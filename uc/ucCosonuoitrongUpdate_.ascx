<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCosonuoitrongUpdate_.ascx.cs"
    Inherits="adminx_ucCosonuoitrongUpdate" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<script src="<%=ResolveUrl("~/js/jquery-1.7.1.js")%>" type="text/javascript"></script>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
<script src="<%=ResolveUrl("~/js/polygon.min.js")%>" type="text/javascript"></script>
<style type="text/css">
    fieldset
    {
        -moz-border-radius: 7px;
        border: 1px #dddddd solid;
        margin-bottom: 20px;
        width: 550px;
    }
    .gmap3
    {
        margin: 20px auto;
        border: 1px dashed #C0C0C0;
        width: 500px;
        height: 250px;
    }
    fieldset legend
    {
        border: 1px #1a6f93 solid;
        color: black;
        font-weight: bold;
        font-family: Verdana;
        font-weight: none;
        font-size: 13px;
        padding-right: 5px;
        padding-left: 5px;
        padding-top: 2px;
        padding-bottom: 2px;
        -moz-border-radius: 3px;
    }
    
    /* Main DIV */
    .m
    {
        width: 560px;
        padding: 20px;
        height: auto;
    }
    
    /* Left DIV */
    .l
    {
        width: 140px;
        margin: 0px;
        padding: 0px;
        float: left;
        text-align: right;
    }
    
    
    /* Right DIV */
    .r
    {
        width: 300px;
        padding-left: 20px;
        float: left;
        text-align: left;
        margin-left: 0px;
        margin-right: 0px;
        margin-bottom: 0px;
        padding-right: 0px;
        padding-top: 0px;
        padding-bottom: 0px;
    }
    .rr
    {
        width: 30px;
        margin: 0px;
        padding: 0px;
        float: left;
        text-align: center;
    }
    .a
    {
        clear: both;
        width: 500px;
        padding: 10px;
    }
    #backgroundPopup
    {
        position: fixed;
        _position: absolute; /* hack for internet explorer 6*/
        height: 100%;
        width: 100%;
        top: 0;
        left: 0;
        background: #000000;
        border: 1px solid #cecece;
        z-index: 1;
        visibility: hidden;
        opacity: 0.7;
        vertical-align: middle;
    }
    #popupContact
    {
        position: absolute;
        _position: absolute; /* hack for internet explorer 6*/
        background: #FFFFFF;
        border: 2px solid #cecece;
        z-index: 2;
        padding: 12px;
        font-size: 13px;
        margin: auto;
        visibility: hidden;
        top: 50px;
        width: 800px;
        height: 450px;
    }
    #popupContact #main-map
    {
        width: 800px;
        height: 410px;
        float: left;
    }
    #popupContact #side
    {
        width: 800px;
        height: 40;
        float: left;
    }
    #popupContact #side *
    {
        float: left;
        margin: 0px;
        padding: 0px;
    }
    .btnMap
    {
        width: 50px;
        height: 35px;
        text-align: center;
        vertical-align: middle;
        margin-left: 6px;
    }
    #popupContact h1
    {
        text-align: left;
        color: #6FA5FD;
        font-size: 22px;
        font-weight: 700;
        border-bottom: 1px dotted #D3D3D3;
        padding-bottom: 2px;
        margin-bottom: 20px;
    }
    #popupContactClose
    {
        font-size: 14px;
        line-height: 14px;
        right: 6px;
        top: 4px;
        position: absolute;
        color: #6fa5fd;
        font-weight: 700;
        display: block;
    }
    #button
    {
        text-align: center;
        margin: 100px;
    }
    #divImg
    {
        float: left;
        width: 120px;
        height: 120px;
        margin: 5px;
    }
    
    #divUl
    {
        float: left;
        width: 210px;
        height: 120px;
        margin: 5px;
    }
    
    #divImg img
    {
    }
    
    #divUl ul
    {
        padding-left: 0px;
        margin: 0px;
    }
    #divUl li
    {
        color: #0077CC !important;
        font-family: Times New Roman !important;
        font-size: 12px !important;
        line-height: 1.8em !important;
        display: block;
        font-weight: normal;
    }
    #dataPanel
    {
        padding: 5px;
        color: Red;
        font-style: italic;
        font-size: 12px;
        float: left;
        width: 100%;
    }
    .lnkBtn
    {
        color: Blue;
        cursor: pointer;
    }
    #divHuyen
    {
        width: 130px;
    }
</style>
<script type="text/javascript">
//    var NineDragonDelta = new google.maps.LatLng(10.70688, 105.11928320104983);
//        var myOptions = {
//            zoom: 10,
//            center:NineDragonDelta ,
//            mapTypeId: google.maps.MapTypeId.HYBRID
//        }
//    var map = null;
//    var geocoder = new google.maps.Geocoder();
//    

    $(function () {
        //--Du lieu tu csdl
        var myData = null;
        var arrCoso = null;
        var arrPen = null;
        var PK_iCosonuoitrongID = 0;
        var bIsShow = false; //Cho biết người dùng đã xem bản đồ hay chưa, đề phòng vẽ đè
        var bDatontai = false; //Cho biết cơ sở nuôi hiện tại đã tồn tại sơ đồ chưa
        var fKinhdo = null;
        var fVido = null;
        var geocoder = new google.maps.Geocoder();

        var AnGiang = new google.maps.LatLng(10.70688, 105.11928320104983);
        var myOptions = {
            zoom: 15,
            center:AnGiang ,
            mapTypeId: google.maps.MapTypeId.HYBRID
        }

        map = new google.maps.Map(document.getElementById('main-map'), myOptions);

        var creator = new PolygonCreator(map);

        function SetcenterByAdress()
        {
            //Địa chỉ mặc định
            var add = "Châu Phú, An Giang";
            var address = $('select[id$=ddlHuyen] :selected').text() + ", " + $('select[id$=ddlTinh] :selected').text();
            if(address != "")
            {
                add = address;
            }
            if (geocoder == null) 
            {
                geocoder = new google.maps.Geocoder();
            }
            geocoder.geocode({ address: address }, function (results, status) 
            {
                if (status == google.maps.GeocoderStatus.OK) 
                {
                    map.panTo(results[0].geometry.location);
                } else {
                    alert('Không xác định được địa chỉ:'+ addressss);
                }
            });
        }
        $('#reset').click(function () {
            //
            creator.destroy();
            creator = null;
            creator = new PolygonCreator(map);
            document.getElementById("btnSave").disabled = "disabled";
            $('#dataPanel').empty();
        });
        //Kiểm tra cơ sở hiện tại đã có sơ đồ hay chưa
        function kiemtraSodoCosonuoi() {
            $.ajax({
                type: "POST",
                url: "<%=ResolveUrl("~/Service.asmx/checkTontaiSodo")%>",
                data: "{'PK_iCosonuoitrongID': '" + PK_iCosonuoitrongID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: checkSuccessed,
                error: checkFailed
            });
        }
        function checkSuccessed(result) {
            var data = eval('(' + result + ');');
            if(data.tt == "YES")
            {
                bDatontai = true;
            }
            else
            {
                bDatontai = false;
            }
        }
        function checkFailed(result) {
            alert(result.status + ' ' + result.statusText);
            console.log("AJAX Error!");
        }
        //31/12/2011 ----------------------
        function ShowData() {
            var ddlHuyen = document.getElementById("<% =ddlHuyen.ClientID %>");
            var QuanhuyenID = ddlHuyen.options[ddlHuyen.selectedIndex].value;
            var txtKinhdo = document.getElementById("<% =txtKinhDo1.ClientID %>").value;
            var txtVido = document.getElementById("<% =txtViDo1.ClientID %>").value;
            if(txtKinhdo != "" && txtVido != "")
            {
                map.setCenter( new google.maps.LatLng(txtVido,txtKinhdo), 25 );
            }
            else
            {
                SetcenterByAdress();
            }
            //-------Xóa bản đồ nếu đã tồn tại
            if (myData != null)
                RemovePolygon(arrPen, myData, arrCoso);
            //-----------------------
            myData = new Array();
            $.ajax({
                type: "POST",
                url: "<%=ResolveUrl("~/Service.asmx/getToadoTheoHuyenJSON")%>",
                data: "{'PK_iQuanHuyenID': '" + QuanhuyenID + "'}",
                //url: "<%=ResolveUrl("~/Service.asmx/getToadoJSON")%>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: AjaxSucceeded,
                error: AjaxFailed
            });
        }

        function AjaxSucceeded(result) {
            myData = new Array();
            arrPen = new Array();
            arrCoso = new Array();
            try {
                var data = eval('(' + result + ');');
                var FK_iCosoCur = data.tblToado[0].PK_iCosonuoitrongID;
                var i = 0;
                while (i < data.tblToado.length) {
                    FK_iCosoCur = data.tblToado[i].PK_iCosonuoitrongID;
                    arrCoso.push(data.tblToado[i]);
                    var arrPoint = new Array();
                    while (i < data.tblToado.length && data.tblToado[i].PK_iCosonuoitrongID == FK_iCosoCur) {
                        var dot = new Dot(new google.maps.LatLng(data.tblToado[i].sLat, data.tblToado[i].sLon), null, null);
                        arrPoint.push(dot);
                        ++i;
                    }
                    myData.push(arrPoint);
                }
                ShowServerPolygon(map, myData, arrCoso, arrPen);
            }
            catch (ex) {

            }
        }
        function AjaxFailed(result) {
            alert(result.status + ' ' + result.statusText);
            console.log("AJAX Error!");
        }

        $('#btnSave').click(function () {
            document.getElementById("<%= txtViDo1.ClientID %>").value = creator.pen.fVido;
            document.getElementById("<%= txtKinhDo1.ClientID %>").value = creator.pen.fKinhdo;
            PK_iCosonuoitrongID = document.getElementById("<%= FK_iCosonuoitrong.ClientID %>").value;
            if(PK_iCosonuoitrongID == "" || PK_iCosonuoitrongID <= 0)
            {
                $('#dataPanel').empty();
                $('#dataPanel').append('Đăng ký tài khoản trước khi đăng ký cơ sở nuôi trồng!');
                return;
            }
            kiemtraSodoCosonuoi();
            if (bDatontai == true) {
                $('#dataPanel').empty();
                $('#dataPanel').append('Một cơ sở nuôi trồng chỉ được phép vẽ một sơ đồ!\nXóa sơ đồ hiện tại để vẽ sơ đồ mới.');
                return;
            }
            $('#dataPanel').empty();
            if (null == creator.showData()) {
                $('#dataPanel').append('Hãy vẽ sơ đồ ao nuôi trước');
            } else {
                var sData = creator.showData() + ":" + PK_iCosonuoitrongID;
                $.ajax({
                    type: "POST",
                    url: "<%=ResolveUrl("~/Service.asmx/AddLatLon")%>",
                    data: "{'sLatLon': '" + sData + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: saveDataSuccessed,
                    error: AjaxFailed
                });
            }
        });
        function saveDataSuccessed() {
            $('#dataPanel').empty();
            $('#dataPanel').append('Lưu thành công!');
            creator.destroy();
            creator = new PolygonCreator(map);
            ShowData();
            document.getElementById("btnSave").disabled = "disabled";
        }
        $('#btnXoa').click(function () {
            kiemtraSodoCosonuoi();
            if(bDatontai == false)
            {
                return;
            }
            if(confirm('Chắc chắn xóa?') == true)
            {
                var PK_iCosonuoitrongID = document.getElementById("<%=FK_iCosonuoitrong.ClientID %>").value;
                $.ajax({
                    type: "POST",
                    url: "<%=ResolveUrl("~/Service.asmx/removeLocation")%>",
                    data: "{'PK_iCosonuoitrongID': '" + PK_iCosonuoitrongID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: removeLocationSuccess,
                    error: removeLocationFailed
                });
                
            }
        });
        function removeLocationSuccess(result)
        {
            var data = eval('(' + result + ');');
            if(data.tt == "OK")
            {
                $('#dataPanel').empty();
                $('#dataPanel').append('Xóa thành công!');
                bDatontai = false;
                ShowData();
            }
            else
            {
                $('#dataPanel').empty();
                $('#dataPanel').append('Xóa không thành công!');
            }
        }
        function removeLocationFailed()
        {
            $('#dataPanel').empty();
            $('#dataPanel').append('Xóa không thành công!');
        }
        //---------------Hiện bản đồ
        $('#dataPanel').empty();
        PK_iCosonuoitrongID = document.getElementById("<%=FK_iCosonuoitrong.ClientID %>").value;
        kiemtraSodoCosonuoi();
        function ShowPopup() {
            ShowData();
            $('#dataPanel').empty();
            document.getElementById('backgroundPopup').style.visibility = 'visible';
            document.getElementById('popupContact').style.visibility = 'visible';
        }
        function ClosePopup() {
            document.getElementById('backgroundPopup').style.visibility = 'hidden';
            document.getElementById('popupContact').style.visibility = 'hidden';
        }
        $('#btnShow').click(function () {ShowPopup();});
        $('#btnClose').click(function () {ClosePopup();});
    });
</script>
<script type="text/javascript">
    
</script>
<%--End polygon script--%>
<asp:ScriptManager ID="scm1" runat="server">
</asp:ScriptManager>
<div style="margin: 30px; margin-bottom: 0;">
    <asp:Label ID="lblLoi" ForeColor="Red" runat="server"></asp:Label>
</div>
<asp:Panel ID="pnDangKyTV" runat="server" Visible="False">
    <div class="m">
        <fieldset>
            <legend>Thông tin tài khoản</legend>
            <div class="a">
                <div class="l">
                    Tên tài khoản</div>
                <div class="r">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="rfvregusername" runat="server" ControlToValidate="txtUsername"
                        Display="Dynamic" ValidationGroup="register" Text="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    E-Mail</div>
                <div class="r">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="rfvregemail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ValidationGroup="register" ForeColor="Red" Text="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revregreemail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="register" Display="Dynamic"
                        ErrorMessage="Định dạng Email sai! " Text="*" SetFocusOnError="true"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Nhập lại e-mail:</div>
                <div class="r">
                    <asp:TextBox ID="txtRetypeEmail" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:CompareValidator ID="cvdregreemail" runat="server" ControlToValidate="txtRetypeEmail"
                        ControlToCompare="txtEmail" Text="*" ForeColor="Red" ValidationGroup="register"
                        SetFocusOnError="true"></asp:CompareValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Mật khẩu</div>
                <div class="r">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="rfvregpassword" runat="server" Display="Dynamic"
                        ControlToValidate="txtPassword" ValidationGroup="register" Text="*" ForeColor="Red"
                        SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Nhập lại mật khẩu</div>
                <div class="r">
                    <asp:TextBox ID="txtRetypePass" TextMode="Password" runat="server"></asp:TextBox></div>
                <div class="rr">
                    <asp:CompareValidator ID="cvdregrepass" runat="server" ControlToValidate="txtRetypePass"
                        ErrorMessage="Mật khẩu không trùng khớp!" Text="*" ForeColor="Red" ControlToCompare="txtPassword"
                        ValidationGroup="register" SetFocusOnError="true"></asp:CompareValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Mã xác nhận</div>
                <div class="r">
                    <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="none" CaptchaLength="5"
                        CaptchaHeight="40" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                        CaptchaMaxTimeout="240" />
                    <asp:TextBox ID="txtCapcha" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldCapcha" runat="server" ControlToValidate="txtCapcha"
                        Display="Dynamic" ValidationGroup="register" Text="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                </div>
                <div class="r">
                    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="register" ForeColor="Red"
                        HeaderText="Phải nhập các trường (*)" runat="server" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    &nbsp;</div>
                <div class="r">
                    <asp:Button ID="btnRegistry" runat="server" OnClick="btnRegistry_Click" Text="Đăng Ký"
                        ValidationGroup="register" CssClass="button" Width="90" />
                </div>
            </div>
            <div class="a">
            </div>
            <asp:HiddenField ID="FK_iUser" runat="server" />
        </fieldset>
    </div>
</asp:Panel>
<asp:Panel ID="pnCSNT" runat="server">
    <div class="m">
        <fieldset>
            <legend>Thông tin cơ sở nuôi trồng</legend>
            <div class="a">
                <div class="l">
                    Tài khoản</div>
                <div class="r">
                    <asp:DropDownList ID="ddlTaikhoan" runat="server" 
                        onselectedindexchanged="ddlTaikhoan_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="rr">
                    
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Tên cơ sở nuôi trồng</div>
                <div class="r">
                    <asp:TextBox ID="txtTenCoSo" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenCoSo"
                        Display="Dynamic" ValidationGroup="register2" Text="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Tên chủ cơ sở</div>
                <div class="r">
                    <asp:TextBox ID="txtTenChuCoSo" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTenChuCoSo"
                        Display="Dynamic" ValidationGroup="register2" Text="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="a">
                        <div class="l">
                            Tỉnh</div>
                        <div class="r">
                            <asp:DropDownList ID="ddlTinh" runat="server" OnSelectedIndexChanged="ddlTinh_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="rr">
                        </div>
                    </div>
                    <div class="a">
                        <div class="l">
                            Quận/ Huyện</div>
                        <div class="r">
                            <asp:DropDownList ID="ddlHuyen" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHuyen_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="rr">
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="a">
                <div class="l">
                    Xã</div>
                <div class="r">
                    <asp:TextBox ID="txtXa" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtXa"
                        Display="Dynamic" ValidationGroup="register2" Text="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Ấp</div>
                <div class="r">
                    <asp:TextBox ID="txtAp" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    &nbsp;
                </div>
                <div class="r">
                    <button type="button" id="btnShow">
                        Xác định vị trí trên bản đồ</button>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Vĩ độ</div>
                <div class="r">
                    <asp:TextBox ID="txtViDo1" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Kinh độ</div>
                <div class="r">
                    <asp:TextBox ID="txtKinhDo1" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Điện thoại</div>
                <div class="r">
                    <asp:TextBox ID="txtDienThoai" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Tổng diện tích cơ sở nuôi (m<sup>2</sup>)</div>
                <div class="r">
                    <asp:TextBox ID="txtTongDienTichCoSoNuoi" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Tổng diện tích mặt nước (m<sup>2</sup>)</div>
                <div class="r">
                    <asp:TextBox ID="txtTongDienTichMatNuoc" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Diện tích ao lắng (m<sup>2</sup>)</div>
                <div class="r">
                    <asp:TextBox ID="txtDienTichAoLang" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Sơ đồ ao nuôi</div>
                <div class="r">
                    <asp:FileUpload ID="fuSoDoAoNuoi" runat="server" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                </div>
                <div class="r">
                    <asp:Image ID="img" runat="server" Visible="false" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Đối tượng nuôi</div>
                <div class="r">
                    <asp:DropDownList ID="ddlDoituongnuoi" runat="server" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Hình thức nuôi</div>
                <div class="r">
                    <asp:DropDownList ID="ddlHinhThucNuoi" runat="server" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Chu kỳ nuôi (tháng)</div>
                <div class="r">
                    <asp:TextBox ID="txtChuKyNuoi" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Năm sản xuất</div>
                <div class="r">
                    <asp:DropDownList ID="ddlNamSanXuat" runat="server" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    Sản lượng dự kiến (kg)</div>
                <div class="r">
                    <asp:TextBox ID="txtSanluongdukien" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>
            <%--<div class="a">
                <div class="l">
                    Mã cơ sở</div>
                <div class="r">
                    <asp:TextBox ID="txtMacoso" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                </div>
            </div>--%>
            <div class="a">
                <div class="l">
                    &nbsp;
                </div>
                <div class="r">
                    <asp:CheckBox ID="chkKiemduyet" runat="server" Text="Kiểm duyệt" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                </div>
                <div class="r">
                    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="register2" ForeColor="Red"
                        HeaderText="Phải nhập các trường (*)" runat="server" />
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="a">
                <div class="l">
                    &nbsp;</div>
                <div class="r">
                    <asp:Button ID="btnDKThongtinCoSoNuoi" runat="server" Text="Đồng ý" ValidationGroup="register2"
                        Width="90" OnClick="btnDKThongtinCoSoNuoi_Click" />
                </div>
            </div>
            <div class="a">
            </div>
            <asp:HiddenField ID="FK_iCosonuoitrong" Value="0" runat="server" />
            <asp:HiddenField ID="PK_iHuyenID" Value="0" runat="server" />
        </fieldset>
    </div>
</asp:Panel>
<div id="popupContact">
    <div id="main-map">
    </div>
    <div id="side">
        <hr style="width: 100%" />
        <input id="btnSave" class="btnMap" value="Lưu" type="button" disabled="disabled" />&nbsp;&nbsp;
        <input id="reset" class="btnMap" value="Hủy" type="button" />&nbsp;&nbsp;
        <input id="btnXoa" class="btnMap" value="Xóa" type="button" />&nbsp;&nbsp;
        <input type="button" class="btnMap" id="btnClose" value="Đóng" />&nbsp;&nbsp;
        <div id="dataPanel">
        </div>
    </div>
</div>
<div id="backgroundPopup">
</div>
