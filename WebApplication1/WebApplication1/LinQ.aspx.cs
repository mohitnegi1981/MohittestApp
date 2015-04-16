using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    
    public partial class LinQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindGrid();
            updateContentFromLinq();
            

        }

        public void bindGrid()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var userDetails = from user in db.user_masters select user;
            grdBindLINQ.DataSource = userDetails;
            grdBindLINQ.DataBind();
        }

        public void updateContentFromLinq()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            user_master user1 = db.user_masters.Single(p => p.email == "neha-jain@hcl.com");
            user1.last_name = "jain";
            db.SubmitChanges();  
        }

        public void insertdata()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            user_master user = new user_master();
            user.last_name = "negi";
            user.first_name="Mohit";
            user.email = "mohit.negi@hcl.com";
        }


        public void usingStoredProcedure()
        {
            /*DataClasses1DataContext db = new DataClasses1DataContext();
            var user = db.USP_GetUserDetailsOnId(1);
            foreach (user_master usr in user)
            {
                usr.user_id
            }*/

        
        
        }

    }
}
