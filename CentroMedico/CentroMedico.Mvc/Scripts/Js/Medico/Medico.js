
$(document).ready(function () {
       
    jQuery("#txtTextoOculto").hide();
    jQuery("#lblMensaje").hide();
     

});


function RegistraMedico() {
    //Crear Objeto Json 
    var param = {
        "rut": jQuery("#txtRutMedico").val(),
        "nombre": jQuery("#txtNombreM").val(),
        "apellidop": jQuery("#txtPaterno").val(),
        "apellidom": jQuery("#txtMaterno").val(),
        "clave": jQuery("#txtClaveMedico").val(),
        "clave": jQuery("#txtClaveMedico2").val(),
        "email": jQuery("#txtEmailMedico").val(),
        "especialidad": jQuery("#comboEspecialidad").val(),
        "sucursal": jQuery("#comboSucursal").val()


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

    
    function ajaxSecre(param) {

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
            url: './GuardarMedico',
            data: JSON.stringify(param),
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",

            beforeSend: function () {
                jQuery('#btnEnviar').attr("disabled", true)
            },


            success: function (returndata) {
                if (returndata)
                {
                    jQuery('#txtTextoOculto').hide('');
                    jQuery('#lblMensaje').show('Médico guardado con exito');
                    jQuery('#lblMensaje').html('Médico guardado con exito');
                   
                    limpiarCampos()
                    return;
                }
                else {
                    $('#lblMensaje').text("Error al Guardar Médico");
                    return;
                }

            },
            complete: function () {
                jQuery('#btnEnviar').attr("disabled", false)
            }
        });

    }

    var vRutLargo = $("#txtRutMedico").val().length;
    var vNombre = $("#txtNombreM").val();
    var vApaterno = $("#txtPaterno").val();
    var vAmaterno = $("#txtMaterno").val();
    var vEmail = $("#txtEmailMedico").val();
    var vClave = $("#txtClaveMedico").val();
    var vComboEspe = $("#comboEspecialidad").val();

    //validacion de rut
    if (vRutLargo == "")
    {
        jQuery('#txtTextoOculto').show('');
        jQuery('#txtTextoOculto').html('Rut no puede estar vacío');
      
    }
    else if (vRutLargo < 11 || vRutLargo >= 13)
    {
        jQuery('#txtTextoOculto').show('');
        jQuery('#txtTextoOculto').html('Ingrese un rut válido');
       
    }
    //validacion de nombre
    else if (vNombre == "")
    {
        jQuery('#txtTextoOculto').show('');
        jQuery('#txtTextoOculto').html('Nombre no puede estar vacío');
     
    }
    else if ($("#txtNombreM").val().length > 15 || $("#txtNombreM").val().length < 3)
    {
        jQuery('#txtTextoOculto').show('');
        jQuery('#txtTextoOculto').html('Ingrese un nombre válido');
       
    }
    //validacion de apellido paterno
    else if (vApaterno == "")
    {
        jQuery('#txtTextoOculto').html('Apellido paterno no puede estar vacío');
        jQuery('#txtTextoOculto').show('');
    
    }
    else if ($("#txtPaterno").val().length > 15 || $("#txtPaterno").val().length < 3)
    {
        jQuery('#txtTextoOculto').html('Ingrese un apellido paterno válido');
        jQuery('#txtTextoOculto').show('');
       
    }
    //validacion de apellido materno
    else if (vAmaterno == "")
    {
        jQuery('#txtTextoOculto').html('Apellido materno no puede estar vacío');
        jQuery('#txtTextoOculto').show('');
      
    }
    else if ($("#txtMaterno").val().length > 15 || $("#txtMaterno").val().length < 3)
    {
        jQuery('#txtTextoOculto').html('Ingrese un apellido materno válido');
        jQuery('#txtTextoOculto').show('');
      
    }
    //validacion de email 
    else if (vEmail == "")
    {
        jQuery('#txtTextoOculto').html('Email no puede estar vacío"');
        jQuery('#txtTextoOculto').show('');
      
    }
    else if ($("#txtEmailMedico").val().length > 45 || $("#txtEmailMedico").val().length < 5)
    {
        jQuery('#txtTextoOculto').html('Ingrese un email válido');
        jQuery('#txtTextoOculto').show('');
       
    }
    else if (!ValidarEmail($("#txtEmailMedico").val()))
    {
        jQuery('#txtTextoOculto').html('Ingrese un email valido, ejemplo: nombre@mail.com ');
        jQuery('#txtTextoOculto').show('');
       
    }
    //validacion de clave
    else if (vClave == "") {
        jQuery('#txtTextoOculto').html('Clave no puede estar vacío');
        jQuery('#txtTextoOculto').show('');
       
    }
    else if ($("#txtClaveMedico").val().length > 9 || $("#txtClaveMedico").val().length < 4) {
        jQuery('#txtTextoOculto').html('Ingrese una contraseña válida"');
        jQuery('#txtTextoOculto').show('');
      
    }
    else if ($("#txtClaveMedico").val() != $("#txtClaveMedico2").val()) {
        jQuery('#txtTextoOculto').html('Contraseñas no coinciden');
        jQuery('#txtTextoOculto').show('');
       
    }
    //validacion de especialidad
    else if ($('#comboEspecialidad').val().trim() === '')
    {
        jQuery('#txtTextoOculto').html('Debe elegir una opción en Epecialidad');
        jQuery('#txtTextoOculto').show('');
      
    }
    //validacion de sucursal
    else if ($('#comboSucursal').val().trim() === '')
    {
        jQuery('#txtTextoOculto').html('Debe elegir una opción en Sucursal');
        jQuery('#txtTextoOculto').show('');
       
    }
    else
    {
        jQuery('#txtTextoOculto').html('');
        jQuery('#txtTextoOculto').hide('');
        ajaxSecre(param);
        limpiarCampos();
    }
}


function ValidarEmail(vEmail) {
        var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        return expr.test(vEmail);
    };
    //$("#btnEnviar").live("click", function () {
    //    if (!ValidarEmail($("#txtEmailMedico").val())) {
    //        alert("Ingrese un email valido, ejemplo: nombre@mail.com ");
    //    }

    //});

    function soloLetras(e) {
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
        especiales = "8-37-39-46";

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

    function limpiarCampos() {
        $("#txtRutMedico").val("");
        $("#txtNombreM").val("");
        $("#txtPaterno").val("");
        $("#txtMaterno").val("");
        $("#txtEmailMedico").val("");
        $("#txtClaveMedico").val("");
        $("#txtClaveMedico2").val("");
    }

    function ValidarDuplicidadMedico() {

        //Creamos Objeto Json con valores tomados desde los input del html
        var param = {
            "rut": jQuery("#txtRutMedico").val(),
        };

        jQuery.ajax({
            type: "POST",
            url: './ValidarMedicoDuplicado',
            data: JSON.stringify(param),
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",
            success:
            function (returndata) {

                if (returndata == "True")
                {
                    jQuery('#txtTextoOculto').html('Rut ya esta registrado');
                    jQuery('#txtTextoOculto').show('');
                    jQuery('#txtNombreM').attr("disabled", true)
                    jQuery('#txtPaterno').attr("disabled", true)
                    jQuery('#txtMaterno').attr("disabled", true)
                    jQuery('#txtClaveMedico').attr("disabled", true)
                    jQuery('#txtClaveMedico2').attr("disabled", true)
                    jQuery('#txtEmailMedico').attr("disabled", true)
                    jQuery('#comboEspecialidad').attr("disabled", true)
                    jQuery('#comboSucursal').attr("disabled", true)
                    jQuery('#btnEnviar').attr("disabled", true)
                    limpiarCampos()
                    return;

                }
                else {
                    $('#txtTextoOculto').hide('');
                    jQuery('#txtNombreM').attr("disabled", false)
                    jQuery('#txtPaterno').attr("disabled", false)
                    jQuery('#txtMaterno').attr("disabled", false)
                    jQuery('#txtClaveMedico').attr("disabled", false)
                    jQuery('#txtClaveMedico2').attr("disabled", false)
                    jQuery('#txtEmailMedico').attr("disabled", false)
                    jQuery('#comboEspecialidad').attr("disabled", false)
                    jQuery('#comboSucursal').attr("disabled", false)
                    jQuery('#btnEnviar').attr("disabled", false)
                    return;
                }

            }
        });

    }