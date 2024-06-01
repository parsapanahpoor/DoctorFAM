
//#region Load ASCVD View Model

function ShowASCVDModal() {
    $.ajax({
        url: "/Show-Diabet-Page-ASCVD-Modal",
        type: "get",
        data: {

        },
        success: function (response) {
            $("#modal-body").html(response);

            $('#ASCVDForm').data('validator', null);
            $.validator.unobtrusive.parse('#ASCVDForm');

            $("#exampleModal").modal("show");
        }
    });
}

//#endregion

//#region Load Diabet Population Modal

function ShowDiabetPopulationModal() {
    $.ajax({
        url: "/Show-DiabetPopulation-Modal",
        type: "get",
        data: {

        },
        success: function (response) {
            $("#modal-body").html(response);

            $('#DiabetPopulationForm').data('validator', null);
            $.validator.unobtrusive.parse('#DiabetPopulationForm');

            $("#exampleModal").modal("show");
        }
    });
}

//#endregion

//#region Load BMI View Model

function ShowBMIModal() {
    $.ajax({
        url: "/Show-BMI-Modal",
        type: "get",
        data: {

        },
        success: function (response) {
            $("#modal-body").html(response);

            $('#BMIForm').data('validator', null);
            $.validator.unobtrusive.parse('#BMIForm');

            $("#exampleModal").modal("show");
        }
    });
}

//#endregion

//#region Load GFR View Model

function ShowGFRModal() {
    $.ajax({
        url: "/Show-GFR-Modal",
        type: "get",
        data: {

        },
        success: function (response) {
            $("#modal-body").html(response);

            $('#GFRForm').data('validator', null);
            $.validator.unobtrusive.parse('#GFRForm');

            $("#exampleModal").modal("show");
        }
    });
}

//#endregion

//#region Priodic Self Evaluation Model

function PriodicSelfEvaluationModal() {
    $.ajax({
        url: "/Priodic-Self-Evaluation-Modal",
        type: "get",
        data: {

        },
        success: function (response) {
            $("#modal-body").html(response);

            $('#PriodicSelfEvaluationForm').data('validator', null);
            $.validator.unobtrusive.parse('#PriodicSelfEvaluationForm');

            $("#exampleModal").modal("show");
        }
    });
}

//The Java Scripts Codes For Inside Of The Modal

$(document).on('change', '#HasDiabet', function () {
    var selectedAdvertisementStatusValue = $("#HasDiabet :selected").val();

    $("#HowYearsOld-div").addClass("d-none");
    $("#DoctorFathi-div").addClass("d-none");
    $("#Submit-div").addClass("d-none");

    if (selectedAdvertisementStatusValue == 1) {
        $("#DiabetHelp1-div").removeClass("d-none");
        $("#RequestFor3MonthLater-div").addClass("d-none");
    }
    else if
        (selectedAdvertisementStatusValue == 2) {
        $("#RequestFor3MonthLater-div").removeClass("d-none");
        $("#DiabetHelp1-div").addClass("d-none");
    }
    else {
        $("#RequestFor3MonthLater-div").addClass("d-none");
        $("#DiabetHelp1-div").addClass("d-none");
    }
});

$(document).on('change', '#RequestFor3MonthLater', function () {
    var selectedAdvertisementStatusValue = $("#RequestFor3MonthLater :selected").val();

    if (selectedAdvertisementStatusValue == 1) {
        $("#DoctorFathi-div").removeClass("d-none");
        $("#Submit-div").removeClass("d-none");
        $("#HowYearsOld-div").addClass("d-none");
    }
    else if
        (selectedAdvertisementStatusValue == 2) {
        $("#HowYearsOld-div").removeClass("d-none");
        $("#DoctorFathi-div").addClass("d-none");
        $("#Submit-div").addClass("d-none");
    }
    else {
        $("#HowYearsOld-div").addClass("d-none");
        $("#DoctorFathi-div").addClass("d-none");
        $("#Submit-div").addClass("d-none");
    }
});

$(document).on('change', '#HowYearsOld', function () {
    var selectedAdvertisementStatusValue = $("#HowYearsOld :selected").val();

    if (selectedAdvertisementStatusValue == 1) {
        $("#DiabetRiskFactorFields-div").removeClass("d-none");
        $("#EmergancyFBS-div").addClass("d-none");
    }
    else if
        (selectedAdvertisementStatusValue == 2) {
        $("#EmergancyFBS-div").removeClass("d-none");
        $("#DiabetRiskFactorFields-div").addClass("d-none");
    }
    else {
        $("#EmergancyFBS-div").addClass("d-none");
        $("#DiabetRiskFactorFields-div").addClass("d-none");
    }
});

$(document).on('change', '#QuestionOfDiabetRiskFactor', function () {
    var selectedAdvertisementStatusValue = $("#QuestionOfDiabetRiskFactor :selected").val();

    if (selectedAdvertisementStatusValue == 1) {
        $("#FBSTest-div").removeClass("d-none");
        $("#NoFBSTest-div").addClass("d-none");
    }
    else if
        (selectedAdvertisementStatusValue == 2) {
        $("#NoFBSTest-div").removeClass("d-none");
        $("#FBSTest-div").addClass("d-none");
    }
    else {
        $("#NoFBSTest-div").addClass("d-none");
        $("#FBSTest-div").addClass("d-none");
    }
});

//#endregion
