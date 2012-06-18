<%@ Page Language="C#" AutoEventWireup="true" CodeFile="maps.aspx.cs" Inherits="maps" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>    
    <div>        
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>    
    <div style="margin-top:10px;width:100%;float:right;">
        <asp:Button ID="btnSavePos" runat="server" Text="Lưu vị trí" width="100px" onclick="btnSavePos_Click"
             />
           <%-- <asp:Button ID="btnHuy" runat="server" Text="Hủy" width="50px" onclick="btnHuy_Click" 
            />--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblToaDoX" runat="server" Text="Vĩ độ:  ">
                
            </asp:Label>
            <asp:TextBox ID="txtViDo" runat="server" >
            
            </asp:TextBox>
            <asp:Label ID="lblkinhDo" runat="server" Text="Kinh độ:  ">
                
            </asp:Label>
            <asp:TextBox ID="txtKinhDo" runat="server" >
            
            </asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel>
    </div>    
  

    </form>
</body>
</html>
