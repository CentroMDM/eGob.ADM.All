using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecattodosroles: ObjetoBase
    {
        public int ClaveAplicacion { get; set; }
        public string NombreAplicacion { get; set; }
        public Int64 RIDRol { get; set; }
        public string nombreRol { get; set; }
        public string descripcionRol { get; set; }
        public string iconFontawesome { get; set; }
        public int claveStatusRol { get; set; }
        public string tipoRol { get; set; }
        public int lvlRol { get; set; }
        public int lvlMaximoRol { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
