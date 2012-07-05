<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucChuyengia.ascx.cs" Inherits="adminx_Tochucchungnhan_ucChuyengia" %>
<%--<link rel="Stylesheet" media="screen" type="text/css" href="<%=ResolveUrl("~/adminx/css/Grid_View.css")%>" />--%>
<asp:Panel ID="pnlEdit" runat="server" Visible="false">
    <table width="100%">
        <tr>
            <td width="30%" colspan="2" style="width: 100%" align="center">
                <asp:Label ID="lblInfo" runat="server" Text="Danh sách chuyên gia"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="30%" colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;
            </td>
            <td width="70%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
                <asp:Label ID="lblName" runat="server" Text="Họ tên:"></asp:Label>
            </td>
            <td valign="middle" width="70%">
                <asp:TextBox ID="txtHoten" runat="server" Width="95%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqTentrinhdo" runat="server" ControlToValidate="txtHoten"
                    ErrorMessage="*" ValidationGroup="vgGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
                <asp:Label ID="Label5" runat="server" Text="Tổ chức chứng nhận:"></asp:Label>
            </td>
            <td valign="middle" width="70%">
                <asp:DropDownList ID="ddlTochucchungnhan" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
                <asp:Label ID="Label6" runat="server" Text="Trình độ:"></asp:Label>
            </td>
            <td valign="middle" width="70%">
                <asp:DropDownList ID="ddlTrinhdo" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
                <asp:Label ID="Label1" runat="server" Text="Số năm kinh nghiệm:"></asp:Label>
            </td>
            <td valign="middle" width="70%">
                <asp:TextBox ID="txtSonamkinhnghiem" runat="server" Width="95%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSonamkinhnghiem"
                    ErrorMessage="*" ValidationGroup="vgGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
                <asp:Label ID="Label2" runat="server" Text="Mã số:"></asp:Label>
            </td>
            <td valign="middle" width="70%">
                <asp:TextBox ID="txtMaso" runat="server" Width="95%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaso"
                    ErrorMessage="*" ValidationGroup="vgGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
                <asp:Label ID="Label3" runat="server" Text="Duyệt:"></asp:Label>
            </td>
            <td valign="middle" width="70%">
                <asp:DropDownList ID="ddlDuyet" runat="server">
                    <asp:ListItem Value="1">Duyệt</asp:ListItem>
                    <asp:ListItem Value="0">Chưa duyệt</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
                <asp:Label ID="Label4" runat="server" Text="Ảnh thẻ:"></asp:Label>
            </td>
            <td valign="middle" width="70%">
                <asp:Image ID="imgAnhthe" runat="server" Height="110px" Width="110px" />
                
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
            </td>
            <td valign="middle" width="70%">
                <asp:FileUpload ID="fAnhthe" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top" width="20%">
                <asp:Label ID="lblGiaytokemtheo" runat="server" Text="Các chứng chỉ:"></asp:Label>
            </td>
            <td valign="middle" width="70%">
                <asp:Panel runat="server" ID="pnlGiaychungnhan" Visible="true">
                        <asp:CheckBoxList ID="cblGiaychungnhan" runat="server">
                        </asp:CheckBoxList>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnOK" runat="server" Text="Thêm" OnClick="btnOK_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Bỏ qua" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblThongbao" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:GridView ID="grvChuyengia" runat="server" AutoGenerateColumns="False" AllowPaging="True"
    AllowSorting="True" OnSelectedIndexChanging="grvPosition_SelectedIndexChanging"
    OnSorting="grvPosition_Sorting" Width="100%" AlternatingRowStyle-CssClass="GridAltItem"
    HeaderStyle-CssClass="GridHeader" CssClass="Grid" 
    onrowdatabound="grvChuyengia_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvGroup','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="chkDelete" />
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
        <asp:BoundField DataField="PK_iChuyengiaID" HeaderText="ID" SortExpression="PK_iChuyengiaID" />
        <asp:BoundField DataField="sHoten" HeaderText="Họ tên" SortExpression="sHoten">
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="sMaso" HeaderText="Mã số" SortExpression="sMaso">
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="iNamkinhnghiem" HeaderText="Kinh nghiệm (năm)" SortExpression="iNamkinhnghiem">
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Tổ chức chứng nhận" SortExpression="FK_iTochucchungnhan">
            <ItemTemplate>
                <asp:Label ID="lblTochucchungnhan" runat="server" Text='<%# Bind("FK_iTochucchungnhanID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Trình độ" SortExpression="FK_iTrinhdoID">
            <ItemTemplate>
                <asp:Label ID="lblTrinhdo" runat="server" Text='<%# Bind("FK_iTrinhdoID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
    </Columns>
</asp:GridView>
<asp:LinkButton ID="lbtnAddnew" runat="server" CausesValidation="False" OnClick="lbtnAddnew_Click">Thêm mới | </asp:LinkButton>
<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click"
    OnClientClick="return confirm('Bạn có thực sự muốn xóa không?');">Xóa mục đã chọn</asp:LinkButton>
</table> 