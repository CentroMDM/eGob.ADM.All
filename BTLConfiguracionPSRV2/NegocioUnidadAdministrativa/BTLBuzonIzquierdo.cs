using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;
using System.Drawing;

namespace BTLConfiguracionPSRV2
{
    public class BTLBuzonIzquierdo
    {
        private DAOGetObjetosNegocio daoGetObjetosNegocio = null;
        private DAOGetObjetosNegocio GetObjetosNegocio()
        {
            if (daoGetObjetosNegocio == null)
            {
                daoGetObjetosNegocio = new DAOGetObjetosNegocio();
            }
            return daoGetObjetosNegocio;
        }

        #region Unidades Administrativas 
        public List<Etusuarios> GetUsuario()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetUsuario());
            List<Etusuarios> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etusuarios>(table);
            return lsUsuarios;
        }
        public List<Etunidadadministrativa> GetUACasoConfiguracion(int RIDUsuario)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetUACasoConfiguracion(RIDUsuario));
            List<Etunidadadministrativa> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etunidadadministrativa>(table);
            return lsUsuarios;
        }
        #endregion
    }
}
