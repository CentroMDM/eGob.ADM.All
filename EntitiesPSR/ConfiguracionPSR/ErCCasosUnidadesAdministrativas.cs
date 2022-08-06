using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    public class ErCCasosUnidadesAdministrativas
    {
        public int RID { get; set; } 
        public int RIDUnidadAdministrativa { get; set; }
        public int RIDCCaso { get; set; }
        public string NombreUA { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
