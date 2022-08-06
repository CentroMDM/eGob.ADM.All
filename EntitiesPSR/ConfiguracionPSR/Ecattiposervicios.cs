using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Ecattiposervicios : ObjetoBase
    {
        public int RID { get; set; }
        public int ClaveClasificadorServicio { get; set; }
        public string NombreServicio { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public string DirectorioSecundario { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }

    }
}
