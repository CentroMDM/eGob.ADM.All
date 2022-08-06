using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecattipodocumentos : ObjetoBase
    {
        

        public int RIDDocumentoRequerido { get; set; }
        public string NombreDocumento { get; set; }
        public string NombreCortoDocumento { get; set; }
        public string Descripcion { get; set; }
        public decimal TamanioMaximoMB { get; set; }
        
        
        //public int RIDTipoDocumento { get; set; }
        public bool Requerido { get; set; }
        public bool Mostrar { get; set; }
        public int Orden { get; set; }
        public int ClaveCCaso { get; set; }
        

        public List<EcatExtenciones> TipoArchivo { get; set; }
        public List<rarchivoextencion> RarchivoExtencion { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
