//#region Add User Wallet

function ShowAddUserWalletModal(userId) {
    $.ajax({
        url: "/Admin/Account/AddUserWallet",
        type: "Get",
        data: {
            userId: userId
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            var modalTitle = "افزودن تراکنش";
            $("#NormalModalTitle").html(modalTitle);
            $("#NormalModalBody").html(response);
            $('#UserWalletForm').data('validator', null);
            $.validator.unobtrusive.parse('#UserWalletForm');
            $("#NormalModal").modal("show");
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

function AddUserWalletFormDone(response) {
    close_waiting();
    if (response.status === "Success") {
        ShowMessage("اعلان", "عملیات با موفقیت انجام شد", "success");
        $("#NormalModal").modal("hide");
    }
    else {
        ShowMessage("اعلان", response.data, "error");
    }
}

//#endregion

//#region Change User Password

function ShowChangePasswordModal(userId) {
    console.log('s');
    $.ajax({
        url: "/Admin/Account/ChangePassword",
        type: "Get",
        data: {
            userId: userId
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            var modalTitle = "تغییر کلمه عبور کاربر";
            $("#NormalModalTitle").html(modalTitle);
            $("#NormalModalBody").html(response);
            $('#UserWalletForm').data('validator', null);
            $.validator.unobtrusive.parse('#ChangePasswordForm');
            $("#NormalModal").modal("show");
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });
}

function ChangePasswordFormDone(response) {
    close_waiting();
    if (response.status === "Success") {
        ShowMessage("اعلان", "عملیات با موفقیت انجام شد", "success");
        $("#NormalModal").modal("hide");
    }
    else {
        ShowMessage("اعلان", response.data, "error");
    }
}

//#endregion