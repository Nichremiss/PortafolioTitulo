using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentroMedico.Datos;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAgendaDiariasvc" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAgendaDiariasvc
    {

        [OperationContract]
        bool InsertarAgendaDiaria(AgendaDiariaEnt entidad, string hora_inicio, string hora_termino, string duracion);
        [OperationContract]
        bool EditarAgendaDiaria(AgendaDiariaEnt entidad, string hora_inicio, string hora_termino, string duracion);
        [OperationContract]
        string ObtenerCalendario(AgendaDiariaEnt entidad);
        [OperationContract]
        string MuestraHorasDisponibles(string c_med, string fecha);
        [OperationContract]
        string MuestraHorasxdia(string c_med, string fecha); 
        [OperationContract]
        string MuestraHorasDisponiblesGeneral(string c_esp);
        


    }
}
