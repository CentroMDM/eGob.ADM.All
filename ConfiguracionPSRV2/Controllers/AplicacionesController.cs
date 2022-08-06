using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Mvc;
using EntitiesPSR;
using static ClsLayoutSettings.LS;
using Utilerias;
using DLLEstructuraOrganizacional;

namespace ConfiguracionPSRV2.Controllers
{
    public class AplicacionesController : Controller
    {
        // GET: AdministracionDeBuzones
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Administracion()
        {
            return View();
        }
        //public JsonResult ObtenerAplicacionesDeUnidad()
        //{
        //    Aplicaciones Aplicaciones = new Aplicaciones();
        //    List<EAdmBuzonConfiguracion> lsAplicaciones = Aplicaciones.ObtenerAplicacionesDeUnidad();
        //    return Json(lsAplicaciones, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult ActualizarAplicacionActivo(int objetoNegocio)
        //{
        //    Aplicaciones upApp = new Aplicaciones();
        //    Resultado resultado = upApp.ActualizarAplicacionActivo(objetoNegocio);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult ActualizarAplicacionDesactivada(int objetoNegocio)
        //{
        //    Aplicaciones upApp = new Aplicaciones();
        //    Resultado resultado = upApp.ActualizarAplicacionDesactivada(objetoNegocio);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
    }
}