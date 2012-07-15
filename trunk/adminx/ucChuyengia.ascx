<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucChuyengia.ascx.cs" Inherits="adminx_Tochucchungnhan_ucChuyengia" %>
<link href='<%=ResolveUrl("~/adminx/css/report.css")%>' rel="stylesheet" type="text/css" />
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
                <asp:Label ID="lblGiaytokemtheo" runat="server" Text="Giấy chứng nhận:"></asp:Label>
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
                <asp:Button ID="btnCapmaso" runat="server" Text="Cấp mã số" 
                    onclick="btnCapmaso_Click" />
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
    onrowdatabound="grvChuyengia_RowDataBound" EnableModelValidation="True" 
    onrowcommand="grvChuyengia_RowCommand">
<AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
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
        <asp:TemplateField HeaderText="Tạo thẻ">
            <ItemTemplate>
                <asp:LinkButton ID="lbtnThechuyengia" CommandName="Thechuyengia" CommandArgument='<%# Bind("PK_iChuyengiaID") %>' runat="server" Text="Tạo thẻ" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

<HeaderStyle CssClass="GridHeader"></HeaderStyle>
</asp:GridView>
<asp:LinkButton ID="lbtnAddnew" runat="server" CausesValidation="False" OnClick="lbtnAddnew_Click">Thêm mới | </asp:LinkButton>
<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click"
    OnClientClick="return confirm('Bạn có thực sự muốn xóa không?');">Xóa mục đã chọn</asp:LinkButton>
</table> 
<%--Thẻ chuyên gia--%>
<asp:Panel runat="server" ID="pnThechuyengia" Visible="false">
    <table class="thechuyengia">
        	<tr><td class="2"><br /><br /></td></tr>
        	<tr>
            	<td class="center bold">
                	BỘ NÔNG NGHIỆP VÀ PTNT<br />
                    <asp:Label ID="lblCoquanchidinh" runat="server" Text=""></asp:Label>
                </td>
                <td class="center">
                	CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM<br />Độc lập - Tự do- Hạnh phúc<hr width="40%" />
                </td>
            </tr>
            <tr>
            	<td colspan="2" class="left">
                    <asp:Image ID="imgAnhtheChuyengia" CssClass="anhthe-chuyengia" runat="server" />
                </td>
            </tr>
            <tr>
            	<td colspan="2" class="center bold">
                	THẺ CHUYÊN GIA ĐÁNH GIÁ VietGAP
                </td>
            </tr>
            <tr>
            	<td colspan="2" class="left padding-left line-height">
                	<br /><br />
                	Họ và tên:&nbsp;<asp:Label ID="lblHoten" runat="server" Text=""></asp:Label><br />
                    Năm sinh:&nbsp;<asp:Label ID="lblNamsinh" runat="server" Text=""></asp:Label><br />
                    Đơn vị công tác:&nbsp;<asp:Label ID="lblDonnvicongtac" runat="server" Text=""></asp:Label><br />
                    Lĩnh vực đánh giá:&nbsp;<asp:Label ID="lblLinhvucdanhgia" runat="server" Text=""></asp:Label><br />
                    Mã số:&nbsp;<span class="bold"><asp:Label ID="lblMasochuyengia" runat="server" Text=""></asp:Label></span><br />
                </td>
            </tr>
            <tr>
            	<td class="center">&nbsp;</td>
                <td class="center">
                    <asp:Label ID="lblNgayky" runat="server" Text=""></asp:Label><br />
                	... , ngày ... tháng ... năm 20..<br />
                    <span class="bold">Thủ trưởng đơn vị</span><br />
                    ( Ký tên, đóng dấu)<br />
                    <asp:Label ID="lblTenthutruong" runat="server" Text=""></asp:Label>
                    <br /><br />
                </td>
            </tr>
        </table>
        <center>
            <br />
            <asp:Button ID="btnExportToWord" runat="server" Text="Xuất ra Word" 
                onclick="btnExportToWord_Click" />&nbsp;|&nbsp;
            <asp:Button ID="btnVisiblePannel" runat="server" Text="Ẩn" 
                onclick="btnVisiblePannel_Click" />
        </center>
</asp:Panel>