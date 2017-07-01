using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroMedico.Mvc.Models
{
    public class SecretariaModelo
    {
        private string _secretaria_id;
        private string _secretaria_rut;
        private string _secretaria_nombre;
        private string _secretaria_apellido_paterno;
        private string _secretaria_apellido_materno;
        private string _secretaria_email;

        public string Secretaria_id
        {
            get
            {
                return _secretaria_id;
            }

            set
            {
                _secretaria_id = value;
            }
        }

        public string Secretaria_rut
        {
            get
            {
                return _secretaria_rut;
            }

            set
            {
                _secretaria_rut = value;
            }
        }

        public string Secretaria_nombre
        {
            get
            {
                return _secretaria_nombre;
            }

            set
            {
                _secretaria_nombre = value;
            }
        }

        public string Secretaria_apellido_paterno
        {
            get
            {
                return _secretaria_apellido_paterno;
            }

            set
            {
                _secretaria_apellido_paterno = value;
            }
        }

        public string Secretaria_apellido_materno
        {
            get
            {
                return _secretaria_apellido_materno;
            }

            set
            {
                _secretaria_apellido_materno = value;
            }
        }

        public string Secretaria_email
        {
            get
            {
                return _secretaria_email;
            }

            set
            {
                _secretaria_email = value;
            }
        }
    }
}