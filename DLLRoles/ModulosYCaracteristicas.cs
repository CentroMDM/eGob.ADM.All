using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntitiesPSR;
using Utilerias;

namespace DLLRoles
{
    public class ModulosYCaracteristicas
    {
        public List<Ecattodosroles> GetTodosLosRoles()
        {
            DatosRol todosRoles = new DatosRol();
            DataTable dttodosRoles = todosRoles.GetTodosLosRoles();
            List<Ecattodosroles> lstodosRoles = UtilTablas.ConvertirDataTableToList<Ecattodosroles>(dttodosRoles);
            return lstodosRoles;
        }
        public List<Ecataplicaciones> Getcataplicaciones()
        {
            DatosRol todasApps = new DatosRol();
            DataTable dtTodasApps = todasApps.Getcataplicaciones();
            List<Ecataplicaciones> lsTodasApps = UtilTablas.ConvertirDataTableToList<Ecataplicaciones>(dtTodasApps);
            return lsTodasApps;
        }
        public List<Ecattodosroles> obtenerRolXAplicacion(int RIDApp)
        {
            DatosRol rolesXApp = new DatosRol();
            DataTable dtRolesXApp = rolesXApp.obtenerRolXAplicacion(RIDApp);
            List<Ecattodosroles> lsRolesXApp = UtilTablas.ConvertirDataTableToList<Ecattodosroles>(dtRolesXApp);
            return lsRolesXApp;
        }
        public Resultado setNewRol(Ecattodosroles datosDeRol)
        {
            DatosRol SetNewRol = new DatosRol();
            DataTable dtSetNewRol = SetNewRol.setNewRol(datosDeRol);
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(dtSetNewRol);
            return resultado;
        }
        public List<Ecattodosroles> DeleteRolyRelacionesRol(int RIDRol)
        {
            DatosRol delRol = new DatosRol();
            DataTable dtDelRol = delRol.DeleteRolyRelacionesRol(RIDRol);
            List<Ecattodosroles> lsDelRol = UtilTablas.ConvertirDataTableToList<Ecattodosroles>(dtDelRol);
            return lsDelRol;
        }
        public List<Ecattodosroles> GetNewRol(Ecattodosroles aplicacionRol)
        {
            DatosRol newRol = new DatosRol();
            DataTable dtNewRol = newRol.GetNewRol(aplicacionRol);
            List<Ecattodosroles> lsNewRol = UtilTablas.ConvertirDataTableToList<Ecattodosroles>(dtNewRol);
            return lsNewRol;
        }
        public List<EModulosCaractAcciones> GetModulosXAplicacion(Ecattodosroles aplicacionRol)
        {
            DatosRol catModulos = new DatosRol();
            DataTable dtCatModulos = catModulos.GetModulosXAplicacion(aplicacionRol);
            List<EModulosCaractAcciones> lsCatModulos = UtilTablas.ConvertirDataTableToList<EModulosCaractAcciones>(dtCatModulos);
            return lsCatModulos;
        }
        public List<EModulosCaractAcciones> GetModulosCXRol(EModulosCaractAcciones moduloRol)
        {
            DatosRol catModulosC = new DatosRol();
            DataTable dtCatModulosC = catModulosC.GetModulosCXRol(moduloRol);
            List<EModulosCaractAcciones> lsCatModulosC = UtilTablas.ConvertirDataTableToList<EModulosCaractAcciones>(dtCatModulosC);
            return lsCatModulosC;
        }
        public List<EModulosCaractAcciones> GetAccionXRol(EModulosCaractAcciones caractRol)
        {
            DatosRol catAcciones = new DatosRol();
            DataTable dtCatAcciones = catAcciones.GetAccionXRol(caractRol);
            List<EModulosCaractAcciones> lsCatAcciones = UtilTablas.ConvertirDataTableToList<EModulosCaractAcciones>(dtCatAcciones);
            return lsCatAcciones;
        }
        public Resultado Roles_SetAccesosM(EModulosCaractAcciones Modul)
        {
            DatosRol SetModul = new DatosRol();
            DataTable dtnewAcceso = SetModul.Roles_SetAccesosM(Modul);
            Resultado newAcceso = UtilTablas.ResultadoDesdeTabla(dtnewAcceso);
            return newAcceso;
        }
        public Resultado Roles_SetAccesosMC(EModulosCaractAcciones ModulCaract)
        {
            DatosRol SetModulCaract = new DatosRol();
            DataTable dtnewAcceso = SetModulCaract.Roles_SetAccesosMC(ModulCaract);
            Resultado newAcceso = UtilTablas.ResultadoDesdeTabla(dtnewAcceso);
            return newAcceso;
        }
        public Resultado Roles_SetAccesosAll(EModulosCaractAcciones ModulCaractAccion)
        {
            DatosRol SetModulCaractAccion = new DatosRol();
            DataTable dtnewAcceso = SetModulCaractAccion.Roles_SetAccesosAll(ModulCaractAccion);
            Resultado newAcceso = UtilTablas.ResultadoDesdeTabla(dtnewAcceso);
            return newAcceso;
        }
        public List<EModulosCaractAcciones> EliminarRaccesoRol(EModulosCaractAcciones RaccesoRol)
        {
            DatosRol delRaccesoRol = new DatosRol();
            DataTable dtRaccesoRol = delRaccesoRol.EliminarRaccesoRol(RaccesoRol);
            List<EModulosCaractAcciones> lsRaccesoRol = UtilTablas.ConvertirDataTableToList<EModulosCaractAcciones>(dtRaccesoRol);
            return lsRaccesoRol;
        }
        public List<Ecattodosroles> UpdateCatRol(Ecattodosroles dataCatRoles)
        {
            DatosRol upCatRoles = new DatosRol();
            DataTable dtCatRoles = upCatRoles.UpdateCatRol(dataCatRoles);
            List<Ecattodosroles> lsCatRoles = UtilTablas.ConvertirDataTableToList<Ecattodosroles>(dtCatRoles);
            return lsCatRoles;
        }
    }
}
