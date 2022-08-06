using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace EntitiesPSR
{
    [Serializable]
    public abstract class ObjetoBase : object, IDisposable
    {
        private bool disposed = false;

        #region Propiedades para uso de transacciones con base de datos

        /// <summary>
        /// Obtiene o establece la transacción
        /// </summary>
        [Category("NoBusqueda")]
        public IDbTransaction Transaction { get; set; }
        /// <summary>
        /// Indica si el objeto está dentro de una transacción
        /// </summary>
        [Category("NoBusqueda")]
        public bool IsTransaction { get; set; }

        #endregion

        #region Metodos base de IDisponsable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Atributos para las tablas de PSR-Ver2
        public DateTime FechaInicio { get; set; }
        public Int64 ClaveStatus { get; set; }
        public DateTime FechaStatus { get; set; }
        public DateTime FechaFin { get; set; }
        public bool EsVisible { get; set; }
        public string DirectorioImagenes { get; set; }
        public string ImagenModelo { get; set; }
        public bool SePuedeEliminar { get; set; }
        #endregion
        /// <summary>
        /// Obtiene una cadena con el nombre del objeto y propiedades, así como los valores de cada propiedad
        /// </summary>
        /// <returns></returns>
        public string ObjetoEnCadena()
        {
            var flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy;
            System.Reflection.PropertyInfo[] infos = this.GetType().GetProperties(flags);
            StringBuilder sb = new StringBuilder();


            string typeName = this.GetType().Name;
            sb.AppendLine("Objeto:  " + typeName);
            sb.AppendLine(string.Empty.PadRight(typeName.Length + 5, '='));

            foreach (var info in infos)
            {
                object value = info.GetValue(this, null);
                if (info.PropertyType.FullName.Contains("System.Collections.Generic.List"))
                {
                    sb.AppendFormat("{0}: {1}{2}", info.Name, "", Environment.NewLine);
                    sb.Append(this.ObtieneDeLista(value, info.Name));
                }
                else
                {
                    if (!info.Name.Contains("Transaction"))
                        sb.AppendFormat("{0}: {1}{2}", info.Name, value ?? "null", Environment.NewLine);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Obtiene una cadena con el nombre del objeto y propiedades, así como los valores de cada propiedad
        /// </summary>
        /// <returns></returns>
        private string ObtieneDeLista(object objeto, string propiedad)
        {
            StringBuilder sb = new StringBuilder();
            int numeroDeElemento = 0;
            IList lista = objeto as IList;
            if (lista.Count > 0)
            {
                Type elementoDelista = lista[0].GetType();
                PropertyInfo[] properties = elementoDelista.GetProperties();
                foreach (object elemento in lista)
                {
                    numeroDeElemento++;
                    string typeName = elemento.GetType().Name;
                    sb.AppendLine(string.Format("{0}{1} Num:{2}", string.Empty.PadRight(propiedad.Length, ' '), typeName, numeroDeElemento.ToString()));
                    foreach (var property in properties)
                    {
                        object value;
                        try
                        {
                            value = property.GetValue(elemento, null);
                        }
                        catch
                        {
                            value = null;
                        }

                        if (!property.Name.Contains("Transaction"))
                            sb.AppendFormat("{0}{1}:{2}{3}", string.Empty.PadLeft(propiedad.Length + typeName.Length + 5, ' '), property.Name, value ?? "null", Environment.NewLine);
                    }
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Obtiene una cadena con el nombre del objeto y propiedades, así como los valores de cada propiedad
        /// </summary>
        /// <returns></returns>
        public static string ObjetoEnCadena(object objeto)
        {
            var flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy;
            System.Reflection.PropertyInfo[] infos = objeto.GetType().GetProperties(flags);
            StringBuilder sb = new StringBuilder();
            _ = objeto.GetType().Name;
            sb.AppendLine(string.Format("\t\t"));

            foreach (var info in infos)
            {
                object value;
                try
                {
                    value = info.GetValue(objeto, null);
                }
                catch
                {
                    value = null;
                }

                if (!info.Name.Contains("Transaction"))
                    sb.AppendFormat("{0}{1}: {2}{3}", "\t\t\t\t", info.Name, value ?? "null", Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
