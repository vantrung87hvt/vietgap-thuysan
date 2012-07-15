<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTochucchungnhanDanhsachDangky.ascx.cs"
    Inherits="adminx_ucTochucchungnhanDanhsachDangky" %>
<%@ Register src="ucTochuccapphepDanhgia.ascx" tagname="ucTochuccapphepDanhgia" tagprefix="uc1" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    fieldset
    {
        -moz-border-radius: 7px;        
        margin-bottom: 20px;
        width: 100%;
        border:0;
    }
    
    fieldset legend
    {
        border: 1px #1a6f93 solid;
        color: black;
        font-weight: bold;
        font-family: Verdana;
        font-weight: none;
        font-size: 13px;
        padding-right: 5px;
        padding-left: 5px;
        padding-top: 2px;
        padding-bottom: 2px;
        -moz-border-radius: 3px;
    }
    
    /* Main DIV */
    .m
    {
        width: 100%;
        padding: 20px;
        height: auto;
    }
    
    /* Left DIV */
    .l
    {
        width: 160px;
        margin: 0px;
        padding: 0px;
        float: left;
        text-align: right;
    }
    
    
    /* Right DIV */
    .r
    {
        width: 300px;
        margin: 0px;
        padding: 0px;
        padding-left: 20px;
        float: left;
        text-align: left;
    }
    .rr
    {
        margin: 0px;
        padding: 0px;
        float: left;
        text-align: center;
    }
    .a
    {
        clear: both;
        width: 100%;
        padding: 10px;
    }
    
</style>
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
            Đăng ký lần:
            <asp:DropDownList ID="ddlLandangky" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlLandangky_SelectedIndexChanged">
                <asp:ListItem Value="0">Lần đầu</asp:ListItem>
                <asp:ListItem Value="1">Lại</asp:ListItem>
            </asp:DropDownList>
            
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grvTochuccapphep" runat="server" AutoGenerateColumns="False" OnRowDataBound="grvTochuccapphep_RowDataBound"
                OnSelectedIndexChanging="grvTochuccapphep_SelectedIndexChanging" OnRowCommand="grvTochuccapphep_RowCommand"
                AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grvTochuccapphep_PageIndexChanging"
                OnSorting="grvTochuccapphep_Sorting" AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader" CssClass="Grid" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn tất">
                        <HeaderTemplate>
                            <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvTochuccapphep','chkDelete');" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkDelete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PK_iDangkyChungnhanVietGapID" HeaderText="ID" SortExpression="PK_iDangkyChungnhanVietGapID" />
                    <asp:TemplateField HeaderText="Tên" SortExpression="FK_iTochucchungnhanID">
                        <ItemTemplate>
                            <asp:Label ID="lblTentochuc" runat="server" Text='<%# Bind("FK_iTochucchungnhanID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTentochuc" runat="server" Text='<%# Bind("FK_iTochucchungnhanID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quận">
                        <ItemTemplate>
                            <asp:Label ID="lblQuanHuyen" runat="server" Text='<%# Bind("FK_iTochucchungnhanID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQuanHuyen" runat="server" Text='<%# Bind("FK_iTochucchungnhanID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate>
                            <asp:Label ID="lblTrangthai" runat="server" Text='<%# Bind("PK_iDangkyChungnhanVietGapID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTrangthai" runat="server" Text='<%# Bind("PK_iDangkyChungnhanVietGapID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="FK_iTochucchungnhanID,PK_iDangkyChungnhanVietGapID" HeaderText="Chi tiết"
                     NavigateUrl="" Text="Chi tiết" DataNavigateUrlFormatString="Default.aspx?page=TochucchungnhanDanhsachDangky&amp;iTochucchungnhanID={0}&amp;PK_iDangkyChungnhanVietGapID={1}" />
                     <asp:TemplateField HeaderText="Đánh giá">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnDanhgia" CommandName="Danhgia" CommandArgument='<%# Bind("FK_iTochucchungnhanID") %>' runat="server">Đánh giá</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lnkAdd" runat="server" Text="Thêm mới|" NavigateUrl="~/adminx/Default.aspx?page=TochuccapphepUpdate&do=add" />
            <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click"
                OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>|
        </td>
    </tr>
</table>
<asp:Panel ID="pnThongTin" runat="server" Visible="false">
    
    
    

    <div class="grid_12">
        <div class="block-border" id="tab-panel-2">
            <div class="block-header">
                <h1>
                Thông tin tổ chức đăng ký
                    </h1>
                <ul class="tabs">
                    <li class="active"><a href="#thongtinchung">Thông tin chung</a></li>
                    <li><a href="#giaytokemtheo">Giấy tờ kèm theo</a></li>                                       
                </ul>
            </div>
            <div class="block-content tab-container">
                <div id="thongtinchung" class="tab-content" style="display: block;">
                    <div class="m">
        <fieldset>            
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblTen" runat="server" Text="Tên"></asp:Label></div>
                <div class="r">
                    <asp:Label ID="lblTenTochuc" runat="server" Text=""></asp:Label></div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblVietTat" runat="server" Text="Mã số"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblMaSotc" runat="server"></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblDiaChi" runat="server" Text="Địa chỉ"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblDiaChitc" runat="server" Text="Địa chỉ"></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblDienThoai" runat="server" Text="Địa thoại"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblDienthoaitc" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblFax" runat="server" Text="Fax"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblFaxtc" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblLogo" runat="server" Text="Logo" ></asp:Label>
                </div>
                <div class="r">
                    <asp:Image ID="imgLogo" runat="server" Width="110px" Height="110px" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblEmailtc" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblSoDangkykd" runat="server" Text="Số đăng ký kinh doanh"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblSodangkykdtc" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblCoQuanCap" runat="server" Text="Cơ quan cấp"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblCoQuanCaptc" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblNgayCap" runat="server" Text="Ngày cấp đăng ký kinh doanh"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblNgayCapdkdtc" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblNoiCap" runat="server" Text="Nơi cấp đăng ký kinh doanh"></asp:Label>
                </div>
                <div class="r">
                    <asp:Label ID="lblNoiCapdkkdtc" runat="server" Text=""></asp:Label>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
            </div>
        </fieldset>
    </div>
                </div>
                <div id="giaytokemtheo" class="tab-content" style="display: none;">
                    <div class="m">
        <fieldset>
            
            <asp:Repeater ID="rptHoSoKemTheo" runat="server" 
                onitemdatabound="rptHoSoKemTheo_ItemDataBound">
                <ItemTemplate>
                    <div class="a">
                        <div class="l">
                            <asp:Label ID="FK_iGiaytoID" runat="server" Text='<%#Eval("FK_iGiaytoID")%>' Visible="false"></asp:Label>
                        </div>
                        <div class="r" style="width:90%;">
                            - <asp:Label ID="lblTenGiayTo" runat="server" Text="" ></asp:Label>
                        </div>
                        <div class="rr">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="a"></div>
        </fieldset>
    </div>
                </div>
            </div>
        </div>
        <div style="text-align:center;width: 100%; padding:15px;">
    <asp:Button ID="btnCapPhep" runat="server" Text="Cấp phép" 
            onclick="btnCapPhep_Click" style="height: 26px" /> &nbsp;|&nbsp;
            <asp:Button ID="btnAnChitiet" runat="server" Text="Ẩn" 
                onclick="btnAnChitiet_Click" />
    </div>

    </div>
    <br />
</asp:Panel>
<%--<asp:Panel runat="server" ID="panGiayto" Visible="false">
    <fieldset>
        <legend>Giấy tờ nộp kèm hồ sơ</legend>
        <asp:Label runat="server" ID="Label2" ForeColor="Red"></asp:Label>
        <asp:CheckBoxList ID="cblGiaytonopkem" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="btnLuuGiaytonopkem" runat="server" Text="Lưu" 
            onclick="btnLuuGiaytonopkem_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnHuygiaytonopkem" runat="server" Text="Ẩn" 
            onclick="btnHuygiaytonopkem_Click" />
    </fieldset>
</asp:Panel>--%>
<asp:Panel runat="server" ID="pnDanhgia" Visible="false">
    <asp:PlaceHolder runat="server" ID="phDanhgia"></asp:PlaceHolder>
</asp:Panel>