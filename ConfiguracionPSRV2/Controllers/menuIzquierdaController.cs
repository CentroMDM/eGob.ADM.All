using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Text;
using BTLConfiguracionPSRV2;
using EntitiesPSR;
using EntitiesPSR.ConfiguracionPSR;
using Utilerias;
using static ClsLayoutSettings.LS;


namespace ConfiguracionPSRV2.Controllers
{
    public class menuIzquierdaController : Controller
    {
        BTLBuzonIzquierdo btl = null;
        private BTLBuzonIzquierdo GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLBuzonIzquierdo();
            }
            return btl;
        }

        // GET: menuIzquierda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _MenuIzquierda()
        {
            return View();
        }
        #region Unidades Administrativas
        public JsonResult GetUsuario()
        {
            List<Etusuarios> resultado = GetBTL().GetUsuario();
            return Json(resultado[0], JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUACasoConfiguracion(Etusuarios objetoNegocio)
        {
            List<Etunidadadministrativa> resultado = GetBTL().GetUACasoConfiguracion(objetoNegocio.RIDUsuario);
            return Json(resultado[0], JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
