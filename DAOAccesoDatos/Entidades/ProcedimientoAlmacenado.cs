using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public class ProcedimientoAlmacenado
    {
        private readonly List<MySqlParameter> parametros;
        public ProcedimientoAlmacenado()
        {
            this.parametros = new List<MySqlParameter>();
            this.Nombre = string.Empty;
        }
        public ProcedimientoAlmacenado(string nombreDeProcedimiento)
        {
            this.parametros = new List<MySqlParameter>();
            this.Nombre = nombreDeProcedimiento;
        }

        /// <summary>
        /// Obtiene o establece el nombre del procedimiento almacenado que se va a ejecutar
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Obtiene la lista de los parametros que recibe el procedimiento almacenado
        /// </summary>
        public List<MySqlParameter> Parametros
        {
            get { return parametros; }
        }
        /// <summary>
        /// Obtiene la lista de los parametros del procedimiento almacenado como arreglo, si no existen datos
        /// regresa nulo
        /// </summary>
        public MySqlParameter[] ParametrosEnArreglo
        {
            get { return this.parametros.Count > 0 ? this.parametros.ToArray() : null; }
        }

        /// <summary>
        /// Obtiene la sentencia SQL que se va a ejecutar o fue ejecutada, Ejemplo: si el spPrueba @parametro1 = 1,@parametro2 = 'Dato',@parametro3 = '01/01/1900'
        /// segun sea la cantidad de parametros que tenga el Procedimiento almacenado
        /// </summary>
        /// <returns></returns>
        public string SentenciaSQL
        {
            get
            {
                StringBuilder sbCadena = new StringBuilder();
                string respuesta = string.Empty;
                if (!string.IsNullOrEmpty(this.Nombre))
                {
                    sbCadena.AppendFormat("{0} ", this.Nombre);
                    sbCadena.Append("(");
                    foreach (MySqlParameter parametro in parametros)
                    {
                        sbCadena.AppendFormat("{0},", this.GetParametroParaSp(parametro));
                    }

                    if (parametros.Count > 0)
                    {
                        respuesta = sbCadena.ToString().Substring(0, sbCadena.ToString().Length - 1);
                    }
                    else
                        respuesta = sbCadena.ToString();
                }
                return respuesta + ")";
            }
        }

        public void NuevoParametro(string nombreDeParametro, MySqlDbType tipoDeDato, object valor)
        {
            if (string.IsNullOrEmpty(nombreDeParametro.Trim()))
            {
                throw new Exception("Se requiere del nombre del nuevo parametro para el procedimiento almacenado");
            }

            if (valor == null)
                this.parametros.Add(GetNuevoParametro(nombreDeParametro, tipoDeDato, null, true));
            else
                this.parametros.Add(GetNuevoParametro(nombreDeParametro, tipoDeDato, valor));
        }

        #region Propiedades Publicas y estaticas

        /// <summary>
        /// Genera y obtine una parametro
        /// </summary>
        /// <param name="nombreDeParametro">Nombre que tendra el parametro, sin la @</param>
        /// <param name="tipoDeDato">tipo de dato que almacena</param>
        /// <param name="valor">Valor que se asigna</param>
        /// <returns></returns>
        public static MySqlParameter GetNuevoParametro(string nombreDeParametro, MySqlDbType tipoDeDato, object valor)
        {
            MySqlParameter param = new MySqlParameter
            {
                ParameterName = string.Format("@{0}", nombreDeParametro),
                MySqlDbType = tipoDeDato,
                Value = valor
            };

            return param;
        }
        /// <summary>
        /// Genera y obtine una parametro
        /// </summary>
        /// <param name="nombreDeParametro">Nombre que tendra el parametro, sin la @</param>
        /// <param name="tipoDeDato">tipo de dato que almacena</param>
        /// <param name="valor">Valor que se asigna</param>
        /// <param name="permiteValorNulo">Indica si el campo permite valores Nulos</param>
        /// <returns></returns>
        public static MySqlParameter GetNuevoParametro(string nombreDeParametro, MySqlDbType tipoDeDato, object valor, bool permiteValorNulo)
        {
            MySqlParameter param = new MySqlParameter
            {
                ParameterName = string.Format("@{0}", nombreDeParametro),
                MySqlDbType = tipoDeDato,
                IsNullable = permiteValorNulo
            };
            switch (tipoDeDato)
            {
                case MySqlDbType.Bit:
                    break;
                case MySqlDbType.Binary:
                case MySqlDbType.Blob:
                case MySqlDbType.Byte:
                case MySqlDbType.Date:
                case MySqlDbType.DateTime:
                case MySqlDbType.Decimal:
                case MySqlDbType.Double:
                case MySqlDbType.Enum:
                case MySqlDbType.Float:
                case MySqlDbType.Geometry:
                case MySqlDbType.Guid:
                case MySqlDbType.Int16:
                case MySqlDbType.Int24:
                case MySqlDbType.Int32:
                case MySqlDbType.Int64:
                case MySqlDbType.JSON:
                case MySqlDbType.LongBlob:
                case MySqlDbType.LongText:
                case MySqlDbType.MediumBlob:
                case MySqlDbType.MediumText:
                case MySqlDbType.Newdate:
                case MySqlDbType.NewDecimal:
                case MySqlDbType.Set:
                case MySqlDbType.String:
                case MySqlDbType.Text:
                case MySqlDbType.Time:
                case MySqlDbType.Timestamp:
                case MySqlDbType.TinyBlob:
                case MySqlDbType.TinyText:
                case MySqlDbType.UByte:
                case MySqlDbType.UInt16:
                case MySqlDbType.UInt24:
                case MySqlDbType.UInt32:
                case MySqlDbType.UInt64:
                case MySqlDbType.VarBinary:
                case MySqlDbType.VarChar:
                case MySqlDbType.VarString:
                case MySqlDbType.Year:
                    param.Value = valor;
                    break;
                default:
                    param.Value = permiteValorNulo ? null : valor;
                    break;
            }
            return param;
        }

        #endregion      

        /// <summary>
        /// Obtiene la cadena del procedimiento almacenado que se ejecuta, con los datos que se envian para ejecucion
        /// </summary>
        /// <param name="Sqlparametro"></param>
        /// <returns></returns>
        private string GetParametroParaSp(MySqlParameter Sqlparametro)
        {
            StringBuilder respuesta = new StringBuilder();
            switch (Sqlparametro.MySqlDbType)
            {
                case MySqlDbType.Bit:
                    if (Sqlparametro.Value != null)
                        respuesta.AppendFormat("{0}:={1}", Sqlparametro.ParameterName, (bool)Sqlparametro.Value ? 1 : 0);
                    else
                        respuesta.AppendFormat("{0}:={1}", Sqlparametro.ParameterName, "NULL");
                    break;
                case MySqlDbType.Decimal:
                case MySqlDbType.NewDecimal:
                case MySqlDbType.Float:
                case MySqlDbType.Int16:
                case MySqlDbType.Int24:
                case MySqlDbType.Int32:
                case MySqlDbType.Int64:
                case MySqlDbType.Double:
                case MySqlDbType.UByte:
                case MySqlDbType.UInt16:
                case MySqlDbType.UInt24:
                case MySqlDbType.UInt32:
                case MySqlDbType.UInt64:
                    if (Sqlparametro.Value != null)
                        respuesta.AppendFormat("{0}:={1}", Sqlparametro.ParameterName, Sqlparametro.Value);
                    else
                        respuesta.AppendFormat("{0}:={1}", Sqlparametro.ParameterName, "NULL");
                    break;
                case MySqlDbType.VarChar:
                case MySqlDbType.String:
                case MySqlDbType.TinyText:
                case MySqlDbType.MediumText:
                case MySqlDbType.LongText:
                case MySqlDbType.Text:
                case MySqlDbType.Guid:
                case MySqlDbType.JSON:
                case MySqlDbType.VarBinary:
                case MySqlDbType.Binary:
                    if (Sqlparametro.Value != null)
                        respuesta.AppendFormat("{0}:='{1}'", Sqlparametro.ParameterName, Sqlparametro.Value.ToString());
                    else
                        respuesta.AppendFormat("{0}:={1}", Sqlparametro.ParameterName, "NULL");
                    break;
                case MySqlDbType.Newdate:
                case MySqlDbType.Timestamp:
                case MySqlDbType.Date:
                case MySqlDbType.Time:
                case MySqlDbType.DateTime:
                    if (Sqlparametro.Value != null)
                        respuesta.AppendFormat("{0}:='{1}'", Sqlparametro.ParameterName, Sqlparametro.Value.ToString());
                    else
                        respuesta.AppendFormat("{0}:={1}", Sqlparametro.ParameterName, "NULL");
                    break;

                default:
                    if (Sqlparametro.Value != null)
                        respuesta.AppendFormat("{0}:='{1}'", Sqlparametro.ParameterName, Sqlparametro.Value.ToString());
                    else
                        respuesta.AppendFormat("{0}:={1}", Sqlparametro.ParameterName, "NULL");
                    break;
            }
            return respuesta.ToString();
        }
    }
}
