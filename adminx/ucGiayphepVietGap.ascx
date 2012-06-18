<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucGiayphepVietGap.ascx.cs"
    Inherits="adminx_ucGiayphepVietGap" %>
<div>
    <table border="1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Thủ trưởng cơ quan chứng nhận:
                <asp:TextBox ID="txtTenThuTruong" runat="server" Width="172px"></asp:TextBox>
                <asp:Button ID="btnXem" runat="server" Text="Xem" onclick="btnXem_Click" />
                <asp:Button ID="btnExportToWord" runat="server" Text="Xuất ra Word" OnClick="ExportToWord"
                    Enabled="false" />
                <br />
                <asp:RequiredFieldValidator ID="rqTenTT" runat="server" ValidationGroup="er" ControlToValidate="txtTenThuTruong"
                    ErrorMessage="Bạn phải nhập tên thủ trưởng"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="chung_nhan">
                    <table>
                        <tr>
                            <td>
                                <div class="logo" style="margin-left: 120px;">
                                    <asp:Image ID="imgTochuc" runat="server" Height="16px" />
                                </div>
                            </td>
                            <td style="width: 370px;">
                                <div class="in_hoa s14 bold" style="text-decoration: underline;">
                                    <asp:Label ID="lblCoQuanCapTren" runat="server" Text=""></asp:Label>
                                    </div>
                                <div class="in_hoa s14 bold">
                                    <asp:Label ID="lblTencoquan" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td>
                                    
                            </td>
                        </tr>
                    </table>
                    <div class="clear">
                        &nbsp;</div>
                    <div class="s12 left_1">
                        Số (VGN): <b>
                            <asp:Label ID="lblMaso" runat="server" Text=""></asp:Label>
                        </b>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                    <div class="in_hoa s14 bold">
                        Chứng nhận</div>
                    <div class="thong_tin bold tieu_de_nho s12" style="line-height: 32px;">
                        <ul>
                            <li>Cơ sở nuôi: <span class="medium">
                                <asp:Label ID="lblCosonuoi" runat="server" Text=""></asp:Label>
                            </span></li>
                            <li>Địa chỉ: <span class="medium">
                                <asp:Label ID="lblDiachi" runat="server" Text=""></asp:Label>
                            </span></li>
                            <li>Mã số cơ sở: <span class="medium">
                                <asp:Label ID="lblMasocoso" runat="server" Text=""></asp:Label>
                            </span></li>
                            <li>Diện tích: <span class="medium">
                                <asp:Label ID="lblDientich" runat="server" Text=""></asp:Label>
                            </span></li>
                            <li>Đối tượng, hình thức nuôi: <span class="medium">
                                <asp:Label ID="lblDoituong" runat="server" Text=""></asp:Label>
                            </span></li>
                            <li>Sản lượng dự kiến (kg): <span class="medium">
                                <asp:Label ID="lblSanluongdukien" runat="server" Text=""></asp:Label>
                            </span></li>
                        </ul>
                    </div>
                    <div class="in_hoa s14 bold">
                        Chứng nhận sản phẩm được sản xuất/sơ chế phù hợp Quy phạm thực hành sản xuất nông nghiệp tốt theo Quyết  định số, ngày/tháng/năm ban hành, ký hiệu
                    </div>
                    <div class="chu_ky">
                        <span class="s11 in_nghieng">
                            <asp:Label ID="lblNgaycap" runat="server" Text=""></asp:Label>
                        </span>
                        <br />
                        <span class="in_hoa s14 bold">ĐẠI DIỆN TỔ CHỨC CHỨNG NHẬN</span><br />
                        <span class="s11 in_nghieng">(Ký tên và đóng dấu)</span>
                    </div>
                    <div class="tieu_de_nho s12 bold left_1" style="margin-top: 50px;">
                        Giấy chứng nhận có giá trị đến ngày:
                        <asp:Label ID="lblNgayhethan" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="tieu_de_nho s12 bold left_1">
                        Và được gia hạn ở mặt sau căn cứ vào kết quả kiểm tra và giám sát</div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <center>
                    <div class="in_hoa s14 bold">
                        gia hạn hiệu lực
                    </div>
                </center>
                <table width="820px">
                    <tr>
                        <td>
                            <asp:Repeater ID="rptGiaHan" runat="server" 
                                onitemdatabound="rptGiaHan_ItemDataBound">
                                <ItemTemplate>
                                    <ul class="khunggiahan">
                                        <asp:Label ID="lblID" Text='<%#Eval("PK_iMasoVietGapID")%>' Visible="false" runat="server" />
                                        <li>Ngày gia hạn: <span class="medium">
                                            <asp:Label ID="lblNgayGiaHan" runat="server" Text=""></asp:Label>
                                        </span></li>
                                        <li>Sản lượng dự kiến: <span class="medium">
                                            <asp:Label ID="lblSanLuongDuKien" runat="server" Text=""></asp:Label>
                                        </span></li>
                                        <li>Diện tích: <span class="medium">
                                            <asp:Label ID="lblDienTich" runat="server" Text=""></asp:Label>
                                        </span></li>
                                        <li>Gia hạn đến: <span class="medium">
                                            <asp:Label ID="lblGiaHanDen" runat="server" Text=""></asp:Label>
                                        </span></li>
                                        <li style="text-align:center;margin-top:120px; font-weight:bold;">
                                            <asp:Label ID="lblThuTruong" runat="server" Text=""></asp:Label>
                                        </li>
                                    </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
