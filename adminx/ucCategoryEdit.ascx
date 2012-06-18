<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCategoryEdit.ascx.cs"
    Inherits="adminx_CategoryEdit" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
 <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View2" runat="server">
        <table style="width: 500px; vertical-align: top">
            <tr>
                <td colspan="3" style="text-align: center">
                    Quản lý Chủ đề
                </td>
            </tr>
            <tr>
                <td colspan="3">
                   
                </td>
            </tr>
            <tr>
                <td>
                    Tên chủ đề
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="200"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="*" ValidationGroup="vgUpdateCategory"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Thứ tự
                </td>
                <td>
                    <asp:TextBox ID="txtOrder" runat="server" Height="22px" MaxLength="3" Width="50px">0</asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrder"
                        ErrorMessage="*" ValidationGroup="vgUpdateCategory"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Nhóm cấp trên
                </td>
                <td>
                    <asp:DropDownList ID="cboTop" runat="server" AutoPostBack="false">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Mô tả
                </td>
                <td>
                    <asp:TextBox ID="txtDesc" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="Đồng ý" ValidationGroup="vgUpdateCategory" />
                    <asp:Button ID="btnReset" runat="server" CausesValidation="false" OnClick="btnReset_Click"
                        Text="Hủy bỏ" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View1" runat="server">
        <asp:Table ID="Table1" runat="server" GridLines="Both" CssClass="Grid">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Chủ đề ID">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Tên chủ đề">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Thứ tự">
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Sửa">
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            
        </asp:Table>
        <asp:LinkButton ID="lbtnAdd" runat="server" CausesValidation="False" OnClick="lbtnAdd_Click">Thêm mới</asp:LinkButton>|
        
        <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click">Xóa mục đã chọn</asp:LinkButton>
    </asp:View>
</asp:MultiView>
