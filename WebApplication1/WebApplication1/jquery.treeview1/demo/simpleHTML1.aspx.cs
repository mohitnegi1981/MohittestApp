using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace WebApplication1.jquery.treeview.demo
{
    public partial class TestHTML1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {


            //getree();

            /*DataSet ds = new DataSet();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["SBConnString"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //string sql = "select cast(bsi_item_id as varchar(255)) bsi_item_id,bsi_parent_id,bsi_bfw_uid,bsi_title from bsi_item_mptt where bsi_site_id=5164 and bsi_item_subtype='Folder' or bsi_bfw_uid='bsi-5E784383-FF3D-4D9F-BE30-46E0EECF14A4'";
                string sql = "select mptt_P.bsi_item_id,mptt_P.bsi_parent_id,mptt_P.bsi_bfw_uid,mptt_P.bsi_title,mptt_C.bsi_item_id Parent_id from bsi_item_mptt mptt_P join bsi_item_mptt mptt_C on mptt_P.bsi_parent_id = mptt_C.bsi_bfw_uid where mptt_P.bsi_site_id=5164 and mptt_P.bsi_item_subtype='Folder' select mptt_P.bsi_item_id,mptt_P.bsi_parent_id,mptt_P.bsi_bfw_uid,mptt_P.bsi_title,mptt_C.bsi_item_id + 123 as Parent_id from bsi_item_mptt mptt_P join bsi_item_mptt mptt_C on mptt_P.bsi_parent_id = mptt_C.bsi_bfw_uid where mptt_P.bsi_site_id=5164 and mptt_P.bsi_item_subtype='Folder' order by mptt_P.bsi_item_id,Parent_id asc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds);
                da.Dispose();
            }*/
            
            /*ds.DataSetName = "SiteItems";
            ds.Tables[0].TableName = "SiteItem";*/
            //ds.Tables[0].DefaultView.Sort = "bsi_item_id";
            //ds.Tables[1].TableName = "SiteItemsSorted";
            //DataRelation relation = new DataRelation("ParentChild", ds.Tables["SiteItem"].Columns["Parent_id"], ds.Tables["SiteItem"].Columns["bsi_item_id"], false);
            
            //relation.Nested = true;

            //ds.Tables.Remove("SiteItem");
           // ds.Relations.Add(relation);

            /*DataTable tableNodes = ds.Tables[0];
            DataRow parentDr = tableNodes.Rows[0];
            JsTreeNode rootNode = new JsTreeNode();

            rootNode.attributes = new Attributes();
            rootNode.attributes = new Attributes();
            rootNode.attributes.id = Convert.ToString(parentDr["bsi_item_id"]);
            rootNode.attributes.rel = "root" + Convert.ToString(parentDr["bsi_item_id"]);
            rootNode.data = new Data();
            rootNode.data.title = Convert.ToString(parentDr["bsi_title"]);

            rootNode.attributes.mdata = "{ draggable : true, max_children : 100, max_depth : 100 }";

            PopulateTree(parentDr, rootNode, tableNodes);*/



        }

        public void PopulateTree(DataRow dataRow, JsTreeNode jsTNode, DataTable tableNodes)
        {
            jsTNode.children = new List<JsTreeNode>();
            foreach (DataRow dr in tableNodes.Rows)
            {
 
                if (dr != null)
                {
                    if (Convert.ToInt32(dr["Parent_id"]) == Convert.ToInt32(dataRow["bsi_item_id"]))
                    {
 
                        JsTreeNode cnode = new JsTreeNode();
                        cnode.attributes = new Attributes();
                        cnode.attributes.id = Convert.ToString(dr["bsi_item_id"]);
                        cnode.attributes.rel = "folder" + Convert.ToString(dr["bsi_item_id"]);
                        cnode.data = new Data();
                        cnode.data.title = Convert.ToString(dr["bsi_title"]);
 
                        cnode.attributes.mdata = "{ draggable : true, max_children : 100, max_depth : 100 }";
 
                        jsTNode.children.Add(cnode);
 
 
                        PopulateTree(dr, cnode, tableNodes);
 
                     }
                }
            }
        }




        


        public void getree()
        {
            SiteItemFolderDAL siteItemDal=new SiteItemFolderDAL();
            JsTreeModel treeModel = new JsTreeModel();
            treeModel.data = "Site Items";
            treeModel.attr = new JsTreeAttribute
            {
                id = 5436,
                title = ""
            };
            var list = siteItemDal.getFolderItemBySiteId();
            foreach (var header in list)
            {
                JsTreeModel Parts = new JsTreeModel
                {
                    data = header.ItemTitle,
                    attr = new JsTreeAttribute { id = header.ItemId, title = header.ItemTitle }
                };

                GetChildren(Parts, list);
                treeModel.children.Add(Parts);
            }
            JavaScriptSerializer serialize = new JavaScriptSerializer();

            string jtree = serialize.Serialize(treeModel);
           // return Json(treeModel, JsonRequestBehavior.AllowGet);
        }
        private void GetChildren(JsTreeModel node, IEnumerable<SiteItemsFolder> list)
        {

            var courseitems = list.Where(i => i.ItemParenId== node.attr.id);

            foreach (var SiteItem in courseitems)
            {
                string name = SiteItem.ItemTitle;// (SiteItem.ItemLevel == 5) ? SiteItem.QuizEnum + " . " + SiteItem.ItemTitle : SiteItem.ItemTitle;
                JsTreeModel subTree = new JsTreeModel
                {
                    data = name,
                    attr = new JsTreeAttribute { id = SiteItem.ItemId, title = SiteItem.ItemTitle }
                };

                GetChildren(subTree, list);
                node.children.Add(subTree);
            }
        }

        
    }
}