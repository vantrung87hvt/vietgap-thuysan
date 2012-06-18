<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenPassword.aspx.cs" Inherits="GenPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>&nbsp;
        <asp:Button ID="btnGen" runat="server" Text="Gen" onclick="btnGen_Click" />
        <br/>
        <asp:TextBox ID="txtGenPass" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
