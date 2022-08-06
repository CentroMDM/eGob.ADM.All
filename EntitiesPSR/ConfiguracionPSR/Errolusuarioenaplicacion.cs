using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Errolusuarioenaplicacion : ObjetoBase
    {
        public long RIDRUS { get; set; }
        public long ClaveApplicacion { get; set; }
        public long ClaveUsuario { get; set; }
        public long ClaveBuzon { get; set; }
        public long ClaveRol { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
