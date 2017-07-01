function GuardaAgendaGeneral() {
    //Crear Objeto Json 
    console.log("Entro a fechas")
    var param = {
        "inicioAgenda": jQuery("#txtFechaInicio").val(),
        "terminoAgenda": jQuery("#txtFechaTermino").val()
    }

    if (jQuery("#txtFechaInicio").val() == '' || jQuery("#txtFechaTermino").val() == '') {
        jQuery("#txtTextoOculto1").show();
        jQuery('#txtTextoOculto1').html('Debe ingresar Ambas fechas!');
        return;

    } else {
        jQuery.ajax({
            type: "POST",
            url: './ComparaFechas',
            data: JSON.stringify(param),
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",
            success: function (returndata) {

                if (returndata == "False") {
                    jQuery("#txtTextoOculto1").show();
                    jQuery('#txtTextoOculto1').html('Orden de fechas no corresponde!');
                    $('#lblMensaje').text("");
                }
                else {
                    jQuery('#btnAgendaGeneral').attr("disabled", false);
                    jQuery('#txtTextoOculto1').html('');
                    $('#lblMensaje').text("");
                    var param = {
                        "idMedico": jQuery("#combo").val(),
                        "inicioAgenda": jQuery("#txtFechaInicio").val(),
                        "terminoAgenda": jQuery("#txtFechaTermino").val(),

                    };

                    console.log(param)

                    var opts = {
                        "closeButton": true,
                        "debug": false,
                        "positionClass": "toast-top-right",
                        "onclick": null,
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                    };

                    jQuery.ajax({
                        type: "POST",
                        url: './GuardaAgenda',
                        data: JSON.stringify(param),
                        datatype: "JSON",
                        contentType: "application/json; charset=utf-8",
                        success: function (returndata) {

                            if (returndata) {
                            
                                jQuery("#txtTextoOculto1").hide();
                                 jQuery("#txtFechaInicio").val(''),
                                 jQuery("#txtFechaTermino").val('')
                                 $('#lblMensaje').text("Agenda guardada, ir al Paso 2");
                                 setTimeout(function () {
                                     location.reload();
                                 }, 1000);
                                return;
                                //toastr.success("Agenda Registrada con exito!.", "This is a title", opts);

                            }
                            else {
                                toastr.error('Error al ingresar Agenda', null, opts);
                                return;
                            }

                        }
                    });





                }

            }
        });
    }




}

function GuardaAgendaDiaria() {
    //Crear Objeto Json 
    var param = {
        "fechaDia": jQuery("#txtFechaDia").val(),
    }
    jQuery.ajax({
        url: 'validaAgendaDiaenRangoAgenda',
        type: "POST",
        data: JSON.stringify(param),
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
        },


        success: function (returndata) {
            console.log(returndata);
            if (returndata == "False") {
                jQuery("#lblMensajef3").show();
                jQuery("#lblMensajef3").html("Fecha Fuera de rango, verifique he intente nuevamente");
                return;
            } else {
                jQuery('#lblMensajef3').html('');
                var param = {
                    "fechaDia": jQuery("#txtFechaDia").val(),
                    "horaInicio": jQuery("#txtHoraInicio").val(),
                    "horaTermino": jQuery("#txtHoraTermino").val(),
                    "tiempoAtencion": jQuery("#txtSelectDuracion").val(),
                    "id_medico": jQuery("#combo2").val()

                };

                console.log(param)

                var opts = {
                    "closeButton": true,
                    "debug": false,
                    "positionClass": "toast-top-right",
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };

                jQuery.ajax({
                    type: "POST",
                    url: 'GuardaAgendaDiaria',
                    data: JSON.stringify(param),
                    datatype: "JSON",
                    contentType: "application/json; charset=utf-8",
                    success: function (returndata) {

                        if (returndata == "True") {
                            console.log(returndata);
                            jQuery("#id_alerta").hide();
                            jQuery("#lblMensajef3").hide();
                            jQuery("#lblMensaje2").show();
                            $('#lblMensaje2').html("Agenda Diaria Guardada con Exito");

                            jQuery("#txtFechaDia").val(''),
                            jQuery("#txtHoraInicio").val(''),
                            jQuery("#txtHoraTermino").val(''),
                            jQuery("#txtSelectDuracion").val(),
                            jQuery("#combo2").select('val', 0)
                            return;
                        }
                        else {
                            toastr.error('Error al ingresar Datos', "Agenda Diaria", opts);
                            return;
                        }

                    }
                });
            }
        }
    });
}

function ValidaDuplicidadAgenda() {
    console.log("entro a valida");
    var param = { "id_medico": jQuery("#combo").val(), }

    jQuery.ajax({
        type: "POST",
        url: './validaDuplicidadagendaGeneral',
        data: JSON.stringify(param),
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (returndata) {

            if (returndata == "False") {

                console.log(returndata)
                jQuery('#txtFechaInicio').attr("disabled", true);
                jQuery('#txtFechaTermino').attr("disabled", true);
                jQuery('#btnAgendaGeneral').attr("disabled", true);
                jQuery("#txtTextoOculto").show();
                jQuery('#txtTextoOculto').html('Ya existe Disponibilidad para este médico!');
                $('#lblMensaje').text("");
            }
            else {
                jQuery("#txtTextoOculto").hide();
                jQuery('#txtFechaInicio').attr("disabled", false);
                jQuery('#txtFechaTermino').attr("disabled", false);
                jQuery('#btnAgendaGeneral').attr("disabled", false);
                jQuery('#txtTextoOculto').html('');

                $('#lblMensaje').text("");
            }

        }
    });

}

function ComparaFechas() {



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