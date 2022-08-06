using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntitiesPSR;
using System.Data;
using System.IO;
using ClsLayoutSettings;
using Utilerias;
using DLLRoles;
using static ClsLayoutSettings.LS;


namespace ConfiguracionPSRV2.Controllers
{
    public class ConfiguracionRolesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        #region RolesPorNivelDeMando
        public ActionResult RolesPorNivelDeMando()
        {
            return View();
        }
        public JsonResult ObtenerNivelMando()
        {
            RolesXNivelDeMando NivelesDeMando = new RolesXNivelDeMando();
            List<EcatNivelesPuestos> NivelesdeMando = NivelesDeMando.ObtenerNivelMando();
            return Json(NivelesdeMando, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRolesXNivel()
        {
            RolesXNivelDeMando RolesXNivel = new RolesXNivelDeMando();
            List<ERolesXNivel> RolesDelNivel = RolesXNivel.GetRolesXNivel();
            return Json(RolesDelNivel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RolesDeNivel(int objetoNegocio)
        {
            RolesXNivelDeMando rolesDelNivel = new RolesXNivelDeMando();
            List<ECaracteristicasDeRoles> lsrolesDelNivel = rolesDelNivel.RolesDeNivel(objetoNegocio);
            return Json(lsrolesDelNivel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult rolesAsignables(int objetoNegocio)
        {
            RolesXNivelDeMando RolesA = new RolesXNivelDeMando();
            List<ECaracteristicasDeRoles> lsRolesA = RolesA.rolesAsignables(objetoNegocio);
            return Json(lsRolesA, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DetalleDeLosRoles(int objetoNegocio)
        {
            RolesXNivelDeMando detalleRoles = new RolesXNivelDeMando();
            List<EModulosCaractAcciones> lsDetalleRoles = detalleRoles.DetalleDeLosRoles(objetoNegocio);
            return Json(lsDetalleRoles, JsonRequestBehavior.AllowGet);
        }
        public JsonResult setNivelRol(ECaracteristicasDeRoles objetoNegocio)
        {
            RolesXNivelDeMando SetRolNivel = new RolesXNivelDeMando();
            Resultado newRolNivel = SetRolNivel.setNivelRol(objetoNegocio);
            return Json(newRolNivel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult eliminaRolAsignado(ECaracteristicasDeRoles objetoNegocio)
        {
            RolesXNivelDeMando delRolNivel = new RolesXNivelDeMando();
            List<ECaracteristicasDeRoles> lsRolNivel = delRolNivel.eliminaRolAsignado(objetoNegocio);
            return Json(lsRolNivel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ModulosYCaracteristicas
        public ActionResult ModulosYCaracteristicas()
        {
            return View();
        }
        public JsonResult GetTodosLosRoles()
        {
            ModulosYCaracteristicas todosRoles = new ModulosYCaracteristicas();
            List<Ecattodosroles> lstodosRoles = todosRoles.GetTodosLosRoles();
            return Json(lstodosRoles, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Getcataplicaciones()
        {
            ModulosYCaracteristicas todasApps = new ModulosYCaracteristicas();
            List<Ecataplicaciones> lstodasApps = todasApps.Getcataplicaciones();
            return Json(lstodasApps, JsonRequestBehavior.AllowGet);
        }
        public JsonResult obtenerRolXAplicacion(int objetoNegocio)
        {
            ModulosYCaracteristicas rolesXApp = new ModulosYCaracteristicas();
            List<Ecattodosroles> lsRolesXApp = rolesXApp.obtenerRolXAplicacion(objetoNegocio);
            return Json(lsRolesXApp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult setNewRol(Ecattodosroles objetoNegocio)
        {
            ModulosYCaracteristicas SetNewRol = new ModulosYCaracteristicas();
            Resultado newSetNewRol = SetNewRol.setNewRol(objetoNegocio);
            return Json(newSetNewRol, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteRolyRelacionesRol(int objetoNegocio)
        {
            ModulosYCaracteristicas delRol = new ModulosYCaracteristicas();
            List<Ecattodosroles> lsDelRol = delRol.DeleteRolyRelacionesRol(objetoNegocio);
            return Json(lsDelRol, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNewRol(Ecattodosroles objetoNegocio)
        {
            ModulosYCaracteristicas newRol = new ModulosYCaracteristicas();
            List<Ecattodosroles> lsNewRol = newRol.GetNewRol(objetoNegocio);
            return Json(lsNewRol, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetModulosXAplicacion(Ecattodosroles objetoNegocio)
        {
            ModulosYCaracteristicas catModulos = new ModulosYCaracteristicas();
            List<EModulosCaractAcciones> lsCatModulos = catModulos.GetModulosXAplicacion(objetoNegocio);
            return Json(lsCatModulos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetModulosCXRol(EModulosCaractAcciones objetoNegocio)
        {
            ModulosYCaracteristicas catModulosC = new ModulosYCaracteristicas();
            List<EModulosCaractAcciones> lsCatModulosC = catModulosC.GetModulosCXRol(objetoNegocio);
            return Json(lsCatModulosC, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAccionXRol(EModulosCaractAcciones objetoNegocio)
        {
            ModulosYCaracteristicas catAcciones = new ModulosYCaracteristicas();
            List<EModulosCaractAcciones> lsCatAcciones = catAcciones.GetAccionXRol(objetoNegocio);
            return Json(lsCatAcciones, JsonRequestBehavior.AllowGet);
        }        
        public JsonResult Roles_SetAccesosM(EModulosCaractAcciones objetoNegocio)
        {
            ModulosYCaracteristicas SetModul = new ModulosYCaracteristicas();
            Resultado newAcceso = SetModul.Roles_SetAccesosM(objetoNegocio);
            return Json(newAcceso, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Roles_SetAccesosMC(EModulosCaractAcciones objetoNegocio)
        {
            ModulosYCaracteristicas SetModulCaract = new ModulosYCaracteristicas();
            Resultado newAcceso = SetModulCaract.Roles_SetAccesosMC(objetoNegocio);
            return Json(newAcceso, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Roles_SetAccesosAll(EModulosCaractAcciones objetoNegocio)
        {
            ModulosYCaracteristicas SetModulCaractAccion = new ModulosYCaracteristicas();
            Resultado newAcceso = SetModulCaractAccion.Roles_SetAccesosAll(objetoNegocio);
            return Json(newAcceso, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarRaccesoRol(EModulosCaractAcciones objetoNegocio)
        {
            ModulosYCaracteristicas delRaccesoRol = new ModulosYCaracteristicas();
            List<EModulosCaractAcciones> lsRaccesoRol = delRaccesoRol.EliminarRaccesoRol(objetoNegocio);
            return Json(lsRaccesoRol, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateCatRol(Ecattodosroles objetoNegocio)
        {
            ModulosYCaracteristicas upCatRoles = new ModulosYCaracteristicas();
            List<Ecattodosroles> lsCatRoles = upCatRoles.UpdateCatRol(objetoNegocio);
            return Json(lsCatRoles, JsonRequestBehavior.AllowGet);
        }        
        #endregion
    }
}