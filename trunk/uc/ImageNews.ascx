<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageNews.ascx.cs" Inherits="uc_ImageNews" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<asp:Panel ID="pnNews" runat="server">
<div class="post">
	<div class="post-title"><h2>
        <asp:HyperLink ID="lnkTitle" runat="server" />
    </h2></div>
    <div class="post-date"><asp:Label ID="lblDateTime" runat="server" /></div>
    
	<div class="post-body">
        <p class="bordered" style="width:500px;" >
            <asp:HyperLink ID="lnkLink" runat="server">                
                    <asp:Image ID ="img" runat="server" Width="495px" height ="320px"  class="bordered" />                
            </asp:HyperLink>            
        </p>
		<asp:Label ID="lblDesc" runat="server" />
        <asp:HyperLink ID="lnkChitiet" Text="<%$ Resources:Language, readmore%>" class="more" runat="server" />.            
	</div>	
    			
</div>
</asp:Panel>