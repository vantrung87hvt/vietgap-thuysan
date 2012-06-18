<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTochuccapphepDanhgia_.ascx.cs" Inherits="adminx_ucTochuccapphepDanhgia" %>
    <link href="css/jquery-ui-1.8.12.custom.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui-1.8.12.custom.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        $(".datepicker").datepicker({
            closeText: 'Đóng',
	        prevText: '<Trước',
	        nextText: 'Sau>',
	        currentText: 'Đã chọn',
	        monthNames: ['Giêng','Hai','Ba','Tư','Năm','Sáu',
	        'Bảy','Tám','Chín','Mười','Mười một','Mười hai'],
	        monthNamesShort: ['Giêng', 'Hai', 'Ba', 'Tư', 'Năm', 'Sáu',
	        'Bảy', 'Tám', 'Chín', 'Mười', 'Mười một', 'Mười hai'],
	        dayNames: ['Thứ hai','Thứ ba','Thứ tư','Thứ năm','Thứ sáu','Thứ bảy','Chủ nhật'],
	        dayNamesShort: ['Hai', 'Ba', 'Tư', 'Năm', 'Sáu', 'Bảy', 'CN'],
	        dayNamesMin: ['Hai', 'Ba', 'Tư', 'Năm', 'Sáu', 'Bảy', 'CN'],
	        weekHeader: 'Tuần',
	        dateFormat: 'dd/mm/yy'
        });
        $(".timepicker").timepicker({
            hourGrid: 4,
            minuteGrid: 10,
            timeOnlyTitle: 'Chọn giờ',
            timeText: 'TG:',
            hourText: 'Giờ',
            minuteText: 'Phút',
            secondText: 'Giây',
            currentText: 'Giờ hiện tại',
            closeText: 'Đóng'
        });
        $.timepicker.setDefaults($.timepicker.regional['vi']);
    });

    
	</script>

<table width="100%">
  <tr>
    <td align="center"><strong style="font-size:18px;">BÁO CÁO ĐÁNH GIÁ TỔ CHỨC CHỨNG NHẬN</strong></td>
  </tr>
  <tr>
    <td><p><strong>1. Tổ chức chứng nhận được đánh giá</strong></p>
      <table width="100%" border="0.5">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
          <td width="10%">Tên tổ chức:</td>
          <td>
              <asp:label runat="server" text="" id="lblTentochuc"></asp:label>
          </td>
        </tr>
        <tr>
          <td>Địa chỉ:</td>
          <td><asp:label runat="server" text="" id="lblDiachi"></asp:label></td>
        </tr>
        <tr>
          <td>Điện thoại:</td>
          <td><asp:label runat="server" text="" id="lblSodienthoai"></asp:label></td>
        </tr>
        <tr>
          <td>Fax:</td>
          <td><asp:label runat="server" text="" id="lblFax"></asp:label></td>
        </tr>
        <tr>
          <td>E-mail:</td>
          <td><asp:label runat="server" text="" id="lblEmail"></asp:label></td>
        </tr>
      </table></td>
  </tr>
  <tr>
    <td><strong>2. Phạm vi về nghị chỉ định:</strong> 
        <asp:RequiredFieldValidator ID="rp1" runat="server" errormessage="Không được trống!" ValidationGroup="required"  ControlToValidate="txtPhamvideghi"></asp:RequiredFieldValidator>
        <br />
        <textarea id="txtPhamvideghi" cols="70" rows="4" runat="server"></textarea>
    </td>
  </tr>
  <tr>
    <td><strong>3. Đoàn đánh giá:</strong><br />
        <table>
            <tr>
                <td>
                    <asp:listbox runat="server" id="lstDoandanhgia" Height="100px" Width="300px"></asp:listbox>
                </td>
                <td valign="middle" align="center">
                    <asp:button runat="server" text=">" id="btnAdd" onclick="btnAdd_Click" /><br /><br />
                    <asp:button runat="server" text="&lt;" id="btnRemove" 
                        onclick="btnRemove_Click" />
                </td>
                <td>
                    <asp:listbox runat="server" id="lstDoandanhgiachon" Height="100px" Width="300px"></asp:listbox>
                </td>
            </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td><strong>4. Thời gian đánh giá:</strong>
    <asp:RequiredFieldValidator ID="rp2" runat="server" errormessage="Không được trống!" ValidationGroup="required"  ControlToValidate="txtNgaydg"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rp3" runat="server" errormessage="Không được trống!" ValidationGroup="required"  ControlToValidate="txtGiodg"></asp:RequiredFieldValidator>
    <%--<asp:RequiredFieldValidator runat="server" errormessage="*" ValidationGroup="required"  ControlToValidate="txtNgaydanhgia"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator runat="server" errormessage="*" ValidationGroup="required"  ControlToValidate="txtGiodanhgia"></asp:RequiredFieldValidator>--%>
    <br />
        Ngày: <asp:TextBox ID="txtNgaydg" runat="server" class="datepicker"></asp:TextBox>
        Giờ: <asp:TextBox ID="txtGiodg" runat="server" class="timepicker"></asp:TextBox>
        <%--Ngày: <input runat="server" type="text" id="txtNgaydanhgia" class="datepicker"><span>&nbsp;&nbsp;</span>Giờ: <input runat="server" type="text" id="txtGiodanhgia" class="timepicker">--%>
    </td>
  </tr>
  <tr>
    <td><p><strong>5. Các căn cứ để đánh giá:
        <asp:RequiredFieldValidator ID="rp4" runat="server" errormessage="Không được trống!" ValidationGroup="required"  ControlToValidate="txtCancudanhgia"></asp:RequiredFieldValidator></strong></p>
      <textarea id="txtCancudanhgia" cols="70" rows="4" runat="server"></textarea>
    </td>
  </tr>
  <tr>
    <td><p><strong>6. Nội dung đánh giá:
    <asp:RequiredFieldValidator ID="rp5" runat="server" errormessage="Không được trống!" ValidationGroup="required"  ControlToValidate="txtNoidungdanhgia"></asp:RequiredFieldValidator>
    </strong></p>
        <textarea id="txtNoidungdanhgia" cols="70" rows="4" runat="server"></textarea>
    </td>
  </tr>
  <tr>
    <td><p><strong>7. Kết quả đánh giá:
    <asp:RequiredFieldValidator ID="rp6" runat="server" errormessage="Không được trống!" ValidationGroup="required"  ControlToValidate="txtKetquadanhgia"></asp:RequiredFieldValidator>
    </strong></p>
        <textarea id="txtKetquadanhgia" cols="70" rows="4" runat="server"></textarea>
    </td>
  </tr>
  <tr>
    <td><strong>8. Kết luận và kiến nghị của Đoàn đánh giá:</strong><br />
        <asp:DropDownList runat="server" ID="ddlKetluan">
            <asp:ListItem Text="Không đạt" Value="0"></asp:ListItem>
            <asp:ListItem Text="Đạt" Value="1"></asp:ListItem>            
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td><table width="100%" border="0.5">
      <tr>
        <td align="center"><p align="center"><strong>Các thành viên Đoàn đánh giá</strong></p>
          (Ký và ghi rõ họ, tên)<br />
           <asp:label runat="server" text="" id="lblCacthanhvien"></asp:label>
          </td>
        <td align="center"><p align="center"><strong>Trưởng Đoàn đánh giá</strong></p>
          (Ký và  ghi rõ họ, tên)<br />
            <asp:dropdownlist runat="server" id="ddlTruongdoan"></asp:dropdownlist>
          </td>
        </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td colspan="2" align="left">
        <asp:button runat="server" text="Lưu" ValidationGroup="required" id="btnLuu" 
            onclick="btnLuu_Click" /> | 
        <asp:button runat="server" text="Hủy" id="btnHuy" /> | 
        <asp:button runat="server" text="Xuất ra Word" id="btnExportToWord" onclick="btnExportToWord_Click" Enabled="false" />
    </td>
  </tr>
</table>
