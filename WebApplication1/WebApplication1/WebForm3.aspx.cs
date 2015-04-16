using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public string strCon = ConfigurationManager.ConnectionStrings["IPRISMDB"].ToString();
        DataSet ds = new DataSet();
        DataView dv = new DataView();
        SqlConnection sqlConnection;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {

            //ViewState["sortOrder"] = "desc";
            //ViewState["sortExpr"] = "last_name";
            //BindSearchResult();
        }
        public void BindSearchResult()
        {
            try
            {
                /*if (!IsPostBack)
                {*/
                
                //dv = bindgrid(str);
               

                

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       /* private DataView bindgrid(string lid, string name, string emai, string countryId, string statusid, string buid)
        {
            try
            {
                sqlConnection = new SqlConnection(strCon);
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "USP_GetPersonnelSearchDetails";


                cmd.Parameters.Add(new SqlParameter("@lid", lid));
                if (name != string.Empty)
                {
                    cmd.Parameters.Add(new SqlParameter("@user_name", name));
                }
                if (emai != string.Empty)
                {
                    cmd.Parameters.Add(new SqlParameter("@email", emai));
                }
                if (countryId != string.Empty)
                {
                    cmd.Parameters.Add(new SqlParameter("@country_id", countryId));
                }
                if (buid != string.Empty)
                {
                    cmd.Parameters.Add(new SqlParameter("@bu_id", buid));
                }

                if (statusid != string.Empty)
                {
                    cmd.Parameters.Add(new SqlParameter("@status_id", statusid));
                }



                //cmd.Parameters.Add(new SqlParameter("@status_id", statusid));
                sqlConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);



                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ViewState["sortExpr"] != null)
                    {
                        dv = new DataView(ds.Tables[0]);
                        dv.Sort = (string)ViewState["sortExpr"] + " " + sortOrder();
                    }
                    else
                        dv = ds.Tables[0].DefaultView;
                    //btnExport.Enabled = true;
                }




                sqlConnection.Close();
                return dv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public string sortOrder()
        {
            if (ViewState["sortOrder"].ToString() == "desc")
            {
                ViewState["sortOrder"] = "asc";
            }
            else
            {
                ViewState["sortOrder"] = "desc";
            }
            return ViewState["sortOrder"].ToString();
        }


        protected void gvSearchDetails_OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                if (e.SortExpression != ViewState["sortExpr"].ToString())
                {
                    ViewState["sortExpr"] = e.SortExpression;
                    ViewState["sortOrder"] = "desc";
                }
                else
                    ViewState["sortExpr"] = e.SortExpression;

                string strDisplay = @"<script language='javascript'>scrollgrid();</script>";

                //ClientScript.RegisterClientScriptBlock(GetType(), "onloadsort ", strDisplay, true);
                //Page.RegisterStartupScript("onloadsort",strDisplay);
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "onloadsort ", strDisplay, false);

                //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "onload", strDisplay);
                BindSearchResult();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvSearchDetails_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvSearchDetails.PageIndex = e.NewPageIndex;
                BindSearchResult();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvSearchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string strNavigate;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int i = e.Row.RowIndex;
                if (i == 0)
                {
                    //GridViewRow tr1 = e.Row;
                    //tr1.ID = "rowHeight1";
                    //e.Row.Cells[0].ID = "rowHeight1";
                }
                strNavigate = "location.href='AddPersonnel1.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "user_id") + "'";
                GridViewRow tr = e.Row;
                tr.Attributes.Add("onClick", strNavigate);
                //tr.Attributes.Add("style", "cursor:hand;");
                tr.Attributes.Add("style", "cursor:pointer;");
                string str = string.Empty;
                str = tr.Cells[1].Text;
                if (str.Length > 10)
                {
                    //tr.Cells[1].Text = "<span style=\"cursor:hand\">" + str.Substring(0, 10) + "</span>";
                    tr.Cells[1].Text = str;
                    tr.Cells[1].ToolTip = str;
                }
                else
                {
                    tr.Cells[1].Text = str;
                }

                str = tr.Cells[3].Text;
                if (str.Length > 10)
                {
                    //tr.Cells[3].Text = str.Substring(0, 10) + "...";
                    tr.Cells[3].ToolTip = str;
                }
                else
                {
                    tr.Cells[3].Text = str;
                }

                str = tr.Cells[5].Text;
                if (str.Length > 20)
                {
                    //tr.Cells[5].Text = str.Substring(0, 20) + "...";
                    tr.Cells[5].ToolTip = str;
                }
                else
                {
                    tr.Cells[5].Text = str;
                }

                str = tr.Cells[11].Text;
                if (str.Length > 18)
                {
                    //tr.Cells[11].Text = str.Substring(0, 18) + "...";
                    tr.Cells[11].ToolTip = str;
                }
                else
                {
                    tr.Cells[11].Text = str;
                }

                str = tr.Cells[13].Text;
                if (str.Length > 18)
                {
                    //tr.Cells[13].Text = str.Substring(0, 18) + "...";
                    tr.Cells[13].ToolTip = str;
                }
                else
                {
                    tr.Cells[13].Text = str;
                }
                //Truncate Phone No
                Label lblphone = ((Label)e.Row.FindControl("lblphone"));

                if (lblphone != null)
                {
                    if (lblphone.Text != "")
                    {
                        str = lblphone.Text;
                        if (str.Length > 10)
                        {
                            //tr.Cells[16].Text = str.Substring(0, 10) + "...";
                            tr.Cells[16].ToolTip = str;
                        }
                        else
                        {
                            tr.Cells[16].Text = str;
                        }
                    }
                }


                Label lblcompanyName = ((Label)e.Row.FindControl("lblcompanyName"));

                if (lblcompanyName != null)
                {
                    if (lblcompanyName.Text != "")
                    {
                        str = lblcompanyName.Text;
                        if (str.Length > 18)
                        {
                            //tr.Cells[17].Text = str.Substring(0, 18) + "...";
                            tr.Cells[17].ToolTip = str;
                        }
                        else
                        {
                            tr.Cells[17].Text = str;
                        }
                    }
                }

                Label lblinhouseContact = ((Label)e.Row.FindControl("lblinhouseContact"));

                if (lblinhouseContact != null)
                {
                    if (lblinhouseContact.Text != "")
                    {
                        str = lblinhouseContact.Text;
                        if (str.Length > 18)
                        {
                            //tr.Cells[18].Text = str.Substring(0, 18) + "...";
                            tr.Cells[18].ToolTip = str;
                        }
                        else
                        {
                            tr.Cells[18].Text = str;
                        }
                    }
                }



                Label lblComments = ((Label)e.Row.FindControl("lblComments"));

                if (lblComments != null)
                {
                    if (lblComments.Text != "")
                    {
                        str = lblComments.Text;
                        if (str.Length > 18)
                        {
                            //tr.Cells[19].Text = str.Substring(0, 18) + "...";
                            tr.Cells[19].ToolTip = str;
                        }
                        else
                        {
                            tr.Cells[19].Text = str;
                        }
                    }
                }

                Label lblCreatedby = ((Label)e.Row.FindControl("lblCreatedby"));

                if (lblCreatedby != null)
                {
                    if (lblCreatedby.Text != "")
                    {
                        str = lblCreatedby.Text;
                        if (str.Length > 15)
                        {
                            //lblCreatedby.Text = str.Substring(0, 13) + "...";
                            lblCreatedby.ToolTip = str;
                        }
                        else
                        {
                            lblCreatedby.Text = str;
                        }
                    }
                }




                Label lblMOdifiedBy = ((Label)e.Row.FindControl("lblmodifiedby"));
                Label lblMOdifiedDate = ((Label)e.Row.FindControl("lblModifiedDate"));
                if (lblMOdifiedDate.Text == "01/01/1900" || lblMOdifiedDate.Text == "")
                {
                    lblMOdifiedDate.Text = "";
                    lblMOdifiedBy.Text = "";

                }
                else
                {
                    if (lblMOdifiedBy != null)
                    {
                        if (lblMOdifiedBy.Text != "")
                        {
                            str = lblMOdifiedBy.Text;
                            if (str.Length > 15)
                            {
                                //lblMOdifiedBy.Text = str.Substring(0, 13) + "...";
                                lblMOdifiedBy.ToolTip = str;
                            }
                            else
                            {
                                lblMOdifiedBy.Text = str;
                            }
                        }
                    }
                }

                //Mohit - Added Row coloring on mouse hover
                //e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFF00'");

                //e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='red'; this.style.color='#ffffff';");


                // when mouse leaves the row, change the bg color to its original value    
                // e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;this.style.color='#000000'");


            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("D:\\autobatch.bat");

            psi.CreateNoWindow = true;

            psi.UseShellExecute = false;

            psi.RedirectStandardOutput = true;

            System.Diagnostics.Process processBatch = System.Diagnostics.Process.Start(psi);

            processBatch.WaitForExit();
            // Read the output.

            string output = processBatch.StandardOutput.ReadToEnd();

            Response.Write(output);
        }
        */
    }
}
