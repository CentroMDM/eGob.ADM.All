using System;
namespace EntitiesPSR
{
    [Serializable]
    public class Ergrupousuario : ObjetoBase
    {
        public int RID { get; set; }
        public int ClaveGrupoAtencion { get; set; }
        public int ClaveUsuario { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
