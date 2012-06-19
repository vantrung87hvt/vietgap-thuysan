<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChitietCosonuoitrong.ascx.cs" Inherits="uc_ChitietCosonuoitrong" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/pdfobject.js"></script>
<script src="<%=ResolveUrl("~/uc/js/uc.js")%>" type="text/javascript"></script>
<div style="float: left; margin-left: 10px; width: 100%">
    <asp:Label ID="lblMessage" ForeColor="red" runat="server" />
    <h2 class="label label-orange">
        <asp:Label ID="lblTieude" runat="server" /></h2>
    <table id="hor-minimalist-b" summary="Employee Pay Sheet">
        <thead>
            <tr>
                <th scope="col" colspan="4">                    
                    <asp:Label ID="lblThongTinTaiLieu" runat="server" Text="Thông tin cơ sở nuôi trồng"></asp:Label>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lblMasoL" runat="server" Text="Mã số VietGAP"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMaso" Font-Bold="true" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblSodienthoaiL" runat="server" Text="Số điện thoại"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSodienthoai" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTencosoL" runat="server" Text="Tên cơ sở"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTencoso" Font-Bold="true" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblDiachiL" runat="server" Text="Địa chỉ"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDiachi" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTenchucosoL" runat="server" Text="Chủ cơ sở"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTenchucoso" Font-Bold="true" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblChukynuoiL" runat="server" Text="Chu kỳ nuôi"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblChukynuoi" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTongdientichL" runat="server" Text="Tổng diện tích"></asp:Label>                  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblTongdientich" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblDientichaonuoiL" runat="server" Text="Diện tích ao nuôi"></asp:Label>                        
                </td>
                <td>
                    <asp:Label ID="lblDientichaonuoi" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblHinhthucnuoiL" runat="server" Text="Hình thức nuôi"></asp:Label>  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblHinhthucnuoi" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblSanluongdukienL" runat="server" Text="Sản lượng dự kiến"></asp:Label>  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblSanluongdukien" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Sơ đồ ao nuôi
                </td>
                <td colspan="2">
                    <asp:Image ID="imgSodo" CssClass="imgSodo" runat="server" />
                </td>
            </tr>
            
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </tbody>
    </table>
</div>
