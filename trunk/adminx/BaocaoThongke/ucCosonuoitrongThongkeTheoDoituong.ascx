<%@ Control Language="C#" AutoEventWireup="true"  CodeFile="ucCosonuoitrongThongkeTheoDoituong.ascx.cs"  Inherits="adminx_BaocaoThongke_ucCosonuoitrongThongkeTheoDoituong"   %>


<style type="text/css">
    .gridborder
    {
	    border: solid 2px #ffffff;
	    padding-left: 0px;	   
    }

</style>
<%--<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />--%>

<table style="width: 100%; margin-top: 20px; height: auto;" id="hor-minimalist-b">
    <tr>
    <td>
        <asp:DropDownList ID="ddlDoituongnuoi" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnXem" runat="server" Text="Xem" onclick="btnXem_Click" />
        <asp:LinkButton ID="lnkXuatraExel" runat="server" 
            onclick="lnkXuatraExel_Click" >Xuất ra Exel</asp:LinkButton>
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
        <td><asp:Label ID="lblTranghthai" runat="server" Text="" ForeColor="Red"></asp:Label></td>
    </tr>
   <tr>
   <td>
        
       <asp:GridView ID="grvTinh" runat="server" AutoGenerateColumns="false"           
           AllowPaging="true"    PageSize="5"    
           onrowdatabound="grvTinh_RowDataBound" 
           onpageindexchanging="grvTinh_PageIndexChanging">
       <Columns>
         <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label id="PK_iTinhID" Runat="Server" 
                    Text='<%# Eval("PK_iTinhID") %>'/>
                </ItemTemplate>                
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Tên tỉnh">
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
                            <asp:TemplateField HeaderText="Quận/Huyện" ControlStyle-Width='120px'>
                                    <ItemTemplate>
                                     <asp:Label id="sTen" Runat="Server" Text='<%# Eval("sTen") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                 <asp:GridView ID="grvCoso" runat="server" AutoGenerateColumns="false" CssClass="gridborder" ShowFooter="true">
                                 <Columns>

                                 <asp:TemplateField HeaderText="Mã số VietGAp">
                                    <ItemTemplate>
                                     <asp:Label id="MasoVietGAP" Runat="Server" Text='<%# Eval("sMaso_Vietgap") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Tên cơ sở">
                                    <ItemTemplate>
                                     <asp:Label id="Cosonuoi" Runat="Server" Text='<%# Eval("sTencoso") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Chủ cơ sở">
                                    <ItemTemplate>
                                     <asp:Label id="Chucoso" Runat="Server" Text='<%# Eval("sTenchucoso") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Địa chỉ" ControlStyle-Width='200px'>
                                    <ItemTemplate>
                                     <asp:Label id="sDiachi" Runat="Server" Text='<%# FormatAddress(
                                          Eval(&quot;sAp&quot;),
                                          Eval(&quot;sXa&quot;)) %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Điện thoại">
                                    <ItemTemplate>
                                     <asp:Label id="Sodienthoai" Runat="Server" Text='<%# Eval("sDienthoai") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Diện tích">
                                    <ItemTemplate>
                                     <asp:Label id="Tongdientich" Runat="Server" Text='<%# Eval("fTongdientich", "{0:0,0.#}") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Diện tích ao nuôi">
                                    <ItemTemplate>
                                     <asp:Label id="Dientichaonuoi" Runat="Server" Text='<%# Eval("fTongdientichmatnuoc", "{0:0,0.#}") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Diện tích ao nuôi lắng">
                                    <ItemTemplate>
                                     <asp:Label id="Dientichaolang" Runat="Server" Text='<%# Eval("fDientichAolang", "{0:0,0.#}") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sản lượng dự kiến">
                                    <ItemTemplate>
                                     <asp:Label id="Sanluongdukien" Runat="Server" Text='<%# Eval("iSanluongdukien", "{0:#,###}") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Chi tiết">
                                    <ItemTemplate>
                                     <asp:LinkButton ID="lbtnChitiet" runat="server" Text="Chi tiết" PostBackUrl='<%# "~/Content.aspx?CosonuoitrongID=" + Eval("PK_iCosonuoitrongID") %>'></asp:LinkButton>
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
