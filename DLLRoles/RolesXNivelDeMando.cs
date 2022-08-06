using System;
using System.Collections.Generic;
using System.Data;
using EntitiesPSR;
using Utilerias;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DLLRoles
{
    public class RolesXNivelDeMando
    {
        public List<EcatNivelesPuestos> ObtenerNivelMando()
        {
            DatosRol obtenerNivelMando = new DatosRol();
            DataTable dtNivelesdeMando = obtenerNivelMando.ObtenerNivelMando();
            List<EcatNivelesPuestos> lsNivelesdeMando = UtilTablas.ConvertirDataTableToList<EcatNivelesPuestos>(dtNivelesdeMando);
            return lsNivelesdeMando;
        }
        public List<ERolesXNivel> GetRolesXNivel()
        {
            DatosRol obtenerRolesXNivel = new DatosRol();
            DataTable dtRolesXNivel = obtenerRolesXNivel.GetRolesXNivel();
            List<ERolesXNivel> lsRolesXNivel = UtilTablas.ConvertirDataTableToList<ERolesXNivel>(dtRolesXNivel);
            return lsRolesXNivel;
        }
        public List<ECaracteristicasDeRoles> RolesDeNivel(int RIDNivel)
        {
            DatosRol rolesDelNivel = new DatosRol();
            DataTable dtrolesDelNivel = rolesDelNivel.RolesDeNivel(RIDNivel);
            List<ECaracteristicasDeRoles> lsrolesDelNivel = UtilTablas.ConvertirDataTableToList<ECaracteristicasDeRoles>(dtrolesDelNivel);
            return lsrolesDelNivel;
        }
        public List<ECaracteristicasDeRoles> rolesAsignables(int RIDNivel)
        {
            DatosRol RolesA = new DatosRol();
            DataTable dtRolesA = RolesA.rolesAsignables(RIDNivel);
            List<ECaracteristicasDeRoles> lsRolesA = UtilTablas.ConvertirDataTableToList<ECaracteristicasDeRoles>(dtRolesA);
            return lsRolesA;
        }
        public List<EModulosCaractAcciones> DetalleDeLosRoles(int RIDRol)
        {
            DatosRol detalleRoles = new DatosRol();
            DataTable dtDetalleRoles = detalleRoles.DetalleDeLosRoles(RIDRol);
            List<EModulosCaractAcciones> lsDetalleRoles = UtilTablas.ConvertirDataTableToList<EModulosCaractAcciones>(dtDetalleRoles);
            return lsDetalleRoles;
        }
        public Resultado setNivelRol(ECaracteristicasDeRoles NivelRol)
        {
            DatosRol SetRolNivel = new DatosRol();
            DataTable dtRolNivel = SetRolNivel.setNivelRol(NivelRol);
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(dtRolNivel);
            return resultado;
        }
        public List<ECaracteristicasDeRoles> eliminaRolAsignado(ECaracteristicasDeRoles NivelRol)
        {
            DatosRol delRolNivel = new DatosRol();
            DataTable dtRolNivel = delRolNivel.eliminaRolAsignado(NivelRol);
            List<ECaracteristicasDeRoles> lsRolNivel = UtilTablas.ConvertirDataTableToList<ECaracteristicasDeRoles>(dtRolNivel);
            return lsRolNivel;
        }
    }
}
