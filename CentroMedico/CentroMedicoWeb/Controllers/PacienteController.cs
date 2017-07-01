using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroMedico.Mvc.PacienteSvc;
using CentroMedico.Mvc.PrevisionSvc;
using System.Web.Script.Serialization;

namespace CentroMedico.Mvc.Controllers
{
    public class PacienteController : Controller
    {
        public ActionResult RegistroPaciente()
        {
            //metodo que va al combobox 
            PrevisionClient pre = new PrevisionClient();
            string jsonPrevision = pre.ObtenerPrevision();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<PrevisionEnt> listaPre = js.Deserialize<List<PrevisionEnt>>(jsonPrevision);
            ViewBag.listaPrevision = listaPre;
            return View(ViewBag);
        }

        [HttpPost]
        public bool GuardarPaciente(string prut, string pnombre, string papellido, string papellidomat,
            string pfecha_nac, string ptelefono, string prevision, string pclave, string pemail, string pdireccion)
        {
            //metodo que guarda la agenda
            PacienteClient servicio = new PacienteClient();
            PacienteEnt pac = new PacienteEnt();
            pac.paciente_rut = prut;
            pac.paciente_nombre = pnombre;
            pac.paciente_apellido_paterno = papellido;
            pac.paciente_apellido_materno = papellidomat;
            pac.paciente_fecha_nac = pfecha_nac;
            pac.paciente_telefono = ptelefono;
            pac.paciente_prevision = prevision;
            pac.paciente_clave = pclave;
            pac.paciente_email = pemail;
            pac.paciente_direccion = pdireccion;
            
            bool inserta = servicio.InsertarPaciente(pac);
            return inserta;
        }

        public ActionResult LoginPacienteView()
        {
            return View(ViewBag);
        }

        [HttpPost]
        public bool LoginPaciente(string rut, string pass)
        {
            PacienteClient servicio = new PacienteClient();
            PacienteEnt pac = new PacienteEnt();
            pac.paciente_rut = rut;
            pac.paciente_clave = pass;
            bool valida = servicio.ValidarLoginPaciente(pac);
            return valida;

        }

        public ActionResult MenuPaciente()
        {
            return View();
        }


    }
}
