<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMasoVietGapQuanLy.ascx.cs"
    Inherits="adminx_ucMasoVietGapQuanLy" %>

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
            <asp:LinkButton ID="btnSearchByID" runat="server" Text="Tìm kiếm" />|
            <asp:LinkButton ID="btnShowAll" runat="server" Text="Hiện toàn bộ" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grvMasoVietGap" runat="server" AutoGenerateColumns="False" OnRowDataBound="grvMasoVietGap_RowDataBound"
                OnSelectedIndexChanging="grvMasoVietGap_SelectedIndexChanging" AllowPaging="True"
                AllowSorting="True" OnPageIndexChanging="grvMasoVietGap_PageIndexChanging" OnSorting="grvMasoVietGap_Sorting"
                AlternatingRowStyle-CssClass="GridAltItem" HeaderStyle-CssClass="GridHeader"
                CssClass="Grid" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn tất">
                        <HeaderTemplate>
                            <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvMasoVietGap','chkDelete');" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkDelete" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PK_iMasoVietGapID" HeaderText="ID" SortExpression="PK_iMasoVietGapID" />
                    <asp:BoundField DataField="sMaso" HeaderText="Mã số" SortExpression="sMaso" />
                    <asp:TemplateField HeaderText="Tổ chức" SortExpression="FK_iTochucchungnhanID">
                        <ItemTemplate>
                            <asp:Label ID="lblTochuc" runat="server" Text='<%# Bind("FK_iTochucchungnhanID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTochuc" runat="server" Text='<%# Bind("FK_iTochucchungnhanID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cơ sở" SortExpression="FK_iCosonuoitrongID">
                        <ItemTemplate>
                            <asp:Label ID="lblCoso" runat="server" Text='<%# Bind("FK_iCosonuoitrongID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCoso" runat="server" Text='<%# Bind("FK_iCosonuoitrongID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="dNgaycap" HeaderText="Ngày cấp" SortExpression="dNgaycap"
                        DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="dNgayhethan" HeaderText="Ngày hết hạn" SortExpression="dNgayhethan"
                        DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="iThoihan" HeaderText="Thời hạn" SortExpression="iThoihan" />
                    <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Sửa" />
                </Columns>
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlEdit" runat="server" Visible="false">
                <div class="m">
                    <fieldset>
                        <legend>Thông tin về mã số VIETGAP</legend>
                        <div class="a">
                            <div class="l">
                                Mã số:</div>
                            <div class="r">
                                <asp:TextBox ID="txtMaso" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="rr">
                            </div>
                        </div>
                        <div class="a">
                            <div class="l">
                                Tổ chức chứng nhận:</div>
                            <div class="r">
                                <asp:DropDownList ID="ddlTochucchungnhan" runat="server" Visible="false">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtTochucchungnhan" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="rr">
                            </div>
                        </div>
                        <div class="a">
                            <div class="l">
                                Tên cơ sở:</div>
                            <div class="r">
                                <asp:DropDownList ID="ddlCosonuoitrong" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="rr">
                            </div>
                        </div>
                        <div class="a">
                            <div class="l">
                                Địa chỉ:</div>
                            <div class="r">
                                <asp:TextBox ID="txtDiachi" runat="server"></asp:TextBox>
                            </div>
                            <div class="rr">
                                <asp:RequiredFieldValidator ID="rfvDiachi" runat="server" ControlToValidate="txtDiachi"
                                    Display="Dynamic" ValidationGroup="MasoVietGapQuanly" ForeColor="Red" Text="*"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="a">
                            <div class="l">
                                Ngày cấp:</div>
                            <div class="r">
                                <asp:TextBox ID="txtNgaycap" runat="server"></asp:TextBox>
                            </div>
                            <div class="rr">
                                <asp:RequiredFieldValidator ID="rfvNgaycap" runat="server" ControlToValidate="txtNgaycap"
                                    Display="Dynamic" ValidationGroup="MasoVietGapQuanly" ForeColor="Red" Text="*"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <div class="a">
                            <div class="l">
                                Thời hạn:</div>
                            <div class="r">
                                <asp:TextBox ID="txtThoihan" runat="server"></asp:TextBox>
                            </div>
                            <div class="rr">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtThoihan"
                                    Display="Dynamic" ValidationGroup="MasoVietGapQuanly" ForeColor="Red" Text="*"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvThoihan" runat="server" ErrorMessage="Thời hạn phải là 12 tháng" ControlToValidate="txtThoihan" Display="Dynamic" SetFocusOnError="true" Text="*"></asp:RangeValidator>
                            </div>
                        </div>
                        <div class="a">
                            <div class="l">
                                Ngày hết hạn:</div>
                            <div class="r">
                                <asp:TextBox ID="txtNgayhethan" runat="server"></asp:TextBox></div>
                            <div class="rr">
                                <asp:RequiredFieldValidator ID="rfvNgayhethan" runat="server" ControlToValidate="txtNgayhethan"
                                    Display="Dynamic" ValidationGroup="MasoVietGapQuanly" ForeColor="Red" Text="*"
                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="a">
                            <div class="l">
                            </div>
                            <div class="r">
                                <asp:ValidationSummary ID="vsMasoVietGap" ValidationGroup="MasoVietGapQuanly" ForeColor="Red"
                                    HeaderText="Phải nhập các trường (*)" runat="server" Font-Names="Times New Roman" />
                            </div>
                            <div class="rr">
                            </div>
                        </div>
                        <div class="a">
                            <div class="l">
                                &nbsp;</div>
                            <div class="r">
                                <asp:Button ID="btnOk" runat="server" Text="Đồng ý" ValidationGroup="MasoVietGapQuanly"
                                    CssClass="button" Width="70" OnClick="btnOk_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Hủy bỏ" ValidationGroup="MasoVietGapQuanly"
                                    CssClass="button" Width="70" OnClick="btnReset_Click" />
                            </div>
                        </div>
                        <div class="a">
                        </div>
                    </fieldset>
                </div>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            |
        </td>
    </tr>
</table>
