using System;


namespace EntitiesPSR
{
    [Serializable]
    public class Ebuzonconfiguraciongruposatencion:ObjetoBase
    {
        public int RID { get; set; }
        public int ClaveBuzon { get; set; }
        public int ClaveTipoGrupo { get; set; }
        public int ClaveCatalogo { get; set; }
        public string Display { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public int ClaveGrupoAtencion { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
