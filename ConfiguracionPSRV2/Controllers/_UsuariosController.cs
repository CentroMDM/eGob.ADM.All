using System.Collections.Generic;
using System.Web.Mvc;
using BTLConfiguracionPSRV2;
using EntitiesPSR;
using System;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using ClsLayoutSettings;
using Utilerias;
using static ClsLayoutSettings.LS;
using DAOAccesoDatos;

namespace ConfiguracionPSRV2.Controllers
{
    public class _UsuariosController : Controller
    {
        // GET: Usuarios
        BTLUsuario btl = null;
        private BTLUsuario GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLUsuario();
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

        public ActionResult Usuarios() {
            var AllLogos = GetConfigBuzon();
            ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
            ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
            ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;
            return View();
        }

        public ActionResult GruposAtencion() {
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
        //public JsonResult IngresarUsuario(Etempleados objetoNegocio)
        //{
        //    Resultado resultado = GetBTL().IngresarUsuario(objetoNegocio);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}

        //////////////////////////////////////////////////////////////////////////////public JsonResult ObtenerUsuariosYEmpleados()
        //////////////////////////////////////////////////////////////////////////////{
        //////////////////////////////////////////////////////////////////////////////    List<Etempleados> lsEmpleados = GetBTL().ObtenerUsuariosYEmpleados();
        //////////////////////////////////////////////////////////////////////////////    return Json(lsEmpleados, JsonRequestBehavior.AllowGet);
        //////////////////////////////////////////////////////////////////////////////}

        public JsonResult IngresarGrupoAtencion(Etgruposatencion objetoNegocio) {
            Resultado resultado = GetBTL().IngresarGrupoAtencion(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}