using System.Data;
using ClsAccessData;
using ClsBOID;
using EntitiesPSR;
using MySql.Data.MySqlClient;
using Utilerias;

namespace DAOAccesoDatos
{
    public class DAOSetObjetosNegocio
    {
        private readonly DataAccess dataAccess = null;
        public DAOSetObjetosNegocio(DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public DAOSetObjetosNegocio()
        {
            if (this.dataAccess == null)
            {
                this.dataAccess = new DataAccess();
            }
        }









        public (int, string) ObtenerIdentificadoresPSR(TablasAdministracion tablasAdministracion)
        {
            (int, string) identificadores = new BOID().GenNewBOID((int)tablasAdministracion,dataAccess);
            return identificadores;
        }
        public DataTable InsertarRegistro(ProcedimientoAlmacenado sp)
        {
            DataTable resultado = new DataTable();
            MySqlCommand mySql = null;
            try
            {
                mySql = new MySqlCommand(sp.Nombre, this.dataAccess.conn);
                if (mySql.Connection.State == ConnectionState.Closed)
                {
                    AbrirConexion();
                }
                IniciarTransaccion();
                mySql.Transaction = dataAccess.transaction;
                mySql.CommandType = CommandType.StoredProcedure;
                if (sp.ParametrosEnArreglo != null)
                {
                    mySql.Parameters.AddRange(sp.ParametrosEnArreglo);
                }
                IDataReader Ejec = mySql.ExecuteReader();
                resultado.Load(Ejec);
                Ejec.Dispose();
                Ejec.Close();
                TerminarTransaccion();
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
                resultado.Rows.Add(row);
                DeshacerTransaccion();
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



















        public DataTable InsertarRegistrosMultiples(ProcedimientoAlmacenado sp)
        {
            DataTable resultado = new DataTable();
            try
            {
                MySqlCommand mySql = new MySqlCommand(sp.Nombre, this.dataAccess.conn)
                {
                    Transaction = dataAccess.transaction,
                    CommandType = CommandType.StoredProcedure
                };
                if (sp.ParametrosEnArreglo != null)
                {
                    mySql.Parameters.AddRange(sp.ParametrosEnArreglo);
                }
                IDataReader Ejec = mySql.ExecuteReader();
                resultado.Load(Ejec);
                Ejec.Dispose();
                Ejec.Close();
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
                resultado.Rows.Add(row);
            }
            return resultado;
        }
















        public void IniciarTransaccion() {
            dataAccess.BeginTransaction();
        }

        public void TerminarTransaccion() {
            dataAccess.CommitTransaction();
        }

        public void DeshacerTransaccion() {
            dataAccess.Rollback();
        }

        public void AbrirConexion() {
            dataAccess.OpenConnection();
        }

        public void CerrarConexion() {
            dataAccess.CloseConnection();
        }

        //public DataTable InsertarRegistrosMultiples(ProcedimientoAlmacenado sp)
        //{
        //    DataTable resultado = new DataTable();
        //    try
        //    {
        //        MySqlCommand mySql = new MySqlCommand(sp.Nombre, this.dataAccess.conn)
        //        {
        //            Transaction = dataAccess.transaction,
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        if (sp.ParametrosEnArreglo != null)
        //        {
        //            mySql.Parameters.AddRange(sp.ParametrosEnArreglo);
        //        }
        //        IDataReader Ejec = mySql.ExecuteReader();
        //        resultado.Load(Ejec);
        //        Ejec.Dispose();
        //        Ejec.Close();
        //        return resultado;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        resultado = UtilGenerarTablas.GetTablaResultado();
        //        DataRow row = resultado.NewRow();
        //        row["Proceso"] = 0;
        //        row["DetalleDeError"] = ex.Message;
        //        row["DetalleErrorSql"] = ex.Code;
        //        row["Mensaje"] = "Error al realizar al ingresar el SP: " + sp.Nombre;
        //        resultado.Rows.Add(row);
        //    }
        //    return resultado;
        //}

        

    }
}
