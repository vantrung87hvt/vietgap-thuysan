<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDanhsachTCCN.ascx.cs" Inherits="uc_ucDanhsachTCCN" %>
 <script src="<%=ResolveUrl("~/js/jquery-1.7.1.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/jquery.easing.1.3.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/jquery.bxSlider.min.js")%>" type="text/javascript"></script>
    <style type="text/css">
        #divTCCN span
        {
            width:100%;
        }
        #btnTCCN
        {
            float:right;
            padding-right:10px;
        }
        #btnTCCN a
        {
            cursor:pointer;
            font-size:10px;
        }
        ul#lstTCCN
	    {
		    margin:0px;
		    padding:4px;
	    }
	    ul#lstTCCN li
	    {
		    height:50px;
		    background:url('uc/img/file-icon.png') no-repeat top left;
		    padding-left:32px;
		    margin:3px 0px;
	    }
	    ul#lstTCCN li:hover
	    {
		    cursor:pointer;
		    background-color:#CCC;
	    }
	    ul#lstTCCN li a:hover
	    {
	        color:#4284B0;
	    }
    </style>
    <h3>
        <%--<asp:Label ID="lblTieudeTailieu" runat="server" Text="<%$ Resources:Language, lblTieudeTailieu%>"></asp:Label>  --%>
        <asp:HyperLink ID="hypTailieu" runat="server" 
            NavigateUrl="../Content.aspx?mode=uc&amp;page=DanhsachTCCNChitiet" 
            Text="<%$ Resources:Language, lblTieudeDanhsachTCCN %>"></asp:HyperLink>
        </h3>
        <div class="content-separator" style="margin-top:5px; margin-bottom:5px;"></div>
        <div id="divTCCN">
            <asp:Label ID="lblDanhsachTochucchungnhan" runat="server" Text=""></asp:Label>
            <div id="btnTCCN"><a id="go-prev" title="Trước">|<</a>&nbsp;&nbsp;<a id="go-next" title="Sau">>|</a></div>
        </div>
<script type="text/javascript">
    $(function () {
        var slider = $('#lstTCCN').bxSlider({
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