using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecatconfiguracionvariables: ObjetoBase
    {
        public int RIDVariable { get; set; }
        public string NombreInterno { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
