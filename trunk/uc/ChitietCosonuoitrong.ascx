<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChitietCosonuoitrong.ascx.cs" Inherits="uc_ChitietCosonuoitrong" %>
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
        
         a.showLink, a.hideLink {
     
      padding-left: 8px;
      background: transparent url(CSS/Images/down.gif) no-repeat left; }
   a.hideLink {
      background: transparent url(CSS/Images/up.gif) no-repeat left; }
   img#<%=imgSodo.ClientID%>
   {
       max-width:450px;
       max-height:450px;
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
                    <asp:Image ID="imgSodo" runat="server" />
                </td>
            </tr>
            
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </tbody>
    </table>
</div>
