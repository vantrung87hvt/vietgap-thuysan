<%@ Control Language="C#" AutoEventWireup="true"  CodeFile="ucCosonuoitrongThongkeTheoTinh1.ascx.cs"  Inherits="adminx_BaocaoThongke_ucCosonuoitrongThongkeTheoTinh1"   %>


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
        <asp:HyperLink ID="hypXem" runat="server" NavigateUrl="../Default.aspx?page=BaocaoThongke/ucCosonuoitrongThongkeTheoTinh">Xem giản lược theo Tỉnh</asp:HyperLink>
        &nbsp;
        <asp:LinkButton ID="lnkXuatraExel" runat="server" 
            onclick="lnkXuatraExel_Click" >Xuất ra Exel</asp:LinkButton>
     </td>
    </tr>
   <tr>
   <td>
   
       <asp:GridView ID="GridParent" runat="server" AutoGenerateColumns="false"           
           AllowPaging="true"    PageSize="5"    
           onrowdatabound="GridParent_RowDataBound" 
           onpageindexchanging="GridParent_PageIndexChanging">
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
                 <asp:GridView ID="GridChild" runat="server" AutoGenerateColumns="false" CssClass="gridborder"
                 onrowdatabound="GridChild_RowDataBound"  >
                        <Columns>  
                            <asp:TemplateField HeaderText="Quận/Huyện" ControlStyle-Width='120px'>
                                    <ItemTemplate>
                                     <asp:Label id="sTen" Runat="Server" Text='<%# Eval("sTen") %>'/>
                                    </ItemTemplate>                
                                </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                 <asp:GridView ID="GridGrand" runat="server" AutoGenerateColumns="false" CssClass="gridborder" ShowFooter="true">
                                 <Columns>
                                 <asp:TemplateField HeaderText="Địa chỉ" ControlStyle-Width='200px'>
                                    <ItemTemplate>
                                     <asp:Label id="sDiachi" Runat="Server" Text='<%# FormatAddress(
                                          Eval(&quot;sAp&quot;),
                                          Eval(&quot;sXa&quot;)) %>'/>
                                   <%--<asp:Label id="sDiachi" Runat="Server" Text='<%# FormatAddress(((System.Data.DataRowView)Container.DataItem).Row) %>'/>--%>
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
