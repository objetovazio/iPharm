function Lock() {
    $(this).siblings().andSelf().fadeOut();
    $('body').fadeIn();
};

function Unlock() {
    $('body').fadeOut();
    $(this).closest('div').siblings().fadeIn();
};

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(savePosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function savePosition(position) {
    if (position.coords.latitude === undefined || position.coords.longitude === undefined) Lock();
    Message("1", "Position: " + position.coords.latitude + " " + position.coords.longitude);
}

$(document).ready(function () {
    navigator.geolocation.watchPosition(function (position) {
        savePosition(position);
    },
        function (error) {
            if (error.code == error.PERMISSION_DENIED)
                Lock();
        });

    //getLocation();
});