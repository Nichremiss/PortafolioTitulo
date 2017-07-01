using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Especialidad
    {
        public bool InsertarEspecialidad(EspecialidadEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_ESPECIALIDAD_DESC", entidad.especialidad_desc);
                exec.ExecStoredProcedure("SPINS_INGRESARESPECIALIDAD", _diccionario);
                retorno = true;
            }
            catch (System.Exception)
            {

                retorno = false;
            }
            return retorno;
        }

        public List<EspecialidadEnt> ObtenerEspecialidad()
        {
            OracleComand exec = new OracleComand();
            List<EspecialidadEnt> retorno = new List<EspecialidadEnt>();

            try
            {
                var parametros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SPREC_ESPECIALIDADVALIDAR", dataTable, parametros);

                foreach (DataRow rows in dataTable.Rows)
                {
                    EspecialidadEnt entidad = new EspecialidadEnt();
                    entidad.especialidad_id = rows["ESPECIALIDAD_ID"].ToString();
                    entidad.especialidad_desc = rows["ESPECIALIDAD_DESC"].ToString();

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
    }
}
