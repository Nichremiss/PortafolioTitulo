using System.ServiceModel;
using CentroMedico.Datos;
using System.Text;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPrevision" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPrevision
    {
        [OperationContract]
        bool InsertarPrevision(PrevisionEnt entidad);

        [OperationContract]
        string ObtenerPrevision();
    }
}
