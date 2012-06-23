<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucGiayphepVietGap.ascx.cs"
    Inherits="adminx_ucGiayphepVietGap" %>
<style type="text/css">
	div.chungnhan{
		width:820px;
		height:560px;
		font-family:"Times New Roman", Times, serif;
		padding-top:20px;
		padding-left:100px;
		padding-right:50px;
	}
	.chungnhan .normal-text{
		font-weight:normal;
	}
	.chungnhan{
		font-size:19px;
		font-weight:bold;
	}
	.chungnhan td.center{
		text-align:center;
	}
	.chungnhan img.logo{
		max-height:80px;
	}
	.head-1{
		height:100px;
		vertical-align:top;
	}
	.head-2
	{
	    padding-bottom:10px;
	}
	.upercase
	{
	    text-transform:uppercase;
	}
</style>
<div>
    <table border="1">
        <tr>
            <td colspan="2">
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
                <div class="chungnhan">
                    <table class="chungnhan">
                        <tr>
                            <td width="50%" rowspan="2" class="center">
                                <asp:Image ID="imgTochuc" CssClass="logo" runat="server" />
                            </td>
                            <td width="50%" class="center head-1">
                                <span>GIẤY CHỨNG NHẬN VietGAP</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="center head-2">
                                <span class="upercase"><asp:Label ID="lblTencoquan" runat="server" Text=""></asp:Label></span><br />
                                <span class="normal-text">Mã số (chỉ định):
                                <asp:Label ID="lblMasochidinh" runat="server" Text=""></asp:Label></span><br />
                                CHỨNG NHẬN
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Cơ sở nuôi/Nhà sản xuất/sơ chế:
                                <span class="normal-text">
                                    <asp:Label ID="lblCosonuoi" runat="server" Text=""></asp:Label>
                                </span><br />
                                Địa chỉ:
                                <span class="normal-text">
                                    <asp:Label ID="lblDiachi" runat="server" Text=""></asp:Label>
                                </span>&nbsp;&nbsp;&nbsp;
                                Điện thoại:
                                <span class="normal-text">
                                    <asp:Label ID="lblDienthoai" runat="server" Text=""></asp:Label>
                                </span>&nbsp;&nbsp;&nbsp;
                                Email/Website:
                                <span class="normal-text">
                                    <asp:Label ID="lblEmailWebsite" runat="server" Text=""></asp:Label>
                                </span>&nbsp;&nbsp;&nbsp;<br />
                                Địa điểm suản xuất/sơ chế:
                                <span class="normal-text">
                                    <asp:Label ID="lblDiadiemsanxuat" runat="server" Text=""></asp:Label>
                                </span><br />
                                Mã số chứng nhận VietGAP:
                                <span class="normal-text">
                                    <asp:Label ID="lblMaso" runat="server" Text=""></asp:Label>
                                </span><br />
                                Tên sản phẩm hoặc nhóm sản phẩm:
                                <span class="normal-text">
                                    <asp:Label ID="lblDoituong" runat="server" Text=""></asp:Label>
                                </span><br />
                                Diện tích nuôi/Quy mô sản xuất/Diện tích sản xuất/sơ chế:
                                <span class="normal-text">
                                    <asp:Label ID="lblDientich" runat="server" Text="">&nbsp;m</asp:Label>
                                </span><br />
                                Sản lượng dự kiến:
                                <span class="normal-text">
                                    <asp:Label ID="lblSanluongdukien" runat="server" Text=""></asp:Label>
                                </span><br />
                                <span class="normal-text">
                                    Chứng nhận sản phẩm được sản xuất/sơ chế phù hợp Quy phạm thực hành sản xuất nông nghiệp tốt theo Quyết định số ..., __/__/_____, ký hiệu ....
                                </span><br />
                                Giấy chứng nhận có giá trị đến ngày:
                                <span class="normal-text">
                                    <asp:Label ID="lblNgayhethan" runat="server" Text=""></asp:Label>
                                </span><br />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="center">
                                <span class="normal-text"><i>
                                    ................ngày,.......tháng.........năm................
                                </i></span><br />
                                ĐẠI DIỆN TỔ CHỨC CHỨNG NHẬN<br />
                                <span class="normal-text">
                                    <i>(ký tên và đóng dấu)</i>
                                </span>
                            </td>
                        </tr>
                    </table>
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
