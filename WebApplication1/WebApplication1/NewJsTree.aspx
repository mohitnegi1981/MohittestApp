<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewJsTree.aspx.cs" Inherits="WebApplication1.NewJsTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="vakata-jstree/dist/themes/default/style.min.css" />
    <script src="vakata-jstree/dist/libs/jquery.js"></script>
    <script src="vakata-jstree/dist/jstree.min.js"></script>
    <link rel="stylesheet" href="js/jquery.treeview/jquery.treeview.css" />
	<link rel="stylesheet" href="js/jquery.treeview/demo/screen.css" />
	<script src="js/jquery.js" type="text/javascript"></script>
	<script src="js/jquery.treeview/lib/jquery.cookie.js" type="text/javascript"></script>
	<script src="js/jquery.treeview/jquery.treeview.js" type="text/javascript"></script>
	<script type="text/javascript" src="js/jquery.treeview/demo/demo.js"></script>
    <script language="javascript" type="text/javascript">
        
        
        
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="main" style="height:400px;width:500px;overflow:auto;">
            <asp:Literal ID="ltrHTML" runat="server"></asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
