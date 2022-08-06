using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    [Serializable]
    public class EtConfiguracionDocumentos : ObjetoBase
    {
		public Int64 RIDRequisito { get; set; }//Relacion entre CCaso y CDocumentoReq   --> tcasos_configuracion_documentosrequeridos 
		public string NombreDocumento { get; set; }
		public bool Requerido { get; set; }
		public string NombreCortoDocumento { get; set; }
		public string Descripcion { get; set; }
		public string NombreTipoArchivo { get; set; }
		public string Extencion { get; set; }
		public decimal TamanioMaximoMB { get; set; }
		public int Orden { get; set; }
		public bool Mostrar { get; set; }
		public string TypeMime { get; set; }
		public string Documento { get; set; }		
		public Int64 ClaveCCaso { get; set; }
		public Int64 RIDDocumentoRequerido { get; set; }
		public Int64 ClaveExtencion { get; set; }
		public override string ToString()
		{
			return ObjetoBase.ObjetoEnCadena(this);
		}
	}
}
