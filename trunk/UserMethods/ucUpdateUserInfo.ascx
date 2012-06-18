<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUpdateUserInfo.ascx.cs" Inherits="UserMethods_ucUpdateUserInfo" %>
<style type="text/css">
    fieldset
    {
        -moz-border-radius: 7px;
        border: 1px #dddddd solid;
        margin-bottom: 20px;
        width: 550px;
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
        width: 560px;
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
        width: 300px;
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
        width: 500px;
        padding: 10px;
    }
    input
    {
        width: 100%;
    }
    
   
    #button
    {
        text-align: center;
        margin: 100px;
    }
</style>
<div style="margin: 30px; margin-bottom: 0;">
    <asp:Label ID="lblLoi" ForeColor="Red" runat="server"></asp:Label>
</div>
<asp:Panel ID="pnDangKyTV" runat="server">
    <div class="m">
        <fieldset>
            <legend>Thông tin tài khoản</legend>            
            <div class="a">
                <div class="l">
                    E-Mail</div>
                <div class="r">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="rfvregemail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ValidationGroup="register" ForeColor="Red" Text="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revregreemail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="register" Display="Dynamic"
                        ErrorMessage="Định dạng Email sai! " Text="*" SetFocusOnError="true"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Nhập lại e-mail:</div>
                <div class="r">
                    <asp:TextBox ID="txtRetypeEmail" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:CompareValidator ID="cvdregreemail" runat="server" ControlToValidate="txtRetypeEmail"
                        ControlToCompare="txtEmail" Text="*" ForeColor="Red" ValidationGroup="register"
                        SetFocusOnError="true"></asp:CompareValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Mật khẩu cũ</div>
                <div class="r">
                    <asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server"></asp:TextBox></div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="txtOldPassword" ValidationGroup="register" Text="*" ForeColor="Red"
                        SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Mật khẩu mới</div>
                <div class="r">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="rfvregpassword" runat="server" Display="Dynamic"
                        ControlToValidate="txtPassword" ValidationGroup="register" Text="*" ForeColor="Red"
                        SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Nhập lại mật khẩu</div>
                <div class="r">
                    <asp:TextBox ID="txtRetypePass" TextMode="Password" runat="server"></asp:TextBox></div>
                <div class="rr">
                    <asp:CompareValidator ID="cvdregrepass" runat="server" ControlToValidate="txtRetypePass"
                        ErrorMessage="Mật khẩu không trùng khớp!" Text="*" ForeColor="Red" ControlToCompare="txtPassword"
                        ValidationGroup="register" SetFocusOnError="true"></asp:CompareValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                </div>
                <div class="r">
                    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="register" ForeColor="Red"
                        HeaderText="Phải nhập các trường (*)" runat="server" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    &nbsp;</div>
                <div class="r">
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cập nhật"
                        ValidationGroup="register" CssClass="button" Width="90" />
                </div>
            </div>
            <div class="a">
            </div>
        </fieldset>
    </div>
</asp:Panel>