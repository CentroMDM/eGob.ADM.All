using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    public class rarchivoextencion:EcatExtenciones
    {
        public new int RID { get; set; }
        public int ClaveTipoDocumento { get; set; }
        public int ClaveExtencion { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
