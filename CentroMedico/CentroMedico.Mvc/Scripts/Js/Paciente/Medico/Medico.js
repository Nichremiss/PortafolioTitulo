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
        "especialidad": jQuery("#comboEspecialidad").val()

    };

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
                    $('#lblMensaje').text("Médico guardado con exito");
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

    //validacion de rut
    if (vRutLargo == "")
    {
        alert("Rut no puede estar vacío");
    }
    else if (vRutLargo < 11 || vRutLargo >= 13)
    {
        alert("Ingrese un rut válido");
    }
    //validacion de nombre
    else if (vNombre == "")
    {
        alert("Nombre no puede estar vacío");
    }
    else if ($("#txtNombreM").val().length > 15 || $("#txtNombreM").val().length < 3)
    {
        alert("Ingrese un nombre válido");
    }
    //validacion de apellido paterno
    else if (vApaterno == "")
    {
        alert("Apellido paterno no puede estar vacío");
    }
    else if ($("#txtPaterno").val().length > 15 || $("#txtPaterno").val().length < 3)
    {
        alert("Ingrese un apellido paterno válido");
    }
    //validacion de apellido materno
    else if (vAmaterno == "")
    {
        alert("Apellido materno no puede estar vacío");
    }
    else if ($("#txtMaterno").val().length > 15 || $("#txtMaterno").val().length < 3)
    {
        alert("Ingrese un apellido materno válido");
    }
    //validacion de email 
    else if (vEmail == "")
    {
        alert("Email no puede estar vacío");
    }
    else if ($("#txtEmailMedico").val().length > 20 || $("#txtEmailMedico").val().length < 5)
    {
        alert("Ingrese un email válido");
    }
    //validacion de clave
    else if (vClave == "")
    {
        alert("Contraseña no puede estar vacía");
    }
    else if ($("#txtClaveMedico").val().length > 9 || $("#txtClaveMedico").val().length < 4)
    {
        alert("Ingrese una contraseña válida");
    }
    else if ($("#txtClaveMedico2").val() != $("#txtClaveMedico").val())
    {
        alert("Contraseñas no coinciden");
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
    $("#btnEnviar").live("click", function () {
        if (!ValidarEmail($("#txtEmailMedico").val())) {
            alert("Ingrese un email valido, ejemplo: nombre@mail.com ");
        }

    });


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