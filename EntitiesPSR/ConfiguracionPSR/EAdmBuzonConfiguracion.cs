using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class EAdmBuzonConfiguracion : ObjetoBase
    {
        public int RIDBuzon { get; set; }
        public int ClaveUnidadAdmva { get; set; }
        public int ClaveTipoBuzon { get; set; }
        public string NombreAplicacion { get; set; }
        public string NombreBuzon { get; set; }
        public string AliasBuzon { get; set; }
        public string Descripcion { get; set; }
        public int ClaveDirectorioLogo { get; set; }
        public string DirectorioSecundarioLogo { get; set; }
        public string CStatus { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
