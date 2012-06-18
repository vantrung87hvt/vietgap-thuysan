<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucNewsManager.ascx.cs" Inherits="INVI.INVINews.Admin.NewsManager" %>
<%@ Register Namespace = "FreeTextBoxControls" Assembly="FreeTextBox" TagPrefix="FTB"%>

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


<asp:GridView ID="grvNews" runat="server" AutoGenerateColumns="False" onrowdatabound="grvNews_RowDataBound" 
    onselectedindexchanging="grvNews_SelectedIndexChanging" 
    AllowPaging="True" AllowSorting="True" 
    onpageindexchanging="grvNews_PageIndexChanging" 
    onsorting="grvNews_Sorting"  AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid"
    >
    <Columns>
       <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvNews','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
               <asp:CheckBox runat="server" id="chkDelete" />
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>      
        <asp:BoundField DataField="iNewsID" HeaderText="ID" SortExpression="iNewsID" />
        <asp:BoundField DataField="sTitle" HeaderText="Ti&#234;u đề" 
            SortExpression="sTitle" />
        <asp:BoundField DataField="tDate" HeaderText="Ng&#224;y đăng" 
            SortExpression="tDate" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:TemplateField HeaderText="Kiểm duyệt">
            <ItemTemplate>
                <asp:CheckBox ID="chkVerify" runat="server" Checked='<%#Convert.ToBoolean(Eval("bVerified")) %>' />
            </ItemTemplate>
        </asp:TemplateField>
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
       <asp:HyperLink ID="lnkAdd" runat="server" Text="Thêm mới|" NavigateUrl="~/adminx/Default.aspx?page=NewsUpdate&do=add" />     
<asp:LinkButton ID="lbtnDelete" runat="server" 
    onclick="lbtnDelete_Click" OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>|

<asp:LinkButton ID="lbtnVerify" runat="server" 
    onclick="lbtnVerify_Click">Kiểm duyệt</asp:LinkButton>

</td>
    </tr>
</table>


