using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.IO;

namespace WebApplication1
{
    public partial class NewJsTree : System.Web.UI.Page
    {
        public List<JsTreeModel> mainTreelist = new List<JsTreeModel>();
        JsTreeModel parentjstree = new JsTreeModel();
        public string strVal = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /*parentjstree.attr = new JsTreeAttribute() { title = "ROOT", name = "Root", type = "folder", path = "ROOT" };
            mainTreelist.Add(parentjstree);
            GetResourceList(parentjstree);*/


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Root));



            StreamReader reeader = new StreamReader(@"D:\Workarea\SB-709\new_resourseList1.xml");
            Root root = (Root)xmlSerializer.Deserialize(reeader);

            strVal = "<ul id=\"browser\" class=\"filetree\"><li>";
            strVal += "<span class=\"folder\"><input type=\"checkbox\" id=\"" + root.Folder[0].Path + "\" onclick=\"SelectChildren(this);\" />" + root.Folder[0].Name + "</span><ul>";
            CreateHTML(root.Folder[0]);
            strVal += "</ul></li></ul>";
            ltrHTML.Text = strVal;
            
        }

        private void GetResourceList(JsTreeModel jsMaintree)
        {
            XDocument xdoc = XDocument.Load(@"D:\Workarea\SB-709\ResourceList_new.xml");
            XElement newDoc = new XElement("root");
            List<XElement> existingNodes = xdoc.Element("resources").Elements("resource").ToList<XElement>(); //ToList<XElement>();
            existingNodes = existingNodes.OrderByDescending(e => (int)e.Attribute("path").Value.Split('/').Length).ToList();  //ordered in descending order of no of subfolders in the path
            
            XElement currentNode = null;
            bool init = false;
            JsTreeModel jsMainFolderItem = new JsTreeModel();
            JsTreeModel jsFolderItem = null;
            JsTreeModel jsSubFolderItem = null;
            foreach (XElement node in existingNodes)
            {
                int len = node.Attribute("path").Value.LastIndexOf("/");
                string foldername = node.Attribute("path").Value.Substring(0, len);
                string lastFolderName = foldername.Split('/').Last();
                
                if (foldername.Split('/').Count() > 1 && init == false)
                {
                    jsMainFolderItem.children = new List<JsTreeModel>();
                    jsFolderItem = new JsTreeModel();
                    init = true;
                    foreach (string fold in foldername.Split('/'))
                    {
                        jsSubFolderItem = new JsTreeModel();
                        XElement xfolder = new XElement("folder", new XAttribute("name", fold));
                        if (currentNode == null)
                            newDoc.Add(xfolder);
                        else
                            currentNode.Add(xfolder);

                        jsSubFolderItem.attr = new JsTreeAttribute { name = fold, type = "folder", };
                        jsFolderItem.children = new List<JsTreeModel>();
                        jsFolderItem.children.Add(jsSubFolderItem);
                        jsFolderItem = jsSubFolderItem;
                        currentNode = xfolder;
                        //jsMainFolderItem.children.Add(jsFolderItem);
                    }
                }
                string filename = node.Attribute("path").Value.Substring(len + 1);
                XElement folder = GetParentFolder(foldername.Split('/'), newDoc);
                if (folder == null)
                {
                    folder = new XElement("folder", new XAttribute("name", foldername));
                    //jsFolderItem.attr = new JsTreeAttribute { name = foldername, type = "folder", };
                    currentNode.Add(folder);
                }
                JsTreeModel jsFileItem = new JsTreeModel();
                jsFolderItem.children = new List<JsTreeModel>();
                jsFileItem.attr = new JsTreeAttribute { name = filename, type = "file" };
                jsFolderItem.children.Add(jsFileItem);

                XElement file = new XElement("file", new XAttribute("name", filename));
                file.Add(new XAttribute("path", node.Attribute("path").Value));
                folder.Add(file);
                currentNode = folder;
                /*if (jsFolderItem.children.Count > 0)
                {
                    jsMaintree = jsFolderItem;
                    parentjstree.children.Add(jsFolderItem);
                }*/
            }
            newDoc.Save(@"D:\Workarea\SB-709\new_resourseList1.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Workarea\SB-709\new_resourseList1.xml");
            
            
            
        }

        
        public void CreateHTML(FolderItem jsTreeFolder)
        {
            for (int i = 0; i < jsTreeFolder.SubFolder.Count; i++)
            {
                strVal += "<li><span class=\"folder\"><input type=\"checkbox\" id=\"" + jsTreeFolder.SubFolder[i].Path + "\" onclick=\"SelectChildren(this);\" />" + jsTreeFolder.SubFolder[i].Name + "</span>";
                if (jsTreeFolder.SubFolder[i].SubFolder.Count > 0)
                {
                    strVal += "<ul>";
                    CreateHTML(jsTreeFolder.SubFolder[i]);
                    strVal += "</ul>";
                    if (jsTreeFolder.SubFolder[i].File.Count > 0)
                    {
                        for (int j = 0; j < jsTreeFolder.SubFolder[i].File.Count; j++)
                        {
                            strVal += "<ul>";
                            strVal += "<li><span class=\"file\"><input type=\"checkbox\" id=\"" + jsTreeFolder.SubFolder[i].File[j].Path + "\" onclick=\"SelectChildren(this);\" />" + jsTreeFolder.SubFolder[i].File[j].Name + "</span></li>";
                            strVal += "</ul>";
                        }
                    }
                }
                else if (jsTreeFolder.SubFolder[i].File.Count > 0)
                {
                    for (int j = 0; j < jsTreeFolder.SubFolder[i].File.Count; j++)
                    {
                        strVal += "<ul>";
                        strVal += "<li><span class=\"file\"><input type=\"checkbox\" id=\"" + jsTreeFolder.SubFolder[i].File[j].Path + "\" onclick=\"SelectChildren(this);\" />" + jsTreeFolder.SubFolder[i].File[j].Name + "</span></li>";
                        strVal += "</ul>";
                    }
                }
                
            }
        }

        void Process(XElement element, int depth, JsTreeModel jstree)
        {
            // For simplicity, argument validation not performed
            jstree.children = new List<JsTreeModel>();
            if (!element.HasElements)
            {
                // element is child with no descendants
                JsTreeModel jsTreeFileItem = new JsTreeModel();
                jsTreeFileItem.attr = new JsTreeAttribute { type = "File", name = element.Attribute("name").Value };
                jstree.children.Add(jsTreeFileItem);
            }
            else
            {
                // element is parent with children
                depth++;
                JsTreeModel jsTreeFolderItem = new JsTreeModel();
                if (element.Attribute("name") != null)
                    jsTreeFolderItem.attr = new JsTreeAttribute { type = "folder", name = element.Attribute("name").Value };
                else
                    jsTreeFolderItem.attr = new JsTreeAttribute { type = "folder", name = "root" };
                
                foreach (var child in element.Elements())
                {
                    Process(child, depth, jsTreeFolderItem);
                }
                parentjstree.children.Add(jsTreeFolderItem);
                jstree.children.Add(jsTreeFolderItem);
                depth--;
            }
        }


        public void createJSTreeModel(XElement xelementItem,JsTreeModel jstreeItemchild)
        {
            XElement XFolderItem = xelementItem.Element("folder");
            string ItemName = string.Empty;
            jstreeItemchild.children = new List<JsTreeModel>();
            if (XFolderItem != null)
            {
                ItemName = XFolderItem.Attribute("name").Value;
                JsTreeModel JsTreeFolder = new JsTreeModel();
                JsTreeFolder.attr = new JsTreeAttribute { name = ItemName };
                jstreeItemchild.children.Add(JsTreeFolder);
                createJSTreeModel(XFolderItem, jstreeItemchild);
            }
            else
            {
                XElement XFilItem = xelementItem.Element("file");
                if (XFilItem!=null)
                {
                    ItemName = XFilItem.Attribute("name").Value;
                    JsTreeModel JsTreeFolder = new JsTreeModel();
                    JsTreeFolder.attr = new JsTreeAttribute { name = ItemName };
                    jstreeItemchild.children.Add(JsTreeFolder);
                }
            }
            
            
        }

        public XElement GetParentFolder(string[] folders, XElement root)
        {
            XElement node = root;
            for (int i = 0; i < folders.Count(); i++)
            {
                //if (i>0)
                try
                {
                    if (node.Descendants("folder").Count() > 0)
                        node = node.Descendants("folder").First();
                }
                catch
                {
                    if (node != null)
                    {
                        if (node.NextNode != null)
                            node = (XElement)node.NextNode;
                    }
                }
                if (folders[i] == node.Attribute("name").Value)
                {
                    continue;
                }
                else
                {
                    XElement prev = null;
                    while (node != null)
                    {
                        prev = node;
                        node = (XElement)node.NextNode;
                        if (node != null && folders[i] == node.Attribute("name").Value)
                            return node;
                    }
                    if (node == null)
                    {
                        if (i < folders.Count() - 1)  //means there are more subfolders in between which are not already created
                        {
                            node = prev.Parent;
                            while (i <= folders.Count() - 1)
                            {
                                node = CreateNewFolder(node, folders[i]);
                                i++;
                            }
                            return node;
                        }
                        else if (i == folders.Count() - 1)
                        {
                            return CreateNewFolder(prev.Parent, folders[i]);
                        }
                        else
                        {
                            while (prev.Parent != null)
                            {
                                if (prev.Attribute("name").Value == folders[i])
                                    return prev;
                                prev = prev.Parent;
                            }
                            if (prev == null)
                                return root;
                        }
                    }
                    else
                        return CreateNewFolder(node.Parent, folders[i]);
                }
            }
            return node;
        }
        private XElement CreateNewFolder(XElement current, string newNodeName)
        {
            XElement newFolder = new XElement("folder");
            newFolder.Add(new XAttribute("name", newNodeName));
            current.Add(newFolder);
            return newFolder;
        }
        

        
    }
}