function ValidarLoginMedico() {

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
        url: './LoginMedico',
        data: JSON.stringify(param),
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        success:
        function (returndata) {


            if (returndata == "True") {
                window.location.replace("MenuMedico")

            }
            else {
                toastr.error('Credenciales no corresponden', 'Login Médico', opts);
                return;
            }

        }
    });

}