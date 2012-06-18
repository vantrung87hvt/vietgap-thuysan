<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucBandoThongketheoTinh.ascx.cs"
    Inherits="Maps_ucBandophanboCosonuoitrong" %>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
<script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=AIzaSyDdAlOyWIG04ZLSTCZUzaQP7oHt28WI6V8"
    type="text/javascript"></script>
<script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
<script src="../js/geoxml14Jun2011.js" type="text/javascript"></script>
<%--<script src="../js/elabel.js" type="text/javascript"></script>--%>
<style type="text/css">
    .style1
    {
        font-size: 10px;
        font-family: Arial,sans-serif;
        background: none;
        font-weight: normal;
        border: 2px #00000 solid;
        color: black;
        white-space: nowrap;
    }
</style>
<script type="text/javascript">
	     //<![CDATA[

    var gml, mmap;
    $dpts = $("#<%=side_bar.ClientID%>");
    var table = "";
    var sTable = "";
    var oData = null;
    var xlsTable = null;
    var sTentinh = "";
    function initMap() {

        mmap = new GMap2(document.getElementById("map"), { draggableCursor: 'crosshair', draggingCursor: 'move' });
        mmap.setCenter(new GLatLng(0, 0), 15);
        mmap.addControl(new GMapTypeControl());
        mmap.enableScrollWheelZoom();
        mmap.enableDoubleClickZoom();
        mmap.enableContinuousZoom();

        GEvent.addListener(mmap, "click", function (overlay, point) {

            showTableData(overlay.description);
            sTentinh = overlay.name;
            //            alert(overlay.description);
        });


        GEvent.addListener(mmap, "infowindowopen", function () {
            mmap.closeInfoWindow();
        });
        //            gml = new GeoXml("gml", mmap,"<%=ResolveUrl("KML/Vietnam")%>", { polylabeloffset: new GSize(-20, 0), polylabelopacity: 50, polylabelclass: "style1"});
        
        gml = new GeoXml("gml", mmap, toAbs('KML/Vietnam.xml', window.location.href));
        gml.parse("Dữ liệu cơ sở nuôi trồng");

    }
    //Chuyển đổi dường dẫn tương đối sang tuyệt đối
    function toAbs(link, host) {

        var lparts = link.split('/');
        if (/http:|https:|ftp:/.test(lparts[0])) {
            return link;
        }

        var i, hparts = host.split('/');
        if (hparts.length > 3) {
            hparts.pop(); // 
        }

        if (lparts[0] === '') {
            host = hparts[0] + '//' + hparts[2];
            hparts = host.split('/');
            delete lparts[0];
        }

        for (i = 0; i < lparts.length; i++) {
            if (lparts[i] === '..') {
                if (typeof lparts[i - 1] !== 'undefined') {
                    delete lparts[i - 1];
                } else if (hparts.length > 3) {
                    hparts.pop();
                }
                delete lparts[i];
            }
            if (lparts[i] === '.') {
                delete lparts[i];
            }
        }

        var newlinkparts = [];
        for (i = 0; i < lparts.length; i++) {
            if (typeof lparts[i] !== 'undefined') {
                newlinkparts[newlinkparts.length] = lparts[i];
            }
        }

        return hparts.join('/') + '/' + newlinkparts.join('/');

    }

    function showTableData(value) {
        $.ajax({
            type: "POST",
            url: "../Service.asmx/getTonghopTheoISO_3166JSON",
            data: "{'ISO_3166': '" + value + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: getDataSuccessed,
            error: AjaxFailed
        });

    }
    function getDataSuccessed(result) {

        var data = eval('(' + result + ');');
        oData = data;
        if (data.tblCosonuoitrong.length > 0) {
            table = "";
            table += '<table id=\"hor-minimalist-b\" summary=\"Thông Tin Cơ sở nuôi trồng\" width=\"550\">';
            table += '<thead>';
            table += '<th scope="col" colspan=\"4\">'+sTentinh+'</th>';
            table += '</thead>';
            table += '<thead>';
            table += '<tr>';
            table += '<th scope="col">Đối tượng</th>';
            table += '<th scope="col">T.Số hộ</th>';
            table += '<th scope="col">T.Diện tích</th>';
            table += '<th scope="col">T.Diện tích Ao lắng</th>';
            table += '<th scope="col">T.Sản lượng</th>';
            table += '</tr>';
            table += '</thead>';
            for (var i = 0; i < data.tblCosonuoitrong.length; i++) {
                table += '<tr>';
                table += '<td>' + data.tblCosonuoitrong[i].sTendoituong + '</td>';
                table += '<td>' + data.tblCosonuoitrong[i].iSoho + '</td>';
                var fTongdientich = data.tblCosonuoitrong[i].fTongdientich;
                table += '<td>' + formatCurrency(fTongdientich) + ' m<sup>2</sup></td>';
                var fTongdientichAolang = data.tblCosonuoitrong[i].fTongdientichAolang;
                table += '<td>' + formatCurrency(fTongdientichAolang) + ' m<sup>2</sup></td>';
                //bignum.numberFormat("0,0,, million");
                var iTongsanluongdukien = data.tblCosonuoitrong[i].iSanluongdukien;
                table += '<td>' + formatCurrency(iTongsanluongdukien) + ' kg</td>';
                table += '</tr>';
            }
            table += '</table>';
            sTable = table;
            //                alert(table);
            $dpts = $("#<%=side_bar.ClientID%>");
            $dpts.html(table);
            document.getElementById('<%=lnkExport2Excel.ClientID%>').style.display = 'inherit';
            document.getElementById('bot').style.display = 'inherit';   
        }
        else {
            table = "";
            table += '<table id=\"hor-minimalist-b\" summary=\"Thông Tin Cơ sở nuôi trồng\" width=\"350\">';
            table += '<tr>';
            table += '<td>Không có dữ liệu';
            table += '</td>';
            table += '</tr>';
            table += '</table>';
            $dpts = $("#<%=side_bar.ClientID%>");
            $dpts.html(table);
            document.getElementById('<%=lnkExport2Excel.ClientID%>').style.display = 'none';
            document.getElementById('bot').style.display = 'none';
        }
    }
    function AjaxFailed(result) {
        alert(result.status + ' ' + result.statusText);
        console.log("AJAX Error!");
    }
    // Định dạng số
    function formatCurrency(num) {
        num = num.toString().replace(/\$|\,/g, '');
        if (isNaN(num))
            num = "0";
        sign = (num == (num = Math.abs(num)));
        num = Math.floor(num * 100 + 0.50000000001);
        num = Math.floor(num / 100).toString();
        for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
            num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));
        return (((sign) ? '' : '-') + num);
    }
    function submitData() {
        
        $.ajax({
            type: "POST",
            url: "../Service.asmx/Export",
            data: "{'sTableContent': '" + table + "'}",
            //data: "{'sTableContent': 'AAA'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: sendDataSuccessed,
            error: AjaxFailed
        });
    }
    function sendDataSuccessed() {
        alert('Successed');
    }

    function exportXls() {

        var ExcelApp = new ActiveXObject("Excel.Application");
        var ExcelSheet = new ActiveXObject("Excel.Sheet");
        ExcelSheet.Application.Visible = true;
  //      Tạo header table
        ExcelSheet.ActiveSheet.Cells(0, 0).Value = 'Đối tượng';
        ExcelSheet.ActiveSheet.Cells(0, 1).Value = 'T.Số hộ';
        ExcelSheet.ActiveSheet.Cells(0, 2).Value = 'T.Diện tích';
        ExcelSheet.ActiveSheet.Cells(0, 3).Value = 'T.Diện tích Ao lắng';
        ExcelSheet.ActiveSheet.Cells(0, 4).Value = 'T.Sản lượng dự kiến';
  //      Tạo body
        var fTongdientich;
        var iTongsanluongdukien;
        for (var i = 0; i < oData.tblCosonuoitrong.length; i++) {
            ExcelSheet.ActiveSheet.Cells(i + 1, 0).Value = data.tblCosonuoitrong[i].sTendoituong;
            ExcelSheet.ActiveSheet.Cells(i + 1, 1).Value = data.tblCosonuoitrong[i].iSoho;
            fTongdientich = data.tblCosonuoitrong[i].fTongdientich;
            ExcelSheet.ActiveSheet.Cells(i + 1, 2).Value = formatCurrency(fTongdientich);
            var fTongdientichAolang = data.tblCosonuoitrong[i].fTongdientichAolang;
            ExcelSheet.ActiveSheet.Cells(i + 1, 3).Value = formatCurrency(fTongdientichAolang);
            iTongsanluongdukien = data.tblCosonuoitrong[i].iSanluongdukien;
            ExcelSheet.ActiveSheet.Cells(i + 1, 4).Value = formatCurrency(iTongsanluongdukien);

        }
    }
    var tableToExcel = (function () {
        var uri = 'data:application/vnd.ms-excel;base64,'
    , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><meta http-equiv="Content-Type" content="charset=utf-8" /><title>Thongketheotinh</title><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
    , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
    , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
        return function (table, name) {
            var ctx = { worksheet: name || 'Worksheet', table: sTable }
            window.location.href = uri + base64(format(template, ctx))
        }
    })()
    //]]>
</script>

<body onload="initMap()">
    <div style="width: 940px; margin-top: 10px; text-align: justify;">
        <div id='map'>
        </div>
        <div style="clear: both">
        </div>
        
        <div id="side_bar" runat="server">
            
        </div>
        <div id="bot" style="width: 305; margin-top: 5px; display:none">
            <asp:LinkButton ID="lnkExport2Excel" runat="server" OnClick="lnkExport2Excel_Click"
                Style="display: none">Xuất ra Excel (theo session)</asp:LinkButton>
            <%--<a href="#" onclick="submitData();">Xuất ra Excel</a><br />--%>
            <a href="" onclick="tableToExcel('Thongketheotinh', 'Thống kê theo tỉnh')">Xuất Excel (theo Javascript - Firefox)</a><br />
            <a href="" onclick="exportXls();">Xuất Excel (theo Javascript - IE)</a>
        </div>
        <asp:HiddenField ID="hidContent" runat="server" />
    </div>
</body>
