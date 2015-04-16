<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSTreeForFileUpload.aspx.cs" Inherits="WebApplication1.JSTreeForFileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" src="js/jquery-1.4.1.js" type="text/javascript"></script>
    <script language="javascript" src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script language="javascript" src="js/jquery.js" type="text/javascript"></script>
    <script language="javascript" src="js/jquery.jstree.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        window.onload = function () {
            $('#jstree_demo').jstree({ 'core': {
                'data': [
                       'Simple root node',
                       {
                           'text': 'Root node 2',
                           'state': {
                               'opened': true,
                               'selected': true
                           },
                           'children': [
                           { 'text': 'Child 1' },
                           'Child 2'
                         ]
                       }
                    ]
            }
            });
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <div id="jstree_demo">
        
        </div>
    </div>
    </form>
</body>
</html>
