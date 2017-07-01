<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="CentroMedico.Vista.RegistroUsuario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Demo Settings -->
    <script src="assets/js/neon-demo.js"></script>
    <link rel="stylesheet" href="assets/js/jquery-ui/css/no-theme/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="assets/css/font-icons/entypo/css/entypo.css" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Noto+Sans:400,700,400italic" />
    <link rel="stylesheet" href="assets/css/bootstrap.css" />
    <link rel="stylesheet" href="assets/css/neon-core.css" />
    <link rel="stylesheet" href="assets/css/neon-theme.css" />
    <link rel="stylesheet" href="assets/css/neon-forms.css" />
    <link rel="stylesheet" href="assets/css/custom.css" />

    <script src="assets/js/jquery-1.11.0.min.js"></script>


    <div class="well well-sm">
        <h4>Registro de Usuarios</h4>
    </div>

    <form id="rootwizard-2" method="post" action="" class="form-wizard validate">

        <div class="steps-progress">
            <div class="progress-indicator"></div>
        </div>
        <ul class="nav nav-pills">
            <li class="active"><a href="#tab2-1" data-toggle="tab">Registro Cliente
            </a></li>
            <li><a href="#tab2-2" data-toggle="tab">Registro Médico
            </a></li>
        </ul>


        <div class="tab-content">
            <div class="tab-pane active" id="tab2-1">

                <div class="panel panel-primary">

                    <div class="panel-heading">
                        <div class="panel-title">Ingrese Datos Requeridos <small><code>*</code></small></div>
                    </div>

                    <div class="panel-body;">

                        <form role="form" id="form1" method="post" class="validate">


                            <div class="row">
                                <div class="col-md-12">

                                    <div class="form-group; col-md-4">
                                        <label class="control-label">Nombre</label>

                                        <input type="text" class="form-control" name="txtNombre" data-validate="required" data-message-required="This is custom message for required field." placeholder="Ingrese Nombre" />
                                    </div>


                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">


                                    <div class="form-group; col-md-4">
                                        <label class="control-label">Segundo Nombre</label>

                                        <input type="text" class="form-control" name="txtSegundoNombre" data-validate="maxlength[20]" placeholder="Maximum Length Field" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group; col-md-4">
                                        <label class="control-label">Apellido Materno</label>

                                        <input type="text" class="form-control" name="txtAmat" data-validate="required" placeholder="Numeric Field" />
                                    </div>


                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">

                                    <div class="form-group; col-md-4">
                                        <label class="control-label">Apellido Paterno</label>

                                        <input type="text" class="form-control" name="txtApat" data-validate="required" placeholder="Numeric Field" />
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">

                                    <div class="form-group; col-md-4">
                                        <label class="control-label">Rut</label>

                                        <input type="text" class="form-control" name="txtRut" data-validate="required" placeholder="Ingrese Rut" />
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">

                                    <div class="form-group; col-md-4">
                                        <label class="control-label">Edad</label>

                                        <input type="number" class="form-control" name="txtEdad" data-validate="number,minlength[2]" placeholder="Numeric + Minimun Length Field" />
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">

                                    <div class="form-group; col-md-4">
                                        <label class="control-label">Teléfono</label>

                                        <input type="text" class="form-control" name="txtTelefono" data-validate="number,minlength[9]" placeholder="Ingrese numero de contacto" />
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">

                                    <div class="form-group; col-md-4">
                                        <label class="control-label">Dirección</label>

                                        <input type="text" class="form-control" name="txtDireccion" data-validate="required" placeholder="ingrese direccion" />
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">


                                    <div class="form-group; col-md-4">
                                        <label class="control-label">URL Field</label>

                                        <input type="text" class="form-control" name="url" data-validate="required,url" placeholder="URL" />
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group col-md-4">
                                        <label class="control-label">Credit Card Field</label>

                                        <input type="text" class="form-control" name="creditcard" data-validate="required,creditcard" placeholder="Credit Card" />
                                    </div>


                                </div>
                            </div>


                            <div class="form-group">
                                <button type="submit" class="btn btn-success">Validate</button>
                                <button type="reset" class="btn">Reset</button>
                            </div>

                        </form>

                    </div>

                </div>

            </div>

            <div class="tab-pane" id="tab2-2">

                <div class="row">

                    <div class="col-md-8">
                        <div class="form-group">
                            <label class="control-label" for="street">Street</label>
                            <input class="form-control" name="street" id="street" data-validate="required" placeholder="Enter your street address" />
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label" for="door_no">Door no.</label>
                            <input class="form-control" name="door_no" id="door_no" data-validate="number" placeholder="Numbers only" />
                        </div>
                    </div>

                </div>

                <div class="row">

                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label" for="address_line_2">Address Line 2</label>
                            <input class="form-control" name="address_line_2" id="address_line_2" placeholder="(Optional) Secondary Address" />
                        </div>
                    </div>

                </div>

                <div class="row">

                    <div class="col-md-5">
                        <div class="form-group">
                            <label class="control-label" for="city">City</label>
                            <input class="form-control" name="city" id="city" data-validate="required" placeholder="Current city" />
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label" for="state">State</label>

                            <select name="test" class="selectboxit">
                                <optgroup label="United States">
                                    <option value="1">Alabama</option>
                                    <option value="2">Boston</option>
                                    <option value="3">Ohaio</option>
                                    <option value="4">New York</option>
                                    <option value="5">Washington</option>
                                </optgroup>
                            </select>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="form-group">
                            <label class="control-label" for="zip">Zip</label>
                            <input class="form-control" name="zip" id="zip" data-mask="** *** **" data-validate="required" placeholder="Zip Code" />
                        </div>
                    </div>

                </div>

            </div>

        </div>

    </form>
    <!-- Imported styles on this page -->
    <link rel="stylesheet" href="assets/js/selectboxit/jquery.selectBoxIt.css" />

    <!-- Bottom scripts (common) -->
    <script src="assets/js/gsap/main-gsap.js"></script>
    <script src="assets/js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js"></script>
    <script src="assets/js/bootstrap.js"></script>
    <script src="assets/js/joinable.js"></script>
    <script src="assets/js/resizeable.js"></script>
    <script src="assets/js/neon-api.js"></script>


    <!-- Imported scripts on this page -->
    <script src="assets/js/jquery.bootstrap.wizard.min.js"></script>
    <script src="assets/js/jquery.validate.min.js"></script>
    <script src="assets/js/jquery.inputmask.bundle.min.js"></script>
    <script src="assets/js/selectboxit/jquery.selectBoxIt.min.js"></script>
    <script src="assets/js/bootstrap-datepicker.js"></script>
    <script src="assets/js/bootstrap-switch.min.js"></script>
    <script src="assets/js/jquery.multi-select.js"></script>
    <script src="assets/js/neon-chat.js"></script>


    <!-- JavaScripts initializations and stuff -->
    <script src="assets/js/neon-custom.js"></script>

</asp:Content>
