using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    [Serializable]
    public class EcatcpEntidadesFederativas : ObjetoBase
    {
        public int RIDEntidad { get; set; }
        public string Estado { get; set; }
        public string Abreviatura { get; set; }
        public long ClaveDirectorio { get; set; }
        public string DirectorioSecundario { get; set; }
        public string NombreLogo { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
