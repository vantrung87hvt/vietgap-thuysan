<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTCCN_TaikhoanDangky.ascx.cs" Inherits="adminx_Tochucchungnhan_ucTCCN_TaikhoanDangky" %>
 <%@Register assembly="PasswordTextBox" namespace="opp" tagprefix="cc1" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<table width="100%">
    <tr>
        <td></td>
        <td style="text-align: center">&nbsp;</td>
        <td></td>
    </tr>
    <tr>
        <td style="width: 10%"></td>
        <td>
            <table width="100%">
                <tr>
                    <td width="30%" colspan="2" align="center">
                        <asp:Label ID="lblInfo" runat="server" 
                            Text="<%$Resources:language,dsnguoidung %>"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" colspan="2" align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="middle">
                        <asp:Label ID="lblEmail" runat="server" Text="<%$Resources:language,email %>"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtEmail" runat="server" 
                            Width="90%" Enabled="False"></asp:TextBox>
                        
                        <asp:RegularExpressionValidator ID="reEmail" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="*" 
                            ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" 
                            ValidationGroup="vgUser"></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>
                <tr style="display:none">
                    <td valign="top">
                        <asp:Label ID="lblIP" runat="server">IP:</asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtIP" runat="server" 
                            Width="90%" Enabled="False"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblUsername" runat="server" Text="<%$Resources:language,tentruycap %>"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtUsername" runat="server" 
                            Width="90%" Enabled="False"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="rqTentruycap" runat="server" 
                            ControlToValidate="txtUsername" ErrorMessage="*" ValidationGroup="vgUser"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblUsername0" runat="server" Text="<%$Resources:language,password %>"></asp:Label>
                    </td>
                    <td>
                        
                        <cc1:PasswordTextBox ID="txtPassword" runat="server"></cc1:PasswordTextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="<%$Resources:language,them %>" onclick="btnOK_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:language,boqua %>"
                            onclick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblThongbao" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 10%">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">


<asp:GridView ID="grvUsers" runat="server" AutoGenerateColumns="False"
    AllowPaging="True" AllowSorting="True" 
                onselectedindexchanging="grvPosition_SelectedIndexChanging" 
                onsorting="grvPosition_Sorting" Width="100%" 
                onpageindexchanging="grvUsers_PageIndexChanging"
                 AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid" EnableModelValidation="True" onrowdatabound="grvUsers_RowDataBound"
                >
<AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
    <Columns>
      <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvUsers','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>

            </asp:TemplateField>
        <asp:BoundField DataField="iUserID" HeaderText="ID" 
            SortExpression="iUserID" >
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="sUsername" HeaderText="Tên truy cập" 
            SortExpression="sUsername">
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Mật khẩu" SortExpression="sPassword">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# getPasswordChar(DataBinder.Eval(Container,"DataItem.sPassword")) %>'></asp:Label>
            </ItemTemplate>
            
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tên nhóm" SortExpression="iGroupID">
            <ItemTemplate>
                <asp:Label ID="lblGroupName" runat="server" Text='<%#getGroupName(DataBinder.Eval(Container,"DataItem.iGroupID"))%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Kích hoạt">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("bActive") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblKiemduyet" runat="server" Text='<%# Bind("bActive") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
        
    </Columns>

<HeaderStyle CssClass="GridHeader"></HeaderStyle>
</asp:GridView>


        </td>
    </tr>
    <tr>
        <td colspan="3" align="right">


<asp:LinkButton ID="lbtnActive" runat="server" CausesValidation="False" 
    onclick="lbtnActive_Click">Kích hoạt</asp:LinkButton>
&nbsp;|&nbsp;<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click" 
                onclientclick="return confirm('Xóa tài khoản sẽ xóa cả CSNT/TCCN đang được quản lý bởi tài khoản. Đồng ý xóa?');">Xóa mục đã chọn</asp:LinkButton>



        </td>
    </tr>
</table>
