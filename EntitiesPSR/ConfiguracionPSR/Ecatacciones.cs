using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecatacciones:ObjetoBase
    {
        public int RIDAccion { get; set; }
        public string NombreAccion { get; set; }
        public string DescripcionAccion { get; set; }
        public string Icono { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
