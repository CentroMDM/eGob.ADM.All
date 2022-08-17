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
    public class DiasController : Controller
    {
        // GET: Dias
        BTLDias btl = null;
        private BTLDias GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLDias();
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

        //public ActionResult DiasInhabiles() {
        //    var AllLogos = GetConfigBuzon();
        //    ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
        //    ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
        //    ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;

        //    return View();
        //}
        public List<EcatBuzonFiscal> GetConfigBuzon()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetConfigBuzon());
            List<EcatBuzonFiscal> lsResultado = UtilTablas.ConvertirDataTableToList<EcatBuzonFiscal>(table);
            return lsResultado;
        }
        #region Motivo Dias Inhabiles
        //public JsonResult GetMotivoDiasInhabil()
        //{
        //    List<EcatmotivoDiasInhabiles> resultado = GetBTL().GetMotivoDiasInhabil();
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult SetMotivoDiasInhabil(EcatmotivoDiasInhabiles objetoNegocio)
        //{
        //    Resultado resultado = GetBTL().SetMotivoDiasInhabil(objetoNegocio);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult UpdateMotivoDiasInhabil(EcatmotivoDiasInhabiles objetoNegocio)
        //{
        //    Resultado resultado = GetBTL().UpdateMotivoDiasInhabil(objetoNegocio);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        #endregion

        #region cat dias inhabiles
        
        //public JsonResult GetDescriptivoItems()
        //{
        //    List<Ecatdescriptivoitems> resultado = GetBTL().GetDescriptivoItems();
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetCatDiasInhabiles()
        //{
        //    List<EcatdiasInhabiles> resultado = GetBTL().GetCatDiasInhabiles();
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult SetCatDiasInhabiles(EcatdiasInhabiles objetoNegocio)
        //{
        //    Resultado resultado = GetBTL().SetCatDiasInhabiles(objetoNegocio);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult UpdateCatDiasInhabiles(EcatdiasInhabiles objetoNegocio)
        //{
        //    Resultado resultado = GetBTL().UpdateCatDiasInhabiles(objetoNegocio);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult DeleteCatDiasInhabiles(EcatdiasInhabiles objetoNegocio)
        //{
        //    Resultado resultado = GetBTL().DeleteCatDiasInhabiles(objetoNegocio);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        #endregion

    }
}

