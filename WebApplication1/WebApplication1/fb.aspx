<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fb.aspx.cs" Inherits="WebApplication1.fb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="background-color:rgb(290,210,250); padding:10px; box-shadow:0px 0px 10px black"><h2>facebook Login by  Puru Raj Gupta</h2></div>
   <asp:Button ID="btnFetch" runat="server" Text="Fetch Friends" OnClick="btnFetch_Click" />
    <br />
    <asp:GridView ID="gvFriends" runat="server" >
        <Columns>
            <asp:ImageField DataImageUrlField="PictureUrl" HeaderText="Picture" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
        </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
