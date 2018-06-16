$ = require('jquery');
require('jquery-mask-plugin');

require('popper.js');
require('bootstrap');
require('bootstrap-datepicker');


// Utilizing bootstrap-datepicker
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
