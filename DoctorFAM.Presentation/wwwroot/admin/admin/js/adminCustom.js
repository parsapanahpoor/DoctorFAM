//#region Paging Function

function FillPartialPageId(pageId, baseName) {
    console.log("hello");
    var formId = GetFormIdForSearchModal(baseName);
    $("#PartialPageId").val(pageId);
    $(`#${formId}`).submit();
}

//#endregion

//#region Get Ids Functions

function GetInputIdForSearchModal(baseName) {
    return `${baseName}-Input`;
}

function GetDisplayIdForSearchModal(baseName) {
    return `${baseName}-Display`;
}

function GetFormIdForSearchModal(baseName) {
    return `${baseName}-Form`;
}

//#endregion

//#region Search User Modal

function ShowSearchUserModal(baseName) {
    $.ajax({
        url: "/Admin/Home/SearchUserModal",
        type: "post",
        data: {
            baseName: baseName
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            $("#LargeModalTitle").html("لیست کاربران");
            $("#LargeModalBody").html(response);
            $("#LargeModal").modal("show");
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

function SelectUser(userId, userName, baseName) {
    var inputId = GetInputIdForSearchModal(baseName);
    var displayId = GetDisplayIdForSearchModal(baseName);

    $(`#${inputId}`).val(userId).trigger("change");
    $(`#${displayId}`).val(userName).trigger("change");

    $("#LargeModal").modal("hide");
}

//#endregion

//#region Search Branch Modal

function ShowSearchBranchModal(baseName) {
    $.ajax({
        url: "/Admin/Home/SearchBranchModal",
        type: "post",
        data: {
            baseName: baseName
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            $("#LargeModalTitle").html("لیست شعبه ها");
            $("#LargeModalBody").html(response);
            $("#LargeModal").modal("show");
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

function SelectBranch(branchId, branchName, baseName, branchPercent) {
    var inputId = GetInputIdForSearchModal(baseName);
    var displayId = GetDisplayIdForSearchModal(baseName);

    $(`#${inputId}`).val(branchId).trigger("change");
    $(`#${displayId}`).val(branchName).trigger("change");

    if ($("#BranchPercentage").length) {
        $("#BranchPercentage").val(branchPercent);
    }

    $("#LargeModal").modal("hide");
}

//#endregion

//#region Search Master Modal

function ShowSearchMasterModal(baseName) {
    var branchId = $("#Branch-Input").val();

    if (branchId === "" || !branchId.length) {
        ShowMessage("اعلان", "برای انتخاب مدرس ابتدا باید شعبه را انتخاب کنید .", "info");
        return;
    }

    $.ajax({
        url: "/Admin/Home/SearchMasterModal",
        type: "post",
        data: {
            baseName: baseName,
            branchId: branchId
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            $("#LargeModalTitle").html("لیست مدرسین");
            $("#LargeModalBody").html(response);
            $("#LargeModal").modal("show");
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

function SelectMaster(masterId, masterName, baseName, masterPercent) {
    var inputId = GetInputIdForSearchModal(baseName);
    var displayId = GetDisplayIdForSearchModal(baseName);

    $(`#${inputId}`).val(masterId).trigger("change");
    $(`#${displayId}`).val(masterName).trigger("change");

    if ($("#MasterPercentage").length) {
        $("#MasterPercentage").val(masterPercent);
    }

    $("#LargeModal").modal("hide");
}

//#endregion

//#region Search Course Modal

function ShowSearchCourseModal(baseName) {
    $.ajax({
        url: "/Admin/Home/SearchCourseModal",
        type: "post",
        data: {
            baseName: baseName
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            $("#LargeModalTitle").html("لیست دوره ها");
            $("#LargeModalBody").html(response);
            $("#LargeModal").modal("show");
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

function SelectCourse(courseId, courseTitle, baseName) {
    var inputId = GetInputIdForSearchModal(baseName);
    var displayId = GetDisplayIdForSearchModal(baseName);

    $(`#${inputId}`).val(courseId).trigger("change");
    $(`#${displayId}`).val(courseTitle).trigger("change");

    $("#LargeModal").modal("hide");
}

//#endregion

//#region Search Active Course Course Modal

function ShowSearchActiveCourseModal(baseName) {
    $.ajax({
        url: "/Admin/Home/SearchActiveCourseModal",
        type: "post",
        data: {
            baseName: baseName
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            $("#LargeModalTitle").html("لیست دوره های فعال");
            $("#LargeModalBody").html(response);
            $("#LargeModal").modal("show");
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

function SelectActiveCourse(activeCourseId, activeCourseTitle, baseName) {
    var inputId = GetInputIdForSearchModal(baseName);
    var displayId = GetDisplayIdForSearchModal(baseName);

    $(`#${inputId}`).val(activeCourseId).trigger("change");
    $(`#${displayId}`).val(activeCourseTitle).trigger("change");

    $("#LargeModal").modal("hide");
}

//#endregion

//#region Load Course Categories

$("#MainCategoryId").change(function () {
    if ($("#MainCategoryId :selected").val() !== '') {
        $('#SubCategoryId option:not(:first)').remove();
        $.get("/Admin/Home/LoadCourseCategories", { categoryId: $("#MainCategoryId :selected").val() }).then(res => {
            if (res.data !== null) {
                $.each(res.data, function () {
                    $("#SubCategoryId").append(
                        '<option value=' + this.id + '>' + this.title + '</option>'
                    );
                });
            }
        });
    } else {
        $('#SubCategoryId option:not(:first)').remove();
    }
});

//#endregion

//#region Document Ready

$(function () {
    var adminDatePickers = $("[AdminDatePicker]");
    if (adminDatePickers.length > 0) {
        $('<link/>',
            {
                rel: 'stylesheet',
                type: 'text/css',
                href: '/common/admindatapicker/kamadatepicker.min.css'
            }).appendTo('head');
        $.getScript("/common/admindatapicker/kamadatepicker.min.js", function (script, textStatus, jqXHR) { });
    }
});

//#endregion

//#region Change User Info State

function ChangeUserInfoState(userId, stateId) {
    $.ajax({
        url: "/Admin/Account/ChangePersonalInfoState",
        type: "post",
        data: {
            userId: userId,
            stateId: stateId
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            if (response.status === "Success") {
                ShowMessage("اعلان", "عملیات با موفقیت انجام شد", "success");
            } else {
                ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
            }
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

//#endregion

//#region Change Request Certificate State

function ChangeRequestCertificateState(requestId, stateId) {
    $.ajax({
        url: "/Admin/Certificate/ChangeRequestCertificateState",
        type: "post",
        data: {
            requestId: requestId,
            stateId: stateId
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            if (response.status === "Success") {
                ShowMessage("اعلان", "عملیات با موفقیت انجام شد", "success");
            } else {
                ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
            }
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

//#endregion

//#region Change Request Certificate Final State

function ChangeRequestCertificateFinalState(id) {
    console.log('do ajax');
    $.ajax({
        url: "/Admin/Certificate/ChangeFinalStateRequestCertificate",
        data: {
            "id": id
        },
        success: function (data) {
            if (data.status === 'Success') {
                ShowMessage('اعلان', 'عملیات با موفقیت انجام شد', 'success');
            } else {
                ShowMessage('اعلان', 'عملیات با شکست مواجه شد', 'error');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ShowMessage('اعلان', 'عملیات با شکست مواجه شد', 'error');
        }
    });
}

//#endregion