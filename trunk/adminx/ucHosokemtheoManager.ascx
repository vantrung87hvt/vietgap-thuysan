﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucHosokemtheoManager.ascx.cs" Inherits="uc_ucTinh" %>
<h2>
    Quản Lý Hồ sơ kèm theo
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
    <td><asp:GridView ID="grvHosokemtheo" runat="server" HeaderStyle-CssClass="GridHeader" 
        AllowPaging="True" AllowSorting="True" CssClass="Grid"
        AlternatingRowStyle-CssClass="GridAltItem" AutoGenerateColumns="False" 
        onsorting="grvHosokemtheo_Sorting" 
        onpageindexchanging="grvHosokemtheo_PageIndexChanging" 
        onselectedindexchanging="grvHosokemtheo_SelectedIndexChanging" 
        >
        <Columns>
           <asp:TemplateField HeaderText="Chọn tất">
            <HeaderTemplate>
                <input type="checkbox" style="width: 20px;" id="chkAll" onclick="CheckUncheckall();" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" id="chkDelete" />               
            </ItemTemplate>
            <HeaderStyle Width="25px" />
        </asp:TemplateField>
            <asp:BoundField DataField="PK_iHosokemtheoID" HeaderText="ID" SortExpression="PK_iHosokemtheoID" ></asp:BoundField>
            <asp:templatefield headertext="Giấy tờ">
                <itemtemplate>
                    <asp:label id="Tengiayto" Text='<%# getsTengiayto((int)DataBinder.GetPropertyValue(Container.DataItem, "FK_iGiaytoID")) %>' runat="server"/> 
                </itemtemplate>
            </asp:templatefield>
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
            <legend>Thông tin hồ sơ</legend>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblItem1" runat="server" Text="Loại giấy tờ" ></asp:Label></div>
                <div class="r">
                    <asp:DropDownList runat="server" id="ddlGiayto"></asp:DropDownList>
                    <%--<asp:TextBox ID="txtTenhoso" runat="server" CssClass="txtbox" ></asp:TextBox>--%>
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