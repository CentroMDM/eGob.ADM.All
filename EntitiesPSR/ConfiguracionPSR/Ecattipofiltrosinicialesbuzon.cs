using System;
namespace EntitiesPSR
{
    [Serializable]
    public class Ecattipofiltrosinicialesbuzon:ObjetoBase
    {
        public int RID { get; set; }
        public string Nombre { get; set; }
        public string SP_GetCatalogo { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
