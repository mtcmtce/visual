
$(document).ready(function () {
    $('#slider').coinslider({ hoverPause: false });
});


    $(document).ready(function () {
        $('#fade').list_ticker({
            speed: 3000,
            effect: 'fade'
        });
        $('#slide').list_ticker({
            speed: 3000,
            effect: 'slide'
        });
    });

    $('.hamyar_slider').hamyar_slider({
        show: 5,
        btnprev: '.icon-arrow-right',
        btnext: '.icon-arrow-left',
        speed: 500,
        disable_class: 'disable',
        auto: true,
        auto_time: 3500,
        slide: 2
    });
