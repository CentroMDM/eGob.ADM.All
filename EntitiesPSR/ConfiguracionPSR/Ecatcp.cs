using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecatcp: ObjetoBase
    {
        public int IDPrincipal
        {
            get
            {
                return RIDCP;
            }
        }
        public int RIDCP { get; set; }
        public int ClaveEntidad { get; set; }
        public int ClaveMunicipio { get; set; }
        public string CP { get; set; }
        public int ClaveTipoAsentamiento { get; set; }
        public string NombreAsentamiento { get; set; }
        
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
