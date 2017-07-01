function RegistraSecretaria() {

    //Creamos Objeto Json con valores tomados desde los input del html
    var param = {
        "nombre": jQuery("#txtNombre").val(),
        "rut": jQuery("#txtRut").val(),
        "apellidoPat": jQuery("#txtApellidoP").val(),
        "apellidoMat": jQuery("#txtApellidoM").val(),
        "mail": jQuery("#txtEmail").val(),
        "pass": jQuery("#txtPass").val(),
        "pass": jQuery("#txtReingresoPass").val()
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
            url: './Registro',
            data: JSON.stringify(param),
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                jQuery('#btnEnviar').attr("disabled", true)
            },
            success: function (returndata) {
                if (returndata)
                {
                    jQuery("#txtTextoOculto2").show();
                    jQuery('#txtTextoOculto2').html('Secretaria Registrada con Exito');
                    limpiarCampos()
                    return;
                }
                else {
                    $('#lblMensaje').text("Error al Guardar Secretaria");
                    return;
                }

            },
            complete: function () {
                jQuery('#btnEnviar').attr("disabled", false)
            }
        });
    }
 
    var vRutLargo = $("#txtRut").val().length;
    var vNombre = $("#txtNombre").val();
    var vApaterno = $("#txtApellidoP").val();
    var vAmaterno = $("#txtApellidoM").val();
    var vEmail = $("#txtEmail").val();
    var vClave = $("#txtPass").val();

    //validacion de rut
    if (vRutLargo == "") 
    {
        alert("Rut no puede estar vacío");
    }
    else if (vRutLargo < 11 || vRutLargo >= 13) {
        alert("Ingrese un rut válido");
    }
    //validacion de nombre
    else if (vNombre == "")
    {
        alert("Nombre no puede estar vacío");
    }
    else if ($("#txtNombre").val().length > 15 || $("#txtNombre").val().length < 3)
    {
        alert("Ingrese un nombre válido");
    }
    //validacion de apellido paterno
    else if (vApaterno == "")
    {
        alert("Apellido Paterno no puede estar vacío");
    }
    else if ($("#txtApellidoP").val().length > 15 || $("#txtApellidoP").val().length < 3)
    {
        alert("Ingrese un apellido paterno válido");
    }
    //validacion de apellido materno
    else if (vAmaterno == "")
    {
        alert("Apellido Materno no puede estar vacío");
    }
    else if ($("#txtApellidoM").val().length > 15 || $("#txtApellidoM").val().length < 3)
    {
        alert("Ingrese un Apellido Materno válido");
    }
    //validacion de email
    else if (vEmail == "")
    {
        alert("Email no puede estar vacío");
    }
    else if ($("#txtEmail").val().length > 45 || $("#txtEmail").val().length < 5)
    {
        alert("Ingrese un email válido");
    }
    else if (!ValidarEmail($("#txtEmail").val())) 
    {
        alert("Ingrese un email valido, ejemplo: nombre@mail.com ");
    }
    //validacion de clave
    else if (vClave == "")
    {
        alert("Clave no puede estar vacío");
    }
    else if ($("#txtPass").val().length > 9 || $("#txtPass").val().length < 4)
    {
        alert("Ingrese una contraseña válida");
    }
    else if ($("#txtPass").val() != $("#txtReingresoPass").val())
    {
        alert("Contraseñas no coinciden");
    }
    else 
    {
        ajaxSecre(param);
        limpiarCampos();
    }

}

//Validar formato de Correo
function ValidarEmail(vEmail) {
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return expr.test(vEmail);
};

//$("#btnEnviar").live("click", function ()
//{
//    if (!ValidarEmail($("#txtEmail").val())) 
//    {
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

//var emailval = $("#txtEmail").val();

//function validarEmail(emailval) {
//    if (/^\w+([\.\-\_]?\w+)*@\w+([\.-]?\w+)*(\.\D{2,4})+$/.test(emailval)) {

//        alert("La dirección de email " + emailval + " es correcta.");
//    } else {
//        alert("La dirección de email es incorrecta.");
//    }
//}


function limpiarCampos() {

    $("#txtRut").val("");
    $("#txtNombre").val("");
    $("#txtApellidoP").val("");
    $("#txtApellidoM").val("");
    $("#txtEmail").val("");
    $("#txtPass").val("");
    $("#txtReingresoPass").val("");
}

function ValidarDuplicidadSecretaria() {

    //Creamos Objeto Json con valores tomados desde los input del html
    var param = {
        "rut": jQuery("#txtRut").val(),
    };

    jQuery.ajax({
        type: "POST",
        url: './ValidarSecretariaDuplicada',
        data: JSON.stringify(param),
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        success:
        function (returndata) {

            if (returndata == "True") {
                jQuery("#txtTextoOculto").show();
                jQuery('#txtTextoOculto').html('Este Rut ya esta registrado');
                jQuery('#txtNombre').attr("disabled", true)
                jQuery('#txtApellidoP').attr("disabled", true)
                jQuery('#txtApellidoM').attr("disabled", true)
                jQuery('#txtEmail').attr("disabled", true)
                jQuery('#txtPass').attr("disabled", true)
                jQuery('#txtReingresoPass').attr("disabled", true)
                jQuery('#btnEnviar').attr("disabled", true)
                limpiarCampos()
                return;

            }
            else {
                jQuery("#txtTextoOculto").hide();
                jQuery('#txtNombre').attr("disabled", false)
                jQuery('#txtApellidoP').attr("disabled", false)
                jQuery('#txtApellidoM').attr("disabled", false)
                jQuery('#txtEmail').attr("disabled", false)
                jQuery('#txtPass').attr("disabled", false)
                jQuery('#txtReingresoPass').attr("disabled", false)
                jQuery('#btnEnviar').attr("disabled", false)
                return;
            }

        }
    });

}
