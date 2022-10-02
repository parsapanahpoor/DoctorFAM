
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