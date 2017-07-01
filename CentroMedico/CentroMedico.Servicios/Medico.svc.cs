using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Medico" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Medico.svc o Medico.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Medico : IMedico
    {

        public bool InsertarMedico(MedicoEnt entidad)
        {
            Negocio.Medico med = new Negocio.Medico();
            return med.InsertarMedico(entidad);
        }

        public bool ValidarLoginMedico(MedicoEnt entidad)
        {
            Negocio.Medico med = new Negocio.Medico();
            bool retorno = med.ValidarLoginMedico(entidad);
            return retorno;
        }

        public string ObtenerMedico()
        {
            List<MedicoEnt> retorno = new List<MedicoEnt>();
            Negocio.Medico med = new Negocio.Medico();
            retorno = med.ObtenerMedicos();
            string output = JsonConvert.SerializeObject(retorno);
            return output;
        }

        public bool ValidaDuplicidadMedico(MedicoEnt entidad)
        {
            Negocio.Medico med = new Negocio.Medico();
            bool retorno = med.ValidaDuplicidadMedico(entidad);
            return retorno;
        }

        public string ObtenerMedicosAgenda()
        {
            List<MedicoEnt> retorno = new List<MedicoEnt>();
            Negocio.Medico med = new Negocio.Medico();
            retorno = med.ObtenerMedicosAgenda();
            string output = JsonConvert.SerializeObject(retorno);
            return output;
        }

        public string ObtenerMedicosSinAgenda()
        {
            List<MedicoEnt> retorno = new List<MedicoEnt>();
            Negocio.Medico medi = new Negocio.Medico();
            retorno = medi.ObtenerMedicosSinAgenda();
            string output = JsonConvert.SerializeObject(retorno);
            return output;
        }
    }
}
