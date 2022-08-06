using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class Erusuariobuzon:ObjetoBase
    {
        public Erusuariobuzon()
        {
            ClaveRol = new List<ErBuzonRoles>();
            RUSElimindas = new List<ErBuzonRoles>();
            RUSNuevas = new List<ErBuzonRoles>();
        }
        public int RID { get; set; }
        public int ClaveUsuario { get; set; }
        public int ClaveAplicacion { get; set; }
        public int ClaveBuzon { get; set; }
        public int RIDRUS { get; set; }        
        public int RIDRol { get; set; }
        public int RIDUsuarioBuzon { get; set; }

        public List<ErBuzonRoles> ClaveRol { get; set; }
        public List<ErBuzonRoles> RUSElimindas { get; set; }
        public List<ErBuzonRoles> RUSNuevas { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
