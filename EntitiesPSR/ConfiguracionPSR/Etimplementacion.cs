using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class Etimplementacion: ObjetoBase
    {
        public Etimplementacion() {

            Aplicaciones = new List<Ecataplicaciones>();
            NivelesGobierno = new List<EcatNivelGobierno>();
        }

        public long RIDImplementacion { get; set; }
        public string GUIDImplementacion { get; set; }
        public string Nombre { get; set; }
        public string NombreTema { get; set; }
        public string ModoTema { get; set; }
        public string Lema { get; set; }
        public int ClaveDirectorioLogoImplementacion { get; set; }
        public string FaviconDirectorioSecundario { get; set; }
        public string LogoDirectorioSecundario { get; set; }
        public string ImagenHomeDirectorioSecundario { get; set; }
        public string DirectorioImagenesVirtual { get; set; }
        public string NombreAbreviado { get; set; }
        public DateTime HorarioInicioLaboral { get; set; }
        public DateTime HorarioFinLaboral { get; set; }
        public List<Ecataplicaciones> Aplicaciones { get; set; }
        public List<EcatNivelGobierno> NivelesGobierno { get; set; }
        public int Estado { get; set; }
        public int ClaveMunicipio { get; set; }
        public string CodigoPostal { get; set; }
        public int ClaveCP { get; set; }
        public string Calle { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        //public string Privacidad { get; set; }

        public int claveNivelGobierno { get; set; }
        public int claveEntidadNivelGobierno { get; set; }
        public int claveMunicipioNivelGobierno { get; set; }

        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
