using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesPSR;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public static class ScriptMenuIzquierdo
    {
        #region Unidad Administrativa CCasos
        public static ProcedimientoAlmacenado GetUsuario()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_GetUsuario");
            sp.NuevoParametro("pRIDUsuario", MySqlDbType.Int32, (int)EntidadUsuarioCConfiguracion.USUARIO_ACTUAL);
            return sp;
        }
        public static ProcedimientoAlmacenado GetUACasoConfiguracion(int RIDUsuario)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_GetUACasoConfiguracion");
            sp.NuevoParametro("pRIDUsuario", MySqlDbType.Int32, RIDUsuario);
            return sp;
        }
        #endregion
    }
}
