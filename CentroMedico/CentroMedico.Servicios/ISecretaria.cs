using CentroMedico.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using CentroMedico.Datos;
using System.Text;

namespace CentroMedico.Servicios
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface ISecretaria
    {
        [OperationContract]
        bool ValidarLoginSecretaria(SecretariaEnt entidad);

        [OperationContract]
        bool InsertarSecretaria(SecretariaEnt entidad);

        [OperationContract]
        bool ValidaDuplicidadSecretaria(SecretariaEnt entidad);
    }
}
