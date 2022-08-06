using System.Collections.Generic;
using System.Data;
using EntitiesPSR;
using DLLUtilerias;

namespace DLLEstructuraOrganizacional
{
    public class NivelesMando
    {
        public List<EcatNivelesPuestos> ObtenerNivelesPuestosInstitucionales()
        {
            DatosEO obtenerNivelMando = new DatosEO();
            DataTable dtNivelesdeMando = obtenerNivelMando.ObtenerNivelPuesto();
            List<EcatNivelesPuestos> lsNivelesdeMando = new Utilerias().Convertir<EcatNivelesPuestos>(dtNivelesdeMando);
            return lsNivelesdeMando;
        }
        public List<EcatNivelesPuestos> ObtenerNivelXPuesto(int RIDPuesto)
        {
            DatosEO obtenerNivelXP = new DatosEO();
            DataTable dtNivelesXPuesto = obtenerNivelXP.ObtenerNivelXPuesto(RIDPuesto);
            List<EcatNivelesPuestos> lsNivelesXP = new Utilerias().Convertir<EcatNivelesPuestos>(dtNivelesXPuesto);
            return lsNivelesXP;
        }
        public Resultado InsertarNivelPuesto(EcatNivelesPuestos catNivelPuestos)
        {
            DatosEO ingresarNivelMando = new DatosEO();
            //(int, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_NIVELESPUESTOS);
            int param1;
            string param2;
            (param1, param2) = ingresarNivelMando.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_NIVELESPUESTOS);
            catNivelPuestos.RIDNivel = param1;
            catNivelPuestos.BOIDNivel = param2;
            DataTable dtNivelesdeMando = ingresarNivelMando.InsertarNivelPuesto(catNivelPuestos);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtNivelesdeMando);
            return resultado;
        }
        public Resultado ActualizarNivelPuesto(EcatNivelesPuestos catNivelPuestos)
        {
            DatosEO actualizarNivelMando = new DatosEO();
            DataTable dtNivelesdeMando = actualizarNivelMando.ActualizarNivelPuesto(catNivelPuestos);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtNivelesdeMando);
            return resultado;
        }
        public Resultado EliminarNivelPuesto(EcatNivelesPuestos catNivelPuestos)
        {
            DatosEO ingresarNivelMando = new DatosEO();
            DataTable dtNivelesdeMando = ingresarNivelMando.EliminarNivelPuesto(catNivelPuestos);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtNivelesdeMando);
            return resultado;
        }
    }
}
