<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDanhgiaketqua.ascx.cs" Inherits="uc_ucTinh" %>
<%@ Import Namespace="System.Data" %>
<link href="../CSS/Grid_View.css" rel="stylesheet" type="text/css" />
<style stype="text/css">
    .label-orange
    {
        border-left-color: #FA8F6F;
    }
     #hor-minimalist-b
    {
        font-size: 12px;
        background: #fff;
        margin-left:30px;
        margin-top: 5px;
        width: 90%;
        border-collapse: collapse;
        text-align: left;
    }
    #hor-minimalist-b th
    {
        font-size: 12px;
        font-weight: normal;
        color: #039;
        padding: 8px 6px;
        border-bottom: 2px solid #6678b1;
    }
    #hor-minimalist-b td
    {
        border-bottom: 1px solid #ccc;
        padding: 4px 6px;
    }
    
    #hor-minimalist-b td *
    {
        font-size: 12px;
        color: #669;
    }
    #hor-minimalist-b tr:hover td
    {
        color: #009;
    }
</style>
<h2>
    Kết quả đánh giá nội bộ:
</h2>
<table id="hor-minimalist-b">
    <tr>
        <td>
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
                    <table id="hor-minimalist-b">
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
                    <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Huỷ" Width="90" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Panel>
