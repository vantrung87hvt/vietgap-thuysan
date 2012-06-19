<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DocDetail.ascx.cs" Inherits="uc_DocDetail" %>
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
                    <asp:Label ID="lblThongTinTaiLieu" runat="server" Text="<%$ Resources:Language, lblThongTinTaiLieu%>"></asp:Label>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lblSoKyHieuL" runat="server" Text="<%$ Resources:Language, lblSoKyHieu%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSokyhieu" Font-Bold="true" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblLoaiTaiLieuL" runat="server" Text="<%$ Resources:Language, lblLoaiTaiLieu%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLoaitailieu" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCQBanHanhL" runat="server" Text="<%$ Resources:Language, lblCQBanHanh%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCoquanbanhanh" Font-Bold="true" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblNgayDangL" runat="server" Text="<%$ Resources:Language, lblNgayDang%>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblNgaydang" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTacGiaL" runat="server" Text="<%$ Resources:Language, lblTacGia%>"></asp:Label>                  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblTacgia" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblNgayBanHanhL" runat="server" Text="<%$ Resources:Language, lblNgayBanHanh%>"></asp:Label>                        
                </td>
                <td>
                    <asp:Label ID="lblNgaybanhanh" Font-Bold="true" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDangCongBaoL" runat="server" Text="<%$ Resources:Language, lblDangCongBao%>"></asp:Label>  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblNgaydangcongbao" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblHieuLucDenL" runat="server" Text="<%$ Resources:Language, lblHieuLucDen%>"></asp:Label>  
                </td>
                <td>
                    <asp:Label Font-Bold="true" ID="lblNgayhethieuluc" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <em>
                        <asp:Label ID="lblTomTatNoiDungL" runat="server" Text="<%$ Resources:Language, lblTomTatNoiDung%>"></asp:Label>  
                        <asp:Label ID="lblNoidung" runat="server" /></em>
                </td>
            </tr>
        </tbody>
    </table>
    <p class="post-footer align-right">
        <a href="#" id="example-show" class="showLink"   onclick="showHide('example');return false;">
            <asp:Label ID="lblNoiDungL" runat="server" Text="<%$ Resources:Language, noidung%>"></asp:Label>
        </a>

            <a href="#" id="example-hide" class="hideLink" 
	onclick="showHide('example');return false;"><asp:Label ID="lblAnNoiDung" runat="server" Text="<%$ Resources:Language, lblAnNoiDung%>"></asp:Label></a>
        <asp:HyperLink ID="lnkDownload" runat="server">
            <asp:Image ID="imgDownload" runat="server" ImageUrl="~/Images/page_down.gif" />
            <asp:Label ID="lblDownload" runat="server" />
        </asp:HyperLink>
        <span class="date"></span>
    </p>
    <div class="col3-mid left">
        <div id="example" class="more">
            <div id="viewdoc" style="width: 740px; height: 710px; overflow:scroll;">
                <asp:Literal ID="ltView" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div style="clear: both">
    </div>
</div>
