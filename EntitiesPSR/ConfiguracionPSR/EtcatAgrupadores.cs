using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    [Serializable]
    public class EtcatAgrupadores:ObjetoBase
    {
        public int RIDAgrupador { get; set; }
        public string nombreAgrupador { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }

    }



}
