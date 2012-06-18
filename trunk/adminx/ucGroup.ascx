<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucGroup.ascx.cs" Inherits="adminx_ucGroup" %>
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
            <asp:Panel ID="pnlEdit" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td width="30%" colspan="2" style="width: 100%" align="center">
                        <asp:Label ID="lblInfo" runat="server" 
                            Text="<%$Resources:language,dsnhomnguoidung %>"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" colspan="2" align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20%">
                        &nbsp;</td>
                    <td width="70%">&nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" width="20%">
                        <asp:Label ID="lblName" runat="server" Text="<%$Resources:language,tennhom %>"></asp:Label>
                    </td>
                    <td valign="middle" width="70%">
                        
                        <asp:TextBox ID="txtGroupName" runat="server" 
                            Width="95%"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="rqTennhom" runat="server" 
                            ControlToValidate="txtGroupName" ErrorMessage="*" ValidationGroup="vgGroup"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="30%">
                        <asp:Label ID="lblDesc" runat="server" Text="<%$Resources:language,mota %>"></asp:Label>
                    </td>
                    <td valign="middle" width="70%">
                        
                        <asp:TextBox ID="txtGroupDesc" runat="server" 
                            Width="95%" Height="22px"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="rqMota" runat="server" 
                            ControlToValidate="txtGroupDesc" ErrorMessage="*" ValidationGroup="vgGroup"></asp:RequiredFieldValidator>
                        
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
            </asp:Panel>
        </td>
        <td style="width: 10%"></td>
    </tr>
    <tr>
        <td></td>
        <td align="center">


<asp:GridView ID="grvGroup" runat="server" AutoGenerateColumns="False"
    AllowPaging="True" AllowSorting="True" 
                onselectedindexchanging="grvPosition_SelectedIndexChanging" 
                onsorting="grvPosition_Sorting" Width="100%"
                AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid"
                >
                
    <Columns>
         <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvGroup','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
        <asp:BoundField DataField="iGroupID" HeaderText="ID" 
            SortExpression="sTitle" />
        <asp:BoundField DataField="sName" HeaderText="Tên nhóm" 
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

<asp:LinkButton ID="lbtnAddnew" runat="server" CausesValidation="False" 
                onclick="lbtnAddnew_Click">Thêm mới | </asp:LinkButton>
<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click" OnClientClick="return confirm('Bạn có thực sự muốn xóa không?');">Xóa mục đã chọn</asp:LinkButton>



        </td>
        <td>&nbsp;</td>
    </tr>
</table>
