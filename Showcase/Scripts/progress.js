$(document).ready(function () {
    $('#ds-progress-wrap').progressbar({
        value: 1
    });
});
var statusTracker;
var percentage = 0;

function checkStatus() {
    percentage = percentage + 99;
    $('#ds-progress-bar').animate({
        width: percentage + '%'
    });

    if (percentage == 100) stop();
}
function startProgress() {
    statusTracker = setInterval(checkStatus, 100);
}

function stop() {
    clearInterval(statusTracker);
}
$(document).ready(startProgress);