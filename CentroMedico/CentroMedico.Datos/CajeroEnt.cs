using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroMedico.Datos
{
    public class CajeroEnt
    {
        public string id_medico { get; set; }
        public string nombre { get; set; }
        public string especialidad { get; set; }
        public string sucursal { get; set; }
        public string atenciones { get; set; }
        public string recaudado { get; set; }
        public string comision { get; set; }

    }
}