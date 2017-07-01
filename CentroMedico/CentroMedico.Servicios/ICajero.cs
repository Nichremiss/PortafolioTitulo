using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using CentroMedico.Datos;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICajero" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICajero
    {
        [OperationContract]
        string RecaudacionGeneral(string fecha_inicio, string fecha_fin);
        [OperationContract]
        CajeroEnt MuestraDatoReporte(string fecha_inicio, string fecha_fin, string id_medico);
        [OperationContract]
        CajeroEnt MuestraCalculoGral(string fecha_inicio, string fecha_fin);
    }
}
