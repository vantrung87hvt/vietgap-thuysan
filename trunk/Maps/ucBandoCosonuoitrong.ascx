<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucBandoCosonuoitrong.ascx.cs"
    Inherits="Maps_ucBandoCosonuoitrong" %>
<style type="text/css">
    #side_bar
    {
        float: right;
        width: 170px;
        height: 500px;
        text-align: left;
        
        font-family: verdana;
        font-size: 11px;
        color: #000000;
        line-height: 17px;
        border: 1px dashed #C0C0C0;
    }
    #side_bar input[type=checkbox]{
        margin-right:10px;
      }
    #side_bar label{
        display:inline;
      }
    #map
        {
            width: 750px;
            height: 500px;
            float: left;
            margin-left: 5px;
            margin-bottom: 5px;
            border: 1px dashed #C0C0C0;
        }
</style>
<script src="http://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
<script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
<script src="../js/gmap3.js" type="text/javascript"></script>

<script type="text/javascript">
    var pt;
    var sAddress;
    var markerData = [];
    regions = [];
    $dpts = $("#side_bar");
    
    $(document).ready(Startup);
    function Startup() {
        $(function () {
            sAddress = $('select[id$=ddlHuyen] :selected').text() + "," + $('select[id$=ddlTinh] :selected').text();
            $('#map').gmap3(
                { action: 'init',
                    options: {
                        zoom: 15
                    }
                },
                {
                    action: 'getLatLng',
                    address: sAddress,
                    callback: function (result) {
                        if (result) {
                            $(this).gmap3({ action: 'setCenter', args: [result[0].geometry.location] });
                        }
                        else {
                            alert('Bad address 2 !');
                        }
                    }
                });
        });
        // Xử lý sự kiện khi nút ShowMap được bấm
            $("#bnShowMap").click(function () {
                $dpts.html("");
            sAddress = $('select[id$=ddlHuyen] :selected').text() + ", " + $('select[id$=ddlTinh] :selected').text();
            $('#map').gmap3({
                action: 'getLatLng',
                option: {
                    zoom: 15
                },
                address: sAddress,
                callback: function (result) {
                    if (result) {
                        $(this).gmap3({ action: 'setCenter', args: [result[0].geometry.location] });
                    }
                    else {
                        alert('Bad address 2 !');
                    }
                }
            }
            );
            CallService();
            showPanelInfo();
        });
        $(function () {
            $('select[id$=ddlHuyen]').bind("change keyup", function () {
                sAddress = $('select[id$=ddlHuyen] :selected').text() + ",";
            });
        });
        $(function () {
            $('select[id$=ddlTinh]').bind("change keyup", function () {
                sAddress += $('select[id$=ddlTinh] :selected').text();
            });
        });
    }
    function oc(arguments) {
        var o = {};
        for (var i = 0; i < arguments.length; i++) {
            o[arguments[i]] = null;
        }
        return o;
    }
    function CallService() {
        var QuanhuyenID = $('select[id$=ddlHuyen] :selected').val();

        $.ajax({
            type: "POST",
            url: "../Service.asmx/getCosonuoitrongJSON",
            data: "{'iQuanhuyenID': '" + QuanhuyenID + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: AjaxSucceeded,
            error: AjaxFailed
        });
        function AjaxSucceeded(result) {
            //                $("#jsonDiv").html(result);

            var data = eval('(' + result + ');');
            markerData.length = 0;
            for (var i = 0; i < data.tblCosonuoitrong.length; i++) {
                var val1 = data.tblCosonuoitrong[i].sTencoso;
                var val2 = data.tblCosonuoitrong[i].sTendoituong;
                var val3 = data.tblCosonuoitrong[i].Latitude;
                var val4 = data.tblCosonuoitrong[i].Longitude;
                var dNgaycap = new Date(data.tblCosonuoitrong[i].dNgaycap);
                var curr_date = dNgaycap.getDate();
                var curr_month = dNgaycap.getMonth() + 1; //months are zero based
                var curr_year = dNgaycap.getFullYear();

                var val5 = curr_date + '/' + curr_month + '/' + curr_year;
                
                var vSodoaonuoi = data.tblCosonuoitrong[i].sSodoaonuoi;
                var vMasovietgap = data.tblCosonuoitrong[i].sMaso;
                var vDientich = data.tblCosonuoitrong[i].fTongdientich;
                markerData.push({ "lat": val3, "lng": val4, "tag": val2, "data": { sTencoso: val1, sDoituongnuoi: val2, dNgaycap: val5, sSodoaonuoi: vSodoaonuoi, sMasovietgap: vMasovietgap, fTongdientich:vDientich} });
                if (val2 in oc(regions) == false)
                    regions.push(val2);
                //$dpts.append('<input id="chk' + val6 + '" type="checkbox" checked><label for="chk' + val6 + '">' + val6 + '</label><br />');
            }
            regions = regions.sort();
            $dpts = $("#side_bar");

            for (k in regions) {

                $dpts.append('<input id="chk' + k + '" type="checkbox" checked><label for="chk' + k + '">' + regions[k] + '</label><br />');
            }
            $('input', $dpts).change(function () {
                var region = $('label[for=' + $(this).attr('id') + ']', $dpts).html(),
                checked = $(this).is(':checked'),
                map = $('#map').gmap3('get'),
                markers;

                markers = $('#map').gmap3({
                    action: 'get',
                    name: 'marker',
                    all: true,
                    tag: region
                });

                $.each(markers, function (i, marker) {
                    marker.setMap(checked ? map : null);
                });

            });

            $('#map').gmap3({
                action: 'init',
                options: {
                    zoom: 15,
                    draggable: true,
                    animation: google.maps.Animation.DROP
                }
            },
                {
                    action: 'addMarkers',
                    radius: 100,
                    markers: markerData,
                    marker: {
                        options: {
                            icon: new google.maps.MarkerImage('../Images/icon_green.png')
                        },
                        events: {
                            mouseover: function (marker, event, data) {
                                $(this).gmap3(
                            { action: 'clear', name: 'overlay' },
                            { action: 'addOverlay',
                                latLng: marker.getPosition(),
                                content:
                                '<div class="infobulle popup">' +
    	                            '<div class="bub_head">' +
        	                            '<div class="bub_left">&nbsp;</div>' +
                                        '<div class="bub_center">&nbsp;</div>' +
                                        '<div class="bub_right">&nbsp;</div>' +
                                    '</div>' +
                                    '<div class="bub_content">' +
        	                            '<div class="bub_left">&nbsp;</div>' +
                                        '<div class="bub_center">' +
            	                            '<div class="imgLeft">' +
                	                            '<img src="../upload/' + data.sSodoaonuoi + '" />' +
                                            '</div>' +
                                            '<div class="inforRight">' +
                	                            '<ul>' +
                    	                            '<li><b>Mã số VietGAP: </b> ' + data.sMasovietgap + '</li>' +
                                                    '<li><b>Tên cơ sở: </b> ' + data.sTencoso + '</li>' +
                                                    '<li><b>Đối tượng: </b> ' + data.sDoituongnuoi + '</li>' +
                                                    '<li><b>Diện tích: </b> '+data.fTongdientich+' m<sup>2</sup></li>' +
                                                    '<li><b>Ngày cấp: </b> ' + data.dNgaycap + '</li>' +
                                                '</ul>' +
                                            '</div>' +
                                        '</div>' +
                                        '<div class="bub_right">&nbsp;</div>' +
                                    '</div>' +
    	                            '<div class="bub_foot">' +
        	                            '<div class="bub_left">&nbsp;</div>' +
                                        '<div class="bub_center">' +
            	                            '<img src="../Images/bubble-tail2.png" />' +
                                        '</div>' +
                                        '<div class="bub_right">&nbsp;</div>' +
                                    '</div>' +
                                '</div>'
                                            ,
                                offset: {
                                    x: -46,
                                    y: -73
                                }
                            }
                            );
                            },
                            mouseout: function () {
                                $(this).gmap3({ action: 'clear', name: 'overlay' });
                            }
                        }
                    }
                }
                );

        }

        function AjaxFailed(result) {
            alert(result.status + ' ' + result.statusText);
            console.log("AJAX Error!");
        }
        function addMarkerToCluster($this, latLng) {
            $this.gmap3({
                action: 'addmarker',
                latLng: latLng,
                to: markerData
            });
        }
    }
</script>
<body>
    <div id="GisMap" style="width: 940px; margin-top: 10px; margin-bottom:10px; text-align: justify;">
        <div id="map">
        </div>
        <div id="side_bar">
        </div>
        <div id="main" style="margin-top: 10px; text-align: justify;">
            <div class="a">
                <div class="l">
                    T&#7881;nh</div>
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
            </div>
            <div class="a">
                <div class="l">
                </div>
                <div class="r">
                    <%--<asp:Button ID="btnView" runat="server" Text="View" CausesValidation="False" OnClientClick="showAddress();" />--%>
                    <input id="lat" value="" type="hidden" />
                    <input id="lng" value="" type="hidden" />
                    <input type="button" id="bnShowMap" name="bnShowMap" value="Xem" onclick="return bnShowMap_onclick()" />
                </div>
            </div>
        </div>
    </div>
</body>
