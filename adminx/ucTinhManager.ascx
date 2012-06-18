<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTinhManager.ascx.cs" Inherits="adminx_ucTinhMa" %>
<h2>
Quản Lý Thông Tin Tỉnh
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
    <td><asp:GridView ID="grvTinh" runat="server" HeaderStyle-CssClass="GridHeader" 
        AllowPaging="True" AllowSorting="True" CssClass="Grid"
        AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" 
        onsorting="grvTinh_Sorting" 
        onpageindexchanging="grvTinh_PageIndexChanging" 
        onselectedindexchanging="grvTinh_SelectedIndexChanging" 
        >
        <Columns>
           <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvTinh','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
            <asp:BoundField DataField="PK_iTinhID" HeaderText="ID" SortExpression="PK_iTinhID" ></asp:BoundField>
            <asp:BoundField DataField="sTentinh" HeaderText="Tên" SortExpression="sTentinh" ></asp:BoundField>
            <asp:BoundField DataField="sKyhieu" HeaderText="Ký hiệu" SortExpression="sKyhieu" ></asp:BoundField>
            <asp:BoundField DataField="ISO31662" HeaderText="ISO31662" SortExpression="ISO31662" ></asp:BoundField>
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
<asp:Panel ID="pnAdd" runat="server" Visible="false" >

    <div class="m">
        <fieldset>
            <legend>Thông tin tinh</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblTinh" runat="server" Text="Tên" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtTen" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtTen" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                   <asp:Label ID="lblVietTat" runat="server" Text="Ký hiệu" ></asp:Label>
                </div>
                <div class="r">
                    <asp:TextBox ID="txtKyHieu" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtKyHieu" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>                                      
              <div class="a">
                <div class="l">
                   <asp:Label ID="lblIso" runat="server" Text="ISO31662" ></asp:Label>
                </div>
                <div class="r">
                    <asp:TextBox ID="txtISO31662" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtISO31662" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
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


