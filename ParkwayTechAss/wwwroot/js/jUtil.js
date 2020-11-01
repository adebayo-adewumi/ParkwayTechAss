function CalculateCharge() {
    let ajaxPost = $.ajax({
        url: "/FeeCalculator/CalculateCharge",
        type: "post",
        data: { amount: $("[name='fee']").val() },
        dataType: "json"
    });

    ajaxPost.done(function (response) {
        $(".fee-response").html('<div class="alert alert-success">Fee Charge is: <strong>NGN '+response+'</strong></div>');
    });

    ajaxPost.fail(function (err) {
        console.log(err);
    });
}

function CalculateSurCharge() {
    let ajaxPost = $.ajax({
        url: "/FeeCalculator/CalculateSurCharge",
        type: "post",
        data: { amount: $("[name='surcharge']").val() },
        dataType: "json"
    });

    ajaxPost.done(function (response) {
        $(".response-body").append('<tr>' +
            '<td>' + response.amount + '</td >' +
            '<td>' + response.transferAmount + '</td>' +
            '<td>' + response.charge + '</td>' +
            '<td>'+response.debitAmount+'</td>'+
         '</tr >');
    });

    ajaxPost.fail(function (err) {
        console.log(err);
    });
}