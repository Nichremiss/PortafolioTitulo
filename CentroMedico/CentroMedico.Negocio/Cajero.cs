using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Cajero
    {
      
/// <summary>
/// 
/// </summary>
/// <param name="fecha_inicio"></param>
/// <param name="fecha_fin"></param>
/// <param name="NombreTabla"></param>
/// <returns></returns>
        public string RecaudacionGeneral(string fecha_inicio, string fecha_fin, string NombreTabla = "TablaReporteGeneral")
        {
            try
            {
                OracleComand exec = new OracleComand();
                string salida = " ";
                DataTable dataTable = new DataTable();
                DataTable dt = new DataTable();
                
                var parametros = new Dictionary<string, string>();
                parametros.Add("V_FECHA_INICIO", fecha_inicio);
                parametros.Add("V_FECHA_FIN", fecha_fin);
                string[] nombrecolumnas = { "Acciones" };
                TEMPLATE.Ocultas = "0";
                string[] columnas = { "<a href='#' class='btn btn-info btn-sm btn-icon icon-left' style='margin: 8px;' onclick =\"MostrarModal('{0}')\"><i class='entypo-download'></i>Informe comisión</a>" + "<a href='#' class='btn btn-info btn-sm btn-icon icon-left' onclick=\"AbrirModalPdf('{0}')\"><i class='entypo-attach'></i>Adj. comisión</a>", "MEDICO_ID"};
                //object sumObject;
                //sumObject = dt.Compute("Sum(RECAUDADO)", "Total = 6");

                dt = exec.ExecStoredProcedure("SPREC_REPORTE_GENERAL ", dt, parametros);
                
                return TEMPLATE.Tabla(dt, NombreTabla, nombrecolumnas, columnas);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

/// <summary>
/// 
/// </summary>
/// <param name="fecha_inicio"></param>
/// <param name="fecha_fin"></param>
/// <param name="id_medico"></param>
/// <returns></returns>
public CajeroEnt MuestraDatoReporte(string fecha_inicio, string fecha_fin, string id_medico)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            Boolean bolRespuests = false;
            CajeroEnt ca = new CajeroEnt();
            try
            {
                DataTable dt = new DataTable();
                Dictionary<String, String> parametros = new Dictionary<string, string>();
                parametros.Add("V_ID_MED", int.Parse(id_medico).ToString());
                parametros.Add("V_FECHA_INICIO", fecha_inicio);
                parametros.Add("V_FECHA_FIN", fecha_fin);
              
                exec.ExecStoredProcedure("SPREC_REPORTE_COMISION_MOD", dt, parametros);
                foreach (DataRow col in dt.Rows)
                {

                    bolRespuests = true;
                  ca.id_medico   = col["MEDICO_ID"].ToString();
                  ca.especialidad= col["ESPECIALIDAD"].ToString();
                  ca.nombre      =col["DOCTOR"].ToString();
                  ca.atenciones  =col["CANTIDAD_ATENCIONES"].ToString();
                  ca.recaudado   =col["TOTAL_RECAUDADO"].ToString();
                  ca.comision    =col["COMISION"].ToString();
                   ca.sucursal   =col["SUCURSAL"].ToString();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return ca;
        }
        
                  
public ReservaEnt MuestraDatoReserva(string id_agenda)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            Boolean bolRespuests = false;
            //List<RegistroEnt> retorno = new List<RegistroEnt>();
            ReservaEnt res = new ReservaEnt();
            try
            {
                DataTable dt = new DataTable();
                Dictionary<String, String> datos = new Dictionary<string, string>();
                datos.Add("V_ID_AGENDA_RESERVA ", int.Parse(id_agenda).ToString());
                exec.ExecStoredProcedure("SPREC_REPORTE_COMISION_MOD", dt, datos);

                foreach (DataRow col in dt.Rows)
                {

                    bolRespuests = true;
                    res.reserva_medico = col["MEDICO"].ToString();
                    res.reserva_hora = col["HORA"].ToString();
                    res.reserva_especialidad = col["ESPECIALIDAD"].ToString();
                    res.reserva_fecha = col["FECHA"].ToString();
                    res.reserva_sucursal = col["SUCURSAL"].ToString();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return res;
        }

        public CajeroEnt MuestraCalculoGral(string fecha_inicio, string fecha_fin)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            Boolean bolRespuests = false;
            //List<RegistroEnt> retorno = new List<RegistroEnt>();
            CajeroEnt ca = new CajeroEnt();
            try
            {
                DataTable dt = new DataTable();
                Dictionary<String, String> parametros = new Dictionary<string, string>();
                parametros.Add("V_FECHA_INICIO", fecha_inicio);
                parametros.Add("V_FECHA_FIN", fecha_fin);
                exec.ExecStoredProcedure("SPREC_MUESTRA_REPORTE_GRAL", dt, parametros);

                foreach (DataRow col in dt.Rows)
                {

                    bolRespuests = true;
                    ca.recaudado = col["TOTAL_RECAUDADO"].ToString();

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return ca;
        }





        






    }
}
