<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCosonuoitrongDetail.ascx.cs" Inherits="uc_ucCosonuoitrongDetail" %>
<asp:Panel ID="pnCSNT" runat="server">
    <div class="m">
        <fieldset>
            <legend><asp:Label ID="lblThongTinCoSoNuoiTrong" runat="server" Text="<%$ Resources:Language, lblThongTinCoSoNuoiTrong%>"></asp:Label></legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblTenCoSoNuoiTrong" runat="server" Text="<%$ Resources:Language, lblTenCoSoNuoiTrong%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblTencoso" runat="server" Text=""></asp:Label>
                    
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblTenChuCoSo" runat="server" Text="<%$ Resources:Language, lblTenChuCoSo%>"></asp:Label></div>
                <div class="r">
                   <asp:Label ID="lblChucoso" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                     <asp:Label ID="lblTinhL" runat="server" Text="<%$ Resources:Language, lblTinhL%>"> </asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblTinh" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                     <asp:Label ID="lblQuanHuyenL" runat="server" Text="<%$ Resources:Language, lblQuanHuyenL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblQuanHuyen" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblXaL" runat="server" Text="<%$ Resources:Language, lblXaL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblXa" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                    
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblApL" runat="server" Text="<%$ Resources:Language, lblApL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblAp" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    &nbsp;
                </div>
                <div class="r">
                    
                <button type="button" id="test-ok"><asp:Label ID="lblXemViTriTrenBD" runat="server" Text="<%$ Resources:Language, lblXemViTriTrenBD%>"></asp:Label></button>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblViDoL" runat="server" Text="<%$ Resources:Language, lblViDoL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblVido" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                   <asp:Label ID="lblKinhDoL" runat="server" Text="<%$ Resources:Language, lblKinhDoL%>"> </asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblKinhdo" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblDienThoaiL" runat="server" Text="<%$ Resources:Language, lblDienThoaiL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblDienthoai" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                   <asp:Label ID="lblTongDTCSNuoiTrongL" runat="server" Text="<%$ Resources:Language, lblTongDTCSNuoiTrongL%>"></asp:Label> (m<sup>2</sup>)</div>
                <div class="r">
                    <asp:Label ID="lblTongDienTichCoSoNuoi" runat="server" Text=""></asp:Label>
                    
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblTongDienTichMatNuocL" runat="server" Text="<%$ Resources:Language, lblTongDienTichMatNuocL%>"></asp:Label> (m<sup>2</sup>)</div>
                <div class="r">
                    <asp:Label ID="lblTongdientichmatnuoc" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblDienTichAoLangL" runat="server" Text="<%$ Resources:Language, lblDienTichAoLangL%>"></asp:Label>(m<sup>2</sup>)</div>
                <div class="r">
                    <asp:Label ID="lblDientichAolang" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                </div>
                <div class="r">
                    <asp:Image ID="img" runat="server" Visible="false" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                     <asp:Label ID="lblDoiTuongNuoiL" runat="server" Text="<%$ Resources:Language, lblDoiTuongNuoiL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblDoituongnuoi" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblChuKyNuoiL" runat="server" Text="<%$ Resources:Language, lblChuKyNuoiL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblChukynuoi" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                   <asp:Label ID="lblNamSanXuatL" runat="server" Text="<%$ Resources:Language, lblNamSanXuatL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblNamsanxuat" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblSanLuongDuKienL" runat="server" Text="<%$ Resources:Language, lblSanLuongDuKienL%>"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblSanluongdukien" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <%--<div class="a">
                <div class="l">
                    Mã cơ sở</div>
                <div class="r">
                    <asp:TextBox ID="txtMacoso" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>--%>
            <div class="a">
                <div class="l">
                    &nbsp;
                </div>
                <div class="r">
                    <asp:CheckBox ID="chkKiemduyet" runat="server" Text="<%$ Resources:Language, chkKiemDuyetL%>" />
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
                </div>
            </div>
            <div class="a">
                <div class="l">
                    &nbsp;</div>
                <div class="r">
                    <asp:Button ID="btnDKThongtinCoSoNuoi" runat="server" Text="<%$ Resources:Language, btnDongYL%>" ValidationGroup="register2"
                        Width="90" OnClick="btnDKThongtinCoSoNuoi_Click" />
                </div>
            </div>
            <div class="a">
            </div>
        </fieldset>
    </div>
</asp:Panel>