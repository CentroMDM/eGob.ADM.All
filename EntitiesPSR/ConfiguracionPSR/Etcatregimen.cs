namespace EntitiesPSR
{
    public class Etcatregimen : ObjetoBase
    {
        public int RIDRegimen { get; set; }
        public string Descripcion { get; set; }
        public int ClaveTipoPersona { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
