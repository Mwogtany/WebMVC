$(document).ready(function () {
    var nlevel = sessionStorage.mLevel;

    $('#ddlCty').change(function () {
        var mCty = document.getElementById('ddlCty').value;
        //sessionStorage.mCounty = mCty;
        var selectscty = $("#ddlSCty");
        if (selectscty !== null) {
            $.getJSON("../../api/Cascade/SubCounties/" + mCty,
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

            var selectzone = $("#ddlZone");
            if (selectzone !== null) {
                selectzone.empty();
                selectzone.append($('<option/>', {
                    value: 0,
                    text: "<<Select Zone>>"
                }));
            }
        }

        var selectconst = $("#ddlConst");
        if (selectconst !== null) {
            $.getJSON("../../api/Cascade/Constituencies/" + mCty,
                function (classesData) {
                    selectconst.empty();
                    selectconst.append($('<option/>', {
                        value: 0,
                        text: "<<Select Constituency>>"
                    }));
                    $.each(classesData, function (index, itemData) {
                        selectconst.append($('<option/>', {
                            value: itemData.Constituency_Code,
                            text: itemData.Constituency_Name
                        }));
                    });
                });

            var selectward = $("#ddlWard");
            if (selectward !== null) {
                selectward.empty();
                selectward.append($('<option/>', {
                    value: 0,
                    text: "<<Select Ward>>"
                }));
            }
        }

    });

    $('#ddlSCty').change(function () {
        var selscounty = $(this).val();
        var select = $("#ddlZone");
        if (select !== null) {
            $.getJSON("../../api/Cascade/Zones/" + selscounty,
                function (classesData) {
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "<<Select Zone>>"
                    }));
                    $.each(classesData, function (index, itemData) {
                        select.append($('<option/>', {
                            value: itemData.Zone_Code,
                            text: itemData.Zone_Name
                        }));
                    });
                });
        }
    });

    $('#ddlConst').change(function () {
        var selcounty = $(this).val();
        var select = $("#ddlWard");
        if (select !== null) {
            $.getJSON("../../api/Cascade/Wards/" + selcounty,
                function (classesData) {
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
        }
    });

    //var selectStatus = $("#ddlStatus");
    //if (selectStatus !== null) {
    //    $.getJSON("../../api/Cascade/RegStatus",
    //        function (classesData) {
    //            selectStatus.empty();
    //            selectStatus.append($('<option/>', {
    //                value: 0,
    //                text: "<<Select Status>>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectStatus.append($('<option/>', {
    //                    value: itemData.Status_Code,
    //                    text: itemData.Status_Name
    //                }));
    //            });
    //        });
    //}
    //var selectCategory = $("#ddlCategory");
    //if (selectCategory !== null) {
    //    $.getJSON("../../api/Cascade/InstitutionCategory",
    //        function (classesData) {
    //            selectCategory.empty();
    //            selectCategory.append($('<option/>', {
    //                value: 0,
    //                text: "<<Select Category>>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectCategory.append($('<option/>', {
    //                    value: itemData.Institution_Cat_Code,
    //                    text: itemData.Institution_Cat_Name
    //                }));
    //            });
    //        });
    //}
    //var selectCluster = $("#ddlCluster");
    //if (selectCluster !== null) {
    //    $.getJSON("../../api/Cascade/InstitutionCluster",
    //        function (classesData) {
    //            selectCluster.empty();
    //            selectCluster.append($('<option/>', {
    //                value: 0,
    //                text: "<<Select Cluster>>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectCluster.append($('<option/>', {
    //                    value: itemData.Cluster_Code,
    //                    text: itemData.Cluster_Name
    //                }));
    //            });
    //        });
    //}
    //var selectSGender = $("#ddlSGender");
    //if (selectSGender !== null) {
    //    $.getJSON("../../api/Cascade/InstitutionGender",
    //        function (classesData) {
    //            selectSGender.empty();
    //            selectSGender.append($('<option/>', {
    //                value: 0,
    //                text: "<<Select Gender>>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectSGender.append($('<option/>', {
    //                    value: itemData.School_Gender_Code,
    //                    text: itemData.School_Gender_Name
    //                }));
    //            });
    //        });
    //}
    //var selectAccomm = $("#ddlAccomm");
    //if (selectAccomm !== null) {
    //    $.getJSON("../../api/Cascade/InstitutionAccommodationType",
    //        function (classesData) {
    //            selectAccomm.empty();
    //            selectAccomm.append($('<option/>', {
    //                value: 0,
    //                text: "<< Select >>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectAccomm.append($('<option/>', {
    //                    value: itemData.Accommodation_Code,
    //                    text: itemData.Accommodation_Name
    //                }));
    //            });
    //        });
    //}
    //var selectMobility = $("#ddlMob");
    //if (selectMobility !== null) {
    //    $.getJSON("../../api/Cascade/InstitutionMobilityType",
    //        function (classesData) {
    //            selectMobility.empty();
    //            selectMobility.append($('<option/>', {
    //                value: 0,
    //                text: "<< Select >>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectMobility.append($('<option/>', {
    //                    value: itemData.Mobility_Code,
    //                    text: itemData.Mobility_Name
    //                }));
    //            });
    //        });
    //}
    //var selectFormality = $("#ddlFormality");
    //if (selectFormality !== null) {
    //    $.getJSON("../../api/Cascade/InstitutionFormalityType",
    //        function (classesData) {
    //            selectFormality.empty();
    //            selectFormality.append($('<option/>', {
    //                value: 0,
    //                text: "<< Select >>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectFormality.append($('<option/>', {
    //                    value: itemData.Formality_Code,
    //                    text: itemData.Formality_Name
    //                }));
    //            });
    //        });
    //}
    //var selectResid = $("#ddlResid");
    //if (selectResid !== null) {
    //    $.getJSON("../../api/Cascade/InstitutionResidenceType",
    //        function (classesData) {
    //            selectResid.empty();
    //            selectResid.append($('<option/>', {
    //                value: 0,
    //                text: "<< Select >>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectResid.append($('<option/>', {
    //                    value: itemData.Residence_Code,
    //                    text: itemData.Residence
    //                }));
    //            });
    //        });
    //}
    //var selectEduSys = $("#ddlEduSys");
    //if (selectEduSys !== null) {
    //    $.getJSON("../../api/Cascade/InstitutionEduSysType",
    //        function (classesData) {
    //            selectEduSys.empty();
    //            selectEduSys.append($('<option/>', {
    //                value: 0,
    //                text: "<< Select >>"
    //            }));
    //            $.each(classesData, function (index, itemData) {
    //                selectEduSys.append($('<option/>', {
    //                    value: itemData.Education_System_Code,
    //                    text: itemData.Educationa_System_Name
    //                }));
    //            });
    //        });
    //}
});