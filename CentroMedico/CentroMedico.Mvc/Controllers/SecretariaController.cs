using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedico.Mvc.SecretariaSvc;
using CentroMedico.Mvc.CajeroSvc;
using System.Web.Mvc;
using CentroMedico.Mvc.AgendaDiariaSvc;
using CentroMedico.Mvc.PrevisionSvc;
using CentroMedico.Mvc.SucursalesSvc;
using CentroMedico.Mvc.MedicoSvc;
using CentroMedico.Mvc.EspecialidadSvc;
using System.Web.Script.Serialization;
using CentroMedico.Mvc.ReservaSvc;
using CentroMedico.Mvc.AgendaSvc;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Net.Mail;
using CentroMedico.Mvc.Models;

namespace CentroMedico.Mvc.Controllers
{
    public class SecretariaController : Controller
    {
        #region Métodos ActionResult
        public ActionResult Comisiones()
        {
            return View();
        }
        public ActionResult InformeRecaudacion()
        {
            MedicoClient med = new MedicoClient();
            string jsonMedicos = med.ObtenerMedico();
            JavaScriptSerializer jsMed = new JavaScriptSerializer();
            List<Datos.MedicoEnt> listaMed = jsMed.Deserialize<List<Datos.MedicoEnt>>(jsonMedicos);
            ViewBag.listaMedicos = listaMed;
            return View();
        }

        //Metodo que guarda un archivo pdf
        [HttpPost]
        public ActionResult InformeRecaudacion(HttpPostedFileBase file)
        {
            SubirArchivo modelo = new SubirArchivo();
            if (file != null)
            {
                string archivo = Server.MapPath("~/Uploads/");
                archivo += file.FileName;
                modelo.ConfirmacionHora(archivo, file);
                ViewBag.Error = modelo.error;
                ViewBag.Correcto = modelo.Confirmacion;
            }
            return View();
        }
        public ActionResult ConfirmacionHora()
        {
            return View();
        }
        public ActionResult RegistroSecretaria()
        { 
            //SecretariaClient servicio = new SecretariaClient();
            //ViewBag.Lista = servicio.ObtenerSecretaria();

            return View();
        }
        public ActionResult MostrarReservas()
        {
            ReservaClient res = new ReservaClient();

            ViewBag.ListaHorasReservadas = res.MuestraListaTodasLasReservasRealizadas();
            ViewBag.ListaPacientesEnEspera = res.ListaTodosLosPacientesEnEspera();


            return View();
        }
        public ActionResult MuestraHorasMedicasSecretaria()
        {
            //metodo que va al combobox 
            //MedicoClient med = new MedicoClient();
            //string jsonMedicos = med.ObtenerMedico();
            //JavaScriptSerializer jsMed = new JavaScriptSerializer();
            //List<Datos.MedicoEnt> listaMed = jsMed.Deserialize<List<Datos.MedicoEnt>>(jsonMedicos);
            //ViewBag.listaMedicos = listaMed;
            //return View(ViewBag);

            MedicoClient med = new MedicoClient();
            string jsonMedicosAgenfa = med.ObtenerMedicosAgenda();
            JavaScriptSerializer jsagenda = new JavaScriptSerializer();
            List<Datos.MedicoEnt> listaMedAge = jsagenda.Deserialize<List<Datos.MedicoEnt>>(jsonMedicosAgenfa);
            ViewBag.listaMedicosAgenda = listaMedAge;
            return View(ViewBag);
        }
        public ActionResult ReservaHoras()
        {

            EspecialidadClient espe = new EspecialidadClient();
            string jsonEspecialidad = espe.ObtenerEspecialidad();
            JavaScriptSerializer jsEspe = new JavaScriptSerializer();
            List<Datos.EspecialidadEnt> listaEspe = jsEspe.Deserialize<List<Datos.EspecialidadEnt>>(jsonEspecialidad);
            ViewBag.listaEspecialidad = listaEspe;
            return View(ViewBag);
        }
        #endregion

        #region Métodos HttpPost
        [HttpPost]
        public bool EditarAgendaDiaria( string EDhoraInicio, string EDhoraTermino, string EDtiempoAtencion, string cadena)
        {
            AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();
         CentroMedico.Datos.AgendaDiariaEnt ageEnt = new CentroMedico.Datos.AgendaDiariaEnt();
            var fecha = cadena.Substring(4, 8);
            var c_med = cadena.Substring(0, 3);
            ageEnt.AGENDA_DETALLE_DIA_ATENCION = fecha;
            ageEnt.AGENDA_DETALLE_MEDICO_ID = c_med;
            bool inserta = servicio.EditarAgendaDiaria(ageEnt, EDhoraInicio, EDhoraTermino, EDtiempoAtencion);
            return inserta;
        }
        public bool comparaFechas(string fecha_inicio, string fecha_fin)
        {


            DateTime ini = DateTime.Parse(fecha_inicio);
            DateTime term = DateTime.Parse(fecha_fin);
            if (ini < term)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public bool Registro(string nombre, string rut, string apellidoPat, string apellidoMat, string mail, string pass)
        {
            SecretariaClient servicio = new SecretariaClient();

            SecretariaEnt sec = new SecretariaEnt();
            sec.secretaria_rut = rut;
            sec.secretaria_clave = Encriptar(pass);
            sec.secretaria_nombre = nombre;
            sec.secretaria_apellido_paterno = apellidoPat;
            sec.secretaria_apellido_materno = apellidoMat;
            sec.secretaria_email = mail;

            bool inserta = servicio.InsertarSecretaria(sec);

            return inserta;
        }
        [HttpPost]
        public bool ValidarSecretariaDuplicada(string rut)
        {
            SecretariaClient servicio = new SecretariaClient();
            SecretariaEnt sec = new SecretariaEnt();
            sec.secretaria_rut = rut;
            bool valida = servicio.ValidaDuplicidadSecretaria(sec);
            return valida;
        }    
        [HttpPost]
        public bool LoginSecretaria(string rut, string pass)
        {
            SecretariaClient servicio = new SecretariaClient();

            SecretariaEnt sec = new SecretariaEnt();
            sec.secretaria_rut = rut;
            sec.secretaria_clave = pass;
            bool valida = servicio.ValidarLoginSecretaria(sec);

            return valida;
        }
        [HttpPost]
        public bool CambiarEstadoEspera(string reserva_id)
        {
            ReservaClient servicio = new ReservaClient();
            Datos.ReservaEnt rev = new Datos.ReservaEnt();
            rev.reserva_id = reserva_id;

            bool cambia = servicio.CambiarEstadoPacienteEspera(rev);
            return cambia;
        }
        [HttpPost]
        public ActionResult Calendario(string id_medico)
        {
            try
            {
             CentroMedico.Datos.AgendaDiariaEnt ag = new CentroMedico.Datos.AgendaDiariaEnt();
                ag.AGENDA_DETALLE_MEDICO_ID = id_medico;
                AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();
                return Json(new { tabla = servicio.ObtenerCalendario(ag)});
            }
            catch (Exception ex)
            {

                throw;
            }

        }
         [HttpPost]
        public ActionResult MuestraMail()
        {
            return Json(new {mail = Session["CorreoUsuario"].ToString() });
        }

    
        [HttpPost]
        public ActionResult MuestraHorasxdia(string cadena)
        {

            try
            {
                var fecha = cadena.Substring(4, 8);
                var c_med = cadena.Substring(0, 3);
                AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();
                return Json(new { tabla = servicio.MuestraHorasxdia(c_med, fecha) });
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult MuestraHorasReservaDiaria(string cadena)
        {
           
            try
            {
                var fecha = cadena.Substring(4,8);
                var c_med = cadena.Substring(0, 3);
                AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();
                return Json(new { tabla = servicio.MuestraHorasDisponibles(c_med, fecha) });
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult MuestraHorasReservaGeneral(string c_esp)
        {
            try
            {
                AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();
                return Json(new { tabla = servicio.MuestraHorasDisponiblesGeneral(c_esp) });
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult MostrarConfirmacionReserva(string num_Agenda_detalle_id)
        {
            try
            { 
                ReservaClient reg = new ReservaClient();
                CentroMedico.Datos.ReservaEnt res = new Datos.ReservaEnt();
               CentroMedico.Datos.ReservaEnt reserva = reg.MuestraDatoReserva(num_Agenda_detalle_id);
                return Json(new {
                    rut = Session["Usuario"].ToString(),
                    nombre = Session["NombreUsuario"].ToString(),
                    prevision= Session["Prevision"].ToString(),
                    reserva
                });
            }
            catch (Exception)
            {

                return null;
            }
          
        }

        [HttpPost]
        public bool InsertarReserva(string especialidad, string prevision, string medico, string sucursal,
            string fecha, string hora, string pacienteRut, string pacienteNombre, string detalle_agenda)
        {
            ReservaClient servicio = new ReservaClient();
            Datos.ReservaEnt rev = new Datos.ReservaEnt();

            rev.reserva_especialidad = especialidad;
            rev.reserva_prevision = prevision;
            rev.reserva_medico = medico;
            rev.reserva_sucursal = sucursal;
            rev.reserva_fecha = fecha;
            rev.reserva_hora = hora;
            rev.reserva_paciente_rut = pacienteRut;
            rev.reserva_paciente_nombre = pacienteNombre;
            rev.reserva_agenda_detalle = detalle_agenda;

            string Texto = string.Format(" Le informamos que se ha realizado una reserva de hora para {0}, con fecha del {1} a las {2} Hrs. con el Doctor: {3}. \n La hora fue tomada en la sucursal hubicada en :  {4}. \n \n recomendamos pueda llegar al lugar 15 minutos antes de la hora indicada, esto para evitar restrasos en su atención.", especialidad, fecha, hora, medico, sucursal);

            Clases.CORREO.EnviarCorreo(Session["CorreoUsuario"].ToString(), "Confirmación reserva médica", Clases.CORREO.PlantillaCorreo(Session["NombreUsuario"].ToString(), "Confirmación de reserva médica", Texto, "Atentamente : Centro Médico Galenos"), "centro.med.galenos@gmail.com");
            
            bool inserta = servicio.InsertarReserva(rev);
            return inserta;
        }
        [HttpPost]
        private static string Encriptar(string _cadena)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadena);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        #endregion

        [HttpPost]
       // public ActionResult InformeGeneral(string cadena)
        public ActionResult InformeGeneral(string fecha_inicio, string fecha_fin)
        {

            try
            {
                CajeroClient cajero = new CajeroClient();        
                return Json(new { tabla = cajero.RecaudacionGeneral(fecha_inicio, fecha_fin) });
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult MontoRecaudacionGral(string fecha_inicio, string fecha_fin)
        {
            try
            {
                CajeroClient cajero = new CajeroClient();
                return Json(new { mensaje = cajero.MuestraCalculoGral(fecha_inicio, fecha_fin) });
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult MuestraDatosModalComision(string fecha_inicio, string fecha_fin, string id_medico)
        {
            try
            {
                CajeroClient servicio = new CajeroClient();
                CentroMedico.Datos.CajeroEnt c = new Datos.CajeroEnt();
                c= servicio.MuestraDatoReporte(fecha_inicio, fecha_fin, id_medico);
                string mensaje = string.Format("El doctor : {0}. \n contando desde el dia {1}, hasta {2}, tiene recaudado un total de {3} \n, Considerando que se encuentra estipulado una comision del 20% del total, este debera realizar un pago por {4}, ",c.nombre,fecha_inicio, fecha_fin, c.recaudado,c.comision);

                return Json(new { mensajeFina = mensaje });
            }
            catch (Exception)
            {

                return null;
            }

        }


    }
}
