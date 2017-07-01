using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroMedico.Mvc.AgendaSvc;
using CentroMedico.Mvc.AgendaDiariaSvc;
using CentroMedico.Mvc.MedicoSvc;
using System.Web.Script.Serialization;
//using CentroMedico.Mvc.EspecialidadSvc;


namespace CentroMedico.Mvc.Controllers
{
    public class AgendaController : Controller
    {
        public ActionResult InsertarAgenda()
        {
            //metodo que va al combobox 
            MedicoClient med = new MedicoClient();
            string jsonMedicos = med.ObtenerMedico();
            JavaScriptSerializer js = new JavaScriptSerializer();//comentario json
            List<MedicoEnt> listaMed = js.Deserialize<List<MedicoEnt>>(jsonMedicos);
            ViewBag.listaMedicos = listaMed;
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
            AgendaDiariaEnt ageEnt=new AgendaDiariaEnt();

            ageEnt.AGENDA_DETALLE_DIA_ATENCION= fechaDia;
            //ageEnt.AGENDA_DETALLE_MEDICO_ID =int.Parse(id_medico);
            ageEnt.AGENDA_DETALLE_MEDICO_ID = id_medico;

            bool inserta = servicio.InsertarAgendaDiaria(ageEnt,horaInicio,horaTermino,tiempoAtencion);
            return inserta;
        }

        [HttpPost]
        public bool EditarAgendaDiaria(string EDfechaDia, string EDhoraInicio, string EDhoraTermino,string EDtiempoAtencion, string EDid_medico)
        {
            AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();
            AgendaDiariaEnt ageEnt = new AgendaDiariaEnt();

            ageEnt.AGENDA_DETALLE_DIA_ATENCION = EDfechaDia;
            //ageEnt.AGENDA_DETALLE_MEDICO_ID =int.Parse(id_medico);
            ageEnt.AGENDA_DETALLE_MEDICO_ID = EDid_medico;
            bool inserta = servicio.EditarAgendaDiaria(ageEnt, EDhoraInicio, EDhoraTermino, EDtiempoAtencion);
            return inserta;
        }

    }

   
}
   

