using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    public class EcatTipoSujetosObjetos:ObjetoBase
    {
        
        public int RIDItemCatalogo { get; set; }
        
        public string nombreItem { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
