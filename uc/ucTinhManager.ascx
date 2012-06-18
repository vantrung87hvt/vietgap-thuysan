<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTinhManager.ascx.cs" Inherits="uc_ucTinh" %>
<link href="../CSS/Grid_View.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    fieldset
    {
        -moz-border-radius: 7px;
        border: 1px #dddddd solid;
        margin-bottom: 20px;
        width: 550px;
    }
    
    fieldset legend
    {
        border: 1px #1a6f93 solid;
        color: black;
        font-weight: bold;
        font-family: Verdana;
        font-weight: none;
        font-size: 13px;
        padding-right: 5px;
        padding-left: 5px;
        padding-top: 2px;
        padding-bottom: 2px;
        -moz-border-radius: 3px;
    }
    
    /* Main DIV */
    .m
    {
        width: 560px;
        padding: 20px;
        height: auto;
    }
    
    /* Left DIV */
    .l
    {
        width: 140px;
        margin: 0px;
        padding: 0px;
        float: left;
        text-align: right;
    }
    
    
    /* Right DIV */
    .r
    {
        width: 300px;
        margin: 0px;
        padding: 0px;
        padding-left: 20px;
        float: left;
        text-align: left;
    }
    .rr
    {
        
        margin: 0px;
        padding: 0px;
        float: left;
        text-align: center;
    }
    .a
    {
        clear: both;
        width: 500px;
        padding: 10px;
    }
    input
    {
        width: 100%;
    }    
   
</style>
<table style="width: 100%; margin-top:20px; height: auto;">
    <tr><td><asp:GridView ID="grvTinh" runat="server" HeaderStyle-CssClass="GridHeader" 
        AllowPaging="True" AllowSorting="True" CssClass="Grid"
        AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" 
        onsorting="grvTinh_Sorting" 
        onpageindexchanging="grvTinh_PageIndexChanging" 
        onselectedindexchanging="grvTinh_SelectedIndexChanging" 
        >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkDelete" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PK_iTinhID" HeaderText="ID" SortExpression="PK_iTinhID" ></asp:BoundField>
            <asp:BoundField DataField="sTentinh" HeaderText="Tên Tỉnh" SortExpression="sTentinh" ></asp:BoundField>
            <asp:BoundField DataField="sKyhieu" HeaderText="Ký Hiệu" SortExpression="sKyhieu" ></asp:BoundField>
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
            <legend>Thông tin tỉnh</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblTentinh" runat="server" Text="Tên Tỉnh" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtTentinh" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtTentinh" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
              <div class="a">
                <div class="l">
                   <asp:Label ID="lblKyhieu" runat="server" Text="Ký Hiệu" ></asp:Label>
                </div>
                <div class="r">
                    <asp:TextBox ID="txtKyhieu" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtKyhieu" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="Không được để trống!" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>            
             <div class="a">
                <div class="l">
                  </div>
                <div class="r">
                    <asp:Button ID="btnInsert" CssClass="button" runat="server" Text="Thêm" Width="90" 
            OnClick="btnInsert_Click" ValidationGroup="adding" Visible="true" />
        <asp:Button ID="btnUpdate" CssClass="button" runat="server" Text="Sửa" Width="90" 
            OnClick="btnUpdate_Click" ValidationGroup="adding" Visible="false" />
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