<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree.aspx.cs" Inherits="WebApplication1.jquery.treeview.demo.tree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="../jquery.treeview.css" />
	<link rel="stylesheet" href="screen.css" />
	
	<script src="../lib/jquery.js" type="text/javascript"></script>
	<script src="../lib/jquery.cookie.js" type="text/javascript"></script>
	<script src="../jquery.treeview.js" type="text/javascript"></script>
	
	<script type="text/javascript" src="demo.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul id="browser" class="filetree">
            <span class="folder"><li>
                <input type="checkbox" id="" onclick="SelectChildren(this);" />SitebuilderUploads</span><li>
                    <span class="folder">
                        <input type="checkbox" id="" onclick="SelectChildren(this);" />images</span><ul>
                            <li><span class="folder">
                                <input type="checkbox" id="" onclick="SelectChildren(this);" />universe9e</span><ul>
                                    <li><span class="folder">
                                        <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__0B03A621__5B23__4536__BF8A__8BC612FF7599</span><ul>
                                            <li><span class="file">
                                                <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__0B03A621__5B23__4536__BF8A__8BC612FF7599/CH11 Thumbnail.jpg"
                                                    onclick="SelectChildren(this);" />CH11 Thumbnail.jpg</span></li></ul>
                                        <li><span class="folder">
                                            <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__1305B31E__28A7__4706__86DC__1A85EB3D76C4</span><ul>
                                                <li><span class="file">
                                                    <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__1305B31E__28A7__4706__86DC__1A85EB3D76C4/CH16 Thumbnail.jpg"
                                                        onclick="SelectChildren(this);" />CH16 Thumbnail.jpg</span></li></ul>
                                            <li><span class="folder">
                                                <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__131A9179__FAFC__49C6__BB00__45B3D1EEDB4C</span><ul>
                                                    <li><span class="file">
                                                        <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__131A9179__FAFC__49C6__BB00__45B3D1EEDB4C/CH10 Thumbnail.jpg"
                                                            onclick="SelectChildren(this);" />CH10 Thumbnail.jpg</span></li></ul>
                                                <li><span class="folder">
                                                    <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__1E9B5032__6B42__46DE__A263__4C007C2460AE</span><ul>
                                                        <li><span class="file">
                                                            <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__1E9B5032__6B42__46DE__A263__4C007C2460AE/CH22 Thumbnail.jpg"
                                                                onclick="SelectChildren(this);" />CH22 Thumbnail.jpg</span></li></ul>
                                                    <li><span class="folder">
                                                        <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__22AB7733__444D__45E9__8ABF__57A13A94E237</span><ul>
                                                            <li><span class="file">
                                                                <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__22AB7733__444D__45E9__8ABF__57A13A94E237/CH21 Thumbnail.jpg"
                                                                    onclick="SelectChildren(this);" />CH21 Thumbnail.jpg</span></li></ul>
                                                        <li><span class="folder">
                                                            <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__247D74CB__4EAE__4B4E__9E47__C1633CE151AE</span><ul>
                                                                <li><span class="file">
                                                                    <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__247D74CB__4EAE__4B4E__9E47__C1633CE151AE/CH27 Thumbnail.jpg"
                                                                        onclick="SelectChildren(this);" />CH27 Thumbnail.jpg</span></li></ul>
                                                            <li><span class="folder">
                                                                <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__24AAE0D5__6EC1__4A6E__9D5F__46F0A1D5EAAD</span><ul>
                                                                    <li><span class="file">
                                                                        <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__24AAE0D5__6EC1__4A6E__9D5F__46F0A1D5EAAD/CH17 Thumbnail.jpg"
                                                                            onclick="SelectChildren(this);" />CH17 Thumbnail.jpg</span></li></ul>
                                                                <li><span class="folder">
                                                                    <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__2C968355__D838__46C6__9C2B__B3E2DA6C4709</span><ul>
                                                                        <li><span class="file">
                                                                            <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__2C968355__D838__46C6__9C2B__B3E2DA6C4709/CH19 Thumbnail.jpg"
                                                                                onclick="SelectChildren(this);" />CH19 Thumbnail.jpg</span></li></ul>
                                                                    <li><span class="folder">
                                                                        <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__379A51E6__E185__4569__8B72__2E8516A449B5</span><ul>
                                                                            <li><span class="file">
                                                                                <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__379A51E6__E185__4569__8B72__2E8516A449B5/CH07 Thumbnail.jpg"
                                                                                    onclick="SelectChildren(this);" />CH07 Thumbnail.jpg</span></li></ul>
                                                                        <li><span class="folder">
                                                                            <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__37F84A10__5E55__4B7E__849C__F0656E9160B1</span><ul>
                                                                                <li><span class="file">
                                                                                    <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__37F84A10__5E55__4B7E__849C__F0656E9160B1/CH09 Thumbnail.jpg"
                                                                                        onclick="SelectChildren(this);" />CH09 Thumbnail.jpg</span></li></ul>
                                                                            <li><span class="folder">
                                                                                <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__51162963__79A2__45E3__B482__E1CB7C36D022</span><ul>
                                                                                    <li><span class="file">
                                                                                        <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__51162963__79A2__45E3__B482__E1CB7C36D022/CH12 Thumbnail.jpg"
                                                                                            onclick="SelectChildren(this);" />CH12 Thumbnail.jpg</span></li></ul>
                                                                                <li><span class="folder">
                                                                                    <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__62516201__BBE6__4FB5__B066__7534BC15597A</span><ul>
                                                                                        <li><span class="file">
                                                                                            <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__62516201__BBE6__4FB5__B066__7534BC15597A/CH13 Thumbnail.jpg"
                                                                                                onclick="SelectChildren(this);" />CH13 Thumbnail.jpg</span></li></ul>
                                                                                    <li><span class="folder">
                                                                                        <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__6D569A30__ECF6__4A06__BC4F__5C226F043D26</span><ul>
                                                                                            <li><span class="file">
                                                                                                <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__6D569A30__ECF6__4A06__BC4F__5C226F043D26/CH25 Thumbnail.jpg"
                                                                                                    onclick="SelectChildren(this);" />CH25 Thumbnail.jpg</span></li></ul>
                                                                                        <li><span class="folder">
                                                                                            <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__8284C1CF__1ABD__4087__8EEA__9F6F47D3013F</span><ul>
                                                                                                <li><span class="file">
                                                                                                    <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__8284C1CF__1ABD__4087__8EEA__9F6F47D3013F/CH08 Thumbnail.jpg"
                                                                                                        onclick="SelectChildren(this);" />CH08 Thumbnail.jpg</span></li></ul>
                                                                                            <li><span class="folder">
                                                                                                <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__87BDEB6B__FD4D__41CB__AB9E__5AB623707B40</span><ul>
                                                                                                    <li><span class="file">
                                                                                                        <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__87BDEB6B__FD4D__41CB__AB9E__5AB623707B40/CH20 Thumbnail.jpg"
                                                                                                            onclick="SelectChildren(this);" />CH20 Thumbnail.jpg</span></li></ul>
                                                                                                <li><span class="folder">
                                                                                                    <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__93EF34B9__D3E6__4FED__B0CB__C5EE2968B092</span><ul>
                                                                                                        <li><span class="file">
                                                                                                            <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__93EF34B9__D3E6__4FED__B0CB__C5EE2968B092/CH18 Thumbnail.jpg"
                                                                                                                onclick="SelectChildren(this);" />CH18 Thumbnail.jpg</span></li></ul>
                                                                                                    <li><span class="folder">
                                                                                                        <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__B3FAD9B7__9208__4124__9167__1E200A153700</span><ul>
                                                                                                            <li><span class="file">
                                                                                                                <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__B3FAD9B7__9208__4124__9167__1E200A153700/CH23 Thumbnail.jpg"
                                                                                                                    onclick="SelectChildren(this);" />CH23 Thumbnail.jpg</span></li></ul>
                                                                                                        <li><span class="folder">
                                                                                                            <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__B88F6531__221C__4AD3__A25A__7CBB8D653549</span><ul>
                                                                                                                <li><span class="file">
                                                                                                                    <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__B88F6531__221C__4AD3__A25A__7CBB8D653549/CH24 Thumbnail.jpg"
                                                                                                                        onclick="SelectChildren(this);" />CH24 Thumbnail.jpg</span></li></ul>
                                                                                                            <li><span class="folder">
                                                                                                                <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__E529DEDE__F89E__4CF5__9C7A__4B8FBA7E7DAC</span><ul>
                                                                                                                    <li><span class="file">
                                                                                                                        <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__E529DEDE__F89E__4CF5__9C7A__4B8FBA7E7DAC/CH15 Thumbnail.jpg"
                                                                                                                            onclick="SelectChildren(this);" />CH15 Thumbnail.jpg</span></li></ul>
                                                                                                                <li><span class="folder">
                                                                                                                    <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__E7D26BD4__D55D__4367__B290__BE9F8712DCE8</span><ul>
                                                                                                                        <li><span class="file">
                                                                                                                            <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__E7D26BD4__D55D__4367__B290__BE9F8712DCE8/CH20 Thumbnail.jpg"
                                                                                                                                onclick="SelectChildren(this);" />CH20 Thumbnail.jpg</span></li></ul>
                                                                                                                    <li><span class="folder">
                                                                                                                        <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__F3983FD8__AFA1__4572__8B71__4C627CBF98DE</span><ul>
                                                                                                                            <li><span class="file">
                                                                                                                                <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__F3983FD8__AFA1__4572__8B71__4C627CBF98DE/CH14 Thumbnail.jpg"
                                                                                                                                    onclick="SelectChildren(this);" />CH14 Thumbnail.jpg</span></li></ul>
                                                                                                                        <li><span class="folder">
                                                                                                                            <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__F5E7F4EB__29CA__4657__846C__FE11E52F3312</span><ul>
                                                                                                                                <li><span class="file">
                                                                                                                                    <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__F5E7F4EB__29CA__4657__846C__FE11E52F3312/CH28 Thumbnail.jpg"
                                                                                                                                        onclick="SelectChildren(this);" />CH28 Thumbnail.jpg</span></li></ul>
                                                                                                                            <li><span class="folder">
                                                                                                                                <input type="checkbox" id="" onclick="SelectChildren(this);" />bsi__F75B151A__4257__44AB__BF56__0A23471E5B25</span><ul>
                                                                                                                                    <li><span class="file">
                                                                                                                                        <input type="checkbox" id="SitebuilderUploads/images/universe9e/bsi__F75B151A__4257__44AB__BF56__0A23471E5B25/CH26 Thumbnail.jpg"
                                                                                                                                            onclick="SelectChildren(this);" />CH26 Thumbnail.jpg</span></li></ul>
                                </ul>
                        </ul>
                    <li><span class="folder">
                        <input type="checkbox" id="" onclick="SelectChildren(this);" />Dummy folder</span><ul>
                            <li><span class="folder">
                                <input type="checkbox" id="" onclick="SelectChildren(this);" />sample_files</span><ul>
                                    <li><span class="file">
                                        <input type="checkbox" id="SitebuilderUploads/Dummy folder/sample_files/colorschememapping.xml"
                                            onclick="SelectChildren(this);" />colorschememapping.xml</span></li></ul>
                                <ul>
                                    <li><span class="file">
                                        <input type="checkbox" id="SitebuilderUploads/Dummy folder/sample_files/filelist.xml"
                                            onclick="SelectChildren(this);" />filelist.xml</span></li></ul>
                                <ul>
                                    <li><span class="file">
                                        <input type="checkbox" id="SitebuilderUploads/Dummy folder/sample_files/image001.jpg"
                                            onclick="SelectChildren(this);" />image001.jpg</span></li></ul>
                                <ul>
                                    <li><span class="file">
                                        <input type="checkbox" id="SitebuilderUploads/Dummy folder/sample_files/image002.jpg"
                                            onclick="SelectChildren(this);" />image002.jpg</span></li></ul>
                                <ul>
                                    <li><span class="file">
                                        <input type="checkbox" id="SitebuilderUploads/Dummy folder/sample_files/themedata.thmx"
                                            onclick="SelectChildren(this);" />themedata.thmx</span></li></ul>
                        </ul>
                        <li><span class="folder">
                            <input type="checkbox" id="" onclick="SelectChildren(this);" />QTI</span><ul>
                                <li><span class="file">
                                    <input type="checkbox" id="SitebuilderUploads/QTI/4-test.xml" onclick="SelectChildren(this);" />4-test.xml</span></li></ul>
                        </li>
                        </li>
        </ul>
    </div>
    </form>
</body>
</html>
