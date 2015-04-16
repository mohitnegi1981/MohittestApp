using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Text;

namespace WebApplication1
{
    public partial class directoryTree : System.Web.UI.Page
    {
        public int counter = 0;
        List<JsTreeModel> mainTreelist = new List<JsTreeModel>();
        JsTreeModel parentjstree = new JsTreeModel();
        public string strVal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            /*string str = @"C:\QTI\QTI";
            parentjstree.attr = new JsTreeAttribute(){ title= "QTI"};
            DirectoryInfo dirinfo = new DirectoryInfo(str);*/
            //CreateList(dirinfo,  parentjstree);
            mainTreelist.Add(parentjstree);
            strVal="<ul id=\"browser\" class=\"filetree\">";
            CreateTreeHTML(mainTreelist);
            strVal = "</ul>";
            /*parentjstree.attr = new JsTreeAttribute() { title = "QTI" };
            //listHTTPDirectory("http://192.168.78.89//PX_Registry_Filestore_TEST//QTI", parentjstree);
            //listFTPDirectory("ftp://dev.dlap.bfwpub.com//99574//QTI", parentjstree);
            //mainTreelist.Add(parentjstree);
            strVal="<ul id=\"browser\" class=\"filetree\">";
            //CreateTreeHTML(mainTreelist);
            strVal = "</ul>";
            /*List<DirectoryItem> listing = GetDirectoryInformation("ftp://dev.dlap.bfwpub.com//99574//QTI", "root/pxmigration", "Px-Migration-123");
            List<string> lstdir = GetFtpDirectoryDetails("ftp://dev.dlap.bfwpub.com//99574//QTI");*/
        }

        public static string GetDirectoryListingRegexForUrl(string url)
        {
            //if (url.Contains("http://192.168.78.89//PX_Registry_Filestore_TEST//QTI"))
            //{
                return "\\\"([^\"]*)\\\"";
            /*}
            throw new NotSupportedException();*/
        }
        public string replaceFolderString(string passSTR)
        {
            string strVar = passSTR.Remove(0, 2);
            strVar = strVar.Remove(strVar.Length - 2, 2);
            return strVar;
        }

        public string replaceFileString(string passSTR)
        {
            string strVar = passSTR.Remove(0, 2);
            strVar = strVar.Remove(strVar.Length - 1, 1);
            strVar = strVar.Replace("99574/QTI/", "");
            return strVar;
        }

        public static List<string> GetFtpDirectoryDetails(string strDir)
        {
            List<string> lst_strFiles = new List<string>();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strDir);
                NetworkCredential cred = new NetworkCredential("root/pxmigration", "Px-Migration-123");
                request.Credentials = cred;
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //
                StreamReader file = new StreamReader(response.GetResponseStream());
                while (!file.EndOfStream)
                {
                    lst_strFiles.Add(file.ReadLine());
                }
                file.Close();
                response.Close();
            }
            catch (Exception exc)
            {
                lst_strFiles.Add(exc.Message);
            }
            return lst_strFiles;
        }

        public void listHTTPDirectory(string url, JsTreeModel jsmaintree)
        {
            jsmaintree.children = new List<JsTreeModel>();
            counter = 0;
            string strURL = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            
            request.Credentials = new NetworkCredential("root/pxmigration", "Px-Migration-123");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string html = reader.ReadToEnd();
            Regex regex = new Regex(GetDirectoryListingRegexForUrl(url));
            MatchCollection matches = regex.Matches(html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        //if ((!match.ToString().Contains("Content")) && (!match.ToString().Contains("text/html")) &&  (!match.ToString().Contains("PX_Registry_Filestore_TEST")))
                        if (counter>2)
                        {
                            string dirName = match.ToString();
                            //dirName=dirName.Remove(0,2);
                            string finalString = string.Empty;
                            //lstbox.Items.Add(dirName);
                            if (!match.ToString().Contains('.'))
                            {
                                //finalString=dirName.Remove(dirName.Length - 2, 2);
                                finalString = replaceFolderString(dirName);
                                strURL = "http://192.168.78.89/" + finalString;
                                JsTreeModel jsChildItem = new JsTreeModel();
                                jsChildItem.attr = new JsTreeAttribute() { title = finalString.Replace("PX_Registry_Filestore_TEST//QTI", ""), id = 1 };
                                //jsChildItem.title = dir.Name;
                                jsmaintree.children.Add(jsChildItem);
                                listHTTPDirectory(strURL, jsChildItem);
                            }
                            else
                            {
                                finalString = replaceFileString(dirName);
                                //finalString = finalString.Replace("PX_Registry_Filestore_TEST/QTI/", "");
                                JsTreeModel jsChildItem = new JsTreeModel();
                                jsChildItem.attr = new JsTreeAttribute() { title = finalString,id=0 };

                                //jsChildItem.title = file.Name;
                                
                                jsmaintree.children.Add(jsChildItem);
                            }
                        }
                        counter++;
                    }
                }
            }
            
            reader.Close();
            response.Close();
        }


        public void listFTPDirectory(string url, JsTreeModel jsmaintree)
        {
            jsmaintree.children = new List<JsTreeModel>();
            counter = 0;
            string strURL = url;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential("root/pxmigration", "Px-Migration-123");
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string html = reader.ReadToEnd();
            Regex regex = new Regex(GetDirectoryListingRegexForUrl(url));
            MatchCollection matches = regex.Matches(html);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        //if ((!match.ToString().Contains("Content")) && (!match.ToString().Contains("text/html")) &&  (!match.ToString().Contains("PX_Registry_Filestore_TEST")))
                        if (counter > 2)
                        {
                            string dirName = match.ToString();
                            //dirName=dirName.Remove(0,2);
                            string finalString = string.Empty;
                            //lstbox.Items.Add(dirName);
                            if (!match.ToString().Contains('.'))
                            {
                                //finalString=dirName.Remove(dirName.Length - 2, 2);
                                finalString = replaceFolderString(dirName);
                                strURL = "ftp://dev.dlap.bfwpub.com//" + finalString;
                                JsTreeModel jsChildItem = new JsTreeModel();
                                jsChildItem.attr = new JsTreeAttribute() { title = finalString.Replace("99574/QTI/", ""), id = 1 };
                                //jsChildItem.title = dir.Name;
                                jsmaintree.children.Add(jsChildItem);
                                listFTPDirectory(strURL, jsChildItem);
                            }
                            else
                            {
                                finalString = replaceFileString(dirName);
                                //finalString = finalString.Replace("PX_Registry_Filestore_TEST/QTI/", "");
                                JsTreeModel jsChildItem = new JsTreeModel();
                                jsChildItem.attr = new JsTreeAttribute() { title = finalString, id = 0 };

                                //jsChildItem.title = file.Name;
                                jsmaintree.children.Add(jsChildItem);
                            }
                        }
                        counter++;
                    }
                }
            }

            reader.Close();
            response.Close();
        }

        public void CreateList(DirectoryInfo DirInfo, JsTreeModel jsmaintree)
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

        //Here the data from the database is converted into a tree in a form of HTML .
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
                strVal += "<li><span class=\"folder\">" + jsTreeChild[i].attr.title + "</span>";
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

        // This is where the main Parents of the items get fetched.
        
        static List<DirectoryItem> GetDirectoryInformation(string address, string username, string password)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            List<DirectoryItem> returnValue = new List<DirectoryItem>();
            string[] list = null;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                list = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string line in list)
            {
                // Windows FTP Server Response Format
                // DateCreated    IsDirectory    Name
                string data = line;

                // Parse date
                string date = data.Substring(0, 38);
                DateTime dateTime = DateTime.Parse(date);
                data = data.Remove(0, 24);

                // Parse <DIR>
                string dir = data.Substring(0, 5);
                bool isDirectory = dir.Equals("<dir>", StringComparison.InvariantCultureIgnoreCase);
                data = data.Remove(0, 5);
                data = data.Remove(0, 10);

                // Parse name
                string name = data;

                // Create directory info
                DirectoryItem item = new DirectoryItem();
                item.BaseUri = new Uri(address);
                item.DateCreated = dateTime;
                item.IsDirectory = isDirectory;
                item.Name = name;

                //Debug.WriteLine(item.AbsolutePath);
                item.Items = item.IsDirectory ? GetDirectoryInformation(item.AbsolutePath, username, password) : null;

                returnValue.Add(item);
            }

            return returnValue;
        }

    }


    struct DirectoryItem
    {
        public Uri BaseUri;

        public string AbsolutePath
        {
            get
            {
                return string.Format("{0}/{1}", BaseUri, Name);
            }
        }

        public DateTime DateCreated;
        public bool IsDirectory;
        public string Name;
        public List<DirectoryItem> Items;
    }
}