<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewNews.ascx.cs" Inherits="INVI.INVINews.Module.ViewNews" %>

<%@ Register src="~/uc/Feedback.ascx" tagname="Feedback" tagprefix="uc1" %>
<%@ Register src="~/uc/ListFeedback.ascx" tagname="ListFeedback" tagprefix="uc2" %>
<%@ Register src="~/uc/Rate.ascx" tagname="Rate" tagprefix="uc3" %>
<%@ Register src="~/uc/Poll.ascx" tagname="Poll" tagprefix="uc4" %>
<%@ Register src="ListNewsMoreInCat.ascx" tagname="ListNewsMoreInCat" tagprefix="uc5" %>

<%@ Register src="ListNewsByTag.ascx" tagname="ListNewsByTag" tagprefix="uc6" %>

<%@ Register src="SearchNewsByDate.ascx" tagname="SearchNewsByDate" tagprefix="uc7" %>

<style>
    .bluelink
    {
        clear: both;
        float: left;
        margin-top: 10px;
        margin-bottom: 10px;
        width: 100%;
        
    }
    .blueTitle
    {
        color: #006599;
        font-size: 18pt;
        font-weight:bold;
        margin-bottom:10px;
        float:left;
    }
    .anhtin
    {
        width: 150px;
        height: 150px;
        margin-right: 5px;
        float: left;
    }
    .tinControl
    {
        margin-top:20px;
    }
    .tinControl li
    {
        list-style-image:url(images/1vuong.jpg);
    }
    .right
    {
    	text-align:justify;
    	float:left;
    	
    }
</style>
<div style="float:left;margin-left:10px;width:512px">
<asp:Label ID="lblMessage" ForeColor="red" runat="server" />
<asp:PlaceHolder ID="phXemtin" runat="server">
<div>
    <asp:HyperLink ID="lnkCategory" runat="server"/>	
        <br />
	    <div class="bluelink">
	        <asp:Label ID="lblTieude" CssClass="blueTitle"  Runat="server" />
		    
		    <asp:Label ID="lblMota" Font-Bold="true" CssClass="right" Width="100%" Runat="server" />
	    </div>
	    <div style="clear:both">
		    
		    <div><asp:Label ID="lblNoidung" Runat="server" />
		    
		    <asp:Label ID="lblTNgaydang" runat="server" Text="Ngày đăng"></asp:Label>:<asp:Label  ID="lblNgaydang" Runat="server" />
		    </div>
	    </div>
	<div class="tinControl" >
	<asp:PlaceHolder ID="phControl" Runat="server">
	    <uc3:Rate ID="Rate1" runat="server" />
        <uc1:Feedback ID="Feedback1" runat="server" />
        <uc2:ListFeedback ID="ListFeedback1" runat="server" />
        <uc4:Poll ID="Poll1" runat="server" />
        <div style="font-weight:bold;font-size:11pt">Tin cùng chủ đề</div>
        <uc5:ListNewsMoreInCat ID="ListNewsMoreInCat1" runat="server" />
        <div style="font-weight:bold;font-size:11pt">Xem tin theo ngày</div>
        <uc7:SearchNewsByDate ID="SearchNewsByDate1" runat="server" />
	</asp:PlaceHolder>
	</div>	
</div>
</asp:PlaceHolder>
</div>






























































































































































































































































