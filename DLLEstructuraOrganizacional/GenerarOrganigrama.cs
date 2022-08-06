using System.Collections.Generic;
using System.Linq;
using EntitiesPSR;

namespace DLLEstructuraOrganizacional
{
    public class GenerarOrganigrama
    {
        public Organigrama ObtenerOrganigrama(List<Etunidadadministrativa> unidadesAdministrativas) {
            Organigrama org = new Organigrama();
            Etunidadadministrativa unidadAuxiliar = unidadesAdministrativas.Where(p => p.ClaveUAPadre == 0).First();
            org.children = new List<Organigrama>();
            org.title = unidadAuxiliar.NombreEmpleado;//Este es el cuerpo
            org.name = unidadAuxiliar.NombreUA;//Este es el titulo
            org.identificador = unidadAuxiliar.RIDUnidadAdministrativa;
            IngresarDatosOrg(unidadesAdministrativas, org);
            return org;
        }

        public void IngresarDatosOrg(List<Etunidadadministrativa> unidadesAdministrativas, Organigrama org) {
            foreach (Etunidadadministrativa unidad in unidadesAdministrativas) {
                if (unidad.ClaveUAPadre == 0)
                {
                    continue;
                }
                else {
                    if (unidad.ClaveUAPadre == org.identificador) {
                        Organigrama orgAux = new Organigrama
                        {
                            title = unidad.NombreEmpleado,
                            name = unidad.NombreUA,
                            identificador = unidad.RIDUnidadAdministrativa,
                            children = new List<Organigrama>()
                        };
                        org.children.Add(orgAux);
                        IngresarDatosOrg(unidadesAdministrativas, orgAux);
                    }
                }

            }
        }
    }
}
