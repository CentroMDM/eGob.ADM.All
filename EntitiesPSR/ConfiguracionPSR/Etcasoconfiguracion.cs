using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class Etcasoconfiguracion : ObjetoBase
    {
        public int RIDCCaso { get; set; }
        public int ClaveUnidadAdministrativa { get; set; }//UA de quien configuró el caso 
        public int ClaveTipoServicio { get; set; }
        public int ClaveTipoCaso { get; set; }
        public Int64 ClasificacionCaso { get; set; }
        public string ClasificadorDeCaso { get; set; }
        public int ClaveStatusCCaso { get; set; }//Clave del Status de Publicado o sin Publicar
        public string StatusCCaso { get; set; }//Status de Publicado o sin Publicar
        public int ClaveWorkFlow { get; set; }
        public string Nombre { get; set; }
        public string NombreInterno { get; set; }
        public string NombreExterno { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionInterna { get; set; }
        public string DescripcionExterna { get; set; }
        public string AbreviaturaInterna { get; set; }
        public string AbreviaturaExterna { get; set; }

        //public int ClaveTipoDocumento { get; set; }

        public string PlantillaCuerpoDocumento { get; set; }
        public int DiasHabilesTerminoAtencion { get; set; }
        public int DiasHabilesRespuesta { get; set; }
        public bool PermitirRespuesta { get; set; }
        public bool RequiereAcuse { get; set; }
        public int ClavePathPlantillaAcuse { get; set; }
        public string DirectorioSecundarioAcuse { get; set; }
        public bool RequiereFiel { get; set; }
        public bool RequiereAutorizacion { get; set; }
        public int ClaveTipoResultado { get; set; }
        public int ClavePathPlantilla { get; set; }
        public string DirectorioSecundario { get; set; }
        public string DirectorioFisicoInterno { get; set; }
        public bool IniciaAutoridad { get; set; }
        public Int64 Prioridad { get; set; }
        //public string PlantillaGP { get; set; }
        //public bool ProcesoMasivo { get; set; }
        public List<Etcasocformatos> ListaFormatos { get; set; }
        public List<Etcasoformatovariable> Variables { get; set; }
        public List<Etcasoconfiguracion> Respuestas { get; set; }
        public List<Etunidadadministrativa> LstUnidadesAdministrativas { get; set; }
        public List<EtConfiguracionDocumentos> LstDocumentosRequeridos { get; set; }
        
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
