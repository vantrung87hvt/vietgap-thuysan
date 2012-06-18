<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPhuongphapkiemtraManager.ascx.cs"
    Inherits="uc_ucTinh" %>
<link href="../CSS/Grid_View.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function checkAll() {

    }
</script>
<h2>
    Quản Lý Phương pháp kiểm tra
</h2>
<table style="width: 100%; margin-top: 20px; height: auto;">
    <tr>
        <td width="100%">
            <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
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
            <asp:GridView ID="grvPhuongphapkiemtra" runat="server" HeaderStyle-CssClass="GridHeader"
                AllowPaging="True" AllowSorting="True" CssClass="Grid" AlternatingRowStyle-CssClass="GridAltItem"
                AutoGenerateColumns="False" OnSorting="grvPhuongphapkiemtra_Sorting" OnPageIndexChanging="grvPhuongphapkiemtra_PageIndexChanging"
                OnSelectedIndexChanging="grvPhuongphapkiemtra_SelectedIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn tất">
                        <HeaderTemplate>
                            <%--<input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvPhuongphapkiemtra','chkDelete');" />--%>
                            <input type="checkbox" style="width: 20px;" id="chkAll" onclick="CheckUncheckall();" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkDelete" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PK_iPhuongphapkiemtraID" HeaderText="ID" SortExpression="PK_iPhuongphapkiemtraID">
                    </asp:BoundField>
                    <asp:BoundField DataField="sTenphuongphapkiemtra" HeaderText="Tên phương pháp kiểm tra"
                        SortExpression="sTenphuongphapkiemtra"></asp:BoundField>
                    <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Sửa">
                    </asp:ButtonField>
                </Columns>
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
                <PagerStyle HorizontalAlign="Right" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="lbtnAdd" runat="server" CausesValidation="false" OnClick="lbtnAdd_Click">Thêm mới | </asp:LinkButton>
            <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" OnClick="lbtnDelete_Click"
                OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>
        </td>
    </tr>
</table>
<script language="javascript" type="text/javascript">
    function CheckUncheckall() {
        var chks = document.getElementsByTagName("input");
        var chkAll = document.getElementById("chkAll");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i].type == "checkbox") chks[i].checked = chkAll.checked;
        }
    }
</script>
<asp:Panel ID="pnAdd" runat="server" Visible="false">
    <div class="m">
        <fieldset>
            <legend>Thông tin phương pháp kiểm tra</legend>
            <table>
                <tr>
                    <td>
                        Phương pháp:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenphuongphapkiemtra" runat="server" Width="300px" 
                            TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhuongphapkiemtra" runat="server" ErrorMessage="*" ControlToValidate="txtTenphuongphapkiemtra" ValidationGroup="adding">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnOK" CssClass="button" runat="server" Text="Thêm" Width="90" OnClick="btnOK_Click"
                        ValidationGroup="adding" Visible="true" />
                    <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Huỷ" Width="90"
                        OnClick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Panel>
