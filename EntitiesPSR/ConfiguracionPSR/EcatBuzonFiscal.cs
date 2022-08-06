using System;

namespace EntitiesPSR
{
    [Serializable]
    public class EcatBuzonFiscal : ObjetoBase
    {
        public int RIDConfiguracion { get; set; }
        public string URLBuzonFiscal { get; set; }
        public int ClaveDirectorioLogoApp { get; set; }
        public string DirectorioSecundarioLogoApp { get; set; }
        public string DirectorioImagenesApp { get; set; }
        public string DirectorioImagenesVirtualApp { get; set; }
        public int ClaveDirectorioLogoInstitucional { get; set; }
        public int ClaveDirectorioLogo { get; set; }
        public string DirectorioSecundarioLogo { get; set; }
        public string DirectorioImagenesLogo { get; set; }
        public string DirectorioImagenesVirtualLogo { get; set; }
        public int ClaveDirectorioImagenHome { get; set; }
        public string DirectorioSecundarioImagenHome { get; set; }
        public string DirectorioImagenesHome { get; set; }
        public string DirectorioImagenesVirtualHome { get; set; }
        public string NombreTema { get; set; }
        public string ModoTema { get; set; }
        public string FLBF { get; set; }
        public string FLN { get; set; }
        public string DirectorioImagenesVirtual { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}