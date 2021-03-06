

//select state and city by country id

const countryEl = document.getElementById('CountryId');
const stateEl = document.getElementById('StateId');
const cityEl = document.getElementById('CityId');

$(countryEl).on('change',
    function (event) {
        stateEl.innerHTML = "";
        cityEl.innerHTML = "";
        stateEl.setAttribute('disabled', '');
        cityEl.setAttribute('disabled', '');

        const countryId = event.currentTarget.value;

        if (!countryId) {
            return;
        }

        $.ajax({
            method: 'get',
            url: '/Admin/Location/GetLocationsByParentId/' + countryId,
            success: function (response) {
                stateEl.removeAttribute('disabled');
                createLocationsElement(response.data, stateEl);
            }
        });
    });

$(stateEl).on('change',
    function (event) {
        cityEl.innerHTML = "";
        cityEl.setAttribute('disabled', '');

        const stateId = event.currentTarget.value;

        if (!stateId) {
            return;
        }

        $.ajax({
            method: 'get',
            url: '/Admin/Location/GetLocationsByParentId/' + stateId,
            success: function (response) {
                cityEl.removeAttribute('disabled');
                createLocationsElement(response.data, cityEl);
            }
        });
    });

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