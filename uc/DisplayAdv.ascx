<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DisplayAdv.ascx.cs" Inherits="uc_DisplayAdv" %>
<style>
.quangcao_item
{
    float:left;
    margin-top:10px;
}

</style>
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