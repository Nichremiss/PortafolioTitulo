using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Registro" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Registro.svc o Registro.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Registro : IRegistro
    {
        public RegistroEnt  LoginUsuario(string usuario, string contrass)
        {
            //List<RegistroEnt> retorno = new List<RegistroEnt>();
            Negocio.Registro reg = new Negocio.Registro();
            RegistroEnt retorno = reg.LoginUsuario(usuario, contrass);
            return retorno;
        }
    }
}
