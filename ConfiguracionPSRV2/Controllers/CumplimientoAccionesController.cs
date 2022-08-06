using BTLConfiguracionPSRV2.NegocioUnidadAdministrativa;
using EntitiesPSR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using BTLConfiguracionPSRV2;
using ClsLayoutSettings;
using Utilerias;
using static ClsLayoutSettings.LS;
using DAOAccesoDatos;



namespace ConfiguracionPSRV2.Controllers
{
    public class CumplimientoAccionesController : Controller
    {

        BTLClasificacionSujetos btl = null;
        private BTLClasificacionSujetos GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLClasificacionSujetos();
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

        // GET: CumplimientoAcciones
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CatalogoImpuestos()
        {
            var AllLogos = GetConfigBuzon();
            ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
            ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
            ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;
            return View();
        }

        public ActionResult CumplimientoSujeto() {
            var AllLogos = GetConfigBuzon();
            ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
            ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
            ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;
            return View();
        }

        public ActionResult AccionesCumplimiento() {
            var AllLogos = GetConfigBuzon();
            ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
            ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
            ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;
            return View();
        }

        public ActionResult ClasificacionSujetos()
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

        public JsonResult ConsultarTipoSujetosObjetos()
        {
            List<EcatTipoSujetosObjetos> resultado = GetBTL().ObtenerConsultaTipoSujetosObjetos();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IngresarTipoSujetosObjetos(EcatTipoSujetosObjetos objetoNegocio)
        {
            Resultado resultado = GetBTL().IngresarTipoSujetosObjeto(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarClasificadores(EtcatAgrupadores objetoNegocio)
        {
            List<EtcatAgrupadoresClasificadores> resultado = GetBTL().ConsultarClasificadoresGrupo(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarClasificadoresMultipleSeleccion(List<EtcatAgrupadores> objetoNegocio)
        {
            List<EtcatAgrupadoresClasificadores> resultadoFinal=new List<EtcatAgrupadoresClasificadores>();
            if (objetoNegocio != null)
            {
                foreach (EtcatAgrupadores objetosNeg in objetoNegocio)
                {

                    List<EtcatAgrupadoresClasificadores> resultado = GetBTL().ConsultarClasificadoresGrupo(objetosNeg);
                    foreach (EtcatAgrupadoresClasificadores res in resultado)
                    {
                        resultadoFinal.Add(res);
                    }
                }
            }
            return Json(resultadoFinal, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarObjetosClasificados(List<EtcatAgrupadoresClasificadores> objetoNegocio)
        {
            List<EConsultaObjetosClasificados> resultadoFinal = new List<EConsultaObjetosClasificados>();

            if (objetoNegocio != null)
            {
                foreach (EtcatAgrupadoresClasificadores objneg in objetoNegocio)
                {
                    List<EConsultaObjetosClasificados> resultado = GetBTL().ObtenerObjetosClasificados(objneg);
                    foreach (EConsultaObjetosClasificados res in resultado)
                    {
                        resultadoFinal.Add(res);
                    }
                }
            }
            return Json(resultadoFinal, JsonRequestBehavior.AllowGet);
        }

       


        public ActionResult cargaArchivoTXT(HttpPostedFileBase file, string ClaveSubjetoObjeto,string ClaveClasificacion)
        {
            Resultado resultado = GetBTL().ClasificaSujetouObjeto(file, ClaveSubjetoObjeto,ClaveClasificacion);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IngresarClasificacion(EClasificacionSujetoObjeto objetoNegocio)
        {
            Resultado resultado = GetBTL().ClasificaSujetouObjeto(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminaClasificacion(EConsultaObjetosClasificados objetoNegocio)
        {
            Resultado resultado = GetBTL().EliminarClasificacion(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        


    }

}