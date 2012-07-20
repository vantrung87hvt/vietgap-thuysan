<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListVideoClips.ascx.cs"
    Inherits="uc_ucListVideoClips" %>
<%@ Register Assembly="ASPNetVideo.NET2" Namespace="ASPNetVideo" TagPrefix="ASPNetVideo" %>
<script src='<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.10.min.js") %>' type="text/javascript"></script>
<script src='<%=ResolveUrl("../js/jquery-1.7.1.js")%>' type="text/javascript"></script>
<table>
    <tr>
        <td>
            <asp:HyperLink ID="hypVideoLink" runat="server" NavigateUrl="~/Content.aspx?mode=uc&page=ViewVideoClip">Video
            </asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel runat="server" ID="pnXemvideo">
                <div runat="server" id="divVideo">
                </div>
                <script type="text/javascript">
                    var swfUrl = '<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.11.swf") %>';
                    $(document).ready(function () {
                        flowplayer("player", swfUrl, {
                            clip: {
                                url: "myMovie.flv",
                                autoPlay: false
                            }
                        });
                    });
                </script>
            </asp:Panel>
        </td>
    </tr>
</table>
<div>
    <asp:Repeater ID="rptVideoClips" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="hypVideoLink" runat="server" NavigateUrl='<%#"~/Content.aspx?VideoID="+Eval("PK_iVideoID") %>'><%#Eval("sTieude")%>
            </asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>
</div>
