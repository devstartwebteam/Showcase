
$(function () {
    $('.ds-home-slider').bxSlider({
        mode: 'fade',
        auto: true,
        captions: false,
        infiniteLoop: true,
        responsive: true
    });
});

// Show the progress bar 
NProgress.start();

// Increase randomly
var interval = setInterval(function () { NProgress.inc(); }, 1000);

// Trigger finish when page fully loaded
jQuery(window).load(function () {
    clearInterval(interval);
    NProgress.done();
});

// Trigger bar when exiting the page
jQuery(window).unload(function () {
    NProgress.start();
});