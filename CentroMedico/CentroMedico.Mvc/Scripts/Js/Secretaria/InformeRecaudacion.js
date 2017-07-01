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

function MostrarInformeGeneral() {

    var param = {
        //"id_medico": jQuery("#combo").val(),
        fecha_inicio: jQuery('#txtFechaInicio').val(),
        fecha_fin: jQuery('#txtFechaTermino').val()
    };

    jQuery.ajax({
        url: 'InformeGeneral',
        type: "POST",
        data: JSON.stringify(param),
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            jQuery('#contenedorReporteGeneral').slideUp();
        },
        success: function (returndata) {
            console.log(returndata)
            jQuery('#contenedorReporteGeneral').html(returndata.tabla);
            jQuery("#TablaReporteGeneral").dataTable({
                "aaSorting": [[3, "asc"]]
            });
            jQuery('#txtTextoOculto').html('');
            jQuery('#contenedorReporteGeneral').slideDown();
        }
    });
}

function MostrarIPorMedico() {

    var param = {
        id_medico: jQuery("#combo").val(),
        fecha_inicio: jQuery('#txtFechaInicioG').val(),
        fecha_fin: jQuery('#txtFechaTerminoG').val()
    };

    jQuery.ajax({
        url: 'InformePorMedico',
        type: "POST",
        data: JSON.stringify(param),
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            jQuery('#contenedorReportePorMedico').slideUp();
        },
        success: function (returndata) {
            console.log(returndata)
            jQuery('#contenedorReportePorMedico').html(returndata.tabla);
            jQuery("#TablaReportePorMedico").dataTable({
                "aaSorting": [[3, "asc"]]
            });
            jQuery('#txtTextoOculto').html('');
            jQuery('#contenedorReportePorMedico').slideDown();
        }
    });
}
