<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDangky.ascx.cs" Inherits="uc_ucDangky" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<link href="../css/formInMain.css" rel="stylesheet" type="text/css" />

<asp:Panel ID="pnDangKyTV" runat="server">
    <div class="m">
        <fieldset>
            <legend>Thông tin tài khoản</legend>
            <div class="a">
                <div class="l">
                    Tên tài khoản</div>
                <div class="r">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="rfvregusername" runat="server" ControlToValidate="txtUsername"
                        Display="Dynamic" ValidationGroup="register" Text="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
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
                    Mật khẩu</div>
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
                    Mã xác nhận</div>
                <div class="r">
                    <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="none" CaptchaLength="5"
                        CaptchaHeight="40" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                        CaptchaMaxTimeout="240" />
                    <asp:TextBox ID="txtCapcha" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldCapcha" runat="server" ControlToValidate="txtCapcha"
                        Display="Dynamic" ValidationGroup="register" Text="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                    <asp:Button ID="btnRegistry" runat="server" OnClick="btnRegistry_Click" Text="Đăng Ký"
                        ValidationGroup="register" CssClass="button" Width="90" />
                </div>
            </div>
            <div class="a">
                <asp:Literal ID="litThongtin" runat="server"></asp:Literal>
            </div>
        </fieldset>
    </div>
</asp:Panel>