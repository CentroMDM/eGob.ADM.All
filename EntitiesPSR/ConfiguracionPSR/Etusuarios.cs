using System;
using System.Collections.Generic;


namespace EntitiesPSR
{
    [Serializable]
    public class Etusuarios: ObjetoBase
    {
        public Etusuarios()
        {
            Buzones = new List<Erusuariobuzon>();
            RUBElimindas = new List<Erusuariobuzon>();
            RUBNuevas = new List<Erusuariobuzon>();
            RUSElimindas = new List<ErBuzonRoles>();
            RUSNuevas = new List<ErBuzonRoles>();
        }
        public int RIDUsuario { get; set; }
        public int ClaveEmpleado { get; set; }
        public int RIDUnidadAdministrativa { get; set; }
        public int RolBuzonFinal { get; set; }
        public string NombreUA { get; set; }
        public string NombreEmpleado { get; set; }
        public string RFCEmpleado { get; set; }
        public string UserID { get; set; }
        public string UserPW { get; set; }
        public string confirmUserPW { get; set; }
        public int ClaveNivelPuesto { get; set; }
        public string NombrePuesto { get; set; }
        //public int claveStatus { get; set; }
        public Boolean Firmante { get; set; }
        public string FundamentoFirma { get; set; }
        public string BOIDUsuario { get; set; }
        public List<Erusuariobuzon> Buzones { get; set; }
        public List<Erusuariobuzon> RUBElimindas { get; set; }
        public List<Erusuariobuzon> RUBNuevas { get; set; }
        public List<ErBuzonRoles> RUSElimindas { get; set; }
        public List<ErBuzonRoles> RUSNuevas { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
