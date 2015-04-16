using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace WebApplication1
{
    public partial class FixHeader : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDbConn1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*DataSet ds = new DataSet();
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sqldb = new SqlDataAdapter("Select top 10 * from tblsinglecontent", sqlconn);
            sqldb.Fill(ds);
            GridViewLeaveHistory.DataSource = ds;
            GridViewLeaveHistory.DataBind();*/
            if(hdnValue.Value == "1" )
            {
                createButtons();
            }
            

            
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            GetDataFromDatabase(lblFileName.Text);
        }

        private void GetDataFromDatabase(string fileName)
        {
            // write code for displaying data from db
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //HtmlButton btnSubmit = new HtmlButton();
            Button btnSubmit = new Button();
            btnSubmit.ID = "btnclick";
            btnSubmit.Text = "Click Me";
            btnSubmit.Click += new EventHandler(this.Button2_Click);
            plcHldrControl.Controls.Add(btnSubmit);
            hdnValue.Value = "1";

        }
        public void createButtons()
        {
            
            Button btnSubmit = new Button();
            btnSubmit.ID = "btnclick";
            btnSubmit.Text = "Click Me";
            btnSubmit.Click += new EventHandler(this.Button2_Click);
            plcHldrControl.Controls.Add(btnSubmit);
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "my", "showmsg();", true);
        } 
    }
}