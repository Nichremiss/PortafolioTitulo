using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Reserva" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Reserva.svc o Reserva.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Reserva : IReserva
    {
        public bool InsertarReserva(ReservaEnt entidad)
        {
            Negocio.Reserva res = new Negocio.Reserva();
            return res.InsertarReserva(entidad);
        }

        public ReservaEnt MuestraDatoReserva(string id_agenda)
        {
            Negocio.Reserva res = new Negocio.Reserva();
            ReservaEnt retorno = res.MuestraDatoReserva(id_agenda);
            return retorno;
        }
        public string MuestraListaTodasLasReservasRealizadas()
        {
            Negocio.Reserva res = new Negocio.Reserva();
            return res.MuestraListaTodasLasReservasRealizadas();
        }

        public string ListaTodosLosPacientesEnEspera()
        {
            Negocio.Reserva res = new Negocio.Reserva();
            return res.ListaTodosLosPacientesEnEspera();
        }
        public string MuestraPacientesEsperaXdoctor(string nombre)
        {
            Negocio.Reserva res = new Negocio.Reserva();
            return res.MuestraPacientesEsperaXdoctor(nombre);
        }
        public string MuestraListaDeReservaXpaciente(string rut)
        {
            Negocio.Reserva res = new Negocio.Reserva();
            return res.MuestraListaDeReservaXpaciente(rut);
        }

        public bool CambiarEstadoPaciente(ReservaEnt entidad)
        {
            Negocio.Reserva rev = new Negocio.Reserva();
            bool retorno = rev.CambiarEstadoPaciente(entidad);
            return retorno;
        }
        /// <summary>
        /// Metodo para cambiar la reserva a paciente en espera
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool CambiarEstadoPacienteEspera(ReservaEnt entidad)
        {
            Negocio.Reserva rev = new Negocio.Reserva();
            bool retorno = rev.CambiarEstadoPacienteEspera(entidad);
            return retorno;
        }

        public bool AnularReservaPaciente(string id_reserva)
        {
            Negocio.Reserva res = new Negocio.Reserva();
            return res.AnularReservaPaciente(id_reserva);
        }


    }
}
