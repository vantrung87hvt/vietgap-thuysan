<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucBandoDientichAonuoiCosonuoi.ascx.cs"
    Inherits="Maps_ucBandoDientichAonuoiCosonuoi" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script src="../js/polygon.min.js" type="text/javascript"></script>
    <link href="../CSS/tooltip.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        div#header
        {
            vertical-align: middle;
            border-bottom: 1px solid #000;
        }
        div#map
        {
            width: 930px;
            height: 500px;
            float: left;
            margin-top: 10px;
        }
        div#side
        {
            width: 30%;
            float: left;
        }
        
        
        #dataPanel
        {
            padding: 5px;
            color: Red;
            font-style: italic;
            font-size: 12px;
        }
    </style>
    <!-- script src="js/epoly.js" type="text/javascript"></script -->
    <%--<script src="js/elabel.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        var map = null;
        var bIsShow = false;
        var geocoder = new google.maps.Geocoder();  
        var myData = null;
        var mapDefaults = {
            zoom: 10,
            center: null,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        // documentReady
        $(function () {
            map = new google.maps.Map(document.getElementById("map"), mapDefaults);
            var address;
            address = $('select[id$=ddlHuyen] :selected').text() + ", " + $('select[id$=ddlTinh] :selected').text();
            if (geocoder == null) {
                geocoder = new google.maps.Geocoder();
            }
            geocoder.geocode({ address: address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                } else {
                    alert(address + ' not found');
                }
            });
            function ShowData() {
                bIsShow = true;

                //-------Xóa bản đồ nếu đã tồn tại
                if (myData != null)
                    RemovePolygon(arrPen, myData, arrCoso);
                //-----------------------
                myData = new Array();
                var QuanhuyenID = $('select[id$=ddlHuyen] :selected').val();
                address = $('select[id$=ddlHuyen] :selected').text() +", "+ $('select[id$=ddlTinh] :selected').text();
                $.ajax({
                    type: "POST",
                    url: "../Service.asmx/getToadoTheoHuyenJSON",
                    data: "{'PK_iQuanHuyenID': '" + QuanhuyenID + "'}",
                    //url: "../Service.asmx/getToadoJSON",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: AjaxSucceeded,
                    error: AjaxFailed
                });
                if (geocoder == null) {
                    geocoder = new google.maps.Geocoder();
                }
                geocoder.geocode({ address: address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        map.panTo(results[0].geometry.location);
                    } else {
                        alert(address + ' not found');
                    }
                });

            }

            $('#btnShowData').click(ShowData);

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
        });
        
       
    </script>
</head>
<body>
    <div id="map">
    </div>
    <div id="side">
        <div class="a">
            <div class="l">
                Tỉnh</div>
            <div class="r">
                <asp:DropDownList ID="ddlTinh" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlTinh_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="a">
            <div class="l">
                Quận / Huyện</div>
            <div class="r">
                <asp:DropDownList ID="ddlHuyen" runat="server">
                </asp:DropDownList>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="a">
            <div class="l">
            </div>
            <div class="r">
                <input id="btnShowData" value="Xem sơ đồ" type="button" />
            </div>
            <div class="rr">
            </div>
        </div>
    </div>
</body>
</html>
