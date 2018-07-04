var postUrl = '';

function getLocation(url) {
    postUrl = url;

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {

    $.ajax({
        type: "POST",
        url: postUrl,
        data: JSON.stringify({
            latitude: position.coords.latitude,
            longitude: position.coords.longitude
        }),
        contentType: "application/json; charset=utf-8",
        success: function () {
            $('#location').html("" + position.coords.latitude + " " + position.coords.longitude);
        },
        error: function (xhr, err) {
            location.reload();
        }
    });
}

function addProduct(postUrl, idProduto) {
    $.ajax({
        type: "POST",
        url: postUrl,
        data: JSON.stringify({
            id: idProduto
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            MessageSuccess("Sucesso!", "Produto adicionado à cesta.");
            $("#quantityChart").html(data);
        },
        error: function (xhr, err) {
            MessageError("Erro!", "Houve um problema ao adicionar o produto à cesta");
        }
    });
}

function removeProduct(postUrl, idProduto)
{
    $.ajax({
        type: "POST",
        url: postUrl,
        data: JSON.stringify({
            id: idProduto
        }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#quantityChart").html(data);
            location.reload();
        },
        error: function (xhr, err) {
            MessageError("Erro!", "Houve um problema ao remover o produto.");
        }
    });
}

function editModal(title, value, description) {
    $("#ItemTitle").html(title);
    $("#ItemValue").html("R$ " + value);
    $("#ItemDescription").html(description);
}


