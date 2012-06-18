<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDoituongnuoiManager.ascx.cs" Inherits="uc_ucDoituongnuoi" %>

<table style="width: 100%; margin-top:20px; height: auto;">
    <tr><td><asp:GridView ID="grvDoituongnuoi" runat="server" HeaderStyle-CssClass="GridHeader" 
        AllowPaging="True" AllowSorting="True" CssClass="Grid"
        AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" 
        onsorting="grvDoituongnuoi_Sorting" 
        onpageindexchanging="grvDoituongnuoi_PageIndexChanging" 
        onselectedindexchanging="grvDoituongnuoi_SelectedIndexChanging" 
        >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkDelete" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PK_iDoituongnuoiID" HeaderText="ID" SortExpression="PK_iDoituongnuoiID" ></asp:BoundField>
            <asp:BoundField DataField="sTendoituong" HeaderText="<%$ Resources:Language, lblTenDoiTuongL%>" SortExpression="sTendoituong" ></asp:BoundField>
            <asp:ButtonField CommandName="Select" HeaderText="<%$ Resources:Language, lblSuaL%>" ShowHeader="True" Text="<%$ Resources:Language, lblSuaL%>" ></asp:ButtonField>
        </Columns>
        <HeaderStyle CssClass="GridHeader"></HeaderStyle>
        <AlternatingRowStyle CssClass="GridAltItem"></AlternatingRowStyle>
    </asp:GridView></td></tr>
    <tr><td>
        <asp:LinkButton ID="lbtnAdd" runat="server" CausesValidation="false" 
            onclick="lbtnAdd_Click" ><asp:Label ID="lblDoiTuongNuoiL" runat="server" Text="<%$ Resources:Language, lblThemMoiL%>"></asp:Label></asp:LinkButton>
        <asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
            onclick="lbtnDelete_Click" OnClientClick="return confirm('Chắc chắn xóa?')"><asp:Label ID="Label1" runat="server" Text="<%$ Resources:Language, lblXoaDaChonL%>"></asp:Label></asp:LinkButton>
    </td></tr>
</table>
<asp:Panel ID="pnAdd" runat="server" Visible="false" >
<div class="m">
        <fieldset>
            <legend><asp:Label ID="Label2" runat="server" Text="<%$ Resources:Language, lblThongTinDoiTuongNuoiL%>"></asp:Label></legend>
            <div class="a">
                <div class="l">
                   <asp:Label ID="lblTendoituong" runat="server" Text="<%$ Resources:Language, lblTenDoiTuongL%>" ></asp:Label></div>
                <div class="r">
                    <asp:TextBox ID="txtTendoituong" runat="server" CssClass="txtbox" ></asp:TextBox>
                </div>
                <div class="rr">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="margin̉-left: 10px;" runat="server" ControlToValidate="txtTendoituong" 
                Display="Dynamic" ValidationGroup="adding" ErrorMessage="<%$ Resources:Language, EKhongDeTrongL%>" 
                SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
              
           
             <div class="a">
                <div class="l">
                  </div>
                <div class="r">
                <asp:Button ID="btnInsert" CssClass="button" runat="server" Text="<%$ Resources:Language, them%>" Width="90" 
            OnClick="btnInsert_Click" ValidationGroup="adding" Visible="true" />
        <asp:Button ID="btnUpdate" CssClass="button" runat="server" Text="<%$ Resources:Language, lblSuaL%>" Width="90" 
            OnClick="btnUpdate_Click" ValidationGroup="adding" Visible="false" />
        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="<%$ Resources:Language, lblHuyL%>" Width="90" 
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