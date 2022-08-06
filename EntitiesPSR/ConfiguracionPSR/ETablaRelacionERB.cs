using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class ETablaRelacionERB : ObjetoBase
    {
        public Int64 ClaveEmpleado { get; set; }
        public Int64 ClaveBuzon { get; set; }
        public string NombreBuzon { get; set; }
        public Int64 RolesAsignados { get; set; }
        public Int64 ClaveRol { get; set; }
        public Int64 RIDNivel { get; set; }
        public Int64 RIDRUS { get; set; }
        public Int64 RIDUsuarioBuzon { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
