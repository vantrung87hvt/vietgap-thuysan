<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTochuccapphepQuanLy.ascx.cs"
    Inherits="adminx_ucTochuccapphepQuanLy" %>


<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<link href="<%=ResolveUrl("~/adminx/css/popupStyle.css")%>" rel="stylesheet" type="text/css" />
<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
        <table style="width: 100%;">
            <tr>
                <td width="100%">
                    <asp:Label ID="lblThongbao" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Tìm kiếm&nbsp; :&nbsp;
                    <asp:TextBox ID="txtSearchByID" runat="server" Width="234px"></asp:TextBox>
                    &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label><asp:TextBox
                        ID="txtID" runat="server" Width="50px"></asp:TextBox>
                    <asp:LinkButton ID="btnSearchByID" runat="server" OnClick="btnSearchByID_Click" Text="Tìm kiếm" />|
                    <asp:LinkButton ID="btnShowAll" runat="server" OnClick="btnShowAll_Click" Text="Hiện toàn bộ" />
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:GridView ID="grvTochuccapphep" runat="server" AutoGenerateColumns="False" OnRowDataBound="grvTochuccapphep_RowDataBound"
                        OnSelectedIndexChanging="grvTochuccapphep_SelectedIndexChanging" OnRowCommand="grvTochuccapphep_RowCommand"
                        AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grvTochuccapphep_PageIndexChanging"
                        OnSorting="grvTochuccapphep_Sorting" AlternatingRowStyle-CssClass="GridAltItem"
                        HeaderStyle-CssClass="GridHeader" CssClass="Grid" EnableModelValidation="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Chọn tất">
                                <HeaderTemplate>
                                    <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvTochuccapphep','chkDelete');" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkDelete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PK_iTochucchungnhanID" HeaderText="ID" SortExpression="PK_iTochucchungnhanID" />
                            <asp:BoundField DataField="sTochucchungnhan" HeaderText="Tên" SortExpression="sTochucchungnhan" />
                            <asp:BoundField DataField="sMaso" HeaderText="Mã số" SortExpression="sMaso" />
                            <asp:TemplateField HeaderText="Quận" SortExpression="FK_iQuanHuyenID">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuanHuyen" runat="server" Text='<%# Bind("FK_iQuanHuyenID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtQuanHuyen" runat="server" Text='<%# Bind("FK_iQuanHuyenID") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="sSodienthoai" HeaderText="Điện thoại" SortExpression="sSodienthoai" />
                            <asp:TemplateField HeaderText="Trạng thái">
                                <ItemTemplate>
                                    <asp:Label ID="lblTrangthai" runat="server" Text='<%# Bind("iTrangthai") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTrangthai" runat="server" Text='<%# Bind("iTrangthai") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Sửa" />
                            <asp:HyperLinkField DataNavigateUrlFields="PK_iTochucchungnhanID" 
                                DataNavigateUrlFormatString="Default.aspx?page=TochuccapphepQuanly&amp;PK_iTochucchungnhanID={0}" 
                                Text="Xử lý" />
                        </Columns>
                        <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                        <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="lnkAdd" runat="server" Text="Thêm mới|" NavigateUrl="~/adminx/Default.aspx?page=TochuccapphepUpdate&do=add" />
                    <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click"
                        OnClientClick="return confirm('Chắc chắn xóa?')" CausesValidation="False">Xóa đã chọn</asp:LinkButton>|
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                    <asp:Panel ID="pnlXuly" runat="server" Visible="false">
                        <frameset>
    <legend>Xử lý vi phạm đối với Tổ chức hoạt động cấp phép</legend>
    <table>
        <tr>
            <td>Thông tin Tổ chức hoạt động cấp phép: </td>
            <td>
                <ul>
                    <li><b>Tổ chức chứng nhận: </b><asp:Label ID="lblTentochuc" runat="server"></asp:Label></li>
                    <li><b>Địa chỉ: </b><asp:Label ID="lblDiachi" runat="server"></asp:Label>;</li>
                    <li><b>Số điện thoại: </b><asp:Label ID="lblSodienthoai" runat="server"></asp:Label></li>
                    <li><b>Fax: </b><asp:Label ID="lblSoFax" runat="server"></asp:Label></li>
                    <li><b>Email: </b><asp:Label ID="lblEmail" runat="server"></asp:Label></li>
                    <li><b>Đăng ký KD Số: </b><asp:Label ID="lblSodangkykinhdoanh" runat="server"></asp:Label></li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                <b>Tình trạng:</b>
            </td>
            <td>
                <asp:Label ID="lblTinhtrang" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Hình thức xử lý vi phạm: </td>
            <td>
                <asp:DropDownList ID="ddlHinhthucxuly" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlHinhthucxuly_SelectedIndexChanged">
                    <asp:ListItem Value="0">Khôi phục</asp:ListItem>
                    <asp:ListItem Value="1">Cảnh cáo</asp:ListItem>
                    <asp:ListItem Value="2">Đình chỉ</asp:ListItem>
                    <asp:ListItem Value="3">Thu hồi Giấy chứng nhận VIETGAP</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Lý do:
            </td>
            <td>
                <asp:TextBox ID="txtLydo" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right"><asp:Button ID="btnXuly" runat="server" Text="Xử lý" 
                    onclick="btnXuly_Click"></asp:Button>
                
            </td>
        </tr>
    </table>
    </frameset>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <%-- Đây là popup hiện thông tin--%>
        <%--<asp:Panel ID="pnlPopup" runat="server" Width="550px">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" id="tblPopup">
                <tr>
                    <td class="heading">
                        Thông tin tổ chức
                    </td>
                </tr>
                <tr>
                    <td class="body">
                        <asp:Label ID="lblInfo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="footer">
                        <asp:Button ID="btnDlgOK" runat="server" Text="Đóng" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button ID="btnDummy" runat="server" Text="Button" />
        <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" TargetControlID="btnDummy"
            OkControlID="btnDlgOK" PopupControlID="pnlPopup" DynamicControlID="lblInfo" DynamicServicePath="../Service.asmx"
            DynamicServiceMethod="getAjaxTochucchungnhan" BackgroundCssClass="modal" DropShadow="true">
        </asp:ModalPopupExtender>--%>
    </ContentTemplate>
</asp:UpdatePanel>
