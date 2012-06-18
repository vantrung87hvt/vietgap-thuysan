<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FAQManager.ascx.cs" Inherits="INVI.INVINews.Admin.DocumentManager" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<link href="css/FormEdit.css" rel="Stylesheet" type="text/css" />
<asp:Panel ID="pnEdit" runat="server" Visible="false">
<div class="title">
    <h2>Quản lý FAQ</h2>
</div>
<div class="fieldItemLabel">
    <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
 </div>

<div class="fieldForm" id="fieldForm" > 
<div class="field100Pct">
  <div class="fieldItemLabel">
   <label for="field1">Loại câu hỏi</label>
  </div>
  <div class="fieldItemValue">
      <asp:DropDownList ID="ddlLoaiCauHoi" runat="server">
      </asp:DropDownList>
  </div>								
 </div>
 <div class="clear"></div>
 <div class="field100Pct">
  <div class="fieldItemLabel">
   <label for="field1">Câu hỏi:</label>
  </div>
  <div class="fieldItemValue">
     <%-- <asp:TextBox ID="txtCauhoi" runat="server" TextMode="MultiLine" 
           MaxLength="500" Height="84px" Width="583px"></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtCauhoi" ErrorMessage="*" 
                ValidationGroup="vg"></asp:RequiredFieldValidator>--%>
     <FTB:FreeTextBox ID="txtCauhoi" runat="server" Width="583" SupportFolder="~/aspnet_client/FreeTextBox/"
                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
                ButtonSet="Office2003" ImageGalleryPath="~/upload/">
      </FTB:FreeTextBox>        
    
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtCauhoi" ErrorMessage="*" 
                ValidationGroup="vg"></asp:RequiredFieldValidator>
  </div>								
 </div>
 <div class="clear"></div>
 <div class="field100Pct">
  <div class="fieldItemLabel">
   <label for="field1">Câu trả lời</label>
  </div>
  <div class="fieldItemValue">
      <FTB:FreeTextBox ID="txtCautraloi" runat="server" Width="583" SupportFolder="~/aspnet_client/FreeTextBox/"
                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
                ButtonSet="Office2003" ImageGalleryPath="~/upload/">
      </FTB:FreeTextBox>  
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtCautraloi" ErrorMessage="*" 
                ValidationGroup="vg"></asp:RequiredFieldValidator>
  </div>								
 </div>
 <div class="clear"></div>
 
 <div class="field100Pct">
    	<asp:Button ID="btnOK" runat="server" Text="Đồng ý" 
                ValidationGroup="vg" onclick="btnOK_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy bỏ" 
                CausesValidation="false" onclick="btnReset_Click" />			
 </div>
 <div class="clear"></div>
 </div>
 </asp:Panel>

     Tìm kiếm&nbsp; :&nbsp;
            <asp:TextBox ID="txtSearchByID" runat="server" Width="234px"></asp:TextBox>
&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="ID:"></asp:Label><asp:TextBox
                ID="txtID" runat="server" Width="50px"></asp:TextBox>
            <asp:LinkButton ID="btnSearchByID" runat="server" onclick="btnSearchByID_Click" 
                Text="Tìm kiếm" />|
            <asp:LinkButton ID="btnShowAll" runat="server" onclick="btnShowAll_Click" 
                Text="Hiện toàn bộ" />
<asp:GridView ID="grvFAQ" runat="server" AutoGenerateColumns="False" 
    onselectedindexchanging="grvFAQ_SelectedIndexChanging" 
    AllowPaging="True" AllowSorting="True" 
    onpageindexchanging="grvFAQ_PageIndexChanging" 
    onsorting="grvFAQ_Sorting"
     AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid" EnableModelValidation="True" 
    >
<AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
    <Columns>
         <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvFAQ','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
               <asp:CheckBox runat="server" id="chkDelete" />
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>      
        <asp:BoundField DataField="sQuestion" HeaderText="Câu hỏi" SortExpression="sQuestion"></asp:BoundField>
        <asp:BoundField DataField="dDate" HeaderText="Ngày đăng" SortExpression="dDate"
            DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="iViews" 
            HeaderText="Lượt xem" SortExpression="iViews" />     
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
        
    </Columns>

<HeaderStyle CssClass="GridHeader"></HeaderStyle>
</asp:GridView>
<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click">Xóa mục đã chọn | </asp:LinkButton>
<asp:LinkButton ID="lnkAddnew" runat="server" CausesValidation="False" 
    onclick="lnkAddnew_Click">Thêm mới</asp:LinkButton>



