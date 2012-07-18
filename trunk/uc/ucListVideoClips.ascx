<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListVideoClips.ascx.cs"
    Inherits="uc_ucListVideoClips" %>
<%@ Register Assembly="ASPNetVideo.NET2" Namespace="ASPNetVideo" TagPrefix="ASPNetVideo" %>
<table>
    <tr>
        <td>
            <asp:HyperLink ID="hypVideoLink" runat="server" NavigateUrl="~/Content.aspx?mode=uc&page=ListVideoInCat">Video
            </asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <ASPNetVideo:WindowsMedia ID="WindowsMedia1" runat="server" Height="145px" Width="180px"
                AutoPlay="false" UIMode="None" ShowContextMenu="False">
            </ASPNetVideo:WindowsMedia>
        </td>
    </tr>
    </table>
<div>
    <asp:Repeater ID="rptVideoClips" runat="server">
        <ItemTemplate>
                <asp:HyperLink ID="hypVideoLink" runat="server" NavigateUrl='<%#"~/Content.aspx?VideoID="+Eval("PK_iVideoID") %>'><%#Eval("sTieude")%>
                </asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>
</div>
