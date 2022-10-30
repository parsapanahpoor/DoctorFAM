//#region Load BMI View Model

function ShowCooperationRequest() {
    $.ajax({
        url: "/Show-Cooperation-Request-Modal",
        type: "get",
        data: {

        },
        success: function (response) {
            $("#modal-body").html(response);


            $("#exampleModal").modal("show");
        }
    });
}

//#endregion