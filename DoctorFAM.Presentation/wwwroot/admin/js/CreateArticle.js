$("#MainCategory").change(function () {
    if ($("#MainCategory :selected").val() !== '') {
        $('#SubCategory option:not(:first)').remove();
        $.get("/Admin/Home/LoadSubCategories", { MainCategoryId: $("#MainCategory :selected").val() }).then(res => {
            if (res.data !== null) {
                $.each(res.data, function () {
                    $("#SubCategory").append(
                        '<option value=' + this.id + '>' + this.title + '</option>'
                    );
                });
            }
        });
    } else {
        $('#SubCategory option:not(:first)').remove();
    }
});