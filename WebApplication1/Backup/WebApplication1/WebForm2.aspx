<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1.6.4.min.js"></script>
    <script language="javascript" type="text/javascript">
        
        function showtext() {
            var strEmail = document.getElementById("TextBox1").value;
            var strRep = strEmail.replace(/\,/g, ';');
            alert(strRep);
            return false;
        }

        var isDirty;
        isDirty = 0;

        $(document).ready(function() {
            
            $(":input").change(function() {
                isDirty = 1;
            });
        });

        function show1() {
            
                if (isDirty == 1) {
                    //return false;
                    var varConfirm = confirm('Press ok to save and exit press cancel to stay on the page.');
                    if (varConfirm == true) {
                        alert('true');
                    }
                    else {
                        alert('false');
                        return false;
                    }
                }
            }
       
        
    </script>
</head>
<body onbeforeunload="return show1();">
    <form id="form1" runat="server">
    <div>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="CheckBoxList1_SelectedIndexChanged"></asp:CheckBoxList>
    &nbsp;&nbsp;&nbsp;
    </div>
    <asp:TextBox ID="TextBox1" runat="server" Width="914px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" OnClientClick="showtext()" Text="Button" />
    <asp:Label ID="lblvalue" runat="server" Text="texttoGet"></asp:Label>
    </form>
</body>
</html>
