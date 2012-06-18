<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucBaocaodanhgianoibo.ascx.cs" Inherits="adminx_ucBaocaodanhgianoibo" %>
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
            	    <p class="bold inhoa">BÁO CÁO ĐÁNH GIÁ NỘI BỘ</p>
                </div>
                <div class="content">
            	    <p class="bold">Kính gửi: ……………………………………………………………………………………….</p>
                    <span class="bold">I. Thông tin chung</span>
                    <ul class="s13">
                	    <li>Tên cơ sở nuôi: 
                            <asp:label runat="server" text="" id="lblTencoso" ></asp:label>
                        </li>
                        <li>Địa chỉ cơ sở nuôi: <asp:label runat="server" text="" id="lblDiachiCoso" ></asp:label></li>
                        <li>
                            Số điện thoại: <asp:label runat="server" text="" id="lblSodienthoai" ></asp:label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fax: 
                        </li>
                        <li>Người đại diện: <asp:label runat="server" text="" id="lblNguoidaidien" ></asp:label></li>
                        <li>Số lượng thành viên (nếu cơ sở do một tổ chức làm chủ): <asp:label runat="server" text="" id="lblSoluongthanhvien" ></asp:label></li>
                    </ul>
                    <p class="bold">
                	    Sau khi tiến hành đánh giá nội bộ, Cơ sở nuôi chúng tôi xin gửi tới Quý cơ quan kết quả <br />kết quả đánh giá (Bảng 1).<br /><br />
                        Kính đề nghị quý cơ quan tổ chức đánh giá và cấp chứng nhận VietGAP.
                    </p>
                </div>
                <div class="foot">
            	    <div class="innghieng f_right">
                	    Ngày … tháng … năm …<br /><br />
                    </div>
            	    <div class="foot_left">
                	    <span class="bold">Người đánh giá</span><br />
                        <span class="innghieng">(Ký, ghi rõ họ tên)</span>
                    </div>
                    <div class="foot_right">
                	    <span class="bold">Đại diện chủ cơ sở nuôi</span><br />
                        <span class="innghieng">(Ký, ghi rõ họ tên)</span>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>