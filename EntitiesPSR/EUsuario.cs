using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    public class EUsuario
    {
        public long RIDUsuario { get; set; }  //bigint(12)
        public string BOIDUsuario { get; set; } //varchar(20)
        public long ClaveEmpleado { get; set; }   //bigint(12)
        public string UserID { get; set; }  //varchar(256)
        public string UserPW { get; set; }  //varchar(256)
        public DateTime? FechaInicio { get; set; } //datetime
        public long ClaveStatus { get; set; } //bigint(12)
        public DateTime? FechaStatus { get; set; } //datetime
        public DateTime? FechaFin { get; set; }	//datetime
    }
}
