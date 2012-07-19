<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucVideoClipsManager.ascx.cs" Inherits="adminx_ucVideoClipsManager" %>
<%@ Register Assembly="Media-Player-ASP.NET-Control" Namespace="Media_Player_ASP.NET_Control"
    TagPrefix="cc1" %>
<%@ Register Assembly="ASPNetVideo.NET2" Namespace="ASPNetVideo" TagPrefix="ASPNetVideo" %>
<link href="../../css/Grid_View.css" rel="stylesheet" type="text/css" />
<script src='<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.10.min.js") %>' type="text/javascript"></script>
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
                        
                        <asp:RequiredFieldValidator ID="rqTieude" runat="server" 
                            ControlToValidate="txtTieude" ErrorMessage="*" ValidationGroup="vgGroup"></asp:RequiredFieldValidator>
                        
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
                        
                        <%--<ASPNetVideo:WindowsMedia ID="WindowsMedia1" runat="server">
                        </ASPNetVideo:WindowsMedia>--%>
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
            <asp:Panel runat="server" ID="pnXemvideo">
                <div runat="server" id="divVideo"></div>
                <script type="text/javascript">
                    var swfUrl = '<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.11.swf") %>';
                    $(document).ready(function () {
                        flowplayer('player', swfUrl, { clip: { autoPlay: false}});
                    });
                </script>
            </asp:Panel>
        </td>
        <td style="width: 10%"></td>
    </tr>
    <tr>
        <td></td>
        <td align="center">
            <asp:GridView ID="grvVideoClips" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" 
                            onsorting="grvVideoClips_Sorting" Width="100%"
                            AlternatingRowStyle-CssClass="GridAltItem"
                            HeaderStyle-CssClass="GridHeader"
                            CssClass="Grid" EnableModelValidation="True" 
                onselectedindexchanging="grvVideoClips_SelectedIndexChanging" 
                onrowcommand="grvVideoClips_RowCommand">
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
                    <asp:BoundField DataField="PK_iVideoID" HeaderText="ID" 
                        SortExpression="PK_iVideoID" />
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
                     <asp:TemplateField HeaderText="Duyệt">
                         <ItemTemplate>
                             <asp:LinkButton CommandName="Xem" CommandArgument='<%# Bind("sTentep") %>' ID="lbtnXemvideo" runat="server">Duyệt</asp:LinkButton>
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