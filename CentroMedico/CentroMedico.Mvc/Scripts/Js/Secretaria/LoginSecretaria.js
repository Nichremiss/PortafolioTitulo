function ValidarLogin() {

    //Creamos Objeto Json con valores tomados desde los input del html
    var param = {
        "rut": jQuery("#txtRut").val(),
        "pass": jQuery("#txtPass").val(),

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

    jQuery.ajax({
        type: "POST",
        url: './LoginSecretaria',
        data: JSON.stringify(param),
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        success:
        function (returndata) {

            if (returndata == "True") {
                window.location.replace("MenuSecretaria")

            }
            else {
                toastr.error('Credenciales no corresponden','Login secretaria', opts);
                return;
            }

        }
    });

}
