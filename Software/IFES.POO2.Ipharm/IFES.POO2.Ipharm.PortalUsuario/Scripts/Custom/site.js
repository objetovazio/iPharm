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
