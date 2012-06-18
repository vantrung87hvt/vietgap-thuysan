<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDangKyChungNhan.ascx.cs"
    Inherits="UserMethods_ucDangKyChungNhan" %>
<style type="text/css">
    fieldset
    {
        -moz-border-radius: 7px;
        border: 1px #dddddd solid;
        margin-bottom: 20px;
        width: 730px;
    }
    
    fieldset legend
    {
        border: 1px #1a6f93 solid;
        color: black;
        font-weight: bold;
        font-family: Verdana;
        font-weight: none;
        font-size: 13px;
        padding-right: 5px;
        padding-left: 5px;
        padding-top: 2px;
        padding-bottom: 2px;
        -moz-border-radius: 3px;
    }
    
    /* Main DIV */
    .m
    {
        width: 750px;
        padding: 20px;
        height: auto;
    }
    
    /* Left DIV */
    .l
    {
        width: 140px;
        margin: 0px;
        padding: 0px;
        float: left;
        text-align: right;
    }
    
    
    /* Right DIV */
    .r
    {
        width: 600px;
        margin: 0px;
        padding: 0px;
        padding-left: 20px;
        float: left;
        text-align: left;
    }
    input
    {
        width:50px;    
        
        margin-top:5px;
    }
    label
    {
        margin-top:0;   
        float:left; 
    }
    .rr
    {
        width: 30px;
        margin: 0px;
        padding: 0px;
        float: left;
        text-align: center;
    }
    .a
    {
        clear: both;
        width: 700px;
        padding: 10px;
    }
    
    
    
    #button
    {
        text-align: center;
        margin: 100px;
    }
    .center
    {
        text-align: center;
    }
    .khung
    {
        width: 100%;
        padding-top: 20px;
    }
    .bold
    {
        font-weight: bold;
    }
    .nomal
    {
        font-weight: normal;
    }
    .w30
    {
        width: 30%;
    }
    table {
	font: 11px/24px Verdana, Arial, Helvetica, sans-serif;
	border-collapse: collapse;
	border:1px solid #CCC;
	width:100%;
	
	}

th {
	padding: 0 0.5em;
	text-align: left;
	}

tr.yellow td {
	border-top: 1px solid #FB7A31;
	border-bottom: 1px solid #FB7A31;
	background: #FFC;
	}

td {
	border-bottom: 1px solid #CCC;
	padding: 0 0.5em;
	}

td:first-child {
	width: 190px;
	}
    .checkboxes
    {
        width:100%;
        }
td+td {
	border-left: 1px solid #CCC;
	text-align: center;
	}
	.checkboxes label
{
    display: block;
    float: left;
    padding-right: 10px;
    
    width:630px;
    height:auto;
    
}

.checkboxes input
{
    vertical-align: middle;
    
}

.checkboxes label span
{
    vertical-align: middle;
}
</style>
<%--<asp:Panel ID="pnDangKy" runat="server">
    <div class="m">
        <fieldset>
            <legend>Đăng ký cấp mã số Viet G.A.P </legend>
            <div class="a">
                <div class="l" style="width:200px;">
                    <asp:CheckBox ID="cbDangKyLanDau" runat="server" /><asp:Label ID="lblDangKyLanDau" runat="server" Text="Đăng ký lần đầu"></asp:Label>
                </div>
                <div class="r">
                    
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblGiayToKemTheo" runat="server" Text="Giấy tờ kèm theo"></asp:Label>
                </div>
                <div class="r">
                     <div class="checkboxes">
                    <asp:CheckBoxList ID="cblGiayToKemTheo" runat="server" Width="100%">
                    </asp:CheckBoxList>
                    </div>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    &nbsp;</div>
                <div class="r">
                    <asp:Button ID="btnDangKy" runat="server" OnClick="btnDangKy_Click" Text="Đăng ký"
                        ValidationGroup="register" CssClass="button" Width="90" />
                </div>
            </div>
            <div class="a">
            </div>
        </fieldset>
    </div>
</asp:Panel>--%>
<asp:Panel ID="pnDangKyThanhCong" runat="server">
    <div class="m">
        <fieldset>
            <legend>Đăng ký cấp mã số Viet G.A.P</legend>
            <div style="color:Red;width:100%; text-align:center;margin-top:10px;" >
                <asp:Label ID="lblLoi" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>
            <div class="khung">
                <div class="center">
                    <b>CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM<br />
                        Độc lập - Tự do - Hạnh phúc<br />
                        <br />
                        ĐƠN ĐĂNG KÝ CHỨNG NHẬN VietGAP
                        <br />
                        Kính gửi:<asp:DropDownList ID="ddlTochucchungnhan" runat="server">
                            </asp:DropDownList>
                        </b>(Tổ chức chứng nhận VietGAP)
                </div>
                <br />
                <table >
                    <tr>
                        <td class="w30">
                            1. Tên cơ sở nuôi :
                        </td>
                        <td>
                            <asp:Label ID="lblTenCoSo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="w30">
                            2. Địa chỉ cơ sở nuôi:
                        </td>
                        <td>
                            <asp:Label ID="lblDiaChi" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="w30">
                            3. Tên người đại diện:
                        </td>
                        <td>
                            <asp:Label ID="lblNguoiDaiDien" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="width: 50%; float: left;">
                                4. Số điện thoại:
                                <asp:Label ID="lblDienThoai" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="float: left;">
                                Fax (nếu có):<asp:Label ID="lblFax" runat="server" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Sau khi nghiên cứu Thông tư quy định trình tự, thủ tục Chứng nhận VietGAP TT-BNNTTNT
                            ban hành ngày / /2011của Bộ trưởng Bộ Nông nghiệp và Phát triển nông thôn, chúng
                            tôi xin đăng ký đánh giá Chứng nhận VietGAP cho:
                        </td>
                    </tr>
                    <tr>
                        <td class="w30">
                            5. Đối tượng nuôi:
                        </td>
                        <td>
                            <asp:Label ID="lblDoiTuongNuoi" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="w30">
                            6. Hình thức nuôi
                        </td>
                        <td>
                            <asp:Label ID="lblHinhThucNuoi" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            7. Đăng ký chứng nhận lần đầu
                            <asp:CheckBox ID="cbChungNhanLanDau" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Đăng ký chứng nhận lại/thay đổi
                            <asp:CheckBox ID="cbThayDoi" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="w30">
                            8. Diện tích :
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="width: 50%; float: left;">
                                - Tổng diện tích:
                                <asp:Label ID="lblTongDienTich" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="float: left;">
                                - Diện tích cần Chứng nhận:
                                <asp:Label ID="lblDienTichChungNhan" runat="server" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            9. Sản lượng dự kiến:
                            <asp:Label ID="lblSanLuongDuKien" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            10. Gửi kèm theo đơn hồ sơ sau:
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="border-top:0;">
                          <div class="checkboxes">
                            <asp:CheckBoxList ID="cblHoSoCSNTKemtheo" runat="server" Width="100%">
                            </asp:CheckBoxList>
                          </div>
                             <div style="margin-left: 400px;">
                                <div class="center">
                                    ……, ngày….. tháng…..năm……
                                    <br />
                                    Đại diện cơ sở nuôi<br />
                                    (ký tên và đóng dấu nếu có)<br />
                                </div>
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>Tổ chức chứng nhận:</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlTochucchungnhan" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                </table>
                <div class="a">
                <div class="l">
                    &nbsp;</div>
                <div class="r" style="text-align:center;">
                    
                    <asp:Button ID="btnDangKy" runat="server" OnClick="btnDangKy_Click" Text="Đăng ký"
                        ValidationGroup="register" CssClass="button" Width="90" />
                </div>
            </div>
            <div class="a"></div>
            </div>
        </fieldset>
    </div>
</asp:Panel>
