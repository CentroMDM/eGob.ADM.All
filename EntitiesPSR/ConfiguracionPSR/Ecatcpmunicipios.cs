using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecatcpmunicipios:ObjetoBase
    {
        public int ClaveEntidad { get; set; }
        public int RIDMunicipio { get; set; }
        public string Municipio { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
