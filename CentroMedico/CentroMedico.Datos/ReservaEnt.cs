using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroMedico.Datos
{
    public class ReservaEnt
    {
        public string reserva_id;
        public string reserva_especialidad;
        public string reserva_prevision { get; set; }
        public string reserva_medico;
        public string reserva_sucursal;
        public string reserva_fecha;
        public string reserva_hora;
        public string reserva_paciente_rut { get; set; }
        public string reserva_paciente_nombre;
        public string reserva_agenda_detalle;
        //public string  rut { get; set; }
        //public string  prevision { get; set; }
    }
}
