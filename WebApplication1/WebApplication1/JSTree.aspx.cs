using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;


namespace WebApplication1
{
    public partial class JSTree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            maketree();
            
        }
        
        public static List<parent> maketree()
        {
            
            List<parent> parent = new List<parent>();
            parent par = new parent();
            par.ParentName = "BP Chaturvedi";
            par.childs = new List<child1>();
            child1 ch = new child1();
            ch.Name = "Vikas";
            child1 ch1 = new child1();
            ch.Name = "Kiran";
            par.childs.Add(ch);
            par.childs.Add(ch1);

            parent par1 = new parent();
            par1.ParentName = "Apke papa ka naam";
            par1.childs = new List<child1>();
            child1 ch3 = new child1();
            ch3.Name = "unke lardke";
            child1 ch4 = new child1();
            ch4.Name = "unki beti";
            par1.childs.Add(ch3);
            par1.childs.Add(ch4);
            parent.Add(par);
            parent.Add(par1);


            JavaScriptSerializer serialize = new JavaScriptSerializer();

            string jtree = serialize.Serialize(parent);

            List<parent> response = (List<parent>)serialize.Deserialize(jtree, typeof(List<parent>));
            

            return response;
        }

        




        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetTreeViewNodes(int id)
        {
            return "[{ \"data\" : \"A node\", \"children\" : [ { \"data\" : \"Only child\",  " + "\"state\" : \"closed\" }], \"state\" : \"open\" }, \"Ajax node \" ]";
        } 
    }
}