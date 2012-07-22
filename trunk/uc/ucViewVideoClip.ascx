<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewVideoClip.ascx.cs" Inherits="uc_ucViewVideoClip" %>
<%@ Register Assembly="Media-Player-ASP.NET-Control" Namespace="Media_Player_ASP.NET_Control"
    TagPrefix="cc1" %>
<%@ Register src="~/uc/ucListVideoInCat.ascx" tagname="ucListVideoInCat" tagprefix="uc1" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<link href="<%=ResolveUrl("~/css/video.css") %>" rel="stylesheet" type="text/css" />
<script src='<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.10.min.js") %>' type="text/javascript"></script>
<div class="post">
	<div class="post-body">
        <asp:Panel runat="server" ID="pnXemvideo">
            <div runat="server" id="divVideo">
                 <a  
			         style='display:block;width:520px;height:330px'
			         id='player'> 
		        </a>
            </div>
        </asp:Panel>
	</div>
    <div class="post-title">
        <h2>
            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
        </h2>
        <asp:Label CssClass="desc" ID="lblDesc" runat="server" />
    </div>
    <div class="post-date">
        <asp:Label ID="lblDateTime" CssClass="date" runat="server" /> &nbsp;|&nbsp;
        <asp:Label CssClass="view" ID="lblLuotxem" runat="server" Text=""></asp:Label>
    </div>	
</div>
<uc1:ucListVideoInCat runat="server" />
<script type="text/javascript">
    $(document).ready(function () {
        var lblTrangthai = $("#lblTrangthai");
        var swfUrl = '<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.11.swf") %>';
        var player = $f("player_content", swfUrl, {
            // this will enable pseudostreaming support
            plugins: {
                pseudo: {
                    url: "http://releases.flowplayer.org/swf/flowplayer.pseudostreaming-3.2.9.swf"
                }
            },
            // listen to following clip events
            clip: {
                // these two settings will make the first frame visible
                autoPlay: false,
                autoBuffering: true,
                // make this clip use pseudostreaming plugin with "provider" property
                provider: 'pseudo'
            }
        });
    });
</script>