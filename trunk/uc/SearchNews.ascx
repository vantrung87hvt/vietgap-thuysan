<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchNews.ascx.cs" Inherits="uc_SearchNews" %>
<div class="dvSearch">
    <div class="textSearch">
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    </div>
    <asp:ImageButton ID="btnSearch"
    runat="server" ImageUrl="~/images/imgSearch.jpg" CssClass="right" style="margin-right:2px;" onclick="btnSearch_Click" />
</div>