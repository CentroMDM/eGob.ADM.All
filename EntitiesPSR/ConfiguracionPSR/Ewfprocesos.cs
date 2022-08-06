using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ewfprocesos : ObjetoBase
    {

        public Ewfprocesos()
        {
            WorkFlowDefinicion = new Eworkflowdefinicion();
            //ProcesoPrincipal = new Ewfprocesos();
        }
        public int ClaveWorkFlow { get; set; }
        public Eworkflowdefinicion WorkFlowDefinicion { get; set; }
        public int ClaveProcesoPadre { get; set; }
        public Ewfprocesos ProcesoPrincipal { get; set; }
        public int RIDProceso { get; set; }
        public string NombreProcesoInterno { get; set; }
        public string DescripcionProcesoIntarno { get; set; }
        public string NombreProcesoExterno { get; set; }
        public string DescripcionProcesoExterna { get; set; }
        public int OrdenEjecucion { get; set; }
        public bool EjecucionObligatoria { get; set; }
        public bool ProcesoRepetitivo { get; set; }
        public int LimiteIteraciones { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
