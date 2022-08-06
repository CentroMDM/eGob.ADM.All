using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecatdescriptivoitems:ObjetoBase
    {
        public long ClaveCatalogo { get; set; }
	    public string NombreItem { get; set; }
        public long RIDItemCatalogo { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
