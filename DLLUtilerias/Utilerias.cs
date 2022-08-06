using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using EntitiesPSR;


namespace DLLUtilerias
{
    public class Utilerias
    {
        public List<T> Convertir<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            PropertyInfo[] Prop = typeof(T).GetProperties();

            //Se localiza la posición de los atributos 
            DataTable dtMatchIndex = new DataTable();
            dtMatchIndex.Columns.Add("column_index");
            dtMatchIndex.Columns.Add("property_index");
            for (int c = 0; c < dt.Columns.Count; c++)
                for (int p = 0; p < Prop.Length; p++)
                    if (Prop[p].Name == dt.Columns[c].ColumnName)
                    {
                        dtMatchIndex.Rows.Add(c, p); break;
                    }
            //Se recorre la tabla para agregar los atributos de cada miembro de la entidad
            for (int tableRow = 0; tableRow < dt.Rows.Count; tableRow++)
            {
                T obj = Activator.CreateInstance<T>();
                for (int tableColumn = 0; tableColumn < dt.Columns.Count; tableColumn++)
                {
                    try
                    {
                        if (dt.Rows[tableRow][tableColumn].GetType().Name != "DBNull")
                            Prop[int.Parse(dtMatchIndex.Rows[tableColumn]["property_index"].ToString())].SetValue(obj, dt.Rows[tableRow][tableColumn]);
                        else
                            Prop[int.Parse(dtMatchIndex.Rows[tableColumn]["property_index"].ToString())].SetValue(obj, default);
                    }
                    catch (Exception er)
                    {
                        throw new Exception("No se puede hacer match: " + dt.Columns[tableColumn].ColumnName + "[" + tableRow + "] tipo " + dt.Rows[tableRow][tableColumn].GetType().Name + " != " + Prop[int.Parse(dtMatchIndex.Rows[tableColumn]["property_index"].ToString())].PropertyType.Name, er);
                    }
                }
                data.Add(obj);
            }
            return data;
        }

        public List<Ebuzonconfiguracionfiltros> ObtenerFiltrosBuzon(DataTable dt, Ecattipofiltrosinicialesbuzon filterInicial)
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

        public Resultado ResultadoDesdeTabla(DataTable table)
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
                    if (table.Columns.Contains("Dato"))
                    {
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

        public DataTable GetTablaResultado()
        {
            DataTable dtRespuesta = new DataTable();
            dtRespuesta.Columns.Add(new DataColumn("ExisteError", typeof(bool)));
            dtRespuesta.Columns.Add(new DataColumn("DetalleDeError", typeof(string)));
            dtRespuesta.Columns.Add(new DataColumn("ComandoEjecutado", typeof(string)));
            dtRespuesta.Columns.Add(new DataColumn("Dato", typeof(object)));
            dtRespuesta.Columns.Add(new DataColumn("Dato2", typeof(object)));
            dtRespuesta.Columns.Add(new DataColumn("DetalleErrorSql", typeof(string)));
            dtRespuesta.Columns.Add(new DataColumn("Mensaje", typeof(string)));
            dtRespuesta.Columns.Add(new DataColumn("Proceso", typeof(long)));
            return dtRespuesta;
        }

        public string guardarImagen(string strpath, HttpPostedFile file)
        {
            //subir imagen en la ruta
            try
            {
                Guid g;
                g = Guid.NewGuid();

                if (!Directory.Exists(strpath))
                    Directory.CreateDirectory(strpath);
                string pic = g.ToString();
                pic = pic + file.FileName.Substring(file.FileName.ToString().LastIndexOf('.'));
                string strpathFinal = System.IO.Path.Combine(strpath, pic);
                file.SaveAs(strpathFinal);
                return pic;
                //return file.FileName;
            }
            catch (Exception er)
            {
                return er.Message;
            }

        }
    }
}