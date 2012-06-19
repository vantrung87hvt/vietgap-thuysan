<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Rate.ascx.cs" Inherits="INVI.INVINews.Module.Rate" %>
<div style="margin-bottom:10px">
    <asp:Label ID="lblThongkeBinhchon" runat="server" ForeColor="Blue"></asp:Label><asp:Image ID="imgStar" runat="server" Visible="False" />
    <br />
    <asp:Label ID="lblThongbao" runat="server" Text="<%$Resources:language,moibinhchon %>"></asp:Label><br/>
    <asp:RadioButtonList ID="rdlstBinhchon" runat="server" RepeatDirection="Horizontal"
        RepeatLayout="Flow">
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="btnBinhchon" runat="server" Text="<%$Resources:language,binhchon %>" OnClick="btnBinhchon_Click" />
</div>