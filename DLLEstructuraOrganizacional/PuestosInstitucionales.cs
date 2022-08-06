using System;
using System.Collections.Generic;
using System.Data;
using EntitiesPSR;
using DLLUtilerias;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLEstructuraOrganizacional
{
    public class PuestosInstitucionales
    {
        public List<EtcatPuestos> ConsultaPuesto()
        {
            DatosEO Puestos = new DatosEO();
            DataTable dtPuestos = Puestos.ConsultaPuesto();
            List<EtcatPuestos> lsPuestos = new Utilerias().Convertir<EtcatPuestos>(dtPuestos);
            return lsPuestos;
        }
        public List<EtcatPuestos> ObtenerPuestosXUnidad(int RIDUnidad)
        {
            DatosEO Puestos = new DatosEO();
            DataTable dtPuestos = Puestos.ObtenerPuestosXUnidad(RIDUnidad);
            List<EtcatPuestos> lsPuestos = new Utilerias().Convertir<EtcatPuestos>(dtPuestos);
            return lsPuestos;
        }
        public Resultado IngresarPuesto(EtcatPuestos catPuestos)
        {
            DatosEO ingresarPuesto = new DatosEO();
            int param1;
            string param2;
            (param1, param2) = ingresarPuesto.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_PUESTOS);
            catPuestos.RIDPuestos = param1;
            catPuestos.BOIDPuesto = param2;
            DataTable dtPuestos = ingresarPuesto.IngresarPuesto(catPuestos);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtPuestos);
            return resultado;
        }
        public Resultado ActualizarPuesto(EtcatPuestos catPuestos)
        {
            DatosEO actualizarPuesto = new DatosEO();
            DataTable dtPuestos = actualizarPuesto.ActualizarPuesto(catPuestos);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtPuestos);
            return resultado;
        }
        public Resultado EliminarPuesto(EtcatPuestos catPuestos)
        {
            DatosEO EliminarPuesto = new DatosEO();
            DataTable dtPuestos = EliminarPuesto.EliminarPuesto(catPuestos);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtPuestos);
            return resultado;
        }
    }
}
