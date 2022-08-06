using System;

namespace EntitiesPSR
{
    [Serializable]
    public class EcatdiasInhabiles : ObjetoBase
    {
        public Int64 ClaveMotivoDiasInhabiles { get; set; }
        public string Motivo { get; set; }
        public int ClaveEntidadFederativa { get; set; }
        public int ClaveMunicipio { get; set; }
        public int RIDDiasInhabiles { get; set; }
        public int ClaveAplicaPara { get; set; }
        public string Aplica { get; set; }
        public DateTime FechaDiaInhabil { get; set; }
        public DateTime FechaDiaInhabilFinal { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
