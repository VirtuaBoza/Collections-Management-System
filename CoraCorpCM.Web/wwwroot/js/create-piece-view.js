﻿$(document).ready(function () {

    var toggles = ['medium-toggle', 'genre-toggle', 'subgenre-toggle', 'subjectMatter-toggle', 'artist-toggle', 'acquisition-toggle', 'fundingSouce-toggle', 'pieceSource-toggle', 'permanentLocation-toggle', 'currentLocation-toggle', 'collection-toggle'];

    toggles.forEach(function (toggleName) {
        var toggle = $('#' + toggleName);
        var toggleTarget = $('.' + toggleName + '-target');
        if (toggle.val() == "") {
            toggleTarget.hide();
        }
        toggle.change(function () {
            if (toggle.val() == -1) {
                toggleTarget.slideDown();
                var toggleWithin = toggleTarget.find('.toggle')
                if (toggleWithin !== 'undefined') {
                    toggleWithin.val(-1);
                }
            } else {
                toggleTarget.slideUp();
            }
        });
    });

    // Utilizing bootstrap-datepicker
    $('input.date-picker').datepicker({
        format: "m/d/yyyy",
        clearBtn: true,
        autoclose: true
    });

    $('input.year-picker').datepicker({
        format: "yyyy",
        minViewMode: 2,
        clearBtn: true,
        autoclose: true
    });

    $('input.month-picker').datepicker({
        format: "m",
        minViewMode: 1,
        maxViewMode: 1,
        clearBtn: true,
        autoclose: true
    });

    // Utilizing jquery-mask-plugin
    $('.year-mask').mask('0000');
    $('.month-mask').mask('00');
    $('.day-mask').mask('00');
    $('.money-mask').mask("#,##0.00", { reverse: true });
});
