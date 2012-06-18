<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListNewsByCatID.ascx.cs"
    Inherits="uc_ListNewsByCatID" %>
<div class="panel_item">
    <asp:Repeater ID="rptrNewsByCatID" runat="server">
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
