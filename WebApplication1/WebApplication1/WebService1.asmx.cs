using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.Configuration;
using System.Threading;
using System.Text;
using System.IO;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RequestState
    {
        // This class stores the request state of the request. 
        public WebRequest request;
        public RequestState()
        {
            request = null;
        }
    }
    public class WebService1 : System.Web.Services.WebService
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public WebRequest request;
       
        [WebMethod]
        public string Proxy(string szURL, string PostData)
        {
            
            if (ConfigurationManager.AppSettings["RAgProxyDomain"] != null)
            {
                szURL = ConfigurationManager.AppSettings["RAgProxyDomain"] + szURL.Substring(szURL.IndexOf("/BFWglobal"));
            }
            else
            {
                szURL = "http://int-bcs.bedfordstmartins.com" + szURL.Substring(szURL.IndexOf("/BFWglobal"));
            }
            WebRequest request = WebRequest.Create(szURL);
            request.Method = "POST";
            RequestState state = new RequestState
            {
                request = request
            };
            request.ContentType = "application/x-www-form-urlencoded";
            state.request.Method = "POST";
            state.progress = state.progress + "Method set ----\n";
            state.PostData = PostData;
            state.progress = state.progress + "PostData set ----\n";
            request.BeginGetRequestStream(new AsyncCallback(RAgLocalWebService.ReadCallback), state);
            allDone.WaitOne();
            WebResponse response = request.GetResponse();
            state.progress = state.progress + "Request sent ----\n";
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            char[] buffer = new char[0x100];
            int length = reader.Read(buffer, 0, 0x100);
            string str = "";
            while (length > 0)
            {
                string str2 = new string(buffer, 0, length);
                str = str + str2;
                length = reader.Read(buffer, 0, 0x100);
            }
            responseStream.Close();
            reader.Close();
            response.Close();
            return str;
        }

    }
}
