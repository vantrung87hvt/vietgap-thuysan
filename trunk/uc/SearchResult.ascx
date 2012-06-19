<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchResult.ascx.cs" Inherits="uc_SearchResult" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<div class="danhsachtin">
    <asp:Label ID="lblMessage" runat="server" />
    <asp:Repeater ID="rptrNews" runat="server" onitemdatabound="rptrNews_ItemDataBound">
        <ItemTemplate>
            <div class="bluelink">
                <asp:HyperLink ID="lnkImage" runat="server" NavigateUrl='<%#"~/Category.aspx?newsID="+Eval("iNewsID") %>'>
                <asp:Image ID="imgMinhhoa" runat="server" ImageUrl="~/upload/nophoto.jpg" BorderWidth="1"
                        BorderColor="Silver" CssClass="anhtin" />
                </asp:HyperLink>
                <asp:HyperLink ID="lnkTitle" NavigateUrl='<%#"~/Category.aspx?newsID="+Eval("iNewsID") %>'
                    runat="server" Font-Bold="true">
                    <asp:Label ID="lblTitle" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),70) %>' Width="300px" runat="server" CssClass="left" />
                </asp:HyperLink>
                <br />
                <asp:Label ID="lblDate" CssClass="left" Width="300px" runat="server" Text='<%#Eval("tDate","{0:dd/MM/yyyy}") %>' />
                <br />
                <asp:Label ID="lblDesc" CssClass="left" Width="300px" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sDesc").ToString(),150) %>' runat="server" />
            </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr style="float: left; width: 100%; border: dashed 1px silver" />
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="lnkPrev" runat="server" Text="<%$ Resources:Language, lblPreviousPage%>"  />&nbsp;
    <asp:HyperLink ID="lnkNext" runat="server" Text="<%$ Resources:Language, lblNextPage%>" />
</div>