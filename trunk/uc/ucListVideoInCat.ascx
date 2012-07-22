<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListVideoInCat.ascx.cs"
    Inherits="uc_ucListVideoInCat" %>
<script src="../Plugin/flowplayer/flowplayer-3.2.10.min.js" type="text/javascript"></script>
<div class="lst-video">
    <asp:Repeater ID="rptVideoClips" runat="server">
        <ItemTemplate>
            <div class="video-item">
                <asp:HyperLink CssClass="video-link" runat="server" NavigateUrl='<%#"~/Content.aspx?VideoID="+Eval("PK_iVideoID") %>'>
                    <img src="<%#Eval("sAnhMinhHoa") %>" alt='<%#Eval("sMota") %>' />
                </asp:HyperLink>
                <div class="desc">
                    <asp:HyperLink ToolTip='<%#Eval("sMota") %>' runat="server" NavigateUrl='<%#"~/Content.aspx?VideoID="+Eval("PK_iVideoID") %>'><%#Eval("sTieude")%></asp:HyperLink>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="video-page">
    <asp:LinkButton ID="lbnPrev" runat="server" onclick="lbnPrev_Click"> <asp:Label ID="lblPreviousPage" runat="server" Text="<%$ Resources:Language, lblPreviousPage%>"></asp:Label>
    </asp:LinkButton>&nbsp;
    <asp:LinkButton ID="lbnNext" runat="server" onclick="lbnNext_Click"><asp:Label ID="lblNextPage" runat="server" Text="<%$ Resources:Language, lblNextPage%>"></asp:Label>
    </asp:LinkButton>
</div>