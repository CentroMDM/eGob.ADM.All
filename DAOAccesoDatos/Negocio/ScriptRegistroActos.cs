using EntitiesPSR;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public static class ScriptRegistroActos
    {


        public static ProcedimientoAlmacenado Gettcatregimen() {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_RegistroActos_Gettcatregimen");
            return sp;
        }
        public static ProcedimientoAlmacenado Gettcatimpuestos()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_RegistroActos_Gettcatimpuestos");
            return sp;
        }
        public static ProcedimientoAlmacenado Settcatimpuestos(Etcatimpuestos etcatimpuestos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_RegistroActos_Settcatimpuestos");
            sp.NuevoParametro("_RIDObligacion", MySqlDbType.Int32, etcatimpuestos.RIDObligacion);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, etcatimpuestos.Nombre);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, etcatimpuestos.Descripcion);
            sp.NuevoParametro("_Abreviatura", MySqlDbType.VarChar, etcatimpuestos.Abreviatura);
            sp.NuevoParametro("_ClaveObligacion", MySqlDbType.VarChar, etcatimpuestos.ClaveObligacion);
            sp.NuevoParametro("_ClavePeriocidad", MySqlDbType.Int32, etcatimpuestos.ClavePeriocidad);
            sp.NuevoParametro("_ClaveSujetosAplicables", MySqlDbType.Int32, etcatimpuestos.ClaveSujetosAplicables);
            sp.NuevoParametro("_ClaveRegimen", MySqlDbType.Int32, etcatimpuestos.ClaveRegimen);
            sp.NuevoParametro("_ClaveTipoImpuesto", MySqlDbType.Int32, etcatimpuestos.ClaveTipoImpuesto);
            return sp;
        }
        public static ProcedimientoAlmacenado Updatetcatimpuestos(Etcatimpuestos etcatimpuestos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_RegistroActos_Updatetcatimpuestos");
            sp.NuevoParametro("_RIDObligacion", MySqlDbType.Int32, etcatimpuestos.RIDObligacion);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, etcatimpuestos.Nombre);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, etcatimpuestos.Descripcion);
            sp.NuevoParametro("_Abreviatura", MySqlDbType.VarChar, etcatimpuestos.Abreviatura);
            sp.NuevoParametro("_ClaveObligacion", MySqlDbType.VarChar, etcatimpuestos.ClaveObligacion);
            sp.NuevoParametro("_ClavePeriocidad", MySqlDbType.Int32, etcatimpuestos.ClavePeriocidad);
            sp.NuevoParametro("_ClaveSujetosAplicables", MySqlDbType.Int32, etcatimpuestos.ClaveSujetosAplicables);
            sp.NuevoParametro("_ClaveRegimen", MySqlDbType.Int32, etcatimpuestos.ClaveRegimen);
            sp.NuevoParametro("_ClaveTipoImpuesto", MySqlDbType.Int32, etcatimpuestos.ClaveTipoImpuesto);
            return sp;
        }
        public static ProcedimientoAlmacenado Deletetcatimpuestos(Etcatimpuestos etcatimpuestos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_RegistroActos_Deletetcatimpuestos");
            sp.NuevoParametro("_RIDObligacion", MySqlDbType.Int32, etcatimpuestos.RIDObligacion);
            return sp;
        }





    }
}




