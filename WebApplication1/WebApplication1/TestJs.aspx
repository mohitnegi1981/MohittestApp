<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJs.aspx.cs" Inherits="WebApplication1.TestJs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
  .popup {
    width:200px;
    height:100px;
    position:absolute;
    top:50%;
    left:50%;
    margin:-50px 0 0 -100px; /* [-(height/2)px 0 0 -(width/2)px] */
    display:none;
    border: 1px Solid red;
  }
</style>
    <script language="javascript" src="js/jquery-1.4.1.js"></script>
    <script language="javascript" src="js/jquery-1.6.4.min.js"></script>
    <script language="javascript" src="js/jquery.js"></script>
    <script language="javascript" type="text/javascript">


        $(function () {
            $("#demo4").tree({
                data: {
                    type: "xml_flat", // or "xml_nested" or "json"
                    url: "D:\Site Builder\QTI\chapter_2.xml"
                }
            });
        });



        function showValue() {
        var sendData = '' +
                    '<?xml version="1.0" encoding="utf-8"?>' +
                    '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">' +
                    '  <soap:Body>' +
                    '    <Syndata xmlns="localhost:63215/TestJs.aspx"><Msg><![CDATA[' + 12345 + ']]></Msg></Syndata>' +
                    '  </soap:Body>' +
                    '</soap:Envelope>';
            $.ajax({
                type: "POST",
                url: "API/SIUI_API.asmx?op=Syndata",
                contentType: "application/json; charset=utf-8",
                data: sendData,
                dataType: "json",
                success: function (data) { },
                error: function (xhr, status, error) {
                    alert(error);
                }
            });
        }

        function clearfiled() {

            //var fileuplod = document.getElementById('openfile');
            //fileuplod.value = '';
            //document.getElementById('openfile').parentNode.innerHTML = document.getElementById('openfile').parentNode.innerHTML
            //return false
            //alert('hi');
            showDiv("showdiv", 200, 'block', 200, 500, 400);
            return false;
        }

        function showDiv(ID, top, display, height, left, width) {

            try {

                var DivCover = document.getElementById('DivCover');
                if (DivCover != null) {

                    DivCover.style.display = 'none';
                    DivCover.style.background = 'Transparent';
                    DivCover.style.border = "4px solid #000";
                    DivCover.style.width = window.screen.width + 'px';

                    DivCover.style.height = window.screen.height + 'px';
                    DivCover.style.top = 1 + 'px';
                    DivCover.style.position = 'fixed';
                    DivCover.style.backgroundColor = "#ccc";
                    DivCover.style.filter = 'alpha(opacity=50)';
                    DivCover.style.opacity = '0.5';
                    DivCover.style.display = 'block';
                }

                showdeadcenterdiv(width, height, ID, display);
                return false;
            }
            catch (e) {
                // alert("Errror");
            }
        }


        function showdeadcenterdiv(Xwidth, Yheight, divid, display) {
            // First, determine how much the visitor has scrolled
            var scrolledX, scrolledY;
            if (self.pageYOffset) {
                scrolledX = self.pageXOffset;
                scrolledY = self.pageYOffset;
            } else if (document.documentElement && document.documentElement.scrollTop) {
                scrolledX = document.documentElement.scrollLeft;
                scrolledY = document.documentElement.scrollTop;
            } else if (document.body) {
                scrolledX = document.body.scrollLeft;
                scrolledY = document.body.scrollTop;
            }

            // Next, determine the coordinates of the center of browser's window

            var centerX, centerY;
            if (self.innerHeight) {
                centerX = self.innerWidth;
                centerY = self.innerHeight;
            } else if (document.documentElement && document.documentElement.clientHeight) {
                centerX = document.documentElement.clientWidth;
                centerY = document.documentElement.clientHeight;
            } else if (document.body) {
                centerX = document.body.clientWidth;
                centerY = document.body.clientHeight;
            }
            // Xwidth is the width of the div, Yheight is the height of the
            // div passed as arguments to the function:
            var leftOffset = scrolledX + (centerX - Xwidth) / 2;
            //var topOffset = 0;
            var topOffset = scrolledY + (centerY - Yheight) / 2;
            /* if (divid == 'divTeam') {
            topOffset = "22";
            }
            else {
            topOffset = "200";
            }*/
            // The initial width and height of the div can be set in the
            // style sheet with display:none; divid is passed as an argument to // the function
            var o = document.getElementById(divid);
            var r = o.style;
            r.position = 'absolute';
            //r.top = topOffset + 'px';
            r.top = topOffset + 'px';
            r.left = leftOffset + 'px';
            r.display = display;
            r.height = Yheight + 'px';
            r.width = Xwidth + 'px';
            r.position = 'fixed';
            return false;
        }

        function hideDiv1() {
            var DivCover = document.getElementById('DivCover');
            var divConfim = document.getElementById('showdiv');
            DivCover.style.display = 'none';
            divConfim.style.display = 'none';
            
            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="file" id="openfile" />

        <asp:Button ID="btn" Text="Open Buton" runat="server" OnClientClick="clearfiled()" />
        <div id="DivCover" style="display:none; z-index:1">
        <div id="showdiv" style="z-index:500;display:none;border:1px solid red;" >
            hi hello
            <br />
            <asp:Button ID="btnsubmit" runat="server" OnClientClick="return hideDiv1();" />
        </div>
        <div id="demo4">
        
        </div>
    </div>
    </form>
</body>
</html>
