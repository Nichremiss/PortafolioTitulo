using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentroMedico.Datos;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EstadoReserva" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EstadoReserva.svc o EstadoReserva.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EstadoReserva : IEstadoReserva
    {
        public string ObtenerEstado()
        {
            List<EstadoReservaEnt> retorno = new List<EstadoReservaEnt>();
            Negocio.EstadoReserva estr = new Negocio.EstadoReserva();
            retorno = estr.ObtenerEstado();
            string output = JsonConvert.SerializeObject(retorno);
 
            return output;
        }

    }
}
