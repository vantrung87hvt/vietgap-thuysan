<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewVideoClip.ascx.cs" Inherits="uc_ucViewVideoClip" %>
<%@ Register Assembly="Media-Player-ASP.NET-Control" Namespace="Media_Player_ASP.NET_Control"
    TagPrefix="cc1" %>
<%@ Register src="~/uc/ucListVideoInCat.ascx" tagname="ucListVideoInCat" tagprefix="uc1" %>
<link href="<%=ResolveUrl("css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<div class="post">
	<div class="post-title"><h2>
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    </h2></div>
    <div class="post-date"><asp:Label ID="lblDateTime" runat="server" /></div>
	<div class="post-body">
        <asp:Panel runat="server" ID="pnXemvideo">
                <div runat="server" id="divVideo"></div>
            </asp:Panel>
		<asp:Label ID="lblDesc" runat="server" />
	</div>	
</div>
<hr />
<uc1:ucListVideoInCat runat="server" />
