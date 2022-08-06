using EntitiesPSR;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public static class ScriptUsuario
    {
        public static ProcedimientoAlmacenado IngresarUsuario(Etempleados empleados)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_SetUsuario");
            sp.NuevoParametro("_RIDUsuario", MySqlDbType.Int32, empleados.Usuario.RIDUsuario);
            //sp.NuevoParametro("_BOIDUsuario", MySqlDbType.VarChar, empleados.Usuario.BOIDUsuario);
            sp.NuevoParametro("_UserID", MySqlDbType.VarChar, empleados.Usuario.UserID);
            sp.NuevoParametro("_UserPW", MySqlDbType.VarChar, empleados.Usuario.UserPW);
            sp.NuevoParametro("_claveEmpleado", MySqlDbType.Int32, empleados.RIDEmpleado);
            return sp;
        }

        public static ProcedimientoAlmacenado IngresarUsuarioBuzon(Erusuariobuzon usuariobuzon)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetRusuariobuzon");
            sp.NuevoParametro("_RID", MySqlDbType.Int64, usuariobuzon.RID);
            sp.NuevoParametro("_ClaveUsuario", MySqlDbType.Int64, usuariobuzon.ClaveUsuario);
            sp.NuevoParametro("_ClaveBuzon", MySqlDbType.Int64, usuariobuzon.ClaveBuzon);
            return sp;
        }

        public static ProcedimientoAlmacenado IngresarRolUsuarioAplicacion(Errolusuarioenaplicacion rolusuarioenaplicacion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetRrolusuarioenaplicacion");
            sp.NuevoParametro("_RIDRUS", MySqlDbType.Int32, rolusuarioenaplicacion.RIDRUS);
            sp.NuevoParametro("_ClaveApplicacion", MySqlDbType.Int32, rolusuarioenaplicacion.ClaveApplicacion);
            sp.NuevoParametro("_ClaveUsuario", MySqlDbType.Int32, rolusuarioenaplicacion.ClaveUsuario);
            sp.NuevoParametro("_ClaveBuzon", MySqlDbType.Int32, rolusuarioenaplicacion.ClaveBuzon);
            sp.NuevoParametro("_ClaveRol", MySqlDbType.Int32, rolusuarioenaplicacion.ClaveRol);
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerUsuariosBuzon()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_GetUsuario");
            return sp;
        }

        public static ProcedimientoAlmacenado ObtenerUsuarioEnAplicacion()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_configuracion_GetRrolusuarioenaplicacion");
            return sp;
        }

        //Grupos de atencion
        public static ProcedimientoAlmacenado ObtenerGrupoAtencion() {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetGruposAtencion");
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerBuzonConfiguracionGruposAtencion()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_Getbuzonconfiguraciongruposatencion");
            return sp;
        }

        public static ProcedimientoAlmacenado ObtenerRelacionGrupoUsuario() {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_Getrgrupousuario");
            return sp;
        }

        public static ProcedimientoAlmacenado IngresarGrupoAtencion(Etgruposatencion grupoAtencion) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetGruposAtencion");
            sp.NuevoParametro("_ClaveBuzon", MySqlDbType.Int32, grupoAtencion.Buzon.RIDBuzon);
            sp.NuevoParametro("_RIDGrupo", MySqlDbType.Int32, grupoAtencion.RIDGrupo);
            //sp.NuevoParametro("_BOIDGrupo", MySqlDbType.VarChar, grupoAtencion.BOIDGrupo);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, grupoAtencion.Nombre);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, grupoAtencion.Descripcion);
            sp.NuevoParametro("_NombreSP", MySqlDbType.VarChar, grupoAtencion.NombreSP);
            return sp;
        }

        public static ProcedimientoAlmacenado IngresarBuzonConfiguracionGruposAtencion(Ebuzonconfiguraciongruposatencion configuracionGruposAtencion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_Setbuzonconfiguraciongruposatencion");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, configuracionGruposAtencion.RID);
            sp.NuevoParametro("_ClaveBuzon", MySqlDbType.Int32, configuracionGruposAtencion.ClaveBuzon);
            sp.NuevoParametro("_ClaveTipoGrupo", MySqlDbType.Int32, configuracionGruposAtencion.ClaveTipoGrupo);
            sp.NuevoParametro("_ClaveCatalogo", MySqlDbType.Int32, configuracionGruposAtencion.ClaveCatalogo);
            sp.NuevoParametro("_Display", MySqlDbType.VarChar, configuracionGruposAtencion.Display);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, configuracionGruposAtencion.Descripcion);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, configuracionGruposAtencion.Nombre);
            sp.NuevoParametro("_ClaveGrupoAtencion", MySqlDbType.Int32, configuracionGruposAtencion.ClaveGrupoAtencion);
            return sp;
        }

        public static ProcedimientoAlmacenado IngresarGrupoUsuario(Ergrupousuario rgrupoUsuario) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_Setrgrupousuario");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, rgrupoUsuario.RID);
            sp.NuevoParametro("_ClaveGrupoAtencion", MySqlDbType.Int32, rgrupoUsuario.ClaveGrupoAtencion);
            sp.NuevoParametro("_ClaveUsuario", MySqlDbType.Int32, rgrupoUsuario.ClaveUsuario);
            return sp;
        }

    }
}
