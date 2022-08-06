using System;

namespace EntitiesPSR
{
    [Serializable]
    public class Eworkflowdefinicion: ObjetoBase
    {
        public int RIDWorkFlow { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }

    }
}
