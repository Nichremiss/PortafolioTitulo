using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Text;

using System.Net.Mail;
using System.Net;


namespace CentroMedico.Mvc.Clases
{
    public class CORREO
    {
        public static bool EnviarCorreo(string Destinatario, string Asunto, string Mensaje, string Emisor)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(Destinatario);

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = Asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //  mmsg.Bcc.Add("cla.olivaresa@alumnos.duoc.cl"); Opcional

            //Cuerpo del Mensaje
            mmsg.Body = Mensaje;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(Emisor);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential("centro.med.galenos@gmail.com", "adminadmin123");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
           
            cliente.Port = 587;
            cliente.EnableSsl = true;
            

            cliente.Host = "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                return true;
            }
           catch (System.Net.Mail.SmtpException ex)
            {
                return false;
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }

        public static bool EnviarCorreo(string[] Destinatarios, string Asunto, string Mensaje, string Emisor)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            foreach (var item in Destinatarios)
            {
                mmsg.To.Add(item);
            }

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = Asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("cla.olivaresa@alumnis.duoc.cl"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = Mensaje;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(Emisor);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential("centro.med.galenos@gmail.com", "adminadmin123");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            /*
            cliente.Port = 587;
            cliente.EnableSsl = true;
            */

            cliente.Host = "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }

        public static string PlantillaCorreo(string Nombres, string Asunto, string Mensaje, string Firma)
        {
            string HTML = "";
            string Cuerpo = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath("~/Scripts/assets/"), "tlp.correo.html"));
            string CSS = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath("~/Scripts/assets/"), "tlp.correo.css"));

            HTML += @"<html>
	                    <head>
		                    <META http-equiv='Content-Type' content='text/html; charset=utf-8'>
		                    <meta content='text/html; charset=utf-8' http-equiv='Content-Type'>
		                    <title>Notificaciones ::Centro Médico Galenos</title>
		                    <style type='text/css'>";
            HTML += CSS;
            HTML += @"</style>
	                    </head>
	                    <body bgcolor='#E5E5E5' style='background-color: #e5e5e5'>";

            HTML += String.Format(Cuerpo, Asunto, Nombres, Mensaje, Firma);

            HTML += @"	</body>
                    </html>";

            return HTML.Replace("\t", "");
            //    }

            //    using(SmtpClient cliente = new SmtpClient("aspmx.l.google.com", 25))
            //        {
            //            cliente.EnableSsl = true;
            //            cliente.Credentials = new NetworkCredential("CORREO A USAR", "CONTRASEÑA DEL CORREO");
            //MailMessage mensaje = new MailMessage("QUIEN ENVIA EL CORREO", "QUIEN RECIBE EL CORREO", "ASUNTO DEL CORREO", "MENSAJE 		DE CORREO");
            //cliente.Send(mensaje);
            //        }



        }
    }
}