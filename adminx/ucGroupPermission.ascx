<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucGroupPermission.ascx.cs" Inherits="adminx_ucGroupPermission" %>
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
                    <td width="30%" colspan="2" style="width: 100%" align="center">
                        <asp:Label ID="lblInfo" runat="server" 
                            Text="<%$Resources:language,dsquyennhomnguoidung %>"></asp:Label>
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
                        <asp:Label ID="lblGroupName" runat="server" Text="<%$Resources:language,tennhom %>"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlGroupName_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblPermission" runat="server" Text="<%$Resources:language,quyen %>"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:DropDownList ID="ddlPermission" runat="server">
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <asp:Panel ID="panAdd" runat="server" Visible="false">
                <tr>
                    <td>
                        Thêm:
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="<%$Resources:language,them %>" 
                            onclick="btnAdd_Click" />
                    </td>
                </tr>
                </asp:Panel>
                <asp:Panel ID="panEdit" Visible="false" runat="server" >
                    <tr>
                        <td>Sửa:</td>
                        <td>
                            <asp:Button ID="btnOK" runat="server" Text="<%$Resources:language,luu %>" onclick="btnOK_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:language,boqua %>"
                                onclick="btnCancel_Click" />
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblThongbao" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 10%"></td>
    </tr>
    <tr>
        <td></td>
        <td align="center">


<asp:GridView ID="grvGroupPermission" runat="server" AutoGenerateColumns="False"
    AllowPaging="True" AllowSorting="True" Width="100%" 
                onpageindexchanging="grvGroupPermission_PageIndexChanging" 
                onselectedindexchanging="grvGroupPermission_SelectedIndexChanging" 
                onsorting="grvGroupPermission_Sorting"
                AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid"
                >
    <Columns>
         <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvGroupPermission','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
        <asp:BoundField DataField="iGroupPermissionID" HeaderText="ID" 
            SortExpression="sTitle" />
        <asp:TemplateField HeaderText="Tên nhóm" SortExpression="iGroupID">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# getGroupName(DataBinder.Eval(Container,"DataItem.iGroupID")) %>'></asp:Label>
            </ItemTemplate>
            
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quyền" SortExpression="iPermissionID">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# getPermissionName(DataBinder.Eval(Container,"DataItem.iPermissionID")) %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("iPermissionID") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:BoundField DataField="sValue" HeaderText="Giá trị" 
            SortExpression="sValue" />
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


<%--<asp:LinkButton ID="lbtnDelete" runat="server" 
    onclick="lbtnDelete_Click" Text="<%$Resources:language,xoamucdachon %>" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?');">
    </asp:LinkButton>--%>
    <asp:LinkButton ID="lbtnThemmoi" runat="server" Text="Thêm mới | " 
                onclick="lbtnThemmoi_Click">
    </asp:LinkButton>
    <asp:LinkButton ID="lbtnDelete" runat="server" 
    onclick="lbtnDelete_Click" Text="Xóa mục đã chọn" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?');">
    </asp:LinkButton>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
