using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR.AppsRoles
{
    public class ECat_OpcionesMenu
    {
        public int ClaveCaracteristica { get; set; }   //	int(11)
        public int RIDOpcionMenu { get; set; } //	int(11)
        public string Nombre { get; set; }    //	varchar(128)
        public string Descripcion { get; set; }   //	varchar(255)
        public string Icono { get; set; } //	varchar(32)
        public string ColorHex { get; set; }  //	varchar(0)
        public DateTime? FechaInicio { get; set; }   //	varchar(0)
        public int ClaveStatus { get; set; }   //	int(11)
        public DateTime? FechaStatus { get; set; }   //	varchar(0)
    }
}
