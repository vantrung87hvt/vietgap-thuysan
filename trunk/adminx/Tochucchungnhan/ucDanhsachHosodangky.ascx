<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDanhsachHosodangky.ascx.cs" Inherits="uc_ucDanhsachHosodangky" %>
<%@ Register Src="ucBaocaodanhgianoibo.ascx" TagName="ucBaocaodanhgianoibo" TagPrefix="uc" %>
<link href='<%=ResolveUrl("~/adminx/Tochucchungnhan/css/tccn.css") %>' rel="stylesheet" type="text/css" />
<h1>
    <span class="green">
        Danh sách các cơ sở nuôi trồng đăng ký
    </span>
</h1>
<div class="header">
</div>
<div class="section-content">
    <asp:Repeater ID="rptCosonuoitrong" runat="server" 
        onitemdatabound="rptCosonuoitrong_ItemDataBound" 
        onitemcommand="rptCosonuoitrong_ItemCommand">
        <HeaderTemplate>
        <table class="full-wide">
        <thead>
            <tr>
                <th scope="col">
                    <asp:Label ID="lblSTTL" runat="server" Text="<%$ Resources:Language, lblSTTL%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="lblCoSoNuoiTrong" runat="server" Text="<%$ Resources:Language, lblCoSoNuoiTrong%>"></asp:Label>
                </th>
                <th scope="col">
                     <asp:Label ID="lblChuSoHuu" runat="server" Text="<%$ Resources:Language, lblChuSoHuu%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="lblDiaChiL" runat="server" Text="<%$ Resources:Language, lblDiaChiL%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="Label1" runat="server" Text="Ngày đăng ký"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="Label4" runat="server" Text="Lần đăng ký"></asp:Label>
                </th>
                <th>
                    Tác vụ
                </th>
            </tr>
        </thead>
        <tbody>
        </HeaderTemplate>
        <ItemTemplate>
               
                <tr>
                    <td>
                        <%#rptCosonuoitrong.Items.Count + 1%>
                    </td>
                    <td>
                        <asp:Label ID="lblCosonuoi" runat="server" Text='<%#Eval("FK_iCosonuoiID")%>' />
                    </td>
                    <td>
                        <asp:Label ID="lblChusohuu" runat="server" Text='<%#Eval("FK_iCosonuoiID")%>' />
                    </td>
                    <td>
                        <asp:Label ID="lblHuyenID" runat="server" Text='<%#Eval("FK_iCosonuoiID")%>'/>
                    </td>
                    <td>
                        <asp:Label ID="lblNgaydangky" runat="server" Text='<%#DateTime.Parse(Eval("dNgaydangky").ToString()).ToString("dd/MM/yyyy")%>'/>
                    </td>
                    <td>
                        <asp:Label ID="lblLandangky" runat="server" Text='<%#Boolean.Parse(Eval("bLandau").ToString()) == true ? "Lần đầu" : "Đăng ký lại"%>'/>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbtnDanhgianoibo" CommandName="Danhgianoibo" CommandArgument='<%#Eval("FK_iCosonuoiID")%>' runat="server">KQ đánh giá nội bộ</asp:LinkButton>|
                        <asp:LinkButton ID="lbtnGiaytokemtheo" CommandName="Giaytokemtheo" CommandArgument='<%#Eval("PK_iHosodangkychungnhanID")%>' runat="server">Giấy tờ nộp kèm</asp:LinkButton>|
                        <asp:LinkButton ID="lbtnCapmaso" CommandName="Capmaso" CommandArgument='<%#Eval("PK_iHosodangkychungnhanID")%>' runat="server">Cấp mã số VietGAP</asp:LinkButton>
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="dvFooter">
        <asp:LinkButton ID="lbnPrev" runat="server" onclick="lbnPrev_Click"> <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Language, lblPreviousPage%>"></asp:Label></asp:LinkButton>&nbsp;
        <asp:LinkButton ID="lbnNext" runat="server" onclick="lbnNext_Click"><asp:Label ID="Label3" runat="server" Text="<%$ Resources:Language, lblNextPage%>"></asp:Label></asp:LinkButton>
    </div>
</div>
<asp:Panel runat="server" ID="panGiaytonopkem" Visible="false">
    <fieldset>
        <legend>Giấy tờ nộp kèm hồ sơ</legend>
        <asp:Label runat="server" ID="lblThongbao" ForeColor="Red"></asp:Label>
        <asp:CheckBoxList ID="cblGiaytonopkem" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="btnLuuGiaytonopkem" runat="server" Text="Lưu" 
            onclick="btnLuuGiaytonopkem_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnHuygiaytonopkem" runat="server" Text="Ẩn" 
            onclick="btnHuygiaytonopkem_Click" />
    </fieldset>
</asp:Panel>
<asp:Panel runat="server" ID="panCapmaso" Visible="false">
    <fieldset>
        <legend>Hồ sơ đăng ký hộ nuôi trồng thủy sản</legend>
            <asp:PlaceHolder runat="server" ID="phCapmasoContent"></asp:PlaceHolder><br />
            <fieldset>
                <legend>Thời hạn chứng nhận</legend>
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
                <center>
                    <asp:Button ID="btnCapmaso" runat="server" Text="Cấp mã số" 
                        onclick="btnCapmaso_Click" Enabled="false"/>&nbsp;|&nbsp;
                    <asp:Button ID="btnAncapmaso" runat="server" Text="Ẩn" 
                        onclick="btnAncapmaso_Click" />
                </center>
            </fieldset>
    </fieldset>
</asp:Panel>