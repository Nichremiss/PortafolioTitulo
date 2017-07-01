using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Prevision" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Prevision.svc o Prevision.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Prevision : IPrevision
    {
        public bool InsertarPrevision(PrevisionEnt entidad)
        {
            Negocio.Prevision pre = new Negocio.Prevision();
            return pre.InsertarPrevision(entidad);
        }

        public string ObtenerPrevision()
        {
            List<PrevisionEnt> retorno = new List<PrevisionEnt>();
            Negocio.Prevision pre = new Negocio.Prevision();
            retorno = pre.ObtenerPrevision();
            string output = JsonConvert.SerializeObject(retorno);
            return output;
        }
    }
}
