<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication1.WebForm4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
    <table>
    <tr style='background:black;font-weight:bold;color:Black;'><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td></tr>
    </table>
    </div>
    </form>
</body>
</html>
