<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListVideoInCat.ascx.cs"
    Inherits="uc_ucListVideoInCat" %>
<style type="text/css">
    div.img
    {
        margin: 2px;
        border: 1px solid #0000ff;
        height: auto;
        width: auto;
        float: left;
        text-align: center;
    }
    div.img img
    {
        display: inline;
        margin: 3px;
        border: 1px solid #ffffff;
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
</style>
<div>
    <asp:Repeater ID="rptVideoClips" runat="server">
        <ItemTemplate>
            <div class="img">
                <asp:HyperLink ID="hypVideoLink" runat="server" NavigateUrl='<%#"~/Content.aspx?VideoID="+Eval("PK_iVideoID") %>'>
                <%--<asp:Image ID="imMinhhoa" runat="server" />--%>
                <img src='<%#Eval("sAnhminhhoa")%>' alt="Klematis" width="110" height="90" />
                <%--<img src="" alt="Video" width="110" height="90" />--%>
                <%--<%#Eval("sTieude")%>--%>
                </asp:HyperLink>
                <div class="desc">
                    <asp:Label ID="lblMota" runat="server" Text=""></asp:Label>
                </div>
            </div>
            
        </ItemTemplate>
    </asp:Repeater>
</div>
