<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucFaqCategory.ascx.cs" Inherits="adminx_ucFaqCategory" %>
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


<asp:GridView ID="grvFaqCategory" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" AllowSorting="True"  AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid" EnableModelValidation="True" onselectedindexchanging="grvFaqCategory_SelectedIndexChanging"
    >
    <Columns>
         <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvFaqCategory','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
        <asp:BoundField DataField="PK_iFaqCateID" HeaderText="ID" 
            SortExpression="PK_iFaqCateID" />
        <asp:BoundField DataField="sCateName" HeaderText="Chuyên mục" 
            SortExpression="sCateName" />
        <asp:BoundField DataField="sDesc" HeaderText="Mô tả" 
            SortExpression="sDesc" />
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
       <asp:HyperLink ID="lnkAdd" runat="server" Text="Thêm mới|" NavigateUrl="~/adminx/Default.aspx?page=FaqCategory&do=add" />
           

<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click" OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>|

</td>
    </tr>
</table>