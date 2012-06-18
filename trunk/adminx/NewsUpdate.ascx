<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsUpdate.ascx.cs" Inherits="adminx_NewsUpdate" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<table style="width: 629px; vertical-align: top">
  
    <tr>
        <td colspan="3" style="text-align: center">
            Quản lý Tin tức
        </td>
        <td style="text-align: center" rowspan="14" valign="top">
            <div style="height: 700px; overflow: auto">
                <asp:ListBox ID="lstbNhomtin" runat="server" Height="700px" Width="262px" SelectionMode="Multiple">
                </asp:ListBox>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Tiêu đề tin
        </td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="200"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="txtTitle" ValidationGroup="vgUpdateNews"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Ngày đăng tin
        </td>
        <td>
            
                            <input id="txtDate_datepicker" class="required"
                    type="text" runat="server"  />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate_datepicker"
                ErrorMessage="*" ValidationGroup="vgUpdateNews"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Luồng tin
        </td>
        <td>
            <asp:TextBox ID="txtTag" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td rowspan="2">
            Ảnh minh họa
        </td>
        <td valign="top">
            <asp:FileUpload ID="fuImage" runat="server"/>
            <asp:Image ID="imgNews" runat="server" Height="150px" Width="150px" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    
    <tr>
        <td>
            Kiểm duyệt
            <asp:CheckBox ID="chkVerify" runat="server" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;
        </td>
    </tr>
    
    <tr>
        <td valign="top">
            <asp:Label ID="Label1" runat="server" Text="URL:"></asp:Label>
            &nbsp;</td>
        <td>
            <asp:TextBox ID="txtUrl" runat="server" Width="90%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Mô tả
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" MaxLength="750" Height="45px"
                Width="476px"></asp:TextBox>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    
    <tr>
        
        <td>
            Nội dung
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <FTB:FreeTextBox ID="ftbNoidung" runat="server" Width="100%" SupportFolder="~/aspnet_client/FreeTextBox/"
                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
                ButtonSet="Office2003" ImageGalleryPath="~/upload/">
            </FTB:FreeTextBox>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="Đồng ý" ValidationGroup="vgUpdateCategory"
                OnClick="btnOK_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy bỏ" CausesValidation="false" OnClick="btnReset_Click" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
