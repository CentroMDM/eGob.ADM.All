using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLConfiguracionPSRV2;
using EntitiesPSR;
using System.Data;
using System.IO;
using ClsLayoutSettings;
using Utilerias;
using static ClsLayoutSettings.LS;
using DAOAccesoDatos;

namespace ConfiguracionPSRV2.Controllers
{
    public class BuzonController : Controller
    {
        // GET: Buzon
        BTLBuzon btl = null;
        private BTLBuzon GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLBuzon();
            }
            return btl;
        }
        private DAOGetObjetosNegocio daoGetObjetosNegocio = null;
        private DAOGetObjetosNegocio GetObjetosNegocio()
        {
            if (daoGetObjetosNegocio == null)
            {
                daoGetObjetosNegocio = new DAOGetObjetosNegocio();
            }
            return daoGetObjetosNegocio;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdministracionBuzones() {
            var AllLogos = GetConfigBuzon();
            ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
            ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
            ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;
            return View();
        }
        public List<EcatBuzonFiscal> GetConfigBuzon()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetConfigBuzon());
            List<EcatBuzonFiscal> lsResultado = UtilTablas.ConvertirDataTableToList<EcatBuzonFiscal>(table);
            return lsResultado;
        }

        //////////////////////////////////////////////////////////////////////public JsonResult ObtenerBuzonesConfiguracion() {
        //////////////////////////////////////////////////////////////////////    List<Ebuzonesconfiguracion> resultado = GetBTL().ObtenerBuzonesConfiguracion();
        //////////////////////////////////////////////////////////////////////    return Json(resultado, JsonRequestBehavior.AllowGet);
        //////////////////////////////////////////////////////////////////////}

        public JsonResult ObtenerRoles(Ebuzonesconfiguracion objetoNegocio) {

            //List<Ecatroles> resultado = GetBTL().ObtenerRoles(objetoNegocio);
            //return Json(resultado, JsonRequestBehavior.AllowGet);

            List<Ecattodosroles> resultado = GetBTL().ObtenerRoles(objetoNegocio);
            JsonResult variable = new JsonResult();
            variable.MaxJsonLength = 900000000;
            variable.Data = resultado;
            return Json(variable, JsonRequestBehavior.AllowGet);

            //List<Ecatroles> resultado = GetBTL().ObtenerRoles(objetoNegocio);
            //JsonResult variable = new JsonResult();
            //variable.MaxJsonLength = 900000000;
            //variable.Data = resultado;
            //return Json(variable, JsonRequestBehavior.AllowGet);

            //var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
            //jsonResult.MaxJsonLength = int.MaxValue;
            //return jsonResult;
        }
    }
}