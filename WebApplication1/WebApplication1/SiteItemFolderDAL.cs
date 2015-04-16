using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebApplication1
{
    public class SiteItemFolderDAL
    {
        public SiteItemFolderDAL()
        {

        }
        public IEnumerable<SiteItemsFolder> getFolderItemBySiteId()
        {
            var listSiteItem = new Collection<SiteItemsFolder>();
            DataSet ds = new DataSet();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["SBConnString"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //string sql = "select cast(bsi_item_id as varchar(255)) bsi_item_id,bsi_parent_id,bsi_bfw_uid,bsi_title from bsi_item_mptt where bsi_site_id=5164 and bsi_item_subtype='Folder' or bsi_bfw_uid='bsi-5E784383-FF3D-4D9F-BE30-46E0EECF14A4'";
                string sql = "select mptt_P.bsi_item_id,mptt_P.bsi_parent_id,mptt_P.bsi_bfw_uid,mptt_P.bsi_title,mptt_C.bsi_item_id Parent_id from bsi_item_mptt mptt_P join bsi_item_mptt mptt_C on mptt_P.bsi_parent_id = mptt_C.bsi_bfw_uid where mptt_P.bsi_site_id=5164 and mptt_P.bsi_item_subtype='Folder' select mptt_P.bsi_item_id,mptt_P.bsi_parent_id,mptt_P.bsi_bfw_uid,mptt_P.bsi_title,mptt_C.bsi_item_id + 123 as Parent_id from bsi_item_mptt mptt_P join bsi_item_mptt mptt_C on mptt_P.bsi_parent_id = mptt_C.bsi_bfw_uid where mptt_P.bsi_site_id=5164 and mptt_P.bsi_item_subtype='Folder' order by mptt_P.bsi_item_id,Parent_id asc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds);
                da.Dispose();
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++)
            {
                var objSiteItem = new SiteItemsFolder();
                objSiteItem.ItemId =Convert.ToInt32(ds.Tables[0].Rows[i]["bsi_item_id"]);
                objSiteItem.ItemTitle = ds.Tables[0].Rows[i]["bsi_title"].ToString();
                objSiteItem.ItemParenId = Convert.ToInt32(ds.Tables[0].Rows[i]["Parent_id"]);
                listSiteItem.Add(objSiteItem);
            }
            return listSiteItem;
        }

    }
}