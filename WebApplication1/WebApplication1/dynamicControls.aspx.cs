using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class dynamicControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlTable table = new HtmlTable();
            HtmlTableRow trow = new HtmlTableRow();
            HtmlTableCell tcell = new HtmlTableCell();
            TextBox txtbox = new TextBox();
            txtbox.ID = "txtbox";
            txtbox.Text = "Mohit";
            tcell.Controls.Add(txtbox);
            trow.Controls.Add(tcell);
            table.Controls.Add(trow);


            trow = new HtmlTableRow();
            tcell = new HtmlTableCell();
            Button btnclick = new Button();
            btnclick.ID = "btnClick";
            btnclick.Text = "Click Me";
            ClientScriptManager cs = Page.ClientScript;
            btnclick.Attributes.Add("onclick","" + cs.GetPostBackEventReference(this, btnclick.ID) + ";return false;");
            tcell.Controls.Add(btnclick);
            trow.Controls.Add(tcell);
            table.Controls.Add(trow);

            PlaceHolder.Controls.Add(table);

        }


        public void RaisePostBackEvent(string eventArgument)
        {
            TextBox txtbox =(TextBox)Page.FindControl("txtbox");
            string a = txtbox.Text;
        }
    }
}