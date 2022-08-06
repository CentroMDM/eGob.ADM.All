using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    [Serializable]
    public class EConsultaObjetosClasificados:ObjetoBase
    {
        public int RIDItemCatalogo { set; get; }

        public string TipoObjeto { set; get; }

        public int RIDClasificador { set; get; }

        public string Clasificacion { set; get; }

        public string Identificador { set; get; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
