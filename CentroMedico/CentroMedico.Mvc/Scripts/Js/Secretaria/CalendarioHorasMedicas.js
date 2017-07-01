
function EditarAgendaDiaria() {
   

}


function justNumbers(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 0) {
        return true;
    }

    // Patron de entrada, no acepta letras ni numeros
    patron = /[/-/]/;
    tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);

}

function llamarCalendario() {

    var param = {
        "id_medico": jQuery("#combo").val(),
        "fecha_dia": jQuery("#txtCalen_fecha").val()
    };

    jQuery.ajax({
        url: 'Calendario',
        type: "POST",
        data: JSON.stringify(param),
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            jQuery('#contenedorDisponibilidadDiaria').slideUp();
        },
        success: function (returndata) {
            console.log(returndata)
            jQuery('#contenedorDisponibilidadDiaria').html(returndata.tabla);
            jQuery("#TablaDisponibilidadDiaria").dataTable({
                "aaSorting": [[3, "asc"]]
            });
            jQuery('#txtTextoOculto').html('');
            jQuery('#contenedorDisponibilidadDiaria').slideDown();
        }
    });
}

