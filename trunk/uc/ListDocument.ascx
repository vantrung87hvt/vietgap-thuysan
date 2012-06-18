<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListDocument.ascx.cs"
    Inherits="uc_ListDocument" %>
    <script src="<%=ResolveUrl("~/js/jquery-1.7.1.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/jquery.easing.1.3.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/jquery.bxSlider.min.js")%>" type="text/javascript"></script>
    <style type="text/css">
        #divDoc span
        {
            width:100%;
        }
        #docBtn
        {
            float:right;
            padding-right:10px;
        }
        #docBtn a
        {
            cursor:pointer;
            font-size:10px;
        }
        ul#lstDoc
	    {
		    margin:0px;
		    padding:4px;
	    }
	    ul#lstDoc li
	    {
		    height:50px;
		    background:url('uc/img/file-icon.png') no-repeat top left;
		    padding-left:32px;
		    margin:3px 0px;
	    }
	    ul#lstDoc li:hover
	    {
		    cursor:pointer;
		    background-color:#CCC;
	    }
	    ul#lstDoc li a:hover
	    {
	        color:#4284B0;
	    }
    </style>
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
<%--=======
        <div class="content-separator" style="margin-top:5px; margin-bottom:5px;"></div>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tbody>
                <tr>
                    <td>
                        <marquee width="100%" direction="up" scrollamount="2" onmouseover="this.stop()" onmouseout="this.start()">
                            <span id="dnn_ctr410_CMS_ND_HTTinMoi_lblTinMoi" style="display:inline-block;width:100%;">
                            <table width="97%" cellpadding="0" cellspacing="0" border="0">                            
                             <asp:Repeater ID="rptrDocument" runat="server">
                             <ItemTemplate> <tr>
                            <td align="justify">
                            »&nbsp;  <asp:HyperLink ID="lnkTitle" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),60) %>' NavigateUrl='<%#"../Content.aspx?docID="+Eval("PK_iDocumentID") %>' runat="server" />
                            </td>
                            </tr></ItemTemplate>
                             </asp:Repeater>
                            </table>
                            </span>
                       </marquee>
                    </td>
                </tr>
            </tbody>
        </table>
>>>>>>> .r313--%>
