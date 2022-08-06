using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntitiesPSR
{
	[Serializable]
	public class EtFirmantes
    {
		public Int64 RIDUsuario { get; set; }
		public Int64 RIDEmpleado { get; set; }
		public Int64 RIDPuestos { get; set; }
		public string RFCEmpleado { get; set; }
		public string NombreFirmante { get; set; }
		
	}
}
