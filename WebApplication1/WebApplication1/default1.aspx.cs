using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;


namespace WebApplication1
{
    public partial class default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RouteCallbacks();
                
            }
        }

        void RouteCallbacks()
        {
            string callback = Request.Params["callback"];
            if (string.IsNullOrEmpty(callback))
                return;

            if (callback == "GetNodesJson")
                this.GetNodesJson();
        }
        void GetNodesJson()
        {
            List<JsTreeNode> nodesList = new List<JsTreeNode>();
            for (int i = 1; i < 10; i++)
            {
                JsTreeNode node = new JsTreeNode();
                node.attributes = new Attributes();
                node.attributes.id = "rootnod" + i;
                node.attributes.rel = "root" + i;
                node.data = new Data();
                node.data.title = "Root node:" + i;
                node.state = "open";

                node.children = new List<JsTreeNode>();

                for (int j = 1; j < 4; j++)
                {
                    JsTreeNode cnode = new JsTreeNode();
                    cnode.attributes = new Attributes();
                    cnode.attributes.id = "childnod1" + j;
                    cnode.attributes.rel = "folder";
                    cnode.data = new Data();
                    cnode.data.title = "child node: " + j;
                    cnode.attributes.mdata = "{draggable : true,max_children : 1,max_depth : 1 }";
                    node.children.Add(cnode);

                }
                node.attributes.mdata = "{draggable : false,max_children : 1, max_depth :1}";
                nodesList.Add(node);
            }
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string res = ser.Serialize(nodesList);
            Response.ContentType = "application/json";
            Response.Write(res);
            Response.End();
        }






    }
}