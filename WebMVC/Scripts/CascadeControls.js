$(document).ready(function () {
    $('#ddlCty').change(function () {
        var selcounty = $(this).val();
        $.getJSON("../../api/Cascade/SubCounties/" + selcounty,
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
        var selectscty = $("#ddlCons");
        if (selectscty !== null) {
            $.getJSON("../../api/Cascade/Constituencies/" + selcounty,
                function (classesData) {
                    selectscty.empty();
                    selectscty.append($('<option/>', {
                        value: 0,
                        text: "<<Select Constituency>>"
                    }));
                    $.each(classesData, function (index, itemData) {
                        selectscty.append($('<option/>', {
                            value: itemData.Constituency_Code,
                            text: itemData.Constituency_Name
                        }));
                    });
                });
        }
        var select = $("#ddlWards");
        select.empty();
        select.append($('<option/>', {
            value: 0,
            text: "<<Select Ward>>"
        }));
    });

    $('#ddlCons').change(function () {
        var selcounty = $(this).val();
        $.getJSON("../../api/Cascade/Wards/" + selcounty,
            function (classesData) {
                var select = $("#ddlWards");
                select.empty();
                select.append($('<option/>', {
                    value: 0,
                    text: "<<Select Ward>>"
                }));
                $.each(classesData, function (index, itemData) {
                    select.append($('<option/>', {
                        value: itemData.Ward_Code,
                        text: itemData.Ward_Name
                    }));
                });
            });
    });

    $('#ddlAgrType').change(function () {
        var selcounty = $(this).val();
        $.getJSON("../../api/Cascade/AgriItem/" + selcounty,
            function (classesData) {
                var select = $("#ddlAgrItem");
                select.empty();
                select.append($('<option/>', {
                    value: 0,
                    text: "<<Select Practice>>"
                }));
                $.each(classesData, function (index, itemData) {
                    select.append($('<option/>', {
                        value: itemData.ItemID,
                        text: itemData.ItemDescription
                    }));
                });
            });
    });
});