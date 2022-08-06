using System;

namespace EntitiesPSR
{
    [Serializable]
    public class EAuxPreviewFormatos: ObjetoBase
    {

        public string NombreExterno { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public string Enum { get; set; }
        public int Orden { get; set; }
        public int Clave { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
