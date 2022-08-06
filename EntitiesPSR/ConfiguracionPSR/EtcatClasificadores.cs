using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    [Serializable]
    public class EtcatClasificadores : ObjetoBase
    {
        public int RIDClasificador { set; get; }
        public int ClaveAgrupador { set; get; }
        public string nombreClasificador { set; get; }
        public string descripcionClasificador { set; get; }
        public string iconoClasificador { set; get; }
        public string colorClasificador { set; get; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
    
    
    [Serializable]
    public class EtcatAgrupadoresClasificadores : EtcatClasificadores
    {
        public int RIDAgrupador { set; get; }
        public string nombreAgrupador { set; get; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }

}
