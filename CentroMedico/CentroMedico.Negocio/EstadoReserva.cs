using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class EstadoReserva
    {

        public List<EstadoReservaEnt> ObtenerEstado()
        {
            OracleComand exec = new OracleComand();
            List<EstadoReservaEnt> retorno = new List<EstadoReservaEnt>();

            try
            {
                var parametros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SPREC_ESTADO_RESERVA", dataTable, parametros);

                foreach (DataRow rows in dataTable.Rows)
                {
                    EstadoReservaEnt entidad = new EstadoReservaEnt();
                    entidad.estado_reserva_id = rows["ESTADO_RESERVA_ID"].ToString();
                    entidad.estado_desc = rows["ESTADO_DESC"].ToString();   

                    return null;
                }
            }
            catch
            {
                retorno = null;
            }

            return retorno;
        }

    }
}
