using ClsAccessData;
using EntitiesPSR;
using System;
using MySql.Data.MySqlClient;
using ClsBOID;
using System.Data;
using DLLUtilerias;
//using Utilerias;

namespace DLLEstructuraOrganizacional
{
    public class DatosEO
    {
        DataAccess dataAccess = new DataAccess();
        public (int, string) ObtenerIdentificadoresPSR(TablasAdministracion tablasAdministracion)
        {
            (int, string) identificadores = new BOID().GenNewBOID((int)tablasAdministracion, dataAccess);
            return identificadores;
        }

        #region Niveles de Mando
        public DataTable ObtenerNivelPuesto()
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
        public DataTable ObtenerNivelXPuesto(int RIDPuesto)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_ObtenerNivelMandoXPuesto", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDPuesto, ParameterName = "_RIDPuesto", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtNivelesXP = new DataTable();
                da.Fill(dtNivelesXP);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtNivelesXP;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable InsertarNivelPuesto(EcatNivelesPuestos catNivelPuestos)
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
                com = new MySqlCommand("SP_Administracion_SetNivelPuesto", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.RIDNivel, ParameterName = "_RIDNivel", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.Clave, ParameterName = "_Clave", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.Nombre, ParameterName = "_Nombre", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.PuestoMando, ParameterName = "_PuestoMando", MySqlDbType = MySqlDbType.Byte });
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
        public DataTable ActualizarNivelPuesto(EcatNivelesPuestos catNivelPuestos)
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
                com = new MySqlCommand("SP_Administracion_UpdateNivelPuesto", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.RIDNivel, ParameterName = "_RIDNivel", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.Clave, ParameterName = "_Clave", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.Nombre, ParameterName = "_Nombre", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.PuestoMando, ParameterName = "_PuestoMando", MySqlDbType = MySqlDbType.Byte });
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
        public DataTable EliminarNivelPuesto(EcatNivelesPuestos catNivelPuestos)
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
                com = new MySqlCommand("SP_Administracion_DelNivelPuesto", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = catNivelPuestos.RIDNivel, ParameterName = "_RIDNivel", MySqlDbType = MySqlDbType.Int32 });
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
        #endregion

        #region Puestos
        public DataTable ConsultaPuesto()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SP_Administracion_GetPuestosInstitucionales", dataAccess.conn);
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
        public DataTable ObtenerPuestosXUnidad(int RIDUnidad)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_ObtenerPuestosXUnidad", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUnidad, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
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
        public DataTable IngresarPuesto(EtcatPuestos catPuestos)
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
                com = new MySqlCommand("SP_Administracion_SetPuesto", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.RIDPuestos, ParameterName = "_RIDPuestos", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.ClaveUnidadAdministrativa, ParameterName = "_ClaveUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.ClaveNivelPuesto, ParameterName = "_ClaveNivelPuesto", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.NombrePuesto, ParameterName = "_nombrePuesto", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.Abreviatura, ParameterName = "_abreviatura", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.DescripcionPuesto, ParameterName = "_descripcionPuesto", MySqlDbType = MySqlDbType.Text });//text
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
        public DataTable ActualizarPuesto(EtcatPuestos catPuestos)
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
                com = new MySqlCommand("SP_Administracion_UpdatePuestoInstitucional", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.RIDPuestos, ParameterName = "_RIDPuestos", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.ClaveUnidadAdministrativa, ParameterName = "_ClaveUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.ClaveNivelPuesto, ParameterName = "_ClaveNivelPuesto", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.NombrePuesto, ParameterName = "_nombrePuesto", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.Abreviatura, ParameterName = "_abreviatura", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.DescripcionPuesto, ParameterName = "_descripcionPuesto", MySqlDbType = MySqlDbType.VarChar });
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
        public DataTable EliminarPuesto(EtcatPuestos catPuestos)
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
                com = new MySqlCommand("SP_Administracion_DelPuestoInstitucional", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = catPuestos.RIDPuestos, ParameterName = "_RIDPuesto", MySqlDbType = MySqlDbType.Int32 });
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
        #endregion

        #region Empleados
        public DataTable ObtenerEmpleado()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SP_Configuracion_GetEmpleados", dataAccess.conn);
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
        public DataTable RFCDisponibleEmpleadoNew(string RFCEmp)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_EmpleadosObtenerRFCDisponibleEmpleado", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RFCEmp, ParameterName = "_RFCEmpleado", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtClaveEmpleado = new DataTable();
                da.Fill(dtClaveEmpleado);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtClaveEmpleado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }    
        public DataTable RFCDisponibleEmpleado(Etempleados RFCEmp)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_GetRFCDisponibleEmpleado", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RFCEmp.RFCEmpleado, ParameterName = "_RFCEmpleado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = RFCEmp.RIDEmpleado, ParameterName = "_RIDEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtClaveEmpleado = new DataTable();
                da.Fill(dtClaveEmpleado);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtClaveEmpleado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }        
        public DataTable ObtenerClaveEmpleadoNew(string numeroNuevo)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_ObtenerClaveEmpleado", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = numeroNuevo, ParameterName = "_numeroNuevo", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtClaveEmpleado = new DataTable();
                da.Fill(dtClaveEmpleado);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtClaveEmpleado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable ObtenerClaveEmpleado(Etempleados numeroNuevo)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();

                MySqlCommand com = new MySqlCommand("SSP_GetClaveEmpleado", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = numeroNuevo.NumeroEmpleado, ParameterName = "_numeroNuevo", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = numeroNuevo.RIDEmpleado, ParameterName = "_RIDEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtClaveEmpleado = new DataTable();
                da.Fill(dtClaveEmpleado);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtClaveEmpleado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable ObtenerEmpleadosXUnidad(int RIDUnidad)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_ObtenerEmpleadosXUnidad", dataAccess.conn);
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
        public DataTable ObtenerEmpleadosXPuesto(int RIDPuesto)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_ObtenerEmpleadosXPuesto", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDPuesto, ParameterName = "_RIDPuestos", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtEmpleadosXP = new DataTable();
                da.Fill(dtEmpleadosXP);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtEmpleadosXP;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable CargarImagenEmpleado()
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
        public DataTable IngresarEmpleado(Etempleados templeados)
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
                com = new MySqlCommand("SP_Configuracion_SetEmpleado", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = templeados.RIDEmpleado, ParameterName = "_RIDEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = templeados.RFCEmpleado, ParameterName = "_RFCEmpleado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.NombreEmpleado, ParameterName = "_NombreEmpleado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.APaterno, ParameterName = "_APaterno", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.AMaterno, ParameterName = "_AMaterno", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.NumeroEmpleado, ParameterName = "_NumeroEmpleado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.DirectorioSecundarioFoto, ParameterName = "_DirectorioSecundarioFoto", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.ClavePuesto, ParameterName = "_ClavePuesto", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = templeados.correoEmpleado, ParameterName = "_correoEmpleado", MySqlDbType = MySqlDbType.VarChar });
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
        public DataTable ActualizarEmpleado(Etempleados templeados)
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
                com = new MySqlCommand("SP_Configuracion_UpdateEmpleado", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = templeados.RIDEmpleado, ParameterName = "_RIDEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = templeados.RFCEmpleado, ParameterName = "_RFCEmpleado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.NombreEmpleado, ParameterName = "_NombreEmpleado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.APaterno, ParameterName = "_APaterno", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.AMaterno, ParameterName = "_AMaterno", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.NumeroEmpleado, ParameterName = "_NumeroEmpleado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.DirectorioSecundarioFoto, ParameterName = "_DirectorioSecundarioFoto", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.ClavePuesto, ParameterName = "_ClavePuesto", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = templeados.correoEmpleado, ParameterName = "_correoEmpleado", MySqlDbType = MySqlDbType.VarChar });
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
        public DataTable EliminarEmpleado(Etempleados templeados)
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
                com = new MySqlCommand("SP_Administracion_DelEmpleado", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = templeados.RIDEmpleado, ParameterName = "_RIDEmpleado", MySqlDbType = MySqlDbType.Int32 });
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
        #endregion

        #region UnidadesAdministrativas
        public DataTable ObtenerUnidadesAdministrativas()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SP_Administracion_GetUnidadAdministrativa", dataAccess.conn);
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
        public DataTable GetUnidadAdmActiva()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_Administracion_GetUnidadAdmActiva", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtUnidades = new DataTable();
                da.Fill(dtUnidades);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtUnidades;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable datosOrganigrama()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_Administracion_GetOrganigrama", dataAccess.conn);
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
        public DataTable ObtenerEntidadFederativa()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_ADM_GetEntidad", dataAccess.conn);
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
        public DataTable ObtenerMunicipios(int RIDEntidad)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("Sp_Administracion_GetMunicipios", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDEntidad, ParameterName = "_RIDEntidad", MySqlDbType = MySqlDbType.Int32 });
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
        public DataTable ObtenerAplicaciones()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SP_Configuracion_GetAplicacionBuzon", dataAccess.conn);
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
        public DataTable CargarLogos()
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
        public DataTable ObtenerFiltros()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SP_Configuracion_GetFiltroBuzon", dataAccess.conn);
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
        public DataTable BuscarFiltros(Ecattipofiltrosinicialesbuzon tipoFiltro)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand(tipoFiltro.SP_GetCatalogo, dataAccess.conn);
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
        public DataTable InsertarUnidadAdministrativa(Etunidadadministrativa unidadADM)
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
                com = new MySqlCommand("SP_Administracion_SetUnidadAdministrativa", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveUAPadre, ParameterName = "_ClaveUAPadre", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.RIDUnidadAdministrativa, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.NombreUA, ParameterName = "_NombreUA", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.AbreviaturaUA, ParameterName = "_AbreviaturaUA", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveDirectorioLogo, ParameterName = "_ClaveDirectorioLogo", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.DirectorioSecundarioLogo, ParameterName = "_DirectorioSecundarioLogo", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.Estado, ParameterName = "_Estado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveMunicipio, ParameterName = "_ClaveMunicipio", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.CodigoPostal, ParameterName = "_CodigoPostal", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveCP, ParameterName = "_ClaveCP", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.Calle, ParameterName = "_Calle", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.NumExt, ParameterName = "_NumeroExterior", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.NumInt, ParameterName = "_NumeroInterior", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();
                //La información se almacenó correctamente
                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                //Ocurrió un Error
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
        public DataTable InsertarBuzonAppUA(Ebuzonesconfiguracion buzon)
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
                com = new MySqlCommand("SP_Configuracion_SetBuzonConfiguracion", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = buzon.RIDBuzon, ParameterName = "_RIDBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = buzon.ClaveUnidadAdmva, ParameterName = "_ClaveUnidadAdmva", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = buzon.ClaveTipoBuzon, ParameterName = "_ClaveTipoBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = buzon.NombreBuzon, ParameterName = "_NombreBuzon", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = buzon.AliasBuzon, ParameterName = "_AliasBuzon", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = buzon.Descripcion, ParameterName = "_Descripcion", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = buzon.DirectorioSecundarioLogo, ParameterName = "_DirectorioSecundarioLogo", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();
                //La información se almacenó correctamente
                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                //Ocurrió un Error
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
        public DataTable InsertarBuzonFiltroUA(Ebuzonconfiguracionfiltros filtro)
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
                com = new MySqlCommand("SP_Configuracion_SetBuzonConfiguracionFiltros", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = filtro.RID, ParameterName = "_RID", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = filtro.ClaveBuzon, ParameterName = "_ClaveBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = filtro.ClaveTipoFiltro, ParameterName = "_ClaveTipoFiltro", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = filtro.ClaveCatalogo, ParameterName = "_ClaveCatalogo", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();
                //La información se almacenó correctamente
                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                //Ocurrió un Error
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
        public DataTable ActualizarTitular(Etunidadadministrativa unidadADM)
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
                com = new MySqlCommand("SSP_ADM_UpdateTitularUA", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.RIDUnidadAdministrativa, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveEmpleado, ParameterName = "_ClaveEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();
                //La información se almacenó correctamente
                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                //Ocurrió un Error
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
        public DataTable ObtenerUnidadesHijas(int RIDUA)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_Administracion_GetUnidadesAdmnistrativasHijas", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUA, ParameterName = "_ClaveUAPadre", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtUAHijas = new DataTable();
                da.Fill(dtUAHijas);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtUAHijas;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable BuzonesXUA(int RIDUA)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_Configuracion_GetBuzonConfiguracionXUA", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUA, ParameterName = "_RIDUA", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtBuzones = new DataTable();
                da.Fill(dtBuzones);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtBuzones;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable FiltrosXBuzon(int RIDBuzon)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_Get_FiltrosByBuzon", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDBuzon, ParameterName = "_RIDBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtFiltroBuzon = new DataTable();
                da.Fill(dtFiltroBuzon);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtFiltroBuzon;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable ObtenerBuzonFiltrosInicial()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SP_Configuracion_GetBuzonConfiguracionFiltros", dataAccess.conn);
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
        public DataTable DelUnidadAdministrativaBuzones(Ebuzonesconfiguracion buzon)
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Proceso");
            resultado.Columns.Add("DetalleDeError");
            resultado.Columns.Add("DetalleErrorSql");
            resultado.Columns.Add("Mensaje");
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_Administracion_DelUnidadAdministrativaBuzones", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = buzon.RIDBuzon, ParameterName = "_RIDBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtTransaction = new DataTable();
                da.Fill(dtTransaction);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                //Ocurrió un Error
                if (dtTransaction.Rows.Count > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 0;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "Ocurrió un Error";
                    resultado.Rows.Add(tr);
                }
                else
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                return resultado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }//No se copia
        public DataTable DelUnidadAdministrativa(Etunidadadministrativa unidadADM)//No se copia
        {
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Proceso");
            resultado.Columns.Add("DetalleDeError");
            resultado.Columns.Add("DetalleErrorSql");
            resultado.Columns.Add("Mensaje");
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_Administracion_DelUnidadAdministrativa", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.RIDUnidadAdministrativa, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtTransaction = new DataTable();
                da.Fill(dtTransaction);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                //Ocurrió un Error
                if (dtTransaction.Rows.Count > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 0;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "Ocurrió un Error";
                    resultado.Rows.Add(tr);
                }
                else
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                return resultado;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable ActualizarUnidadAdministrativa(Etunidadadministrativa unidadADM)
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
                com = new MySqlCommand("SP_Administracion_UpdateUnidadAdministrativa", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveUAPadre, ParameterName = "_ClaveUAPadre", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.RIDUnidadAdministrativa, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.NombreUA, ParameterName = "_NombreUA", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.AbreviaturaUA, ParameterName = "_AbreviaturaUA", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveDirectorioLogo, ParameterName = "_ClaveDirectorioLogo", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.DirectorioSecundarioLogo, ParameterName = "_DirectorioSecundarioLogo", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.Estado, ParameterName = "_Estado", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveMunicipio, ParameterName = "_ClaveMunicipio", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.CodigoPostal, ParameterName = "_CodigoPostal", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveCP, ParameterName = "_ClaveCP", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.Calle, ParameterName = "_Calle", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.NumExt, ParameterName = "_NumeroExterior", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.NumInt, ParameterName = "_NumeroInterior", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = unidadADM.ClaveEmpleado, ParameterName = "_ClaveEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();
                //La información se almacenó correctamente
                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                //Ocurrió un Error
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
        public DataTable ActualizarBuzonAppUA(Ebuzonesconfiguracion buzon)
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
                com = new MySqlCommand("SSP_Configuracion_UpdateBuzonConfiguracion", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = buzon.RIDBuzon, ParameterName = "_RIDBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = buzon.ClaveUnidadAdmva, ParameterName = "_ClaveUnidadAdmva", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = buzon.ClaveTipoBuzon, ParameterName = "_ClaveTipoBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = buzon.NombreBuzon, ParameterName = "_NombreBuzon", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = buzon.AliasBuzon, ParameterName = "_AliasBuzon", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = buzon.Descripcion, ParameterName = "_Descripcion", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = buzon.DirectorioSecundarioLogo, ParameterName = "_DirectorioSecundarioLogo", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();
                //La información se almacenó correctamente
                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                //Ocurrió un Error
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
        public DataTable ActualizarBuzonFiltroUA(Ebuzonconfiguracionfiltros filtro)
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
                com = new MySqlCommand("SSP_Configuracion_UpdateBuzonConfiguracionFiltros", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = filtro.RID, ParameterName = "_RID", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                int intResultado = com.ExecuteNonQuery();
                //La información se almacenó correctamente
                if (intResultado > 0)
                {
                    DataRow tr = resultado.NewRow();
                    tr[0] = 1;
                    tr[1] = "";
                    tr[2] = "";
                    tr[3] = "La información se almacenó correctamente";
                    resultado.Rows.Add(tr);
                }
                //Ocurrió un Error
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
        #endregion

        #region usuarios
        public DataTable GetUsuarios()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_GetUsuarios", dataAccess.conn);
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
        //public DataTable ObtenerUsuariosActivos()
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_ObtenerUsuariosActivos", dataAccess.conn);
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtUsuarios = new DataTable();
        //        da.Fill(dtUsuarios);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtUsuarios;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        public DataTable AplicacionesxUnidad(int RIDUnidad)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_AplicacionesxUnidad", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUnidad, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtAppXU = new DataTable();
                da.Fill(dtAppXU);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtAppXU;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //public DataTable ObtenerUsuariosActivosXU(int RIDUnidad)
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_ObtenerUsuariosActivosXU", dataAccess.conn);
        //        com.Parameters.Add(new MySqlParameter { Value = RIDUnidad, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtUsuarios = new DataTable();
        //        da.Fill(dtUsuarios);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtUsuarios;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        public DataTable ObtenerUsuariosXUnidadA(int RIDUnidad)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_ObtenerUsuariosXUnidadA", dataAccess.conn);
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
        
        //public DataTable ObtenerFirmantes()
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_ObtenerFirmantes", dataAccess.conn);
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtFirmantes = new DataTable();
        //        da.Fill(dtFirmantes);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtFirmantes;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //public DataTable ObtenerFirmantesXU(int RIDUnidad)
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_ObtenerFirmantesXU", dataAccess.conn);
        //        com.Parameters.Add(new MySqlParameter { Value = RIDUnidad, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtFirmantes = new DataTable();
        //        da.Fill(dtFirmantes);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtFirmantes;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //public DataTable ObtenerFirmantesActivos()
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_ObtenerFirmantesActivos", dataAccess.conn);
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtFirmantes = new DataTable();
        //        da.Fill(dtFirmantes);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtFirmantes;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        public DataTable getNewUsuarios(int RIDUnidad)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_getNewUsuarios", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUnidad, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtnewUsuariosXU = new DataTable();
                da.Fill(dtnewUsuariosXU);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtnewUsuariosXU;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable UsuariosExistentes(int RIDUnidad)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_UsuariosExistentes", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUnidad, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtUsuariosXU = new DataTable();
                da.Fill(dtUsuariosXU);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtUsuariosXU;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //public DataTable GetTableRelacionERB()
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_GetTableRelacionERB", dataAccess.conn);
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtRelacionERB = new DataTable();
        //        da.Fill(dtRelacionERB);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtRelacionERB;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        public DataTable IngresarUsuario(Etusuarios templeados)
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
                com = new MySqlCommand("Sp_Administracion_SetUsuario", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = templeados.RIDUsuario, ParameterName = "_RIDUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = templeados.ClaveEmpleado, ParameterName = "_ClaveEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = templeados.UserID, ParameterName = "_UserID", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.UserPW, ParameterName = "_UserPW", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = templeados.Firmante, ParameterName = "_Firmante", MySqlDbType = MySqlDbType.Byte });
                com.Parameters.Add(new MySqlParameter { Value = templeados.FundamentoFirma, ParameterName = "_FundamentoFirma", MySqlDbType = MySqlDbType.VarChar });
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
        public DataTable UpdateUser(Etusuarios tusuarios)
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
                com = new MySqlCommand("SSP_UpdateUser", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = tusuarios.RIDUsuario, ParameterName = "_RIDUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = tusuarios.Firmante, ParameterName = "_Firmante", MySqlDbType = MySqlDbType.Byte });
                com.Parameters.Add(new MySqlParameter { Value = tusuarios.FundamentoFirma, ParameterName = "_FundamentoFirma", MySqlDbType = MySqlDbType.VarChar });
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
        public DataTable UpdateUserPW(Etusuarios tusuarios)
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
                com = new MySqlCommand("SSP_UpdateUserPW", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = tusuarios.RIDUsuario, ParameterName = "_RIDUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = tusuarios.UserID, ParameterName = "_UserID", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = tusuarios.UserPW, ParameterName = "_UserPW", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = tusuarios.Firmante, ParameterName = "_Firmante", MySqlDbType = MySqlDbType.Byte });
                com.Parameters.Add(new MySqlParameter { Value = tusuarios.FundamentoFirma, ParameterName = "_FundamentoFirma", MySqlDbType = MySqlDbType.VarChar });
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
        public DataTable rUsuarioBuzon(Erusuariobuzon buzones)
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
                com = new MySqlCommand("SSP_rUsuarioBuzon", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = buzones.RID, ParameterName = "_RID", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = buzones.ClaveUsuario, ParameterName = "_ClaveUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = buzones.ClaveBuzon, ParameterName = "_ClaveBuzon", MySqlDbType = MySqlDbType.Int32 });
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
        public DataTable rUsuarioRol(ErBuzonRoles Roles)
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
                com = new MySqlCommand("SSP_rUsuarioRol", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = Roles.RIDRUS, ParameterName = "_RIDRUS", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = Roles.ClaveUsuario, ParameterName = "_ClaveUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = Roles.ClaveBuzon, ParameterName = "_ClaveBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = Roles.ClaveRol, ParameterName = "_ClaveRol", MySqlDbType = MySqlDbType.Int32 });
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
        public DataTable DelRUBElimindas(Erusuariobuzon rubElimindo)
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
                com = new MySqlCommand("SSP_DelRUBElimindas", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = rubElimindo.RIDUsuarioBuzon, ParameterName = "_RID", MySqlDbType = MySqlDbType.Int32 });
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
        public DataTable DelRUSElimindas(ErBuzonRoles rusElimindo)
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
                com = new MySqlCommand("SSP_DelRUSElimindas", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = rusElimindo.RIDRUS, ParameterName = "_RIDRUS", MySqlDbType = MySqlDbType.Int32 });
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
        public DataTable GetDatosTablaTemporalERB(ETablaRelacionERB RIDNivel)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_GetDatosTablaTemporalERB", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDNivel.RIDNivel, ParameterName = "_RIDNivel", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = RIDNivel.ClaveEmpleado, ParameterName = "_RIDEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = RIDNivel.ClaveBuzon, ParameterName = "_RIDBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtrolesXNivelP = new DataTable();
                da.Fill(dtrolesXNivelP);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtrolesXNivelP;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable ReactivaUsuario(int RIDUsuario)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_ReactivaUsuario", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_RIDUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtdelUser = new DataTable();
                da.Fill(dtdelUser);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtdelUser;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable DownUsuarioyRelacionesRolBuzon(int RIDUsuario)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_DownUsuarioyRelacionesRolBuzon", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_RIDUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtdelUser = new DataTable();
                da.Fill(dtdelUser);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtdelUser;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable DeleteUsuarioyRelacionesRolBuzon(int RIDUsuario)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_DeleteUsuarioyRelacionesRolBuzon", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_RIDUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtdelUser = new DataTable();
                da.Fill(dtdelUser);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtdelUser;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region Usuarios-Roles
        public DataTable RolesXNivelPuesto(int RIDNivel)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_RolesXNivelPuesto", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDNivel, ParameterName = "_RIDNivel", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtrolesXNivelP = new DataTable();
                da.Fill(dtrolesXNivelP);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtrolesXNivelP;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable insertaRolesEmpleado(ETablaRelacionERB Roles)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_insertaRolesEmpleado", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = Roles.ClaveRol, ParameterName = "_RIDRol", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = Roles.ClaveEmpleado, ParameterName = "_RIDEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.Parameters.Add(new MySqlParameter { Value = Roles.ClaveBuzon, ParameterName = "_RIDBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtrolesXNivelP = new DataTable();
                da.Fill(dtrolesXNivelP);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtrolesXNivelP;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable EliminaRolTeporal(int ClaveBuzon)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_EliminaRolTeporal", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = ClaveBuzon, ParameterName = "_ClaveBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtdelRolTemp = new DataTable();
                da.Fill(dtdelRolTemp);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtdelRolTemp;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region Desbloqueo de cuentas
        public DataTable busquedaUserID(Etusuarios userID)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_EOCuentas_GetDatosUsuario", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = userID.UserID, ParameterName = "_UserID", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = userID.UserPW, ParameterName = "_IDDesbloqueo", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtUsuariosID = new DataTable();
                da.Fill(dtUsuariosID);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtUsuariosID;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable desbloquearUserID(Etusuarios userID)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_EOCuentas_UpdateDatosUsuario", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = userID.UserID, ParameterName = "_UserID", MySqlDbType = MySqlDbType.VarChar });
                com.Parameters.Add(new MySqlParameter { Value = userID.UserPW, ParameterName = "_IDDesbloqueo", MySqlDbType = MySqlDbType.VarChar });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtUsuariosID = new DataTable();
                da.Fill(dtUsuariosID);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtUsuariosID;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region Buzon-Aplicaciones
        //public DataTable ObtenerAplicacionesDeUnidad()
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_Configuracion_GetBuzonConfiguracion", dataAccess.conn);
        //        com.CommandType = CommandType.StoredProcedure;
        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtPuestos = new DataTable();
        //        da.Fill(dtPuestos);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtPuestos;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //public DataTable ActualizarAplicacionActivo(int RIDBuzon)
        //{
        //    DataTable resultado = new DataTable();
        //    resultado.Columns.Add("Proceso");
        //    resultado.Columns.Add("DetalleDeError");
        //    resultado.Columns.Add("DetalleErrorSql");
        //    resultado.Columns.Add("Mensaje");
        //    MySqlCommand com = null;
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        com = new MySqlCommand("SSP_Administracion_UpdateBuzonAplicacion", dataAccess.conn, dataAccess.transaction);
        //        com.Parameters.Add(new MySqlParameter { Value = RIDBuzon, ParameterName = "_RIDBuzon", MySqlDbType = MySqlDbType.Int32 });
        //        com.CommandType = CommandType.StoredProcedure;
        //        int intResultado = com.ExecuteNonQuery();
        //        if (intResultado > 0)
        //        {
        //            DataRow tr = resultado.NewRow();
        //            tr[0] = 1;
        //            tr[1] = "";
        //            tr[2] = "";
        //            tr[3] = "La información se almacenó correctamente";
        //            resultado.Rows.Add(tr);
        //        }
        //        else
        //        {
        //            DataRow tr = resultado.NewRow();
        //            tr[0] = 0;
        //            tr[1] = "";
        //            tr[2] = "";
        //            tr[3] = "Ocurrió un Error";
        //            resultado.Rows.Add(tr);
        //        }
        //        com.Dispose();
        //        com.Connection.Close();
        //        return resultado;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        resultado = UtilGenerarTablas.GetTablaResultado();
        //        DataRow row = resultado.NewRow();
        //        row["Proceso"] = 0;
        //        row["DetalleDeError"] = ex.Message;
        //        row["DetalleErrorSql"] = ex.Code;
        //        row["Mensaje"] = "Error al realizar SP ";
        //    }
        //    finally
        //    {
        //        if (com.Connection != null)
        //        {
        //            com.Connection.Close();
        //        }
        //    }
        //    return resultado;
        //}
        //public DataTable ActualizarAplicacionDesactivada(int RIDBuzon)//No se copia
        //{
        //    DataTable resultado = new DataTable();
        //    resultado.Columns.Add("Proceso");
        //    resultado.Columns.Add("DetalleDeError");
        //    resultado.Columns.Add("DetalleErrorSql");
        //    resultado.Columns.Add("Mensaje");

        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_Administracion_DeleteBuzonAplicacion", dataAccess.conn);
        //        com.Parameters.Add(new MySqlParameter { Value = RIDBuzon, ParameterName = "_RIDBuzon", MySqlDbType = MySqlDbType.Int32 });
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtTransaction = new DataTable();
        //        da.Fill(dtTransaction);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        //Ocurrió un Error
        //        if (dtTransaction.Rows.Count > 0)
        //        {
        //            DataRow tr = resultado.NewRow();
        //            tr[0] = 0;
        //            tr[1] = "";
        //            tr[2] = "";
        //            tr[3] = "Ocurrió un Error";
        //            resultado.Rows.Add(tr);
        //        }
        //        else
        //        {
        //            DataRow tr = resultado.NewRow();
        //            tr[0] = 1;
        //            tr[1] = "";
        //            tr[2] = "";
        //            tr[3] = "La información se almacenó correctamente";
        //            resultado.Rows.Add(tr);
        //        }
        //        return resultado;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //public DataTable AplicacionXUnidad(int RIDUnidad)
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_ObtenerBuzonXUnidadA", dataAccess.conn);
        //        com.Parameters.Add(new MySqlParameter { Value = RIDUnidad, ParameterName = "_RIDUnidadAdministrativa", MySqlDbType = MySqlDbType.Int32 });
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtBuzones = new DataTable();
        //        da.Fill(dtBuzones);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtBuzones;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        public DataTable BuzonesEmpleado(int RIDEmpleado)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_BuzonesEmpleado", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDEmpleado, ParameterName = "_RIDEmpleado", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtbuzonesXE = new DataTable();
                da.Fill(dtbuzonesXE);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtbuzonesXE;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //public DataTable BuzonesDeUsuario(int RIDUsuario)
        //{
        //    try
        //    {
        //        if (dataAccess.conn.State == ConnectionState.Closed)
        //            dataAccess.OpenConnection();

        //        MySqlCommand com = new MySqlCommand("SSP_BuzonesDeUsuario", dataAccess.conn);
        //        com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_RIDUsuario", MySqlDbType = MySqlDbType.Int32 });
        //        com.CommandType = CommandType.StoredProcedure;

        //        MySqlDataAdapter da = new MySqlDataAdapter(com);
        //        DataTable dtbuzonesXU = new DataTable();
        //        da.Fill(dtbuzonesXU);
        //        dataAccess.CloseConnection();
        //        dataAccess.KillConnection();
        //        return dtbuzonesXU;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        public DataTable RolesXBuzon(int RIDEmpleado)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_RolesXBuzon", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDEmpleado, ParameterName = "_ClaveBuzon", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtBuzones = new DataTable();
                da.Fill(dtBuzones);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtBuzones;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable EliminaTablaTeporal()
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_EliminaTablaTeporal", dataAccess.conn);
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtBuzones = new DataTable();
                da.Fill(dtBuzones);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtBuzones;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable UsuariosSetDatosUsuariosTablaTemporal(int RIDUsuario)
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
                com = new MySqlCommand("SSP_UsuariosSetDatosUsuariosTablaTemporal", dataAccess.conn, dataAccess.transaction);
                com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_RIDUsuario", MySqlDbType = MySqlDbType.Int32 });
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
        public DataTable relacionesEliminadasTablaTemporal(int RIDUsuario)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_relacionesEliminadasTablaTemporal", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_ClaveUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtbuzonesXE = new DataTable();
                da.Fill(dtbuzonesXE);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtbuzonesXE;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable relacionesNuevasTablaTemporal(int RIDUsuario)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_relacionesNuevasTablaTemporal", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_ClaveUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtbuzonesXE = new DataTable();
                da.Fill(dtbuzonesXE);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtbuzonesXE;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable relacionesUBEliminadasTablaTemporal(int RIDUsuario)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_relacionesUBEliminadasTablaTemporal", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_ClaveUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtbuzonesXE = new DataTable();
                da.Fill(dtbuzonesXE);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtbuzonesXE;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public DataTable relacionesUBNuevasTablaTemporal(int RIDUsuario)
        {
            try
            {
                if (dataAccess.conn.State == ConnectionState.Closed)
                    dataAccess.OpenConnection();
                MySqlCommand com = new MySqlCommand("SSP_relacionesUBNuevasTablaTemporal", dataAccess.conn);
                com.Parameters.Add(new MySqlParameter { Value = RIDUsuario, ParameterName = "_ClaveUsuario", MySqlDbType = MySqlDbType.Int32 });
                com.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtbuzonesXE = new DataTable();
                da.Fill(dtbuzonesXE);
                dataAccess.CloseConnection();
                dataAccess.KillConnection();
                return dtbuzonesXE;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        //#region Tipos de Transacciones
        //public void IniciarTransaccion()
        //{
        //    dataAccess.BeginTransaction();
        //}
        //public void TerminarTransaccion()
        //{
        //    dataAccess.CommitTransaction();
        //}
        //public void DeshacerTransaccion()
        //{
        //    dataAccess.Rollback();
        //}
        //public void AbrirConexion()
        //{
        //    dataAccess.OpenConnection();
        //}
        //public void CerrarConexion()
        //{
        //    dataAccess.CloseConnection();
        //}
        //#endregion
    }
}
