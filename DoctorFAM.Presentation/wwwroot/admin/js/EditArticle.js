$("#MainCat").change(function () {
    if ($("#MainCat :selected").val() !== '') {
        $('#SubCat option:not(:first)').remove();
        $.get("/Admin/Home/LoadSubCategories", { MainCategoryId: $("#MainCat :selected").val() }).then(res => {
            if (res.data !== null) {
                $.each(res.data, function () {
                    $("#SubCat").append(
                        '<option value=' + this.id + '>' + this.title + '</option>'
                    );
                });
            }
        });
    } else {
        $('#SubCat option:not(:first)').remove();
    }
});