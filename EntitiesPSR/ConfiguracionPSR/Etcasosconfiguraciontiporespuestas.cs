using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Etcasosconfiguraciontiporespuestas : ObjetoBase
    {
        public int RID { get; set; }
        public int ClaveCCaso { get; set; }
        public int ClaveCCasoRespuesta { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
