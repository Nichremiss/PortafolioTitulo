using System;
using System.Collections.Generic;
using CentroMedico.Datos;
using System.Data;
using Newtonsoft.Json;

namespace CentroMedico.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Sucursales" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Sucursales.svc o Sucursales.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Sucursales : ISucursales
    {
        public bool InsertarSucursal(SucursalEnt entidad)
        {
            Negocio.Sucursales suc = new Negocio.Sucursales();
            return suc.InsertarSucursal(entidad);
        }

        public string ObtenerSucursales()
        {
            List<SucursalEnt> retorno = new List<SucursalEnt>();
            Negocio.Sucursales suc = new Negocio.Sucursales();
            retorno = suc.ObtenerSucursales();
            string output = JsonConvert.SerializeObject(retorno);
            return output;
        }
    }
}
