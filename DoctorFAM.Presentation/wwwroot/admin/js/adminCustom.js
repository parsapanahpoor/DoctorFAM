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

function createLocationsElement(data, insertEl) {
    for (let location of data) {
        let optionEl = document.createElement('option');
        optionEl.setAttribute('value', location.locationId);
        optionEl.innerHTML = location.name;

        insertEl.appendChild(optionEl);
    }
    $(insertEl).trigger('change');
}

//change avatar preview

var loadAvatar = function (event) {
    var image = document.getElementById('avatarPreview');
    image.src = URL.createObjectURL(event.target.files[0]);
};


//#region Document Ready

$(function () {
    if ($("input[name=Permissions]").length === $("input[name=Permissions]:checked").length) {
        $("#SelectAll").prop("checked", true);
    }
});

//#endregion

//#region Select All Button

$("#SelectAll").click(function (e) {
    if (this.checked) {
        $(".accordion-toggle").each(function (index, value) {
            if ($(value).hasClass("collapsed")) {
                $(value).removeClass("collapsed");
            }
        });
        $(".panel-collapse").each(function (index, value) {
            if (!$(value).hasClass("in")) {
                $(value).addClass("in");
            }
        });
        $(".accordion-toggle").attr("aria-expanded", true);
        $(".panel-collapse").attr("aria-expanded", true);
        $(".panel-collapse").css("height", "auto");
        $("input[name=Permissions]").prop("checked", true);
    } else {
        $(".accordion-toggle").each(function (index, value) {
            if (!$(value).hasClass("collapsed")) {
                $(value).addClass("collapsed");
            }
        });
        $(".panel-collapse").each(function (index, value) {
            if ($(value).hasClass("in")) {
                $(value).removeClass("in");
            }
        });
        $(".accordion-toggle").attr("aria-expanded", false);
        $(".panel-collapse").attr("aria-expanded", false);
        $(".panel-collapse").css("height", "0");
        $("input[name=Permissions]").prop("checked", false);
    }
});

//#endregion

//#region Check Box Click

$("input[name=Permissions]").click(function (e) {
    var id = $(this).attr("data-id");
    var parentId = $(this).attr("data-parentId");
    if (this.checked) {
        if (parentId === undefined) {
            $(`input[data-parentId=${id}]`).each(function (index, value) {
                $(this).prop("checked", true);
            });
        } else {
            $(`input[data-id=${parentId}]`).prop("checked", true);
        }
    } else {
        if (parentId === undefined) {
            $(`input[data-parentId=${id}]`).each(function (index, value) {
                $(this).prop("checked", false);
            });
        } else {
            if ($(`input[data-parentId=${parentId}]:checked`).length < 1) {
                $(`input[data-id=${parentId}]`).prop("checked", false);
            }
        }
        $("#SelectAll").prop("checked", false);
    }
});

//#endregion

//#region Search User Modal

function ShowSearchUserModal(baseName) {
    $.ajax({
        url: "/Admin/Home/SearchUserModal",
        type: "post",
        data: {
            baseName: baseName
        },
        success: function (response) {
            close_waiting();
            $("#LargeModalBody").html(response);
            $("#LargeModal").modal("show");
            console.log(response);
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


//#region CkEditor

var editors = $("[ckeditor]");
if (editors.length > 0) {
    $.getScript("/lib/ckeditor/build/ckeditor.js",
        function () {
            $(editors).each(function (index, value) {
                var id = $(value).attr('ckeditor');
                var data = $(value).attr('ck-data');
                var lang = $(value).attr('ck-lang');
                if (lang === "fa") {
                    ClassicEditor.create(document.querySelector('[ckeditor="' + id + '"]'),
                        {
                            toolbar: {
                                items: [
                                    'heading',
                                    '|',
                                    'bold',
                                    'italic',
                                    'underline',
                                    'blockQuote',
                                    'link',
                                    '|',
                                    'fontColor',
                                    'fontSize',
                                    '|',
                                    'alignment',
                                    'numberedList',
                                    'bulletedList',
                                    'indent',
                                    'outdent',
                                    '|',
                                    'imageUpload',
                                    'insertTable',
                                    '|',
                                    'codeBlock',
                                    'removeFormat',
                                ]
                            },
                            language: lang,
                            image: {
                                toolbar: [
                                    'imageTextAlternative',
                                    'imageStyle:full',
                                    'imageStyle:side'
                                ]
                            },
                            table: {
                                contentToolbar: [
                                    'tableColumn',
                                    'tableRow',
                                    'mergeTableCells',
                                    'tableCellProperties',
                                    'tableProperties'
                                ]
                            },
                            simpleUpload: {
                                uploadUrl: '/Uploader/UploadImage'
                            },
                            licenseKey: '',
                        })
                        .then(editor => {
                            window.editor = editor;
                            if (data !== undefined && data !== null) {
                                editor.setData(data);
                            }
                        })
                        .catch(error => {
                            console.error(error);
                        });
                }
                else {
                    $.getScript(`/lib/ckeditor/build/translations/${lang}.js`, function () {
                        ClassicEditor.create(document.querySelector('[ckeditor="' + id + '"]'),
                            {
                                toolbar: {
                                    items: [
                                        'heading',
                                        '|',
                                        'bold',
                                        'italic',
                                        'underline',
                                        'blockQuote',
                                        'link',
                                        '|',
                                        'fontColor',
                                        'fontSize',
                                        '|',
                                        'alignment',
                                        'numberedList',
                                        'bulletedList',
                                        'indent',
                                        'outdent',
                                        '|',
                                        'imageUpload',
                                        'insertTable',
                                        '|',
                                        'codeBlock',
                                        'removeFormat',
                                    ]
                                },
                                language: lang,
                                image: {
                                    toolbar: [
                                        'imageTextAlternative',
                                        'imageStyle:full',
                                        'imageStyle:side'
                                    ]
                                },
                                table: {
                                    contentToolbar: [
                                        'tableColumn',
                                        'tableRow',
                                        'mergeTableCells',
                                        'tableCellProperties',
                                        'tableProperties'
                                    ]
                                },
                                simpleUpload: {
                                    uploadUrl: '/Uploader/UploadImage'
                                },
                                licenseKey: '',
                            })
                            .then(editor => {
                                window.editor = editor;
                                if (data !== undefined && data !== null) {
                                    editor.setData(data);
                                }
                            })
                            .catch(error => {
                                console.error(error);
                            });
                    });
                }
            });
        });
}

//#endregion


//#region show Selec tUser Section in  create notification page
function showSelectUserSection() {
    var checkBox = document.getElementById("IsForSingleUser");
    var userList = document.getElementById("findUserSection");

    if (checkBox.checked == false) {
        userList.style.display = "none";
        document.getElementById("Owner-Input").removeAttribute('value');;
    } else {
        userList.style.display = "block";
    }
}
//#endregion


//#region Document Ready

$(function () {
    if ($("input[name=CategoriesId]").length === $("input[name=CategoriesId]:checked").length) {
        $("#SelectAll").prop("checked", true);
    }
});

//#endregion

//#region Select All Button

$("#SelectAll").click(function (e) {
    if (this.checked) {
        $(".accordion-toggle").each(function (index, value) {
            if ($(value).hasClass("collapsed")) {
                $(value).removeClass("collapsed");
            }
        });
        $(".panel-collapse").each(function (index, value) {
            if (!$(value).hasClass("in")) {
                $(value).addClass("in");
            }
        });
        $(".accordion-toggle").attr("aria-expanded", true);
        $(".panel-collapse").attr("aria-expanded", true);
        $(".panel-collapse").css("height", "auto");
        $("input[name=CategoriesId]").prop("checked", true);
    } else {
        $(".accordion-toggle").each(function (index, value) {
            if (!$(value).hasClass("collapsed")) {
                $(value).addClass("collapsed");
            }
        });
        $(".panel-collapse").each(function (index, value) {
            if ($(value).hasClass("in")) {
                $(value).removeClass("in");
            }
        });
        $(".accordion-toggle").attr("aria-expanded", false);
        $(".panel-collapse").attr("aria-expanded", false);
        $(".panel-collapse").css("height", "0");
        $("input[name=CategoriesId]").prop("checked", false);
    }
});

//#endregion

//#region Check Box Click

$("input[name=CategoriesId]").click(function (e) {
    var id = $(this).attr("data-id");
    var parentId = $(this).attr("data-parentId");
    if (this.checked) {
        if (parentId === undefined) {
            $(`input[data-parentId=${id}]`).each(function (index, value) {
                $(this).prop("checked", true);
            });
        } else {
            $(`input[data-id=${parentId}]`).prop("checked", true);
        }
    } else {
        if (parentId === undefined) {
            $(`input[data-parentId=${id}]`).each(function (index, value) {
                $(this).prop("checked", false);
            });
        } else {
            if ($(`input[data-parentId=${parentId}]:checked`).length < 1) {
                $(`input[data-id=${parentId}]`).prop("checked", false);
            }
        }
        $("#SelectAll").prop("checked", false);
    }
});

//#endregion