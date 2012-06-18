<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="uc_footer" %>
<%@ Register src="~/uc/DisplayAdv.ascx" tagname="DisplayAdv" tagprefix="uc11" %>
<style>
#footer { 
	clear: both; 
	color: #FFF; 
	background: #A9BAC3; 
	border-top: 5px solid #568EB6;
	margin: 0; padding: 0; 
	height: 50px;	  
	font-size: 95%;		
}
#footer a { 
	text-decoration: none; 
	font-weight: bold;	
	color: #FFF;
}
#footer .footer-left{
	float: left;
	width: 55%;
}
#footer .footer-right{
	float: right;
	width: 45%;
}
</style>
 <div class="quangcao_footer">
        <uc11:DisplayAdv 
            ID="DisplayAdv3" Huong="Horizontal" MaxWidth="820" MaxHeight="100" Vitri="Cuoitrang" runat="server" />
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
    
