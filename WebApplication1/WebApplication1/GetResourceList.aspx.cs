using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;


namespace WebApplication1
{
    public partial class GetResourceList : System.Web.UI.Page
    {
        public string strVal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            strVal = "<ul id=\"browser\" class=\"filetree\">";
            getResourecList();
            strVal = "</ul>";
        }


        public void getResourecList()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@"C:\QTI\resourseList_mini.xml");
            List<FileItem> files = ds.Tables["resource"].AsEnumerable().Select(data => new FileItem()
            {
                Path = Path.GetDirectoryName(Convert.ToString(data["path"])),
                Parents = (Path.GetDirectoryName(Convert.ToString(data["path"]))).Split(Path.DirectorySeparatorChar),
                Name = Path.GetFileName(Convert.ToString(data["path"]))
            }).ToList();
            Dictionary<string, string> dicIds = new Dictionary<string, string>();
            foreach (FileItem file in files)
            {
                foreach (string parent in file.Parents)
                {
                    if (!dicIds.ContainsKey(parent))
                        dicIds.Add(parent, Guid.NewGuid().ToString());
                }
            }

            DataTable dt = new DataTable();
            foreach (FileItem file in files)
            {
                for (int i = 0; i < file.Parents.Length; i++)
                {
                    if (!dt.Columns.Contains("Parent" + i))
                        dt.Columns.Add("Parent" + i);
                }
                if (!dt.Columns.Contains("Path"))
                    dt.Columns.Add("Path");

                if (!dt.Columns.Contains("Name"))
                    dt.Columns.Add("Name");
                DataRow row = dt.NewRow();
                row["Name"] = file.Name;
                row["Path"] = file.Path;
                for (int i = 0; i < file.Parents.Length; i++)
                {
                    row["Parent" + i] = file.Parents[i];
                }
                dt.Rows.Add(row);
            }
            int totalRows = dt.Rows.Count;
            int parentCols = dt.Columns.Count - 2;
            var f = dt.AsEnumerable();
            List<FolderItem> folders = new List<FolderItem>();
            foreach (DataRow r in f)
            {
                FolderItem folder = new FolderItem();
                folder.Name = Convert.ToString(r["Parent0"]);
                folder.Id = dicIds[folder.Name];
                folder.ParentId = "root";
                folder.SubFolder = new List<FolderItem>();
                for (int i = 1; i < parentCols; i++)
                {
                    FolderItem subfolder = new FolderItem();
                    subfolder.Name = Convert.ToString(r["Parent" + i]);
                    subfolder.Id = dicIds[subfolder.Name];
                    subfolder.ParentId = dicIds[Convert.ToString(r["Parent" + (i - 1)])];
                    if (String.IsNullOrWhiteSpace(Convert.ToString(r[i + 1])))
                    {
                        subfolder.File = new List<FileItem>()
                        { new FileItem()
                        {
                            Name = Convert.ToString(r["Name"]),
                            Id = Guid.NewGuid().ToString(),
                            ParentId = subfolder.Id
                        }
                        };
                        folder.SubFolder.Add(subfolder);
                        break;
                    }
                    if (i + 1 == parentCols)
                        subfolder.File = new List<FileItem>()
                        {
                            new FileItem(){
                            Name = Convert.ToString(r["Name"]),
                            Id = Guid.NewGuid().ToString(),
                            ParentId = subfolder.Id
                            }
                        };
                    folder.SubFolder.Add(subfolder);
                }
                folders.Add(folder);
            }
            string fullLocation = @"c:\QTI\output.xml";
            XmlSerializer serialize = new XmlSerializer(typeof(List<FolderItem>));
            System.IO.File.Create(fullLocation).Close();
            using (XmlTextWriter xmlWriter = new XmlTextWriter(fullLocation, Encoding.UTF8))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                serialize.Serialize(xmlWriter, folders, ns);
            }

            //read output
            ds = new DataSet();
            ds.ReadXml(fullLocation);

            List<Model> modelList = new List<Model>();
            foreach (DataTable dataTableOutput in ds.Tables)
            {
                foreach (DataRow dr in dataTableOutput.Rows)
                {
                    Model model = new Model();
                    model.Name = Convert.ToString(dr["Name"]);
                    model.Id = Convert.ToString(dr["id"]);
                    model.ParentId = Convert.ToString(dr["parentId"]);
                    modelList.Add(model);
                }
            }
            var list = modelList.GroupBy(p => p.Id).Select(g => g.First()).ToList();
            list.ForEach(data =>
            {
                data.Children = list.Where(ch => ch.ParentId == data.Id).ToList();
            });
            var tree = list.Where(data => data.ParentId == "root").Select(data => data).ToList();
            List<Model> treelist = tree;
            CreateHTML(treelist);
        }

        public void CreateHTML(List<Model> jsTreeChild)
        {
            for (int i = 0; i < jsTreeChild.Count; i++)
            {
                if (jsTreeChild[i].FullPath == "folder")
                {
                    strVal += "<li><span class=\"folder\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].Name + "\" />" + jsTreeChild[i].Name + "</span>";//jsTreeChild[i].attr.title
                }
                else
                {
                    strVal += "<li><span class=\"file\"><input type=\"checkbox\" id=\"" + jsTreeChild[i].Name + "\" />" + jsTreeChild[i].Name + "</span>";//jsTreeChild[i].attr.title
                }
                if (jsTreeChild[i].Children != null)
                {
                    if (jsTreeChild[i].Children.Count > 0)
                    {
                        strVal += "<ul>";
                        CreateHTML(jsTreeChild[i].Children);
                        strVal += "</ul>";
                    }
                }
                strVal += "</li>";
            }
            ltrHTML.Text = strVal;
        }
    }
}