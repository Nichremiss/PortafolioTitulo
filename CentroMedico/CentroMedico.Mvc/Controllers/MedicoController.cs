using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroMedico.Mvc.AgendaSvc;
using CentroMedico.Mvc.AgendaDiariaSvc;
using CentroMedico.Mvc.MedicoSvc;
using CentroMedico.Mvc.EspecialidadSvc;
using CentroMedico.Mvc.SucursalesSvc;
using System.Web.Script.Serialization;
using CentroMedico.Datos;
using CentroMedico.Mvc.ReservaSvc;

namespace CentroMedico.Mvc.Controllers
{
    public class MedicoController : Controller
    {
        public ActionResult RegistroMedico()
        {
            //metodo que va al combobox
            EspecialidadClient espe = new EspecialidadClient();
            SucursalesClient suc = new SucursalesClient();
            string jsonEspecialidad = espe.ObtenerEspecialidad();
            string jsonSucursales = suc.ObtenerSucursales();
            JavaScriptSerializer jsEspe = new JavaScriptSerializer();
            JavaScriptSerializer jsSuc = new JavaScriptSerializer();
            List<EspecialidadEnt> listaEspe = jsEspe.Deserialize<List<EspecialidadEnt>>(jsonEspecialidad);
            List<Datos.SucursalEnt> listasuc = jsSuc.Deserialize<List<Datos.SucursalEnt>>(jsonSucursales);
            ViewBag.listaEspecialidad = listaEspe;
            ViewBag.listaSucursales = listasuc;
            return View(ViewBag);
        }

        public ActionResult PacientesEspera()
        {
            return View();
        }
        [HttpPost]
        public bool CambiarEstado(string reserva_id)
        {
            ReservaClient servicio = new ReservaClient();
            ReservaEnt rev = new ReservaEnt();
            rev.reserva_id = reserva_id;

            bool cambia = servicio.CambiarEstadoPaciente(rev);
            return cambia;
        }

        [HttpPost]
        public ActionResult PecientesEnEspera()
        {        
            ReservaClient res = new ReservaClient();         
            return Json(new { tabla = res.MuestraPacientesEsperaXdoctor(Session["NombreUsuario"].ToString())});
        }

        [HttpPost]
        public bool GuardarMedico(string rut, string nombre, string apellidop, 
            string apellidom, string clave, string email, string especialidad, string sucursal)
        {
            MedicoClient servicio = new MedicoClient();
            MedicoEnt med = new MedicoEnt();
           
            med.medico_rut = rut;
            med.medico_nombre = nombre;
            med.medico_apellido_paterno = apellidop;
            med.medico_apellido_materno = apellidom;
            med.medico_clave = Encriptar(clave);
            med.medico_email = email;
            med.medico_especialidad = especialidad;
            med.medico_sucursal = sucursal;
            bool inserta = servicio.InsertarMedico(med);
            return inserta;
        }

        [HttpPost]
        public bool ValidarMedicoDuplicado(string rut)
        {
            MedicoClient servicio = new MedicoClient();
            MedicoEnt med = new MedicoEnt();
            med.medico_rut = rut;
            bool valida = servicio.ValidaDuplicidadMedico(med);
            return valida;
        }

        private static string Encriptar(string _cadena)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadena);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public ActionResult LoginMedicoView()
        {
            return View();
        }

        [HttpPost]
        public bool LoginMedico(string rut, string pass)
        {
            MedicoClient servicio = new MedicoClient();
            Session["Usuario"] = rut;
            string nombrecompleto = Session["Usuario"].ToString();
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
