
$("#TicketStatus").change(function () {

    console.log("hello");

    var state = $("#TicketStatus").val();
    var ticketId = $("#TicketStatus").attr("ticketId");

    $.ajax({
        url: "/Doctor/OnlineVisit/ChangeTicketStatus",
        type: "post",
        data: {
            status: state,
            ticketId: ticketId
        },
        beforeSend: function() {
            open_waiting();
        },
        success: function(response) {
            close_waiting();
            if (response.status === "Success") {
                $("#TicketStatusName").html(response.data);
                ShowMessage("اعلان", "وضعیت تیکت با موفقیت تغییر کرد .", "success");
            } else {
                ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
            }
        },
        error: function() {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });

});

$("#WorkingOn").click(function () {
    var ticketId = $("#WorkingOn").attr("ticketId");

    $.ajax({
        url: "/Admin/Ticket/ChangeTicketOnWorkingStatus",
        type: "post",
        data: {
            ticketId: ticketId
        },
        beforeSend: function () {
            open_waiting();
        },
        success: function (response) {
            close_waiting();
            if (response.status === "Success") {
                ShowMessage("اعلان", "وضعیت پیگیری تیکت با موفقیت تغییر کرد .", "success");
            } else {
                ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
            }
        },
        error: function () {
            close_waiting();
            ShowMessage("خطا", "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .", "error");
        }
    });

});