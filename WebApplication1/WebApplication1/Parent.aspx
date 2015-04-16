<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Parent.aspx.cs" Inherits="WebApplication1.Parent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript">
        function openModel() {
            var vdialogargs = "dialogHeight: 300px; dialogWidth: 500px;dialogTop: 190px;  dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;titlebar:No;";
            var vPopUpWin = window.showModalDialog("http://localhost:63215/Child.aspx", window, vdialogargs);
            alert(vPopUpWin);
        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="parentbutton" runat="server" Text="Open Child" OnClientClick="openModel();" />
        <asp:HiddenField ID="hdn" runat="server" />
    </div>
    <div>
        
                <ul>
                    <li><span class="FOLDER">
                        <input type="CHECKBOX" id="0" onclick="sELECTcHILDREN(THIS);" />3.XML</span></ul>
                </LI><ul>
                    <li><span class="FOLDER">
                        <input type="CHECKBOX" id="0" onclick="sELECTcHILDREN(THIS);" />4.XML</span></ul>
                </LI><ul>
                    <li><span class="FOLDER">
                        <input type="CHECKBOX" id="0" onclick="sELECTcHILDREN(THIS);" />5.XML</span></ul>
        </LI></LI>
    </div>
    </form>
</body>
</html>
