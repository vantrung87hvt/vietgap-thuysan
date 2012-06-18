<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDangkytochucchungnhan.ascx.cs" Inherits="adminx_ucDangkytochucchungnhan" %>
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

.checkboxes
{
    width:100%;
}
</style>
<style type="text/css">
    input[type="text"], select
    {
        width:300px;
    }
</style>
<link href="../css/jquery-ui-1.8.12.custom.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.12.custom.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        $(".datepicker").datepicker({
            closeText: 'Đóng',
            prevText: '<Trước',
            nextText: 'Sau>',
            currentText: 'Đã chọn',
            monthNames: ['Giêng', 'Hai', 'Ba', 'Tư', 'Năm', 'Sáu',
	        'Bảy', 'Tám', 'Chín', 'Mười', 'Mười một', 'Mười hai'],
            monthNamesShort: ['Giêng', 'Hai', 'Ba', 'Tư', 'Năm', 'Sáu',
	        'Bảy', 'Tám', 'Chín', 'Mười', 'Mười một', 'Mười hai'],
            dayNames: ['Thứ hai', 'Thứ ba', 'Thứ tư', 'Thứ năm', 'Thứ sáu', 'Thứ bảy', 'Chủ nhật'],
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
<div>
    <fieldset>
	    <legend>Đăng ký Tổ chức chứng nhận</legend>
        <table>
          <tr>
            <td></td>
            <td>
                <asp:Label ID="lblThongbao" runat="server" BackColor="White" ForeColor="Red"></asp:Label></td>
            <td></td>
          </tr>
          <tr>
            <td>Trạng thái:</td>
            <td>
                <asp:Label ID="lblTrangthai" runat="server" BackColor="White" ForeColor="Red"></asp:Label></td>
            <td></td>
          </tr>
          <tr>
            <td>Tên tổ chức:</td>
            <td><input runat="server" type="text" name="txtTentochuc" id="txtTentochuc" /></td>
            <td>
                <asp:requiredfieldvalidator runat="server" ValidationGroup="required"  ControlToValidate="txtTentochuc" errormessage="Không được trống!"></asp:requiredfieldvalidator>
            </td>
          </tr>
          <tr>
            <td>Ký tự viết tắt:</td>
            <td><input runat="server" type="text" name="txtKytuviettat" id="txtKytuviettat" /></td>
            <td>
                <asp:requiredfieldvalidator ID="Requiredviettat" runat="server" ValidationGroup="required"  ControlToValidate="txtKytuviettat" errormessage="Không được trống!"></asp:requiredfieldvalidator>
            </td>
          </tr>
          <tr>
            <td>Địa chỉ liên lạc:</td>
            <td>
                <textarea runat="server" id="txtDiachi" cols="35"></textarea>
            </td>
            <td><asp:RequiredFieldValidator ID="rfDiachi" runat="server" ErrorMessage=" Không được trống!" ControlToValidate="txtDiachi" ValidationGroup="required" ></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td>Quận (huyện):</td>
            <td>
                <asp:dropdownlist runat="server" id="ddlQuanhuyen"></asp:dropdownlist>
            </td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>Số điện thoại:</td>
            <td><input runat="server" type="text" name="txtSodienthoai" id="txtSodienthoai" /></td>
            <td>
                <asp:requiredfieldvalidator runat="server" ValidationGroup="required"  ControlToValidate="txtSodienthoai" errormessage="Không được trống!"></asp:requiredfieldvalidator>
            </td>
          </tr>
          <tr>
            <td>Fax:</td>
            <td><input runat="server" type="text" name="txtFax" id="txtFax" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>E-mail:
            </td>
            <td><input runat="server" type="text" name="txtEmail" id="txtEmail" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>Quyết định thành lập  (nếu có) hoặc Giấy đăng ký kinh doanh số:</td>
            <td><input runat="server" type="text" name="txtSodangkydinhdoanh" id="txtSodangkydinhdoanh" /></td>
            <td><asp:RequiredFieldValidator ID="rqGdk" runat="server" ErrorMessage=" Không được trống!" ControlToValidate="txtSodangkydinhdoanh" ValidationGroup="required" ></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td>Cơ quan cấp phép kinh doanh:</td>
            <td><input runat="server" type="text" name="txtCoquancapphep" id="txtCoquancapphep" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>Ngày cấp:</td>
            <td>
                <input type="text" ID="txtNgaycap_datepicker" runat="server" class="required timepicker" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqNgaycap" runat="server" ErrorMessage=" Không được trống!" ControlToValidate="txtNgaycap_datepicker" ValidationGroup="required" ></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td>Nơi cấp:</td>
            <td><input runat="server" type="text" name="txtNoicap" id="txtNoicap" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>Logo:</td>
            <td>
                <asp:FileUpload ID="imgUpload" runat="server" />
                <%--<input runat="server" type="file" name="sLogo" id="sLogo" />--%>
                <div style="max-width:200px; max-height:200px;">
                <asp:Image ID="imgLogo" runat="server" Visible="false" Width="200px" Height="200px" />
                </div>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorimg" ValidationGroup="required" runat="server" ControlToValidate="imgUpload" ErrorMessage="Không được trống!"></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
               <td>Giấy tờ nộp kèm:</td>
                <td>
                    <asp:CheckBoxList ID="cblGiaytonopkem" runat="server" Width="100%"></asp:CheckBoxList>
                </td>
          </tr>
          <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnAdd" runat="server" Text="Đăng ký" onclick="AddTochucchungnhan" ValidationGroup="required" />
                <asp:Button ID="btnLuu" runat="server" Text="Lưu" onclick="SaveChange" ValidationGroup="required" />
                <asp:Button ID="btnSua" runat="server" Text="Sửa" onclick="EditTochucchungnhan" />
                <asp:Button ID="btnHuy" runat="server" Text="Hủy" onclick="Huy" />
            <td>&nbsp;</td>
          </tr>
        </table>
    </fieldset>
</div>