using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Erccasoformatos:ObjetoBase
    {
        public int RID { get; set; }
        public int ClaveCCaso { get; set; }
        public int ClaveFormato { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
