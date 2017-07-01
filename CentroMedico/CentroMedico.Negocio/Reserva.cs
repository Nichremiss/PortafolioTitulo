using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Reserva
    {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entidad"></param>
    /// <returns></returns>
        public bool InsertarReserva(ReservaEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_RESERVA_ESPECIALIDAD", entidad.reserva_especialidad);
                _diccionario.Add("V_RESERVA_PREVISION", entidad.reserva_prevision);
                _diccionario.Add("V_RESERVA_MEDICO", entidad.reserva_medico);
                _diccionario.Add("V_RESERVA_SUCURSAL", entidad.reserva_sucursal);
                _diccionario.Add("V_RESERVA_FECHA", entidad.reserva_fecha);
                _diccionario.Add("V_RESERVA_HORA", entidad.reserva_hora);
                _diccionario.Add("V_RESERVA_PACIENTE_RUT", entidad.reserva_paciente_rut);
                _diccionario.Add("V_RESERVA_PACIENTE_NOMBRE", entidad.reserva_paciente_nombre);
                _diccionario.Add("V_RESERVA_AGENDA_DETALLE", entidad.reserva_agenda_detalle);

                exec.ExecStoredProcedure("SPINS_INGRESARRESERVA", _diccionario);

                ////LLENA tabla estado reserva
                //var _diccionarioestado = new Dictionary<string, string>();
                //_diccionarioestado.Add("V_ESTADO_PACIENTE_ID", entidad.reserva_paciente_rut);
                //_diccionarioestado.Add("V_ESTADO_RESERVA_DESC", "1");
                //exec.ExecStoredProcedure("SPINS_ESTADORESERVA", _diccionarioestado);
                retorno = true;
            }
            catch (System.Exception)
            {

                retorno=false;
            }

            return retorno;
        }

        /// <summary>
        /// Muestra Datos en Modal de reserva
        /// para confirmar datos y posteriormente
        /// confirmar la reserva
        /// </summary>
        /// <param name="id_agenda"></param>
        /// <returns></returns>
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
                exec.ExecStoredProcedure("SPREC_MOSTRAR_RESERVA", dt, datos);

                foreach (DataRow col in dt.Rows)
                {

                    bolRespuests = true;
                    res.reserva_medico = col["MEDICO"].ToString();
                    res.reserva_hora= col["HORA"].ToString();
                    res.reserva_especialidad= col["ESPECIALIDAD"].ToString();
                    res.reserva_fecha= col["FECHA"].ToString();
                    res.reserva_sucursal= col["SUCURSAL"].ToString();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public string MuestraListaTodasLasReservasRealizadas(string NombreTabla= "MuestraListaTodasLasReservasRealizadas")
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            DataTable dt = new DataTable();
            DataTable dto = new DataTable();
            Dictionary<String, String> datos = new Dictionary<string, string>();
            string[] nombrecolumnas = { "Acciones" };
            TEMPLATE.Ocultas = "0";
            string[] columnas = { "<a href='#' class='btn btn-info btn-sm btn-icon icon-left' id='lista' onclick=\"ListarReservas('{0}')\"><i class='entypo-pencil'></i>Poner en Fila</a>", "NUM_ID" };
            dt = exec.ExecStoredProcedure("SPREC_LISTA_RESERVADAS_TODAS", dto, datos);
            return TEMPLATE.Tabla(dt, NombreTabla, nombrecolumnas, columnas);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        /// 

        public bool AnularReservaPaciente(string id_reserva)
        {
            try
            {
                OracleComand exec = new OracleComand();
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("ID_RESERVA", int.Parse(id_reserva).ToString());
                exec.ExecStoredProcedure("SPDEL_ANULAR_RESERVA ", param);
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }



        public string MuestraListaDeReservaXpaciente(string rut,string NombreTabla="Tabla_ListaHorasReservadas")
        {
            OracleComand exec = new OracleComand();
            string salida = "";

            DataTable dt = new DataTable();
            Dictionary<String, String> datos = new Dictionary<string, string>();
            datos.Add("V_RUT", rut);
            string[] nombrecolumnas = { "Acciones" };
            TEMPLATE.Ocultas = "0";
            string[] columnas = { "<a href='#' class='btn btn-danger btn-sm btn-icon icon-left' onclick=\"AnularReserva('{0}')\"><i class='entypo-cancel'></i>Anular hora</a>", "NUM_ID" };
            dt = exec.ExecStoredProcedure("SPREC_LISTA_RESERVAXPACIENTE", dt, datos);
            return TEMPLATE.Tabla(dt, NombreTabla, nombrecolumnas, columnas);
           
        }
        /// <summary>
        /// Lista  a doctor sua pacientes que se encuentren a espera
        /// </summary>
        /// <returns></returns>
        public string MuestraPacientesEsperaXdoctor(string nombre, string NombreTabla="TablaPacientesEsperaxDoctor")
        {
            OracleComand exec = new OracleComand();
            string salida = "";
          
            DataTable dt = new DataTable();
            Dictionary<String, String> datos = new Dictionary<string, string>();
            datos.Add("V_NOMBRE_DOCTOR", nombre);
            string[] nombrecolumnas = { "Acciones" };
            TEMPLATE.Ocultas = "0";
            string[] columnas = { "<a href='#' class='btn btn-info btn-sm btn-icon icon-left' onclick=\"MarcarPacienteAtendido('{0}')\"><i class='entypo-check'></i>Atendido</a>", "NUM_ID" };
            dt = exec.ExecStoredProcedure("SPREC_LISTA_ESPERAXDOCTOR", dt, datos);
            return TEMPLATE.Tabla(dt, NombreTabla, nombrecolumnas, columnas);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public string ListaTodosLosPacientesEnEspera(string NombreTabla = "MuestraListaPacienteEsperaTodos")
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            DataTable dto = new DataTable();
            DataTable dt = new DataTable();
            Dictionary<String, String> datos = new Dictionary<string, string>();       
            string[] nombrecolumnas = { "Acciones" };
            TEMPLATE.Ocultas = "7";
            string[] columnas = { "<a href='#' class='btn btn-info btn-sm btn-icon icon-left' onclick=\"SinMetodo('{0}')\"><i class='entypo-pencil'></i>Poner en Fila</a>", "NUM_ID" };
            dt = exec.ExecStoredProcedure("SPREC_LISTA_ESPERA_TODAS", dto, datos);
            return TEMPLATE.Tabla(dt, NombreTabla, nombrecolumnas, columnas);           
        }

        public bool CambiarEstadoPaciente(ReservaEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_RESERVA_ID", entidad.reserva_id);
                exec.ExecStoredProcedure("SPREC_RESERVAPACIENTEATEND", _diccionario);
                retorno = true;
            }
            catch (System.Exception)
            {

                retorno=false;
            }

            return retorno;
        }

        public bool CambiarEstadoPacienteEspera(ReservaEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_RESERVA_ID_ESP", entidad.reserva_id);
                exec.ExecStoredProcedure("SPREC_RESERVAPACIENTEESPERA", _diccionario);
                retorno = true;
            }
            catch (System.Exception)
            {

                retorno=false;
            }
            return retorno;
        }




    }
}
