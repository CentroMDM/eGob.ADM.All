using System;

namespace EntitiesPSR.AppsRoles
{
    [Serializable]
    public class ECat_MenuAcciones : ObjetoBase
    {
        public int ClaveCaracteristica { get; set; }   //	int(11)
        public int RIDAccion { get; set; } //	int(11)
        public int Orden { get; set; } //	int(4)
        public string Nombre { get; set; }    //	varchar(128)
        public string Descripcion { get; set; }   //	varchar(255)
        public string IconFontawesome { get; set; }   //	varchar(32)
        public string ColorHex { get; set; }  //	varchar(0)
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
