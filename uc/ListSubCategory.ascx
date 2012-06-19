<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListSubCategory.ascx.cs" Inherits="uc_ListSubCategory" %>
<asp:Repeater ID="rptrSubCategory" runat="server">
    <ItemTemplate>
        <asp:HyperLink ID="lnkCategory" runat="server" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),70) %>' NavigateUrl='<%#"~/Category.aspx?catID="+Eval("iCategoryID") %>' />
    </ItemTemplate>
</asp:Repeater>
