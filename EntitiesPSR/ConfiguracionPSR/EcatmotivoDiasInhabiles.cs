using System;

namespace EntitiesPSR
{
    [Serializable]
    public class EcatmotivoDiasInhabiles:ObjetoBase
    {
        public int RIDMotivoDias { get; set; }
        public string Motivo { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
