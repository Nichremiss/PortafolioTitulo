using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentroMedico.Datos;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISucursales" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISucursales
    {
        [OperationContract]
        string ObtenerSucursales();

        [OperationContract]
        bool InsertarSucursal(SucursalEnt entidad);
    }
}
