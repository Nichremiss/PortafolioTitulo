function RegistraPaciente() {
    //Crear Objeto Json 
    var param = {
        "prut": jQuery("#txtRutPaciente").val(),
        "pnombre": jQuery("#txtNombreP").val(),
        "papellido": jQuery("#txtPaternoP").val(),
        "papellidomat": jQuery("#txtMaternoP").val(),
        "pfecha_nac": jQuery("#txtFechaNacP").val(),
        "ptelefono": jQuery("#txtTelefonoP").val(),
        "prevision": jQuery("#combo3").val(),
        "pclave": jQuery("#txtClaveP").val(),
        "pclave": jQuery("#txtClaveP2").val(),
        "pemail": jQuery("#txtEmailP").val(),
        "pdireccion": jQuery("#txtDireccionP").val()
    };

    console.log(param)

    function ajaxSecre(param) {

        jQuery.ajax({
            type: "POST",
            url: './GuardarPaciente',
            data: JSON.stringify(param),
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                jQuery('#btnEnviar').attr("disabled", true)
            },
            success: function (returndata) {
                if (returndata)
                {
                    //$('#lblMensaje').text("Paciente guardado con exito");
                    jQuery("#txtTextoOculto2").show();
                    jQuery('#txtTextoOculto').hide('');
                    jQuery('#txtTextoOculto2').html('Paciente Registrado con Exito');
                    limpiarCampos()
                    return;
                    
                }
                else {
                    $('#lblMensaje').text("Error al Guardar Paciente");
                    return;
                }
            },
            complete: function () {
                jQuery('#btnEnviar').attr("disabled", false)
                }

        });
    }


    var vRutLargo = $("#txtRutPaciente").val().length;
    var vNombre = $("#txtNombreP").val();
    var vApaterno = $("#txtPaternoP").val();
    var vAmaterno = $("#txtMaternoP").val();
    var vDireccion = $("#txtDireccionP").val();
    var vFecha = $("#txtFechaNacP").val();
    var vTelefono = $("#txtTelefonoP").val();
    var vEmail = $("#txtEmailP").val();
    var vPrevision = $("#combo3").val();
    var vClave = $("#txtClaveP").val();
    var vClave2 = $("#txtClaveP2").val();

    //validación de rut
    if (vRutLargo == "")
    {
       
        jQuery("#txtTextoOculto").show();
        jQuery('#txtTextoOculto').html('Rut no puede estar vacío');
    }
    else if (vRutLargo < 11 || vRutLargo >= 13)
    {
      
        jQuery('#txtTextoOculto').html('Ingrese un rut valido');
        jQuery('#txtTextoOculto').show('');
    }
    //validacion de nombre
    else if (vNombre == "" )
    {
        jQuery('#txtTextoOculto').html('El nombre no puede estar vacío');
        jQuery('#txtTextoOculto').show('');
       
    }
    
    else if ($("#txtNombreP").val().length > 15 || $("#txtNombreP").val().length < 3)
    {
        jQuery('#txtTextoOculto').html('Ingrese un nombre válido');
        jQuery('#txtTextoOculto').show('');
       
    }
    //validacion de apellido paterno
    else if (vApaterno == "")
    {
        jQuery('#txtTextoOculto').html('Apellido Paterno no puede estar vacío');
        jQuery('#txtTextoOculto').show('');
      
    }

    else if ($("#txtPaternoP").val().length > 15 || $("#txtPaternoP").val().length < 3)
    {

        jQuery('#txtTextoOculto').html('Ingrese un Apellido paterno válido');
        jQuery('#txtTextoOculto').show('');
       
    }
    //validacion de apellido materno
    else if (vAmaterno == "")
    {
        jQuery('#txtTextoOculto').html('Apellido materno no puede estar vacío');
        jQuery('#txtTextoOculto').show('');
       
    }
    else if ($("#txtMaternoP").val().length > 15 || $("#txtMaternoP").val().length < 3)
    {
        jQuery('#txtTextoOculto').html('Ingrese un apellido materno válido');
        jQuery('#txtTextoOculto').show('');
       
    }
    //validacion de fecha
    else if (vFecha == "")
    {
        jQuery('#txtTextoOculto').html('Fecha no puede estar vacía');
        jQuery('#txtTextoOculto').show('');
       
    }
    //validacion de telefono
    else if ($("#txtTelefonoP").val().length != 9)
    {
        jQuery('#txtTextoOculto').html('Ingrese un numero telefónico válido');
        jQuery('#txtTextoOculto').show('');
       
    }
    //validacion de email
    else if ($("#txtEmailP").val() == "")
    {
       
        jQuery('#txtTextoOculto').html('Email no puede estar vacío');
        jQuery('#txtTextoOculto').show('');
    }
    else if ($("#txtEmailP").val().length > 45 || $("#txtEmailP").val().length < 5) {
        
        jQuery('#txtTextoOculto').html('Ingrese un Email válido');
        jQuery('#txtTextoOculto').show('');
    }
    else if (!ValidarEmail($("#txtEmailP").val())) {
       
        jQuery('#txtTextoOculto').html('Ingrese un email valido, ejemplo: nombre@mail.com ');
        jQuery('#txtTextoOculto').show('');
    }
    //validacion de direccion
    else if ($("#txtDireccionP").val() == "")
    {
       
        jQuery('#txtTextoOculto').html('Direccion no puede estar vacía');
        jQuery('#txtTextoOculto').show('');
    }
    else if ($("#txtDireccionP").val().length > 40 || $("#txtDireccionP").val().length < 6)
    {
       
        jQuery('#txtTextoOculto').html('Ingrese una direccion válida');
        jQuery('#txtTextoOculto').show('');
    }
        //validacion de sucursal
    else if ($('#combo3').val().trim() === '')
    {
       
        jQuery('#txtTextoOculto').html('Debe elegir una opción en Prevision');
        jQuery('#txtTextoOculto').show('');
    }
    //validacion de clave
    else if (vClave == "")
    {
       
        jQuery('#txtTextoOculto').html('Clave no puede estar vacía');
        jQuery('#txtTextoOculto').show('');

    }
    else if ($("#txtClaveP").val().length > 9 || $("#txtClaveP").val().length < 4)
    {
      
        jQuery('#txtTextoOculto').html('Ingrese una clave válida');
        jQuery('#txtTextoOculto').show('');
    }

    else if ($("#txtClaveP2").val() != $("#txtClaveP").val())
    {
      
        jQuery('#txtTextoOculto').html('Contraseñas no coinciden');
        jQuery('#txtTextoOculto').show('');
    }
    else
    {
        ajaxSecre(param);
        limpiarCampos();
    }

}

    function ValidarEmail(vEmail) {
        var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        return expr.test(vEmail);
    };
    //$("#btnEnviar").live("click", function () {
    //    if (!ValidarEmail($("#txtEmailP").val())) {
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

        $("#txtRutPaciente").val("");
        $("#txtNombreP").val("");
        $("#txtPaternoP").val("");
        $("#txtMaternoP").val("");
        $("#txtFechaNacP").val("");
        $("#txtTelefonoP").val("");
        $("#txtEmailP").val("");
        $("#txtDireccionP").val("");
        $("#combo3").val("");
        $("#txtClaveP").val("");
        $("#txtClaveP2").val("");
    }

    //funcion que no permite que se escriba en el input de fecha
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

    function ValidarDuplicidadPaciente() {

        //Creamos Objeto Json con valores tomados desde los input del html
        var param = {
            "rut": jQuery("#txtRutPaciente").val(),
        };

        jQuery.ajax({
            type: "POST",
            url: './ValidarPacienteDuplicado',
            data: JSON.stringify(param),
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",
            success:
            function (returndata) {

                if (returndata == "True")
                {
                    jQuery("#txtTextoOculto").show();
                    jQuery('#txtTextoOculto').html('Este Rut ya esta registrado');
                    //$('#lblMensajeok').text("Este rut ya esta registrado");
                    jQuery('#txtNombreP').attr("disabled", true)
                    jQuery('#txtPaternoP').attr("disabled", true)
                    jQuery('#txtMaternoP').attr("disabled", true)
                    jQuery('#txtFechaNacP').attr("disabled", true)
                    jQuery('#txtTelefonoP').attr("disabled", true)
                    jQuery('#txtEmailP').attr("disabled", true)
                    jQuery('#txtDireccionP').attr("disabled", true) 
                    jQuery('#combo3').attr("disabled", true)
                    jQuery('#txtClaveP').attr("disabled", true)
                    jQuery('#txtClaveP2').attr("disabled", true)
                    jQuery('#btnEnviar').attr("disabled", true)
                    limpiarCampos()
                    return;

                }
                else 
                {
                    jQuery("#txtTextoOculto").hide();
                    //$('#lblMensajeok').text("");
                    jQuery('#txtNombreP').attr("disabled", false)
                    jQuery('#txtPaternoP').attr("disabled", false)
                    jQuery('#txtMaternoP').attr("disabled", false)
                    jQuery('#txtFechaNacP').attr("disabled", false)
                    jQuery('#txtTelefonoP').attr("disabled", false)
                    jQuery('#combo3').attr("disabled", false)
                    jQuery('#txtClaveP').attr("disabled", false)
                    jQuery('#txtClaveP2').attr("disabled", false)
                    jQuery('#txtEmailP').attr("disabled", false)
                    jQuery('#txtDireccionP').attr("disabled", false)
                    jQuery('#btnEnviar').attr("disabled", false)
                    return;
                }

            }
        });

    }

