using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ebuzonconfiguracionfiltros:ObjetoBase
    {
        public int RID { get; set; }
        public int ClaveBuzon { get; set; }
        public string NombreBuzon { get; set; }
        public int ClaveTipoFiltro { get; set; }
        public string NombreFiltro { get; set; }
        public int ClaveCatalogo { get; set; }
        public string Municipio { get; set; }

        public string Nombre { get; set; }
        public string Display { get; set; }
        public string Descripcion { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
