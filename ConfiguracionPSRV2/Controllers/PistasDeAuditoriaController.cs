using EntitiesPSR;
using System.Web.Mvc;
using DLLPistasDeAuditoria;
using System.Collections.Generic;

namespace ConfiguracionPSRV2.Controllers
{
    public class PistasDeAuditoriaController : Controller
    {
        // GET: PistasDeAuditoria
        public ActionResult PistasDeAuditoria()
        {
            return View();
        }
        public JsonResult GetUsuariosXUnidad(int objetoNegocio)
        {
            PistasDeAuditoria usuariosXU = new PistasDeAuditoria();
            List<EUsuariosPistas> lsusuariosXU = usuariosXU.GetUsuariosXUnidad(objetoNegocio);
            return Json(lsusuariosXU, JsonRequestBehavior.AllowGet);
        }
    }
}