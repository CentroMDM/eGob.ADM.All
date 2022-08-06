using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesPSR;
using DLLUtilerias;
using System.Data;

namespace DLLEstructuraOrganizacional
{
    public class DesbloqueoDeCuenta
    {
        public List<Etusuarios> busquedaUserID(string userID)
        {
            DatosEO IdUser = new DatosEO();
            DataTable dtIdUser = IdUser.busquedaUserID(userID);
            List<Etusuarios> lsUserID = new Utilerias().Convertir<Etusuarios>(dtIdUser);
            return lsUserID;
        }
    }
}
