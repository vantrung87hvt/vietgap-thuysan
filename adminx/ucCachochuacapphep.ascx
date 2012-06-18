<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCachochuacapphep.ascx.cs"
    Inherits="adminx_ucCachochuacapphep" %>
<%@ Register Namespace="FreeTextBoxControls" Assembly="FreeTextBox" TagPrefix="FTB" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<link href="css/FormInAdmin.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.7.1.js" type="text/javascript"></script>

<table style="width: 100%;">
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
            <asp:LinkButton ID="btnSearchByID" runat="server" OnClick="btnSearchByID_Click" Text="Tìm kiếm" />|
            <asp:LinkButton ID="btnShowAll" runat="server" OnClick="btnShowAll_Click" Text="Hiện toàn bộ" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grvCosonuoitrong" runat="server" AutoGenerateColumns="False" OnRowDataBound="grvCosonuoitrong_RowDataBound"
                OnSelectedIndexChanging="grvCosonuoitrong_SelectedIndexChanging" AllowPaging="True"
                AllowSorting="True" OnPageIndexChanging="grvCosonuoitrong_PageIndexChanging"
                OnSorting="grvCosonuoitrong_Sorting" AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader" CssClass="Grid" 
                EnableModelValidation="True" onrowcreated="grvCosonuoitrong_RowCreated">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvCosonuoitrong','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
                    <asp:BoundField DataField="PK_iCosonuoitrongID" HeaderText="ID" SortExpression="PK_iCosonuoitrongID" />
                    <asp:BoundField DataField="sMaso_vietgap" HeaderText="MS VietGap" SortExpression="sMaso_vietgap" />
                    <asp:BoundField DataField="sTencoso" HeaderText="Tên Cs" SortExpression="sTencoso" />
                    <asp:TemplateField HeaderText="Tỉnh" SortExpression="FK_iQuanHuyenID">
                        <ItemTemplate>
                            <asp:Label ID="lblTinhthanh" runat="server" Text='<%# Bind("FK_iQuanHuyenID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTinhthanh" runat="server" Text='<%# Bind("FK_iQuanHuyenID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="fTongdientichmatnuoc" HeaderText="Tổng dt" SortExpression="fTongdientichmatnuoc" />
                    <asp:TemplateField HeaderText="Đối tượng nuôi" SortExpression="FK_iDoituongnuoiID">
                        <ItemTemplate>
                            <asp:Label ID="lblDoituongnuoi" runat="server" Text='<%# Bind("FK_iDoituongnuoiID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDoituongnuoi" runat="server" Text='<%# Bind("FK_iDoituongnuoiID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kiểm duyệt">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkVerify" runat="server" Checked='<%#Convert.ToBoolean(Eval("bDuyet")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Sửa" />
                </Columns>
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
                <PagerStyle HorizontalAlign="Right" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lnkAdd" runat="server" Text="Thêm mới|" NavigateUrl="~/adminx/Default.aspx?page=CosonuoitrongUpdate&do=add" />
            <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click"
                OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>|
            <asp:LinkButton ID="lbtnVerify" runat="server" CausesValidation="False" OnClick="lbtnVerify_Click">Kiểm duyệt| </asp:LinkButton>
        </td>
    </tr>
</table>
