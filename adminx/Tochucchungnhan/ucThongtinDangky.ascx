<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucThongtinDangky.ascx.cs" Inherits="adminx_Tochucchungnhan_ucThongtinDangky" %>
    <table class="full-wide">
        <tr>
            <th align="center">1. Giấy tờ nộp kèm hồ sơ</th>
        </tr>
        <tr>
            <td>
                <asp:Repeater runat="server" ID="rptGiaytonopkem">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <li><%#Eval("sTengiayto")%></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <th>2. Bảng kết quả đánh giá nội bộ</th>
        </tr>
        <tr>
            <td>
                <table class="full-wide">
                    <tr>
                        <td>
                            Số tiêu chuẩn đạt yêu cầu theo VietGAP - Mức độ A: <asp:Label ID="lblDatyeucauA" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucauA" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Số tiêu chuẩn đạt yêu cầu theo VietGAP - Mức độ B: <asp:Label ID="lblDatyeucauB" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucauB" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tổng số tiêu chuẩn đạt yêu cầu theo VietGAP: <asp:Label ID="lblDatyeucau" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucau" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tổng số tiêu chuẩn chưa đạt yêu cầu theo VietGAP: <asp:Label ID="lblChuadatyeucau" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            Tỷ lệ %: <asp:Label ID="lblPhantramchuadatyeucau" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>