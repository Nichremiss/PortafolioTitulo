using System.ServiceModel;
using CentroMedico.Datos;
using System.Text;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMedico" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMedico
    {
        [OperationContract]
        bool ValidarLoginMedico(MedicoEnt entidad);

        [OperationContract]
        bool InsertarMedico(MedicoEnt entidad);

        [OperationContract]
        string ObtenerMedico();

        [OperationContract]
        bool ValidaDuplicidadMedico(MedicoEnt entidad);

        [OperationContract]
        string ObtenerMedicosAgenda();

        [OperationContract]
        string ObtenerMedicosSinAgenda();
    }
}
