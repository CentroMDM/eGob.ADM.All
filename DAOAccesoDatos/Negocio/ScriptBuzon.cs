using EntitiesPSR;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public static class ScriptBuzon
    {
        public static ProcedimientoAlmacenado ObtenerRoles(Ebuzonesconfiguracion buzon)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetRoles");
            sp.NuevoParametro("_ClaveAplicacion", MySqlDbType.Int64, buzon.ClaveTipoBuzon);
            return sp;
        }

    }
}
