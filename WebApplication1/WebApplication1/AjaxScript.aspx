<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxScript.aspx.cs" Inherits="WebApplication1.AjaxScript" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function GetXmlHttpObject(handler) {
            var objXmlHttp = null
            if (navigator.userAgent.indexOf("Opera") >= 0) {
                alert("This example doesn't work in Opera")
                return
            }
            if (navigator.userAgent.indexOf("MSIE") >= 0) {
                var strName = "Msxml2.XMLHTTP"
                if (navigator.appVersion.indexOf("MSIE 5.5") >= 0) {
                    strName = "Microsoft.XMLHTTP"
                }
                try {
                    objXmlHttp = new ActiveXObject(strName)
                    objXmlHttp.onreadystatechange = handler
                    return objXmlHttp
                }
                catch (e) {
                    alert("Error. Scripting for ActiveX might be disabled")
                    return
                }
            }
            if (navigator.userAgent.indexOf("Mozilla") >= 0) {
                objXmlHttp = new XMLHttpRequest()
                objXmlHttp.onload = handler
                objXmlHttp.onerror = handler
                return objXmlHttp
            }
        }

        function GetProduct(id) {
            var url = "Details.aspx?CatId=" + id;
            xmlHttp = GetXmlHttpObject(stateChanged);
            xmlHttp.open("GET", url, true);
            xmlHttp.send(null);
        }


        function stateChanged() {
            if (xmlHttp.readyState == 4 || xmlHttp.readyState == "complete") {
                document.getElementById('ProductDetails').innerHTML = xmlHttp.responseText;
            }
        }

  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
      <div>
          <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
              DataTextField="Country_name" DataValueField="country_id">
          </asp:DropDownList>
          
      </div>
      <div id="ProductDetails">
      </div>
  </div>
  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IPRISMDB %>"
      SelectCommand="SELECT * FROM country_master"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
