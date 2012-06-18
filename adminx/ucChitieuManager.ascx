<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucChitieuManager.ascx.cs" Inherits="uc_ucChitieuManager" %>
<link href="../CSS/Grid_View.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function checkAll() {
        
    }
</script>
<h2>
    Quản Lý Chỉ tiêu
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
    <td>
        <asp:GridView ID="grvChiTieu" runat="server" HeaderStyle-CssClass="GridHeader" 
            AllowPaging="True" AllowSorting="True" CssClass="Grid"
            AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" 
            onsorting="grvChiTieu_Sorting" 
            onpageindexchanging="grvChiTieu_PageIndexChanging" 
            onselectedindexchanging="grvChiTieu_SelectedIndexChanging" 
            >
            <Columns>
               <asp:TemplateField HeaderText="Chọn tất">
                <HeaderTemplate>
                    <%--<input type="checkbox" style="width: 20px;" id="chkAll" onclick="javascript:checkAll(this,'grvChiTieu','chkDelete');" />--%>
                    <input type="checkbox" style="width: 20px;" id="chkAll" onclick="CheckUncheckall();" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox runat="server" id="chkDelete" />               
                </ItemTemplate>
                <HeaderStyle Width="25px" />
                </asp:TemplateField>
                <asp:BoundField DataField="PK_iChitieuID" HeaderText="ID" SortExpression="PK_iChitieuID" ></asp:BoundField>
                <asp:BoundField DataField="iThuthu" HeaderText="Số thứ tự" SortExpression="iThuthu" ></asp:BoundField>
                
                <asp:templatefield headertext="Danh mục chỉ tiêu">
                    <itemtemplate>
                        <asp:label id="TenDanhmucchitieu" Text='<%# getsTendanhmucchitieu((int)DataBinder.GetPropertyValue(Container.DataItem, "FK_iDanhmucchitieuID")) %>' runat="server"/> 
                    </itemtemplate>
                </asp:templatefield>
                <asp:BoundField DataField="sNoidung" HeaderText="Nội dung" SortExpression="sNoidung" ></asp:BoundField>
                <asp:BoundField DataField="sYeucauvietgap" HeaderText="Yêu cầu theo VietGAP" SortExpression="sYeucauvietgap" ></asp:BoundField>
                <asp:templatefield headertext="Mức độ">
                    <itemtemplate>
                        <asp:label id="Tenmucdo" Text='<%# getsTenmucdo((int)DataBinder.GetPropertyValue(Container.DataItem, "FK_iMucdoID")) %>' runat="server"/> 
                    </itemtemplate>
                </asp:templatefield>
                <asp:BoundField DataField="sGhichu" HeaderText="Ghi chú" SortExpression="sGhichu" ></asp:BoundField>
                <asp:ButtonField CommandName="Select" HeaderText="Sửa" ShowHeader="True" Text="Sửa" >
            </asp:ButtonField>
            </Columns>
            <HeaderStyle CssClass="GridHeader"></HeaderStyle>
            <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
        </asp:GridView>
    </td>
    </tr>
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
            <legend>Thông tin chỉ tiêu</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblItem1" runat="server" Text="Danh mục chỉ tiêu" ></asp:Label></div>
                <div class="r">
                    <asp:DropDownList runat="server" id="ddlDanhmucchitieu"></asp:DropDownList>
                </div>
            </div> 
            <div class="a">
                <div class="l">
                   <asp:Label ID="lblIThutu" runat="server" Text="Số thứ tự" ></asp:Label>
                </div>
                <div class="r">
                    <asp:TextBox runat="server" id="txtIThutu"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtIThutu" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div> 
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblItem2" runat="server" Text="Nội dung" ></asp:Label></div>
                <div class="r">
                    <textarea id="txtNoidung" runat="server" CssClass="txtbox" cols="50" rows="4"></textarea>
                </div>
                <div class="rr">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtNoidung" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblItem3" runat="server" Text="Yêu cầu theo VietGAP" ></asp:Label></div>
                <div class="r">
                    <textarea id="txtYeucauvietgap" runat="server" CssClass="txtbox" cols="50" rows="4"></textarea>
                </div>
                <div class="rr">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtYeucauvietgap" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblItem4" runat="server" Text="Mức độ" ></asp:Label></div>
                <div class="r">
                    <asp:DropDownList ID="ddlMucdo" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="Label2" runat="server" Text="Phương pháp kiểm tra" cols="50" rows="4" ></asp:Label></div>
                <div class="r">
                    <asp:DropDownList ID="ddlPhuongphapkiemtra" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblItem5" runat="server" Text="Ghi chú" ></asp:Label></div>
                <div class="r">
                    <textarea id="txtGhichu" runat="server" CssClass="txtbox" cols="50" rows="4"></textarea>
                </div>
            </div>        
             <div class="a">
                <div class="l">
                  </div>
                <div class="r">
                    <asp:Button ID="btnOK" CssClass="button" runat="server" Text="Lưu" Width="90" 
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