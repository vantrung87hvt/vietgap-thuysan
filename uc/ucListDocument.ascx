<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListDocument.ascx.cs" Inherits="uc_ListDocument" %>
<style type="text/css">
    .label-orange
    {
        border-left-color: #FA8F6F;
    }
     #hor-minimalist-b
    {
        font-size: 12px;
        background: #fff;
        margin-left:30px;
        margin-top: 5px;
        width: 90%;
        border-collapse: collapse;
        text-align: left;
    }
    #hor-minimalist-b th
    {
        font-size: 12px;
        font-weight: normal;
        color: #039;
        padding: 8px 6px;
        border-bottom: 2px solid #6678b1;
    }
    #hor-minimalist-b td
    {
        border-bottom: 1px solid #ccc;
        color: #669;
        padding: 4px 6px;
    }
    #hor-minimalist-b tbody tr:hover td
    {
        color: #009;
    }
    .dvFooter
    {
         font-size: 12px;
        background: #fff;
        margin-left:30px;
        margin-top: 5px;
        width: 90%;
        border-collapse: collapse;
        text-align: right;
    }
    .LawTracuu {
    background-image: url(uc/img/QLVB_Tracuu.jpg);
    background-position: top;
    background-repeat: no-repeat;
    text-indent:20px;
    }
    
</style>
<h1><span class="green">
    <asp:Label ID="lblTieudeTailieu" runat="server" Text="<%$ Resources:Language, lblTieudeTailieu%>"></asp:Label>
</span></h1>
<div class="section-content">
    <table cellpadding="0" cellspacing="3" border="0" width="678px" class="LawTracuu">
    <tr>
        <td style="padding-top:30px;">
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="LawTracuu_text">
            <asp:Label ID="lblNoiDungCanTim" runat="server" Text="<%$ Resources:Language, lblNoiDungCanTim%>"></asp:Label>
          
        </td>
        <td>
            
            <asp:TextBox ID="txtNoiDung" runat="server" Width="275px"></asp:TextBox>
            <asp:Button ID="btnTimKiem"
                runat="server" Text="<%$ Resources:Language, btnTimKiemLD%>" onclick="btnTimKiem_Click" />
        </td>
    </tr>
    <tr>
        <td class="LawTracuu_text">
           <asp:Label ID="lblSoKyHieu" runat="server" Text="<%$ Resources:Language, lblSoKyHieu%>"></asp:Label> 
        </td>
        <td>
            <asp:TextBox ID="txtSoKyHieu" runat="server" Width="271px"></asp:TextBox>
        </td>
    </tr>    
    <tr>
        <td class="LawTracuu_text">
            <asp:Label ID="lblLoaiVanBan" runat="server" Text="<%$ Resources:Language, lblLoaiVanBan%>"></asp:Label> 
        </td>
        <td>
            <asp:DropDownList ID="ddlLoaiVanBan" runat="server">
            </asp:DropDownList>
        </td>
    </tr>

    </table>
    <asp:Repeater ID="rptrDocument" runat="server">
        <HeaderTemplate>
        <table id="hor-minimalist-b" summary="Document List">
        <thead>
            <tr>
                <th scope="col">
                    <asp:Label ID="lblSTT" runat="server" Text="<%$ Resources:Language, lblSTT%>"></asp:Label> 
                </th>
                <th scope="col">
                    <asp:Label ID="lblTenTaiLieu" runat="server" Text="<%$ Resources:Language, lblTenTaiLieu%>"></asp:Label> 
                </th>
                <th scope="col">
                    <asp:Label ID="lblBanHanh" runat="server" Text="<%$ Resources:Language, lblBanHanh%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="lblCQBanHanh" runat="server" Text="<%$ Resources:Language, lblCQBanHanh%>"></asp:Label>
                </th>
                <th scope="col">
                    <asp:Label ID="lblLanTai" runat="server" Text="<%$ Resources:Language, lblLanTai%>"></asp:Label>
                </th>
            </tr>
        </thead>
        <tbody>
        </HeaderTemplate>
        <ItemTemplate>
               
                <tr>
                    <td>
                        <%=iStt++%>
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkTitle" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),30) %>' NavigateUrl='<%#"../Content.aspx?docID="+Eval("PK_iDocumentID") %>'
                    runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("dNgaybanhanh","{0:dd/MM/yyyy}")%>' />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("sCoquanbanhanh")%>'/>
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkDownload" Text='<%#"Tải ("+Eval("iDownloadTime")+")"%>' NavigateUrl='<%#"../download.aspx?id="+Eval("PK_iDocumentID") %>' runat="server"></asp:HyperLink>
                        <%--<asp:Label ID="Label5" Font-Bold="true" runat="server" Text='<%#Eval("iDownloadTime")%>'/>--%>
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="dvFooter">
        <asp:LinkButton ID="lbnPrev" runat="server" onclick="lbnPrev_Click"> <asp:Label ID="lblPreviousPage" runat="server" Text="<%$ Resources:Language, lblPreviousPage%>"></asp:Label>
        </asp:LinkButton>&nbsp;
        <%--<asp:HyperLink ID="lnkPrev" runat="server" Text="[Trang trước]" />&nbsp;
                    <asp:HyperLink ID="lnkNext" runat="server" Text="[Trang sau]" />--%>
        <asp:LinkButton ID="lbnNext" runat="server" onclick="lbnNext_Click"><asp:Label ID="lblNextPage" runat="server" Text="<%$ Resources:Language, lblNextPage%>"></asp:Label>
        </asp:LinkButton>
    </div>
</div>
