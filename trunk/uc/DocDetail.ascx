<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DocDetail.ascx.cs" Inherits="uc_DocDetail" %>
<style type="text/css">
    .dvTailieu
    {
        clear: both;
        margin-top: 10px;
        margin-bottom: 10px;
        width: 100%;
    }
    
    .label
    {
        border-left-style: solid;
        border-left-width: 4px;
        margin-bottom: 0.2em;
        padding-left: 10px;
    }
    
    .label-orange
    {
        border-left-color: #FA8F6F;
    }
    .more
    {
        display: none;
    }
     #example-hide
    {
        display: none;
    }
    #hor-minimalist-b
    {
        font-size: 12px;
        background: #fff;
        margin-left:45px;
        margin-top: 5px;
        width: 640px;
        border-collapse: collapse;
        text-align: left;
    }
    #hor-minimalist-b th
    {
        font-size: 14px;
        font-weight: normal;
        color: #039;
        padding: 10px 8px;
        border-bottom: 2px solid #6678b1;
    }
    #hor-minimalist-b td
    {
        border-bottom: 1px solid #ccc;
        color: #669;
        padding: 6px 8px;
    }
    #hor-minimalist-b tbody tr:hover td
    {
        color: #009;
    }
    .Section1 img
    {
        width:300px;
        height:80px;
        display: block;
        margin-left:auto; 
        margin-right:auto; 
    }
        
    a.showLink, a.hideLink 
    {
      padding-left: 8px;
      background: transparent url(CSS/Images/down.gif) no-repeat left; 
    }
   a.hideLink 
   {
      background: transparent url(CSS/Images/up.gif) no-repeat left; 
   }
   img#<%= imgDownload.ClientID %>
   {
       width:16px;
       height:16px;
   }
</style>
<script type="text/javascript" src="../js/pdfobject.js">
</script>
  
  
<script type="text/javascript">
    function showHide(shID) {
        if (document.getElementById(shID)) {
            if (document.getElementById(shID + '-show').style.display != 'none') {
                document.getElementById(shID + '-show').style.display = 'none';
                document.getElementById(shID).style.display = 'block';
                document.getElementById(shID + '-hide').style.display = 'inline';
            }
            else {
                document.getElementById(shID + '-show').style.display = 'inline';
                document.getElementById(shID + '-hide').style.display = 'none';
                document.getElementById(shID).style.display = 'none';
            }          
        }
    }
</script>
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
