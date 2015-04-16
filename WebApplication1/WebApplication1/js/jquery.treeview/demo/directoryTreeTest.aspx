<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="directoryTreeTest.aspx.cs"
    Inherits="WebApplication1.directoryTreeTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../jquery.treeview.css" />
    <link rel="stylesheet" href="screen.css" />
    <script src="../lib/jquery.js" type="text/javascript"></script>
    <script src="../lib/jquery.cookie.js" type="text/javascript"></script>
    <script src="../jquery.treeview.js" type="text/javascript"></script>
    <script type="text/javascript" src="demo.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main" style="overflow-y: scroll; height: 500px; padding: 5px;">
    <asp:Literal ID="ltrHTML" runat="server"></asp:Literal>    

    </div>
    </form>
</body>
</html>
