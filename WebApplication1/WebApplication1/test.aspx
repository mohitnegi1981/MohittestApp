<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebApplication1.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>jsTree v.1.0 - Demo</title>
	<script type="text/javascript" src="jstree/_lib/jquery.js"></script>
	<script type="text/javascript" src="jstree/_lib/jquery.cookie.js"></script>
	<script type="text/javascript" src="jstree/_lib/jquery.hotkeys.js"></script>
	<script type="text/javascript" src="jstree/_lib/jquery.jstree.js"></script>
	<link type="text/css" rel="stylesheet" href="jstree/_docs/syntax/!style.css"/>
	<link type="text/css" rel="stylesheet" href="jstree/_docs/!style.css"/>
	<script type="text/javascript" src="jstree/_docs/syntax/!script.js"></script>
    <style type="text/css" class="source below">
    #demo5 li { min-height:22px; line-height:22px; }
    #demo5 a { line-height:20px; height:20px; font-size:10px; }
    #demo5 a ins { height:20px; width:20px; background-position:-56px -17px; } 
    </style>
    <script type="text/javascript">
        $(function () {
            $("#demo5")
		    .jstree({ "plugins": ["themes", "html_data", "ui"] });
        });
    </script>
</head>
<body id="demo_body">
    <form id="form1" runat="server">
    <div id="demo_body">
        <div id="demo5" class="demo" style="height:120px;">
	<ul>
		<li class="jstree-open">
			<a href="#">Root node 1</a>
			<ul>
				<li>
					<a href="#">Child node 1 with a long text which would normally just cause a scrollbar, but with this line of CSS it will actually wrap, this is not really throughly tested but it works</a>
				</li>
				<li>
					<a href="#">Child node 2</a>
				</li>
			</ul>
		</li>
		<li>
			<a href="#">Root node 2</a>
		</li>
	</ul>
</div>
    </div>
    </form>
    <script type="text/javascript" class="source below">
        $(function () {

            $("#demo")
	.bind("before.jstree", function (e, data) {
	    $("#alog").append(data.func + "<br />");
	})
	.jstree({
	    // List of active plugins
	    "plugins": [
			"themes", "json_data", "ui", "crrm", "cookies", "dnd", "search", "types", "hotkeys", "contextmenu"
		],

	    // I usually configure the plugin that handles the data first
	    // This example uses JSON as it is most common
	    "json_data": {
	        // This tree is ajax enabled - as this is most common, and maybe a bit more complex
	        // All the options are almost the same as jQuery's AJAX (read the docs)
	        "ajax": {
	            // the URL to fetch the data
	            "url": "./server.php",
	            // the `data` function is executed in the instance's scope
	            // the parameter is the node being loaded 
	            // (may be -1, 0, or undefined when loading the root nodes)
	            "data": function (n) {
	                // the result is fed to the AJAX request `data` option
	                return {
	                    "operation": "get_children",
	                    "id": n.attr ? n.attr("id").replace("node_", "") : 1
	                };
	            }
	        }
	    },
	    // Configuring the search plugin
	    "search": {
	        // As this has been a common question - async search
	        // Same as above - the `ajax` config option is actually jQuery's AJAX object
	        "ajax": {
	            "url": "./server.php",
	            // You get the search string as a parameter
	            "data": function (str) {
	                return {
	                    "operation": "search",
	                    "search_str": str
	                };
	            }
	        }
	    },
	    // Using types - most of the time this is an overkill
	    // read the docs carefully to decide whether you need types
	    "types": {
	        // I set both options to -2, as I do not need depth and children count checking
	        // Those two checks may slow jstree a lot, so use only when needed
	        "max_depth": -2,
	        "max_children": -2,
	        // I want only `drive` nodes to be root nodes 
	        // This will prevent moving or creating any other type as a root node
	        "valid_children": ["drive"],
	        "types": {
	            // The default type
	            "default": {
	                // I want this type to have no children (so only leaf nodes)
	                // In my case - those are files
	                "valid_children": "none",
	                // If we specify an icon for the default type it WILL OVERRIDE the theme icons
	                "icon": {
	                    "image": "./file.png"
	                }
	            },
	            // The `folder` type
	            "folder": {
	                // can have files and other folders inside of it, but NOT `drive` nodes
	                "valid_children": ["default", "folder"],
	                "icon": {
	                    "image": "./folder.png"
	                }
	            },
	            // The `drive` nodes 
	            "drive": {
	                // can have files and folders inside, but NOT other `drive` nodes
	                "valid_children": ["default", "folder"],
	                "icon": {
	                    "image": "./root.png"
	                },
	                // those prevent the functions with the same name to be used on `drive` nodes
	                // internally the `before` event is used
	                "start_drag": false,
	                "move_node": false,
	                "delete_node": false,
	                "remove": false
	            }
	        }
	    },
	    // UI & core - the nodes to initially select and open will be overwritten by the cookie plugin

	    // the UI plugin - it handles selecting/deselecting/hovering nodes
	    "ui": {
	        // this makes the node with ID node_4 selected onload
	        "initially_select": ["node_4"]
	    },
	    // the core plugin - not many options here
	    "core": {
	        // just open those two nodes up
	        // as this is an AJAX enabled tree, both will be downloaded from the server
	        "initially_open": ["node_2", "node_3"]
	    }
	})
	.bind("create.jstree", function (e, data) {
	    $.post(
			"./server.php",
			{
			    "operation": "create_node",
			    "id": data.rslt.parent.attr("id").replace("node_", ""),
			    "position": data.rslt.position,
			    "title": data.rslt.name,
			    "type": data.rslt.obj.attr("rel")
			},
			function (r) {
			    if (r.status) {
			        $(data.rslt.obj).attr("id", "node_" + r.id);
			    }
			    else {
			        $.jstree.rollback(data.rlbk);
			    }
			}
		);
	})
	.bind("remove.jstree", function (e, data) {
	    data.rslt.obj.each(function () {
	        $.ajax({
	            async: false,
	            type: 'POST',
	            url: "./server.php",
	            data: {
	                "operation": "remove_node",
	                "id": this.id.replace("node_", "")
	            },
	            success: function (r) {
	                if (!r.status) {
	                    data.inst.refresh();
	                }
	            }
	        });
	    });
	})
	.bind("rename.jstree", function (e, data) {
	    $.post(
			"./server.php",
			{
			    "operation": "rename_node",
			    "id": data.rslt.obj.attr("id").replace("node_", ""),
			    "title": data.rslt.new_name
			},
			function (r) {
			    if (!r.status) {
			        $.jstree.rollback(data.rlbk);
			    }
			}
		);
	})
	.bind("move_node.jstree", function (e, data) {
	    data.rslt.o.each(function (i) {
	        $.ajax({
	            async: false,
	            type: 'POST',
	            url: "./server.php",
	            data: {
	                "operation": "move_node",
	                "id": $(this).attr("id").replace("node_", ""),
	                "ref": data.rslt.cr === -1 ? 1 : data.rslt.np.attr("id").replace("node_", ""),
	                "position": data.rslt.cp + i,
	                "title": data.rslt.name,
	                "copy": data.rslt.cy ? 1 : 0
	            },
	            success: function (r) {
	                if (!r.status) {
	                    $.jstree.rollback(data.rlbk);
	                }
	                else {
	                    $(data.rslt.oc).attr("id", "node_" + r.id);
	                    if (data.rslt.cy && $(data.rslt.oc).children("UL").length) {
	                        data.inst.refresh(data.inst._get_parent(data.rslt.oc));
	                    }
	                }
	                $("#analyze").click();
	            }
	        });
	    });
	});

        });
</script>
</body>
</html>
