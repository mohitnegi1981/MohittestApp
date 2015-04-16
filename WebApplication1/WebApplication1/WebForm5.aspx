<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="WebApplication1.WebForm5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="js/jquery-1.6.4.min.js"></script>
    <script language="javascript" type="text/javascript">
        function removeIteminlist() {
            var selectedvalue = $('#<%= RadioButtonListPrimarySelection.ClientID %>').find('input:checked').val();
            //alert(selectedvalue);
            $('#<%= RadioButtonListPrimarySelection.ClientID %> span[id="optionA"]').remove();
            $('#<%= RadioButtonListPrimarySelection.ClientID %> input[value="Import Content Item(s)"]').attr('checked', 'checked');
            return false;
        }

        Page.init = function () {
            var selectedvalue = $('#<%= RadioButtonListPrimarySelection.ClientID %>').find('input:checked').val();
            //alert(selectedvalue);
            $('#<%= RadioButtonListPrimarySelection.ClientID %> span[id="optionA"]').remove();
            $('#<%= RadioButtonListPrimarySelection.ClientID %> input[value="Import Content Item(s)"]').attr('checked', 'checked');
            return false;

        }
    </script>
     
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="flvUp" runat="server" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" OnClientClick="javascript:return removeIteminlist();" Text="Button" />
    </div>
    <div>
        <asp:RadioButtonList ID="RadioButtonListPrimarySelection" runat="server" RepeatLayout="Flow" repeatdirection="Vertical">
                        <asp:listitem id="optionA" runat="server" value="Import Digital First Manifest"  Selected ="True"/>
                        <asp:listitem id="optionB" runat="server" value="Import Content Item(s)"  Selected ="false"/>
        </asp:RadioButtonList>
    </div>
    </form>
</body>
</html>
