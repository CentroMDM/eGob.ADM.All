using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    public class EcatExtenciones : ObjetoBase
    {
		public int RID { get; set; }
		public string NombreTipoArchivo { get; set; }
		public string NombreCorto { get; set; }
		public string Extencion { get; set; }
		public string TypeMime { get; set; }
		
		public override string ToString()
		{
			return ObjetoBase.ObjetoEnCadena(this);
		}
	}
}
