var IDLE_CHECK_INTERVAL = 2;   // seconds
var IDLE_TIMEOUT = 10;         // seconds

var _idleSecondsCounter = 0;

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

var _intervalId = window.setInterval(CheckIdleTime, IDLE_CHECK_INTERVAL * 1000);

function CheckIdleTime() {
    _idleSecondsCounter += IDLE_CHECK_INTERVAL;

    if (_idleSecondsCounter >= IDLE_TIMEOUT) {

        window.clearInterval(_intervalId);

        alert("Time expired!");

        // Toast a dialog warning.

        document.location.href = "Home/LoggedOut";
    }
}