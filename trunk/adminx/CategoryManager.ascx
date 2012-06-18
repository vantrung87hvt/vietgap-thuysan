<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryManager.ascx.cs" Inherits="INVI.INVINews.Admin.CategoryManager" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<table style="width:500px;vertical-align:top">
    <tr>
        <td colspan="3" style="text-align: center">
            Quản lý Chủ đề</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Tên chủ đề</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="200"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="*" ControlToValidate="txtTitle" 
                ValidationGroup="vgUpdateCategory"></asp:RequiredFieldValidator>
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
                ValidationGroup="vgUpdateCategory"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Nhóm cấp trên</td>
        <td>
            <asp:DropDownList ID="cboTop" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Mô tả</td>
        <td>
            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="Đồng ý" 
                ValidationGroup="vgUpdateCategory" onclick="btnOK_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy bỏ" 
                CausesValidation="false" onclick="btnReset_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>


<asp:GridView ID="grvCategory" runat="server" AutoGenerateColumns="False" onrowdatabound="grvCategory_RowDataBound" 
    onselectedindexchanging="grvCategory_SelectedIndexChanging" 
    AllowPaging="True" AllowSorting="True" 
    onpageindexchanging="grvCategory_PageIndexChanging" 
    onsorting="grvCategory_Sorting"
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
        <asp:BoundField DataField="sTitle" HeaderText="Tên chủ đề" 
            SortExpression="sTitle" />
        <asp:BoundField DataField="iOrder" HeaderText="Thứ tự" 
            SortExpression="iOrder" />
        <asp:TemplateField HeaderText="Nhóm cấp trên">
            <ItemTemplate>
                <asp:Label ID="lblNhomcaptren" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
        
    </Columns>
</asp:GridView>
<a href="javascript:inviCheck.CheckAll()">Chọn tất |</a>
<a href="javascript:inviCheck.UnCheckAll()">Bỏ chọn |</a>

<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click">Xóa mục đã chọn</asp:LinkButton>



