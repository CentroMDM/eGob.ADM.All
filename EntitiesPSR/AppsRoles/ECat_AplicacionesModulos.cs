using System;
using System.Collections.Generic;

namespace EntitiesPSR.AppsRoles
{
    [Serializable]
    public class ECat_AplicacionesModulos : ObjetoBase
    {
        public ECat_AplicacionesModulos()
        {
            ListCaracteristicas = new List<ECat_AplicacionesModulosC>();
        }
        public int ClaveApplicacion { get; set; }  //	int(11)
        public int RIDModulo { get; set; } //	int(11)
        public int Orden { get; set; } //	int(4)
        public string NombreModulo { get; set; }  //	varchar(64)
        public string NombreColorHex { get; set; }    //	varchar(8)
        public string DescModulo { get; set; }    //	varchar(256)
        public string DescTecnicaModulo { get; set; } //	varchar(45)
        public string IconFontawesome { get; set; }   //	varchar(45)
        public string IconColorHex { get; set; }  //	varchar(7)
        public string DireccionURL { get; set; }  //	varchar(64)
        public string VersionModulo { get; set; } //	varchar(16)
        public List<ECat_AplicacionesModulosC> ListCaracteristicas { get; set; }   //	int(11)
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
