using ClsAccessData;
using EntitiesPSR;
using System;
using MySql.Data.MySqlClient;
using System.Data;
using DLLUtilerias;

namespace DLLImplementacion
{
    public class DatosImplementacion
    {
        readonly DataAccess dataAccess = new DataAccess();
        public DataTable GetImplementacion()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("Sp_Administracion_Gettimplementacion", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtImplementacion = new DataTable();
                da.Fill(dtImplementacion);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtImplementacion;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetNiveldeGobierno()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SP_Configuracion_GetNivelesGobierno", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtImplementacion = new DataTable();
                da.Fill(dtImplementacion);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtImplementacion;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetCatAplicaciones()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SP_Administracion_Getcataplicaciones", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtImplementacion = new DataTable();
                da.Fill(dtImplementacion);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtImplementacion;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetImpEntidadesFederativas()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("Sp_Administracion_GetImpEntidadesFederativas", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtImplementacion = new DataTable();
                da.Fill(dtImplementacion);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtImplementacion;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable GetImpMunicipios(EcatcpEntidadesFederativas entidades)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("Sp_Administracion_GetImpMunicipios", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = entidades.RIDEntidad, ParameterName = "_ClaveEntidad", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtImplementacion = new DataTable();
                da.Fill(dtImplementacion);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtImplementacion;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable ObtenerCodigoPostalMunicipio(int municipio)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SP_Administracion_GetCodigoPostalMunicipio", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = municipio, ParameterName = "_ClaveMunicipio", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtImplementacion = new DataTable();
                da.Fill(dtImplementacion);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtImplementacion;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable ObtenerColoniasCP(string codigoPostal)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("Sp_Administracion_GetColoniaCP", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = codigoPostal, ParameterName = "_CP", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtImplementacion = new DataTable();
                da.Fill(dtImplementacion);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtImplementacion;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable CargarImagenImplementacion()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SP_GPObtenerParametrosServidor", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtPuestos = new DataTable();
                da.Fill(dtPuestos);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtPuestos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable Setimplementacion(Etimplementacion implementacion)
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

                com = new MySqlCommand("Sp_Administracion_SetImplementacion", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = implementacion.RIDImplementacion, ParameterName = "_RIDImplementacion", MySqlDbType = MySqlDbType.Int64 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.GUIDImplementacion, ParameterName = "_GUIDImplementacion", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.Nombre, ParameterName = "_Nombre", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.NombreTema, ParameterName = "_NombreTema", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ModoTema, ParameterName = "_ModoTema", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.Lema, ParameterName = "_Lema", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ClaveDirectorioLogoImplementacion, ParameterName = "_ClaveDirectorioLogoImplementacion", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.FaviconDirectorioSecundario, ParameterName = "_FaviconDirectorioSecundario", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.LogoDirectorioSecundario, ParameterName = "_LogoDirectorioSecundario", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ImagenHomeDirectorioSecundario, ParameterName = "_ImagenHomeDirectorioSecundario", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.Estado, ParameterName = "_Estado", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ClaveMunicipio, ParameterName = "_ClaveMunicipio", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.claveNivelGobierno, ParameterName = "_ClaveNivelGobierno", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.claveEntidadNivelGobierno, ParameterName = "_ClaveEntidadNivelGobierno", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.claveMunicipioNivelGobierno, ParameterName = "_ClaveMunicipioNivelGobierno", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.CodigoPostal, ParameterName = "_CodigoPostal", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ClaveCP, ParameterName = "_ClaveCP", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.Calle, ParameterName = "_Calle", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.NumExt, ParameterName = "_NumExt", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.NumInt, ParameterName = "_NumInt", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.NombreAbreviado, ParameterName = "_NombreAbreviado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.HorarioInicioLaboral.ToString("yyyy-MM-dd HH:mm:ss"), ParameterName = "_HorarioInicioLaboral", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.HorarioFinLaboral.ToString("yyyy-MM-dd HH:mm:ss"), ParameterName = "_HorarioFinLaboral", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"), ParameterName = "_FechaInicio", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.FechaFin.ToString("yyyy-MM-dd HH:mm:ss"), ParameterName = "_FechaFin", MySqlDbType = MySqlDbType.VarChar });
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
                resultado = new Utilerias().GetTablaResultado();
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
        public DataTable Updatetimplementacion(Etimplementacion implementacion)
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

                com = new MySqlCommand("Sp_Administracion_Updatetimplementacion", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = implementacion.RIDImplementacion, ParameterName = "_RIDImplementacion", MySqlDbType = MySqlDbType.Int64 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.GUIDImplementacion, ParameterName = "_GUIDImplementacion", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.Nombre, ParameterName = "_Nombre", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.NombreTema, ParameterName = "_NombreTema", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ModoTema, ParameterName = "_ModoTema", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.Lema, ParameterName = "_Lema", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ClaveDirectorioLogoImplementacion, ParameterName = "_ClaveDirectorioLogoImplementacion", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.FaviconDirectorioSecundario, ParameterName = "_FaviconDirectorioSecundario", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.LogoDirectorioSecundario, ParameterName = "_LogoDirectorioSecundario", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ImagenHomeDirectorioSecundario, ParameterName = "_ImagenHomeDirectorioSecundario", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.Estado, ParameterName = "_Estado", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ClaveMunicipio, ParameterName = "_ClaveMunicipio", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.claveNivelGobierno, ParameterName = "_ClaveNivelGobierno", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.claveEntidadNivelGobierno, ParameterName = "_ClaveEntidadNivelGobierno", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.claveMunicipioNivelGobierno, ParameterName = "_ClaveMunicipioNivelGobierno", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.CodigoPostal, ParameterName = "_CodigoPostal", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.ClaveCP, ParameterName = "_ClaveCP", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.Calle, ParameterName = "_Calle", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.NumExt, ParameterName = "_NumExt", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.NumInt, ParameterName = "_NumInt", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.NombreAbreviado, ParameterName = "_NombreAbreviado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.HorarioInicioLaboral.ToString("yyyy-MM-dd HH:mm:ss"), ParameterName = "_HorarioInicioLaboral", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.HorarioFinLaboral.ToString("yyyy-MM-dd HH:mm:ss"), ParameterName = "_HorarioFinLaboral", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"), ParameterName = "_FechaInicio", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = implementacion.FechaFin.ToString("yyyy-MM-dd HH:mm:ss"), ParameterName = "_FechaFin", MySqlDbType = MySqlDbType.VarChar });
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
                resultado = new Utilerias().GetTablaResultado();
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
    }






    //public Etimplementacion GetImplementacion()
    //{
    //    DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetImplementacion());
    //    List<Etimplementacion> lsResultado = UtilTablas.ConvertirDataTableToList<Etimplementacion>(table);
    //    Etimplementacion implementacion = lsResultado[0];

    //    return implementacion;
    //}
    //public static ProcedimientoAlmacenado GetImplementacion()
    //{
    //    ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_Gettimplementacion");
    //    return sp;
    //}


    //public bool AsignarExpedienteCaso(EAsignaciones MaestroAsignacion, DataAccess dataAccess)
    //{
    //    MySqlCommand com = new MySqlCommand("JSP_Asignacion_AddMaestro", dataAccess.conn, dataAccess.transaction);
    //    try
    //    {
    //        com.Parameters.Add(new MySqlParameter { Value = MaestroAsignacion.RIDAsignacion, ParameterName = "RIDAsignacion_", MySqlDbType = MySqlDbType.Int64 });                          //	bigint(12),
    //        com.Parameters.Add(new MySqlParameter { Value = MaestroAsignacion.ClaveTipoAsignacion, ParameterName = "ClaveTipoAsignacion_", MySqlDbType = MySqlDbType.Int64 });                          //	bigint(12),
    //        com.Parameters.Add(new MySqlParameter { Value = MaestroAsignacion.ClaveUsuarioAsignador, ParameterName = "ClaveUsuarioAsignador_", MySqlDbType = MySqlDbType.Int64 });                          //	bigint(12),
    //        com.Parameters.Add(new MySqlParameter { Value = MaestroAsignacion.ClaveUsuarioAsignado, ParameterName = "ClaveUsuarioAsignado_", MySqlDbType = MySqlDbType.Int64 });                          //	bigint(12),
    //        com.CommandType = CommandType.StoredProcedure;

    //        var result = com.ExecuteNonQuery();
    //        return result == 1 ? true : false;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        com.Dispose();
    //    }
    //}

    //    public bool AsignarExpedienteCasoDetalle(int ClaveUsuarioAsignado, EAsignacionesDetalle DetalleAsignacion, DataAccess dataAccess)
    //    {
    //        MySqlCommand com = new MySqlCommand("JSP_Asignacion_AddDetalleItem_UpdateExpediente", dataAccess.conn, dataAccess.transaction);
    //        try
    //        {
    //            com.Parameters.Add(new MySqlParameter { Value = ClaveUsuarioAsignado, ParameterName = "ClaveUsuarioAsignado_", MySqlDbType = MySqlDbType.Int64 });                          //	bigint(12),
    //            com.Parameters.Add(new MySqlParameter { Value = DetalleAsignacion.ClaveAsignacion, ParameterName = "ClaveAsignacion_", MySqlDbType = MySqlDbType.Int64 });                          //	bigint(12),
    //            com.Parameters.Add(new MySqlParameter { Value = DetalleAsignacion.ClaveExpediente, ParameterName = "ClaveExpediente_", MySqlDbType = MySqlDbType.Int64 });                          //	bigint(12),
    //            com.Parameters.Add(new MySqlParameter { Value = DetalleAsignacion.ClaveCaso, ParameterName = "ClaveCaso_", MySqlDbType = MySqlDbType.Int64 });                          //	bigint(12),
    //            com.CommandType = CommandType.StoredProcedure;

    //            var result = com.ExecuteNonQuery();
    //            return result >= 2 ? true : false;

    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            com.Dispose();
    //        }}
}

