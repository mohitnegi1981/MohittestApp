using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mono.Unix;

namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //Add the save function here ex store the text to DB
            //Here we only move between the two textboxes to show that it works
            TextBox2.Text = TextBox1.Text;
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Save();
        }
    }
}
