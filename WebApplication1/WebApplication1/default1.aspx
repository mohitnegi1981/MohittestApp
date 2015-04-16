<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default1.aspx.cs" Inherits="WebApplication1.default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" src="js/jquery-1.4.1.js"></script>
    <script language="javascript" src="js/jquery-1.6.4.min.js"></script>
    <script language="javascript" src="js/jquery-1.8.0.min.js"></script>
    <script src="jstree/themes/jquery.jstree.js" type="text/javascript"></script>
    <script type="text/javascript">

 
	$(function() {
            $("#divJsTreeDemo").jstree({
            data: {
            type: "json",
            url: "Default.aspx?callback=GetNodesJson",
            async: true
            },
            rules: {
            metadata: "mdata",
            use_inline: true,
            clickable: ["root2", "folder"],
            deletable: "none",
            renameable: "all",
            creatable: ["folder"],
            draggable: ["folder"],
            dragrules: ["folder * folder", "folder inside root", "tree-drop inside root2"],
            drag_button: "left",
            droppable: ["tree-drop"]
 
            }
            });
 
        });

    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="divJsTreeDemo">
        </div>
        <input type="button" value="send" onclick="test()" />
    </div>
    </form>
</body>
</html>
