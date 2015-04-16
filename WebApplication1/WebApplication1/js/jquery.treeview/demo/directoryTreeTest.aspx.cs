using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class directoryTreeTest : System.Web.UI.Page
    {
        List<JsTreeModel> mainTreelist = new List<JsTreeModel>();
        JsTreeModel parentjstree = new JsTreeModel();
        public string strVal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = @"C:\QTI\QTI";
            parentjstree.attr = new JsTreeAttribute(){ title= "QTI"};
            DirectoryInfo dirinfo = new DirectoryInfo(str);
            CreateList(dirinfo,  parentjstree);
            mainTreelist.Add(parentjstree);
            strVal = "<ul id=\"browser\" class=\"filetree\">";
            CreateTreeHTML(mainTreelist);
            strVal += "</ul>";
            ltrHTML.Text = strVal;
            //maketree();
        }


        //Here the data from the database is converted into a tree in a form of HTML .
        public void CreateTreeHTML(List<JsTreeModel> jsTreeChild)
        {
            string strItemid = string.Empty;

            for (int i = 0; i < jsTreeChild.Count; i++)
            {
                strItemid = jsTreeChild[i].attr.id.ToString();
                string fileFolderName = jsTreeChild[i].attr.title.ToString();

                if (fileFolderName.Contains('.'))
                    strVal += "<li><span class=\"file\">" + jsTreeChild[i].attr.title + "</span>";
                else
                    strVal += "<li><span class=\"folder\">" + jsTreeChild[i].attr.title + "</span>";
                
                
                if (jsTreeChild[i].children != null)
                {
                    if (jsTreeChild[i].children.Count > 0)
                    {
                        strVal += "<ul>";
                        CreateTreeHTML(jsTreeChild[i].children);
                        strVal += "</ul>";
                    }
                }
                strVal += "</li>";
            }
            

        }

        // This is where the main Parents of the items get fetched.



        public void CreateList(DirectoryInfo DirInfo,JsTreeModel jsmaintree)
        {
            jsmaintree.children = new List<JsTreeModel>();
            System.IO.FileInfo[] fileInfo = DirInfo.GetFiles();
            System.IO.DirectoryInfo[] dirInfo = DirInfo.GetDirectories();
            if (fileInfo.Length > 0)
            {
                foreach (System.IO.FileInfo file in fileInfo)
                {
                    JsTreeModel jsChildItem = new JsTreeModel();
                    jsChildItem.attr = new JsTreeAttribute() { title = file.Name };
                    
                    //jsChildItem.title = file.Name;
                    jsmaintree.children.Add(jsChildItem);
                }
            }
            if (dirInfo.Length > 0)
            {
                foreach (System.IO.DirectoryInfo dir in dirInfo)
                {
                    JsTreeModel jsChildItem = new JsTreeModel();
                    jsChildItem.attr = new JsTreeAttribute() { title = dir.Name };
                    //jsChildItem.title = dir.Name;
                    jsmaintree.children.Add(jsChildItem);
                    CreateList(dir, jsChildItem);
                }
            }

        }

        
    }
}