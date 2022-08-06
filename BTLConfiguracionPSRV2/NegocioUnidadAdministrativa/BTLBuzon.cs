using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;

namespace BTLConfiguracionPSRV2
{
    public class BTLBuzon
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
        public List<Ebuzonesconfiguracion> ObtenerBuzonesConfiguracion()
        {
            BTLUnidadAdministrativa btl = new BTLUnidadAdministrativa();
            List<Ebuzonesconfiguracion> lsBuzones = btl.ObtenerBuzonesConfiguracion();
            return lsBuzones;
        }












        public List<Ecattodosroles> ObtenerRoles(Ebuzonesconfiguracion buzon)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptBuzon.ObtenerRoles(buzon));
            List<Ecattodosroles> lsResultado = UtilTablas.ConvertirDataTableToList<Ecattodosroles>(table);
            return lsResultado;
        }

        public List<Ebuzonesconfiguracion> ObtenerBuzonYRol()
        {
            List<Ebuzonesconfiguracion> lsBuzones = ObtenerBuzonesConfiguracion();
            foreach (Ebuzonesconfiguracion buzon in lsBuzones)
            {
                buzon.Roles.AddRange(ObtenerRoles(buzon));
            }
            return lsBuzones;
        }
    }
}
