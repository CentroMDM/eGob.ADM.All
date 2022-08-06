using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class ERolesXNivel : ObjetoBase
    {
        public Int64 RIDPuestoRol { get; set; }
        public Int64 RIDNivel { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public Int64 RIDRol { get; set; }
        public string nombreRol { get; set; }
        public string descripcionRol { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
