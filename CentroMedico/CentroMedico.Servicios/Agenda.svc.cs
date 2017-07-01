using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using CentroMedico.Datos;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Agenda" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Agenda.svc o Agenda.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Agenda : IAgenda
    {
        public string ObtenerAgenda()
        {
            List<AgendaEnt> retorno = new List<AgendaEnt>();
            Negocio.Agenda age = new Negocio.Agenda();
            retorno = age.ObtenerAgenda();
            string output = JsonConvert.SerializeObject(retorno);

            return output;
        }

        public bool InsertarAgenda(AgendaEnt entidad)
        {
            Negocio.Agenda age = new Negocio.Agenda();
            return age.InsertarAgenda(entidad);
        }

        public bool ValidaDuplicidadAgendaGen(string id_medico)
        {
            Negocio.Agenda age = new Negocio.Agenda();
            return   age.ValidaDuplicidadAgendaGen(id_medico);

        }

        public AgendaEnt Trae_rangosAgendaGralXmedico(string id_medico)
        {
            Negocio.Agenda age = new Negocio.Agenda();
            AgendaEnt ret= age.Trae_rangosAgendaGralXmedico(id_medico);
            return ret;
        }
    }
}
