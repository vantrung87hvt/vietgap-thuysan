<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCapmasoVietGap.ascx.cs" Inherits="adminx_ucCapmasoVietGap" %>
<%@ Register Src="../UserMethods/ucBaocaodanhgianoibo.ascx" TagName="ucBaocaodanhgianoibo" TagPrefix="uc1" %>
<%@ Register Src="~/UserMethods/ucDanhgiaketqua.ascx" TagName="ucDanhgiaketqua" TagPrefix="uc2" %>
<script type="text/javascript">
    function addMonth() {
        var currDate = document.getElementById('<%=txtNgaycap_datepicker.ClientID%>').value.split('/');
        var currDay = currDate[0];
        var currMonth = currDate[1];
        var currYear = currDate[2];
        var txtThoihan = document.getElementById('<%=txtThoihan.ClientID%>');
        if (parseInt(txtThoihan) > 4) {
            alert('Không được gia hạn quá 4 tháng');
            return false;
        }
        currDateStr = currMonth + "/" + currDay + "/" + currYear;

        var ModMonth = parseInt(currMonth) + parseInt(txtThoihan.value);
        if (ModMonth > 12) {
            ModMonth = 1;
            currYear = parseInt(currYear) + 1;
        }

        ModDateStr = currDay + "/" + ModMonth + "/" + currYear;
        document.getElementById('<%=txtNgayhethan_datepicker.ClientID%>').value = ModDateStr;
    }
    function validate(content) {
        if (isNaN(content) == true) {
            alert('Hãy nhập số tháng!');
            return false;
        }
        else
            return true;
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
            <asp:GridView ID="grvHosodangkychungnhan" runat="server" AutoGenerateColumns="False"
                OnRowDataBound="grvCosonuoitrong_RowDataBound" AllowPaging="True" AllowSorting="True"
                OnPageIndexChanging="grvCosonuoitrong_PageIndexChanging" OnSorting="grvCosonuoitrong_Sorting"
                AlternatingRowStyle-CssClass="GridAltItem" HeaderStyle-CssClass="GridHeader"
                CssClass="Grid" EnableModelValidation="True" OnSelectedIndexChanging="grvCosonuoitrong_SelectedIndexChanging">
                <Columns>
                    <asp:BoundField DataField="PK_iHosodangkychungnhanID" HeaderText="ID" SortExpression="PK_iHosodangkychungnhanID" />
                    <asp:TemplateField HeaderText="Cơ sở nuôi">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCosonuoi" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Địa chỉ">
                        <ItemTemplate>
                            <asp:Label ID="lblTinhthanh" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTinhthanh" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tổng dt">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTongdientich" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sản lượng">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSanluong" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Đối tượng nuôi">
                        <ItemTemplate>
                            <asp:Label ID="lblDoituongnuoi" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDoituongnuoi" runat="server" Text='<%# Bind("FK_iCosonuoiID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="PK_iHosodangkychungnhanID, FK_iCosonuoiID"
                        Text="Duyệt" DataNavigateUrlFormatString="Default.aspx?page=CapmasoVietGap&amp;PK_iHosodangkychungnhanID={0}&amp;FK_iCosonuoiID={1}" />
                </Columns>
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
                <PagerStyle HorizontalAlign="Right" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnThongtinCosonuoitrong" runat="server" Visible="false">
                <div class="grid_12">
                    <div class="block-border" id="tab-panel-2">
                        <div class="block-header">
                            <h3>
                                Thông tin Hộ nuôi trồng Thủy sản
                            </h3>
                            <ul class="tabs">
                                <li class="active"><a href="#thongtinchung">Kết quả đánh giá nội bộ</a></li>
                                <li><a href="#giaytokemtheo">Giấy tờ kèm theo</a></li>
                                <li><a href="#danhgia">Đánh giá nội bộ</a></li>
                                <li><a href="#bangdanhgia">Bảng đánh giá nội bộ</a></li>
                            </ul>
                        </div>
                        <div class="block-content tab-container">
                            <table style="font-weight: bold;">
                            </table>
                            <div id="thongtinchung" class="tab-content" style="display: block;">
                                <div class="m">
                                    <fieldset>
                                        <div class="a">
                                            <div class="l">
                                                <asp:Label ID="lblMucdoA" runat="server" Text="Số tiêu chuẩn đạt yêu cầu theo VietGAP - Mức độ A"></asp:Label></div>
                                            <div class="r">
                                                <asp:Label ID="lblDatyeucauA" runat="server" Text=""></asp:Label></div>
                                            <div class="rr">
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                <asp:Label ID="lblTile" runat="server" Text="Tỉ lệ (%):"></asp:Label>
                                            </div>
                                            <div class="r">
                                                <asp:Label ID="lblPhantramdatyeucauA" runat="server"></asp:Label>
                                            </div>
                                            <div class="rr">
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                <asp:Label ID="lblMucdoB" runat="server" Text="Số tiêu chuẩn đạt yêu cầu theo VietGAP - Mức độ B:"></asp:Label>
                                            </div>
                                            <div class="r">
                                                <asp:Label ID="lblDatyeucauB" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="rr">
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                <asp:Label ID="lblTileB" runat="server" Text="Tỉ lệ (%):"></asp:Label>
                                            </div>
                                            <div class="r">
                                                <asp:Label ID="lblPhantramdatyeucauB" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="rr">
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                <asp:Label ID="lblTongso" runat="server" Text="Tổng số tiêu chuẩn đạt yêu cầu theo VietGAP:"></asp:Label>
                                            </div>
                                            <div class="r">
                                                <asp:Label ID="lblDatyeucau" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="rr">
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                <asp:Label ID="lblTongTile" runat="server" Text="Tỷ lệ (%):"></asp:Label>
                                            </div>
                                            <div class="r">
                                                <asp:Label ID="lblPhantramdatyeucau" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="rr">
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                <asp:Label ID="lblChuadat" runat="server" Text="Tổng số tiêu chuẩn chưa đạt yêu cầu theo VietGAP:"></asp:Label>
                                            </div>
                                            <div class="r">
                                                <asp:Label ID="lblChuadatyeucau" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="rr">
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                <asp:Label ID="lblTongtileChuadat" runat="server" Text="Tỷ lệ (%):"></asp:Label>
                                            </div>
                                            <div class="r">
                                                <asp:Label ID="lblPhantramchuadatyeucau" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="rr">
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                Ngày cấp:</div>
                                            <div class="r">
                                                <input id="txtNgaycap_datepicker" class="required" type="text" runat="server" />
                                            </div>
                                            <div class="rr">
                                                <asp:RequiredFieldValidator ID="rfvNgaycap" runat="server" ControlToValidate="txtNgaycap_datepicker"
                                                    Display="Dynamic" ValidationGroup="Capphep" Text="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                Thời hạn:</div>
                                            <div class="r">
                                                <input id="txtThoihan" class="required" type="text" runat="server" />
                                                &nbsp;(tháng)</div>
                                            <div class="rr">
                                                <asp:RequiredFieldValidator ID="rfvThoihan" runat="server" ControlToValidate="txtThoihan"
                                                    Display="Dynamic" ValidationGroup="Capphep" ForeColor="Red" Text="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                                Ngày hết hạn:</div>
                                            <div class="r">
                                                <input id="txtNgayhethan_datepicker" class="required" type="text" runat="server" />
                                            </div>
                                            <div class="rr">
                                                <asp:RequiredFieldValidator ID="rfvNgayhethan" runat="server" ControlToValidate="txtNgayhethan_datepicker"
                                                    Display="Dynamic" ValidationGroup="Capphep" ForeColor="Red" Text="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="a">
                                            <div class="l">
                                            </div>
                                            <div class="r">
                                                <asp:ValidationSummary ID="vsCapmasoVietGap" ValidationGroup="Capphep" ForeColor="Red"
                                                    HeaderText="Phải nhập các trường (*)" runat="server" Font-Names="Times New Roman" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                            <div id="giaytokemtheo" class="tab-content" style="display: none;">
                                <div class="m">
                                    <fieldset>
                                        <asp:Repeater ID="rptHoSoKemTheo" runat="server" OnItemDataBound="rptHoSoKemTheo_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="a">
                                                    <div class="l">
                                                        <asp:Label ID="FK_iGiaytoID" runat="server" Text='<%#Eval("FK_iGiaytoID")%>' Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="r" style="width: 90%;">
                                                        -
                                                        <asp:Label ID="lblTenGiayTo" runat="server" Text=""></asp:Label>
                                                    </div>
                                                    <div class="rr">
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <div class="a">
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                            <div id="danhgia" class="tab-content" style="display: none;">
                                <uc1:ucBaocaodanhgianoibo ID="ucBaocaodanhgianoibo1" runat="server" />
                            </div>
                            <div id="bangdanhgia" class="tab-content" style="display: none;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:PlaceHolder ID="phlBangdanhgianoibo" runat="server"></asp:PlaceHolder>            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnXem" runat="server" Text="Xem bảng đánh giá nội bộ" 
                                                onclick="btnXem_Click" />
                                        </td>
                                    </tr>
                                </table>
                                
                            </div>
                        </div>
                        
                    </div>
                    <div style="text-align: center; width: 100%; padding: 15px;">
                        <asp:Button ID="btnCapPhep" runat="server" Text="Cấp phép" OnClick="btnCapPhep_Click" />
                    </div>
                </div>
                <br />
            </asp:Panel>
        </td>
    </tr>
</table>
