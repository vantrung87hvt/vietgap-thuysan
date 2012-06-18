<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDocumentCategoryManager.ascx.cs" Inherits="adminx_ucDocumentCategoryManager" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />

<table style="width:100%;">
    <tr>
        <td width="100%">
            <asp:Label ID="lblThongbao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Tìm kiếm&nbsp; :&nbsp;
            <asp:TextBox ID="txtSearchByID" runat="server" Width="234px"></asp:TextBox>
&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label><asp:TextBox
                ID="txtID" runat="server" Width="50px"></asp:TextBox>
            <asp:LinkButton ID="btnSearchByID" runat="server" onclick="btnSearchByID_Click" 
                Text="Tìm kiếm" />|
            <asp:LinkButton ID="btnShowAll" runat="server" onclick="btnShowAll_Click" 
                Text="Hiện toàn bộ" />
        </td>
    </tr>
    <tr>
        <td>


<asp:GridView ID="grvDocCategory" runat="server" AutoGenerateColumns="False"  
    onselectedindexchanging="grvDocCategory_SelectedIndexChanging" 
    AllowPaging="True" AllowSorting="True" 
    onpageindexchanging="grvDocCategory_PageIndexChanging" 
    onsorting="grvDocCategory_Sorting"  AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid"
    >
    <Columns>
        <asp:TemplateField HeaderText="Chọn tất">
                        <HeaderTemplate>
                            <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvDocCategory','chkDelete');" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkDelete" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
        <asp:BoundField DataField="PK_iLoaivanbanID" HeaderText="ID" SortExpression="PK_iLoaivanbanID" />
        <asp:BoundField DataField="sTenloai" HeaderText="Tên loại" 
            SortExpression="sTenloai" />      
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True"
            Text="Sửa" />
        
    </Columns>
    
    
<HeaderStyle CssClass="GridHeader"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
    
    
</asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
       <asp:HyperLink ID="lnkAdd" runat="server" Text="Thêm mới|" 
                NavigateUrl="~/adminx/Default.aspx?page=DocumentCategoryUpdate&amp;do=add" /> 
<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click" OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>
</td>
    </tr>
</table>
