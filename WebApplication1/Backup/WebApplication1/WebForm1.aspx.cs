﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl = (Label)PreviousPage.FindControl("lblValue");
            string str = lbl.Text;

        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultureName = RadioButtonList1.SelectedValue.ToString();

            Page.Culture = cultureName;
            Page.UICulture = cultureName;
        }

        

        protected void Page_PreRender()
        {
            DateTime date = DateTime.Now;
            decimal price = 65000;
            string cultureName = RadioButtonList1.SelectedValue.ToString();

            Page.Culture = cultureName;
            Page.UICulture = cultureName;
            /*Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");*/
            


            txtDate.Text = date.ToString("D");
            txtPrice.Text = price.ToString("c");

            //lblTodayDate.Text = GetLocalResourceObject("DateLabel").ToString();
            //lblCurrentPrice.Text = GetLocalResourceObject("PriceLabel").ToString();
            //lblCalendar.Text = GetLocalResourceObject("CalendarLabel").ToString();
        }
    }
}
