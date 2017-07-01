using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroMedico.Mvc.AgendaSvc;
using CentroMedico.Mvc.AgendaDiariaSvc;
using CentroMedico.Mvc.MedicoSvc;
using CentroMedico.Mvc.EspecialidadesSvc;
using System.Web.Script.Serialization;

namespace CentroMedico.Mvc.Controllers
{
    public class MedicoController : Controller
    {
        public ActionResult RegistroMedico()
        {
            //metodo que va al combobox
            EspecialidadClient espe = new EspecialidadClient();
            string jsonEspecialidad = espe.ObtenerEspecialidad();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<EspecialidadClient> listaEspe = js.Deserialize<List<EspecialidadClient>>(jsonEspecialidad);
            ViewBag.listaEspecialidad = listaEspe;
            return View(ViewBag);
        }

        [HttpPost]
        public bool GuardarMedico(string rut, string nombre, string apellidop, 
            string apellidom, string clave, string email, string especialidad)
        {
            MedicoClient servicio = new MedicoClient();
            MedicoEnt med = new MedicoEnt();
            med.medico_rut = rut;
            med.medico_nombre = nombre;
            med.medico_apellido_paterno = apellidop;
            med.medico_apellido_materno = apellidom;
            med.medico_clave = clave;
            med.medico_email = email;
            med.medico_especialidad = especialidad;
            bool inserta = servicio.InsertarMedico(med);
            return inserta;
        }

        public ActionResult LoginMedicoView()
        {
            return View();
        }

        [HttpPost]
        public bool LoginMedico(string rut, string pass)
        {
            MedicoClient servicio = new MedicoClient();

            MedicoEnt med = new MedicoEnt();
            med.medico_rut = rut;
            med.medico_clave = pass;
            bool valida = servicio.ValidarLoginMedico(med);
            return valida;
        }

        public ActionResult MenuMedico()
        {
            return View();
        }

    }
}
