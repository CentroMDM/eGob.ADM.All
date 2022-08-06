using System;
using System.Data;
using ClsAccessData;
using MySql.Data.MySqlClient;
using Utilerias;

namespace DAOAccesoDatos
{
    public class DAOGetObjetosNegocio
    {

        private readonly DataAccess dataAccess = null;
        public DAOGetObjetosNegocio(DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public DAOGetObjetosNegocio()
        {
            if (dataAccess == null)
            {
                dataAccess = new DataAccess();
            }
        }

        public DataTable ObtenerConsulta(ProcedimientoAlmacenado sp) {
            DataTable resultado = new DataTable();
            MySqlCommand mySql = new MySqlCommand(sp.Nombre, this.dataAccess.conn);
            try {
                mySql.CommandType = CommandType.StoredProcedure;
                if (sp.ParametrosEnArreglo != null) {
                    mySql.Parameters.AddRange(sp.ParametrosEnArreglo);
                }
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySql);
                dataAdapter.Fill(resultado);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
            }
            catch (Exception ex) {
                resultado = UtilGenerarTablas.GetTablaResultado();
                DataRow row = resultado.NewRow();
                row["Proceso"] = 0;
                row["DetalleDeError"] = ex.Message;
                row["Mensaje"] = "Error al realizar al ingresar el SP: " + sp.Nombre;
                resultado.Rows.Add(row);
            }
            finally
            {
                if (mySql.Connection != null)
                {
                    dataAccess.CloseConnection();
                    dataAccess.KillConnection();
                }
            }
            return resultado;
        }


        public DataSet ObtenerConsultaDataSet(ProcedimientoAlmacenado sp)
        {
            MySqlCommand selectCommand = new MySqlCommand(sp.Nombre, this.dataAccess.conn);
            try
            {
                MySqlParameterCollection parameters = selectCommand.Parameters;
                selectCommand.CommandType = CommandType.StoredProcedure;
                if (sp.ParametrosEnArreglo != null)
                {
                    parameters.AddRange(sp.ParametrosEnArreglo);
                }
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.dataAccess.CloseConnection();
                selectCommand.Dispose();
            }
        }


        //public DataTable ObtenerConsulta(ProcedimientoAlmacenado sp)
        //{
        //    DataTable resultado = new DataTable();
        //    MySqlCommand mySql = new MySqlCommand(sp.Nombre, this.dataAccess.conn);
        //    try
        //    {
        //        mySql.CommandType = CommandType.StoredProcedure;
        //        if (sp.ParametrosEnArreglo != null)
        //        {
        //            mySql.Parameters.AddRange(sp.ParametrosEnArreglo);
        //        }
        //        //mySql.Connection.Open();
        //        IDataReader Ejec = mySql.ExecuteReader();
        //        resultado.Load(Ejec);
        //        Ejec.Dispose();
        //        Ejec.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        resultado = UtilGenerarTablas.GetTablaResultado();
        //        DataRow row = resultado.NewRow();
        //        row["Proceso"] = 0;
        //        row["DetalleDeError"] = ex.Message;
        //        row["DetalleErrorSql"] = ex.Code;
        //        row["Mensaje"] = "Error al realizar al ingresar el SP: " + sp.Nombre;
        //    }
        //    finally
        //    {
        //        if (mySql.Connection != null)
        //        {
        //            mySql.Connection.Close();
        //        }
        //    }
        //    return resultado;
        //}



    }
}
