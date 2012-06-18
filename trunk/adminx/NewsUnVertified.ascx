<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsUnVertified.ascx.cs" Inherits="INVI.INVINews.Admin.NewsUnVertified" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<table style="width: 100%">
    <tr>
        <td width="100%">
            <asp:Label ID="lblThongbao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Tìm kiếm&nbsp;<strong><span style="color: #756a4f"> :&nbsp; </span></strong>
            <asp:TextBox ID="txtSearchByID" runat="server" Width="234px"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label><asp:TextBox ID="txtID"
                runat="server" Width="50px"></asp:TextBox>
            <asp:LinkButton ID="btnSearchByID" runat="server" OnClick="btnSearchByID_Click" Text="Tìm kiếm"></asp:LinkButton>|
            <asp:LinkButton ID="btnShowAll" runat="server" OnClick="btnShowAll_Click" Text="Hiện toàn bộ"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grvNews" runat="server" AllowPaging="True" AllowSorting="True"
                AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" CssClass="Grid"
                HeaderStyle-CssClass="GridHeader" OnPageIndexChanging="grvNews_PageIndexChanging"
                OnRowDataBound="grvNews_RowDataBound" OnSelectedIndexChanging="grvNews_SelectedIndexChanging"
                OnSorting="grvNews_Sorting">
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
                    <asp:BoundField DataField="sDesc" HeaderText="T&#243;m lược" SortExpression="sDesc" />
                    <asp:BoundField DataField="tDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y đăng"
                        SortExpression="tDate" />
                    <asp:TemplateField HeaderText="Kiểm duyệt">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkVerify" runat="server" Checked='<%#Convert.ToBoolean(Eval("bVerified")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True"
                        Text="Sửa" />
                </Columns>
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GridAltItem" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lnkAdd" runat="server" NavigateUrl="~/adminx/Default.aspx?page=NewsUpdate&do=add"
                Text="Thêm mới|"></asp:HyperLink>
             
            <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click"
                OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>|
            <asp:LinkButton ID="lbtnVerify" runat="server" CausesValidation="False" OnClick="lbtnVerify_Click">Kiểm duyệt</asp:LinkButton>
        </td>
    </tr>
</table>
<p>
&nbsp;&nbsp;&nbsp;
</p>

