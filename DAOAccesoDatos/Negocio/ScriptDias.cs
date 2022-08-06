using EntitiesPSR;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public static class ScriptDias
    {
        #region Motivo
        public static ProcedimientoAlmacenado GetMotivoDiasInhabil() {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Dias_GetMotivoDiasInhabil");
            return sp;
        }

        public static ProcedimientoAlmacenado SetMotivoDiasInhabil(EcatmotivoDiasInhabiles diasInhabiles) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Dias_SetMotivoDiasInhabil");
            sp.NuevoParametro("_RIDMotivoDias", MySqlDbType.Int32, diasInhabiles.RIDMotivoDias);
            sp.NuevoParametro("_motivo", MySqlDbType.VarChar, diasInhabiles.Motivo);
            sp.NuevoParametro("_ClaveStatus", MySqlDbType.Int32, diasInhabiles.ClaveStatus);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateMotivoDiasInhabil(EcatmotivoDiasInhabiles diasInhabiles) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Dias_UpdateMotivoDiasInhabil");
            sp.NuevoParametro("_RIDMotivoDias", MySqlDbType.Int32, diasInhabiles.RIDMotivoDias);
            //sp.NuevoParametro("_motivo", MySqlDbType.VarChar, diasInhabiles.Motivo);
            return sp;
        }
        #endregion
        #region dias inhabiles
        public static ProcedimientoAlmacenado GetCatDiasInhabiles()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Dias_GetCatDiasInhabiles");
            return sp;
        }
        public static ProcedimientoAlmacenado SetCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Dias_SetCatDiasInhabiles");
            sp.NuevoParametro("_ClaveMotivoDiasInhabiles", MySqlDbType.Int32, catDiasInhabiles.ClaveMotivoDiasInhabiles);
            sp.NuevoParametro("_ClaveEntidadFederativa", MySqlDbType.Int32, catDiasInhabiles.ClaveEntidadFederativa);
            sp.NuevoParametro("_ClaveMunicipio", MySqlDbType.Int32, catDiasInhabiles.ClaveMunicipio);
            sp.NuevoParametro("_RIDDiasInhabiles", MySqlDbType.Int32, catDiasInhabiles.RIDDiasInhabiles);
            sp.NuevoParametro("_FechaDiaInhabil", MySqlDbType.VarChar, catDiasInhabiles.FechaDiaInhabil.ToString("yyyy-MM-dd HH:mm:ss"));
            //sp.NuevoParametro("_FechaFinDiaInhabil", MySqlDbType.VarChar, catDiasInhabiles.FechaFinDiaInhabil.ToString("yyyy-MM-dd HH:mm:ss"));
            sp.NuevoParametro("pClaveAplicaPara", MySqlDbType.Int32, catDiasInhabiles.ClaveAplicaPara);
            return sp;
        }
        public static ProcedimientoAlmacenado UpdateCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Dias_UpdateCatDiasInhabiles");
            sp.NuevoParametro("_ClaveMotivoDiasInhabiles", MySqlDbType.Int32, catDiasInhabiles.ClaveMotivoDiasInhabiles);
            sp.NuevoParametro("_ClaveEntidadFederativa", MySqlDbType.Int32, catDiasInhabiles.ClaveEntidadFederativa);
            sp.NuevoParametro("_ClaveMunicipio", MySqlDbType.Int32, catDiasInhabiles.ClaveMunicipio);
            sp.NuevoParametro("_RIDDiasInhabiles", MySqlDbType.Int32, catDiasInhabiles.RIDDiasInhabiles);
            sp.NuevoParametro("_FechaDiaInhabil", MySqlDbType.VarChar, catDiasInhabiles.FechaDiaInhabil.ToString("yyyy-MM-dd HH:mm:ss"));
            //sp.NuevoParametro("_FechaFinDiaInhabil", MySqlDbType.VarChar, catDiasInhabiles.FechaFinDiaInhabil.ToString("yyyy-MM-dd HH:mm:ss"));
            sp.NuevoParametro("pClaveAplicaPara", MySqlDbType.Int32, catDiasInhabiles.ClaveAplicaPara);
            return sp;
        }

        public static ProcedimientoAlmacenado DeleteCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Dias_DeleteCatDiasInhabiles");
            sp.NuevoParametro("_RIDDiasInhabiles", MySqlDbType.Int32, catDiasInhabiles.RIDDiasInhabiles);
            return sp;
        }

        #endregion

    }
}
