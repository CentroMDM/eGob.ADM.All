using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    [Serializable]
    public class EtCasosClasificadores : ObjetoBase
    {
        public long RID { get; set; }
        public int ClaveGrupo { get; set; }
        public int ClaveClasificador { get; set; }
        public int ClaveCaso { get; set; }
        public string NombreGrupo { get; set; }
        public string NombreClasificador { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
