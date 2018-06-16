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
