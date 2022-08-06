using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Mvc;
using EntitiesPSR;
using DLLEstructuraOrganizacional;
using static ClsLayoutSettings.LS;
using Utilerias;



namespace ConfiguracionPSRV2.Controllers
{
    public class EstructuraOrganizacionalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NivelesDeMando()
        {
            return View();
        }
        public ActionResult PuestosInstitucionales()
        {
            return View();
        }
        public ActionResult Empleados()
        {
            return View();
        }
        public ActionResult UnidadAdministrativa()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult DesbloqueoDeCuenta()
        {
            return View();
        }
        public ActionResult GruposAtencion()
        {
            return View();
        }

        //#region Usuarios

        ////////////////////////////////////////////////////////////////////////////////////////////////public JsonResult GetUsuarios()
        //public JsonResult ObtenerUsuariosActivos()
        //{
        //    Usuarios usuarios = new Usuarios();
        //    List<Etusuarios> lsusuarios = usuarios.ObtenerUsuariosActivos();
        //    return Json(lsusuarios, JsonRequestBehavior.AllowGet);
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////public JsonResult AplicacionesxUnidad(int objetoNegocio)
        //public JsonResult ObtenerUsuariosActivosXU(int objetoNegocio)
        //{
        //    Usuarios usuariosXU = new Usuarios();
        //    List<Etusuarios> lsusuariosXU = usuariosXU.ObtenerUsuariosActivosXU(objetoNegocio);
        //    return Json(lsusuariosXU, JsonRequestBehavior.AllowGet);
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////public JsonResult ObtenerUsuariosXUnidadA(int objetoNegocio)      
        //public JsonResult ObtenerFirmantes()
        //{
        //    Usuarios firmantes = new Usuarios();
        //    List<Etusuarios> lsfirmantes = firmantes.ObtenerFirmantes();
        //    return Json(lsfirmantes, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult ObtenerFirmantesXU(int objetoNegocio)
        //{
        //    Usuarios firmantesXU = new Usuarios();
        //    List<Etusuarios> lsfirmantesXU = firmantesXU.ObtenerFirmantesXU(objetoNegocio);
        //    return Json(lsfirmantesXU, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult ObtenerFirmantesActivos()
        //{
        //    Usuarios firmantesA = new Usuarios();
        //    List<Etusuarios> lsfirmantesA = firmantesA.ObtenerFirmantesActivos();
        //    return Json(lsfirmantesA, JsonRequestBehavior.AllowGet);
        //}
        ////////////////////////////////////////////////////////////////////////////////////public JsonResult getNewUsuarios(int objetoNegocio)
        ////////////////////////////////////////////////////////////////////////////////////public JsonResult UsuariosExistentes(int objetoNegocio)     
        //public JsonResult GetTableRelacionERB()
        //{
        //    Usuarios relacionERB = new Usuarios();
        //    List<ETablaRelacionERB> lsrelacionesERB = relacionERB.GetTableRelacionERB();
        //    return Json(lsrelacionesERB, JsonRequestBehavior.AllowGet);
        //}
        //////////////////////////////////////////////////////////////////////////////////////////public JsonResult IngresarUsuario(Etusuarios objetoNegocio)
        //////////////////////////////////////////////////////////////////////////////////////////public JsonResult UpdateUser(Etusuarios objetoNegocio)     
        //////////////////////////////////////////////////////////////////////////////////////////public JsonResult DeleteUsuarioyRelacionesRolBuzon(int objetoNegocio)     
        //#endregion

        //#region Buzones-Aplicaciones
        //public JsonResult AplicacionXUnidad(int objetoNegocio)
        //{
        //    Buzon_Aplicacion buzonXU = new Buzon_Aplicacion();
        //    List<Ecataplicaciones> lsbuzonesXU = buzonXU.AplicacionXUnidad(objetoNegocio);
        //    return Json(lsbuzonesXU, JsonRequestBehavior.AllowGet);
        //}
        //////////////////////////////////////////////////////////////////////////////////public JsonResult BuzonesEmpleado(int objetoNegocio)
        //public JsonResult BuzonesDeUsuario(int objetoNegocio)
        //{
        //    Buzon_Aplicacion buzonXU = new Buzon_Aplicacion();
        //    List<ETablaRelacionERB> lsbuzonesXU = buzonXU.BuzonesDeUsuario(objetoNegocio);
        //    return Json(lsbuzonesXU, JsonRequestBehavior.AllowGet);
        //}        
        //////////////////////////////////////////////////////////////////////////////public JsonResult RolesXBuzon(int objetoNegocio)
        //#endregion
    }
}