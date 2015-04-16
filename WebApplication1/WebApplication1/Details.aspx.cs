using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication1
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Response.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append("<br />");
            string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["IPRISMDB"].ConnectionString;
            string query = "select email from country_bu where country_id=@CustId"; 
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "USP_GetPersonnelSearchDetails";
            cmd.Parameters.Add(new SqlParameter("@lid", "1001"));
            //cmd.Parameters.AddWithValue("@CustId", Request.QueryString["CatId"]);
            conn.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sb.Append(ds.Tables[0].Rows[i].ToString() + "<br />");
            }
                /*while (dr.Read())
                {
                    sb.Append(dr[0].ToString() + "<br />");
                    //sb.Append(dr[1].ToString() + "<br />");
                    //sb.Append(dr[2].ToString() + "<br />");
                    //sb.Append(dr[3].ToString() + "<br />");
                    //sb.Append(dr[4].ToString() + "<br />");
                    //sb.Append(dr[5].ToString() + "<br />");
                    //sb.Append(dr[6].ToString() + "<br />");
                }
                dr.Close();
                dr.Dispose();*/
                conn.Close();
            conn.Dispose();
            //bindfromWCF();
            Response.Write(sb.ToString());
            Response.End();
            
        }

        public void bindfromWCF()
        {
            WebService.IntellisenceSearch name = new WebApplication1.WebService.IntellisenceSearch();
            
        }

        
    }
}
