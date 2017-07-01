using System.ServiceModel;
using CentroMedico.Datos;
using System.Text;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEspecialidad" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEspecialidad
    {
        [OperationContract]
        bool InsertarEspecialidad(EspecialidadEnt entidad);

        [OperationContract]
        string ObtenerEspecialidad();
    }
}
