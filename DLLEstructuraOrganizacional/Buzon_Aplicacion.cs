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
    public class Buzon_Aplicacion
    {
        //public List<Ecataplicaciones> AplicacionXUnidad(int RIDUnidad)
        //{
        //    DatosEO obtenerNivelXP = new DatosEO();
        //    DataTable dtNivelesXPuesto = obtenerNivelXP.AplicacionXUnidad(RIDUnidad);
        //    List<Ecataplicaciones> lsNivelesXP = UtilTablas.ConvertirDataTableToList<Ecataplicaciones>(dtNivelesXPuesto);
        //    return lsNivelesXP;
        //}
        public List<ETablaRelacionERB> BuzonesEmpleado(int RIDEmpleado)
        {
            DatosEO buzonXE = new DatosEO();
            DataTable dtbuzonesXE = buzonXE.BuzonesEmpleado(RIDEmpleado);
            List<ETablaRelacionERB> lsbuzonesXE = new Utilerias().Convertir<ETablaRelacionERB>(dtbuzonesXE);
            return lsbuzonesXE;
        }
        //public List<ETablaRelacionERB> BuzonesDeUsuario(int RIDUsuario)
        //{
        //    DatosEO buzonXU = new DatosEO();
        //    DataTable dtbuzonesXU = buzonXU.BuzonesDeUsuario(RIDUsuario);
        //    List<ETablaRelacionERB> lsbuzonesXU = UtilTablas.ConvertirDataTableToList<ETablaRelacionERB>(dtbuzonesXU);
        //    return lsbuzonesXU;
        //}
        public List<ErBuzonRoles> RolesXBuzon(int RIDEmpleado)
        {
            DatosEO obtenerNivelXP = new DatosEO();
            DataTable dtNivelesXPuesto = obtenerNivelXP.RolesXBuzon(RIDEmpleado);
            List<ErBuzonRoles> lsNivelesXP = new Utilerias().Convertir<ErBuzonRoles>(dtNivelesXPuesto);
            return lsNivelesXP;
        }
        public List<ECatRoles> GetDatosTablaTemporalERB(ETablaRelacionERB RIDNivel)
        {
            DatosEO rolesXNivelP = new DatosEO();
            DataTable dtrolesXNivelP = rolesXNivelP.GetDatosTablaTemporalERB(RIDNivel);
            List<ECatRoles> lsrolesXNivelP = new Utilerias().Convertir<ECatRoles>(dtrolesXNivelP);
            return lsrolesXNivelP;
        }
        public Resultado EliminaTablaTeporal()
        {
            DatosEO DelTablaT = new DatosEO();
            DataTable dtDelTablaT = DelTablaT.EliminaTablaTeporal();
            Resultado lsDelTablaT = new Utilerias().ResultadoDesdeTabla(dtDelTablaT);
            return lsDelTablaT;
        }
        public Resultado UsuariosSetDatosUsuariosTablaTemporal(int RIDUsuario)
        {
            DatosEO SetDatosUsuariosTT = new DatosEO();
            DataTable dtSetDatosUsuariosTT = SetDatosUsuariosTT.UsuariosSetDatosUsuariosTablaTemporal(RIDUsuario);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtSetDatosUsuariosTT);
            return resultado;
        }
        public List<ETablaRelacionERB> relacionesEliminadasTablaTemporal(int RIDUsuario)
        {
            DatosEO rTablaTemporal = new DatosEO();
            DataTable dtrTablaTemporal = rTablaTemporal.relacionesEliminadasTablaTemporal(RIDUsuario);
            List<ETablaRelacionERB> lsresultado = new Utilerias().Convertir<ETablaRelacionERB>(dtrTablaTemporal);
            return lsresultado;
        }
        public List<ETablaRelacionERB> relacionesNuevasTablaTemporal(int RIDUsuario)
        {
            DatosEO rTablaTemporal = new DatosEO();
            DataTable dtrTablaTemporal = rTablaTemporal.relacionesNuevasTablaTemporal(RIDUsuario);
            List<ETablaRelacionERB> lsresultado = new Utilerias().Convertir<ETablaRelacionERB>(dtrTablaTemporal);
            return lsresultado;
        }
        public List<ETablaRelacionERB> relacionesUBEliminadasTablaTemporal(int RIDUsuario)
        {
            DatosEO rTablaTemporal = new DatosEO();
            DataTable dtrTablaTemporal = rTablaTemporal.relacionesUBEliminadasTablaTemporal(RIDUsuario);
            List<ETablaRelacionERB> lsresultado = new Utilerias().Convertir<ETablaRelacionERB>(dtrTablaTemporal);
            return lsresultado;
        }
        public List<ETablaRelacionERB> relacionesUBNuevasTablaTemporal(int RIDUsuario)
        {
            DatosEO rTablaTemporal = new DatosEO();
            DataTable dtrTablaTemporal = rTablaTemporal.relacionesUBNuevasTablaTemporal(RIDUsuario);
            List<ETablaRelacionERB> lsresultado = new Utilerias().Convertir<ETablaRelacionERB>(dtrTablaTemporal);
            return lsresultado;
        }
    }
}
