<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Poll.ascx.cs" Inherits="INVI.INVINews.Module.Poll" %>
<asp:Repeater ID="rptrPoll" runat="server" 
    onitemdatabound="rptrPoll_ItemDataBound">
    <ItemTemplate>
        <div id="divChinh" style="text-align: center; width: 220px; margin-bottom: 10px">
            <asp:Label ID="lblThongbao" runat="server" ForeColor="red" />
            <table width="100%" style="margin: 0px auto; border: solid 1px #70a9b3;" cellspacing="-1px">
                <tr>
                    <td id="tdTieude" runat="server" style="background-color: #bce1e8; text-align: center;">
                        <asp:Label ID="lblThamDoYKienL" runat="server" Text="<%$ Resources:Language, lblThamDoYKienL%>"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="tdThamdo" runat="server" style="text-align: left; font-weight: bold; padding-left: 5px;">
                        <asp:Label ID="lblCauhoi" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td id="tdPhuongan" runat="server" style="text-align: left; padding-left: 5px;">
                        <asp:RadioButtonList ID="optlPhuongan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnBophieu" CommandArgument='<%#Eval("iPollID")%>'  runat="server" Text="<%$ Resources:Language, lblBoPhieu%>" OnClick="btnBophieu_Click" />
                        <input id="Button1" type="button" value="Kết quả" onclick="window.open('PollKetqua.aspx?pollID=<%#Eval("iPollID")%>','Ketqua','width=600,height=400,toolbar=0,menubar=0,status=0')" />
                    </td>
                </tr>
            </table>
        </div>
    </ItemTemplate>
</asp:Repeater>
