
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