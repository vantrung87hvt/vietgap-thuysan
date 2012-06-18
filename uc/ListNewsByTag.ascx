<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListNewsByTag.ascx.cs"
    Inherits="uc_ListNewsByTag" %>
<div class="panel_item">
    <asp:Repeater ID="rptrNewsByTag" runat="server">
        <HeaderTemplate>
        <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="lnkTitle" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),60) %>' NavigateUrl='<%#"~/Category.aspx?newsID="+Eval("iNewsID") %>'
                    runat="server" />
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
