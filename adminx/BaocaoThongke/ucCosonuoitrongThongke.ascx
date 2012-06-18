<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCosonuoitrongThongke.ascx.cs"
    Inherits="adminx_BaocaoThongke_ucCosonuoitrongThongke" %>
<%@ Register Assembly="skmControls2" Namespace="skmControls2.GoogleChart" TagPrefix="cc2" %>
<table id="hor-minimalist-b">
    <tr>
        <td>
            Tỉnh:<asp:DropDownList ID="ddlTinh" runat="server">
            </asp:DropDownList>
            Đối tượng nuôi:
            <asp:DropDownList ID="ddlDoituongnuoi" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnXem" runat="server" Text="Xem" OnClick="btnXem_Click" />
            &nbsp;
            <asp:Button ID="btnXuatraExcel" runat="server" Text="Xuất ra Excel" OnClick="btnXuatraExcel_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table border="1" width="100%" id="hor-minimalist-b">
                <asp:Repeater ID="rptCosonuoitrongThongke" runat="server" 
                    OnItemCreated="rptCosonuoitrongThongke_ItemCreated" 
                    onitemdatabound="rptCosonuoitrongThongke_ItemDataBound">
                    <HeaderTemplate>
                        <tr>
                            <td colspan="7" width="100%">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            Tổng cục Thủy sản<br />
                                            Vụ Nuôi trồng Thủy sản
                                        </td>
                                        <td width="40%">
                                        </td>
                                        <td align="center">
                                            Cộng Hòa Xã Hội Chủ nghĩa Việt Nam<br />
                                            Độc lập - Tự do - Hạnh phúc
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" align="center">
                                <asp:Literal ID="ltrHeader" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                STT
                            </th>
                            <th>
                                Huyện
                            </th>
                            <th>
                                Số hộ
                            </th>
                            <th>
                                Tổng diện tích
                            </th>
                            <th>
                                Tổng DT mặt nước
                            </th>
                            <th>
                                Tổng DT Ao lắng
                            </th>
                            <th>
                                Tổng sản lượng dự kiến
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#rptCosonuoitrongThongke.Items.Count + 1%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "sTenHuyen")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "iSoho")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "fTongdientich","{0:F0}")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "fTongdientichmatnuoc", "{0:F0}")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "fDientichAolang", "{0:F0}")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "iTongsanluongdukien","{0:N0}")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td colspan="7">
                                <table>
                                    <tr>
                                        <td>
                                            <cc2:Chart ID="chartCosonuoiSoho" runat="server" Width="450px" Height="250px">
                                            </cc2:Chart>
                                            <cc2:Chart ID="chartCosonuoiDientich" runat="server" Width="450px" Height="250px">
                                            </cc2:Chart>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <cc2:Chart ID="chartSanluong" runat="server" Width="450px" Height="250px">
                                            </cc2:Chart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
</table>
