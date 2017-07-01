using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    public class Secretaria : ISecretaria
    {

        public bool InsertarSecretaria(SecretariaEnt entidad)
        {
            Negocio.Secretaria sec = new Negocio.Secretaria();
       
            return sec.InsertarSecretaria(entidad);
        }

        public bool ValidarLoginSecretaria(SecretariaEnt entidad)
        {
            Negocio.Secretaria sec = new Negocio.Secretaria();
            bool retorno = sec.ValidarLoginSecretaria(entidad);

            return retorno;
        }

        public bool ValidaDuplicidadSecretaria(SecretariaEnt entidad)
        {
            Negocio.Secretaria sec = new Negocio.Secretaria();
            bool retorno = sec.ValidaDuplicidadSecretaria(entidad);
            return retorno;
        }


    }
}
