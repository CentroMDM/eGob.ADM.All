using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{

    [Serializable]
    public class EClasificacionSujetoObjeto:ObjetoBase
    {

        public int ClaveSujetoObjeto { set; get; }
        public int ClaveClasificador { set; get; }

        public string ClaveObjeto { set; get; }

        //public override string ToString()
        //{
        //    return ObjetoBase.ObjetoEnCadena(this);
        //}

    }

}
