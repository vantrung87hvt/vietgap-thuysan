<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdvUpdate.ascx.cs" Inherits="adminx_AdvManager" %>
<style type="text/css">
.Grid { border: dotted 1px #e6e6e6; }
.GridHeader
{   border-top:dotted 1px #e6e6e6;
    font-weight: bold;
}
.Grid a {
	text-decoration: none;
	border-bottom: 1px dotted #f60;
	color: #f60;
	font-weight: bold;
}

a {
	text-decoration: none;
	border-bottom: 1px dotted #f60;
	color: #756a4f;
	font-weight: bold;
}
.Grid td
{
    margin: 1px 1px 1px 1px;
    text-align: left;
    padding: 5px;
	line-height: 1.6em;
    vertical-align: top;
}

.GridAltItem
{
    background-color: #E8EDFF;
}
</style>
<table width="100%">
    <tr>
        <td></td>
        <td style="text-align: center">&nbsp;</td>
        <td>Chọn nhóm :</td>
    </tr>
    <tr valign="top">
        <td></td>
        <td>
            <table>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblInfo" runat="server" 
                            Text="<%$Resources:language,dscacmucquangcao %>"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        &nbsp;</td>
                    <td  align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblTitle" runat="server" Text="<%$Resources:language,tieude %>"></asp:Label>
                    </td>
                    <td class="style1">
                        
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        
                    </td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="rqTieude" runat="server" 
                            ErrorMessage="*" ValidationGroup="vgQuangcao" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        <asp:Label ID="lblLink" runat="server" Text="Liên kết"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
                        
                    </td>
                    <td>
                        
                        <asp:RegularExpressionValidator ID="rlDuongdan" runat="server" 
                            ErrorMessage="*" ValidationGroup="vgQuangcao" ControlToValidate="txtLink" 
                            ValidationExpression="^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*$"></asp:RegularExpressionValidator>
                        
                        <asp:RequiredFieldValidator ID="rqDuongdan" runat="server" ErrorMessage="*" 
                            ControlToValidate="txtLink"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        <asp:Label ID="lblDesc" runat="server" Text="<%$Resources:language,mota %>" ></asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtAdvDesc" runat="server"></asp:TextBox>
                        
                    </td>
                    <td>
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="middle">
                        <asp:Label ID="lblMedia" runat="server">Đường dẫn file ảnh/flash:</asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtMedia" runat="server"></asp:TextBox>
                        
                    </td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="rqMedia" runat="server" ErrorMessage="*" 
                            ControlToValidate="txtMedia" ValidationGroup="vgQuangcao"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        Chiều rộng</td>
                    <td>
                        
                        <asp:TextBox ID="txtWidth" runat="server" MaxLength="4" Width="70px"></asp:TextBox>
                        
                    </td>
                    <td>
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="middle">
                        Chiều cao</td>
                    <td>
                        
                        <asp:TextBox ID="txtHeight" runat="server" MaxLength="4" Width="70px"></asp:TextBox>
                        
                    </td>
                    <td>
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="middle">
                        <asp:Label ID="lblMedia0" runat="server" Text="<%$Resources:language,kieu %>"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:DropDownList ID="cboType" runat="server">
                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                            <asp:ListItem Value="1">Ảnh</asp:ListItem>
                            <asp:ListItem Value="2">Flash</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                    <td>
                        
                        <asp:RangeValidator ID="rvKieu" runat="server" ErrorMessage="*" 
                            MinimumValue="1" ValidationGroup="vgQuangcao" ControlToValidate="cboType" 
                            MaximumValue="100" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        <asp:Label ID="lblOrder" runat="server" Text="<%$Resources:language,sapxep %>"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtOrder" runat="server" 
                            Width="50px"></asp:TextBox>
                        
                    </td>
                    <td>
                        
                        <asp:RangeValidator ID="rvSapxep" runat="server" ErrorMessage="*" 
                            MinimumValue="0" ValidationGroup="vgQuangcao" ControlToValidate="txtOrder" 
                            MaximumValue="100" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        <asp:Label ID="lblPosition" runat="server" Text="<%$Resources:language,vitri %>"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:DropDownList ID="ddlPosition" runat="server">
                        </asp:DropDownList>
                        
                    </td>
                    <td>
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="<%$Resources:language,them %>" 
                            onclick="btnOK_Click" ValidationGroup="vgQuangcao" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:language,boqua %>"
                            onclick="btnCancel_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblThongbao" runat="server"></asp:Label>
                    </td>
                    <td align="center" valign="top">
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td>
                <asp:ListBox ID="lstbNhomtin" runat="server" Height="300px" Width="206px" 
                    SelectionMode="Multiple">
                </asp:ListBox>
            </td>
    </tr>
    <tr>
        <td colspan="3">


            &nbsp;</td>
    </tr>
    </table>
