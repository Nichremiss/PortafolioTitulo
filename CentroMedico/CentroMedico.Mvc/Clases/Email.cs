
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
namespace CentroMedico.Mvc.Clases
{

    public class Email
    {
        public string correo { get; set; }
        public class Correo
        {
            public string correo { get; set; }
            public string pass { get; set; }

            SmtpClient server = new SmtpClient();

            public Correo()
            {
                correo = "nichremiss@gmail.com";
                pass = "nicolas21";
                server.UseDefaultCredentials = false;
                server.Credentials = new System.Net.NetworkCredential(correo, pass);
                server.EnableSsl = true;
                server.Host = "smtp.gmail.com";
                server.Port = 587;

            }

            public void EnviarCorreo(MailMessage correo)
            {
                server.Send(correo);
            }
        }

        static bool mailSent = false;
        private static void pruebaCorreo(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
    }
}