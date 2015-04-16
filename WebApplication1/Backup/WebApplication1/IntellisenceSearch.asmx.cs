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
    }
}
