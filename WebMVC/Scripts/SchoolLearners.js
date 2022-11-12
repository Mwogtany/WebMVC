$(document).ready(function () {
    var myObj, x, txt1 = "", txt3 = "", txt4 = "";
    var origin = window.location.origin;
    var mUIC = privilage;
    $('#loadingmessage').show();
    var sgrade = sessionStorage.mGrade;
    if (sgrade !== "") {
        $('#ddlGrade').val(sgrade);
    }
    var scat = sessionStorage.mCatBCert;
    if (scat !== "") {
        $('#ddlCat').val(scat);
    }
    var mGrade = document.getElementById('ddlGrade').value;
    var mCat = document.getElementById('ddlCat').value;
    if (mCat === '1')
    {
        GetLearners(origin + "/api/School/Learners/" + mUIC + "/" + mGrade);
        $('#loadingmessage').hide();
    }
    else
    {
        GetLearners(origin + "/api/School/TmpLearners/" + mUIC + "/" + mGrade);
        $('#loadingmessage').hide();
    }
    var str = "";
    function GetLearners(murl) {
        $.ajax({
            //xhr: function () {
            //    var xhr = new window.XMLHttpRequest();
            //    xhr.upload.addEventListener("progress", function (evt) {
            //        if (evt.lengthComputable) {
            //            var percentComplete = evt.loaded / evt.total;
            //            console.log(percentComplete);
            //            $('.progress').css({
            //                width: percentComplete * 100 + '%'
            //            });
            //            if (percentComplete === 1) {
            //                $('.progress').addClass('hide');
            //            }
            //        }
            //    }, false);
            //    xhr.addEventListener("progress", function (evt) {
            //        if (evt.lengthComputable) {
            //            var percentComplete = evt.loaded / evt.total;
            //            console.log(percentComplete);
            //            $('.progress').css({
            //                width: percentComplete * 100 + '%'
            //            });
            //        }
            //    }, false);
            //    return xhr;
            //},
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
                        txt1 += '<td style="text-align:left;">'
                             + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.UPI + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Names + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.LGender + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.DOB + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.AGE + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Birth_Cert_No + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Disability_Name2 + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Medical_Name + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.Phone_Number + '</td>';
                        txt1 += '<td style="text-align:left;">' +
                            value.NHIF_No + '</td>';
                        str = "&#39;" + value.UPI + "&#39;";
                        txt1 += '<td style="text-align:left;">' +
                            '<a href="/School/EditLearner/' + value.UPI + '">View</a>  |' +
                            '<a href="#" onclick="deleteSession(' + str + ')" id="btnDelete" data-target="#deleteModal" title="Delete"><span class="glyphicon glyphicon-trash"></span></a>  |' +
                            '<a href="/School/MoveLearner/' + value.UPI + '">Move</a>' + '</td>';
                        txt1 += '</tr>';
                    });
                    $('#datatable tr').first().after(txt1);
                    $('#loadingmessage').hide();
                }
            },
            error: function (request, message, error) {
                $('#loadingmessage').hide();
                handleException(request, message, error);
            }
        });
    }

    $('.ddlGrade').change(function () {
        var mGrade = document.getElementById('ddlGrade').value;
        $('#loadingmessage').show();
        sessionStorage.mGrade = mGrade;
        var mgrd = sessionStorage.mGrade;

        var mCat = document.getElementById('ddlCat').value;
        var url = "";
        if (mCat === "1")
            {
            url = origin + "/api/School/Learners/" + mUIC + "/" + mGrade;
        }
        else
        {
            url = origin + "/api/School/TmpLearners/" + mUIC + "/" + mGrade;
        }
        GetLearners(url);
    });

    $('.ddlCat').change(function () {
        var mGrade = document.getElementById('ddlGrade').value;
        var mCat = document.getElementById('ddlCat').value;
        $('#loadingmessage').show();
        sessionStorage.mCatBCert = mCat;
        var mgrd = sessionStorage.mCatBCert;
        var url = "";
        if (mCat === "1") {
            url = origin + "/api/School/Learners/" + mUIC + "/" + mGrade;
        }
        else {
            url = origin + "/api/School/TmpLearners/" + mUIC + "/" + mGrade;
        }
        GetLearners(url);
    });
    //GetLearners(origin + "/api/School/TmpLearners/" + mUIC + "/" + mGrade);
});