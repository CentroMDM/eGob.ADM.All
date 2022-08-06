using System.Collections.Generic;
using System.Linq;
using EntitiesPSR;

namespace Utilerias
{
    public class _GenerarOrganigrama
    {
        //public Organigrama GeneraOrganigrama(List<Etunidadadministrativa> unidadesAdministrativas) {
        //    Organigrama org = new Organigrama();
        //    Etunidadadministrativa unidadAuxiliar = unidadesAdministrativas.Where(p => p.ClaveUAPadre == 0).First();
        //    org.children = new List<Organigrama>();
        //    org.title = "";
        //    org.name = unidadAuxiliar.NombreUA;
        //    org.identificador = unidadAuxiliar.RIDUnidadAdministrativa;
        //    IngresarDatosOrg(unidadesAdministrativas, org);
        //    return org;
        //}

        //public void IngresarDatosOrg(List<Etunidadadministrativa> unidadesAdministrativas, Organigrama org) {
        //    foreach (Etunidadadministrativa unidad in unidadesAdministrativas) {
        //        if (unidad.ClaveUAPadre == 0)
        //        {
        //            continue;
        //        }
        //        else {
        //            if (unidad.ClaveUAPadre == org.identificador) {
        //                Organigrama orgAux = new Organigrama
        //                {
        //                    title = "",
        //                    name = unidad.NombreUA,
        //                    identificador = unidad.RIDUnidadAdministrativa,
        //                    children = new List<Organigrama>()
        //                };
        //                org.children.Add(orgAux);
        //                IngresarDatosOrg(unidadesAdministrativas, orgAux);
        //            }
        //        }

        //    }
        //}
    }
}
