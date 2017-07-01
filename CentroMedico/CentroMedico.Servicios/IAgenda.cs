using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentroMedico.Datos;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAgenda" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IAgenda
    {
        [OperationContract]
        string ObtenerAgenda();
        [OperationContract]
        bool InsertarAgenda(AgendaEnt entidad);
        [OperationContract]
        bool ValidaDuplicidadAgendaGen(string id_medico);
        [OperationContract]
         AgendaEnt Trae_rangosAgendaGralXmedico(string id_medico);
        }
}
