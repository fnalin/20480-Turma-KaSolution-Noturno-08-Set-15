$("#btnGet").on("click", function () {
    $("#ajaxLoad").removeClass("hidden");
    $("#selectClientes").html("<option> -- Buscando ... -- </option>");
    $.get(strURL, function (dados) {
        var options = "";
        for (var i = 0; i < dados.length; i++) {
            options += "<option value=" + dados[i].ID + ">" + dados[i].Nome + "</option>";
        }
        $("#selectClientes").html(options);
    }).done(function () {
        $("#ajaxLoad").addClass("hidden");
    }).fail(function () {
        $("#ajaxLoad").addClass("hidden");
        alert("Erro na requisição");
        $("#selectClientes").html("<option> -- Erro ... -- </option>");
    });
});