<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucVideoClipsManager.ascx.cs" Inherits="adminx_ucVideoClipsManager" %>
<link href="../../css/Grid_View.css" rel="stylesheet" type="text/css" />
<table width="100%">
    <tr>
        <td></td>
        <td style="text-align: center">&nbsp;</td>
        <td></td>
    </tr>
    <tr>
        <td style="width: 10%"></td>
        <td>
            <asp:Panel ID="pnlEdit" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td width="30%" colspan="2" style="width: 100%" align="center">
                        <asp:Label ID="lblInfo" runat="server" 
                            Text="<%$ Resources:language,lblDanhmucVideo %>"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" colspan="2" align="center">
                        <asp:Label ID="lblLoi" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        &nbsp;</td>
                    <td width="70%">&nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" width="20%">
                        <asp:Label ID="lblName" runat="server" Text="Tiêu đề"></asp:Label>
                    </td>
                    <td valign="middle" width="70%">
                        
                        <asp:TextBox ID="txtTieude" runat="server" 
                            Width="95%" Height="22px"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="rqTenChungchi" runat="server" 
                            ControlToValidate="txtChungchi" ErrorMessage="*" ValidationGroup="vgGroup"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="20%">
                        <asp:Label ID="lblMota" runat="server" Text="<%$Resources:language,lblMota %>"></asp:Label>
                    </td>
                    <td valign="middle" width="70%">
                        
                        <asp:TextBox ID="txtMota" runat="server" 
                            Width="95%" Height="22px"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="rqMota" runat="server" 
                            ControlToValidate="txtMota" ErrorMessage="*" ValidationGroup="vgGroup"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="20%">
                        <asp:Label ID="lblTep" runat="server" Text="Tệp"></asp:Label>
                    </td>
                    <td valign="middle" width="70%">
                        <asp:FileUpload ID="fluVideoClips" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="20%">
                    </td>
                    <td valign="middle" width="70%">
                        <asp:Repeater ID="rptVideoClips" runat="server">
                            <ItemTemplate>
                                <object id="player" classid="clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6" height="170"
                                    width="300">
                                    <param name="url" value='<%# "VideoHandler.ashx?iVideoID=" + Eval("PK_iVideoID") %>' />
                                    <param name="showcontrols" value="true" />
                                    <param name="autostart" value="true" />
                                </object>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="Thêm" onclick="btnOK_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Bỏ qua" 
                            onclick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblThongbao" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </td>
        <td style="width: 10%"></td>
    </tr>
    <tr>
        <td></td>
        <td align="center">
            <asp:GridView ID="grvChungchi" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" 
                            onsorting="grvChungchi_Sorting" Width="100%"
                            AlternatingRowStyle-CssClass="GridAltItem"
                            HeaderStyle-CssClass="GridHeader"
                            CssClass="Grid" EnableModelValidation="True" 
                onselectedindexchanging="grvChungchi_SelectedIndexChanging">
<AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
                <Columns>
                     <asp:TemplateField HeaderText="Chọn tất">
                        <HeaderTemplate>
                            <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvGroup','chkDelete');" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" id="chkDelete" />               
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PK_iChungchiID" HeaderText="ID" 
                        SortExpression="PK_iChungchiID" />
                    <asp:BoundField DataField="sTieude" HeaderText="Tiêu đề" 
                        SortExpression="sTieude" >
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField DataField="sMota" HeaderText="Mô tả" SortExpression="sMota" />
                     <asp:BoundField DataField="iSolanxem" HeaderText="Lần xem" 
                         SortExpression="iSolanxem" />
                     <asp:BoundField DataField="iDungluong" HeaderText="Dung lượng" 
                         SortExpression="iDungluong" />
                     <asp:TemplateField HeaderText="Kích thước">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server"></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                    <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false" Text="Sửa" />
                </Columns>

<HeaderStyle CssClass="GridHeader"></HeaderStyle>
            </asp:GridView>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td align="right">
            <asp:LinkButton ID="lbtnAddnew" runat="server" CausesValidation="False" 
                            onclick="lbtnAddnew_Click">Thêm mới | </asp:LinkButton>
            <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
                onclick="lbtnDelete_Click" OnClientClick="return confirm('Bạn có thực sự muốn xóa không?');">Xóa mục đã chọn</asp:LinkButton>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>