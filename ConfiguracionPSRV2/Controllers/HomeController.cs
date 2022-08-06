using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLConfiguracionPSRV2;
using EntitiesPSR;
using EntitiesPSR.AppsRoles;
using System.Data;
using System.IO;
using ClsLayoutSettings;
using Utilerias;
using static ClsLayoutSettings.LS;
using DAOAccesoDatos;

namespace ConfiguracionPSRV2.Controllers
{
    public class HomeController : Controller
    {
        BTLUnidadAdministrativa btl = null;

        private BTLUnidadAdministrativa GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLUnidadAdministrativa();
            }
            return btl;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetConfig()
        {
            List<EcatBuzonFiscal> lsBuzonF = GetBTL().GetConfigBuzon();
            return Json(lsBuzonF, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetImplementacion()
        //{
        //    Etimplementacion implementacion = GetBTL().GetImplementacion();
        //    return Json(implementacion, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetConfigImp()
        {
            Etimplementacion implementacion = GetBTL().GetConfigImp();
            return Json(implementacion, JsonRequestBehavior.AllowGet);
        }        
        public JsonResult GetConfiguracionARC(Erusuariobuzon objetoNegocio)
        {
            List<ECat_AplicacionesModulos> ModulosUser = GetBTL().GetConfiguracionARC(objetoNegocio);
            return Json(ModulosUser, JsonRequestBehavior.AllowGet);
        }
    }
}
