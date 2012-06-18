<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAdv.ascx.cs" Inherits="adminx_ucAdv" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<table width="100%">
    <tr valign="top">
        <td></td>
        <td>
            &nbsp;</td>
        <td>
                &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">


<asp:GridView ID="grvAdv" runat="server" AutoGenerateColumns="False"
    AllowPaging="True" AllowSorting="True" 
                onselectedindexchanging="grvPosition_SelectedIndexChanging" 
                onsorting="grvPosition_Sorting" Width="100%" 
                onpageindexchanging="grvAdv_PageIndexChanging"
                AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid"
                >
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkDelete" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="iAdvID" HeaderText="ID" 
            SortExpression="sTitle" />
        <asp:TemplateField HeaderText="Tiêu đề" SortExpression="sTitle">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.sTitle") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.sTitle") %>'  tooltip='<%# Eval ( "sTitle" ) %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        
        <asp:BoundField DataField="iOrder" HeaderText="Sắp xếp" 
            SortExpression="iOrder" />
        <asp:TemplateField HeaderText="Vị trí" SortExpression="iPositionID">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# getPositionName(DataBinder.Eval(Container,"DataItem.iPositionID")) %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
        
    </Columns>

<HeaderStyle CssClass="GridHeader"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
</asp:GridView>


        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td align="right">

<asp:HyperLink ID="lnkAdd" runat="server" Text="Thêm mới|" NavigateUrl="~/adminx/Default.aspx?page=AdvUpdate&do=add" />
           <a href="javascript:inviCheck.CheckAll()">Chọn tất|</a>
<a href="javascript:inviCheck.UnCheckAll()">Bỏ chọn |</a>
<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click">Xóa mục đã chọn</asp:LinkButton>



        </td>
        <td>&nbsp;</td>
    </tr>
</table>
