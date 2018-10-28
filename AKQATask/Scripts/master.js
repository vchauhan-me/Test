
$("#btnGetResult").click(function () {

    var name = $("#Name").val();
    var value = $("#Value").val();


    var model = '{Name: "' + name + '", Value: "' + value + '" }';
    $.ajax({
        type: "POST",
        url: "/api/ResultAPI/ConvertToWord",
        data: model,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#viewB').html("Output: " + response.Name + "<br/>\"" + response.ResultText + "\"");
        },
        failure: function (response) {
            $('#viewB').html("<div style='background-colr:red'>" + response.responseText + "</div>");
        },
        error: function (response) {
            $('#viewB').html("<div style='background-colr:red'>" + response.responseText+"</div>");
        }
    });
});
