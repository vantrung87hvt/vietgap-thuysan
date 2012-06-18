<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDanhgiavienManager.ascx.cs"
    Inherits="uc_ucTinh" %>
<link href="../CSS/Grid_View.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function checkAll() {

    }
</script>
<h2>
    Quản Lý Đánh giá viên
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
            <asp:GridView ID="grvDanhgiavien" runat="server" HeaderStyle-CssClass="GridHeader"
                AllowPaging="True" AllowSorting="True" CssClass="Grid" AlternatingRowStyle-CssClass="GridAltItem"
                AutoGenerateColumns="False" OnSorting="grvDanhgiavien_Sorting" OnPageIndexChanging="grvDanhgiavien_PageIndexChanging"
                OnSelectedIndexChanging="grvDanhgiavien_SelectedIndexChanging" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn tất">
                        <HeaderTemplate>
                            <input type="checkbox" style="width: 20px;" id="chkAll" onclick="CheckUncheckall();" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkDelete" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PK_iDanhgiavienID" HeaderText="ID" SortExpression="PK_iDanhgiavienID">
                    </asp:BoundField>
                    <asp:BoundField DataField="sHoten" HeaderText="Họ tên" SortExpression="sHoten"></asp:BoundField>
                    <asp:BoundField DataField="sTrinhdo" HeaderText="Trình độ" SortExpression="sTrinhdo">
                    </asp:BoundField>
                    <asp:BoundField DataField="iNamkinhnghiem" HeaderText="Số năm KN" SortExpression="iNamkinhnghiem">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="TCVN 19011-2003">
                        <ItemTemplate>
                            <asp:Label ID="lblTCVN" Text='<%# BoolToString((bool)DataBinder.GetPropertyValue(Container.DataItem, "bTCVN190112003")) %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ISO 19011-2002">
                        <ItemTemplate>
                            <asp:Label ID="lblISO" Text='<%# BoolToString((bool)DataBinder.GetPropertyValue(Container.DataItem, "bISO190112002")) %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chứng chỉ">
                        <ItemTemplate>
                            <asp:Label ID="lblVietGAP" Text='<%# BoolToString((bool)DataBinder.GetPropertyValue(Container.DataItem, "bVietGapCer")) %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="sMaso" HeaderText="Mã số" SortExpression="sMaso" />
                    <asp:CheckBoxField DataField="bDuyet" Text="Duyệt" />
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
<script language="javascript" type="text/javascript">
    function CheckUncheckall() {
        var chks = document.getElementsByTagName("input");
        var chkAll = document.getElementById("chkAll");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i].type == "checkbox") chks[i].checked = chkAll.checked;
        }
    }
</script>
<asp:Panel ID="pnAdd" runat="server" Visible="false">
    <div class="m">
        <fieldset>
            <legend>Thông tin đánh giá viên</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblItem1" runat="server" Text="Họ và tên"></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtHoten" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Style="margin̉-left: 10px;"
                        runat="server" ControlToValidate="txtHoten" Display="Dynamic" ValidationGroup="adding"
                        ErrorMessage="Không được để trống!" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="Label2" runat="server" Text="Trình độ"></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtTrinhdo" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Style="margin̉-left: 10px;"
                        runat="server" ControlToValidate="txtTrinhdo" Display="Dynamic" ValidationGroup="adding"
                        ErrorMessage="Không được để trống!" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="Label3" runat="server" Text="Số năm kinh nghiệm"></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtSonamkinhnghiem" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Style="margin̉-left: 10px;"
                        runat="server" ControlToValidate="txtSonamkinhnghiem" Display="Dynamic" ValidationGroup="adding"
                        ErrorMessage="Không được để trống!" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="Label4" runat="server" Text="Chứng  chỉ TCVN 19011-2003"></asp:Label></div>
                <div class="r">
                    <asp:CheckBox ID="chkTCVN" runat="server" />
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="Label5" runat="server" Text="Chứng  chỉ ISO 19001-2002"></asp:Label></div>
                <div class="r">
                    <asp:CheckBox ID="chkISO" runat="server" />
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="Label6" runat="server" Text="Chứng  chỉ VietGAP"></asp:Label></div>
                <div class="r">
                    <asp:CheckBox ID="chkVietGAP" runat="server" />
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="Label7" runat="server" Text="Duyệt"></asp:Label></div>
                <div class="r">
                    <asp:CheckBox ID="chkDuyet" runat="server" />
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
