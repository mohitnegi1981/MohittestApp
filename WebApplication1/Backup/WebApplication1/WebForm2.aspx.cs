using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;



namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*Hashtable dataSource = new Hashtable();
                dataSource.Add(0, "All");
                dataSource.Add(1, "aa");
                dataSource.Add(2, "bb");
                dataSource.Add(3, "cc");

                CheckBoxList1.DataSource = dataSource;
                CheckBoxList1.DataTextField = "Value";
                CheckBoxList1.DataValueField = "Key";
                CheckBoxList1.DataBind();

                ViewState["sAll"] = "false";*/
                //string strpwd = GenerateNumber();

                
            }
        }


        public string GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 6; i++)
            {
                r += random.Next(0, 5).ToString();
            }
            return r;
        }


        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBoxList1.Items.FindByValue("0").Selected == true)
            {
                if (ViewState["sAll"].ToString() == "true")
                {
                    CheckBoxList1.Items.FindByValue("0").Selected = false;
                    ViewState["sAll"] = "false";
                }
                else
                {
                    ViewState["sAll"] = "true";
                    this.SelectAllCheckBox(true);
                }
            }
            else
            {
                if (ViewState["sAll"].ToString() == "true")
                {
                    ViewState["sAll"] = "false";
                    this.SelectAllCheckBox(false);
                }
            }
        }


        private void SelectAllCheckBox(bool setValue)
        {
            foreach (ListItem item in CheckBoxList1.Items)
            {
                item.Selected = setValue;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("D:\\autobatch.bat");

            psi.CreateNoWindow = true;

            psi.UseShellExecute = false;

            psi.RedirectStandardOutput = true;

            System.Diagnostics.Process processBatch = System.Diagnostics.Process.Start(psi);

            processBatch.WaitForExit();
            // Read the output.

            string output = processBatch.StandardOutput.ReadToEnd();

            Response.Write(output);*/
            Response.Redirect("WebForm1.aspx");
        }


    }
}
