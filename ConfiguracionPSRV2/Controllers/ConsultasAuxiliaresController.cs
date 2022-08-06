using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLConfiguracionPSRV2;
using EntitiesPSR;
using Utilerias;
using System.Data;
using System.IO;
using ClsLayoutSettings;
using static ClsLayoutSettings.LS;
using DAOAccesoDatos;

namespace ConfiguracionPSRV2.Controllers
{
    public class ConsultasAuxiliaresController : Controller
    {
        // GET: ConsultasAuxiliares
        BTLAuxiliares btl = null;
        private BTLAuxiliares GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLAuxiliares();
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

        public JsonResult ObtenerEstatusBuzon() {
            List<Ecatdescriptivoitems> lsItems = GetBTL().ObtenerItemsCatalogoDescriptivo(CatalogoDescriptivo.BUZON);
            return Json(lsItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoServicio() {
            List<Ecatdescriptivoitems> lsItems = GetBTL().ObtenerItemsCatalogoDescriptivo(CatalogoDescriptivo.CAT_TIPOSERVICIO);
            return Json(lsItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoCaso() {
            List<Ecatdescriptivoitems> lsItems = GetBTL().ObtenerItemsCatalogoDescriptivo(CatalogoDescriptivo.TIPO_CASO);
            return Json(lsItems, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ClasificacionCaso()
        {
            List<Ecatdescriptivoitems> lsItems = GetBTL().ObtenerItemsCatalogoDescriptivo(CatalogoDescriptivo.CLASIFICACION_CASO);
            return Json(lsItems, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTipoResultado()
        {
            List<Ecatdescriptivoitems> lsItems = GetBTL().ObtenerItemsCatalogoDescriptivo(CatalogoDescriptivo.TIPO_RESULTADO);
            return Json(lsItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPreview(int objetoNegocio) {
            BTLAuxiliares aux = new BTLAuxiliares();
            (Etcasocformatos, List<Etcasoscformatoseccion>, List<EAuxPreviewFormatos>) items = aux.GetPreview(objetoNegocio);
            string htmlPreview = new GenerarPreview().GetHTMLPreview(items.Item1, items.Item2, items.Item3);
            return Json(htmlPreview, JsonRequestBehavior.AllowGet);
        }


    }
}