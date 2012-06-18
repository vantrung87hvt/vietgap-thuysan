<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucContactList.ascx.cs"
    Inherits="uc_ucContactList" %>
<style type="text/css">
    #ContactList table
    {
        border-bottom: 1px solid #00a513;
        margin: 20px 0;
        width: 100%;
        border-collapse: collapse;
    }
    #ContactList table th
    {
        background: url(css/Images/bg_th.jpg) repeat-x 50% 50%;
        color: #fff;
        font-weight: bold;
        padding: 0 7px;
        margin: 20px 0 0;
        text-align: left;
    }
    #ContactList table tr
    {
    }
    #ContactList table th, #ContactList table td
    {
        color: #666;
        text-align: left;
        line-height: 1.4em;
        padding: 10px 7px;
        border-top: 1px solid #00a513;
    }
    #ContactList table a:link, #ContactList table a:visited
    {
        border-bottom: none;
    }
    #ContactList table a:hover, #ContactList table a:active, #ContactList table a:focus
    {
        color: #060;
        border-bottom: none;
    }
    #ContactList table th.scheme
    {
        background: none;
    }
    #ContactList table th a
    {
        font-weight: bold;
        background: url(../upload/css_img/icon_go.gif) no-repeat left 1px;
        padding: 2px 0 2px 18px;
    }
    #ContactList table th.row a
    {
        background: none;
    }
    #ContactList table th.row img
    {
        border: none;
        margin: 0 0 -3px 0;
    }
    #ContactList dt { float: left;clear:both; width: 7em; } 
    #ContactList dd { clear:both;float:left; margin: 5px; }
    #ContactList select { min-width: 150px; }
    #ContactList { margin: 10px 0 30px 0; position: relative; }    
    #ContactList input,
    #ContactList textarea { margin: 2px; width: 450px; }
    #ContactList dt { float: left; width: 13em; } 
    #ContactList dd { margin: 10px; }  
    #ContactList input { width: 450px; } 
    #ContactList input:focus,
    #ContactList textarea:focus { margin: 2px; background: #eee;}  
    #ContactList p { margin: 0 0 0 12em; }
    #ContactList p input { width: 150px; height: 30px; font-size: 1.1em; }
    #ContactList p input:hover { background: #eee; }
    #ContactList textarea { width: 450px; height: 150px; }

</style>
<div id="ContactList">
    <asp:Panel ID="pnList" runat="server">
        <h2>
              <asp:Label ID="lblDanhSachLienHe" runat="server" Text="<%$ Resources:Language, lblDanhSachLienHe%>"></asp:Label>
        </h2>
        <table>
            <tr>
                <th>
                   <asp:Label ID="lblHoTen" runat="server" Text="<%$ Resources:Language, lblHoTen%>"></asp:Label> 
                </th>
                <th>
                   <asp:Label ID="lblChucVu" runat="server" Text="<%$ Resources:Language, lblChucVu%>"></asp:Label>
                </th>
                <th>
                   <asp:Label ID="lblDienThoai" runat="server" Text="<%$ Resources:Language, lblDienThoai%>"></asp:Label>
                </th>
                <th>
                    Email
                </th>
            </tr>
            <asp:Repeater id="rptPhongBan" runat ="server" 
                onitemdatabound="rptPhongBan_ItemDataBound">
                <ItemTemplate>
                <asp:Panel ID = "pn" runat="server">
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblPK_iPhongBanID" Visible="false" runat="server" Text='<%#Eval("PK_iPhongBanID")%>'></asp:Label>
                            <h3>
                                <asp:Label ID="lblTenPhongBan"  runat="server"></asp:Label>
                            </h3>

                        </td>

                    </tr>
                    </asp:Panel>
                <asp:Repeater ID="rptContactList" runat="server" OnItemDataBound="rptContactList_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblPK_iContactID" Visible="false" runat="server" Text='<%#Eval("PK_iContactID")%>'></asp:Label>
                            <asp:HyperLink ID="hplName" runat="server"></asp:HyperLink>
                        </td>
                        <td>
                            <asp:Label ID="lblChucVu" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDienThoai" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

                </ItemTemplate>
            </asp:Repeater>
         
        </table>
    </asp:Panel>
    <asp:Panel ID="pnComment" runat="server">
        <dl>
             <dt>
                <asp:Label ID="lblLoi" ForeColor="Red" runat="server" Text=""></asp:Label>
            </dt>
            <dt>
                <asp:Label ID="lblSubject" runat="server" Text="<%$ Resources:Language, lblSubject%>"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtChuDe" ValidationGroup="ct" ErrorMessage="" Text="(*)" runat="server" ></asp:RequiredFieldValidator>
            </dt>
            <dd>
                <asp:TextBox ID="txtChuDe" runat="server"></asp:TextBox>
            </dd>
            <dt>
                <asp:Label ID="lblNoiDung" runat="server" Text="<%$ Resources:Language, lblContent%>"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNoiDung" ValidationGroup="ct" ErrorMessage="" Text="(*)" runat="server" ></asp:RequiredFieldValidator>
            </dt>
            <dd>
                <asp:TextBox ID="txtNoiDung" TextMode="MultiLine" Height="200px" runat="server"></asp:TextBox>
            </dd>
            <dt>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEmail" ValidationGroup="ct" ErrorMessage="" Text="(*)" runat="server" ></asp:RequiredFieldValidator>
            </dt>
            <dd>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </dd>
            <dd>
                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="ct" DisplayMode="List" ShowSummary="true" HeaderText="<%$ Resources:Language, ValidationSummary1_CL%>"
                 runat="server" />
            </dd>
        </dl>
        <div style="clear:both;margin-left:200px;">
                <asp:Button ID="btnSend" runat="server" Width="80px" Text="<%$ Resources:Language, btnGui%>"  ValidationGroup="ct"
                    onclick="btnSend_Click" />
                </div>
        
    </asp:Panel>
</div>
