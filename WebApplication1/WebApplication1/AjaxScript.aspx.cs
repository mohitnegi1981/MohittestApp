using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AjaxScript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "");
            }
            DropDownList1.Attributes["onChange"] = "GetCustomer(this.value);";
            HttpResponse myHttpResponse = Response;
            HtmlTextWriter myHtmlTextWriter = new HtmlTextWriter(myHttpResponse.Output);
            DropDownList1.Attributes.AddAttributes(myHtmlTextWriter);
        }
    }
}
