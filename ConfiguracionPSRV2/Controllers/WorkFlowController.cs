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
    public class WorkFlowController : Controller
    {
        // GET: WorkFlow
        BTLWorkFlow btl = null;
        private BTLWorkFlow GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLWorkFlow();
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

        #region Definicion

        public ActionResult Definicion()
        {
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

        public JsonResult GetWorkFlowDefinicion()
        {
            List<Eworkflowdefinicion> resultado = GetBTL().GetWorkFlowDefinicion();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetWorkFlowDefinicion(Eworkflowdefinicion objetoNegocio)
        {
            Resultado resultado = GetBTL().SetWorkFlowDefinicion(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateWorkFlowDefinicion(Eworkflowdefinicion objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateWorkFlowDefinicion(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Proceso
        public ActionResult WFProceso()
        {
            return View();
        }

        public JsonResult GetWorkFlowProceso()
        {
            List<Ewfprocesos> resultado = GetBTL().GetWorkFlowProceso();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SetWorkFlowProceso(Ewfprocesos objetoNegocio)
        {
            Resultado resultado = GetBTL().SetWorkFlowProceso(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateWorkFlowProceso(Ewfprocesos objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateWorkFlowProceso(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Acciones
        public JsonResult GetwfCatAcciones() { 
            List<Ecatacciones> resultado = GetBTL().GetwfCatAcciones();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ProcesoEtapa
        public ActionResult WFEtapa()
        {
            return View();
        }

        public JsonResult GetWorkFlowProcesosEtapas()
        {
            List<Ewfprocesosetapas> resultado = GetBTL().GetWorkFlowProcesosEtapas();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SetWorkFlowProcesosEtapas(Ewfprocesosetapas objetoNegocio)
        {
            Resultado resultado = GetBTL().SetWorkFlowProcesosEtapas(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateWorkProcesosEtapas(Ewfprocesosetapas objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateWorkProcesosEtapas(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        #endregion

    }
}