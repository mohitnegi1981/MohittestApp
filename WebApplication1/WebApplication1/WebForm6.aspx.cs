using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Linq;
using System.Web.Security;
using System.Net;
using System.IO;

namespace WebApplication1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //selectItem.Items.Remove("Ankit");
            //bool strValidate = Membership.ValidateUser("mohit.negi", "msn&1981");
            string str = "Astronomy 2100:Introduction to Astronomy,Physics;Biochemisty 2104:Introduction to Biochemistry,Advanced Biochemistry;Biology 2102:Non-Majors Biology,Intermediate Biology,Genetics,Cell Biology / Molecular Biology,Biochemistry,Ecology,Environmental Science,Immunology,Microbiology,Botany,Comparative Animal Physiology,Ornithology,Biological Statistics,Scientific Teaching Series,Writing in the Biological Sciences,Lab Notebooks;Chemistry 2106:Gen, Org, Bioc/Chem for Nursing and Allied,Preparatory Chemistry,Liberal Arts Chemistry,General Chemistry,Biochemistry,Organic Chemistry,Environmental Chemistry,Physical Chemistry,Analytical Chemistry,Inorganic Chemistry,Lab Notebooks;College Success 2090:The College Experience,Critical Thinking,Diversity,Emotional Intelligence,Exams and Tests,Learning Styles,Libraries and research,Majors and careers,Money management,Note-Taking,Participating in class,Purpose for attending college,Reading,Relationships,Study skills,ime management,Wellness,Writing in Class;Communication 2082:Film Studies,Journalism,Mass Communication,Speech Communication,Professional Resources;Economics 2098:Business and Economics Statistics,Principles of Macroeconomics,Principles of Microeconomics,Principles of Economics,Survey of Economics,Intermediate Macroeconomics,Intermediate Microeconomics,International Economics,Money and Banking,Public Finance,Game Theory,Intermediate Economics;Geography 2110:Human Geography,World Regional Geography,Introduction to Geographic Information Systems,Physical Geography;Geology 2108:Introduction to Physical Geology,Environmental Geology,Historical Geology,Natural Disasters / Hazards,Environmental Science,Oceanography,Sedimentary Geology / Stratigraphy,Petrology,Principles of Paleontology,Structural Geology / Tectonics,Climate Change / Paleoclimatology;History 2086:U.S. History,European History,World History,The Bedford Series in History and Culture,Writing Guides / Methodology,Profession Resources,1890-1920,1920-1950,1950-1980,1980-present;Mathematics 2112:Euclidean / Non-euclidean Geometries,Partial Differential Equations,Liberal Arts Mathematics,Mathematics for Teachers,Calculus,Linear Algebra,Complex Analysis / Complex Variables,Real Analysis / Classical Analysis,Discrete Mathematics,Number Theory;Music 2092:Drama,Music Appreciation,Interactive Listening Charts,Instruments of the Orchestra,Performance;Physics 2114:Introduction to Astronomy,Physics ;Psychology 2094:Introductory Psychology,Developmental Psychology,Abnormal Psychology,Social and Personality Psychology,Statistics and Research Methods,Biological Psychology and Neuroscience,Cognition, Learning, and Memory,Sensation and Perception,Industrial and Organizational Psychology,Forensic Psychology and Psychology and Law,Health Psychology;Sociology 2116:Contemporary Social Issues Series,Criminology,Deviance,Global Issues,Introduction to Sociology,Political Sociology,Racial and Ethnicity,Research Methods,Social Problems,Sociological Theory,Sociology of Gender,Sociology of Health and Medicine,Sociology of Religion,Technology,Urban Sociology;Statistics 2096:Introductory Statistics,Second Course in Statistics,Statistical Literacy / Liberal Arts Statistics,Statistics for Life Sciences,Business Statistics,Mathematical Statistics,Probability and Statistics";
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //XmlElement XBscript = XElement.Load(@"D:\CourseScripts\FullXBookCourse.xml");
            XElement XBscript;
            XBscript = XElement.Load(@"D:\FullXBookCourse.xml");

            /*IEnumerable<XElement> items = from item in XBscript.Elements("request").Elements("requests").Elements("item")
                                          where item.Parent.Parent.Attribute("cmd").Value == "putitems"
                                          select item;*/

            /*IEnumerable<XElement> items = from item in XBscript.Elements("request").Elements("requests").Elements("item")
                                          //where (string)item.Attribute("value") == "-entityid-"
                                          select item;*/

            /*foreach (XElement item in items.Elements())
            {
                
                
            }*/

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\FullXBookCourse.xml");

            XmlNodeList list = xmlDoc.GetElementsByTagName("param");
            for (int i = 0; i <= list.Count;i++)
            {
                XmlNode childNode = list.Item(i);

            }


        }


        public XmlDocument HideTemplateColumns(XmlDocument xmlTemplate, ArrayList arrlColumnsToHide)
        {
            XmlNode xmlNodeTemp = null;
            /*XmlNodeList xmlTRNodeList = xmlTemplate.SelectNodes(@"//table/*");
            int intNumOfColumns = arrlColumnsToHide.Count;
            int intTableWidth = 0;
            if (xmlTemplate.ChildNodes.Count > 1 && xmlTemplate.ChildNodes[1].Attributes["width"] != null)
            {
                intTableWidth = Convert.ToInt32(xmlTemplate.ChildNodes[1].Attributes["width"].Value) - intNumOfColumns * ForecastingToolConstant.UNIT_COLUMN_WIDTH;
                xmlTemplate.ChildNodes[1].Attributes["width"].Value = intTableWidth.ToString();
            }
            foreach (int intColId in arrlColumnsToHide)
            {
                foreach (XmlNode xmlNode in xmlTRNodeList)
                {
                    for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
                    {
                        xmlNodeTemp = xmlNode.ChildNodes[i];
                        if (intColId == i)
                        {
                            XmlAttribute xmlAttribute = xmlTemplate.CreateAttribute("style");
                            xmlAttribute.Value = "display:none";
                            xmlNodeTemp.Attributes.Append(xmlAttribute);
                            break;
                        }
                    }
                }
            }*/
            return xmlTemplate;
        }

        public bool FTP(string sourceFile, string destFolder)
        {
            
            bool retVal = false;
            string ftpFileURI = string.Empty;
            //fileStatusFlag = -1;
            bool flag = false;
            try
            {
                FileInfo fileInf = new FileInfo(sourceFile);
                //  string uri = destFolder + "/" + fileInf.Name;

                ftpFileURI = "ftp://dev.dlap.bfwpub.com//305154_a//SitebuilderUploads//" + fileInf.Name;

                // Create FtpWebRequest object from the Uri provided
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpFileURI));

                reqFTP.Credentials = new NetworkCredential("root/pxmigration", "Px-Migration-123");
                reqFTP.KeepAlive = false;


                // Specify the command to be executed.             
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;


                // Specify the data transfer type.
                reqFTP.UseBinary = true;
                int buffLength = 1048756; //39000;
                byte[] buff = new byte[buffLength];
                int contentLen;

                if (fileInf.Exists)
                {
                    FileStream fs = fileInf.OpenRead();

                    // Notify the server about the size of the uploaded file
                    reqFTP.ContentLength = fileInf.Length;
                    // Stream to which the file to be upload is written
                    Stream strm = reqFTP.GetRequestStream();
                    strm.WriteTimeout = 1800;

                    // Read from the file stream 2kb at a time
                    // contentLen = fs.Read(buff, 0, buffLength);

                    contentLen = 1;
                    // Till Stream content ends
                    int counter = 0;
                    while (contentLen != 0)
                    {
                        // Write Content from the file stream to the FTP Upload Stream

                        contentLen = fs.Read(buff, 0, buffLength);
                        strm.Write(buff, 0, contentLen);
                        counter++;
                    }

                    // Close the file stream and the Request Stream
                    //strm.Flush();
                    strm.Close();
                    fs.Close();
                    strm.Dispose();
                    fs.Dispose();
                    //Helper.TraceMessage("File Uploaded: " + destFolder + "/" + fileInf.Name);
                    flag = true;

                    
                }
                else
                {
                    flag = false;
                    retVal = true;
                }
                retVal = flag;
            }
            
            catch (Exception ex)
            {

                
            }

            return retVal;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FTP("D:\\jsTree.xml", "ftp://dev.dlap.bfwpub.com//305154_a//SitebuilderUploads//jsTree.xml");
        }



    }
}