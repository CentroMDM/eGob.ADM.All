using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class EBuzonXUnidad : ObjetoBase
    {
        public int RIDUnidadAdministrativa { get; set; }
        public string NombreUA { get; set; }
        public int RIDBuzon { get; set; }
        public string NombreBuzon { get; set; }
        public int ClaveTipoBuzon { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
