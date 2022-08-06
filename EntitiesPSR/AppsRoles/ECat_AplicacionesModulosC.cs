using System;
using System.Collections.Generic;

namespace EntitiesPSR.AppsRoles
{
    [Serializable]
    public class ECat_AplicacionesModulosC : ObjetoBase
    {
        public ECat_AplicacionesModulosC()
        {
            ListAcciones = new List<ECat_MenuAcciones>();
        }

        public int ClaveModulo { get; set; }   //	int(11)
        public int RIDCaracteristica { get; set; } //	int(11)
        public int Orden { get; set; } //	int(4)
        public string NombreCaracteristicas { get; set; } //	varchar(64)
        public string DescripcionCaracteristica { get; set; } //	varchar(1024)
        public string ColorNombreHEX { get; set; }    //	varchar(8)
        public string IconFontawesome { get; set; }   //	varchar(45)
        public string IconColorHex { get; set; }  //	varchar(8)
        public int VersionCaracteristica { get; set; } //	int(11)
        public string DireccionURL { get; set; }  //	varchar(64)
        public List<ECat_MenuAcciones> ListAcciones { get; set; }  //	datetime
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
