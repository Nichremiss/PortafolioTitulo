using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentroMedico.Vista.SecretariaSvc;

namespace CentroMedico.Vista
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SecretariaClient servicio = new SecretariaClient();
            string respuesta = string.Empty;
            respuesta = servicio.ObtenerSecretaria();




        }
    }
}