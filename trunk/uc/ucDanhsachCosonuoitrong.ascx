<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDanhsachCosonuoitrong.ascx.cs" Inherits="uc_ucDanhsachCosonuoitrong" %>
<h1><span class="green">
    <asp:Label ID="lblTieude" runat="server" Text="Danh sách các cơ sở nuôi trồng"></asp:Label>
</span></h1>
<div class="header">
<asp:Panel ID="pnlTracuu" runat="server" Visible="false">
<table id="hor-minimalist-b">
    <tr>
        <td><asp:Label ID="lblThongTinTaiKhoanL" runat="server" Text="<%$ Resources:Language, lblMaSoVietGapL%>"></asp:Label></td>
        <td><asp:TextBox ID="txtMasoVietGAP" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblTenCoSoL" runat="server" Text="<%$ Resources:Language, lblTenCoSoL%>"></asp:Label></td>
        <td><asp:TextBox ID="txtTencoso" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblTinhL" runat="server" Text="<%$ Resources:Language, lblTinhL%>"></asp:Label></td>
        <td><asp:DropDownList ID="ddlTinh" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblDoiTuongNuoiL" runat="server" Text="<%$ Resources:Language, lblDoiTuongNuoiL%>"></asp:Label></td>
        <td><asp:DropDownList ID="ddlDoituongnuoi" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnXem" runat="server" Text="<%$ Resources:Language, lblXemL%>" onclick="btnXem_Click" /></td>
    </tr>
</table>
</asp:Panel>
</div>
<div class="section-content">
    <asp:Repeater ID="rptCosonuoitrong" runat="server" 
        onitemdatabound="rptCosonuoitrong_ItemDataBound">
        <HeaderTemplate>
        <table id="hor-minimalist-b" summary="Document List">
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
                    
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Language, lblMaSoVietGapL%>"></asp:Label>
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
                        <%#rptCosonuoitrong.Items.Count + 1%>
                    </td>
                    <td>
                        <asp:Label ID="lblCosonuoi" runat="server" Text='<%#Eval("sTencoso")%>' />
                    </td>
                    <td>
                        <asp:Label ID="lblChusohuu" runat="server" Text='<%#Eval("sTenchucoso")%>' />
                    </td>
                    <td>
                        <asp:Label ID="lblHuyenID" runat="server" Text='<%#Eval("FK_iQuanHuyenID")%>'/>
                    </td>
                    <td>
                        <%--<asp:Label ID="lblMasovietgap" runat="server" Text='<%#Eval("sMaso_vietgap")%>'/>--%>
                        <a target="_parent" href='<%# ResolveUrl("~/Content.aspx?CosonuoitrongID=") + Eval("PK_iCosonuoitrongID") %>'><%# Eval("sMaso_Vietgap") %></a>
                    </td>
                    <td>
                        <asp:Label ID="lblTrangthai" runat="server" Text='<%#Eval("PK_iCosonuoitrongID")%>'/>
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
        <%--<asp:HyperLink ID="lnkPrev" runat="server" Text="[Trang trước]" />&nbsp;
                    <asp:HyperLink ID="lnkNext" runat="server" Text="[Trang sau]" />--%>
        <asp:LinkButton ID="lbnNext" runat="server" onclick="lbnNext_Click"><asp:Label ID="Label3" runat="server" Text="<%$ Resources:Language, lblNextPage%>"></asp:Label></asp:LinkButton>
    </div>
</div>