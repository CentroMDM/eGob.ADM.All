using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class Etgruposatencion: ObjetoBase
    {
        public Etgruposatencion() {
            Buzon = new Ebuzonesconfiguracion();
            Usuarios = new List<Etempleados>();
        }
        public int ClaveBuzon { get; set; }
        public int RIDGrupo { get; set; }
        public string BOIDGrupo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombreSP { get; set; }
        public Ebuzonesconfiguracion Buzon { get; set; }
        public List<Etempleados> Usuarios { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
