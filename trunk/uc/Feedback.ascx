<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Feedback.ascx.cs" Inherits="INVI.INVINews.Module.Feedback" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<DIV class="dvPhanhoi">
    <asp:Label ID="lblMessage" runat="server" Text="<%$Resources:language,moiguiphanhoi %>" ForeColor="Red"></asp:Label></DIV>
<DIV class="dvPhanhoi">

</DIV>
<div class="dvPhanhoi">
	<div>
		<div class="lbl"><asp:Label ID="Label1" runat="server" Text="<%$Resources:language,tenbanla %>"></asp:Label>:</div>
		<asp:textbox id="txtHoten" runat="server" CssClass="textbox"></asp:textbox>
		<asp:RequiredFieldValidator id="rqHoten" runat="server" ErrorMessage="*" ControlToValidate="txtHoten" ValidationGroup="vgNhapphanhoi">*</asp:RequiredFieldValidator><br>
		<div class="lbl"><asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>:</div>
		<asp:textbox id="txtEmail" runat="server" CssClass="textbox"></asp:textbox>
		<asp:RequiredFieldValidator id="rqEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="vgNhapphanhoi">*</asp:RequiredFieldValidator>
		<asp:RegularExpressionValidator id="reEmail" runat="server" ErrorMessage="?" ControlToValidate="txtEmail"
			ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vgNhapphanhoi">*</asp:RegularExpressionValidator><br>
		<div class="lbl"><asp:Label ID="Label3" runat="server" Text="<%$Resources:language,tieude %>"></asp:Label>:</div>
		<asp:textbox id="txtTieude" runat="server" CssClass="textbox"></asp:textbox>
		<asp:RequiredFieldValidator id="rqTieude" runat="server" ErrorMessage="*" ControlToValidate="txtTieude" ValidationGroup="vgNhapphanhoi">*</asp:RequiredFieldValidator><br>
		<div><asp:Label ID="Label4" runat="server" Text="<%$Resources:language,noidung %>"></asp:Label>:</div>
		<div><asp:TextBox id="txtNoidung" CssClass="txtNoidung" runat="server" TextMode="MultiLine"></asp:TextBox>
		<asp:RequiredFieldValidator id="rqNoidung" runat="server" ErrorMessage="*" ControlToValidate="txtNoidung" ValidationGroup="vgNhapphanhoi">*</asp:RequiredFieldValidator>
		</div>
		<div class="dvButton">
			<asp:Button id="btnGui" runat="server" Text="<%$Resources:language,gui %>" Width="61px" OnClick="btnGui_Click" ValidationGroup="vgNhapphanhoi"></asp:Button>
			<INPUT type="reset" value="<%$Resources:language,huybo %>" id="btnReset" runat="server"/>
		</div>
	</div>
</div>