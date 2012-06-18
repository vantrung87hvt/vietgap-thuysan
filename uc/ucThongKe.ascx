<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucThongKe.ascx.cs" Inherits="ucThongKe" %>
 

    <h3 style="color:#6297BC;">
        <asp:Literal ID="Literal1" Text="<%$ Resources:Language, lblThongKeTruyCap%>" runat="server"></asp:Literal>
    </h3>
<asp:Panel ID="pnOne" runat="server">
<table cellpadding="0" cellspacing="0" Width="100%" >
        
        <tr>
            
            <td style="width:10%; padding-left:10px">
               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%;">
                <asp:Literal ID="Literal2" Text="<%$ Resources:Language, lblDangTruyCap%>" runat="server"></asp:Literal>
               </td>
            <td style="width:30%;line-height:32px;">
                <% =Application["visitors_online"].ToString()%></td>
        </tr>
       
    </table>
</asp:Panel>
<asp:Panel ID="pnAll" runat="server">
    <table cellpadding="0" cellspacing="0" Width="100%" >
        
        <tr>
            
            <td style="width:10%; padding-left:10px">
               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%;">
                <asp:Literal ID="lblDangTruyCap" Text="<%$ Resources:Language, lblDangTruyCap%>" runat="server"></asp:Literal>
               </td>
            <td style="width:30%;line-height:32px;">
                <% =Application["visitors_online"].ToString()%></td>
        </tr>
       <tr>
            <td style="width:10%; padding-left:10px">
               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%">
                <asp:Literal ID="lblHomNay" Text="<%$ Resources:Language, lblHomNay%>" runat="server"></asp:Literal>
               </td>
            <td style="width:30%">
                    <asp:Literal ID="lblHomNayd" runat="server"></asp:Literal>
                
                </td>
        </tr>
        <tr>
            <td style="width:10%; padding-left:10px">
               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%;">
                <asp:Literal ID="lblHomQua" Text="<%$ Resources:Language, lblHomQua%>" runat="server"></asp:Literal>
               </td>
            <td style="width:30%">
                    <asp:Literal ID="lblHomQuad" runat="server"></asp:Literal>
                
                </td>
        </tr>
        <tr>
            <td style="width:10%; padding-left:10px">
               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%;">
                <asp:Literal ID="lblTuanNay" runat="server" Text="<%$ Resources:Language, lblTuanNay%>"></asp:Literal>
               </td>
            <td style="width:30%">
                    <asp:Literal ID="lblTuanNayd" runat="server"></asp:Literal>
                
                </td>
        </tr>
        <tr>
            <td style="width:30%; padding-left:10px">
               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%;">
                <asp:Literal ID="lblTuanTruoc" runat="server" Text="<%$ Resources:Language, lblTuanTruoc%>"></asp:Literal>
               </td>
            <td style="width:30%">
                    <asp:Literal ID="lblTuanTruocd" runat="server"></asp:Literal>
                
                </td>
        </tr>
        <tr>
            <td style="width:10%; padding-left:10px">

               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%;">
                <asp:Literal ID="lblThangNay" Text="<%$ Resources:Language, lblThangNay%>" runat="server"></asp:Literal>
               </td>
            <td style="width:30%">
                    <asp:Literal ID="lblThangNayd" runat="server"></asp:Literal>
                
                </td>
        </tr>
        <tr>
            <td style="width:10%; padding-left:10px">
               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%;">
                <asp:Literal ID="lblThangTruoc" Text="<%$ Resources:Language, lblThangTruoc%>" runat="server"></asp:Literal>
               </td>
            <td style="width:30%">
                    <asp:Literal ID="lblThangTruocd" runat="server"></asp:Literal>
                
                </td>
        </tr>
        <tr>
            <td style="width:10%; padding-left:10px">
               <img src="Images/visitorIcon.gif" />
               </td>
               <td style="width:60%;">
                <asp:Literal ID="lblTatCa" Text="<%$ Resources:Language, lblTatCa%>" runat="server"></asp:Literal>
               </td>
            <td style="width:30%">
                    <asp:Literal ID="lblTatCad" runat="server"></asp:Literal>
                
                </td>
        </tr>        
    </table>
    </asp:Panel>
 