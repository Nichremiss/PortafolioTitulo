using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Paciente
    {
        /// <summary>
        /// Valida el Login de Paciente
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool ValidarLoginPaciente(PacienteEnt entidad)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            bool retorno;
            try
            {
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_RUTPACIENTE", entidad.paciente_rut);
                _diccionario.Add("V_CLAVEPACIENTE", entidad.paciente_clave);
                exec.ExecStoredProcedure("SPREC_VALIDARPACIENTE", out salida, _diccionario);

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

        public bool InsertarPaciente(PacienteEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_PACIENTE_RUT", entidad.paciente_rut);
                _diccionario.Add("V_PACIENTE_NOMBRE", entidad.paciente_nombre);
                _diccionario.Add("V_APELLIDOP", entidad.paciente_apellido_paterno);
                _diccionario.Add("V_APELLIDOM", entidad.paciente_apellido_materno);
                _diccionario.Add("V_FECHA_NAC", entidad.paciente_fecha_nac);
                _diccionario.Add("V_TELEFONO", entidad.paciente_telefono);
                _diccionario.Add("V_PREVISION", entidad.paciente_prevision);
                _diccionario.Add("V_CLAVE", entidad.paciente_clave);
                _diccionario.Add("V_EMAIL", entidad.paciente_email);
                _diccionario.Add("V_DIRECCION", entidad.paciente_direccion);  
                            
                exec.ExecStoredProcedure("SPINS_INGRESARPACIENTE", _diccionario);

                //llena tabla usuario
                string nomnbreCompleto = entidad.paciente_nombre + " " + entidad.paciente_apellido_paterno;
                var _diccionarioUsuario = new Dictionary<string, string>();
                _diccionarioUsuario.Add("PASS", entidad.paciente_clave);
                _diccionarioUsuario.Add("USU", entidad.paciente_rut);
                _diccionarioUsuario.Add("NOMBREUSU", nomnbreCompleto);
                _diccionarioUsuario.Add("TIPOUSU", "2");
              

                exec.ExecStoredProcedure("SPINS_USUARIOSWEB", _diccionarioUsuario);
                retorno = true;
            }
            catch (System.Exception)
            {

                retorno = false;
            }
            return retorno;
        }

        public List<PacienteEnt> ObtenerPaciente()
        {
            OracleComand exec = new OracleComand();
            List<PacienteEnt> retorno = new List<PacienteEnt>();

            try
            {
                var parametros = new Dictionary<string, string>();
                DataTable dataTable = new DataTable();
                exec.ExecStoredProcedure("SPREC_PACIENTEVALIDARDATOS", dataTable, parametros);

                foreach (DataRow rows in dataTable.Rows)
                {
                    PacienteEnt entidad = new PacienteEnt();
                    entidad.paciente_id = rows["PACIENTE_ID"].ToString();
                    entidad.paciente_prevision = rows["PACIENTE_PREVISION"].ToString();
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

        public bool ValidaDuplicidadPaciente(PacienteEnt entidad)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            bool retorno;
            try
            {
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_PACIENTE_RUT", entidad.paciente_rut);
                exec.ExecStoredProcedure("SPREC_VALIDAPACIENTEDUP", out salida, _diccionario);
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


    }


}
