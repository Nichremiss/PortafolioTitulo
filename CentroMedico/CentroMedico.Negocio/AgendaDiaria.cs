using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroMedico.Datos;
using System.Data;
using System.Globalization;

namespace CentroMedico.Negocio
{
  public  class AgendaDiaria
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="hora_inicio"></param>
        /// <param name="hora_termino"></param>
        /// <param name="duracion"></param>
        /// <returns></returns>
        public bool InsertarAgendaDiaria(AgendaDiariaEnt entidad, string hora_inicio, string hora_termino, string duracion)
        {
            bool retorno;
            try
            {

                int largoIni = hora_inicio.Length;
                int largoTerm = hora_termino.Length;
                int horaini = 0;
                int minutoini = 0;
                int horaterm = 0;
                int minutoterm = 0;
                int tDuracion = int.Parse(duracion);
                int valorFor = 0;
                int minutosInicio = 0;

                if (largoIni == 4)
                {
                    horaini = int.Parse((hora_inicio).Substring(0, 1));
                    minutoini = int.Parse((hora_inicio).Substring(2, 2));
                }

                if (largoIni == 5)
                {
                    horaini = int.Parse((hora_inicio).Substring(0, 2));
                    minutoini = int.Parse((hora_inicio).Substring(3, 2));
                }

                if (largoTerm == 4)
                {
                    horaterm = int.Parse((hora_termino).Substring(0, 1));
                    minutoterm = int.Parse((hora_termino).Substring(2, 2));
                }

                if (largoTerm == 5)
                {
                    horaterm = int.Parse((hora_termino).Substring(0, 2));
                    minutoterm = int.Parse((hora_termino).Substring(3, 2));
                }

                switch (tDuracion)
                {
                    case 30:
                        valorFor = 2;
                        break;
                    case 15:
                        valorFor = 4;
                        break;
                    case 20:
                        valorFor = 3;
                        break;
                    default:
                        break;
                }


                bool salida = false;
                for (int i = horaini; i <= horaterm; i++)
                {
                    for (int x = 0; x < valorFor; x++)
                    {
                        if (minutoini == 60)
                            minutoini = 0;
                        if (salida == false)
                        {
                            if (i == horaterm && minutoterm == minutoini)
                            {
                                OracleComand exec = new OracleComand();
                                var _diccionario = new Dictionary<string, string>();
                                DateTime hora = new DateTime(2014, 3, 23, i, minutoini, 3, 6);
                                _diccionario.Add("V_HORA_MEDICA", hora.ToString("HH:mm", CultureInfo.CurrentCulture));
                                _diccionario.Add("V_MEDICO_ID", entidad.AGENDA_DETALLE_MEDICO_ID);
                                _diccionario.Add("V_DIA_ATENCION", entidad.AGENDA_DETALLE_DIA_ATENCION);
                                exec.ExecStoredProcedure("SPINS_AGENDADETALLEXDIA", _diccionario);
                                salida = true;
                                _diccionario = null;
                                exec = null;
                            }
                            else
                            {
                                OracleComand exec = new OracleComand();
                                var _diccionario = new Dictionary<string, string>();
                                DateTime hora = new DateTime(2014, 3, 23, i, minutoini, 3, 6);
                                string horasss = hora.ToString("HH:mm", CultureInfo.CurrentCulture);
                                _diccionario.Add("V_HORA_MEDICA", horasss);
                                _diccionario.Add("V_MEDICO_ID", entidad.AGENDA_DETALLE_MEDICO_ID);
                                _diccionario.Add("V_DIA_ATENCION", entidad.AGENDA_DETALLE_DIA_ATENCION);
                                exec.ExecStoredProcedure("SPINS_AGENDADETALLEXDIA", _diccionario);
                                minutoini = minutoini + tDuracion;
                                _diccionario = null;
                                exec = null;
                            }
                        }
                    }
                }

                retorno = true;

            }
            catch (Exception ex)
            {
                retorno = false;
            }

            return retorno;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public string ObtenerCalendario(AgendaDiariaEnt entidad, string NombreTabla = "TablaDisponibilidadDiaria")
        {
           
          
                OracleComand exec = new OracleComand();

                 string salida = "";
                //Va a la capa de Datos para ejecutar procedimiento almacenado
                Dictionary<String, String> parametros = new Dictionary<string, string>();
                parametros.Add("V_MEDICO_ID", entidad.AGENDA_DETALLE_MEDICO_ID);
                DataTable dt = new DataTable();
                DataTable dataTable = new DataTable();
                string[] nombrecolumnas = { "Acciones" };
                string[] columnas = { "<a href='#' class='btn btn-warning btn-sm btn-icon icon-left' id='tablaDiaria' style='margin: 10px' onclick=\"Modificar('{0}')\"><i class='entypo-pencil'></i>Modificar</a>", "DATOS" };
                dt = exec.ExecStoredProcedure("SPREC_CALENDARIO_DIA", dataTable, parametros);
                return TEMPLATE.Tabla(dt, NombreTabla, nombrecolumnas, columnas);

 

           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="hora_inicio"></param>
        /// <param name="hora_termino"></param>
        /// <param name="duracion"></param>
        /// <returns></returns>
        public bool EditarAgendaDiaria(AgendaDiariaEnt entidad, string hora_inicio, string hora_termino, string duracion)
        {
            bool retorno;
            try
            {

                int largoIni = hora_inicio.Length;
                int largoTerm = hora_termino.Length;
                int horaini = 0;
                int minutoini = 0;
                int horaterm = 0;
                int minutoterm = 0;
                int tDuracion = int.Parse(duracion);
                int valorFor = 0;
                int minutosInicio = 0;

                if (largoIni == 4)
                {
                    horaini = int.Parse((hora_inicio).Substring(0, 1));
                    minutoini = int.Parse((hora_inicio).Substring(2, 2));
                }

                if (largoIni == 5)
                {
                    horaini = int.Parse((hora_inicio).Substring(0, 2));
                    minutoini = int.Parse((hora_inicio).Substring(3, 2));
                }

                if (largoTerm == 4)
                {
                    horaterm = int.Parse((hora_termino).Substring(0, 1));
                    minutoterm = int.Parse((hora_termino).Substring(2, 2));
                }

                if (largoTerm == 5)
                {
                    horaterm = int.Parse((hora_termino).Substring(0, 2));
                    minutoterm = int.Parse((hora_termino).Substring(3, 2));
                }

                switch (tDuracion)
                {
                    case 30:
                        valorFor = 2;
                        break;
                    case 15:
                        valorFor = 4;
                        break;
                    case 20:
                        valorFor = 3;
                        break;
                    default:
                        break;
                }
                bool salida = false;

                var param = new Dictionary<string, string>();
                OracleComand execu = new OracleComand();
                param.Add("V_MEDICO_ID", entidad.AGENDA_DETALLE_MEDICO_ID);
               
                param.Add("V_DIA_ATENCION", entidad.AGENDA_DETALLE_DIA_ATENCION);
                execu.ExecStoredProcedure("SPDEL_AGENDIA_DIA", param);

                for (int i = horaini; i <= horaterm; i++)
                {
                    for (int x = 0; x < valorFor; x++)
                    {
                        if (minutoini == 60)
                            minutoini = 0;
                        if (salida == false)
                        {
                            if (i == horaterm && minutoterm == minutoini)
                            {
                                OracleComand exec = new OracleComand();
                                var _diccionario = new Dictionary<string, string>();
                                DateTime hora = new DateTime(2014, 3, 23, i, minutoini, 3, 6);
                                _diccionario.Add("V_HORA_MEDICA", hora.ToString("HH:mm", CultureInfo.CurrentCulture));
                                _diccionario.Add("V_MEDICO_ID", entidad.AGENDA_DETALLE_MEDICO_ID);
                                _diccionario.Add("V_DIA_ATENCION", entidad.AGENDA_DETALLE_DIA_ATENCION);
                                exec.ExecStoredProcedure("SPINS_AGENDADETALLEXDIA", _diccionario);
                                salida = true;
                                _diccionario = null;
                                exec = null;
                            }
                            else
                            {
                                OracleComand exec = new OracleComand();
                                var _diccionario = new Dictionary<string, string>();
                                DateTime hora = new DateTime(2014, 3, 23, i, minutoini, 3, 6);
                                string horasss = hora.ToString("HH:mm", CultureInfo.CurrentCulture);
                                _diccionario.Add("V_HORA_MEDICA", horasss);
                                _diccionario.Add("V_MEDICO_ID", entidad.AGENDA_DETALLE_MEDICO_ID);
                                _diccionario.Add("V_DIA_ATENCION", entidad.AGENDA_DETALLE_DIA_ATENCION);
                                exec.ExecStoredProcedure("SPINS_AGENDADETALLEXDIA", _diccionario);
                                minutoini = minutoini + tDuracion;
                                _diccionario = null;
                                exec = null;
                            }
                        }
                    }
                }

                retorno = true;

            }
            catch (Exception ex)
            {
                retorno = false;
            }

            return retorno;

        }
        /// <summary>
        /// //Muestra todos los medicos (con dia de atencion) que tengan X especialidad, asi dando opciones a paciente de seleccionar medico y día 
        /// </summary>
        /// <param name="c_esp"></param>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public string MuestraHorasDisponiblesGeneral(string c_esp, string NombreTabla = "TablaHorasReservaGeneral")
        {
            try
            {
                OracleComand exec = new OracleComand();
                DataTable dataTable = new DataTable();
                DataTable dt = new DataTable();
                string[] nombrecolumnas = { "Acciones" };
                var parametros = new Dictionary<string, string>();
                parametros.Add("V_ESPECIALIDAD_ID", int.Parse(c_esp).ToString());
                TEMPLATE.Ocultas = "0";
                string[] columnas = { "<a href='#panel3a' class='btn btn-info btn-sm btn-icon icon-left' onclick=\"ReservaGeneral('{0}')\"><i class='entypo-pencil'></i>Seleccionar</a>", "DATOS" };
                dt = exec.ExecStoredProcedure("SPREC_CONSULTA_GRAL_RESERVA ", dataTable, parametros);
                return TEMPLATE.Tabla(dt, NombreTabla, nombrecolumnas, columnas);
            }
            catch (Exception ex)
            {

                throw;
            }

        }        
        /// <summary>
        /// Segun seleccion de en metodo MuestraHorasDisponiblesGeneral(), horas disponibles del medico en el dia seleccionado
        /// </summary>
        /// <param name="c_med"></param>
        /// <param name="fecha"></param>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public string MuestraHorasDisponibles(string c_med,string fecha, string NombreTabla="TablaHorasReserva")
        {
            try
            {
                OracleComand exec = new OracleComand();
                DataTable dataTable = new DataTable();
                DataTable dt = new DataTable();
                string[] nombrecolumnas = { "Acciones" };
                
                var parametros = new Dictionary<string, string>();
                parametros.Add("ID_MEDICO", int.Parse(c_med).ToString());
                parametros.Add("FECHA_ATENCION", fecha);
                string[] columnas = { "<a href='#' class='btn btn-info btn-sm btn-icon icon-left' onclick=\"prueba('{0}')\"><i class='entypo-pencil'></i>Reservar</a>", "AGENDA"};
                dt = exec.ExecStoredProcedure("SPREC_HORAS_RESERVA", dataTable, parametros);
                return TEMPLATE.Tabla(dt,NombreTabla, nombrecolumnas, columnas);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public string MuestraHorasxdia(string c_med, string fecha, string NombreTabla = "TablaHorasxdia")
        {
            try
            {
                OracleComand exec = new OracleComand();
                DataTable dataTable = new DataTable();
                DataTable dt = new DataTable();
                string[] nombrecolumnas = {};
                var parametros = new Dictionary<string, string>();
                parametros.Add("ID_MEDICO", int.Parse(c_med).ToString());
                parametros.Add("FECHA_ATENCION", fecha);
                string[] columnas = { };
                dt = exec.ExecStoredProcedure("SPREC_LISTA_HORASXDIA ", dataTable, parametros);
                return TEMPLATE.Tabla(dt, NombreTabla, nombrecolumnas, columnas);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }

}
