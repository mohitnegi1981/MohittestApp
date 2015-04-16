<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="WebApplication1.WebForm6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function callMethod(e) {
            var strValues = '';
            var hdnCalCulate = document.getElementById("hdnCalCulate");
            if (e.keycode == 13) {
                alert(strValues);
            }
            else {
                var sel = document.getElementById('<%=selectItem.ClientID%>')
                var listLength = sel.options.length;
                for (var i = 0; i < listLength; i++) {
                    if (sel.options[i].selected) {
                        if (strValues == "")
                            strValues = sel.options[i].text;
                        else
                            strValues = strValues + "," + sel.options[i].text;
                    }
                }
                hdnCalCulate.value = strValues;
            }
        }
        function getValue(e) {
            var hdnCalCulate = document.getElementById("hdnCalCulate");
            if(e.keyCode==13)
            {
                alert(hdnCalCulate.value);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ListBox ID="selectItem" SelectionMode="Multiple" runat="server" 
                        onchange="javascript:return callMethod(event);" 
                        onkeypress="javascript:return getValue(event);" Height="138px" Width="90px">
                        <asp:ListItem>Mohit</asp:ListItem>
                        <asp:ListItem>Atul</asp:ListItem>
                        <asp:ListItem>Jay</asp:ListItem>
                        <asp:ListItem>Manu</asp:ListItem>
                        <asp:ListItem>Ankit</asp:ListItem>
                    </asp:ListBox>
                    <asp:HiddenField ID="hdnCalCulate" runat="server" />
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gdview" runat="server"></asp:GridView>
                    <br />
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
