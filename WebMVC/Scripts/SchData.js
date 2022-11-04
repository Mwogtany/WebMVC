function formatComma(value, sep = 2) {
    return Number(value).toLocaleString({ style: "currency", currency: " ", minimumFractionDigits: sep });
}

    function commaSeparateNumber(val){
        while (/(\d+)(\d{3})/.test(val.toString())){
            val = val.toString().replace(/(\d+)(\d{3})/, '$1'+','+'$2');
        }
        return val;
    }

    function currencyFormat(num) {
        return num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
    }

    function format(a) {
        var i=a.indexOf(".");
        var f=(parseFloat("0"+a.substring(i)).toFixed(2)).toString();
        return a.substring(0,i)+"."+f.substring(2,f.length);
    }

    function addCommas(mStr){
        var nStr = parseFloat(mStr).toFixed(2);
        nStr += '';
        var x = nStr.split('.');
        var x1 = x[0];
        var x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        return x1 + x2;
    }

    function commaSeparateNumber(val) {
        if(!val){val = 0;}
        while (/(\d+)(\d{3})/.test(val.toString())) {
            val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
        }
        return val;
    }

$(document).ready(function () {
    var myObj, x, txt1 = "", txt3 = "";
    $('.CGenCnt').innerHTML = "";
    var origin = window.location.origin;
    var mUser = instcode;
    //var mUser = 'V6YZ';
    $.ajax({
        url: origin + "/api/SchDashboard/Capitation/" + mUser,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response !== null) {
                if (response.length > 0) {
                    txt1 = "";
                    txt1 += "<div><table border='1' style='border-collapse: collapse; border-spacing: 2px; empty-cells: show; border-color: black;'><tr><th colspan='11'>Capitation Funds</th></tr>";
                    txt1 += "<tr><th>##</th><th>Date</th><th> Description</th><th> Account</th><th> Bank</th><th> Branch</th><th> Enrol</th><th> Expected</th><th> Recoveries</th><th>Net</th><th> Acknowledged</th></tr>";

                    var x = 0;
                    $.each(response, function (key, value) {
                        x += 1;
                        //CONSTRUCTION OF ROWS HAVING 
                        txt1 += '<tr>';
                        txt1 += '<td style="text-align:left;">' +
                            x + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.DateEffected + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Description + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.AccountTypeName + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Bank_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Branch_Name + '</td>';
                        txt1 += '<td style="text-align:right;">' +
                            commaSeparateNumber(value.Enrol) + '</td>';
                        txt1 += '<td style="text-align:right;">' +
                            addCommas(value.ExpectedAmount) + '</td>';
                        txt1 += '<td style="text-align:right;">' +
                            addCommas(value.RecoveredAmount) + '</td>';
                        txt1 += '<td style="text-align:right;">' +
                            addCommas(value.TotalAmount) + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Acknowledged + '</td>';
                        txt1 += '</tr>';
                    });
                    txt1 += "</table></div>";
                    $('.CGenCnt').append(txt1);
                }
            }
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });

    $('.CenterBadCnt').innerHTML = "";
    $.ajax({
        url: origin + "/api/SchDashboard/School/" + mUser,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response !== null) {
                if (response.length > 0)
                {
                    txt1 = "";
                    txt1 += "<div><table border='1' style='border-collapse: collapse; border-spacing: 2px; empty-cells: show; border-color: black;'><tr><th colspan='6'>Missing Information</th></tr>";
                    txt1 += "<tr><th>##</th><th>COUNTY</th><th>SUB-COUNTY</th><th>CONSTITUENCY</th><th> WARD</th><th> ZONE</th></tr>";

                    var x = 0;
                    $.each(response, function (key, value) {
                        x += 1;
                        //CONSTRUCTION OF ROWS HAVING 
                        txt1 += '<tr>';
                        txt1 += '<td style="text-align:left;">' +
                            x + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.County_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Sub_County_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Constituency_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Ward_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Zone_Name + '</td>';
                        txt1 += '</tr>';
                    });
                    txt1 += "</table></div>";
                    $('.CenterBadCnt').append(txt1);
                }
            }
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });

    $('.mSchSum').innerHTML = "";
    $('.mSchEnrol').innerHTML = "";
    //var mUser = 'V6YZ';
    $.ajax({
        url: origin + "/api/SchDashboard/" + mUser,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response !== null) {
                txt1 = "";
                txt1 += "<div class='matraining col-md-10'><table border='1px Solid Black' class='summitTable' style='font-size: small; border-color: black;'><tr><td colspan='15'><strong>Institution Enrolment Summary</strong></td></tr>";
                txt1 += "<tr><th>##</th><th>Code</th><th>Class</th><th>BC Boys</th><th>BC Girls</th><th>BC Unk</th><th>BC Total</th><th>WBC Boys</th><th>WBC Girls</th><th>WBC Unk</th><th>WBC Total</th><th>Boys</th><th>Girls</th><th>Unk</th><th>Total</th></tr>";

                var x = 0;
                var TBCB = 0, TBCG = 0, TBCU = 0, TBCT = 0, TWBCB = 0, TWBCG = 0, TWBCU = 0, TWBCT = 0, TB = 0, TG = 0, TU = 0, TT = 0, NTB = 0, NTG = 0, NTU = 0, NTT = 0;
                $.each(response, function (key, value) {
                    x += 1;
                    //CONSTRUCTION OF ROWS HAVING 
                    txt1 += '<tr>';
                    txt1 += '<td style="text-align:left;">' +
                        x + '</td>';
                    txt1 += '<td style="text-align:left;">' +
                        value.Class_Code + '</td>';
                    txt1 += '<td style="text-align:left;">' +
                        value.Class_Name + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BC_Boys) + '</td>';
                    TBCB += parseInt(value.BC_Boys);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BC_Girls) + '</td>';
                    TBCG += parseInt(value.BC_Girls);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BC_Unk) + '</td>';
                    TBCU += parseInt(value.BC_Unk);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BC_Total) + '</td>';
                    TBCT += parseInt(value.BC_Total);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.WBC_Boys) + '</td>';
                    TWBCB += parseInt(value.WBC_Boys);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.WBC_Girls) + '</td>';
                    TWBCG += parseInt(value.WBC_Girls);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.WBC_Unk) + '</td>';
                    TWBCU += parseInt(value.WBC_Unk);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.WBC_Total) + '</td>';
                    TWBCT += parseInt(value.WBC_Total);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Boys) + '</td>';
                    TB += parseInt(value.Boys);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Girls) + '</td>';
                    TG += parseInt(value.Girls);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Unk) + '</td>';
                    TU += parseInt(value.Unk);
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Total) + '</td>';
                    TT += parseInt(value.Total);

                    //txt1 += '<td style="text-align:right;">' +
                    //    commaSeparateNumber(value.NER_Boys) + '</td>';
                    //NTB += parseInt(value.NER_Boys);
                    //txt1 += '<td style="text-align:right;">' +
                    //    commaSeparateNumber(value.NER_Girls) + '</td>';
                    //NTG += parseInt(value.NER_Girls);
                    //txt1 += '<td style="text-align:right;">' +
                    //    commaSeparateNumber(value.NER_Unk) + '</td>';
                    //NTU += parseInt(value.NER_Unk);
                    //txt1 += '<td style="text-align:right;">' +
                    //    commaSeparateNumber(value.NER_Total) + '</td>';
                    //NTT += parseInt(value.NER_Total);

                    txt1 += '</tr>';
                });
                txt1 += '<tr>';
                txt1 += '<th style="text-align:left;">' +
                    '</th>';
                txt1 += '<th style="text-align:left;">' +
                    '</th>';
                txt1 += '<th style="text-align:left;">' +
                    'TOTAL</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TBCB) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TBCG) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TBCU) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TBCT) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TWBCB) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TWBCG) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TWBCU) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TWBCT) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TB) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TG) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TU) + '</th>';
                txt1 += '<th style="text-align:right;">' +
                    commaSeparateNumber(TT) + '</th>';

                //txt1 += '<th style="text-align:right;">' +
                //    commaSeparateNumber(NTB) + '</th>';
                //txt1 += '<th style="text-align:right;">' +
                //    commaSeparateNumber(NTG) + '</th>';
                //txt1 += '<th style="text-align:right;">' +
                //    commaSeparateNumber(NTU) + '</th>';
                //txt1 += '<th style="text-align:right;">' +
                //    commaSeparateNumber(NTT) + '</th>';

                txt1 += '</tr>';
                txt1 += "</table></div>";
                $('.mSchEnrol').append(txt1);
            }
        },
        error: function (response, message, error) {
            handleException(response, message, error);
        }
    });

    //Staff Summary
    $.ajax({
        url: origin + "/api/SchDashboard/StaffSummary/" + mUser,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response !== null) {
                txt1 = "";
                txt1 += "<div class='matraining col-md-10'><table border='1px Solid Black'  class='summitTable' style='font-size: small; border-color: black;'><tr><th colspan='16'><strong>Institution Staff Summary</strong></th></tr>";
                txt1 += "<tr><th colspan='4'>TSC Teachers</th><th colspan='4'>BOM/Private</th><th colspan='4'>Total Teachers</th><th colspan='4'>Support Staff</th></tr>";
                txt1 += "<tr><th>Male</th><th>Female</th><th>Unk</th><th>Total</th><th>Male</th><th>Female</th><th>Unk</th><th>Total</th><th>Male</th><th>Female</th><th>Unk</th><th>Total</th><th>Male</th><th>Female</th><th>Unk</th><th>Total</th></tr>";

                var x = 0;
                $.each(response, function (key, value) {
                    x += 1;
                    //CONSTRUCTION OF ROWS HAVING 
                    txt1 += '<tr>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TSC_Male) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TSC_Female) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TSC_Unk) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TSC_Total) + '</td>';

                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BOM_Male) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BOM_Female) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BOM_Unk) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.BOM_Total) + '</td>';

                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.MaleTrs) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.FemaleTrs) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.UnkTrs) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.TotalTrs) + '</td>';

                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Support_Male) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Support_Female) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Support_Unk) + '</td>';
                    txt1 += '<td style="text-align:right;">' +
                        commaSeparateNumber(value.Support_Total) + '</td>';
                   
                    txt1 += '</tr>';
                });
                
                txt1 += "</table></div>";
                $('.mSchSum').append(txt1);
            }
        },
        error: function (response, message, error) {
            handleException(response, message, error);
        }
    });
});