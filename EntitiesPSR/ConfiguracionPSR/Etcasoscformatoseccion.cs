using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Etcasoscformatoseccion:ObjetoBase
    {
        public int ClaveFormato { get; set; }
        public int RIDSeccion { get; set; }
        public int Orden { get; set; }
        public string NombreInterno { get; set; }
        public string NombreExterno { get; set; }
        public string DescripcionInterna { get; set; }
        public string DescripcionExterna { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }

    }
}
