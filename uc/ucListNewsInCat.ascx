<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListNewsInCat.ascx.cs"
    Inherits="uc_ListNews" %>
<style type="text/css">
    .bluelink
    {
        clear: both;
        float: left;
        margin-top: 10px;
        margin-bottom: 10px;
        width: 100%;
        font-size:12px;
    }
    .bluelink a
    {
        color: #006599;
        font-size: 12pt;
    }
    .anhtin
    {
        margin-right: 5px;
        text-align:center;
        max-width:500px;
        max-height: 480px;
        /*float: left;*/
    }
    .bluelink .divImg
    {
        width:740px;
        text-align:center;
        margin:auto;
        margin-top:5px;
        margin-bottom:5px;
    }
</style>
<div class="cattitle">
    <asp:Label ID="lblCatTitle" runat="server" />
</div>
<div class="danhsachtin">
    <asp:Repeater ID="rptrNewsInCat" runat="server" 
        onitemdatabound="rptrNewsInCat_ItemDataBound">
        <ItemTemplate>
            <div class="bluelink">
                <asp:HyperLink ID="lnkTitle" NavigateUrl='<%#"~/Content.aspx?newsID="+Eval("iNewsID") %>'
                    runat="server" Font-Bold="true">
                    <asp:Label ID="lblTitle" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),100) %>' runat="server" CssClass="left" />
                </asp:HyperLink>
                <br />
                <asp:Label ID="lblDate" CssClass="left" runat="server" Text='<%#getsTentacgia((int) Eval("iUserID")) + Eval("tDate","{0:dd/MM/yyyy}") %>' /><br />
                <div class="divImg">
                    <asp:HyperLink ID="lnkImage" runat="server" NavigateUrl='<%#"~/Content.aspx?newsID="+Eval("iNewsID") %>'>
                        <asp:Image ID="imgMinhhoa" runat="server" ImageUrl="~/upload/nophoto.jpg" BorderWidth="1" BorderColor="Silver" CssClass="anhtin" />
                    </asp:HyperLink>
                </div>
                <br />
                <asp:Label ID="lblDesc" CssClass="left" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sDesc").ToString(),150) %>' runat="server" />
            </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr style="float: left; width: 100%; border: dashed 1px silver" />
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="lnkPrev" runat="server" Text="<%$ Resources:Language, lblPreviousPage%>" />&nbsp;
    <asp:HyperLink ID="lnkNext" runat="server" Text="<%$ Resources:Language, lblNextPage%>" />
</div>
