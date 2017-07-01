using System.Runtime.Serialization;
using System.ServiceModel;
using CentroMedico.Datos;
using System.Text;
using System.Data;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReserva" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReserva
    {
        [OperationContract]
        bool InsertarReserva(ReservaEnt entidad);
        [OperationContract]
        ReservaEnt MuestraDatoReserva(string c_esp);
        [OperationContract]
        string MuestraListaTodasLasReservasRealizadas();
        [OperationContract]
        string ListaTodosLosPacientesEnEspera();
        [OperationContract]
        string MuestraPacientesEsperaXdoctor(string nombre);
        [OperationContract]
        string MuestraListaDeReservaXpaciente(string rut);
        [OperationContract]
        bool CambiarEstadoPaciente(ReservaEnt entidad);
        [OperationContract]
        bool CambiarEstadoPacienteEspera(ReservaEnt entidad);
        [OperationContract]
        bool AnularReservaPaciente(string id_reserva);
    }
}

