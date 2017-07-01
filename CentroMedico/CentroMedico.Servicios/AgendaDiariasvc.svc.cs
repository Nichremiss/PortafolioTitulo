using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;


namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AgendaDiariasvc" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AgendaDiariasvc.svc o AgendaDiariasvc.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AgendaDiariasvc : IAgendaDiariasvc
    {
        public bool InsertarAgendaDiaria(AgendaDiariaEnt entidad, string hora_inicio, string hora_termino, string duracion)
        {
            Negocio.AgendaDiaria aDiaria = new Negocio.AgendaDiaria();

            return aDiaria.InsertarAgendaDiaria(entidad, hora_inicio, hora_termino, duracion);
        }

        public bool EditarAgendaDiaria(AgendaDiariaEnt entidad, string hora_inicio, string hora_termino, string duracion)
        {
            Negocio.AgendaDiaria aDiaria = new Negocio.AgendaDiaria();

            return aDiaria.EditarAgendaDiaria(entidad, hora_inicio, hora_termino, duracion);
        }

        public string MuestraHorasDisponibles(string c_med, string fecha)
        {
            Negocio.AgendaDiaria age = new Negocio.AgendaDiaria();
            return age.MuestraHorasDisponibles(c_med, fecha);
        }


        public string MuestraHorasDisponiblesGeneral(string c_esp)
        {
            Negocio.AgendaDiaria age = new Negocio.AgendaDiaria();
            return age.MuestraHorasDisponiblesGeneral(c_esp);
        }
        public string ObtenerCalendario(AgendaDiariaEnt entidad)
        {
            Negocio.AgendaDiaria age = new Negocio.AgendaDiaria();
            return age.ObtenerCalendario(entidad);
        }
        public string MuestraHorasxdia(string c_med, string fecha)
        {
            Negocio.AgendaDiaria age = new Negocio.AgendaDiaria();
            return age.MuestraHorasxdia(c_med, fecha);
        }

    }
}