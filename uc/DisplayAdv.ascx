<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DisplayAdv.ascx.cs" Inherits="uc_DisplayAdv" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<div style="margin-top:10px;margin-bottom:10px">
<asp:DataList ID="dlstQuangcao" runat="server" RepeatLayout="Flow"
    onitemdatabound="dlstQuangcao_ItemDataBound" ItemStyle-CssClass="quangcao_item">
    <ItemTemplate>
        <asp:HyperLink ID="lnkQuangcao" runat="server">
            <asp:Literal ID="ltr1" runat="server" Mode="PassThrough"></asp:Literal>
        </asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
</div>