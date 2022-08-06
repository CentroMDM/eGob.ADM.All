using System;

namespace EntitiesPSR
{
    [Serializable]
    public class EcatNivelesPuestos: ObjetoBase
    {

        public int RIDNivel { get; set; }
        public string BOIDNivel { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public Int64 PuestoMando { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
