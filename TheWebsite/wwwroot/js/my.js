$(document).ready(function () {
    // Récupération de l'élément range et de l'élément textbox
    var range = $('#range');
    var textbox = $('#textbox');

    // Mise à jour de la valeur du textbox lorsqu'on bouge le range
    range.on('input', function () {
        var value = range.val();
        textbox.val(value);
    });
});