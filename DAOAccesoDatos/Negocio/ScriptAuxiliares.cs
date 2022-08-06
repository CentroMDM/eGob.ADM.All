using EntitiesPSR;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public static class ScriptAuxiliares
    {
        public static ProcedimientoAlmacenado GetCatalogoItems(CatalogoDescriptivo catalogo) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetCatalogoDescriptivo");
            sp.NuevoParametro("_ClaveCatalogo", MySqlDbType.Int32, (long)catalogo);
            return sp;
        }

        public static ProcedimientoAlmacenado GetVistaPrevia(int RIDFormato)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_VistaPrevia_GetVistaPrevia");
            sp.NuevoParametro("_RIDFormato", MySqlDbType.Int32, RIDFormato);
            return sp;
        }


    }
}
