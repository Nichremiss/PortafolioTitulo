using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
    public class Secretaria
    {
        /// <summary>
        /// Obtiene todos los registros de la entidad Secretaria
        /// </summary>
        /// <returns></returns>

        public bool ValidarLoginSecretaria(SecretariaEnt entidad)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            bool retorno;
            try
            {
                //Va a la capa de Datos para ejecutar procedimiento almacenado
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_RUTSECRETARIA", entidad.secretaria_rut);
                _diccionario.Add("V_CLAVESECRETARIA", entidad.secretaria_clave);
                exec.ExecStoredProcedure("SPREC_VALIDARSECRETARIA", out salida, _diccionario);

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
                retorno = false;
            }

            return retorno;
        }


        public bool InsertarSecretaria(SecretariaEnt entidad)
        {
            bool retorno;
            try
            {
                OracleComand exec = new OracleComand();
                var _diccionario = new Dictionary<string, string>();
                _diccionario.Add("V_SECRETARIA_RUT", entidad.secretaria_rut);
                _diccionario.Add("V_SECRETARIA_NOMBRE", entidad.secretaria_nombre);
                _diccionario.Add("V_SECRETARIA_APELLIDO_P", entidad.secretaria_apellido_paterno);
                _diccionario.Add("V_SECRETARIA_APELLIDO_M", entidad.secretaria_apellido_materno);
                _diccionario.Add("V_SECRETARIA_CLAVE", entidad.secretaria_clave);
                _diccionario.Add("V_SECRETARIA_EMAIL", entidad.secretaria_email);

                exec.ExecStoredProcedure("SPINS_INGRESARSECRETARIA", _diccionario);

                //llena datos a tabla usuarios
                string nombreCompleto = entidad.secretaria_nombre + " " + entidad.secretaria_apellido_paterno;
                var _diccionarioUsuario = new Dictionary<string, string>();
                _diccionarioUsuario.Add("PASS", entidad.secretaria_clave);
                _diccionarioUsuario.Add("USU", entidad.secretaria_rut);
                _diccionarioUsuario.Add("NOMBREUSU", nombreCompleto);
                _diccionarioUsuario.Add("TIPOUSU", "1");

                exec.ExecStoredProcedure("SPINS_USUARIOSWEB", _diccionarioUsuario);

                retorno = true;

            }
            catch (System.Exception)
            {
                retorno = false;
            }

            return retorno;

        }

        public bool ValidaDuplicidadSecretaria(SecretariaEnt entidad)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            bool retorno;
            try
            {
                var _dicccionario = new Dictionary<string, string>();
                _dicccionario.Add("V_SECRETARIA_RUT", entidad.secretaria_rut);
                exec.ExecStoredProcedure("SPREC_VALIDASECRETARIADUP", out salida, _dicccionario);
                if (salida =="1")
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            catch (System.Exception)
            {

                retorno=false;
            }

            return retorno;
        }



    }
}
