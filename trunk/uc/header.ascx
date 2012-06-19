<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="uc_header" %>
<%@ Register src="ListEventNews.ascx" tagname="ListEventNews" tagprefix="uc1" %>
<%@ Register src="SearchNews.ascx" tagname="SearchNews" tagprefix="uc2" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<div class="header">
    <a name="top" />
  <div class="dvNav">
    <div class="dvTopMenu">
        
        <div class="menuItem"><asp:HyperLink ID="lnkTopCat" runat="server" NavigateUrl="~/Default.aspx" Text="<%$ Resources:Language, lblHomeMenu%>" /></div>
        <div class="menuItem"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Default.aspx" Text="<%$ Resources:Language, lblDaoTao%>" /></div>
        <div class="menuItem"><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Default.aspx" Text="<%$ Resources:Language, lblKhoaHoc%>" /></div>
        <div class="menuItem"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" Text="<%$ Resources:Language, lblThuVien%>" /></div>
        <div class="menuItem"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Default.aspx" Text="<%$ Resources:Language, lblGioiThieu%>" /></div>
        <div class="menuItem"><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Contact.aspx" Text="<%$ Resources:Language, lblLienHe%>" /></div>
        <img src="images/redbtn.jpg" width="0" height="0" />
    </div>
     <uc2:SearchNews ID="SearchNews1" runat="server" />
  </div>
  <div class="dvTopCat">
  <asp:Menu ID="mnuTopCat" runat="server" Orientation="Horizontal" StaticItemFormatString="&nbsp;{0}&nbsp;&nbsp;|" DynamicEnableDefaultPopOutImage="false" StaticEnableDefaultPopOutImage="false"
    DynamicMenuItemStyle-CssClass="topmenu_item" StaticHoverStyle-CssClass="topmenu_hover" StaticMenuItemStyle-Height="20px" DynamicHoverStyle-CssClass="topmenu_hover" DynamicMenuStyle-BackColor="#E9F4FA">
    
  </asp:Menu>
     
  </div>
  <embed src="images/title.swf" quality="high" wmode="transparent" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="995px" height="20px"></embed>
  <div class="dvTrangtri">      
      <uc1:ListEventNews ID="ListEventNews1" runat="server" />
  </div>
</div>


