<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCreateEmailTemplate.ascx.cs" Inherits="adminx_ucCreateEmailTemplate" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<h2>
    Cập nhật nội dung email xác nhận đăng ký
</h2>
<table>
    <tr>
        <td>
            Không được xóa ##UserName## và ##URL##
        </td>
    </tr>
    <tr>
        <td>
          <FTB:FreeTextBox ID="ftbNoidung" runat="server" Width="100%" SupportFolder="~/aspnet_client/FreeTextBox/"
                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
                ButtonSet="Office2003" ImageGalleryPath="~/upload/">
            </FTB:FreeTextBox>    
        </td>

    </tr>
    <tr>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="Cập nhật" onclick="btnOK_Click" />
        </td>
    </tr>
</table>
