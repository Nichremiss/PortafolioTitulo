using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroMedico.Negocio;
using CentroMedico.Datos;
using ConsoladePruebas.AgendaDiariaSvc;
using ConsoladePruebas.Medico;



namespace ConsoladePruebas
{
    class Program
    {
        static void Main(string[] args)
        {

            string Datos = servicio.ObtenerCalendario(ag);
            AgendaDiaria ent = new AgendaDiaria();
            AgendaDiariaEnt ag = new AgendaDiariaEnt();
            List<AgendaDiariaEnt> resultado = new List<AgendaDiariaEnt>();
            ag.AGENDA_DETALLE_MEDICO_ID = 1;
            ag.AGENDA_DETALLE_DIA_ATENCION = "24/04/2017";
            resultado = ent.ObtenerCalendario(ag);

            AgendaDiariasvcClient servicio = new AgendaDiariasvcClient();

            string aaa = servicio.ObtenerCalendario(ag);


            Console.WriteLine(aaa);

            MedicoClient medico = new MedicoClient();
            string resultado;
            resultado = medico.ObtenerMedico();
            Console.WriteLine(resultado);

            Console.ReadKey();
        }
    }
}
