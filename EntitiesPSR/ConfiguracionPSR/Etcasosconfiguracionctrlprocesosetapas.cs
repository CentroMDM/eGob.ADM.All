using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Etcasosconfiguracionctrlprocesosetapas : ObjetoBase
    {
        public long IDPrincipal
        {
            get
            {
                return RIDCtrlPE;
            }
        }
        public long RIDCtrlPE { get; set; }
        public string BOIDCtrlPE { get; set; }
        public long ClaveTipoCaso { get; set; }
        public int OrdenSeguimiento { get; set; }
        public bool SeguimientoObligatorio { get; set; }
        public long ClaveProceso { get; set; }
        public long ClaveEtapa { get; set; }
        public int Duracion { get; set; }
        public string CambioStatusAuto { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
