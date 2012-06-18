<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTochuccapphepUpdate.ascx.cs" Inherits="ucTochuccapphepUpdate" %>

<div style ="margin:30px;margin-bottom:0;">
<asp:Label ID="lblLoi" ForeColor="Red" runat="server" Font-Names="Times New Roman"></asp:Label>
</div>

<asp:Panel id="pnTochuccaphep" runat="server">
<div class="m">
<fieldset><legend>Tổ chức cấp phép</legend>
<div class="a"><div class="l">Tên tổ chức</div><div class="r">
    <asp:TextBox ID="txtTochucchungnhan" runat="server"></asp:TextBox>
</div>
     <div class="rr">
        <asp:RequiredFieldValidator ID="rfvregusername" runat="server" ControlToValidate="txtTochucchungnhan" 
                    Display="Dynamic" ValidationGroup="register"   Text="*"  ForeColor="Red"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
</div>
</div>
    
<%--<div class="a"><div class="l">Ký tự viết tắt:</div><div class="r">
    <asp:TextBox ID="txtKytuviettat" runat="server"></asp:TextBox>
    
</div><div class="rr">
        <asp:RequiredFieldValidator ID="rfvregemail" runat="server" ControlToValidate="txtKytuviettat" Display="Dynamic" 
                    ValidationGroup="register" ForeColor="Red"  Text="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
    </div>
</div>--%>
    
<div class="a"><div class="l">Logo:</div><div class="r">
    <asp:FileUpload ID="fuLogo" runat="server" />
    <asp:Image ID="imgLogo" Width="110px" Height="110px" runat="server" />
    
</div><div class="rr">
      
</div>
</div>
<div class="a"><div class="l">Địa chỉ:</div><div class="r">
    <asp:TextBox ID="txtDiachi" runat="server" ></asp:TextBox>
</div>
    <div class="rr">
        <asp:RequiredFieldValidator ID="rfvDiachi" runat="server" ControlToValidate="txtDiachi" Display="Dynamic" 
                    ValidationGroup="register" ForeColor="Red"  Text="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="a"><div class="l">Tỉnh:</div><div class="r">
    <asp:DropDownList ID="ddlTinh" runat="server" 
        onselectedindexchanged="ddlTinh_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
    
</div> <div class="rr">
</div></div>
<div class="a"><div class="l">Quận - Huyện:</div><div class="r">
    <asp:DropDownList ID="ddlQuanHuyen" runat="server">
    </asp:DropDownList>
    
</div> <div class="rr">
</div></div>
<div class="a"><div class="l">Điện thoại:</div><div class="r"><asp:TextBox ID="txtDienthoai" runat="server"></asp:TextBox></div>
    <div class="rr">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDienthoai" Display="Dynamic" 
                    ValidationGroup="register" ForeColor="Red"  Text="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="a"><div class="l">Tổ chức cấp trên:</div><div class="r">
    <asp:DropDownList ID="ddlCoquancaptren" runat="server">
    </asp:DropDownList>
    
</div> <div class="rr">
</div></div>
<div class="a"><div class="l">Tài khoản:</div><div class="r">
    <asp:DropDownList ID="ddlTaikhoan" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlTaikhoan_SelectedIndexChanged">
    </asp:DropDownList>
    
</div> <div class="rr">
</div></div>
<asp:Panel ID="pnDuyet" runat="server">
<div class="a"><div class="l">Duyệt:</div><div class="r">
    <asp:CheckBox ID="cbDuyet" runat="server" />
</div> <div class="rr">
</div></div>
</asp:Panel>
<div class="a"><div class="l"></div><div class="r">
<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="register"  
        ForeColor="Red"  HeaderText="Phải nhập các trường (*)" runat="server" 
        Font-Names="Times New Roman" />
</div>
    <div class="rr">
        
    </div>
</div>

<div class="a"><div class="l">&nbsp;</div><div class="r">
    <asp:Button ID="btnOk" runat="server" Text="Đồng ý" 
        ValidationGroup="register" CssClass="button" Width="70" 
        onclick="btnOk_Click"/>
    <asp:Button ID="btnReset" runat="server"  Text="Hủy bỏ" 
        ValidationGroup="register" CssClass="button" Width="70" 
        onclick="btnReset_Click"/>
</div></div>
<div class="a"></div>
</fieldset>
</div>
</asp:Panel>