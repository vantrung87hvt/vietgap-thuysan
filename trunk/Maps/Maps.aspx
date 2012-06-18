<%@ Page Title="" Language="C#" MasterPageFile="~/Maps/Maps.master" AutoEventWireup="true"
    CodeFile="Maps.aspx.cs" Inherits="Maps_Maps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctContent" runat="Server">
    <div id="main" style="width: 78%; margin-left: 10px; text-align: justify;">
        <asp:PlaceHolder ID="phMain" runat="server"></asp:PlaceHolder>
    </div>
    <div class="clear">
    </div>
    <div id="navi">
        <hr style="border-style: dotted" />
        <ul id="minitabs">
            <li><a href="Maps.aspx?mode=uc&page=BandophanboCachonuoitrong">Phân bố các hộ</a></li>
            <li><a href="Maps.aspx?mode=uc&page=BandoThongketheoTinh">Thống kê theo Tỉnh</a></li>
            <li><a href="Maps.aspx?mode=uc&page=BandoDientichAonuoiCosonuoi">Bản đồ vùng Ao nuôi</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRight" runat="Server">
</asp:Content>
