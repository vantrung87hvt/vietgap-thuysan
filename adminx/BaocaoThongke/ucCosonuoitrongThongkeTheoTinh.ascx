<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCosonuoitrongThongkeTheoTinh.ascx.cs" Inherits="adminx_BaocaoThongke_ucCosonuoitrongThongkeTheoTinh" %>
<table style="width: 100%; margin-top: 20px; height: auto;" id="hor-minimalist-b">
    <tr>
        <td width="100%">
            <asp:Label ID="lblThongbao" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="hypXem" runat="server" NavigateUrl="../Default.aspx?page=BaocaoThongke/ucCosonuoitrongThongkeTheoTinh1">Xem chi tiết theo Huyện</asp:HyperLink>
        &nbsp;
            <asp:LinkButton ID="lnkExport2Excel" runat="server" 
                onclick="lnkExport2Excel_Click">Xuất ra Excel</asp:LinkButton>
        </td>
    </tr>
    
    <tr>
        <td>
            <asp:Repeater ID="rptCosonuoitrongThongke" runat="server" 
                onitemdatabound="rptCosonuoitrongThongke_ItemDataBound">
                <HeaderTemplate>
                    <table border="1px" id="hor-minimalist-b">
                        <tr>
                            <th scope="col">
                                TT
                            </th>
                            <th scope="col">
                                Tỉnh
                            </th>
                            <th scope="col">
                                Địa chỉ
                            </th>
                            <th scope="col">
                                Tổng diện tích
                            </th>
                            <th scope="col">
                                Diện tích Ao nuôi
                            </th>
                            <th scope="col">
                                Diện tích Ao nuôi lắng
                            </th>
                            <th scope="col">
                                Sản lượng dự kiến
                            </th>
                            <%--<th>&nbsp;
                            </th>--%>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <b>
                                <%# DataBinder.Eval(Container.DataItem, "sTentinh") %></b>
                        </td>
                        <td>
                            <asp:Literal ID="ltrTinhID" Text='<%# DataBinder.Eval(Container.DataItem, "PK_iTinhID")%>' runat="server" Visible="false"></asp:Literal>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <%--<td>
                        </td>--%>
                    </tr>
                   <asp:Repeater ID="rptCosonuoitrong" runat="server" OnItemDataBound="rptCosonuoitrong_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Literal ID="ltrDiachi" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltrCosonuoitrongID" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "PK_iCosonuoitrongID") %>'></asp:Literal>
                                </td>
                                <td>
                                     <%# DataBinder.Eval(Container.DataItem, "fTongdientich", "{0:0,0.#}")%>
                                </td>
                                <td>
                                   <%# DataBinder.Eval(Container.DataItem, "fTongdientichmatnuoc", "{0:0,0.#}")%>
                                </td>
                                <td>
                                   <%# DataBinder.Eval(Container.DataItem, "fDientichAolang", "{0:0,0.#}")%>
                                </td>
                                <td>
                                   <%# DataBinder.Eval(Container.DataItem, "iSanluongdukien", "{0:#,###}")%>
                                </td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:LinkButton ID="lbnPrev" runat="server" onclick="lbnPrev_Click"> <asp:Label ID="lblPreviousPage" runat="server" Text="<%$ Resources:Language, lblPreviousPage%>"></asp:Label>
        </asp:LinkButton>&nbsp;
        <%--<asp:HyperLink ID="lnkPrev" runat="server" Text="[Trang trước]" />&nbsp;
                    <asp:HyperLink ID="lnkNext" runat="server" Text="[Trang sau]" />--%>
        <asp:LinkButton ID="lbnNext" runat="server" onclick="lbnNext_Click"><asp:Label ID="lblNextPage" runat="server" Text="<%$ Resources:Language, lblNextPage%>"></asp:Label>
        </asp:LinkButton>
        </td>
    </tr>
</table>