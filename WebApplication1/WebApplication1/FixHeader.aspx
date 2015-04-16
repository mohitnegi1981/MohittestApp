<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FixHeader.aspx.cs" Inherits="WebApplication1.FixHeader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    #AdjResultsDiv #GridViewLeaveHistory { 
        width: 1080px; 
        height: 500px; 
        overflow: scroll; 
        position: relative; 
    }
     #AdjResultsDiv #GridViewLeaveHistory th 
    {   
        top: expression(document.getElementById("AdjResultsDiv").scrollTop-2); 
        left: expression(parentNode.parentNode.parentNode.parentNode.scrollLeft); 
        position: relative; 
        z-index: 20; 
    }
    div#AdjResultsDiv { 
        width: 1080px; 
        height: 500px; 
        overflow: scroll; 
        position: relative; 
        }

    div#AdjResultsDiv #GridViewLeaveHistory th {   
    top: expression(document.getElementById("AdjResultsDiv").scrollTop-2); 
    left: expression(parentNode.parentNode.parentNode.parentNode.scrollLeft); 
    position: relative; 
    z-index: 20; 
    } 
    </style>
    <script language="javascript" type="text/javascript">
        function showmsg() {
            alert('HI');
            return false;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div  id = "AdjResultsDiv" style="display:none;"> 
        
             <asp:GridView ID="GridViewLeaveHistory" runat="server" GridLines="Both"    Width ="100%">
              <HeaderStyle />
              <Columns>
                <asp:BoundField DataField="iSingleContentID" HeaderText="COntent ID"  />
                <asp:BoundField DataField="iProcessTypeID" HeaderText="iProcessTypeID" />
                <asp:BoundField DataField="iSourceTable" HeaderText="iSourceTable" />
                <asp:BoundField DataField="object_name" HeaderText="object_name" />
                <asp:BoundField DataField="szUrlRoot" HeaderText="szUrlRoot" />
                <asp:BoundField DataField="a_webc_url" HeaderText="a_webc_url" />
                <asp:BoundField DataField="bfw_uid" HeaderText="bfw_uid" />
                <asp:BoundField DataField="SourceFolderPath" HeaderText="r_object_id" />
                <asp:BoundField DataField="a_webc_url" HeaderText="a_webc_url" />
                <asp:BoundField DataField="bfw_uid" HeaderText="bfw_uid" />
                <asp:BoundField DataField="SourceFolderPath" HeaderText="r_object_id" />
              </Columns>
              </asp:GridView>
              <asp:Label Text="FileName.txt" runat="server" ID="lblFileName"></asp:Label> 
              


    </div>
    </div>
    <asp:PlaceHolder runat="server" ID="plcHldrControl"></asp:PlaceHolder>
    <asp:Button ID="Button1" runat="server" Text="Create Button" 
        onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Click" 
        onclick="Button2_Click" Visible="false" />
        <asp:HiddenField ID="hdnValue" Value="0" runat="server" />
    </form>
</body>
</html>
