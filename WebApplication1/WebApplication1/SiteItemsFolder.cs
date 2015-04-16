using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SiteItemsFolder
    {
        public int ItemId { get; set; }
        public int ItemParenId { get; set; }
        public string ItemTitle { get; set; }
        public string ItemParent { get; set; }
        public int BsiLeft { get; set; }
        public int BsiRight { get; set; }
    }
}