<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucGiaytoManager.ascx.cs" Inherits="uc_ucGiaytoManager" %>

<h2>
    Quản Lý Giấy tờ
</h2>
<table style="width: 100%; margin-top:20px; height: auto;">
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
            <asp:LinkButton ID="btnSearchByID" runat="server" onclick="btnSearchByID_Click" 
                Text="Tìm kiếm" />|
            <asp:LinkButton ID="btnShowAll" runat="server" onclick="btnShowAll_Click" 
                Text="Hiện toàn bộ" />
        </td>
    </tr>
    <tr>
    <td><asp:GridView ID="grvGiayto" runat="server" HeaderStyle-CssClass="GridHeader" 
        AllowPaging="True" AllowSorting="True" CssClass="Grid"
        AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" 
        onsorting="grvMucdo_Sorting" 
        onpageindexchanging="grvMucdo_PageIndexChanging" 
        onselectedindexchanging="grvMucdo_SelectedIndexChanging" 
            EnableModelValidation="True" onrowdatabound="grvGiayto_RowDataBound" 
        >
        <Columns>
           <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <%--<input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvMucdo','chkDelete');" />--%>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="CheckUncheckall();" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
            <asp:BoundField DataField="PK_iGiaytoID" HeaderText="ID" SortExpression="PK_iGiaytoID" ></asp:BoundField>
            <asp:BoundField DataField="sTengiayto" HeaderText="Tên giấy tờ" SortExpression="sTengiayto" ></asp:BoundField>
            <asp:TemplateField HeaderText="Loại giấy tờ" SortExpression="bCSNT">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("bCSNT") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLoaiGiaytokemtheo" runat="server" Text='<%# Bind("bCSNT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Sửa" ></asp:ButtonField>
        </Columns>
        <HeaderStyle CssClass="GridHeader"></HeaderStyle>
        <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
    </asp:GridView></td></tr>
    <tr><td>
        <asp:LinkButton ID="lbtnAdd" runat="server" CausesValidation="false" 
            onclick="lbtnAdd_Click" >Thêm mới | </asp:LinkButton>
        <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
            onclick="lbtnDelete_Click" OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>
    </td></tr>
</table>

<script language="javascript" type="text/javascript">
    function CheckUncheckall() {
        var chks = document.getElementsByTagName("input");
        var chkAll = document.getElementById("chkAll");
        for (var i = 0; i < chks.length; i++)
        {
            if (chks[i].type == "checkbox") chks[i].checked = chkAll.checked;
        }
    }
    </script>

<asp:Panel ID="pnAdd" runat="server" Visible="false" >

    <div class="m">
        <fieldset>
            <legend>Thông tin giấy tờ</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblItem1" runat="server" Text="Tên giấy tờ" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtTengiayto" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <div class="rr">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtTengiayto" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>    
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblLoaigiayto" runat="server" Text="Loại giấy tờ" ></asp:Label></div>
                <div class="r">
                    <asp:CheckBox ID="chkLoaigiayto" runat="server" Text="Cơ sở nuôi trồng" />
                </div>
                
                <div class="rr">
                   
                </div>
            </div>                   
             <div class="a">
                <div class="l">
                  </div>
                <div class="r">
                    <asp:Button ID="btnOK" CssClass="button" runat="server" Text="Thêm" Width="90" 
            OnClick="btnOK_Click" ValidationGroup="adding" Visible="true" />       
        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Huỷ" Width="90" 
            OnClick="btnCancel_Click" />
                </div>
                <div class="rr">
                  
                </div>
            </div>
            <div class="a">
            </div>
        </fieldset>
    </div>
</asp:Panel>