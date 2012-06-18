<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PollManager.ascx.cs" Inherits="INVI.INVINews.Admin.PollManager" %>

<%@ Register src="~/adminx/AnswerManager.ascx" tagname="AnswerManager" tagprefix="uc1" %>

<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />

<table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            Chọn nhóm :
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                runat="server" ControlToValidate="lstbNhomtin" ErrorMessage="Chưa chọn" 
                ValidationGroup="vgUpdatePoll"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr valign="top">
        <td class="style1">


<table style="width:500px;vertical-align:top">
    <tr>
        <td colspan="3" style="text-align: center">
            Quản lý thăm dò</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Câu hỏi thăm dò</td>
        <td>
            <asp:TextBox ID="txtQuestion" runat="server" MaxLength="500" Width="257px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="*" ControlToValidate="txtQuestion" 
                ValidationGroup="vgUpdatePoll"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Thứ tự</td>
        <td>
            <asp:TextBox ID="txtOrder" runat="server" Height="22px" MaxLength="3" 
                Width="50px">0</asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtOrder" ErrorMessage="*" 
                ValidationGroup="vgUpdatePoll"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Đặt ở trang chủ&nbsp;</td>
        <td>
            <asp:CheckBox ID="chkHomepage" runat="server" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Ngày đăng</td>
        <td>
            <asp:TextBox ID="txtDate" runat="server" MaxLength="500"></asp:TextBox>
        &nbsp;(dd/MM/yyyy) ví dụ : 11/04/2009</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="Đồng ý" 
                ValidationGroup="vgUpdatePoll" onclick="btnOK_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy bỏ" 
                CausesValidation="false" onclick="btnReset_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
        </td>
        <td>


                <asp:ListBox ID="lstbNhomtin" runat="server" Height="300px" Width="206px" 
                    SelectionMode="Multiple">
                </asp:ListBox>
        </td>
    </tr>
    <tr>
        <td class="style1" colspan="2">
<uc1:AnswerManager ID="AnswerManager1" runat="server" Visible="false" />
        </td>
    </tr>
    <tr>
        <td class="style1" colspan="2">

<asp:GridView ID="grvPoll" runat="server" AutoGenerateColumns="False" onrowdatabound="grvPoll_RowDataBound" 
    onselectedindexchanging="grvPoll_SelectedIndexChanging" 
    AllowPaging="True" AllowSorting="True" 
    onpageindexchanging="grvPoll_PageIndexChanging" 
    onsorting="grvPoll_Sorting"
    AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid"
    >
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkDelete" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="sQuestion" HeaderText="Câu hỏi thăm dò" 
            SortExpression="sQuestion" />
        <asp:BoundField DataField="iOrder" HeaderText="Thứ tự" 
            SortExpression="iOrder" />
        <asp:CheckBoxField DataField="bHomepage" HeaderText="Đặt ở trang chủ" 
            SortExpression="bHomepage" />
        <asp:BoundField DataField="tDate" DataFormatString="{0:dd/MM/yyyy}" 
            HeaderText="Ngày đăng" SortExpression="tDate" />
        <asp:TemplateField HeaderText="Tin tức">
            <ItemTemplate>
                <asp:Label ID="lblNews" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
        
    </Columns>
</asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <a href="javascript:inviCheck.CheckAll()">Chọn tất |</a>
            <a href="javascript:inviCheck.UnCheckAll()">Bỏ chọn |</a>
            <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
                onclick="lbtnDelete_Click">Xóa mục đã chọn</asp:LinkButton>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>




