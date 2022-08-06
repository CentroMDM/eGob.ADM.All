using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ewfprocesosetapas : ObjetoBase
    {
        public Ewfprocesosetapas() {
            Accion = new Ecatacciones();
        }

        public int ClaveProceso { get; set; }
        public Ewfprocesos Proceso { get; set; }
        public int RIDEtapa { get; set; }
        public string NombreEtapaInterno { get; set; }
        public string DescripcionEtapaIntarno { get; set; }
        public string NombreEtapaExterno { get; set; }
        public string DescripcionEtapaExterna { get; set; }
        public int ClaveAccion { get; set; }
        public Ecatacciones Accion { get; set; }
        public int OrdenEjecucion { get; set; }
        public bool EjecucionObligatoria { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
