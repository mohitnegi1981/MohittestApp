<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication1.WebForm4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="js/jquery.treeview/jquery.treeview.css" />
	<link rel="stylesheet" href="js/jquery.treeview/demo/screen.css" />
	<script src="js/jquery.js" type="text/javascript"></script>
	<script src="js/jquery.treeview/lib/jquery.cookie.js" type="text/javascript"></script>
	<script src="js/jquery.treeview/jquery.treeview.js" type="text/javascript"></script>
	<script type="text/javascript" src="js/jquery.treeview/demo/demo.js"></script>
    <script language="javascript" type="text/javascript">
        function check() {
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="15000" ontick="Timer1_Tick"></asp:Timer>
    <div>
     <asp:TextBox ID="TextBox1" runat="server" 
	Height="118px" TextMode="MultiLine" Width="468px"></asp:TextBox>
	<asp:Button ID="Button1" runat="server" Text="Save" 
	onclick="Button1_Click" /><br /><br />
	
	
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <ContentTemplate>
        <asp:TextBox ID="TextBox2" runat="server" Height="120px" 
		TextMode="MultiLine" Width="466px"></asp:TextBox>
    </ContentTemplate>

    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"/>
    </Triggers>

</asp:UpdatePanel> 
    <table style="display:none;">
    <tr style='background:black;font-weight:bold;color:Black;'><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td></tr>
    </table>
    </div>
    <div id="main" style="height:400px;width:500px;overflow:auto;">
        <asp:Literal ID="ltrHTML" runat="server"></asp:Literal>
    </div>
    <input id="click" title="click on me" onclick="check();" />
    <div style="height:20px;background-color:Gray;width:100%;text-align:left;color:Black;font-weight:bold" > Item(s) to Add</div>

    </form>
</body>
</html>
