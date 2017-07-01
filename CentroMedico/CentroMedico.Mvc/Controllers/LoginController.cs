using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroMedico.Mvc.AgendaSvc;
using System.Web.Script.Serialization;
using CentroMedico.Mvc.RegistroSvc;
using CentroMedico.Datos;




namespace CentroMedico.Mvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Logout()
        {

            return View();


        }

        public ActionResult Bienvenida()
        {

            return View();


        }
        //Funcion que consultaa la bdd tipo de usuario, y datos de este para iniciar Sesiones
        [HttpPost]
       public bool ValidadorCredenciales(string usu, string passw)
        { 
            RegistroClient reg = new RegistroClient();
            RegistroEnt regEnt = new RegistroEnt();
            regEnt = reg.LoginUsuario(usu, Encriptar(passw));
            //regEnt = reg.LoginUsuario(usu, passw);

            if (regEnt.NombreUsuario != null)
            {
                Session["Usuario"] = regEnt.Usuario;
                Session["NombreUsuario"] = regEnt.NombreUsuario;
                Session["TipoUsuario"] = regEnt.TipoUsuario;
              

                //Si el tipo de usuario es 2 Paciente se inicia session previsión

                if (int.Parse(Session["TipoUsuario"].ToString()) == 2)
                {
                    Session["Prevision"] = regEnt.prevision;
                    Session["CorreoUsuario"] = regEnt.email;
                }


                return true;
            }
            else
            {
                return false;
            }
          
        }


        private static string Encriptar(string _cadena)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadena);
            result = Convert.ToBase64String(encryted);
            return result;
        }

    }
}

