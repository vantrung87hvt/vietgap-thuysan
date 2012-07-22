<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListVideoClips.ascx.cs"
    Inherits="uc_ucListVideoClips" %>
<%@ Register Assembly="ASPNetVideo.NET2" Namespace="ASPNetVideo" TagPrefix="ASPNetVideo" %>
<%--<script src='<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.10.min.js") %>' type="text/javascript"></script>
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
            <asp:Label ID="lblMota" runat="server" Text=""></asp:Label>
            <asp:Panel runat="server" ID="pnXemvideo">
                <div runat="server" id="divVideo">
                </div>
            </asp:Panel>
        </td>
    </tr>
</table>--%>
<div>
    <h3>Video mới nhất</h3>
    <asp:Repeater ID="rptVideoClips" runat="server">
        <ItemTemplate>
            <div class="video-icon">
                <asp:HyperLink ID="hypVideoLink" CssClass="video-icon" runat="server" NavigateUrl='<%#"~/Content.aspx?VideoID="+Eval("PK_iVideoID") %>'><%#getSubString(Eval("sTieude").ToString())%>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
