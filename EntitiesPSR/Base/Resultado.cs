using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Resultado:ObjetoBase
    {
        public Resultado()
        {
            this.ExisteError = true;
            this.DetalleDeError = string.Empty;
            this.ComandoEjecutado = string.Empty;
        }
        public Resultado(string comandoEjecutado, bool existeError, string detalleDeError)
        {
            this.ExisteError = existeError;
            this.DetalleDeError = detalleDeError;
            this.ComandoEjecutado = comandoEjecutado;
        }
        /// <summary>
        /// Obtiene o establece si existe Erorr al ejecutar el comando
        /// </summary>
        public bool ExisteError { get; set; }
        /// <summary>
        /// Obtiene o establece el detalla del error
        /// </summary>
        public string DetalleDeError { get; set; }
        /// <summary>
        /// Obtiene o establece el comando ejecutado en SQL
        /// </summary>
        public string ComandoEjecutado { get; set; }
        /// <summary>
        /// Obtiene o establece el dato resultado de la ejecucion del query
        /// </summary>
        public object Dato { get; set; }
        /// <summary>
        /// Obtiene o establece el dato resultado de la ejecucion del query
        /// </summary>
        public object Dato2 { get; set; }
        /// <summary>
        /// Obtiene o establece el detalle del error sql
        /// </summary>
        public string DetalleErrorSql { get; set; }
        /// <summary>
        /// Obtiene o establece un mensaje enviado por sql
        /// </summary>
        public string Mensaje { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
