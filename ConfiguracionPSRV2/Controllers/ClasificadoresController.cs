using BTLConfiguracionPSRV2.NegocioUnidadAdministrativa;
using EntitiesPSR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilerias;
using System.IO;
using BTLConfiguracionPSRV2;
using ClsLayoutSettings;
using static ClsLayoutSettings.LS;
using DAOAccesoDatos;

namespace ConfiguracionPSRV2.Controllers
{    
    public class ClasificadoresController : Controller
    {
        BTLAgrupadores btl = null;
        private BTLAgrupadores GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLAgrupadores();
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
        // GET: Agrupador
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Clasificadores() {
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
        #region Catalogo de puestos
        public JsonResult ConsultarClasidicadores()
        {
            List<EtcatAgrupadoresClasificadores> resultado = GetBTL().ObtenerConsultaAgrupadoresClasificadores();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ConsultarAgrupadores()
        {
            List<EtcatAgrupadores> resultado = GetBTL().consultaAgrupadores();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IngresarAgrupador(EtcatAgrupadores objetoNegocio)
        {
            Resultado resultado = GetBTL().IngresarAgrupador(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IngresarClasificador(EtcatClasificadores objetoNegocio)
        {
            Resultado resultado = GetBTL().IngresarClasificador(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ActuaizarClasificador(EtcatClasificadores objetoNegocio)
        {
            Resultado resultado = GetBTL().ActuaizarClasificador(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarClasificador(EtcatClasificadores objetoNegocio)
        {
            Resultado resultado = GetBTL().EliminarClasificador(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CargarImagenIcono(HttpPostedFileBase file)
        {
            if (file != null)
            {
                DataTable dtParametros = GetBTL().ObtenerParametros();
                DataRow[] drDirectorioFotosImplementacion = dtParametros.Select("RIDDirectorio=2021");

                if (drDirectorioFotosImplementacion.Length > 0)
                {
                    CargaImagen upimg = new CargaImagen();
                    string directorioVirtual = drDirectorioFotosImplementacion[0]["DirectorioVirtualInterno"].ToString() + upimg.guardarImagen(drDirectorioFotosImplementacion[0]["DirectorioFisicoInterno"].ToString(), file);
                    var obj = new { rutaArchivo = directorioVirtual };
                    return Json(obj, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new HttpStatusCodeResult(500, "No se pudo obtener los parámetros del servidor.");
                }
            }
            else
            {
                return new HttpStatusCodeResult(500, "Se debe enviar una imágen valida");
            }

        }
        #endregion
    }
}