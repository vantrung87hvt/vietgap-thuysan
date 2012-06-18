<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDocumentManager.ascx.cs"
    Inherits="INVI.INVINews.Admin.DocumentManager" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<link href="css/FormEdit.css" rel="Stylesheet" type="text/css" />
<link rel="stylesheet" media="screen" type="text/css" href="css/datepicker.css" />
<script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
<script type="text/javascript" src="js/datepicker.js"></script>
<script type="text/javascript" src="js/eye.js"></script>
<script type="text/javascript" src="js/utils.js"></script>
<script type="text/javascript" src="js/layout.js?ver=1.0.2"></script>
<asp:Panel ID="pnEdit" runat="server" Visible="false">
    <div class="title">
        <h2>
            Quản lý tài liệu qui phạm pháp luật</h2>
    </div>
    <div class="fieldItemLabel">
        <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="fieldForm" id="fieldForm">
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for="field1">
                    Tiêu đề:</label>
            </div>
            <div class="fieldItemValue">
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="200"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTitle" ValidationGroup="vgUpdateDocument"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for='field2'>
                    Tác giả:</label>
            </div>
            <div class="fieldItemValue">
                <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="field100Pct">
            <div class="fieldItemLabel">
                <label for="field1">
                    Tệp tài liệu:</label>
            </div>
            <div class="fieldItemValue">
                <asp:FileUpload ID="fuDocument" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fuDocument"
                    ErrorMessage="*" ValidationGroup="vgUpdateDocument"></asp:RequiredFieldValidator>
                <asp:HyperLink ID="lnkDocument" runat="server" Visible="false"></asp:HyperLink>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="field100Pct">
            <div class="fieldItemLabel">
                <label for="field1">
                    Ảnh minh họa:</label>
            </div>
            <div class="fieldItemValue">
                <asp:FileUpload ID="fuImage" runat="server" />
                <asp:Image ID="img" runat="server" Visible="false" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for="field1">
                    Mô tả:</label>
            </div>
            <div class="fieldItemValue">
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
            </div>
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for="field1">
                    Loại văn bản:</label>
            </div>
            <div class="fieldItemValue">
                <asp:DropDownList ID="ddlLoaivanban" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for='field2'>
                    Số ký hiệu:</label>
            </div>
            <div class="fieldItemValue">
                <asp:TextBox ID="txtSokyhieu" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for='field2'>
                    C.Q ban hành:</label>
            </div>
            <div class="fieldItemValue">
                <asp:TextBox ID="txtCoquanbanhanh" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for='field2'>
                    Ngày ban hành:</label>
            </div>
            <div class="fieldItemValue">
                <input id="txtNgaybanhanh_datepicker" class="required"
                    type="text" runat="server" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for='field2'>
                    Ngày có hiệu lực:</label>
            </div>
            <div class="fieldItemValue">
                
                <input id="txtNgaycohieuluc_datepicker" class="required"
                    type="text" runat="server" />
            </div>
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for='field2'>
                    Hết hiệu lực:</label>
            </div>
            <div class="fieldItemValue">                
                <input id="txtNgayhethieuluc_datepicker" class="required"
                    type="text" runat="server" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for='field2'>
                    Đăng công báo:</label>
            </div>
            <div class="fieldItemValue">                
                   <input id="txtNgaydangcongbao_datepicker" class="required"
                    type="text" runat="server" />
            </div>
        </div>
        <div class="field50Pct">
            <div class="fieldItemLabel">
                <label for='field2'>
                    Phạm vi:</label>
            </div>
            <div class="fieldItemValue">
                <asp:TextBox ID="txtPhamvi" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="field100Pct">
            <asp:Button ID="btnOK" runat="server" Text="Đồng ý" ValidationGroup="vgUpdateDocument"
                OnClick="btnOK_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy bỏ" CausesValidation="false" OnClick="btnReset_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<asp:GridView ID="grvDocument" runat="server" AutoGenerateColumns="False" OnRowDataBound="grvDocument_RowDataBound"
    OnSelectedIndexChanging="grvDocument_SelectedIndexChanging" AllowPaging="True"
    AllowSorting="True" OnPageIndexChanging="grvDocument_PageIndexChanging" OnSorting="grvDocument_Sorting"
    AlternatingRowStyle-CssClass="GridAltItem" HeaderStyle-CssClass="GridHeader"
    CssClass="Grid" EnableModelValidation="True" OnSelectedIndexChanged="grvDocument_SelectedIndexChanged">
    <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
    <Columns>
        <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvDocument','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="chkDelete" />
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tài liệu">
            <ItemTemplate>
                <asp:HyperLink ID="hplTailieu" runat="server" NavigateUrl='<%# Eval("PK_iDocumentID", "~/upload/doc/{0}") %>'
                    Text='<%# Eval("sTitle") %>'></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="sAuthor" HeaderText="Tác giả" SortExpression="sAuthor">
        </asp:BoundField>
        <asp:BoundField DataField="tDate" HeaderText="Ngày đăng" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="dNgaybanhanh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ban hành"
            SortExpression="dNgaybanhanh" />
        <asp:BoundField DataField="dNgayhethieuluc" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Hiệu lực đến"
            SortExpression="dNgayhethieuluc" />
        <asp:BoundField DataField="sCoquanbanhanh" HeaderText="C.Q. ban hành" SortExpression="sCoquanbanhanh" />
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
    </Columns>
    <HeaderStyle CssClass="GridHeader"></HeaderStyle>
</asp:GridView>
<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click">Xóa mục đã chọn | </asp:LinkButton>
<asp:LinkButton ID="lnkAddnew" runat="server" CausesValidation="False" OnClick="lnkAddnew_Click">Thêm mới</asp:LinkButton>
