<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucConfig.ascx.cs" Inherits="UC_ucConfig" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<table width="100%">
    <tr>
        <td></td>
        <td style="text-align: center"></td>
        <td></td>
    </tr>
    <tr>
        <td style="width: 10%"></td>
        <td>
            <table width="100%">
                <tr>
                    <td width="30%" colspan="2" align="center">
                        <asp:Label ID="lblInfo" runat="server" Text="Cấu hình hệ thống"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" colspan="2" align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCauhinh" runat="server">Cấu hình:</asp:Label>
                    </td>
                    <td align="left" width="70%"><asp:DropDownList ID="ddlConfigName" runat="server" 
                            onselectedindexchanged="ddlConfigName_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <asp:Panel ID="pnlNoidung" runat="server">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblValue" runat="server">Nội dung:</asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        
                       <FTB:FreeTextBox ID="ftbNoidung" runat="server" Width="100%" SupportFolder="~/aspnet_client/FreeTextBox/"
                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
                ButtonSet="Office2003" ImageGalleryPath="~/upload/">
            </FTB:FreeTextBox>
                        
                        <asp:RequiredFieldValidator ID="rqNoidung" runat="server" 
                            ControlToValidate="ftbNoidung" ErrorMessage="*" 
                            ValidationGroup="Config"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="Cập nhật" OnClick="btnOK_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:language,boqua %>" 
                            onclick="btnCancel_Click" />
                    </td>
                </tr>
                </asp:Panel>
            </table>
        </td>
        <td style="width: 10%"></td>
    </tr>
    <tr>
        <td></td>
        <td align="center">
            <asp:Label ID="lblThongbao" runat="server"></asp:Label>
        </td>
        <td></td>
    </tr>
</table>
