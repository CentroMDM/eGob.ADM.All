using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class ECatRoles : ObjetoBase
    {
        public Int64 ClaveAplicacion { get; set; }
        public string nombreRol { get; set; }
        public string descripcionRol { get; set; }
        public Int64 RIDRol { get; set; }
        public bool IDCheck { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
