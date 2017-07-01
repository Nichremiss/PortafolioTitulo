using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Paciente" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Paciente.svc o Paciente.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Paciente : IPaciente
    {

        public bool InsertarPaciente(PacienteEnt entidad)
        {
            Negocio.Paciente pac = new Negocio.Paciente();
            return pac.InsertarPaciente(entidad);
        }

        public bool ValidarLoginPaciente(PacienteEnt entidad)
        {
            Negocio.Paciente pac = new Negocio.Paciente();
            bool retorno = pac.ValidarLoginPaciente(entidad);
            return retorno;
        }

        public string ObtenerPaciente()
        {
            List<PacienteEnt> retorno = new List<PacienteEnt>();
            Negocio.Paciente pac = new Negocio.Paciente();
            retorno = pac.ObtenerPaciente();
            string output = JsonConvert.SerializeObject(retorno);
            return output;
        }

        public bool ValidaDuplicidadPaciente(PacienteEnt entidad)
        {
            Negocio.Paciente pac = new Negocio.Paciente();
            bool retorno = pac.ValidaDuplicidadPaciente(entidad);
            return retorno;
        }


    }
}
