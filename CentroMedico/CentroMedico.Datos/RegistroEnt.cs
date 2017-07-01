using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroMedico.Datos
{
   public  class RegistroEnt
    {
        public string NombreUsuario { get; set; }
        public string Usuario { get; set; }
        public string contrasena { set; get; }
        public int TipoUsuario { get; set; }
        public string prevision { get; set; }
        public string email { get; set; }
    }
}
