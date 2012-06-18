<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucGiahanGiayphepVietGap.ascx.cs"
    Inherits="adminx_ucGiahanGiayphepVietGap" %>
<script type="text/javascript">

    function addMonth() {
        var currDate = document.getElementById('<%=txtNgaygiahan_datepicker.ClientID%>').value.split('/');
        var currDay = currDate[0];
        var currMonth = currDate[1];
        var currYear = currDate[2];
        var txtThoihan = document.getElementById('<%=txtThoigiangiahan.ClientID%>');
        if (parseInt(txtThoihan) > 4) {
            alert('Không được gia hạn quá 4 tháng');
            return false;
        }
        currDateStr = currMonth + "/" + currDay + "/" + currYear;

        var ModMonth = parseInt(currMonth) + parseInt(txtThoihan.value);
        if (ModMonth > 12) {
            var YearNext = 0;
            if (ModMonth % 12 == 0)
                YearNext = parseInt(ModMonth / 12) - 1;
            else
                YearNext = parseInt(ModMonth / 12)
            ModMonth = ModMonth % 12;
            if (ModMonth == 0) {
                ModMonth = currMonth;
            }
            currYear = parseInt(currYear) + YearNext;
        }
        ModDateStr = currDay + "/" + ModMonth + "/" + currYear;
        document.getElementById('<%=lblNgayhethan.ClientID%>').innerHTML = ModDateStr;
    }
</script>
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
                    <asp:ButtonField CommandName="Select" HeaderText="Gia hạn" ShowHeader="True" 
                        Text="Gia hạn" />
                </Columns>
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlGiahan" runat="server" Visible="false">
            <div class="m">
                <fieldset>
                    <legend>Gia hạn giấy phép VIỆT G.A.P</legend>
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
                            Ngày gia hạn:</div>
                        <div class="r">
                            <input id="txtNgaygiahan_datepicker" class="required" type="text" runat="server" />
                        </div>
                        <div class="rr">
                            <asp:RequiredFieldValidator ID="rfvNgaygiahan" runat="server" ControlToValidate="txtNgaygiahan_datepicker"
                                Display="Dynamic" ValidationGroup="rGiahangiayphep" Text="*" ForeColor="Red"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="a">
                        <div class="l">
                            Gia hạn (tháng):</div>
                        <div class="r">
                            <asp:TextBox ID="txtThoigiangiahan" runat="server"></asp:TextBox>
                            đến:&nbsp;<asp:Label ID="lblNgayhethan" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="rr">
                            <asp:RequiredFieldValidator ID="rfvThoigiangiahan" runat="server" ControlToValidate="txtThoigiangiahan"
                                Display="Dynamic" ValidationGroup="rGiahangiayphep" Text="*" ForeColor="Red"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="a">
                        <div class="l">
                            Sản lượng dự kiến mới:</div>
                        <div class="r">
                            <asp:TextBox ID="txtSanLuongMoi" runat="server"></asp:TextBox>
                        </div>
                        <div class="rr">
                            <asp:RequiredFieldValidator ID="rfvSanluongmoi" runat="server" ControlToValidate="txtSanLuongMoi"
                                Display="Dynamic" ValidationGroup="rGiahangiayphep" Text="*" ForeColor="Red"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="a">
                        <div class="l">
                            Diện tích mở rộng:</div>
                        <div class="r">
                            <asp:TextBox ID="txtDienTichMoi" runat="server"></asp:TextBox>
                        </div>
                        <div class="rr">
                            <asp:RequiredFieldValidator ID="rfvDientichmoi" runat="server" ControlToValidate="txtDienTichMoi"
                                Display="Dynamic" ValidationGroup="rGiahangiayphep" Text="*" ForeColor="Red"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="a">
                        <div class="l">
                            &nbsp;</div>
                        <div class="r">
                            <asp:Button ID="btnOK" runat="server" Text="Đồng ý" OnClick="btnOK_Click" 
                                ValidationGroup="vsGiahangiayphep" />
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Hủy" />
                        </div>
                        <div class="rr">
                        </div>
                    </div>
                    <div class="a">
                        <div class="l">
                        </div>
                        <div class="r">
                        </div>
                        <div class="rr">
                            <asp:ValidationSummary ID="vsGiahangiayphep" ValidationGroup="rGiahangiayphep" ForeColor="Red"
                                HeaderText="Phải nhập các trường (*)" runat="server" />
                        </div>
                    </div>
                </fieldset>
            </div>
            </asp:Panel>
        </td>
    </tr>
</table>
