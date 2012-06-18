<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="UserMethods_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang cá nhân - Hộ nuôi trồng Thủy sản</title>
    <link rel="stylesheet" href="../CSS/BrightSide.css" type="text/css" />
    <style>
        body
        {
            background: none;
        }
        h3
        {
            width:180px
            }
        .sidemenu, h3 
        {
            border-bottom:2px solid #41833c;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrap" style="height: auto;">
        <div id="content-wrap">
            <!-- Flash Header -->
            <embed src="../Images/Banner.swf" width="960" height="120" wmode="transparent" type="application/x-shockwave-flash"></embed>
            <!-- End Flash Header -->
            <!--<img src="../Images/headerphoto_.jpg" width="960" height="120" alt="headerphoto"-->
                class="no-border" />&nbsp;<div id="sidebar" style="border-right:5px solid #41833c;">
                <h3 style="margin-left: 15px;">
                    <asp:Label ID="lblCategory" Text="Chỉnh sửa thông tin" runat="server" />
                </h3>
                <ul class="sidemenu">
                    <li><a href="Default.aspx?mode=ucUpdateUserInfo">Thông tin cá nhân</a></li>
                    <li><a href="Default.aspx?mode=ucCosonuoitrongCapnhap">Thông tin cơ sở nuôi trồng</a></li>
                </ul>
                <h3 style="margin-left: 15px;">
                    <asp:Label ID="Label1" Text="Chứng nhận VietGAP" runat="server" />
                </h3>
                <ul class="sidemenu">
                    <li><a href="Default.aspx?mode=ucDangKyChungNhan">Đăng ký cấp mã số VietGAP</a></li>
                   <li><a href="Default.aspx?mode=ucDanhgiaketqua">Đánh giá nội bộ</a></li>
                   <li><a href="Default.aspx?mode=ucBaocaodanhgianoibo">Gửi báo cáo đánh giá nội bộ</a></li>
                </ul>

                 <ul class="sidemenu" style="margin-bottom:0;">
                    <li>
                        <asp:LinkButton ID="lbtDangXuat" runat="server" onclick="lbtDangXuat_Click">Đăng xuất </asp:LinkButton>
                    </li>
                    
                </ul>
            </div>
            <div id="main" style="width: 610px; margin-left: 10px; text-align: justify;">
                <asp:PlaceHolder ID="plMain" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
