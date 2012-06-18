<%@ Control Language="C#" AutoEventWireup="true"  CodeFile="ucCosonuoitrongThongkeTheoDoituong.ascx.cs"  Inherits="adminx_BaocaoThongke_ucCosonuoitrongThongkeTheoDoituong"   %>


<style type="text/css">
    .gridborder
    {
	    border: solid 2px #ffffff;
	    padding-left: 0px;	   
    }
    #hor-minimalist-b tbody tr
    {
        width:744px !important;
    }
    table#hor-minimalist-b table
    {
        width:100%;
    }
    .contentRightMain table td, .contentRightMain table th
    {
        /*width:744px !important;
        overflow:hidden;*/
        padding: 2px 2px !important;
    }
     <%--id="hor-minimalist-b"--%>
</style>
<h1>
<span class="green">
    <span><asp:Label ID="lblDanhSachDichVu" runat="server" Text="Tra cứu cơ sở nuôi trồng theo đối tượng nuôi"></asp:Label></span>
</span>
</h1>
<div class="contentRightMain">
<table id="hor-minimalist-b">
    <tr>
    <td>
        <asp:DropDownList ID="ddlDoituongnuoi" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnXem" runat="server" Text="Xem" onclick="btnXem_Click" />
        <asp:LinkButton ID="lnkXuatraExel" runat="server" onclick="lnkXuatraExel_Click" Visible="false" >Xuất ra Exel</asp:LinkButton>
        <asp:Panel runat="server" ID="panTomtat" Visible="false">
        <table id="hor-minimalist-b">
            <tr><th colspan="2">Thống kê các hộ nuôi <asp:Label ID="lblDoituongnuoi" runat="server" Text=""></asp:Label></th></tr>
            <tr><td>Số tỉnh:</td><td><asp:Label ID="lblSotinh" runat="server" Text=""></asp:Label></td></tr>
            <tr><td>Số huyện:</td><td><asp:Label ID="lblSohuyen" runat="server" Text=""></asp:Label></td></tr>
            <tr><td>Số hộ:</td><td><asp:Label ID="lblSoho" runat="server" Text=""></asp:Label></td></tr>
        </table>
        </asp:Panel>
     </td>
    </tr>
    <tr>
        <td><asp:Label ID="lblTranghthai" runat="server" Text="" ForeColor="Gray" Font-Italic="true"></asp:Label></td>
    </tr>
   <tr>
   <td>
   
       <asp:GridView ID="grvTinh" runat="server" AutoGenerateColumns="false"           
           AllowPaging="true"    PageSize="5"    
           onrowdatabound="grvTinh_RowDataBound" 
           onpageindexchanging="grvTinh_PageIndexChanging">
       <Columns>
         <asp:TemplateField HeaderText="Tỉnh" ItemStyle-Width='85px'>
                <ItemTemplate>
                    <asp:Label id="sTentinh" Runat="Server" 
                    Text='<%# Eval("sTentinh") %>'/>
                </ItemTemplate>                
         </asp:TemplateField>
       
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                 <asp:GridView ID="grvHuyen" runat="server" AutoGenerateColumns="false" CssClass="gridborder"
                 onrowdatabound="grvHuyen_RowDataBound"  >
                        <Columns>  
                            <asp:TemplateField HeaderText="Quận/Huyện" ItemStyle-Width='85px'>
                                    <ItemTemplate>
                                     <asp:Label id="sTen" Runat="Server" Text='<%# Eval("sTen") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                 <asp:GridView ID="grvCoso" runat="server" AutoGenerateColumns="false" CssClass="gridborder" ShowFooter="true">
                                 <Columns>

                                 <asp:TemplateField HeaderText="Mã số VietGAP" ItemStyle-Width='120px'>
                                    <ItemTemplate>
                                        <a target="_parent" href='<%# ResolveUrl("~/Content.aspx?CosonuoitrongID=") + Eval("PK_iCosonuoitrongID") %>'><%# Eval("sMaso_Vietgap") %></a>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Tên cơ sở" ItemStyle-Width='100px'>
                                    <ItemTemplate>
                                     <asp:Label id="Cosonuoi" Runat="Server" Text='<%# Eval("sTencoso") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Chủ cơ sở" ItemStyle-Width='80px'>
                                    <ItemTemplate>
                                     <asp:Label id="Chucoso" Runat="Server" Text='<%# Eval("sTenchucoso") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Địa chỉ" ItemStyle-Width='150px'>
                                    <ItemTemplate>
                                     <asp:Label id="sDiachi" Runat="Server" Text='<%# FormatAddress(
                                          Eval(&quot;sAp&quot;),
                                          Eval(&quot;sXa&quot;)) %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Điện thoại" ItemStyle-Width='80px'>
                                    <ItemTemplate>
                                     <asp:Label id="Sodienthoai" Runat="Server" Text='<%# Eval("sDienthoai") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>
                                </Columns>    
                                </asp:GridView>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                        </Columns>
                 </asp:GridView> 
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        </asp:GridView>
   </td>
   </tr>
</table>
</div>