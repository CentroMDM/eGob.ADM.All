using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    public class EEmpleadoXUnidad 
    {
        public EEmpleadoXUnidad()
        {
            Usuario = new Etusuarios();
        }
        public int RIDUnidadAdministrativa { get; set; }
        public string NombreUA { get; set; }
        public string NombreEmpleado { get; set; }
        public int ClaveUnidadAdministrativa { get; set; }
        public int RIDPuestos { get; set; }
        public string NombrePuesto { get; set; }
        public string UserID { get; set; }
        public string UserPW { get; set; }
        public string confirmUserPW { get; set; }
        public Etusuarios Usuario { get; set; }



    }
}
