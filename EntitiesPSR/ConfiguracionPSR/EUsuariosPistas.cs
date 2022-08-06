using System;

namespace EntitiesPSR
{
    [Serializable]
    public class EUsuariosPistas : ObjetoBase
    {
        public int RIDUsuario { get; set; }
        public int ClaveEmpleado { get; set; }
        public int RIDUnidadAdministrativa { get; set; }
        public string NombreEmpleado { get; set; }
        public string UserID { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
