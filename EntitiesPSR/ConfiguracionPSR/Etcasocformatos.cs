using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Etcasocformatos : ObjetoBase
    {
        //public int ClaveCCaso { get; set; }
        public int RID { get; set; }
        public int RIDFormato { get; set; }
        public int Orden { get; set; }
        public string NombreInterno { get; set; }
        public string NombreExterno { get; set; }
        public string DescipcionInterna { get; set; }
        public string DescripcionExterna { get; set; }
        public int ClavePathPlantilla { get; set; }
        public string DirectorioSecundario { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }

    }
}
