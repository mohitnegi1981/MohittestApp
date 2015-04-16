using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using ASPSnippets.FaceBookAPI;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class CS : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        FaceBookConnect.API_Key = "479827735438511";
        FaceBookConnect.API_Secret = "a3abd98ec3dab755f88b33b62b80808b";
           if (!IsPostBack)
        {
            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
                string data = FaceBookConnect.Fetch(code, "me/friends");
                FaceBookData facebookData = new JavaScriptSerializer().Deserialize<FaceBookData>(data);
                foreach (FaceBookUser user in facebookData.Data)
                {
                    user.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", user.Id);
                    
                }
                //gvFriends.DataSource = facebookData.Data;
                //gvFriends.DataBind();
            }
        }
    }
    protected void btnFetch_Click(object sender, EventArgs e)
    {
        FaceBookConnect.Authorize("user_photos,friends_photos", Request.Url.AbsoluteUri);
    }

}

public class FaceBookData
{
    public List<FaceBookUser> Data { get; set; }
}

public class FaceBookUser
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string PictureUrl { get; set; }

}