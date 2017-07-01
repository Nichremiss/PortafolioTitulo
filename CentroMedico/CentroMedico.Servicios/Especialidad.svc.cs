using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Especialidad" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Especialidad.svc o Especialidad.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Especialidad : IEspecialidad
    {
        public bool InsertarEspecialidad(EspecialidadEnt entidad)
        {
            Negocio.Especialidad espe = new Negocio.Especialidad();
            return espe.InsertarEspecialidad(entidad);
        }

        public string ObtenerEspecialidad()
        {
            List<EspecialidadEnt> retorno = new List<EspecialidadEnt>();
            Negocio.Especialidad espe = new Negocio.Especialidad();
            retorno = espe.ObtenerEspecialidad();
            string output = JsonConvert.SerializeObject(retorno);
            return output;
        }
    }
}
