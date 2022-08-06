using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Etcasosconfiguracionmetadatos : ObjetoBase
    {
        public long IDPrincipal
        {
            get
            {
                return RIDMetadatos;
            }
        }
        public long ClaveCCaso { get; set; }
        public int RIDMetadatos { get; set; }
        public string BOIDMetadatos { get; set; }
        public string Etiqueta { get; set; }
        public string TipoInput { get; set; }
        public string TipoDato { get; set; }
        public string Styles { get; set; }
        public int Orden { get; set; }
        public string ListadosOpciones { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
