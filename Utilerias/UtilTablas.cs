using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using EntitiesPSR.AppsRoles;
using EntitiesPSR;

namespace Utilerias
{
    public static class UtilTablas
    {
        public static List<T> ConvertirDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();

            DataTable dtAux = new DataTable();
            dtAux.Columns.Add("column_index");
            dtAux.Columns.Add("property_index");
            DataColumnCollection columnas = dt.Columns;
            Resultado resultado = new Resultado();

            Type temp = typeof(T);

            //Se localiza la posición de los atributos 
            for (int c = 0; c < columnas.Count; c++)
            {
                PropertyInfo[] propiedades = temp.GetProperties();
                for (int p = 0; p < propiedades.Length; p++)
                {
                    if (propiedades[p].Name == columnas[c].ColumnName)
                    {
                        DataRow dtRow = dtAux.NewRow();
                        dtRow["column_index"] = c;
                        dtRow["property_index"] = p;
                        dtAux.Rows.Add(dtRow);
                        break;
                    }
                }
            }

            //Se recorre la tabla para agregar los atributos de cada miembro de la entidad
            for (int t = 0; t < dt.Rows.Count; t++)
            {
                T obj = Activator.CreateInstance<T>();
                PropertyInfo[] propiedades = temp.GetProperties();
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    try
                    {
                        propiedades[int.Parse(dtAux.Rows[c]["property_index"].ToString())].SetValue(obj, dt.Rows[t][c], null);
                    }
                    catch(Exception er)
                    {
                        //Tipo de dato incorrecto... no hace el match 
                        resultado.ExisteError = true;
                        resultado.DetalleDeError = er.Message;
                    }
                }
                data.Add(obj);
            }
            return data;
        }

        public static List<Ebuzonconfiguracionfiltros> ObtenerFiltrosBuzon(DataTable dt, Ecattipofiltrosinicialesbuzon filterInicial)
        {
            List<Ebuzonconfiguracionfiltros> filtrosBuzon = new List<Ebuzonconfiguracionfiltros>();
            Ebuzonconfiguracionfiltros filter;
            foreach (DataRow row in dt.Rows)
            {
                filter = new Ebuzonconfiguracionfiltros
                {
                    ClaveCatalogo = filterInicial.RID,
                    ClaveTipoFiltro = filterInicial.RID
                };
                filter.ClaveCatalogo = int.Parse(row["Value"].ToString());
                filter.Display = row["Display"].ToString();
                filter.Value = (int)row["Value"];
                if (!string.IsNullOrEmpty(row["Descripcion"].ToString()))
                {
                    filter.Descripcion = row["Descripcion"].ToString();
                }
                filtrosBuzon.Add(filter);
            }
            return filtrosBuzon;
        }

        public static Resultado ResultadoDesdeTabla(DataTable table)
        {
            Resultado resultado = new Resultado();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    resultado.ExisteError = long.Parse(row["Proceso"].ToString()) <= 0;
                    resultado.DetalleDeError = row["DetalleDeError"].ToString();
                    resultado.DetalleErrorSql = row["DetalleErrorSql"].ToString();
                    resultado.Mensaje = row["Mensaje"].ToString();
                    if (table.Columns.Contains("Dato")){
                        resultado.Dato = row.IsNull("Dato") ? string.Empty : row["Dato"].ToString();
                    }
                }
            }
            else
            {
                resultado.ExisteError = true;
                resultado.DetalleDeError = "Error desconocido";
            }
            return resultado;
        }

        public static List<ECat_AplicacionesModulos> dtToListConfigARC (DataTable dtARC)
        {
            try
            {
                List<ECat_AplicacionesModulos> ListARC = new List<ECat_AplicacionesModulos>();

                //DataTable dtARC = new DataLogin().GetConfiguracionARC(ClaveUsuario, ClaveAplicacion, ClaveBuzon);

                string nombreModulo = String.Empty;

                foreach (DataRow rModulo in dtARC.Rows)
                {
                    if (nombreModulo != rModulo["NombreModulo"].ToString())
                    {
                        nombreModulo = rModulo["NombreModulo"].ToString();

                        ECat_AplicacionesModulos modulo = new ECat_AplicacionesModulos();
                        modulo.RIDModulo = Convert.ToInt32(rModulo["RIDModulo"].ToString());
                        modulo.Orden = Convert.ToInt32(rModulo["OrdenModulo"].ToString());
                        modulo.NombreModulo = rModulo["NombreModulo"].ToString();
                        modulo.DireccionURL = rModulo["DireccionURLModulo"].ToString();

                        modulo.ListCaracteristicas = new List<ECat_AplicacionesModulosC>();


                        string nombreCaracteristica = String.Empty;
                        foreach (DataRow rCaracteristica in dtARC.Rows)
                        {
                            if (nombreModulo == rCaracteristica["NombreModulo"].ToString())
                            {
                                if (nombreCaracteristica != rCaracteristica["NombreCaracteristicas"].ToString())
                                {
                                    nombreCaracteristica = rCaracteristica["NombreCaracteristicas"].ToString();

                                    ECat_AplicacionesModulosC Caracteristica = new ECat_AplicacionesModulosC();

                                    Caracteristica.ClaveModulo = Convert.ToInt32(rCaracteristica["ClaveModulo"].ToString());
                                    Caracteristica.Orden = Convert.ToInt32(rCaracteristica["OrdenCaracteristica"].ToString());
                                    Caracteristica.NombreCaracteristicas = rCaracteristica["NombreCaracteristicas"].ToString();
                                    Caracteristica.IconFontawesome = rCaracteristica["IconFontawesomeCaracteristica"].ToString();
                                    Caracteristica.DireccionURL = rCaracteristica["DireccionURLCaracteristica"].ToString();
                                    Caracteristica.ListAcciones = new List<ECat_MenuAcciones>();
                                    int RIDAccion = 0;
                                    foreach (DataRow rAccion in dtARC.Rows)
                                    {
                                        if (nombreCaracteristica == rAccion["NombreCaracteristicas"].ToString())
                                        {
                                            if ((!String.IsNullOrEmpty(rAccion["RIDAccion"].ToString())) && (RIDAccion != Convert.ToInt32(rAccion["RIDAccion"].ToString())))
                                            {
                                                RIDAccion = Convert.ToInt32(rAccion["RIDAccion"].ToString());

                                                ECat_MenuAcciones Accion = new ECat_MenuAcciones();

                                                Accion.RIDAccion = Convert.ToInt32(rAccion["RIDAccion"].ToString());
                                                Accion.Orden = Convert.ToInt32(rAccion["OrdenAccion"].ToString());
                                                Accion.Nombre = rAccion["NombreAccion"].ToString();
                                                Caracteristica.ListAcciones.Add(Accion);
                                            }
                                        }
                                    }
                                    modulo.ListCaracteristicas.Add(Caracteristica);
                                }
                            }
                        }
                        ListARC.Add(modulo);
                    }
                }
                return ListARC;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
