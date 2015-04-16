<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSTree.aspx.cs" Inherits="WebApplication1.JSTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" src="js/jquery-1.4.1.js"></script>
    <script language="javascript" src="js/jquery-1.6.4.min.js"></script>
    <script language="javascript" src="js/jquery.js"></script>
    <script language="javascript" src="js/jquery.jstree.js"></script>
    
    <script language="javascript" type="text/javascript">


        $(function () {
            $("#foldergraph").tree({
                data: {
                    type: "json",
                    json: [
          { attributes: { id: "pjson1_1", rel: "root" }, state: "open", data: "Root node 1", children: [
            { attributes: { id: "pjson1_2", rel: "folder" }, data: { title: "Custom icon", icon: "../media/images/ok.png"} },
            { attributes: { id: "pjson1_3", rel: "folder", mdata: "{ draggable : false, max_children : 1, max_depth : 1 }" }, data: "Child node 2" },
            { attributes: { id: "pjson1_4", rel: "folder" }, data: "Some other child node" }
          ]
          },
          { attributes: { id: "pjson1_5", rel: "root2" }, data: "Root node 2" }
        ]
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
        <div id="foldergraph">
        
        </div>
    </div>
    </form>
</body>
</html>
