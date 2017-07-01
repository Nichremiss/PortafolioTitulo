using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CentroMedico.Negocio
{
    public static class TEMPLATE
    {
        public static string Ocultas;

        //public static string Tabla(DataTable dt, string idTablaHTML, string[] Titulos, string[] Reemplazar)
        //{
        //    int filaCabeza = 0, filaCuerpo = 0, filaPies = 0;
        //    string visible = "";
        //    string[] Ocultar = new string[0];
        //    if (!string.IsNullOrEmpty(TEMPLATE.Ocultas))
        //    {
        //        Ocultar = TEMPLATE.Ocultas.Split(new char[] { ',' });
        //    }

        //    string tablahtml = "";

        //    tablahtml += "<table class='table table-bordered datatable' id='" + idTablaHTML + "'>";
        //    tablahtml += "<thead>";
        //    tablahtml += "<tr>";
        //    foreach (DataColumn col in dt.Columns)
        //    {
        //        if (Array.Exists(Ocultar, element => element == filaCabeza.ToString()))
        //        {
        //            visible = "style='display:none;'";
        //        }
        //        else
        //        {
        //            visible = "";
        //        }

        //        tablahtml += "<th " + visible + ">" + col.ColumnName + "</th>";
        //        filaCabeza++;
        //    }
        //    foreach (var item in Titulos)
        //    {
        //        tablahtml += "<th>" + item + "</th>";
        //    }
        //    tablahtml += "</tr>";
        //    tablahtml += "</thead>";
        //    tablahtml += "<tbody>";
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        filaCuerpo = 0;
        //        tablahtml += "<tr class='odd gradeX'>";
        //        foreach (DataColumn col in dt.Columns)
        //        {
        //            if (Array.Exists(Ocultar, element => element == filaCuerpo.ToString()))
        //            {
        //                visible = "style='display:none;'";
        //            }
        //            else
        //            {
        //                visible = "";
        //            }
        //            tablahtml += "<td " + visible + ">" + row[col.ColumnName] + "</td>";
        //            filaCuerpo++;
        //        }
        //        int inc = 0;
        //        foreach (var item in Reemplazar)
        //        {

        //            if (Array.Exists(Ocultar, element => element == filaCuerpo.ToString()))
        //            {
        //                visible = "style='display:none;'";
        //            }
        //            else
        //            {
        //                visible = "";
        //            }
        //            if (inc > 0)
        //            {
        //                string texto = string.Format(Reemplazar[0], row[item].ToString());
        //                tablahtml += "<td " + visible + ">" + texto + "</td>";
        //            }
        //            inc++;
        //        }
        //        tablahtml += "</tr>";

        //    }
        //    tablahtml += "</tbody>";
        //    tablahtml += "<tfoot>";
        //    tablahtml += "<tr>";
        //    foreach (DataColumn col in dt.Columns)
        //    {
        //        if (Array.Exists(Ocultar, element => element == filaPies.ToString()))
        //        {
        //            visible = "style='display:none;'";
        //        }
        //        else
        //        {
        //            visible = "";
        //        }
        //        tablahtml += "<th " + visible + ">" + col.ColumnName + "</th>";
        //        filaPies++;
        //    }
        //    foreach (var item in Titulos)
        //    {
        //        tablahtml += "<th>" + item + "</th>";
        //    }
        //    tablahtml += "</tr>";
        //    tablahtml += "</tfoot>";
        //    tablahtml += "</table>";
        //    return tablahtml;
        //}
        public static string Tabla(DataTable dt, string idTablaHTML, string[] Titulos, string[] Reemplazar, bool ocultaCampos =true)
        {
            int filaCabeza = 0, filaCuerpo = 0, filaPies = 0;
            string visible = "";
            string[] Ocultar = new string[0];
            if (!string.IsNullOrEmpty(TEMPLATE.Ocultas) && ocultaCampos)
            {
                Ocultar = TEMPLATE.Ocultas.Split(new char[] { ',' });
            }

            string tablahtml = "";

            tablahtml += "<table class='table table-bordered datatable' id='" + idTablaHTML + "'>";
            tablahtml += "<thead>";
            tablahtml += "<tr>";
            foreach (DataColumn col in dt.Columns)
            {
                if (Array.Exists(Ocultar, element => element == filaCabeza.ToString()))
                {
                    visible = "style='display:none;'";
                }
                else
                {
                    visible = "";
                }

                tablahtml += "<th " + visible + ">" + col.ColumnName + "</th>";
                filaCabeza++;
            }
            foreach (var item in Titulos)
            {
                tablahtml += "<th>" + item + "</th>";
            }
            tablahtml += "</tr>";
            tablahtml += "</thead>";
            tablahtml += "<tbody>";
            foreach (DataRow row in dt.Rows)
            {
                filaCuerpo = 0;
                tablahtml += "<tr class='odd gradeX'>";
                foreach (DataColumn col in dt.Columns)
                {
                    if (Array.Exists(Ocultar, element => element == filaCuerpo.ToString()))
                    {
                        visible = "style='display:none;'";
                    }
                    else
                    {
                        visible = "";
                    }
                    tablahtml += "<td " + visible + ">" + row[col.ColumnName] + "</td>";
                    filaCuerpo++;
                }
                int inc = 0;
                foreach (var item in Reemplazar)
                {

                    if (Array.Exists(Ocultar, element => element == filaCuerpo.ToString()))
                    {
                        visible = "style='display:none;'";
                    }
                    else
                    {
                        visible = "";
                    }
                    if (inc > 0)
                    {
                        string texto = string.Format(Reemplazar[0], row[item].ToString());
                        tablahtml += "<td " + visible + ">" + texto + "</td>";
                    }
                    inc++;
                }
                tablahtml += "</tr>";

            }
            tablahtml += "</tbody>";
            tablahtml += "<tfoot>";
            tablahtml += "<tr>";
            foreach (DataColumn col in dt.Columns)
            {
                if (Array.Exists(Ocultar, element => element == filaPies.ToString()))
                {
                    visible = "style='display:none;'";
                }
                else
                {
                    visible = "";
                }
                tablahtml += "<th " + visible + ">" + col.ColumnName + "</th>";
                filaPies++;
            }
            foreach (var item in Titulos)
            {
                tablahtml += "<th>" + item + "</th>";
            }
            tablahtml += "</tr>";
            tablahtml += "</tfoot>";
            tablahtml += "</table>";
            return tablahtml;
        }

    }
}
