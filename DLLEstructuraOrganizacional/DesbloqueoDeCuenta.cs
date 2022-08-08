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
        public List<Etusuarios> busquedaUserID(Etusuarios userID)
        {
            DatosEO IdUser = new DatosEO();
            DataTable dtIdUser = IdUser.busquedaUserID(userID);
            List<Etusuarios> lsUserID = new Utilerias().Convertir<Etusuarios>(dtIdUser);
            return lsUserID;
        }
        public Resultado desbloquearUserID(Etusuarios userID)
        {
            DatosEO IdUser = new DatosEO();
            DataTable dtIdUser = IdUser.desbloquearUserID(userID);
            Resultado lsUserID = new Utilerias().ResultadoDesdeTabla(dtIdUser);
            return lsUserID;
        }
    }
}
