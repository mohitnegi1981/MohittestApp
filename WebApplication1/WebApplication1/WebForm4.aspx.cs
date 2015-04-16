using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Web.Script.Serialization;


namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public int counter = 0;
        public List<JsTreeModel> mainTreelist = new List<JsTreeModel>();
        JsTreeModel parentjstree = new JsTreeModel();
        public string strVal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //ServiceReference1.ISiteMigrationService svc=new SiteMigrationServiceClient();
            //bool b = svc.MigrateToPX(6395, "dev", -1, "csb900@bfwpub", "mytesting", "Launchpad", "yes", 900, "csb900@bfwpub.com", true, true, true, true, 3, "migration1#2$webservice");
            
            
        }

        public void ReadXML()
        {
            //FileInfo fileinfo = new FileInfo(@"C:\QTI\resourses.xml");
            TextReader tr = new StreamReader(@"C:\QTI\resourses.xml");
            List<XElement> itemList = new List<XElement>();
            string importXml = tr.ReadToEnd();
            tr.Close();
            tr = null;
            string strXML = importXml.Replace("xmlns", "abc");
            // Get all items (questions)
            XDocument xDoc = XDocument.Parse(strXML);
            itemList = new List<XElement>(xDoc.Element("response").Elements("resources").Elements("resource"));
            XmlDocument xmlNewDoc = new XmlDocument();
            string folderPath = string.Empty;
            string filePath = string.Empty;
            XmlElement xmlItemFolder = null;
            XmlElement xmlItemFile = null;
            XmlElement xmlItemRoot = xmlNewDoc.CreateElement("root");
            for (int i = 0; i < itemList.Count; i++)
            {
                XElement xmlItem = itemList[i];
                if (xmlItem.Attribute("size").Value == "0")
                {
                    XmlElement xmlItemFolderNew = xmlNewDoc.CreateElement("folder");
                    
                    if (folderPath != xmlItem.Attribute("path").Value)
                    {
                        if (xmlItemFolder!=null)
                        {
                            xmlItemRoot.AppendChild(xmlItemFolder);
                        }
                        xmlItemFolder = xmlItemFolderNew;
                    }
                    else
                        xmlItemFolder = xmlNewDoc.CreateElement("folder");
                    
                    JsTreeModel jsChildFolderItem = new JsTreeModel();
                    jsChildFolderItem.attr = new JsTreeAttribute() { title = folderPath };
                    
                    xmlItemFolder.SetAttribute("name", "folder");
                    folderPath = xmlItem.Attribute("path").Value;
                    xmlItemFolder.SetAttribute("path", folderPath);
                }
                else if(xmlItem.Attribute("size").Value != "0")
                {
                    xmlItemFile = xmlNewDoc.CreateElement("file");
                    filePath = xmlItem.Attribute("path").Value;
                    xmlItemFile.SetAttribute("path",filePath);
                    
                }
                if (filePath.Contains(folderPath) && filePath != "")
                {
                    xmlItemFolder.AppendChild(xmlItemFile);
                    
                }
                if (i == itemList.Count-1)
                {
                    xmlItemRoot.AppendChild(xmlItemFolder);
                }
            }
            xmlNewDoc.AppendChild(xmlItemRoot);
            xmlNewDoc.Save(@"d:\test.xml");

        }

        public void ReadXMLtoCreateXML()
        {
            //FileInfo fileinfo = new FileInfo(@"C:\QTI\resourses.xml");
            TextReader tr = new StreamReader(@"C:\QTI\resourses_new.xml");
            List<XElement> itemList = new List<XElement>();
            string importXml = tr.ReadToEnd();
            tr.Close();
            tr = null;
            string strXML = importXml.Replace("xmlns", "abc");
            // Get all items (questions)
            XDocument xDoc = XDocument.Parse(strXML);
            itemList = new List<XElement>(xDoc.Element("response").Elements("resources").Elements("resource"));
            XmlDocument xmlNewDoc = new XmlDocument();
            string folderPath = string.Empty;
            string filePath = string.Empty;
            XmlElement xmlItemFolder = null;
            XmlElement xmlItemFile = null;
            XmlElement xmlItemRoot = xmlNewDoc.CreateElement("root");
            for (int i = 0; i < itemList.Count; i++)
            {
                XElement xmlItem = itemList[i];
                if (xmlItem.Attribute("size").Value == "0")
                {
                    XmlElement xmlItemFolderNew = xmlNewDoc.CreateElement("folder");

                    if (folderPath != xmlItem.Attribute("path").Value)
                    {
                        if (xmlItemFolder != null)
                        {
                            xmlItemRoot.AppendChild(xmlItemFolder);
                        }
                        xmlItemFolder = xmlItemFolderNew;
                    }
                    else
                        xmlItemFolder = xmlNewDoc.CreateElement("folder");

                    JsTreeModel jsChildFolderItem = new JsTreeModel();
                    jsChildFolderItem.attr = new JsTreeAttribute() { title = folderPath };

                    xmlItemFolder.SetAttribute("name", "folder");
                    folderPath = xmlItem.Attribute("path").Value;
                    xmlItemFolder.SetAttribute("path", folderPath);
                }
                else if (xmlItem.Attribute("size").Value != "0")
                {
                    xmlItemFile = xmlNewDoc.CreateElement("file");
                    filePath = xmlItem.Attribute("path").Value;
                    xmlItemFile.SetAttribute("path", filePath);

                }
                if (filePath.Contains(folderPath) && filePath != "")
                {
                    xmlItemFolder.AppendChild(xmlItemFile);

                }
                if (i == itemList.Count - 1)
                {
                    xmlItemRoot.AppendChild(xmlItemFolder);
                }
            }
            xmlNewDoc.AppendChild(xmlItemRoot);
            xmlNewDoc.Save(@"d:\test.xml");


        }

        

        public void CreateXML(JsTreeModel jsMaintree)
        {
            
            //FileInfo fileinfo = new FileInfo(@"C:\QTI\resourses.xml");
            TextReader tr = new StreamReader(@"C:\QTI\resourses.xml");
            List<XElement> itemList = new List<XElement>();
            parentjstree.children = new List<JsTreeModel>();
            string importXml = tr.ReadToEnd();
            tr.Close();
            tr = null;
            string strXML = importXml.Replace("xmlns", "abc");
            // Get all items (questions)
            XDocument xDoc = XDocument.Parse(strXML);
            itemList = new List<XElement>(xDoc.Element("response").Elements("resources").Elements("resource"));
            XmlDocument xmlNewDoc = new XmlDocument();
            string folderPath = string.Empty;
            string filePath = string.Empty;
            XmlElement xmlItemFolder = null;
            XmlElement xmlItemFile = null;
            XmlElement xmlItemRoot = xmlNewDoc.CreateElement("root");
            for (int i = 0; i < itemList.Count; i++)
            {
                XElement xmlItem = itemList[i];
                if(xmlItem.Attribute("size").Value == "0")
                {
                    JsTreeModel jsFolderItem = new JsTreeModel();
                    folderPath = xmlItem.Attribute("path").Value;
                    xmlItemFolder = xmlNewDoc.CreateElement("folder");
                    xmlItemFolder.SetAttribute("path", folderPath);
                    jsFolderItem.attr = new JsTreeAttribute { title = folderPath, name = folderPath, type = "folder" };
                    jsFolderItem.children = new List<JsTreeModel>();
                    for (int j = 0; j < itemList.Count; j++)
                    {
                        XElement xmlItemNew = itemList[j];
                        if (xmlItemNew.Attribute("size").Value != "0")
                        {
                            filePath = xmlItemNew.Attribute("path").Value;
                            string filePathtoMatch = filePath.Substring(0, filePath.LastIndexOf('/'));
                            string filename = filePath.Substring(filePath.LastIndexOf('/') +1 , filePath.Length - filePath.LastIndexOf('/')-1 );
                            xmlItemFile = xmlNewDoc.CreateElement("file");
                            filePath = xmlItemNew.Attribute("path").Value;
                            xmlItemFile.SetAttribute("path", filePath);
                            xmlItemFile.SetAttribute("name", filename);

                            //JsTreeModel jsFileItem = new JsTreeModel();
                            
                            if (filePathtoMatch == folderPath)
                            {
                                xmlItemFolder.AppendChild(xmlItemFile);
                                //jsFolderItem.children = new List<JsTreeModel>();
                                JsTreeModel jsFileItem = new JsTreeModel();
                                jsFileItem.attr = new JsTreeAttribute { title = filePath, name = filename ,type="file"};
                                jsFolderItem.children.Add(jsFileItem);
                            }
                        }
                    }
                    xmlItemRoot.AppendChild(xmlItemFolder);
                    if (jsFolderItem.children.Count > 0)
                    {
                        jsMaintree = jsFolderItem;
                        
                        parentjstree.children.Add(jsMaintree);
                    }
                }
            }
            xmlNewDoc.AppendChild(xmlItemRoot);
            xmlNewDoc.Save(@"d:\test.xml");
        }

        
        
        public string CreateXMLJason()
        {
            parentjstree.attr = new JsTreeAttribute() { title = "ROOT", name = "Root", type = "folder" };
            //CreateXML(parentjstree);
            
            //FileInfo fileinfo = new FileInfo(@"C:\QTI\resourses.xml");
            TextReader tr = new StreamReader(@"C:\QTI\resourses.xml");
            List<XElement> itemList = new List<XElement>();
            parentjstree.children = new List<JsTreeModel>();
            string importXml = tr.ReadToEnd();
            tr.Close();
            tr = null;
            string strXML = importXml.Replace("xmlns", "abc");
            // Get all items (questions)
            XDocument xDoc = XDocument.Parse(strXML);
            itemList = new List<XElement>(xDoc.Element("response").Elements("resources").Elements("resource"));
            XmlDocument xmlNewDoc = new XmlDocument();
            string folderPath = string.Empty;
            string filePath = string.Empty;
            XmlElement xmlItemFolder = null;
            XmlElement xmlItemFile = null;
            XmlElement xmlItemRoot = xmlNewDoc.CreateElement("root");
            for (int i = 0; i < itemList.Count; i++)
            {
                XElement xmlItem = itemList[i];
                if (xmlItem.Attribute("size").Value == "0")
                {
                    JsTreeModel jsFolderItem = new JsTreeModel();
                    folderPath = xmlItem.Attribute("path").Value;
                    xmlItemFolder = xmlNewDoc.CreateElement("folder");
                    xmlItemFolder.SetAttribute("path", folderPath);
                    jsFolderItem.attr = new JsTreeAttribute { title = folderPath, name = folderPath, type = "folder" };
                    jsFolderItem.children = new List<JsTreeModel>();
                    for (int j = 0; j < itemList.Count; j++)
                    {
                        XElement xmlItemNew = itemList[j];
                        if (xmlItemNew.Attribute("size").Value != "0")
                        {
                            filePath = xmlItemNew.Attribute("path").Value;
                            string filePathtoMatch = filePath.Substring(0, filePath.LastIndexOf('/'));
                            string filename = filePath.Substring(filePath.LastIndexOf('/') + 1, filePath.Length - filePath.LastIndexOf('/') - 1);
                            xmlItemFile = xmlNewDoc.CreateElement("file");
                            filePath = xmlItemNew.Attribute("path").Value;
                            xmlItemFile.SetAttribute("path", filePath);
                            xmlItemFile.SetAttribute("name", filename);

                            //JsTreeModel jsFileItem = new JsTreeModel();

                            if (filePathtoMatch == folderPath)
                            {
                                xmlItemFolder.AppendChild(xmlItemFile);
                                //jsFolderItem.children = new List<JsTreeModel>();
                                JsTreeModel jsFileItem = new JsTreeModel();
                                jsFileItem.attr = new JsTreeAttribute { title = filePath, name = filename, type = "file" };
                                jsFolderItem.children.Add(jsFileItem);
                            }
                        }
                    }
                    xmlItemRoot.AppendChild(xmlItemFolder);
                    if (jsFolderItem.children.Count > 0)
                    {
                        //jsMaintree = jsFolderItem;

                        parentjstree.children.Add(jsFolderItem);
                    }
                }
            } 
            mainTreelist.Add(parentjstree);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    return (serializer.Serialize(mainTreelist));
            /*xmlNewDoc.AppendChild(xmlItemRoot);
            xmlNewDoc.Save(@"d:\test.xml");*/
        }

        public void CreateTreeHTML(List<JsTreeModel> jsTreeChild)
        {
            string strItemid = string.Empty;

            for (int i = 0; i < jsTreeChild.Count; i++)
            {
                //strItemid = jsTreeChild[i].attr.id.ToString();
                /*if (strItemSelected.Contains(strItemid))
                {
                    strVal += "<li><span class=\"folder\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].attr.id + "\" onclick=\"SelectChildren(this);\" checked=\"true\" />" + jsTreeChild[i].attr.title + "</span>";
                }
                else
                {*/
                if (jsTreeChild[i].attr.type == "folder")
                {
                    //strVal += "<li><span class=\"folder\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].attr.title + "\" onclick=\"SelectChildren(this);\"  />" + jsTreeChild[i].attr.name + "</span>";
                    strVal += "<li><span class=\"folder\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].attr.title + "\" onclick=\"SelectChildren(this);\"  />" + jsTreeChild[i].attr.name + "</span>";//jsTreeChild[i].attr.title
                }
                else
                {
                    //strVal += "<li><span class=\"file\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].attr.title + "\" onclick=\"SelectChildren(this);\" />" + jsTreeChild[i].attr.name + "</span>";
                    strVal += "<li><span class=\"file\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].attr.title + "\" onclick=\"SelectChildren(this);\" />" + jsTreeChild[i].attr.name + "</span>";//jsTreeChild[i].attr.title
                }

                

                //}
                if (jsTreeChild[i].children != null)
                {
                    if (jsTreeChild[i].children.Count > 0)
                    {

                        strVal += "<ul>";
                        CreateTreeHTML(jsTreeChild[i].children);
                        strVal += "</ul>";
                    }
                    /*else
                    {
                        strVal += "<ul>";
                        strVal += "<li><span class=\"folder\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].attr.id + "\" onclick=\"SelectChildren(this);\" />" + jsTreeChild[i].attr.title + "</span>";
                        strVal += "</ul>";
                    }*/
                }
                /*else
                {
                    strVal += "<ul>";
                    strVal += "<li><span class=\"folder\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].attr.id + "\" onclick=\"SelectChildren(this);\" />" + jsTreeChild[i].attr.title + "</span>";
                    strVal += "</ul>";
                }*/

                strVal += "</li>";
            }
            ltrHTML.Text = strVal;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //Add the save function here ex store the text to DB
            //Here we only move between the two textboxes to show that it works
            TextBox2.Text = TextBox1.Text;
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Save();
        }
    }
    /*[XmlRoot("folder")]
    [Serializable]
    public class Folder
    {
        [XmlElement("file")]
        public string File { get; set; }


        
    }*/
}
