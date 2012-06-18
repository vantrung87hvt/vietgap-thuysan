<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListEventNews.ascx.cs" Inherits="uc_ListEventNews" %>
<div class="dvHotNews">
    <asp:Repeater ID="rptrEventNews" runat="server">
        <ItemTemplate>
             <span class="hotNews"><img src="images/3vuong.gif" style="position:relative;top:-2px" />
                <asp:HyperLink ID="lnkEventNews" runat="server" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),60) %>' NavigateUrl=<%#"~/Category.aspx?newsID="+Eval("iNewsID")%> />
             </span>
        </ItemTemplate>
    </asp:Repeater>
</div>