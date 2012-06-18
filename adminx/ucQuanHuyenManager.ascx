<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucQuanHuyenManager.ascx.cs" Inherits="adminx_ucQuanHuyenManager" %>

<h2>
Quản Lý Thông Tin Quận/ Huyện
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
    <td><asp:GridView ID="grvQuanHuyen" runat="server" HeaderStyle-CssClass="GridHeader" 
        AllowPaging="True" AllowSorting="True" CssClass="Grid"
        AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" 
        onsorting="grvQuanHuyen_Sorting" 
        onpageindexchanging="grvQuanHuyen_PageIndexChanging" 
        onselectedindexchanging="grvQuanHuyen_SelectedIndexChanging" 
        >
        <Columns>
           <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvQuanHuyen','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
            <asp:BoundField DataField="PK_iQuanHuyenID" HeaderText="ID" SortExpression="PK_iQuanHuyenID" ></asp:BoundField>
            <asp:BoundField DataField="sTen" HeaderText="Tên" SortExpression="sTen" ></asp:BoundField>
            <asp:BoundField DataField="sKytuviettat" HeaderText="Ký hiệu viết tắt" SortExpression="sKytuviettat" ></asp:BoundField>
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
            <legend>Thông tin quận huyện</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblQuanHuyen" runat="server" Text="Tên" ></asp:Label></div>
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
                   <asp:Label ID="lblVietTat" runat="server" Text="Ký tự viết tắt" ></asp:Label>
                </div>
                <div class="r">
                    <asp:TextBox ID="txtKyTu" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtKyTu" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>       
            <div class="a">
                <div class="l">
                   Quận
                </div>
                <div class="r">
                    <asp:CheckBox ID="cbQuan" runat="server" />
                </div>
                <div class="rr">
                  
                </div>
            </div>            
             <div class="a">
                <div class="l">
                    <asp:Label ID="lblTinh" runat="server" Text="Tỉnh" ></asp:Label></div>
                <div class="r">
                    <asp:DropDownList ID="ddlTinh" runat="server">
                    </asp:DropDownList>
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


