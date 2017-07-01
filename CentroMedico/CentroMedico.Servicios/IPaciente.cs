using System.Runtime.Serialization;
using System.ServiceModel;
using CentroMedico.Datos;
using System.Text;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPaciente" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPaciente
    {
        [OperationContract]
        bool ValidarLoginPaciente(PacienteEnt entidad);

        [OperationContract]
        bool InsertarPaciente(PacienteEnt entidad);

        [OperationContract]
        string ObtenerPaciente();

        [OperationContract]
        bool ValidaDuplicidadPaciente(PacienteEnt entidad);
    }
}
