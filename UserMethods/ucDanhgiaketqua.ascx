<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDanhgiaketqua.ascx.cs"
    Inherits="uc_ucTinh" %>
<%@ Import Namespace="System.Data" %>
<link href="../CSS/Grid_View.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function checkAll() {

    }
</script>
<h2>
    Kết quả đánh giá nội bộ:
</h2>
<table style="width: 100%; margin-top: 20px; height: auto;">
    <tr>
        <td width="100%">
            <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <a href="#complete">Hoàn tất đánh giá</a>&nbsp;
            <asp:LinkButton ID="ltbnDellAll" OnClick="ltbnDellAll_Click" runat="server" OnClientClick="return confirm('Chắc chắn xóa?')" >Hủy kết quả đánh giá</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Repeater ID="rptDanhmucchitieu" runat="server" 
                OnItemDataBound="rptDanhmucchitieu_ItemDataBound">
                <HeaderTemplate>
                    <table border="1px">
                        <tr>
                            <th>
                                TT
                            </th>
                            <th>
                                Chỉ tiêu/tiêu chuẩn
                            </th>
                            <th>
                                Yêu cầu theo VietGAP
                            </th>
                            <th>
                                Mức độ
                            </th>
                            <th>
                                Phương pháp kiểm tra, đánh giá
                            </th>
                            <th>
                                Kết quả
                            </th>
                            <th>
                                Ghi chú
                            </th>
                            <th>&nbsp;
                            </th>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <b>
                                <%# DataBinder.Eval(Container.DataItem, "sTenchuyenmuc") %></b>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <asp:Repeater ID="rptChitieu" runat="server" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Danhmucchitieu_Chitieu") %>'
                    onitemcreated="rptChitieu_ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "[\"iThuthu\"]") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "[\"sNoidung\"]") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "[\"sYeucauvietgap\"]") %>
                                </td>
                                <td>
                                     <%# getsTenmucdo((int)(DataBinder.Eval(Container.DataItem, "[\"FK_iMucdoID\"]"))) %>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPhuongphapkiemtra" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlKetqua" runat="server">
                                        <asp:ListItem Text="Đạt" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Không đạt" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "[\"sGhichu\"]") %>
                                </td>
                                <td>
                                    <%--<asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Sửa" ></asp:ButtonField>--%>
                                    <asp:LinkButton ID="lbtnEdit" runat="server" Visible="false" OnClick="lbtnEdit_Click">Sửa</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>
<asp:Panel ID="pnAdd" runat="server">
    <div class="m">
        <fieldset>
            <legend>Hoàn tất đánh giá</legend>
            <div class="a">
                <a id="complete"></a>
                <div>
                    <table style="font-weight: bold;">
                        <tr>
                            <td width="50%">
                                số tiêu chuẩn đạt yêu cầu theo VietGAP - Mức độ A: <asp:Label ID="lblDatyeucauA" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucauA" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="50%">
                                Số tiêu chuẩn đạt yêu cầu theo VietGAP - Mức độ B: <asp:Label ID="lblDatyeucauB" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucauB" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="50%">
                                Tổng số tiêu chuẩn đạt yêu cầu theo VietGAP: <asp:Label ID="lblDatyeucau" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucau" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tổng số tiêu chuẩn chưa đạt yêu cầu theo VietGAP: <asp:Label ID="lblChuadatyeucau" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                Tỷ lệ %: <asp:Label ID="lblPhantramchuadatyeucau" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="r" style="text-align: center;">
                    <asp:Button ID="btnOK" CssClass="button" runat="server" Text="Lưu lại" Width="90"
                        OnClick="btnOK_Click" ValidationGroup="adding" Visible="true" />
                    <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Huỷ" Width="90" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Panel>
