using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WebApplication1.WebService
{
    /// <summary>
    /// Summary description for IntellisenceSearch
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class IntellisenceSearch : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> Information(string prefixText)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IPRISMDB"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select email from user_master where email like @Name+'%'",con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable  dt = new DataTable();
            da.Fill(dt);
            List<string> CountryNames = new List<string>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                CountryNames.Add(dt.Rows[i][0].ToString());
            }
            return CountryNames;
        }

        [WebMethod, ScriptMethod]
        public bool synctext(string strValue)
        {
            bool paasValue = false;
            if (strValue=="1234")
            {
                paasValue = true;
            }
            return paasValue;
        }
        
        public static List<parent> maketree()
        {

            List<parent> parent = new List<parent>();
            parent par = new parent();
            par.ParentName = "BP Chaturvedi";
            par.childs = new List<child1>();
            child1 ch = new child1();
            ch.Name = "Vikas";
            child1 ch1 = new child1();
            ch.Name = "Kiran";
            par.childs.Add(ch);
            par.childs.Add(ch1);

            parent par1 = new parent();
            par1.ParentName = "Apke papa ka naam";
            par1.childs = new List<child1>();
            child1 ch3 = new child1();
            ch3.Name = "unke lardke";
            child1 ch4 = new child1();
            ch4.Name = "unki beti";
            par1.childs.Add(ch3);
            par1.childs.Add(ch4);
            parent.Add(par);
            parent.Add(par1);


            JavaScriptSerializer serialize = new JavaScriptSerializer();

            string jtree = serialize.Serialize(parent);

            List<parent> response = (List<parent>)serialize.Deserialize(jtree, typeof(List<parent>));


            return response;
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetTreeViewNodes(int id)
        {
                return "[{ \"data\" : \"A node\", \"children\" : [ { \"data\" : \"Only child\",  " + "\"state\" : \"closed\" }], \"state\" : \"open\" }, \"Ajax node \" ]";
        }



        [System.Web.Services.WebMethod]
        public string CreateXMLJason()
        {
            
            List<JsTreeModel> mainTreelist = new List<JsTreeModel>();
            JsTreeModel parentjstree = new JsTreeModel();
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


    }
}
