<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="uc_footer" %>
<%@ Register src="~/uc/DisplayAdv.ascx" tagname="DisplayAdv" tagprefix="uc11" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<div class="quangcao_footer">
    <uc11:DisplayAdv ID="DisplayAdv3" Huong="Horizontal" MaxWidth="820" MaxHeight="100" Vitri="Cuoitrang" runat="server" />
</div>
<div class="footer-left">
    <p class="align-left">
        <asp:Label ID="lblNoidung" runat="server" />
    </p>
</div>
<div class="footer-right">
    <p class="align-right"> 
    <a href=""><asp:Label ID="lblHomeFooter" Text="<%$ Resources:Language, lblHomeMenu%>" runat="server" /></a>&nbsp;|&nbsp; 
    <a href=""><asp:Label ID="lblNews" Text="<%$ Resources:Language, lblNewsMenu%>" runat="server" /></a>&nbsp;|&nbsp;
    <a href=""><asp:Label ID="lblSupport" Text="<%$ Resources:Language, lblSupportMenu%>" runat="server" /></a>&nbsp;|&nbsp;       
    <a href=""><asp:Label ID="lblAbout" Text="<%$ Resources:Language, lblAboutMenu%>" runat="server" /></a>
    </p>
</div>
    
