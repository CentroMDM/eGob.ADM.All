using System;

namespace EntitiesPSR
{
    public class Ectrlsaeventos: ObjetoBase
    {
        public int RID { get; set; }
        public int ClaveTipoUsuario { get; set; }
        public int ClaveUsuarioModifico { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }
        public DateTime FechaHora { get; set; }
        public string OrigenMovimiento { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
