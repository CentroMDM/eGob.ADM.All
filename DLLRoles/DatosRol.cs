using EntitiesPSR;
using System;
using MySql.Data.MySqlClient;
using System.Data;
using Utilerias;
using ClsAccessData;

namespace DLLRoles
{
    public class DatosRol
    {
        DataAccess dataAccess = new DataAccess();
        #region RolesPorNivelDeMando
        public DataTable ObtenerNivelMando()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("Sp_Administracion_GetNivelesPuestos", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtNivelesdeMando = new DataTable();
                da.Fill(dtNivelesdeMando);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtNivelesdeMando;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetRolesXNivel()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_GetRolesXNivel", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtRolesXNivel = new DataTable();
                da.Fill(dtRolesXNivel);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtRolesXNivel;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable RolesDeNivel(int RIDNivel)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_RolesDeNivel", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDNivel, ParameterName = "_RIDNivel", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtrolesDelNivel = new DataTable();
                da.Fill(dtrolesDelNivel);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtrolesDelNivel;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable rolesAsignables(int RIDNivel)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_rolesAsignables", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDNivel, ParameterName = "_RIDNivel", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtRolesXNivel = new DataTable();
                da.Fill(dtRolesXNivel);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtRolesXNivel;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable DetalleDeLosRoles(int RIDRol)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_DetalleDeLosRoles", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtDetalleRoles = new DataTable();
                da.Fill(dtDetalleRoles);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtDetalleRoles;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable setNivelRol(ECaracteristicasDeRoles NivelRol)
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Proceso");
            resultado.Columns.Add("DetalleDeError");
            resultado.Columns.Add("DetalleErrorSql");
            resultado.Columns.Add("Mensaje");
            MySqlCommand com = null;
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                com = new MySqlCommand("SSP_setNivelRol", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = NivelRol.RIDNivel, ParameterName = "_ClaveNivelPuesto", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = NivelRol.RIDRol, ParameterName = "_ClaveRol", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();

                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                else
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 0;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "Ocurrió un Error";
                    resultado.Rows.Add(tr);
                }
                com.Dispose();
                com.Connection.Close();
                return resultado;
            }
            catch (MySqlException ex)
            {
                resultado = UtilGenerarTablas.GetTablaResultado();
                DataRow row = resultado.NewRow();
                row["Proceso"] = 0;
                row["DetalleDeError"] = ex.Message;
                row["DetalleErrorSql"] = ex.Code;
                row["Mensaje"] = "Error al realizar SP ";
            }
            finally
            {
                if (com.Connection != null)
                {
                    com.Connection.Close();
                }
            }
            return resultado;
        }
        public DataTable eliminaRolAsignado(ECaracteristicasDeRoles NivelRol)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_eliminaRolAsignado", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = NivelRol.RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = NivelRol.RIDNivel, ParameterName = "_RIDNivel", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtDetalleRoles = new DataTable();
                da.Fill(dtDetalleRoles);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtDetalleRoles;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region ModulosYCaracteristicas
        public DataTable GetTodosLosRoles()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SP_Configuracion_GetTodosLosRoles", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dttodosRoles = new DataTable();
                da.Fill(dttodosRoles);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dttodosRoles;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable Getcataplicaciones()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_Getcat_aplicaciones", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtTodasApps = new DataTable();
                da.Fill(dtTodasApps);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtTodasApps;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable obtenerRolXAplicacion(int RIDApp)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_obtenerRolXAplicacion", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDApp, ParameterName = "_RIDAplicacion", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtRolesXApp = new DataTable();
                da.Fill(dtRolesXApp);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtRolesXApp;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable setNewRol (Ecattodosroles datosDeRol)
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Proceso");
            resultado.Columns.Add("DetalleDeError");
            resultado.Columns.Add("DetalleErrorSql");
            resultado.Columns.Add("Mensaje");
            MySqlCommand com = null;
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                com = new MySqlCommand("SSP_setNewRol", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = datosDeRol.ClaveAplicacion, ParameterName = "_ClaveAplicacion", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = datosDeRol.nombreRol, ParameterName = "_nombreRol", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = datosDeRol.descripcionRol, ParameterName = "_descripcionRol", MySqlDbType = MySqlDbType.VarChar });
                //com.Parameters.Add(new MySqlParameter { Value = datosDeRol.lvlRol, ParameterName = "_lvlRol", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();

                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                else
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 0;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "Ocurrió un Error";
                    resultado.Rows.Add(tr);
                }
                com.Dispose();
                com.Connection.Close();
                return resultado;
            }
            catch (MySqlException ex)
            {
                resultado = UtilGenerarTablas.GetTablaResultado();
                DataRow row = resultado.NewRow();
                row["Proceso"] = 0;
                row["DetalleDeError"] = ex.Message;
                row["DetalleErrorSql"] = ex.Code;
                row["Mensaje"] = "Error al realizar SP ";
            }
            finally
            {
                if (com.Connection != null)
                {
                    com.Connection.Close();
                }
            }
            return resultado;
        }
        public DataTable DeleteRolyRelacionesRol(int RIDRol)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_DeleteRolyRelacionesRol", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtDetalleRoles = new DataTable();
                da.Fill(dtDetalleRoles);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtDetalleRoles;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetNewRol(Ecattodosroles aplicacionRol)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_GetNewRol", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = aplicacionRol.ClaveAplicacion, ParameterName = "_ClaveAplicacion", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = aplicacionRol.nombreRol, ParameterName = "_nombreRol", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtNewRol = new DataTable();
                da.Fill(dtNewRol);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtNewRol;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetModulosXAplicacion(Ecattodosroles aplicacionRol)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_GetModulosXAplicacion", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = aplicacionRol.ClaveAplicacion, ParameterName = "_ClaveAplicacion", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = aplicacionRol.RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtAplicacionRol = new DataTable();
                da.Fill(dtAplicacionRol);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtAplicacionRol;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetModulosCXRol(EModulosCaractAcciones moduloRol)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_GetModulosCXRol", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = moduloRol.RIDModulo, ParameterName = "_ClaveModulo", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = moduloRol.RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtModuloRol = new DataTable();
                da.Fill(dtModuloRol);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtModuloRol;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetAccionXRol(EModulosCaractAcciones caractRol)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_GetAccionXRol", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = caractRol.RIDCaracteristica, ParameterName = "_ClaveCaracteristica", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = caractRol.RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtCaractRol = new DataTable();
                da.Fill(dtCaractRol);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtCaractRol;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }        
        public DataTable Roles_SetAccesosM(EModulosCaractAcciones Modul)
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Proceso");
            resultado.Columns.Add("DetalleDeError");
            resultado.Columns.Add("DetalleErrorSql");
            resultado.Columns.Add("Mensaje");
            MySqlCommand com = null;
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                com = new MySqlCommand("SSP_Roles_SetAccesosM", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = Modul.RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = Modul.RIDModulo, ParameterName = "_ClaveModulo", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();

                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                else
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 0;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "Ocurrió un Error";
                    resultado.Rows.Add(tr);
                }
                com.Dispose();
                com.Connection.Close();
                return resultado;
            }
            catch (MySqlException ex)
            {
                resultado = UtilGenerarTablas.GetTablaResultado();
                DataRow row = resultado.NewRow();
                row["Proceso"] = 0;
                row["DetalleDeError"] = ex.Message;
                row["DetalleErrorSql"] = ex.Code;
                row["Mensaje"] = "Error al realizar SP ";
            }
            finally
            {
                if (com.Connection != null)
                {
                    com.Connection.Close();
                }
            }
            return resultado;
        }
        public DataTable Roles_SetAccesosMC(EModulosCaractAcciones ModulCaract)
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Proceso");
            resultado.Columns.Add("DetalleDeError");
            resultado.Columns.Add("DetalleErrorSql");
            resultado.Columns.Add("Mensaje");
            MySqlCommand com = null;
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                com = new MySqlCommand("SSP_Roles_SetAccesosMC", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = ModulCaract.RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = ModulCaract.RIDModulo, ParameterName = "_ClaveModulo", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = ModulCaract.RIDCaracteristica, ParameterName = "_ClaveCaracteristica", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();

                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                else
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 0;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "Ocurrió un Error";
                    resultado.Rows.Add(tr);
                }
                com.Dispose();
                com.Connection.Close();
                return resultado;
            }
            catch (MySqlException ex)
            {
                resultado = UtilGenerarTablas.GetTablaResultado();
                DataRow row = resultado.NewRow();
                row["Proceso"] = 0;
                row["DetalleDeError"] = ex.Message;
                row["DetalleErrorSql"] = ex.Code;
                row["Mensaje"] = "Error al realizar SP ";
            }
            finally
            {
                if (com.Connection != null)
                {
                    com.Connection.Close();
                }
            }
            return resultado;
        }
        public DataTable Roles_SetAccesosAll(EModulosCaractAcciones ModulCaractAccion)
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Proceso");
            resultado.Columns.Add("DetalleDeError");
            resultado.Columns.Add("DetalleErrorSql");
            resultado.Columns.Add("Mensaje");
            MySqlCommand com = null;
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                com = new MySqlCommand("SSP_Roles_SetAccesosAll", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = ModulCaractAccion.RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = ModulCaractAccion.RIDModulo, ParameterName = "_ClaveModulo", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = ModulCaractAccion.RIDCaracteristica, ParameterName = "_ClaveCaracteristica", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = ModulCaractAccion.RIDAccion, ParameterName = "_ClaveAccionMenu", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();

                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                else
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 0;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "Ocurrió un Error";
                    resultado.Rows.Add(tr);
                }
                com.Dispose();
                com.Connection.Close();
                return resultado;
            }
            catch (MySqlException ex)
            {
                resultado = UtilGenerarTablas.GetTablaResultado();
                DataRow row = resultado.NewRow();
                row["Proceso"] = 0;
                row["DetalleDeError"] = ex.Message;
                row["DetalleErrorSql"] = ex.Code;
                row["Mensaje"] = "Error al realizar SP ";
            }
            finally
            {
                if (com.Connection != null)
                {
                    com.Connection.Close();
                }
            }
            return resultado;
        }
        public DataTable EliminarRaccesoRol(EModulosCaractAcciones RaccesoRol)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_EliminarRaccesoRol", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RaccesoRol.RIDAccesoRol, ParameterName = "_RIDAccesoRol", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtRaccesoRol = new DataTable();
                da.Fill(dtRaccesoRol);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtRaccesoRol;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable UpdateCatRol(Ecattodosroles dataCatRoles)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_UpdateCatRol", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = dataCatRoles.RIDRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = dataCatRoles.ClaveAplicacion, ParameterName = "_ClaveAplicacion", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = dataCatRoles.nombreRol, ParameterName = "_nombreRol", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = dataCatRoles.descripcionRol, ParameterName = "_descripcionRol", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtCatRoles = new DataTable();
                da.Fill(dtCatRoles);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtCatRoles;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region Tipos de Transacciones
        public void IniciarTransaccion()
        {
            dataAccess.BeginTransaction();
        }
        public void TerminarTransaccion()
        {
            dataAccess.CommitTransaction();
        }
        public void DeshacerTransaccion()
        {
            dataAccess.Rollback();
        }
        public void AbrirConexion()
        {
            dataAccess.OpenConnection();
        }
        public void CerrarConexion()
        {
            dataAccess.CloseConnection();
        }
        #endregion
    }
}
