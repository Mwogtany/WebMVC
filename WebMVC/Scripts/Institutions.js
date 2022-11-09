$(document).ready(function () {
    var myObj, x, txt1 = "", txt3 = "", txt4 = "";
    var origin = window.location.origin;
    var mUIC = privilage;
    var secty = sessionStorage.mCounty;
    if (secty !== "") {
        $('#ddlCty').val(secty);
        $.getJSON("../../api/Cascade/SubCounties/" + secty,
            function (classesData) {
                var select = $("#ddlSCty");
                select.empty();
                select.append($('<option/>', {
                    value: 0,
                    text: "<<Select Sub-County>>"
                }));
                $.each(classesData, function (index, itemData) {
                    select.append($('<option/>', {
                        value: itemData.Sub_County_Code,
                        text: itemData.Sub_County_Name
                    }));
                });
            });
    }

    var sescty = sessionStorage.mSCounty;
    if (sescty !== "") {
        $('#ddlSCty').val(sescty);
    }
    var selev = sessionStorage.mLevelCode;
    if (selev !== "") {
        $('#ddlLevel').val(selev);
    }
    var setyp = sessionStorage.mTypeCode;
    if (setyp !== "") {
        $('#ddlType').val(setyp);
    }
    var mSCty = document.getElementById('ddlSCty').value;
    var mLevel = document.getElementById('ddlLevel').value;
    var mType = document.getElementById('ddlType').value;
    GetInstitutions(origin + "/api/Institution/" + mSCty + "/" + mLevel + "/" + mType);

    var str = "";

    function GetInstitutions(murl) {
        $.ajax({
            url: murl,
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {
                    txt1 = "";
                    $('#datatable tr').not(':first').remove();
                    var x = 0;
                    $.each(response, function (key, value) {
                        x += 1;
                        //CONSTRUCTION OF ROWS HAVING 
                        txt1 += '<tr>';
                        txt1 += '<td style="text-align:left;">' +
                            x + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Institution_Code + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Institution_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Status_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Accommodation_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Postal_Address + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Mobile_Number1 + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.TSC_Total + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.BOM_Total + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Staff + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.BC_Total + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.WBC_Total + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Learners + '</td>';
                        str = "&#39;" + value.Institution_Code + "&#39;";
                        txt1 += '<td style="text-align:left;">' +
                            '<a href="/Institution/Edit/' + value.Institution_Code + '">View</a>  |' +
                            '<a href="#" onclick="deleteSession(' + str + ')" id="btnDelete" data-target="#deleteModal" title="Delete"><span class="glyphicon glyphicon-trash"></span></a>  |' +
                            '<a href="/Institution/Move/' + value.Institution_Code + '">Move</a>' + '</td>';
                        txt1 += '</tr>';
                    });
                    $('#datatable tr').first().after(txt1);
                }
            },
            error: function (request, message, error) {
                handleException(request, message, error);
            }
        });
    }

    $('.ddlCty').change(function () {
        var mCty = document.getElementById('ddlCty').value;
        sessionStorage.mCounty = mCty;
    });

    $('.ddlSCty').change(function () {
        var mSCty = document.getElementById('ddlSCty').value;
        sessionStorage.mSCounty = mSCty;

        var mLevel = document.getElementById('ddlLevel').value;
        var mType = document.getElementById('ddlType').value;
        GetInstitutions(origin + "/api/Institution/" + mSCty + "/" + mLevel + "/" + mType);
    });

    $('.ddlLevel').change(function () {
        var mLevel = document.getElementById('ddlLevel').value;
        sessionStorage.mLevelCode = mLevel;
        var mSCty = document.getElementById('ddlSCty').value;
        var mType = document.getElementById('ddlType').value;
        GetInstitutions(origin + "/api/Institution/" + mSCty + "/" + mLevel + "/" + mType);
    });

    $('.ddlType').change(function () {
        var mType = document.getElementById('ddlType').value;
        sessionStorage.mTypeCode = mType;
        var mLevel = document.getElementById('ddlLevel').value;
        var mSCty = document.getElementById('ddlSCty').value;
        GetInstitutions(origin + "/api/Institution/" + mSCty + "/" + mLevel + "/" + mType);
    });
});