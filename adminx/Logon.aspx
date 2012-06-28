<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logon.aspx.cs" Inherits="adminx_Logon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
<link href="../css/Login.css" rel="stylesheet" type="text/css" />    
   
</head>
<body>
    
  <form id="form1" name="form1" runat="server" style="width: 100%; height: 100%">
<table width="100%" style="height:100%; width: 100%;">
    <tr style="height:30%">
        <td></td>
        <td style="text-align: center">&nbsp;</td>
        <td></td>
    </tr>
    <tr>
        <td style="width: 10%"></td>
        <td>
    
  <div id="stylized" class="myform">
    <h1>Đăng nhập</h1>
    <p>Hệ thống quản trị thông tin</p>
      <asp:Label ID="lblThongbao" runat="server" CssClass="login-err" Text=""></asp:Label>
    <label>Username:
        <span class="small">tên truy cập</span>
    </label>
    <asp:TextBox ID="txtUsername" runat="server" Width="202px"></asp:TextBox>     
    <label>Password:
        <span class="small">Ít nhất là 6 ký tự</span>
    </label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="202px"></asp:TextBox>
    <div class="loginbutton">
        <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" Text="Đăng nhập" CssClass="button" Width="92"/>
    </div>
    <div class="spacer"></div>
</div>
    
        </td>
        <td style="width: 10%"></td>
        </tr>
    <tr style="height:30%">
        <td>&nbsp;</td>
        <td align="right">


            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
  </form>
    
</body>
</html>
