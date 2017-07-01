using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Prevision
    {
        public bool InsertarPrevision(PrevisionEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_PREVISION_DESC", entidad.prevision_desc);
                exec.ExecStoredProcedure("SPINS_INGRESARPREVISION", _diccionario);
                retorno = true;
            }
            catch (System.Exception)
            {

                retorno = false;
            }
            return retorno;
        }

        public List<PrevisionEnt> ObtenerPrevision()
        {
            OracleComand exec = new OracleComand();
            List<PrevisionEnt> retorno = new List<PrevisionEnt>();
            try
            {
                var parametros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SPREC_PREVISIONVALIDARDATOS", dataTable, parametros);
                foreach (DataRow rows in dataTable.Rows)
                {
                    PrevisionEnt entidad = new PrevisionEnt();
                    entidad.prevision_id = rows["PREVISION_ID"].ToString();
                    entidad.prevision_desc = rows["PREVISION_DESC"].ToString();
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
