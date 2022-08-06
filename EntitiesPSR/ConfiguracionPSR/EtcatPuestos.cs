using System;
using System.ComponentModel.DataAnnotations;

namespace EntitiesPSR
{
    [Serializable]
    public class EtcatPuestos : ObjetoBase
    {
        public EtcatPuestos()
        {
            NivelPuesto = new EcatNivelesPuestos();
        }
        public int ClaveUnidadAdministrativa { get; set; }
        public int RIDPuestos { get; set; }
        public string BOIDPuesto { get; set; }
        public int ClaveNivelPuesto { get; set; }
        public string Nombre { get; set; }
        public string NombrePuesto { get; set; }
        public string Abreviatura { get; set; }
        public string DescripcionPuesto { get; set; }
        public string NombreUA { get; set; }
        public EcatNivelesPuestos NivelPuesto { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }

    }
}
