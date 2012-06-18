<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPosition.ascx.cs" Inherits="adminx_ucPosition" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />
<table width="100%">
    <tr>
        <td></td>
        <td style="text-align: center">&nbsp;</td>
        <td></td>
    </tr>
    <tr>
        <td style="width: 10%"></td>
        <td>
            <table width="100%">
                <tr>
                    <td width="30%" colspan="2" style="width: 100%" align="center">
                        <asp:Label ID="lblInfo" runat="server" 
                            Text="<%$Resources:language,danhsachvitriquangcao %>"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30%" colspan="2" align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="lblPositionID" runat="server">ID Position:</asp:Label>
                    </td>
                    <td width="70%"><asp:DropDownList ID="ddlPositionID" runat="server" 
                            AutoPostBack="True" onselectedindexchanged="ddlPositionID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblName" runat="server" Text="<%$Resources:language,tenvitri%>"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtPosName" runat="server" 
                            Width="90%" Enabled="False"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="rqVitri" runat="server" 
                            ControlToValidate="txtPosName" ErrorMessage="*" ValidationGroup="vgPosition"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="<%$Resources:language,them %>" onclick="btnOK_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="<%$Resources:language,boqua %>"
                            onclick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblThongbao" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 10%"></td>
    </tr>
    <tr>
        <td></td>
        <td align="center">


<asp:GridView ID="grvPosition" runat="server" AutoGenerateColumns="False"
    AllowPaging="True" AllowSorting="True" 
                onselectedindexchanging="grvPosition_SelectedIndexChanging" 
                onsorting="grvPosition_Sorting" Width="100%"
                 AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid"
                >
    <Columns>
         <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvPosition','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
        <asp:BoundField DataField="iPositionID" HeaderText="ID" 
            SortExpression="sTitle" />
        <asp:BoundField DataField="sName" HeaderText="Tên vị trí" 
            SortExpression="sName" >
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" CausesValidation="false"
            Text="Sửa" />
        
    </Columns>
</asp:GridView>


        </td>
        <td></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td align="right">


<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
    onclick="lbtnDelete_Click" Text="<%$Resources:language,xoamucdachon %>"></asp:LinkButton>



        </td>
        <td>&nbsp;</td>
    </tr>
</table>
