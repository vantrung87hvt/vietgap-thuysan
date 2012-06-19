<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListDocument.ascx.cs"
    Inherits="uc_ListDocument" %>
    <script src="<%=ResolveUrl("~/js/jquery-1.7.1.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/jquery.easing.1.3.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/jquery.bxSlider.min.js")%>" type="text/javascript"></script>
    <link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
    <h3>
    <%--<asp:Label ID="lblTieudeTailieu" runat="server" Text="<%$ Resources:Language, lblTieudeTailieu%>"></asp:Label>  --%>
    <asp:HyperLink ID="hypTailieu" runat="server" NavigateUrl="../Content.aspx?mode=uc&page=ListDocument" Text="<%$ Resources:Language, lblTieudeTailieu%>"></asp:HyperLink>
    </h3>
    <div class="content-separator" style="margin-top:5px; margin-bottom:5px;"></div>
    <div id="divDoc">
        <asp:Label ID="lblLstDoc" runat="server" Text=""></asp:Label>
        <div id="docBtn"><a id="go-prev" title="Trước">|<</a>&nbsp;&nbsp;<a id="go-next" title="Sau">>|</a></div>
    </div>
<script type="text/javascript">
    $(function () {
        var slider = $('#lstDoc').bxSlider({
            mode: 'vertical',
            auto: true,
            displaySlideQty: 5,
            moveSlideQty: 1,
            controls: false,
            //easing: 'easeOutBounce'
        });
        $('#go-prev').click(function () {
            slider.goToPreviousSlide();
            return true;
        });

        $('#go-next').click(function () {
            slider.goToNextSlide();
            return true;
        });
    });
</script>