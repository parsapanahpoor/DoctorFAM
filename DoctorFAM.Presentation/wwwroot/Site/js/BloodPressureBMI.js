
//#region Load BMI View Model

function ShowBMIModal() {
    $.ajax({
        url: "/Show-BMI-Modal-In-BloodPressure",
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

//#region Load BloodPressure Population Modal

function ShowBloodPressurePopulationModal() {
    $.ajax({
        url: "/Show-BloodPressurePopulation-Modal",
        type: "get",
        data: {

        },
        success: function (response) {
            $("#modal-body").html(response);

            $('#BloodPressurePopulationForm').data('validator', null);
            $.validator.unobtrusive.parse('#BloodPressurePopulationForm');

            $("#exampleModal").modal("show");
        }
    });
}

//#endregion

//#region Load GFR View Model

function ShowGFRModal() {
    $.ajax({
        url: "/Show-GFR-Modal-In-BloodPressure",
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

//#region Priodic Blood Pressure Self Evaluation Model

function PriodicBloodPressureSelfEvaluationModal() {
    $.ajax({
        url: "/Priodic-BloodPressure-Self-Evaluation-Modal",
        type: "get",
        data: {

        },
        success: function (response) {
            $("#modal-body").html(response);

            $('#PriodicBloodPressureSelfEvaluationForm').data('validator', null);
            $.validator.unobtrusive.parse('#PriodicBloodPressureSelfEvaluationForm');

            $("#exampleModal").modal("show");
        }
    });
}

//The Java Scripts Codes For Inside Of The Modal

$(document).on('change', '#HasBloodPressure', function () {
    var selectedAdvertisementStatusValue = $("#HasBloodPressure :selected").val();

    $("#HowYearsOld-div").addClass("d-none");
    $("#DoctorFathi-div").addClass("d-none");
    $("#Submit-div").addClass("d-none");

    if (selectedAdvertisementStatusValue == 1) {
        $("#BloodPressureHelp1-div").removeClass("d-none");
        $("#RequestFor3MonthLater-div").addClass("d-none");
    }
    else if
        (selectedAdvertisementStatusValue == 2) {
        $("#RequestFor3MonthLater-div").removeClass("d-none");
        $("#BloodPressureHelp1-div").addClass("d-none");
    }
    else {
        $("#RequestFor3MonthLater-div").addClass("d-none");
        $("#BloodPressureHelp1-div").addClass("d-none");
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

//#endregion