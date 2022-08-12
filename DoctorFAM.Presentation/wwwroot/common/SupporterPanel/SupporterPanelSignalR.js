
//#region Create Connection

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub/Notification")
    .build();

//#endregion

//#region Start Connection And Check User Onile State

async function Start() {
    try {

        //If User In Connected 
        await connection.start();
        ShowMessage("اعلان", "اتصال شما برقرار شده است", "success");
        $("#disConnect").hide();
        $("#Online").show();

    }
    catch (e) {

        //If User Is Disconnected
        $("#disConnect").show();
        $("#Online").hide();
        ShowMessage("اعلان", "اتصال شما به اینترنت قطع شده است.", "error");
        setTimeout(Start, 6000);

    }
}

//When Connection Is Lost Try To Connect Again
connection.onclose(Start);
Start();

//#endregion





