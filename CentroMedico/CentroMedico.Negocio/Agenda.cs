using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Agenda
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AgendaEnt> ObtenerAgenda()
        {
            OracleComand exec = new OracleComand();
            List<AgendaEnt> retorno = new List<AgendaEnt>();

            try
            {
                var parametros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SP_PRUEBA_SS_3", dataTable, parametros);

                foreach (DataRow rows in dataTable.Rows)
                {
                    AgendaEnt entidad = new AgendaEnt();
                    entidad.agenda_id = rows["AGENDA_ID"].ToString();
                    entidad.agenda_fecha_inicio = rows["AGENDA_FECHA_INICIO"].ToString();
                    entidad.agenda_fecha_termino = rows["AGENDA_FECHA_TERMINO"].ToString();
                    entidad.agenda_medico_id = rows["AGENDA_MEDICO_ID"].ToString();

                    retorno.Add(entidad);
                    entidad = null;
                }
            }
            catch
            {
                retorno = null;
            }

            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool InsertarAgenda(AgendaEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_FECHA_INICIO", entidad.agenda_fecha_inicio);
                _diccionario.Add("V_FECHA_TERMINO", entidad.agenda_fecha_termino);
                _diccionario.Add("V_IDMEDICO", entidad.agenda_medico_id);

                exec.ExecStoredProcedure("SPINS_INGRESARAGENDA", _diccionario);
                retorno = true;
            }
            catch (System.Exception)
            {
                retorno = false;
            }

            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_medico"></param>
        /// <returns></returns>
        public bool ValidaDuplicidadAgendaGen(string id_medico)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            bool retorno;
            try
            {
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_NUM_ID", int.Parse(id_medico).ToString());
                exec.ExecStoredProcedure("SPREC_VALIDA_DUP_AGENDA_GEN ", out salida, _diccionario);

                if (salida == "0")
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            catch (System.Exception ex)
            {

                retorno = false;
            }

            return retorno;
        }
        /// <summary>
        /// trae datos de agendageneral para validar que no se registre agenda diaria fuera de rango establecido
        /// </summary>
        /// <param name="id_medico"></param>
        /// <returns></returns>
        public AgendaEnt Trae_rangosAgendaGralXmedico(string id_medico)
        {
            OracleComand exec = new OracleComand();
            DataTable dt = new DataTable();
            Dictionary<string, string> parametro = new Dictionary<string, string>();
            AgendaEnt ag_ent = new AgendaEnt();
            try
            {
                parametro.Add("V_ID_MEDICO", int.Parse(id_medico).ToString());
                exec.ExecStoredProcedure("SPREC_VAL_INGRE_AGEN_DIA", dt, parametro);

                foreach (DataRow item in dt.Rows)
                {
                    ag_ent.agenda_fecha_inicio = item["FECHA_INICIO"].ToString();
                    ag_ent.agenda_fecha_termino= item["FECHA_TERMINO"].ToString();
                }

            }
            catch (System.Exception ex)
            {

                throw;
            }

            return ag_ent;


        }
    }
}
