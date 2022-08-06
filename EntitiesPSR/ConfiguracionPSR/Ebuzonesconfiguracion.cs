using System;
using System.Collections.Generic;

namespace EntitiesPSR
{
    [Serializable]
    public class Ebuzonesconfiguracion : ObjetoBase
    {
        public Ebuzonesconfiguracion() {
            Filtros = new List<Ebuzonconfiguracionfiltros>();
            Roles = new List<Ecattodosroles>();
            CatalogoDescriptivo = new Ecatdescriptivoitems();
            FiltroGrupoAtencion = new List<Ebuzonconfiguraciongruposatencion>();
        }

        public int RIDBuzon { get; set; }
        public string BOIDBuzon { get; set; }
        public int ClaveUnidadAdmva { get; set; }
        public int ClaveTipoBuzon { get; set; }
        public string NombreBuzon { get; set; }
        public string AliasBuzon { get; set; }
        public string Descripcion { get; set; }
        public int ClaveDirectorioLogo { get; set; }
        public string DirectorioSecundarioLogo { get; set; }
        public string DirectorioImagenesVirtual { get; set; }
        //public string IconoFontAsome { get; set; }
        public Ecatdescriptivoitems CatalogoDescriptivo { get; set; }
        public List<Ebuzonconfiguracionfiltros> Filtros { get; set; }
        public List<Ebuzonconfiguraciongruposatencion> FiltroGrupoAtencion {get;set;}
        public List<Ecattodosroles> Roles { get; set; }
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }
    }
}
