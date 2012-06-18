<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucContactManager.ascx.cs"
    Inherits="uc_ucTinh" %>
<link href="../CSS/Grid_View.css" rel="stylesheet" type="text/css" />

<h2>
    Quản Lý Thông Tin Liên Hệ
</h2>
<table style="width: 100%; margin-top: 20px; height: auto;">
    <tr>
        <td width="100%">
            <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
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
            <asp:GridView ID="grvContact" runat="server" HeaderStyle-CssClass="GridHeader" AllowPaging="True"
                AllowSorting="True" CssClass="Grid" AlternatingRowStyle-CssClass="GridAltItem"
                AutoGenerateColumns="False" OnSorting="grvContact_Sorting" OnPageIndexChanging="grvContact_PageIndexChanging"
                OnSelectedIndexChanging="grvContact_SelectedIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn tất">
                        <HeaderTemplate>
                            <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvContact','chkDelete');" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkDelete" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PK_iContactID" HeaderText="ID" SortExpression="PK_iContactID">
                    </asp:BoundField>
                    <asp:BoundField DataField="sHoTen" HeaderText="Họ tên" SortExpression="sHoTen"></asp:BoundField>
                    <asp:BoundField DataField="sDienThoai" HeaderText="Điện thoại" SortExpression="sDienThoai">
                    </asp:BoundField>
                    <asp:BoundField DataField="sEmail" HeaderText="Fax" SortExpression="sEmail"></asp:BoundField>
                    <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Sửa">
                    </asp:ButtonField>
                </Columns>
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="lbtnAdd" runat="server" CausesValidation="false" OnClick="lbtnAdd_Click">Thêm mới | </asp:LinkButton>
            <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click"
                OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>
        </td>
    </tr>
</table>
<asp:Panel ID="pnAdd" runat="server" Visible="false">
    <div class="m">
        <fieldset>
            <legend>Thông tin liên hệ</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblContact" runat="server" Text="Họ tên"></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtHoTen" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Style="margin̉-left: 10px;"
                        runat="server" ControlToValidate="txtHoTen" Display="Dynamic" ValidationGroup="adding"
                        ErrorMessage="Không được để trống!" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblPhongBan" runat="server" Text="Phòng"></asp:Label></div>
                <div class="r">
                    <asp:DropDownList ID="ddlPhong" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblChucVu" runat="server" Text="Chức Vụ"></asp:Label></div>
                <div class="r">
                    <asp:DropDownList ID="ddlChucVu" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblDienThoai" runat="server" Text="Điện thoại"></asp:Label>
                </div>
                <div class="r">
                    <asp:TextBox ID="txtDienThoai" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Style="margin̉-left: 10px;"
                        runat="server" ControlToValidate="txtDienThoai" Display="Dynamic" ValidationGroup="adding"
                        ErrorMessage="Không được để trống!" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </div>
                <div class="r">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Style="margin̉-left: 10px;"
                        runat="server" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="adding"
                        ErrorMessage="Không được để trống!" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                </div>
                <div class="r">
                    <asp:Button ID="btnOK" CssClass="button" runat="server" Text="Thêm" Width="90" OnClick="btnOK_Click"
                        ValidationGroup="adding" Visible="true" />
                    <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Huỷ" Width="90"
                        OnClick="btnCancel_Click" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
            </div>
        </fieldset>
    </div>
</asp:Panel>
