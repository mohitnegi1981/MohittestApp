<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simpleHTML1.aspx.cs" Inherits="WebApplication1.jquery.treeview.demo.TestHTML1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../jquery.treeview.css" />
    <link rel="stylesheet" href="jquery.treeview/demo/screen.css" />
    <script src="../lib/jquery.js" type="text/javascript"></script>
    <script src="../lib/jquery.cookie.js" type="text/javascript"></script>
    <script src="../jquery.treeview.js" type="text/javascript"></script>
    <script type="text/javascript" src="demo.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="main">
            <h4>
                Sample 1 - default</h4>
            <ul id="browser" class="filetree">
                <li><span class="folder">
                    <input type="checkbox" id="" onclick="SelectChildren(this);" />Dummy folder</span>
                        <ul>
                            <li><span class="folder">
                                <input type="checkbox" id="" onclick="SelectChildren(this);" />sample_files</span><ul>
                                    <li><span class="file">
                                        <input type="checkbox" id="SitebuilderUploads/Dummy folder/sample_files/colorschememapping.xml"
                                            onclick="SelectChildren(this);" />colorschememapping.xml</span></li></ul>
                                            </li>
                    </ul>
                    <li><span class="folder">
                        <input type="checkbox" id="" onclick="SelectChildren(this);" />QTI</span><ul>
                            <li><span class="file">
                                <input type="checkbox" id="SitebuilderUploads/QTI/4-test.xml" onclick="SelectChildren(this);" />4-test.xml</span></li></ul>
            </ul>
            
        </div>
        <div>
        </div>
        <div style="float: left; width: 34.5%; height: 800px; overflow: scroll; padding-top: 10px;
            background-color: white;">
            <div id="treeViewDiv" style="padding-top: 10px;">
            </div>
        </div>
        <asp:XmlDataSource ID="xmlDataSource" TransformFile="~/TransformXSLT.xsl" XPath="SiteItems/SiteItem"
            runat="server" />
    </div>
    </form>
</body>
</html>
