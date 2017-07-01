using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroMedico.Mvc.Models
{
    public class SubirArchivo
    {
        public string Confirmacion { get; set; }
        public Exception error { get; set; }
        public void ConfirmacionHora(string archivo, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(archivo);
                this.Confirmacion = "Archivo Guardado con Exito";
            }
            catch (Exception ex)
            {

                this.error = ex;
            }
        }
    }
}