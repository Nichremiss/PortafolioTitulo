using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroMedico.Datos;
using System.Data;

namespace CentroMedico.Negocio
{
   public  class Registro
    {

        public string NombreUsuario { get; set; }
        public string Usuario { get; set; }
        public string contrasena { set; get; }


        public RegistroEnt LoginUsuario(string usuario,string contrass)
        {
            OracleComand exec = new OracleComand();
            string salida = "";
            Boolean bolRespuests = false;
            //List<RegistroEnt> retorno = new List<RegistroEnt>();
            RegistroEnt reg = new RegistroEnt();
            try
            {
               
                DataTable dt = new DataTable();
                Dictionary<String, String> datos = new Dictionary<string, string>();
                datos.Add("PASS", contrass);
                datos.Add("USU", usuario);
                exec.ExecStoredProcedure("SPREC_VALIDATIPOUSER", dt, datos);

                foreach (DataRow celda in dt.Rows)
                {

                    bolRespuests = true;
                    reg.NombreUsuario = celda["NOMBREUSUARIO"].ToString();
                    reg.Usuario = celda["USUARIO"].ToString();
                    reg.TipoUsuario = int.Parse(celda["TIPOUSUARIO"].ToString());
                    reg.prevision = celda["PREVISION"].ToString();
                    reg.email = celda["MAIL"].ToString();

                    //retorno.Add(reg);
                }
               
            }
            catch (Exception ex)
            {
                return  null;
            }
            return reg;
        }


    }
}
