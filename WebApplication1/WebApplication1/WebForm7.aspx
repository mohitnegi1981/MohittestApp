<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="WebApplication1.WebForm7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1.6.4.min.js"></script>
    <script language="javascript" type="text/javascript">
        function createarray() {
            var hdnTitleItems = document.getElementById('hdnAry').value;
            var list1 = hdnTitleItems.split('!!');
            var selectedDiscipline = "Biology 2102";
            var listitems;
            var select = $('#lstSubject');
            for (i = 0; i < list1.length; i++) {
                if (list1[i].indexOf(selectedDiscipline) != -1) {
                    var list2 = list1[i].split('||');
                    $.each(list2, function (index, value) {
                        if (index == 1) {
                            var list3 = value.split('**');
                            $.each(list3, function (i, v) {
                                listitems += '<option value=' + v + '>' + v + '</option>';
                            });
                        }
                    });
                }
            }
            select.append(listitems);
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="hidden" id="hdnAry" runat="server" />
    <input type="button" id="btnclick" onclick="createarray()" title="Click me" 
            name="Click Me" value="Click me" />
        <br />
        <br />
    <select id="lstSubject" size="15">
        
    </select>
    </div>
    </form>
</body>
</html>
