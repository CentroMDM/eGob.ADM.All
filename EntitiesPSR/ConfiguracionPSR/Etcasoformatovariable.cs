using System;


namespace EntitiesPSR
{
    [Serializable]
    public class Etcasoformatovariable: ObjetoBase
    {
        public int ClaveTipoFormulario { get; set; }
        public int Clave { get; set; }
        public int RID { get; set; }
        public int Orden { get; set; }
        public int ClaveVariable { get; set; }
        public bool Required { get; set; }
        public string ContenidoDefault { get; set; }
        public string NombreInterno { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }

    }
}
