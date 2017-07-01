using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Medico
    {
        public bool ValidarLoginMedico(MedicoEnt entidad)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            bool retorno;
            try
            {
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_RUTMEDICO", entidad.medico_rut);
                _diccionario.Add("V_CLAVEMEDICO", entidad.medico_clave);
                exec.ExecStoredProcedure("SPREC_VALIDARMEDICO", out salida, _diccionario);

                if (salida == "1")
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            catch
            {

                retorno=false;
            }

            return retorno;
        }

        public List<MedicoEnt> ObtenerMedicos()
        {
            OracleComand exec = new OracleComand();
            List<MedicoEnt> retorno = new List<MedicoEnt>();

            try
            {
                var parametros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SPREC_MEDICOVALIDADATOS", dataTable, parametros);

                foreach (DataRow rows in dataTable.Rows)
                {
                    MedicoEnt entidad = new MedicoEnt();
                    entidad.medico_id = rows["MEDICO_ID"].ToString();
                    entidad.medico_nombre = rows["MEDICO_NOMBRE"].ToString();
                    entidad.medico_apellido_paterno = rows["MEDICO_APELLIDO_PATERNO"].ToString();

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

        public bool InsertarMedico(MedicoEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_MEDICO_RUT", entidad.medico_rut);
                _diccionario.Add("V_MEDICO_NOMBRE", entidad.medico_nombre);
                _diccionario.Add("V_MEDICO_APELLIDOP", entidad.medico_apellido_paterno);
                _diccionario.Add("V_MEDICO_APELLIDOM", entidad.medico_apellido_materno);
                _diccionario.Add("V_MEDICO_CLAVE", entidad.medico_clave);
                _diccionario.Add("V_MEDICO_EMAIL", entidad.medico_email);
                _diccionario.Add("V_MEDICO_ESPECIALIDAD", entidad.medico_especialidad);
                _diccionario.Add("V_MEDICO_SUCURSAL", entidad.medico_sucursal);

                exec.ExecStoredProcedure("SPINS_INGRESARMEDICO", _diccionario);

                //llena tabla usuarios
                string nombreCompleto = entidad.medico_nombre + " " + entidad.medico_apellido_paterno;
                var _diccionarioUsuario = new Dictionary<string, string>();
                _diccionarioUsuario.Add("PASS", entidad.medico_clave);
                _diccionarioUsuario.Add("USU", entidad.medico_rut);
                _diccionarioUsuario.Add("NOMBREUSU", nombreCompleto);
                _diccionarioUsuario.Add("TIPOUSU", "3");

                exec.ExecStoredProcedure("SPINS_USUARIOSWEB", _diccionarioUsuario);
                retorno = true;

            }
            catch (System.Exception)
            {

                retorno = false;
            }

            return retorno;
        }

        public bool ValidaDuplicidadMedico(MedicoEnt entidad)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            bool retorno;
            try
            {
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_MEDICO_RUT", entidad.medico_rut);
                exec.ExecStoredProcedure("SPREC_VALIDAMEDICODUP", out salida, _diccionario);
                if (salida == "1")
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            catch (Exception)
            {

                retorno=false;
            }
            return retorno;
        }

        public List<MedicoEnt> ObtenerMedicosAgenda()
        {
            OracleComand exec = new OracleComand();
            List<MedicoEnt> retorno = new List<MedicoEnt>();
            try
            {
                var parameros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SPREC_Lista_Medico_Agenda", dataTable, parameros);
                foreach (DataRow rows in dataTable.Rows)
                {
                    MedicoEnt entidad = new MedicoEnt();
                    entidad.medico_id = rows["MEDICO_ID"].ToString();
                    entidad.medico_nombre = rows["MEDICO_NOMBRE"].ToString();
                    entidad.medico_apellido_paterno = rows["MEDICO_APELLIDO_PATERNO"].ToString();
                    entidad.medico_apellido_materno = rows["MEDICO_APELLIDO_MATERNO"].ToString();

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

        public List<MedicoEnt> ObtenerMedicosSinAgenda()
        {
            OracleComand exec = new OracleComand();
            List<MedicoEnt> retorno = new List<MedicoEnt>();
            try
            {
                var parametros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SPREC_Lista_Medico_SinAgenda", dataTable, parametros);
                foreach (DataRow rows in dataTable.Rows)
                {
                    MedicoEnt entidad = new MedicoEnt();
                    entidad.medico_id = rows["MEDICO_ID"].ToString();
                    entidad.medico_nombre = rows["MEDICO_NOMBRE"].ToString();
                    entidad.medico_apellido_paterno = rows["MEDICO_APELLIDO_PATERNO"].ToString();
                    entidad.medico_apellido_materno = rows["MEDICO_APELLIDO_MATERNO"].ToString();
                    retorno.Add(entidad);
                    entidad = null;
                }
            }
            catch
            {

                retorno=null;
            }
            return retorno;
        }
    }
}
