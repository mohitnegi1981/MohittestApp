using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace WebApplication1
{
    public partial class test : System.Web.UI.Page
    {
        private int count=1;
        Dictionary<string, List<string>> dicDirList = new Dictionary<string, List<string>>();
        List<string> strSubDir = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> dicDirList = new Dictionary<string, List<string>>(); 
            string strRootLocation=@"D:\CourseScripts\PRODUCTS";
            dicDirList= GetFolderStructure(strRootLocation); 
        }

        public Dictionary<string, List<string>> GetFolderStructure(string rootLocation)
        {
            DirectoryInfo dir = new DirectoryInfo(rootLocation);
            DirectoryInfo[]  dirInfo=dir.GetDirectories("*.*");
            string strroot;
            strSubDir = new List<string>();
            foreach (DirectoryInfo d in dirInfo)
            {
                
                if(d.Name != "_GLOBAL")
                {
                    if (!d.Name.Contains(".svn"))
                    {
                        DirectoryInfo subDir = new DirectoryInfo(rootLocation + "\\" + d.Name);
                        if (count < 2)
                        {
                            ++count;
                            GetFolderStructure(rootLocation + "\\" + d.Name);
                            /*if (!dicDirList.Keys.Contains(d.Name))
                            {
                                dicDirList.Add(d.Name, strSubDir);

                            }*/
                        }
                        else
                        {
                            strSubDir.Add(d.Name);
                        }
                        
                    }
                }
            }
            count = 1;
            
           return dicDirList;

        }

        public Dictionary<string, List<string>> GetFolderStructure1(string rootLocation)
        {
            Dictionary<string, List<string>> dicDirList = new Dictionary<string, List<string>>();
            DirectoryInfo dir = new DirectoryInfo(rootLocation);
            DirectoryInfo[] dirInfo = dir.GetDirectories("*.*");
            foreach (DirectoryInfo d in dirInfo)
            {
                if (d.Name != "_GLOBAL")
                {
                    if (!d.Name.Contains(".svn"))
                    {
                        List<string> strSubDir = new List<string>();
                        DirectoryInfo subDir = new DirectoryInfo(rootLocation + "\\" + d.Name);
                        DirectoryInfo[] subDirInfo = subDir.GetDirectories("*.*");
                        foreach (DirectoryInfo subd in subDirInfo)
                        {
                            if (subd.Name != "_GLOBAL")
                            {
                                if (!subd.Name.Contains(".svn"))
                                {
                                    strSubDir.Add(subd.Name);
                                }
                            }
                        }
                        dicDirList.Add(d.Name, strSubDir);
                    }
                }
            }

            return dicDirList;

        }
    }
}