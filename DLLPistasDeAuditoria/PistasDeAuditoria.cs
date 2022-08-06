using Utilerias;
using System.Data;
using EntitiesPSR;
using System.Collections.Generic;

namespace DLLPistasDeAuditoria
{
    public class PistasDeAuditoria
    {
        public List<EUsuariosPistas> GetUsuariosXUnidad(int RIDUnidad)
        {
            AuditoriaData obtenerUsuariosXU = new AuditoriaData();
            DataTable dtUsuariosXU = obtenerUsuariosXU.GetUsuariosXUnidad(RIDUnidad);
            List<EUsuariosPistas> lsUsuariosXU = UtilTablas.ConvertirDataTableToList<EUsuariosPistas>(dtUsuariosXU);
            return lsUsuariosXU;
        }
    }
}
