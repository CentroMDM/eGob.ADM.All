using System;
using System.Data;
using ClsAccessData;
using MySql.Data.MySqlClient;

namespace DLLPistasDeAuditoria
{
    internal class AuditoriaData
    {
        DataAccess dataAccess = new DataAccess();
        public DataTable GetUsuariosXUnidad(int RIDUnidad)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_GetUsuariosXUnidad", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUnidad, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtUsuarios = new DataTable();
                da.Fill(dtUsuarios);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtUsuarios;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
