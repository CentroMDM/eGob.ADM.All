using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecataplicaciones : ObjetoBase
    {
        public long RIDAplicacion { get; set; }
        public string NombreAplicacion { get; set; }
        public string URLAcceso { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
