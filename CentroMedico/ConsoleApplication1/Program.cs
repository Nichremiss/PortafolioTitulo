using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using ConsoleApplication1.PrevisionSvc;
using ConsoleApplication1.Medico;
using ConsoleApplication1.Especialidad;
using ConsoleApplication1.AgendaDiaria;
using ConsoleApplication1.SucursalSvc;
using ConsoleApplication1.PacienteSvc;
using ConsoleApplication1.Reserva;
using ConsoleApplication1.SecretariaSvc;
using System.Net.Mail;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrevisionClient prevision = new PrevisionClient();
            //string resultado;
            //resultado = prevision.ObtenerPrevision();
            //Console.WriteLine(resultado);
            //Console.ReadKey();

            //MedicoClient medico = new MedicoClient();
            //string resultado;
            //resultado = medico.ObtenerMedico();
            //Console.WriteLine(resultado);
            //Console.ReadKey();

            //EspecialidadClient espe = new EspecialidadClient();
            //string resultado;
            //resultado = espe.ObtenerEspecialidad();
            //Console.WriteLine(resultado);
            //Console.ReadKey();

            //SucursalesClient suc = new SucursalesClient();
            //string resultado;
            //resultado = suc.ObtenerSucursales();
            //Console.WriteLine(resultado);
            //Console.ReadKey();

            //ReservaClient rev = new ReservaClient();
            //ReservaEnt revent = new ReservaEnt();
            //bool resultados;
            //resultados = rev.CambiarEstadoPacienteEspera(revent);
            //Console.WriteLine(resultados);
            //Console.ReadKey();

            //PacienteClient pac = new PacienteClient();
            //PacienteEnt pacient = new PacienteEnt();
            //bool resultado;
            //resultado = pac.ValidarLoginPaciente(pacient);
            //Console.WriteLine(resultado);
            //Console.ReadKey();

            //MedicoClient med = new MedicoClient();
            //MedicoEnt medico = new MedicoEnt();
            //bool res;
            //res = med.ValidaDuplicidadMedico(medico);
            //Console.WriteLine(res);
            //Console.ReadKey();        

            //SecretariaClient secre = new SecretariaClient();
            //SecretariaEnt secretaria = new SecretariaEnt();
            //bool respuesta;
            //respuesta = secre.ValidaDuplicidadSecretaria(secretaria);
            //Console.WriteLine(respuesta);
            //Console.ReadKey();

            //MedicoClient medico = new MedicoClient();
            //string resultado;
            //resultado = medico.ObtenerMedicosSinAgenda();
            //Console.WriteLine(resultado);
            //Console.ReadKey();


            MailMessage msj = new MailMessage();
            SmtpClient cli = new SmtpClient();
            msj.From = new MailAddress("clothesandshoes87@gmail.com");
            msj.To.Add(new MailAddress(email)); msj.Subject = "Bienvenido";
            msj.Body = "Hola " + name + " bienvenido a Clothes and Shoes";
            msj.IsBodyHtml = false; cli.Host = "smtp.gmail.com";
            cli.Port = 587;
            cli.Credentials = new NetworkCredential("clothesandshoes87@gmail.com", "Mun3745a");
            cli.EnableSsl = true; cli.Send(msj);


        }
    }
}
