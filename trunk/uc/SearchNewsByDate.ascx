<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchNewsByDate.ascx.cs" Inherits="uc_SearchNewsByDate" %>
<asp:Label ID="lblNgayL" runat="server" Text="<%$ Resources:Language, lblNgayL%>"></asp:Label>
<asp:DropDownList ID="ddlDay" runat="server">
</asp:DropDownList>
<asp:Label ID="lblThangL" runat="server" Text="<%$ Resources:Language, lblThangL%>"></asp:Label>
<asp:DropDownList ID="ddlMonth" runat="server">
</asp:DropDownList>
<asp:Label ID="lblNamL" runat="server" Text="<%$ Resources:Language, lblNamL%>"></asp:Label>
<asp:DropDownList ID="ddlYear" runat="server">
</asp:DropDownList>
<asp:Button ID="btnSearchByDate" runat="server" onclick="btnSearchByDate_Click" 
    Text="<%$ Resources:Language, timkiem%>" />

