using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Net;
using System.Text;


namespace WebApplication1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DriveInfo[] drives = DriveInfo.GetDrives();
            //File.Copy(@"z:\\web.config", @"y:\\Sanjay_testing\\web.config");
            //fileCopyUsingFTP();
            //TransferFile("D:\\jsTree.xml", "ftp://dev.dlap.bfwpub.com//305154_a//SitebuilderUploads//jsTree.xml", "root/pxmigration", "Px-Migration-123");
            fileFTPUpload();
        }

        public void fileFTPUpload()
        {
            var fileName = Path.GetFileName("D:\\jsTree.xml");
            var request = (FtpWebRequest)WebRequest.Create("ftp://dev.dlap.bfwpub.com//305154_a//SitebuilderUploads//jsTree.xml");

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("root/pxmigration", "Px-Migration-123");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (var fileStream = File.OpenRead("D:\\jsTree.xml"))
            {
                using (var requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                    requestStream.Close();
                }
            }

            var response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Upload done: {0}", response.StatusDescription);
            response.Close();
            /*FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://dev.dlap.bfwpub.com//305154_a//SitebuilderUploads//jsTree.xml");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("root/pxmigration", "Px-Migration-123");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            FileStream stream = File.OpenRead("D:\\jsTree.xml");
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();*/


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string filepath = flvUp.PostedFile.FileName;

            /*string filepath = @"d:\\SIUI.txt";
            File.Copy(@"\\10.97.71.16\sw\funct.txt", @"\\10.112.37.248\mohit\funct.txt");*/

            //TransferFile(filepath, "\\\\192.168.78.89\\PX_Registry_Filestore_TEST\\sanjay_testing\\SIUI.txt", "VSPXCON01\\PX_MigrationUser", "PX1goUser!");
            //TransferFile("\\\\10.97.71.16\\sw\\funct.txt", "\\\\192.168.78.89\\PX_Registry_Filestore_TEST\\sanjay_testing\\funct.txt", "VSPXCON01\\PX_MigrationUser", "PX1goUser!");


            /*WebClient client = new WebClient();
            NetworkCredential nc = new NetworkCredential("mohit.negi", "msn-1981");
            nc.Domain = "HCLTECH";
            Uri uri = new Uri("\\\\10.112.37.248\\mohit\\");
            client.Credentials = nc;
            byte[] arrReturn = client.UploadFile(uri, filepath);*/

             /*WebClient client = new WebClient();
             //NetworkCredential nc = new NetworkCredential("mohit.negi", "msn-1981");
             NetworkCredential nc = new NetworkCredential(@"VSPXCON01\PX_MigrationUser", "PX1goUser!");
             nc.Domain = "VSPXCON01";
             //Uri uri = new Uri("\\\\10.112.37.248\\mohit\\FF.png");
             Uri uri = new Uri("\\\\192.168.78.89\\PX_Registry_Filestore_TEST\\FF.png");

             client.Credentials = nc;
             byte[] arrReturn = client.UploadFile(uri, filepath);*/

             /*string completeFileName =
             Path.Combine(@"\\10.112.37.248\\mohit\\", flvUp.FileName);

             BinaryReader br = new BinaryReader(flvUp.PostedFile.InputStream);

             FileStream fstm = new FileStream(completeFileName, FileMode.Create, FileAccess.ReadWrite);
             BinaryWriter bw = new BinaryWriter(fstm);

             byte[] buffer = br.ReadBytes(flvUp.PostedFile.ContentLength);
             br.Close();

             bw.Write(buffer);
             bw.Flush();
             bw.Close();*/


            

        }

        public void fileCopyUsingFTP()
        {
            /*WebRequest webRequest = WebRequest.Create(@"\\192.168.78.91\\PX_Registry_Filestore\\web.config");
            WebResponse webResponce;
            StreamWriter strmWriter;
            NetworkCredential nwCR=new NetworkCredential("VSPXCON01\\PX_MigrationUser","PxMigration@");
            webRequest.Credentials=nwCR;
            webRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            webResponce = webRequest.GetResponse();
            strmWriter = new StreamWriter(@"c:\\mohit.config");
            strmWriter.Write(new StreamReader(webResponce.GetResponseStream()).ReadToEnd);
            strmWriter.Close();*/
        }

        public string TransferFile(string originalFile, string destinationFile, string userName, string password)
        {
            /*try
            {*/
                //FileStream for holding the file
                FileStream fStream = new FileStream(destinationFile, FileMode.Create);

                //connect to the server
                FileWebRequest fileRequest = (FileWebRequest)FtpWebRequest.Create(new Uri(originalFile));

                //set the protocol for the request
                fileRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                //provide username and password (for anonymous FTP use the
                //username of Anonymous and password of your email address
                fileRequest.Credentials = new NetworkCredential(userName, password);

                //get the servers response
                WebResponse response = fileRequest.GetResponse();

                //retrieve the response stream
                Stream stream = response.GetResponseStream();

                //create byte buffer
                byte[] buffer = new byte[1024];
                long size = 0;

                //determine how much has been read
                int totalRead = stream.Read(buffer, 0, buffer.Length);

                //loop through the total size of the file
                while (totalRead > 0)
                {
                    size += totalRead;

                    //write to the stream
                    fStream.Write(buffer, 0, totalRead);

                    //get remaining size
                    totalRead = stream.Read(buffer, 0, 1024);
                }

                // Close the streams.
                fStream.Close();
                stream.Close();

                return "File transfered";
            /*}
            catch (SecurityException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }*/
        } 
    }
}