<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDanhsachTCCNChitiet.ascx.cs" Inherits="uc_ucDanhsachTochucchungnhan" %>
<h1><span class="green">
    <asp:Label ID="lblTieude" runat="server" 
        Text="Danh sách các tổ chức chứng nhận"></asp:Label>
</span></h1>
<div class="header">
<table id="hor-minimalist-b">
    <tr>
        <td><asp:Label ID="lblThongTinTaiKhoanL" runat="server" 
                Text="<%$ Resources:Language, lblMasoTochucchungnhanL %>"></asp:Label></td>
        <td><asp:TextBox ID="txtMasoVietGAP" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblTentochucL" runat="server" Text="<%$ Resources:Language, lblTentochucL%>"></asp:Label></td>
        <td><asp:TextBox ID="txtTencoso" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblTinhL" runat="server" Text="<%$ Resources:Language, lblTinhL%>"></asp:Label></td>
        <td><asp:DropDownList ID="ddlTinh" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnXem" runat="server" Text="<%$ Resources:Language, lblXemL%>" onclick="btnXem_Click" /></td>
    </tr>
</table>
</div>
<div class="section-content">
    <asp:Repeater ID="rptTochucchungnhan" runat="server" 
        onitemdatabound="rptTochucchungnhan_ItemDataBound">
        <HeaderTemplate>
        <table id="hor-minimalist-b" summary="Danh sach To chuc chung nhan">
        <thead>
            <tr>
                <th scope="col">
                    <asp:Label ID="lblSTTL" runat="server" Text="<%$ Resources:Language, lblSTTL%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="lblTentochucL" runat="server" Text="<%$ Resources:Language, lblTentochucL%>"></asp:Label>
                </th>
                <th scope="col">
                     <asp:Label ID="lblDiaChiL" runat="server" Text="<%$ Resources:Language, lblDiaChiL%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="lblDienthoai" runat="server" Text="<%$ Resources:Language, lblDienThoai%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Language, lblMasoTochucchungnhanTieude%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Language, lblTrangThaiL%>"></asp:Label>
                </th>
            </tr>
        </thead>
        <tbody>
        </HeaderTemplate>
        <ItemTemplate>
               
                <tr>
                    <td>
                        <%#rptTochucchungnhan.Items.Count + 1%>
                    </td>
                    <td>
                        <asp:HyperLink ID="hypTochucchungnhan" runat="server">
                            <asp:Label ID="lblTochucchungnhan" runat="server" Text='<%#Eval("sTochucchungnhan")%>' />
                        </asp:HyperLink>
                        <asp:Label ID="lblTCCNID" runat="server" Text='<%#Eval("PK_iTochucchungnhanID")%>' Visible="false"/>
                    </td>
                    <td>
                        <asp:Label ID="lblDiachi" runat="server" Text='<%#Eval("FK_iQuanHuyenID")%>' />
                    </td>
                    <td>
                        <asp:Label ID="lblSodienthoai" runat="server" Text='<%#Eval("sSodienthoai")%>'/>
                    </td>
                    <td>
                        <asp:Label ID="lblMasovietgap" runat="server" Text='<%#Eval("sMaso")%>'/>
                    </td>
                    <td>
                        <asp:Label ID="lblTrangthai" runat="server" Text='<%#Eval("PK_iTochucchungnhanID")%>'/>
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
        <%#rptTochucchungnhan.Items.Count + 1%>
        <asp:LinkButton ID="lbnNext" runat="server" onclick="lbnNext_Click"><asp:Label ID="Label3" runat="server" Text="<%$ Resources:Language, lblNextPage%>"></asp:Label></asp:LinkButton>
    </div>
</div>