using System;

namespace EntitiesPSR
{
    [Serializable]
    public class EModulosCaractAcciones : ObjetoBase
    {
        public Int64 RIDAccesoRol { get; set; }
        public Int64 RIDRol { get; set; }
        public Int64 RIDModulo { get; set; }
        public string NombreModulo { get; set; }
        public Int64 RIDCaracteristica { get; set; }
        public string NombreCaracteristicas { get; set; }
        public Int64 RIDAccion { get; set; }
        public string NombreAccion { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
