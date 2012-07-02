<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucGiaydangkyhoatdongchungnhan.ascx.cs" Inherits="adminx_ucBaocaodanhgianoibo" %>
<link href='<%=ResolveUrl("~/adminx/css/report.css") %>' rel="stylesheet" type="text/css" />
<%--liemqv--%>
<table>
    <tr>
        <td style="border:1px;">
            <asp:button runat="server" text="Xuất ra Word" id="btnExToWord" onclick="btnExToWord_Click" />
        </td>
    </tr>
    <tr>
        <td style="border:1px;">
            <div id="baocao_noibo">
        	    <div class="bc_head">
                    <p class="bold">
                        CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM<br />
                        Độc lập - Tự do - Hạnh phúc<br />
                        -------
                    </p>
                    <div class="innghieng" style="text-align:right">
                	    Ngày … tháng … năm 20…<br /><br />
                    </div>
                    <p class="inhoa bold">
                        ĐƠN ĐĂNG KÝ
                    </p>
                    <p class="inhoa">
                        HOẠT ĐỘNG CHỨNG NHẬN VIETGAP
                    </p>
                    <span class="bold">Kính gửi: </span>Cơ quan công nhận Tổ chức Chứng nhận
                </div>
                <div class="content">
                    <p>- Tên tổ chức: 
                        <asp:Label ID="lblTentochuc" runat="server" Text=""></asp:Label>
                    </p>
                    <p>- Địa chỉ liên lạc: 
                        <asp:Label ID="lblDiachi" runat="server" Text=""></asp:Label>
                    </p>
                    <p>- Điện thoại: 
                        <asp:Label ID="lblDienthoai" runat="server" Text=""></asp:Label>
                        ...... Fax: 
                        <asp:Label ID="lblFax" runat="server" Text=""></asp:Label>
                        ...... E-mail: 
                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </p>
                    <p>- Quyết định thành lập (nếu có) hoặc Giấy đăng ký kinh doanh số: 
                        <asp:Label ID="lblSodangky" runat="server" Text=""></asp:Label>
                        .. do Cơ quan câp: 
                        <asp:Label ID="lblCoquancap" runat="server" Text=""></asp:Label>
                        .... cấp ngày ...
                        <asp:Label ID="lblNgaycap" runat="server" Text=""></asp:Label>
                        .... tại ...
                        <asp:Label ID="lblNoicap" runat="server" Text=""></asp:Label>
                    </p>
                    <p>
                        Sau khi nghiên cứu các điều kiện hoạt động chứng nhận VietGAP theo Thông tư<br />
                        số     /2011/TT-BNNPTNT ngày    tháng     năm 2011 của Bộ trưởng Bộ Nông nghiệp và Phát triển nông thôn ban hành Thông tư chứng nhận thực hành Nuôi trồng thuỷ sản tốt (VietGAP) chúng tôi nhận thấy có đủ các điều kiện để hoạt động chứng nhận VietGAP cho...
                        <asp:Label ID="lblTentochuclamdon" runat="server" Text=""></asp:Label>
                    </p>
                    <p>
                        Hồ sơ kèm theo:<br />
                        <asp:Label ID="lblHosokemtheo" runat="server" Text=""></asp:Label>
                    </p>
                    Đề nghị <span class="bold innghieng">Cơ quan công nhận</span> Tổ chức Chứng nhận xem xét để công nhận <i>(<asp:Label ID="lblTentochucinnghieng" runat="server" Text=""></asp:Label>)</i> được hoạt động chứng nhận VietGAP cho :
                    <ul class="s13" style="list-style-type:none;">
                	    <li>-	Đăng ký công nhận lần đầu:
                        </li>
                        <li>-	Đăng ký công nhận lại:
                        </li>
                        <li>-	Đăng ký mở rộng hoạt động chứng nhận:
                        </li>
                    </ul>
                    <p>
                	    Chúng tôi xin cam kết thực hiện đúng các quy định về hoạt động chứng nhận VietGAP./.
                    </p>
                </div>
                <div class="foot">
            	    <div class="foot_left">
                	    
                    </div>
                    <div class="foot_right">
                	    <span class="bold">Đại diện tổ chức ...</span><br />
                        <span class="innghieng">(Ký tên, đóng dấu)</span>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>