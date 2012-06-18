<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCosonuoitrong.ascx.cs" Inherits="adminx_ucCosonuoitrong" %>
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


<asp:GridView ID="grvCosonuoitrong" runat="server" AutoGenerateColumns="False" onrowdatabound="grvNews_RowDataBound" 
    onselectedindexchanging="grvNews_SelectedIndexChanging" 
    AllowPaging="True" AllowSorting="True" 
    onpageindexchanging="grvNews_PageIndexChanging" 
    onsorting="grvNews_Sorting"  AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid" EnableModelValidation="True"
    >
    <Columns>
        <asp:TemplateField HeaderText="Chọn tất">
                        <HeaderTemplate>
                            <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvCosonuoitrong','chkDelete');" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkDelete" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
        <asp:BoundField DataField="PK_iCosonuoitrongID" HeaderText="ID" 
            SortExpression="PK_iCosonuoitrongID" />
        <asp:BoundField DataField="sMaso_vietgap" HeaderText="MS VietGap" 
            SortExpression="sMaso_vietgap" />
        <asp:BoundField DataField="sMasocoso" HeaderText="Mã Cs" 
            SortExpression="sMasocoso" />
        <asp:BoundField DataField="sTencoso" HeaderText="Tên Cs" 
            SortExpression="sTencoso" />
        <asp:TemplateField HeaderText="Tỉnh" SortExpression="FK_iQuanHuyenID">
            <ItemTemplate>
                <asp:Label ID="lblTinhthanh" runat="server" Text='<%# Bind("FK_iQuanHuyenID") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTinhthanh" runat="server" Text='<%# Bind("FK_iQuanHuyenID") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="fTongdientichmatnuoc" 
            HeaderText="Tổng dt" SortExpression="fTongdientichmatnuoc" 
            DataFormatString="{0:0,0.#}" />
        <asp:TemplateField HeaderText="Đối tượng nuôi" 
            SortExpression="FK_iDoituongnuoiID">
            <ItemTemplate>
                <asp:Label ID="lblDoituongnuoi" runat="server" Text='<%# Bind("FK_iDoituongnuoiID") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDoituongnuoi" runat="server" 
                    Text='<%# Bind("FK_iDoituongnuoiID") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Trạng thái">
            <ItemTemplate>
                <asp:Label ID="lblTrangthai" runat="server" Text='<%# Bind("PK_iCosonuoitrongID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Kiểm duyệt">
            <ItemTemplate>
                <asp:CheckBox ID="chkVerify" runat="server" Checked='<%#Convert.ToBoolean(Eval("bDuyet")) %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True"
            Text="Sửa" />
        
        <asp:HyperLinkField DataNavigateUrlFields="PK_iCosonuoitrongID" 
            DataNavigateUrlFormatString="~/adminx/default.aspx?page=Xulyvipham&amp;cosonuoitrongID={0}" 
            Text="Xử lý" />

        <asp:HyperLinkField DataNavigateUrlFields="PK_iCosonuoitrongID" 
            DataNavigateUrlFormatString="~/adminx/default.aspx?page=GiayphepVietGap&amp;PK_iCosonuoitrongID={0}" 
            Text="Cấp Giấy phép" />

    </Columns>
    
    
<HeaderStyle CssClass="GridHeader"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
    
    
    <PagerStyle HorizontalAlign="Right" />
    
    
</asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
       <asp:HyperLink ID="lnkAdd" runat="server" Text="Thêm mới|" 
                NavigateUrl="~/adminx/Default.aspx?page=CosonuoitrongUpdate_&amp;do=add" />
          
<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click" OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>|

<asp:LinkButton ID="lbtnVerify" runat="server" CausesValidation="False" 
    onclick="lbtnVerify_Click">Kiểm duyệt</asp:LinkButton>|
<asp:LinkButton ID="lbtnExport" runat="server" CausesValidation="False" 
                onclick="lbtnExport_Click">Xuất dữ liệu</asp:LinkButton>|
<asp:LinkButton ID="lbtnExportAll" runat="server" CausesValidation="False" 
                ToolTip="Xuất toàn bộ dữ liệu về cơ sở nuôi trồng" 
                onclick="lbtnExportAll_Click">Xuất toàn bộ dữ liệu</asp:LinkButton>|
<asp:HyperLink ID="hypImport" runat="server" Text="Nhập từ Excel|" NavigateUrl="~/adminx/Default.aspx?page=ImportCosonuoitrong" />
</td>
    </tr>
</table>