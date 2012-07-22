<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListVideoInCat.ascx.cs"
    Inherits="uc_ucListVideoInCat" %>
<script src="../Plugin/flowplayer/flowplayer-3.2.10.min.js" type="text/javascript"></script>
<style type="text/css">
    div.img
    {
        margin: 2px;
        height: auto;
        width: auto;
        float: left;
        text-align: center;
    }
    div.img img
    {
        display: inline;
        margin: 3px;
    }
    div.img a:hover img
    {
        border: 1px solid #0000ff;
    }
    div.desc
    {
        text-align: center;
        font-weight: normal;
        width: 120px;
        margin: 2px;
    }
     .dvFooter
    {
         font-size: 12px;
        background: #fff;
        margin-left:30px;
        margin-top: 5px;
        width: 90%;
        border-collapse: collapse;
        text-align: right;
    }
</style>
<div>
    <asp:Repeater ID="rptVideoClips" runat="server">
        <ItemTemplate>
            <div class="img">
                <%--                <asp:HyperLink ID="hypVideoLink" runat="server" NavigateUrl='<%#"~/Content.aspx?VideoID="+Eval("PK_iVideoID") %>'>
                <asp:Image ID="imMinhhoa" runat="server" />
                <img src='<%#Eval("sAnhminhhoa")%>' alt="Ảnh minh họa" width="110" height="90" />
                <img src="" alt="Video" width="110" height="90" />
                <%#Eval("sTieude")%>

                </asp:HyperLink>
                --%>
                <div id="divVideo">
                    <a href='<%#ResolveUrl("~/upload/videos/")+Eval("sTentep").ToString()%>' style="display: block;
                        width: 110px; height: 90px;" id="player<%#Eval("PK_iVideoID")%>"></a>
                    <script type="text/javascript">
                        flowplayer('player<%#Eval("PK_iVideoID")%>', '<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.11.swf") %>', {
                            clip: {
                                autoPlay: false,
                                autoBuffering: true
                        }
                    });
                    </script>
                </div>
                <div class="desc">
                    <%--<asp:Label ID="lblMota" runat="server" Text='<%#Eval("sTieude")%>'></asp:Label>--%>
                    <asp:HyperLink ID="hypVideoLink" runat="server" NavigateUrl='<%#"~/Content.aspx?VideoID="+Eval("PK_iVideoID") %>'><%#Eval("sTieude")%></asp:HyperLink>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="dvFooter">
        <asp:LinkButton ID="lbnPrev" runat="server" onclick="lbnPrev_Click"> <asp:Label ID="lblPreviousPage" runat="server" Text="<%$ Resources:Language, lblPreviousPage%>"></asp:Label>
        </asp:LinkButton>&nbsp;
        <asp:LinkButton ID="lbnNext" runat="server" onclick="lbnNext_Click"><asp:Label ID="lblNextPage" runat="server" Text="<%$ Resources:Language, lblNextPage%>"></asp:Label>
        </asp:LinkButton>
    </div>