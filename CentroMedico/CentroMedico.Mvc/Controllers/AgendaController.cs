using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroMedico.Mvc.AgendaSvc;
using CentroMedico.Mvc.AgendaDiariaSvc;
using CentroMedico.Mvc.MedicoSvc;
using System.Web.Script.Serialization;
using System.Globalization;



namespace CentroMedico.Mvc.Controllers
{
    public class AgendaController : Controller
    {
        public ActionResult InsertarAgenda()
        {
            //metodo que va al combobox 
            MedicoClient med = new MedicoClient();
            string jsonMedicos = med.ObtenerMedico();
            string jsonMedicosAgenfa = med.ObtenerMedicosAgenda();

            JavaScriptSerializer js = new JavaScriptSerializer();
            JavaScriptSerializer jsagenda = new JavaScriptSerializer();

            List<Datos.MedicoEnt> listaMed = js.Deserialize<List<Datos.MedicoEnt>>(jsonMedicos);
            List<Datos.MedicoEnt> listaMedAge = js.Deserialize<List<Datos.MedicoEnt>>(jsonMedicosAgenfa);

            ViewBag.listaMedicos = listaMed;
            ViewBag.listaMedicosAgenda = listaMedAge;
            return View(ViewBag);
        }


        public ActionResult CalendarioMedico(string id_medico, string fecha_dia)
        {


            return View();

        }

        [HttpPost]
        public bool GuardaAgenda(string idMedico, string inicioAgenda, string terminoAgenda)
        {
            //metodo que guarda la agenda
            AgendaClient servicio = new AgendaClient();
            AgendaEnt age = new AgendaEnt();
            age.agenda_medico_id = idMedico;
            age.agenda_fecha_inicio = inicioAgenda;
            age.agenda_fecha_termino = terminoAgenda;

            bool inserta = servicio.InsertarAgenda(age);
            return inserta;
        }

        [HttpPost]
        public bool GuardaAgendaDiaria(string fechaDia, string horaInicio, string horaTermino, 
            string tiempoAtencion,string id_medico)
        {
            AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();
           CentroMedico.Datos.AgendaDiariaEnt ageEnt= new CentroMedico.Datos.AgendaDiariaEnt();
                  ageEnt.AGENDA_DETALLE_DIA_ATENCION = fechaDia;
                    //ageEnt.AGENDA_DETALLE_MEDICO_ID =int.Parse(id_medico);
                    ageEnt.AGENDA_DETALLE_MEDICO_ID = id_medico;
                    bool inserta = servicio.InsertarAgendaDiaria(ageEnt, horaInicio, horaTermino, tiempoAtencion);
                    return inserta;
              
          
        }

        public bool comparaFechas(string inicioAgenda, string terminoAgenda)
        {


            DateTime ini = DateTime.Parse(inicioAgenda);
            DateTime term = DateTime.Parse(terminoAgenda);
            if (ini<term)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validaDuplicidadagendaGeneral(string id_medico)
        {
            AgendaClient age = new AgendaClient();


            if (age.ValidaDuplicidadAgendaGen(id_medico))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool validaAgendaDiaenRangoAgenda(string fechaDia)
        {
            try
            {
                DateTime dia = DateTime.Parse(fechaDia);
                DateTime FechaInicio = DateTime.Parse(Session["FechaInicio"].ToString());
                DateTime FechaTermino = DateTime.Parse(Session["FechaTermino"].ToString());
                if (dia>= FechaInicio && dia<= FechaTermino)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Trae_rangosAgendaGralXmedico(string id_medico)
        {
            try
            {
                AgendaClient age = new AgendaClient();
                AgendaEnt age_ent = new AgendaEnt();
                age_ent= age.Trae_rangosAgendaGralXmedico(id_medico);
                Session["FechaInicio"] = age_ent.agenda_fecha_inicio;
                Session["FechaTermino"] = age_ent.agenda_fecha_termino;
                return Json(new { reserva = age.Trae_rangosAgendaGralXmedico(id_medico)});
            }
            catch (Exception)
            {

                return null;
            }

        }
        
    }

   
}
   

