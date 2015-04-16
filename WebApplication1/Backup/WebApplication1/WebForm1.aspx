<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" Culture="en-US" UICulture="en-US"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="4" cellspacing="0" >
   <tr style="background-color: #dadada;">
      <td style="width: 120px;">
         Language:
      </td>
      <td style="width: 450px;">
         <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="3" 
            Width="300px" AutoPostBack="True" 
               onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                  <asp:ListItem Selected="True" Value="en-US">US English</asp:ListItem>
                  <asp:ListItem Value="de-DE">German</asp:ListItem>
                  <asp:ListItem Value="fr-FR">French</asp:ListItem>
                  <asp:ListItem Value="pt-PT">Brazilian Portuguese</asp:ListItem>
         </asp:RadioButtonList>
      </td>
   </tr>
   <tr>
      <td style="vertical-align: top">
         <asp:Label ID="lblTodayDate" runat="server" Text="Today Date:"></asp:Label>
      </td>
      <td style="vertical-align: top">
         <asp:TextBox ID="txtDate" runat="server" Width="250px"></asp:TextBox>
      </td>
   </tr>
   <tr>
      <td style="vertical-align: top">
         <asp:Label ID="lblCurrentPrice" runat="server" Text="Current Price:"></asp:Label>
      </td>
      <td style="vertical-align: top">
         <asp:TextBox ID="txtPrice" runat="server" Width="250px"></asp:TextBox>
      </td>
   </tr>
   <tr>
      <td style="vertical-align: top">
         <asp:Label ID="lblCalendar" runat="server" Text="Calendar:"></asp:Label>
      </td>
      <td style="vertical-align: top">
         <asp:Calendar ID="Calendar1" runat="server" BorderColor="Black"
            DayNameFormat="Full" Font-Names="Verdana" 
            Height="205px" NextPrevFormat="FullMonth" Width="100%" BorderStyle="Solid" 
            BorderWidth="1px">
            <TodayDayStyle BackColor="Black" ForeColor="White" />
            <DayHeaderStyle BackColor="#dadada" Font-Bold="false"  />
            <TitleStyle BackColor="White" Font-Bold="True" ForeColor="Blue" />
         </asp:Calendar>
      </td>
   </tr>
</table>
    </div>
    </form>
</body>
</html>
