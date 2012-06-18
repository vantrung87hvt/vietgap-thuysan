<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListContact.ascx.cs" Inherits="adminx_ucListContact" %>
<h2>
Quản Lý Liên Hệ
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
    <td><asp:GridView ID="grvContact" runat="server" HeaderStyle-CssClass="GridHeader" 
        AllowPaging="True" AllowSorting="True" CssClass="Grid"
        AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" 
        onsorting="grvContact_Sorting" 
        onpageindexchanging="grvContact_PageIndexChanging" 
        onselectedindexchanging="grvContact_SelectedIndexChanging" 
        >
        <Columns>
             <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvContact','chkDelete');" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
            <asp:BoundField DataField="PK_iUContactID" HeaderText="ID" SortExpression="PK_iUContactID" ></asp:BoundField>
            <asp:BoundField DataField="sTitle" HeaderText="Tiêu đề" SortExpression="sTitle" ></asp:BoundField>            
            <asp:BoundField DataField="sEmail" HeaderText="Fax" SortExpression="sEmail" ></asp:BoundField>
            <asp:BoundField DataField="tDate" HeaderText="Ngày" SortExpression="tDate" ></asp:BoundField>
            <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Chi tiết" ></asp:ButtonField>
        </Columns>
        <HeaderStyle CssClass="GridHeader"></HeaderStyle>
        <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
    </asp:GridView></td></tr>
    <tr><td>        
        <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
            onclick="lbtnDelete_Click" OnClientClick="return confirm('Chắc chắn xóa?')">Xóa đã chọn</asp:LinkButton>
    </td></tr>
</table>
<asp:Panel ID="pnAdd" runat="server" Visible="false" >
    <div class="m">
        <fieldset>
            <legend>Thông tin người được liên hệ</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblHoten" runat="server" Text="Họ tên" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtHoTen" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                  
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblChucVu" runat="server" Text="Chức vụ" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtChucVu" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                  
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblPhongBan" runat="server" Text="Phòng" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtPhongBan" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                  
                </div>
            </div>
         </fieldset>
    </div>
    <div class="m">
        <fieldset>
            <legend>Thông tin liên hệ</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblContact" runat="server" Text="Tiêu đề" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtTieuDe" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                  
                </div>
            </div>
             <div class="a">
                <div class="l">
                    <asp:Label ID="lblEmail" runat="server" Text="Email" ></asp:Label></div>
                <div class="r">
                   <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                 
                </div>
            </div>
             <div class="a">
                <div class="l">
                    <asp:Label ID="lblNgayTao" runat="server" Text="Thời gian" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                  
                </div>
            </div>
              <div class="a">
                <div class="l">
                   <asp:Label ID="lblNoiDung" runat="server" Text="Nội dung" ></asp:Label>
                </div>
                <div class="r">
                    <asp:TextBox ID="txtNoiDung" runat="server" Width="100%" TextMode="MultiLine" Height="100px" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                     
                </div>
            </div>                               
             <div class="a">
                <div class="l">
                  </div>
                <div class="r">
                    <asp:Button ID="btnOK" CssClass="button" runat="server" Text="Ẩn chi tiết" Width="90" 
            OnClick="btnOK_Click" ValidationGroup="adding" Visible="true" />       
                </div>
                <div class="rr">
                  
                </div>
            </div>
            <div class="a">
            </div>
        </fieldset>
    </div>
</asp:Panel>