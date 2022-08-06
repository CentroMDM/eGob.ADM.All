using System;

namespace EntitiesPSR
{
    [Serializable]
    public class ECaracteristicasDeRoles : ObjetoBase
    {
        public Int64 RIDNivel { get; set; }
        public Int64 RIDRol { get; set; }
        public string nombreAplicacion { get; set; }
        public string nombreRol { get; set; }
        public string descripcionRol { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
