<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMostFAQ.ascx.cs" Inherits="uc_ucMostFAQ" %>

<div class="panel_item">
    <asp:Repeater ID="rptrMostFAQ" runat="server">
    <HeaderTemplate>
    <ol class="nice-list">    
        </HeaderTemplate>
    <ItemTemplate>
        <li>
        <asp:HyperLink  ID="lnkTitle" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),60) %>' NavigateUrl='<%#"~/Content.aspx?faqID="+Eval("PK_iFaqID") %>' runat="server"/>
        </li>  
    </ItemTemplate>
    <FooterTemplate>
    </ol>
    </FooterTemplate>
</asp:Repeater>
</div>