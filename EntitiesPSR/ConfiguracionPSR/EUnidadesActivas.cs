using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class EUnidadesActivas : ObjetoBase
    {
        public int RIDUnidadAdministrativa { get; set; }
        public string NombreUA { get; set; }
        public string AbreviaturaUA { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
