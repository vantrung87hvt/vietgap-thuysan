<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PollKetqua.ascx.cs" Inherits="INVI.INVIWeb.Module.PollKetqua" %>

<asp:Panel ID="pnlContainer" runat="server" Width="500px">
    <span>Câu hỏi: </span><asp:Label ID="lblCauhoithamdo" runat="server"></asp:Label>
    <br />
    <br />
    <div>
        <asp:Label ID="lblTongsoluotbinhchon" runat="server"></asp:Label>
    </div>
    <br />    
    <asp:Repeater ID="rptrKetquabinhchon" runat="server" OnItemDataBound="rptrKetquabinhchon_ItemDataBound">
        <HeaderTemplate>
            <table border="1px" cellspacing="0px" width="99%">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="width: 30%" align="left">
                    <asp:Label ID="lblSoluotbinhchon" runat="server" Text='<%# Eval("sAnswer") %>' />
                </td>

                <td>
                    <div><asp:Label ID="lblPhantrambinhchon" runat="server"></asp:Label></div>
                    <asp:Panel ID="pnlThanhphanBieudo" runat="server">
                    </asp:Panel>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Panel>