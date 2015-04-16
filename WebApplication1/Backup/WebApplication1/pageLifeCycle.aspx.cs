using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class pageLifeCycle : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {        
            //  Use this event for the following:          
            //  Check the IsPostBack property to determine whether this is the first time the page is being processed.        //  Create or re-create dynamic controls.        //  Set a master page dynamically.        
            //  Set the Theme property dynamically.           
            string strStep1 = "Page PreInit";
            Response.Write(strStep1);
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            string strStep2 = "Page Init";
            Response.Write(strStep2);
            // Raised after all controls have been initialized and any skin settings have been applied. Use this event to read or initialize control properties.
        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            string strStep3 = "Page InitComplete";
            Response.Write(strStep3);
            // Raised by the  Page object. Use this event for processing tasks that require all initialization be complete. 
        }
        protected override void OnPreLoad(EventArgs e)
        {
            string strStep4 = "Pgae PreLoad";
            Response.Write(strStep4);
            // Use this event if you need to perform processing on your page or control before the  Load event.        // Before the Page instance raises this event, it loads view state for itself and all controls, and then processes any postback data included with the Request instance.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string strStep5 = "PageLoad";
            Response.Write(strStep5);
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            string strStep6 = "Pgae LoadComplete";
            Response.Write(strStep6);
            // Use this event for tasks that require that all other controls on the page be loaded.
        }
        protected override void OnPreRender(EventArgs e)
        {
            string strStep7 = "Pgae On PreRender";
            Response.Write(strStep7);
            // Each data bound control whose DataSourceID property is set calls its DataBind method.        // The PreRender event occurs for each control on the page. Use the event to make final changes to the contents of the page or its controls.
        }

        protected void Page_UnLoad(object sender, EventArgs e)   
        {
            string strStep8 = "Pgae Unload";
            //Response.Write(strStep8);
            // This event occurs for each control and then for the page. In controls, use this event to do final cleanup for specific controls, such as closing control-specific database connections.        // During the unload stage, the page and its controls have been rendered, so you cannot make further changes to the response stream.           //If you attempt to call a method such as the Response.Write method, the page will throw an exception.    
        }
    }
}
