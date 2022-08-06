using System.Data;
using ClsAccessData;
using MySql.Data.MySqlClient;
using Utilerias;

namespace DAOAccesoDatos
{
    public class DAOUpdateorDeleteObjetosNegocio
    {
        private readonly DataAccess dataAccess = null;
        public DAOUpdateorDeleteObjetosNegocio(DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public DAOUpdateorDeleteObjetosNegocio()
        {
            if (this.dataAccess == null)
            {
                this.dataAccess = new DataAccess();
            }
        }

        private void IniciarTransaccion()
        {
            dataAccess.BeginTransaction();
        }

        private void TerminarTransaccion()
        {
            dataAccess.CommitTransaction();
        }

        private void DeshacerTransaccion()
        {
            dataAccess.Rollback();
        }

        public DataTable UpdateOrDeleteRegistro(ProcedimientoAlmacenado sp)
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Proceso");
            resultado.Columns.Add("DetalleDeError");
            resultado.Columns.Add("DetalleErrorSql");
            resultado.Columns.Add("Mensaje");
            
            MySqlCommand mySql = null;
            try
            {
                mySql = new MySqlCommand(sp.Nombre, this.dataAccess.conn);
                mySql.Connection.Open();
                //IniciarTransaccion();
                mySql.Transaction = dataAccess.transaction;
                mySql.CommandType = CommandType.StoredProcedure;
                if (sp.ParametrosEnArreglo != null)
                {
                    mySql.Parameters.AddRange(sp.ParametrosEnArreglo);
                }
                //IDataReader Ejec = mySql.ExecuteReader();
                //MySqlCommand Eject = new MySqlCommand();
                int intResultado = mySql.ExecuteNonQuery();

                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                else {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 0;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "Ocurrió un Error";
                    resultado.Rows.Add(tr);
                }
                
                //TerminarTransaccion();
                mySql.Dispose();
                mySql.Connection.Close();
                return resultado;
            }
            catch (MySqlException ex)
            {
                resultado = UtilGenerarTablas.GetTablaResultado();
                DataRow row = resultado.NewRow();
                row["Proceso"] = 0;
                row["DetalleDeError"] = ex.Message;
                row["DetalleErrorSql"] = ex.Code;
                row["Mensaje"] = "Error al realizar al ingresar el SP: " + sp.Nombre;
                //DeshacerTransaccion();
            }
            finally
            {
                if (mySql.Connection != null)
                {
                    mySql.Connection.Close();
                }
            }
            return resultado;
        }


    }
}
