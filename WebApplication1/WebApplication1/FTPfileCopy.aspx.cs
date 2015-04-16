using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Net;
using System.IO;


namespace WebApplication1
{
    public partial class FTPfileCopy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //copyFileFromFTP();
            ftpSetting();
        }

        public void copyFileFromFTP()
        {

            string MyFile = @"d:\1_1.html";

            //string url = "ftpUrl/FileName";
            string url = "ftp://qa.dlap.bfwpub.com/6714_a/SitebuilderUploads/1_1.html";
            
            using (WebClient ftpClient = new WebClient())
            {
                ftpClient.Credentials = new System.Net.NetworkCredential("root/pxmigration", "Px-Migration-123");
                ftpClient.DownloadFile(url, MyFile);
            }
        }

        public void ftpSetting()
        {
            string ftplocation = "ftp://dev.dlap.bfwpub.com/6714_a/SitebuilderUploads/";
            string file = @"d:\03030-02.htm"; // Or on FreeBSD: "/usr/home/jared/test2.txt";
            string user = "root/pxmigration";
            string password = "Px-Migration-123";
            UploadToFTP(ftplocation, file, user, password);
        }


        static void UploadToFTP(String inFTPServerAndPath, String inFullPathToLocalFile, String inUsername, String inPassword)
        {
            // Get the local file name: C:\Users\Rhyous\Desktop\File1.zip
            // and get just the filename: File1.zip. This is so we can add it
            // to the full URI.
            String filename = Path.GetFileName(inFullPathToLocalFile);

            // Open a request using the full URI, c/file.ext
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(inFTPServerAndPath + "/" + filename);

            // Configure the connection request
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(inUsername, inPassword);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            // Create a stream from the file
            FileStream stream = File.OpenRead(inFullPathToLocalFile);
            byte[] buffer = new byte[stream.Length];

            // Read the file into the a local stream
            stream.Read(buffer, 0, buffer.Length);

            // Close the local stream
            stream.Close();

            // Create a stream to the FTP server
            Stream reqStream = request.GetRequestStream();

            // Write the local stream to the FTP stream
            // 2 bytes at a time
            int offset = 0;
            int chunk = (buffer.Length > 2048) ? 2048 : buffer.Length;
            while (offset < buffer.Length)
            {
                reqStream.Write(buffer, offset, chunk);
                offset += chunk;
                chunk = (buffer.Length - offset < chunk) ? (buffer.Length - offset) : chunk;
            }
            // Close the stream to the FTP server
            reqStream.Close();
        }

    }
}