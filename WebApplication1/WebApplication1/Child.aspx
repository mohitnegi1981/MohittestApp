<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Child.aspx.cs" Inherits="WebApplication1.Child" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" src="js/jquery-1.4.1.js"></script>
    <script language="javascript" src="js/jquery-1.6.4.min.js"></script>
    <script language="javascript" src="js/jquery.js"></script>
    <script language="javascript" src="js/jquery.jstree.js"></script>
    <script language="javascript">
        function closeall() {
                window.close();
                window.returnValue = "true";
        }

        $(function() {
                $("#demo2").jstree(
                {
                    "plugins": ["themes", "json_data"],
                    "json_data": {
                        "ajax": {
                            "type": "POST",
                            "contentType": "application/json;charset=utf-8",
                            "url": "./JSTree.aspx/GetTreeViewNodes",
                            "dataType": "json",
                            "data": function(node) {
                                return '{ "operation" :"get_children", "id" : 1 }';
                            },
                            "success": function(retval) {
                                if (retval.hasOwnProperty('d')) {
                                    return (retval.d);
                                }
                            }
                        }
                    }
                });
            }); 
      </script>  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="parentbutton" runat="server" Text="Close Child" OnClientClick="closeall();" />
    <asp:HiddenField ID="hdnChanged" runat="server" />
    <div id="demo2">
        
        </div>
    </div>
    </form>
</body>
</html>
