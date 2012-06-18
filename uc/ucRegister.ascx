<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRegister.ascx.cs" Inherits="uc_ucRegister_" %>
<div class="contentcenter">
    <h1>Please registry here</h1>
    <div style="line-height: 25px;"><p class="maintitle">THÔNG TIN TÀI KHOẢN</p><p></p></div>
        <div class="linerow">
            <p class="title">Tên tài khoản:</p><p><asp:TextBox CssClass="txtbox" ID="regusername" runat="server" ></asp:TextBox
                ><asp:RequiredFieldValidator ID="rfvregusername" runat="server" ControlToValidate="regusername" 
                    Display="Dynamic" ValidationGroup="register" ErrorMessage="Không được để trống!" 
                    SetFocusOnError="true"></asp:RequiredFieldValidator></p>
        </div>                    
        <div class="linerow">
            <p class="title">Mật khẩu:</p><p><asp:TextBox CssClass="txtbox" ID="regpassword" runat="server" TextMode="Password"></asp:TextBox
                ><asp:RequiredFieldValidator ID="rfvregpassword" runat="server" Display="Dynamic" ControlToValidate="regpassword" 
                    ValidationGroup="register" ErrorMessage="Không được để trống!" 
                    SetFocusOnError="true"></asp:RequiredFieldValidator></p>
        </div>
        <div class="linerow">
            <p class="title">Xác Nhận Mật Mã:</p><p><asp:TextBox CssClass="txtbox" ID="regrepass" runat="server" TextMode="Password"></asp:TextBox
                ><asp:CompareValidator ID="cvdregrepass" runat="server" ControlToValidate="regrepass" ErrorMessage="Mật khẩu không trùng khớp!" 
                    ControlToCompare="regpassword" ValidationGroup="register" SetFocusOnError="true"></asp:CompareValidator></p>
        </div>
        <div class="linerow">
            <p class="title">Email:</p><p><asp:TextBox CssClass="txtbox" ID="regemail" runat="server" ></asp:TextBox
                ><asp:RequiredFieldValidator ID="rfvregemail" runat="server" ControlToValidate="regemail" Display="Dynamic" 
                    ValidationGroup="register" ErrorMessage="Không được để trống! " SetFocusOnError="true"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                        ID="revregreemail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="regemail" 
                        ValidationGroup="register" Display="Dynamic" ErrorMessage="Định dạng Email sai! " SetFocusOnError="true"></asp:RegularExpressionValidator></p>
        </div>
        <div class="linerow">
            <p class="title">Xác Nhận Email:</p><p><asp:TextBox CssClass="txtbox" ID="regreemail" runat="server"></asp:TextBox><asp:CompareValidator 
                ID="cvdregreemail" runat="server" ControlToValidate="regreemail" ErrorMessage="Email không trùng khớp!" ControlToCompare="regemail" 
                ValidationGroup="register" SetFocusOnError="true" ></asp:CompareValidator></p>
        </div>
        
    <div style="line-height: 25px;"><p class="maintitle">THÔNG TIN CƠ SỞ NUÔI TRỒNG</p></div>
        <div class="linerow">
            <p class="title">Tên cơ sở nuôi trồng:</p><p><asp:TextBox CssClass="txtbox" ID="regTencoso" runat="server" ></asp:TextBox
                ><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="regTencoso" 
                    Display="Dynamic" ValidationGroup="register" ErrorMessage="Không được để trống!" 
                    SetFocusOnError="true"></asp:RequiredFieldValidator></p>
        </div>
        <div class="linerow">
            <p class="title">Tên chủ cơ sở:</p><p><asp:TextBox CssClass="txtbox" ID="regTenchucoso" runat="server" ></asp:TextBox
                ><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="regTenchucoso" 
                    Display="Dynamic" ValidationGroup="register" ErrorMessage="Không được để trống!" 
                    SetFocusOnError="true"></asp:RequiredFieldValidator></p>
        </div>
        <div class="linerow">
            <p class="title">Ấp:</p><p><asp:TextBox CssClass="txtbox" ID="regAp" runat="server" ></asp:TextBox></p>
        </div>
        <div class="linerow">
            <p class="title">Xã:</p><p><asp:TextBox CssClass="txtbox" ID="regXa" runat="server" ></asp:TextBox></p>
        </div>
        <div class="linerow">
            <p class="title">Huyện:</p><p><asp:TextBox CssClass="txtbox" ID="regHuyen" runat="server" ></asp:TextBox></p>
        </div>
        <div class="linerow">
            <p class="title">Tỉnh:</p><p><asp:DropDownList ID="ddlTinh" 
                CssClass="txtbox ddl" runat="server"></asp:DropDownList></p>
        </div>
        <div class="linerow">
            <p class="title">Điện thoại:</p><p><asp:TextBox CssClass="txtbox" ID="regDienthoai" 
                runat="server" ></asp:TextBox></p>
        </div>
        <div class="linerow">
            <p class="title">Tổng diện tích cơ sở nuôi:</p><p><asp:TextBox CssClass="txtbox" 
                ID="regTongdientichcosonuoi" runat="server" ></asp:TextBox></p>
        </div>
        <div class="linerow">
            <p class="title">Tổng diện tích mặt nước:</p><p><asp:TextBox CssClass="txtbox" 
                ID="regTongdientichmatnuoc" runat="server" ></asp:TextBox></p>
        </div>
        <div class="linerow">
            <p class="title">Đối tượng nuôi:</p><p><asp:DropDownList ID="ddlDoituongnuoi" 
                CssClass="txtbox ddl" runat="server"></asp:DropDownList></p>
        </div>
        <div class="linerow">
            <p class="title">Năm sản xuất:</p><p><asp:DropDownList ID="ddlNamsanxuat" 
                CssClass="txtbox ddl" runat="server"></asp:DropDownList></p>
        </div>
        <div class="linerow">
            <p class="title">Chu kì nuôi:</p><p><asp:TextBox CssClass="txtbox" 
                ID="regChukinuoi" runat="server" ></asp:TextBox></p>
        </div>
        
    <div class="linerow">
        <p class="btnsubmit">
          <asp:Button ID="btnRegistry" runat="server" onclick="btnRegistry_Click" Text="Đăng Ký" ValidationGroup="register" CssClass="button" Width="90"/>
          <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" Text="Huỷ Bỏ" CssClass="button" Width="90"/>
        </p>
    </div>
</div>