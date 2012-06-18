<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPermission.ascx.cs" Inherits="adminx_ucPermission" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<table width="100%">
    <tr>
        <td></td>
        <td style="text-align: center">&nbsp;</td>
        <td></td>
    </tr>
    <tr>
        <td style="width: 20%"></td>
        <td>
            <table width="100%">
                <tr>
                    <td width="30%" colspan="2" style="width: 100%" align="center">
                        <asp:Label ID="lblInfo" runat="server" 
                            Text="Danh sách các quyền"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" colspan="2" align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="30%">
                        &nbsp;</td>
                    <td width="70%">&nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblName" runat="server">Tên quyền:</asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtPerName" runat="server" 
                            Width="100%" Enabled="False"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblDesc" runat="server">Mô tả:</asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtPerDesc" runat="server" 
                            Width="100%" Height="22px" Enabled="False"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="Thêm" onclick="btnOK_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Bỏ qua" 
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
        <td style="width: 20%"></td>
    </tr>
    <tr>
        <td></td>
        <td align="center">


<asp:GridView ID="grvPermission" runat="server" AutoGenerateColumns="False"
    AllowPaging="True" AllowSorting="True" 
                onselectedindexchanging="grvPosition_SelectedIndexChanging" 
                onsorting="grvPosition_Sorting" Width="100%"
                AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid" onpageindexchanging="grvPermission_PageIndexChanging"
                >
    <Columns>
         <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvPermission','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
        <asp:BoundField DataField="iPermissionID" HeaderText="ID" 
            SortExpression="sTitle" />
        <asp:BoundField DataField="sName" HeaderText="Tên quyền" 
            SortExpression="sName" >
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="sDesc" HeaderText="Mô tả" SortExpression="sDesc" >
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
        
    </Columns>
</asp:GridView>


        </td>
        <td></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td align="right">


<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click">Xóa mục đã chọn</asp:LinkButton>



        </td>
        <td>&nbsp;</td>
    </tr>
</table>
