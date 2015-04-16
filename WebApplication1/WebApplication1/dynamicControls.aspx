<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dynamicControls.aspx.cs" Inherits="WebApplication1.dynamicControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function ChektextBox() {
            var txtArea = document.getElementById("txtbox");
            alert(txtArea);
            alert(txtArea.value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:PlaceHolder ID="PlaceHolder" runat="server"></asp:PlaceHolder>
        <asp:Button ID="btnclik" runat="server" OnClientClick="ChektextBox()" Text="Click to check" />
    </div>
    </form>
</body>
</html>
