<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListNewsInHome.ascx.cs" Inherits="uc_ListNewsInHome" %>
<asp:Repeater ID="rptrNewsInHome" runat="server" onitemdatabound="rptrNewsInHome_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink ID="lnkTitle" Text='<%#Eval("sTitle") %>' NavigateUrl='<%#"~/Category.aspx?newsID="+Eval("iNewsID") %>'
                runat="server" />
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>

    
    
