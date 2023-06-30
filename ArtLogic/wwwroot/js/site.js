$(document).ready(function () {
    $("#idMsgAlert").hide();
    $(".alert alert-danger validation-summary-errors").fadeTo(2000, 1000).slideUp(1000, function () {
        $("#idMsgAlert").slideUp(1000);
    });
});

function validateFile($input) {
    var extPermitidas = ['txt'];
    var extFile = $input.value.split('.').pop();

    if ($input.value == "") {
        $(".alert").html("File is required");
        $("#idMsgAlert").fadeTo(2000, 1000).slideUp(2000, function () {
            $("#idMsgAlert").slideUp(1000);
        });

    } else
        if (typeof extPermitidas.find(function (ext) { return extFile == ext; }) == 'undefined') {
            $(".alert").html("Extension <strong>" + extFile + "</strong> is invalid!");
            $("#idMsgAlert").fadeTo(2000, 1000).slideUp(1000, function () {
                $("#idMsgAlert").slideUp(1000);
            });
            $input.value = "";
        } 
            
}


