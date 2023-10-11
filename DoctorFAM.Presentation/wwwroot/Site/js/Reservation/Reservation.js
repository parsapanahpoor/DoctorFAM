
//The Java Scripts Codes For Inside Of The Modal

$(document).on('change', '#GetReservationForHimSelf', function () {
    var selectedGetReservationForHimSelf = $("#GetReservationForHimSelf :selected").val();

    $("#PersonalInformation").addClass("d-none");
    $("#OtherInformation").addClass("d-none");
    $("#MainContent").addClass("d-none");

    if (selectedGetReservationForHimSelf == 1) {
        $("#PersonalInformation").removeClass("d-none");
        $("#MainContent").removeClass("d-none");
        $("#OtherInformation").addClass("d-none");
    }
    else if
        (selectedGetReservationForHimSelf == 0) {
        $("#OtherInformation").removeClass("d-none");
        $("#MainContent").removeClass("d-none");
        $("#PersonalInformation").addClass("d-none");
    }
});

//#endregion