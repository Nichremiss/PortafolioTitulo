using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Sucursales
    {
        public bool InsertarSucursal(SucursalEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_SUCURSAL_DIRECCION", entidad.sucursal_direccion);
                _diccionario.Add("V_SUCURSAL_TELEFONO", entidad.sucursal_telefono);
                _diccionario.Add("V_SUCURSAL_NOMBRE", entidad.sucursal_nombre);
                exec.ExecStoredProcedure("SPINS_INGRESARSUCURSAL", _diccionario);
                retorno = true;
            }
            catch (System.Exception)
            {

                retorno=false;
            }
            return retorno;
        }

        public List<SucursalEnt> ObtenerSucursales()
        {
            OracleComand exec = new OracleComand();
            List<SucursalEnt> retorno = new List<SucursalEnt>();
            try
            {
                var parametros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SPREC_SUCURSALVALIDARDATOS", dataTable, parametros);
                foreach (DataRow rows in dataTable.Rows)
                {
                    SucursalEnt entidad = new SucursalEnt();
                    entidad.sucursal_id = rows["SUCURSAL_ID"].ToString();
                    entidad.sucursal_direccion = rows["SUCURSAL_DIRECCION"].ToString();
                    entidad.sucursal_telefono = rows["SUCURSAL_TELEFONO"].ToString();
                    entidad.sucursal_nombre = rows["SUCURSAL_NOMBRE"].ToString();
                    retorno.Add(entidad);
                    entidad = null;
                }
            }
            catch (Exception)
            {

                retorno=null;
            }

            return retorno;
        }
    }
}
