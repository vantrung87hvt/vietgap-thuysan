<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAnswerManager.ascx.cs" Inherits="INVI.INVINews.Admin.PollAnswerManager" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />

<div style="width: 701px">
    Phương án :<br />
    <hr align="left" style="width: 692px" />
    <br />
<asp:ListBox ID="lstbAnswer" runat="server" Width="400px"></asp:ListBox>
<br />
<br />
<asp:LinkButton ID="lbtnRemove" runat="server" CausesValidation="False" 
    onclick="lbtnRemove_Click">Xóa</asp:LinkButton>
&nbsp;|
<asp:LinkButton ID="lbtnAdd" runat="server" onclick="lbtnAdd_Click" 
    ValidationGroup="vgUpdateAnswer">Thêm</asp:LinkButton>
&nbsp;
<asp:TextBox ID="txtAdd" runat="server" Width="189px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="txtAdd" ErrorMessage="*" ValidationGroup="vgUpdateAnswer"></asp:RequiredFieldValidator>
<br />
</div>