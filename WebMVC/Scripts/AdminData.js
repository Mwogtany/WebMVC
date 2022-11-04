function commaSeparateNumber(val) {
    if (val) {
        while (/(\d+)(\d{3})/.test(val.toString())) {
            val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
        }
    }
    else {
        val = 0
    }
    return val;
}
$(document).ready(function () {
    var myObj, x, txt1 = "", txt3 = "", txt4 = "";
    $('.mNatSum').innerHTML = "";
    var origin = window.location.origin;
    var mUser = privilage;
    //var mUser = '2003048358';
    $.ajax({
        url: origin + "/api/Dashboard/" + mUser,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response !== null) {
                txt1 = "";
                txt1 += "<div><table border='1' class='summitTable' style='font-size: small; border-color: black;'><tr><td colspan='6'><strong>Institution Summary</strong></td></tr>";
                txt1 += "<tr><th>##</th><th>Code</th><th>Level</th><th>Public</th><th>Private</th><th>Total</th></tr>";

                var x = 0;
                $.each(response, function (key, value) {
                    x += 1;
                    //CONSTRUCTION OF ROWS HAVING 
                    txt1 += '<tr>';
                    txt1 += '<td style="text-align:left;">' +
                        x + '</td>';
                    txt1 += '<td style="text-align:left;">' +
                        value.Level_Code + '</td>';
                    txt1 += '<td style="text-align:left;">' +
                        value.Level_Name + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Public) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Private) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Total) + '</td>';
                    txt1 += '</tr>';
                });
                txt1 += "</table></div>";
                $('.mNatSum').append(txt1);
            }
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });


    $.ajax({
        url: origin + "/api/Dashboard/EnrolSummaries/" + mUser,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response !== null) {
                txt3 = "";
                txt3 += "<div><table border='1' class='summitTable' style='font-size: small; border-color: black;'><tr><td colspan='8'><strong>Enrolment Summary</strong></td></tr>";
                txt3 += "<tr><th>##</th><th>Level</th><th>Type</th><th>Institutions</th><th>Boys</th><th>Girls</th><th>Unknown</th><th>Enrol</th></tr>";

                var x = 0;
                $.each(response, function (key, value) {
                    x += 1;
                    //CONSTRUCTION OF ROWS HAVING 
                    txt3 += '<tr>';
                    txt3 += '<td style="text-align:left;">' +
                        x + '</td>';
                    txt3 += '<td style="text-align:left;">' +
                        value.Level_Name + '</td>';
                    txt3 += '<td style="text-align:left;">' +
                        value.Institution_Type + '</td>';
                    txt3 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Institutions) + '</td>';
                    txt3 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalBoys) + '</td>';
                    txt3 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalGirls) + '</td>';
                    txt3 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalUnk) + '</td>';
                    txt3 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalEnrol) + '</td>';
                    txt3 += '</tr>';

                });
                txt3 += "</table></div>";
                $('.mNatSum').append(txt3);
            }
        },
        error: function (request,
            message, error) {
            handleException(request, message, error);
        }
    });


    $.ajax({
        url: origin + "/api/Dashboard/StaffSummaries/" + mUser,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response !== null) {
                txt4 = "";
                txt4 += "<div><table border='1' class='summitTable' style='font-size: small; border-color: black;'><tr><td colspan='20'><center><strong>Institution Staff Summary</strong></center></td></tr>";
                txt4 += "<tr><th rowspan='2'>##</th><th rowspan='2'>Level</th><th rowspan='2'>Type</th><th colspan='4'>TSC Teachers</th><th colspan='4'>BOM/Private Teachers</th><th colspan='4'>Total Teachers</th></tr>";
                txt4 += "<tr><th>Male</th><th>Female</th><th>Unk</th><th>Total</th><th>Male</th><th>Female</th><th>Unk</th><th>Total</th><th>Male</th><th>Female</th><th>Unk</th><th>Total</th></tr>";

                var x = 0;
                $.each(response, function (key, value) {
                    x += 1;
                    //CONSTRUCTION OF ROWS HAVING 
                    txt4 += '<tr>';
                    txt4 += '<td style="text-align:left;">' +
                        x + '</td>';
                    txt4 += '<td style="text-align:left;">' +
                        value.Level_Name + '</td>';
                    txt4 += '<td style="text-align:left;">' +
                        value.Institution_Type + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TSC_Male) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TSC_Female) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TSC_Unk) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TSC_Total) + '</td>';

                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BOM_Male) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BOM_Female) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BOM_Unk) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BOM_Total) + '</td>';

                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalMaleTrs) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalFemaleTrs) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalUnkTrs) + '</td>';
                    txt4 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalTrs) + '</td>';
                    txt4 += '</tr>';
                });
                txt4 += "</table></div>";
                $('.mNatSum').append(txt4);
            }
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });

});