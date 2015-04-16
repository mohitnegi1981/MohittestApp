<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
	<script src="js/jquery.js" type="text/javascript"></script>
	<script src="js/jquery.treeview/lib/jquery.cookie.js" type="text/javascript"></script>
	<script src="js/jquery.treeview/jquery.treeview.js" type="text/javascript"></script>
	<script type="text/javascript" src="js/jquery.treeview/demo/demo.js"></script>
    <style>
        .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 10px;
            background-color: White;
            margin-left:10px;
        }
        .AutoExtenderList
        {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
        }
        .AutoExtenderHighlight
        {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }
        #divwidth
        {
          width: 180px !important;    
        }
        #divwidth div
       {
        width: 190px !important;   
       }
    </style>
    
    <script type="text/javascript" type="text/javascript">
        function SelectControl(txt) {
            
            alert($("input[tag="+txt+"]").id);
        }
	 </script>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
      
    </asp:ScriptManager>
    <div>
        
        <br />
        <strong>Selected checkbox value: </strong>
        <div id="divChkBoxText">
           <asp:Button ID="btnSubmit" runat="server" />
        &nbsp;&nbsp;&nbsp;
        </div>
    </div>
    <div id="divwidth" ></div>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtname" runat="server" tag="txtname" ></asp:TextBox>
            <asp:TextBox ID="TextBox1" runat="server" tag="TextBox1" ></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" tag="TextBox2" ></asp:TextBox>
                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                  ServicePath="IntellisenceSearch.asmx"   ServiceMethod="Information" TargetControlID="txtname" >
                </ajax:AutoCompleteExtender>1
                
        </ContentTemplate>
    </asp:UpdatePanel>    
        
    <div>
    
        <asp:Button btn="btnSelect" runat="server" OnClientClick="SelectControl('txtname')" Text="Submit" />
    </div>    
    </form>
</body>
</html>
