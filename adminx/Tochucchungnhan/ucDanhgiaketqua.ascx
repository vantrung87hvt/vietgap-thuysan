<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDanhgiaketqua.ascx.cs" Inherits="uc_ucTinh" %>
<%@ Import Namespace="System.Data" %>
<link href='<%=ResolveUrl("~/adminx/Tochucchungnhan/css/tccn.css") %>' rel="stylesheet" type="text/css" />
<asp:Panel ID="pnAdd" runat="server">
    <div class="m">
        <fieldset>
            <legend>Kết quả đánh giá</legend>
            <div class="a">
                <a id="complete"></a>
                <div>
                    <table style="font-weight: bold;" id="hor-minimalist-b">
                        <tr>
                            <th>
                                số tiêu chuẩn đạt yêu cầu theo VietGAP - Mức độ A: <asp:Label ID="lblDatyeucauA" runat="server" Text=""></asp:Label>
                            </th>
                            <th>
                                Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucauA" runat="server" Text=""></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                Số tiêu chuẩn đạt yêu cầu theo VietGAP - Mức độ B: <asp:Label ID="lblDatyeucauB" runat="server" Text=""></asp:Label>
                            </th>
                            <th>
                                Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucauB" runat="server" Text=""></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                Tổng số tiêu chuẩn đạt yêu cầu theo VietGAP: <asp:Label ID="lblDatyeucau" runat="server" Text=""></asp:Label>
                            </th>
                            <th>
                                Tỷ lệ %: <asp:Label ID="lblPhantramdatyeucau" runat="server" Text=""></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                Tổng số tiêu chuẩn chưa đạt yêu cầu theo VietGAP: <asp:Label ID="lblChuadatyeucau" runat="server" Text=""></asp:Label>
                            </th>
                            <th>
                                Tỷ lệ %: <asp:Label ID="lblPhantramchuadatyeucau" runat="server" Text=""></asp:Label>
                            </th>
                        </tr>
                    </table>
                </div>
                <div class="r" style="text-align: center;">
                    <asp:Button ID="btnOK" CssClass="button" runat="server" Text="Lưu lại" Width="90"
                        OnClick="btnOK_Click" ValidationGroup="adding" Visible="true" />
                    <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Huỷ" 
                        Width="90" onclick="btnCancel_Click" />
                    <asp:LinkButton ID="ltbnDellAll" OnClick="ltbnDellAll_Click" runat="server" OnClientClick="return confirm('Chắc chắn hủy kết quả?')" >Hủy kết quả đánh giá</asp:LinkButton>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Panel>
<table class="full-wide">
    <tr>
        <td>
            <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Repeater ID="rptDanhmucchitieu" runat="server" 
                OnItemDataBound="rptDanhmucchitieu_ItemDataBound">
                <HeaderTemplate>
                    <table>
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
                        <th colspan="8">
                            <b><%# DataBinder.Eval(Container.DataItem, "sTenchuyenmuc") %></b>
                        </th>
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

