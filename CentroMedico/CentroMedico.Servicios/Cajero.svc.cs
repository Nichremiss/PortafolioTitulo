using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentroMedico.Datos;


namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Cajero" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Cajero.svc o Cajero.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Cajero : ICajero
    {
            

        public string RecaudacionGeneral(string fecha_inicio, string fecha_fin)
        {
            Negocio.Cajero caj = new Negocio.Cajero();
            return caj.RecaudacionGeneral(fecha_inicio, fecha_fin);
        }

        public CajeroEnt MuestraDatoReporte(string fecha_inicio, string fecha_fin, string id_medico)
        {
            Negocio.Cajero caj = new Negocio.Cajero();
            CajeroEnt caje =caj.MuestraDatoReporte(fecha_inicio, fecha_fin, id_medico);
            return caje;
        }
        public CajeroEnt MuestraCalculoGral(string fecha_inicio, string fecha_fin)
        {
            Negocio.Cajero caj = new Negocio.Cajero();
            CajeroEnt caje = caj.MuestraCalculoGral(fecha_inicio, fecha_fin);
            return caje;

        }
    }
    //}
}
