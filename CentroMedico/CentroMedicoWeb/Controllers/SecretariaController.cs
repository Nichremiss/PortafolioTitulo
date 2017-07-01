using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedico.Mvc.SecretariaSvc;
using System.Web.Mvc;
using CentroMedico.Mvc.AgendaDiariaSvc;
using CentroMedico.Mvc.MedicoSvc;
using System.Web.Script.Serialization;

namespace CentroMedico.Mvc.Controllers
{
    public class SecretariaController : Controller
    {
    
        public ActionResult RegistroSecretaria()
        { 
            //SecretariaClient servicio = new SecretariaClient();
            //ViewBag.Lista = servicio.ObtenerSecretaria();

            return View();
        }


        [HttpPost]
        public bool Registro(string nombre, string rut, string apellidoPat, string apellidoMat, string mail, string pass)
        {
            SecretariaClient servicio = new SecretariaClient();

            SecretariaEnt sec = new SecretariaEnt();
            sec.secretaria_rut = rut;
            sec.secretaria_clave = pass;
            sec.secretaria_nombre = nombre;
            sec.secretaria_apellido_paterno = apellidoPat;
            sec.secretaria_apellido_materno = apellidoMat;
            sec.secretaria_email = mail;

            bool inserta = servicio.InsertarSecretaria(sec);

            return inserta;
        }

        public ActionResult LoginSecretariaView()
        {
            return View();
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


        public ActionResult RegistroMedico()
        {

            return View();
        }

        public ActionResult AnularModificarHoras()
        {

            return View();
        }

    
        public ActionResult MuestraHorasMedicasSecretaria()
        {

            return View();
        }


        [HttpPost]
        public String Calendario(string id_medico, string fecha_dia)
        {
            try
            {

                AgendaDiariaEnt ag = new AgendaDiariaEnt();
                List<AgendaDiariaEnt> resultado = new List<AgendaDiariaEnt>();
                //ag.AGENDA_DETALLE_MEDICO_ID = int.Parse(id_medico);
                ag.AGENDA_DETALLE_MEDICO_ID = id_medico;
                ag.AGENDA_DETALLE_DIA_ATENCION = fecha_dia;
                AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();
                //resultado = servicio.ObtenerCalendario(ag);
                string Datos = servicio.ObtenerCalendario(ag);

                //ViewBag.calendario = servicio.ObtenerCalendario(ag);


                
                return Datos;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public ActionResult ReservaHoras()
        {

            return View();
        }

        public ActionResult MenuSecretaria()
        {
            return View();
        }




    }
}
