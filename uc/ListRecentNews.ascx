<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListRecentNews.ascx.cs" Inherits="uc_ListRecentNews" %>
<div class="panel_item">
    <asp:Repeater ID="rptrRecentNews" runat="server">
        <HeaderTemplate>
            <ul class="nice-list">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink  ID="lnkTitle" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),60) %>' NavigateUrl='<%#"~/Category.aspx?newsID="+Eval("iNewsID") %>' runat="server"/>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>