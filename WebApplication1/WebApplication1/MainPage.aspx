<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplication1.MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .BFWj-overlay {
    display: none;
	position: relative;
	background-color: #fff;
	overflow:scroll;
	height:200;
	
    }
    .BFWj-overlay_title {
	position: relative;
	padding: 10px;
	font-size: 10px;
	
    }
    .BFWj-overlay_contents {
	    position: relative;
	    padding: 10px;
	    overflow: hidden;
	    text-align: center;
    }
    .BFWj-overlay_if {
        WIDTH: 100%; 
        HEIGHT: 500px; 
        BACKGROUND-COLOR: transparent;
        PADDING:0px;
    }
    </style>
    <script language="javascript" src="js/jquery-1.6.4.min.js"></script>
    <script language="javascript" type="text/javascript">
        function test() {
            $('.BFWj-overlay').css('display', 'inline');
            var URL = 'WebForm1.aspx';
            //var URL = 'https://www.google.com/';
            $('#overlay_add_site_if').get(0).src = URL;
            $('#overlay_add_site_if').height = "300";
        }
    </script>
    

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnClick" runat="server" Text="Click" OnClientClick="test()" 
             />
        <input type="button" id="btnClick" onclick="test()" value="Click Me"  />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Parse XML" 
            onclick="Button1_Click" />
        <br />
    </div>
    <div id="overlay_add_site" class="BFWj-overlay">
    <div class="BFWj-overlay_title"></div>
        <div class="BFWj-overlay_contents">
            <div id="overlay_add_site_submitted" class="form_submitted"></div>
            <!-- ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ -->
            <div id="overlay_add_site_instructions" class="form_instructions">Follow the steps below to set up a new site. Be sure to check the information you enter to ensure the RA and SiteItems data is saved correctly.</div>
            <div class="form_page_1">
                <iframe id="overlay_add_site_if" class="BFWj-overlay_if" frameborder="0" scrolling="no" allowTransparency="allowTransparency"></iframe>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdntest" runat="server" Value="test" />
    </form>
</body>
</html>
