<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTochucchungnhanChitiet.ascx.cs" Inherits="uc_ucTochucchungnhanChitiet" %>

<div style="float: left; margin-left: 10px; width: 100%">
    <asp:Label ID="lblMessage" ForeColor="red" runat="server" />
    <h2 class="label label-orange">
        <asp:Label ID="lblTieude" runat="server" /></h2>
    <table id="hor-minimalist-b" summary="Employee Pay Sheet">
        <thead>
            <tr>
                <th scope="col" colspan="4">                    
                    <asp:Label ID="lblThongTinTaiLieu" runat="server" Text="Thông tin chi tiết về Tổ chức chứng nhận"></asp:Label>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lblTochucchungnhanL" runat="server" Text="<%$ Resources:Language, lblTochucchungnhanL%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTochucchungnhan" Font-Bold="true" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblMasoTochucchungnhanL" runat="server" Text="<%$ Resources:Language, lblMasoTochucchungnhanTieude%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMasoTochucchungnhan" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDiachiL" runat="server" Text="<%$ Resources:Language, lblDiachiL%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDiachi" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDienthoaiL" runat="server" Text="<%$ Resources:Language, lblDienthoaiL%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDienthoai" Font-Bold="true" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblEmailL" runat="server" Text="<%$ Resources:Language, lblEmailL%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmail" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSodangkyKinhdoanhL" runat="server" Text="<%$ Resources:Language,lblSodangkyKinhdoanhL%>"></asp:Label>                  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblSodangkyKinhdoanh" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblCoquancapDangkyKinhdoanhL" runat="server" Text="<%$ Resources:Language, lblCoquancapDangkyKinhdoanhL%>"></asp:Label>                        
                </td>
                <td>
                    <asp:Label ID="lblCoquancapDangkyKinhdoanh" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTrangthaiL" runat="server" Text="<%$ Resources:Language, lblTrangthaiL%>"></asp:Label>  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblTrangthai" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblCoquanQuanlyCaptrenL" runat="server" Text="<%$ Resources:Language, lblCoquanQuanlyCaptrenL%>"></asp:Label>  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblCoquanQuanlyCaptren" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Logo
                </td>
                <td colspan="2">
                    <asp:Image ID="imgLogo" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:HyperLink ID="hypDangkyTaikhoanChungnhan" runat="server" 
                        NavigateUrl="../Content.aspx?mode=uc&page=Dangky">Đăng ký để được cấp chứng nhận VietGAP với tổ chức này</asp:HyperLink>
                </td>
            </tr>
        </tbody>
    </table>
</div>
