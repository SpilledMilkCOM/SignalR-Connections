var IDLE_CHECK_INTERVAL = 2;   // seconds
var IDLE_TIMEOUT = 30;         // seconds

var _idleSecondsCounter = 0;
var _logoutIntervalId;
var _logoutSecondsCounter = 0;

// This would eventually be a 2-stage process, with a warning...  (and the expiration timer would still be running and FIRE if the warning was not dismissed)

document.onclick = function () {
    _idleSecondsCounter = 0;
};

document.onmousemove = function () {
    _idleSecondsCounter = 0;
};

document.onkeypress = function () {
    _idleSecondsCounter = 0;
};

var _warningIntervalId = window.setInterval(CheckIdleTime, IDLE_CHECK_INTERVAL * 1000);

function CheckIdleTime() {
    _idleSecondsCounter += IDLE_CHECK_INTERVAL;

    if (_idleSecondsCounter >= IDLE_TIMEOUT) {

        console.log("Idle time reached.");

        window.clearInterval(_warningIntervalId);
        _logoutIntervalId = window.setInterval(CheckLogoutTime, IDLE_CHECK_INTERVAL * 1000);

        // Warning dialog here.

        var warningModal = document.getElementById("warningModal");

        if (warningModal != null) {
            console.log("Displaying modal.");

            $('#warningModal').modal('toggle');
        }
    }
}

function CheckLogoutTime() {
    _logoutSecondsCounter += IDLE_CHECK_INTERVAL;

    if (_logoutSecondsCounter >= IDLE_TIMEOUT) {

        window.clearInterval(_logoutIntervalId);

        Logout();
    }
}

function StayLoggedOn() {
    _idleSecondsCounter = 0;
    window.clearInterval(_logoutIntervalId);

    _warningIntervalId = window.setInterval(CheckIdleTime, IDLE_CHECK_INTERVAL * 1000);
}

function Logout() {
    // Navigate to LoggedOut

    document.location.href = "Home/LoggedOut";
}