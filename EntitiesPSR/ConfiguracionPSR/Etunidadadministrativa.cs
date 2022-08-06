
using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class Etunidadadministrativa:ObjetoBase
    {

        public Etunidadadministrativa() {
            Buzones = new List<Ebuzonesconfiguracion>();
            Empleados = new List<Etempleados>();
            Puestos = new List<EtcatPuestos>();
        }
        public long ClaveImplementacion { get; set; }
        public int ClaveUAPadre { get; set; }
        public int RIDUnidadAdministrativa { get; set; }
        public string BOIDUnidadAdministrativa { get; set; }
        public string NombreUA { get; set; }
        public string AbreviaturaUA { get; set; }
        public long ClaveDirectorioLogo { get; set; }
        public string DirectorioSecundarioLogo { get; set; }
        public string DirectorioImagenesVirtual { get; set; }
        public Int64 ClaveCP { get; set; }
        public string Calle { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        public string Estado { get; set; }
        public Int64 ClaveMunicipio { get; set; }
        public string CodigoPostal { get; set; }
        public Int64 ClaveEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public List<Etempleados> Empleados { get; set; }
        public List<Ebuzonesconfiguracion> Buzones { get; set; }
        public List<EtcatPuestos> Puestos { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
