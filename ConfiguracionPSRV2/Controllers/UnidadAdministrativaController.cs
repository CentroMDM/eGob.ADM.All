using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Mvc;
using BTLConfiguracionPSRV2;
using ClsLayoutSettings;
using EntitiesPSR;
using Utilerias;
using static ClsLayoutSettings.LS;
using System.Linq;
using DAOAccesoDatos;


namespace ConfiguracionPSRV2.Controllers
{
    public class UnidadAdministrativaController : Controller
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
            var AllLogos = GetConfigBuzonimg();
            ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
            ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
            ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;
            return View();
        }

        //public ActionResult UnidadAdministrativa()
        //{
        //    var AllLogos = GetConfigBuzonimg();
        //    ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
        //    ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
        //    ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;
        //    return View();
        //}

        public ActionResult ConfiguracionBuzonFiscal()
        {
            var AllLogos = GetConfigBuzonimg();
            ViewBag.LogoApp = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogoApp;
            ViewBag.Logo = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioLogo;
            ViewBag.ImagenHome = AllLogos[0].DirectorioImagenesVirtual + AllLogos[0].DirectorioSecundarioImagenHome;
            return View();
        }
        public List<EcatBuzonFiscal> GetConfigBuzonimg()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetConfigBuzon());
            List<EcatBuzonFiscal> lsResultado = UtilTablas.ConvertirDataTableToList<EcatBuzonFiscal>(table);
            return lsResultado;
        }

        public JsonResult ObtenerUnidadesAdministrativas()
        {
            List<Etunidadadministrativa> lsUnidades = GetBTL().ObtenerUnidadesAdministrativas();
            return Json(lsUnidades, JsonRequestBehavior.AllowGet);
        }
        public JsonResult datosOrganigrama()
        {
            List<Etunidadadministrativa> lsUnidades = GetBTL().datosOrganigrama();
            return Json(lsUnidades, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerCodigoPostalMunicipio(int objetoNegocio)
        {
            List<Ecatcp> lsResultado = GetBTL().ObtenerCodigoPostalMunicipio(objetoNegocio);
            return Json(lsResultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerColoniasCP(string objetoNegocio)
        {
            List<Ecatcp> resultado = GetBTL().ObtenerColoniasCP(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BuscarFiltros(Ecattipofiltrosinicialesbuzon objetoNegocio)
        {
            List<Ebuzonconfiguracionfiltros> resultado = GetBTL().BuscarFiltros(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerBuzonFiltrosInicial()
        {
            List<Ebuzonconfiguracionfiltros> resultado = GetBTL().ObtenerBuzonFiltrosInicial();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerEntidadFederativa()
        {
            EcatcpEntidadesFederativas resultado = GetBTL().ObtenerEntidadFederativa();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerMunicipios(EcatcpEntidadesFederativas objetoNegocio)
        {
            List<Ecatcpmunicipios> resultado = GetBTL().ObtenerMunicipios(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertarUnidadAdministrativa(Etunidadadministrativa objetoNegocio)
        {
            Resultado resultado = GetBTL().InsertarUnidadAdministrativa(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerAplicacion()
        {
            List<Ecataplicaciones> resultado = GetBTL().ObtenerAplicaciones();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerFiltro()
        {
            List<Ecattipofiltrosinicialesbuzon> resultado = GetBTL().ObtenerFiltro();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IngresarBuzon(Ebuzonesconfiguracion objetoNegocio)
        {
            Resultado resultado = GetBTL().IngresarBuzon(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarUnidadAdministrativa(Etunidadadministrativa objetoNegocio)
        {
            Resultado resultado = GetBTL().EliminarUnidadAdministrativa(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ActualizarUnidadAdministrativa(Etunidadadministrativa objetoNegocio)
        {
            Resultado resultado = GetBTL().ActualizarUnidadAdministrativa(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #region Empleados
        //public ActionResult Empleados()
        //{
        //    return View();
        //}
        public JsonResult ObtenerEmpleado()
        {
            List<Etempleados> empleado = GetBTL().ObtenerEmpleados();
            return Json(empleado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IngresarEmpleado(Etempleados objetoNegocio)
        {
            Resultado resultado = GetBTL().IngresarEmpleado(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ActualizarEmpleado(Etempleados objetoNegocio)
        {
            Resultado resultado = GetBTL().ActualizarEmpleado(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarEmpleado(Etempleados objetoNegocio)
        {
            Resultado resultado = GetBTL().EliminarEmpleado(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUnidadesPuestos()
        {
            var lsUnidadesPuestos = GetBTL().GetUnidadesPuestos();
            return Json(lsUnidadesPuestos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CargarImagenEmpleado(HttpPostedFileBase file)
        {
            if (file != null)
            {
                DataTable dtParametros = GetBTL().ObtenerParametros();
                DataRow[] drDirectorioFotosEmpleado = dtParametros.Select("RIDDirectorio=203");

                if (drDirectorioFotosEmpleado.Length > 0)
                {
                    Utilerias.CargaImagen upimg = new CargaImagen();
                    //var ruta1 = drDirectorioFotosEmpleado[0]["DirectorioVirtualInterno"].ToString().Substring(3).Replace("/", "\\");
                    //var ruta2 = drDirectorioFotosEmpleado[0]["DirectorioFisicoInterno"].ToString();
                    //var rutaFinal = ruta2 + ruta1;
                    //string directorioVirtual = drDirectorioFotosEmpleado[0]["DirectorioVirtualInterno"].ToString() + upimg.guardarImagen(rutaFinal, file);
                    string directorioVirtual = drDirectorioFotosEmpleado[0]["DirectorioVirtualExterno"].ToString() + upimg.guardarImagen(drDirectorioFotosEmpleado[0]["DirectorioFisicoInterno"].ToString(), file);

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
        ////////////////////////////////////////////////////////////////////////////////////public ActionResult CargarImagenImplementacion(HttpPostedFileBase file)
        ////////////////////////////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////////////////////////////    if (file != null && (file.ContentType == "image/png" || file.ContentType == "image/svg+xml" ))
        ////////////////////////////////////////////////////////////////////////////////////    {
        ////////////////////////////////////////////////////////////////////////////////////        DataTable dtParametros = GetBTL().ObtenerParametros();
        ////////////////////////////////////////////////////////////////////////////////////        DataRow[] drDirectorioFotosImplementacion = dtParametros.Select("RIDDirectorio=201");

        ////////////////////////////////////////////////////////////////////////////////////        if (drDirectorioFotosImplementacion.Length > 0)
        ////////////////////////////////////////////////////////////////////////////////////        {
        ////////////////////////////////////////////////////////////////////////////////////            Utilerias.CargaImagen upimg = new CargaImagen();
        ////////////////////////////////////////////////////////////////////////////////////            string directorioVirtual = drDirectorioFotosImplementacion[0]["DirectorioVirtualExterno"].ToString() + upimg.guardarImagen(drDirectorioFotosImplementacion[0]["DirectorioFisicoInterno"].ToString(), file);
        ////////////////////////////////////////////////////////////////////////////////////            var obj = new { rutaArchivo = directorioVirtual };
        ////////////////////////////////////////////////////////////////////////////////////            return Json(obj, JsonRequestBehavior.AllowGet);
        ////////////////////////////////////////////////////////////////////////////////////        }
        ////////////////////////////////////////////////////////////////////////////////////        else
        ////////////////////////////////////////////////////////////////////////////////////        {
        ////////////////////////////////////////////////////////////////////////////////////            return new HttpStatusCodeResult(500, "No se pudo obtener los parámetros del servidor.");
        ////////////////////////////////////////////////////////////////////////////////////        }
        ////////////////////////////////////////////////////////////////////////////////////    }
        ////////////////////////////////////////////////////////////////////////////////////    else
        ////////////////////////////////////////////////////////////////////////////////////    {
        ////////////////////////////////////////////////////////////////////////////////////        return new HttpStatusCodeResult(500, "Se debe enviar una imágen válida");
        ////////////////////////////////////////////////////////////////////////////////////    }

        ////////////////////////////////////////////////////////////////////////////////////}
        public ActionResult CargarImagenAplicacion(HttpPostedFileBase file)
        {
            if (file != null && (file.ContentType == "image/png" || file.ContentType == "image/svg+xml"))
            {
                DataTable dtParametros = GetBTL().ObtenerParametros();
                DataRow[] drDirectorioFotosImplementacion = dtParametros.Select("RIDDirectorio=204");

                if (drDirectorioFotosImplementacion.Length > 0)
                {
                    Utilerias.CargaImagen upimg = new CargaImagen();
                    string directorioVirtual = drDirectorioFotosImplementacion[0]["DirectorioVirtualExterno"].ToString() + upimg.guardarImagen(drDirectorioFotosImplementacion[0]["DirectorioFisicoInterno"].ToString(), file);
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
        public ActionResult cargaImagenBuzon(HttpPostedFileBase file)
        {
            if (file != null)
            {
                DataTable dtParametros = GetBTL().ObtenerParametros();
                DataRow[] drDirectorioFotosImplementacion = dtParametros.Select("RIDDirectorio=208");

                if (drDirectorioFotosImplementacion.Length > 0)
                {
                    Utilerias.CargaImagen upimg = new CargaImagen();
                    string directorioVirtual = drDirectorioFotosImplementacion[0]["DirectorioVirtualExterno"].ToString() + upimg.guardarImagen(drDirectorioFotosImplementacion[0]["DirectorioFisicoInterno"].ToString(), file);
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


        #region implementacion
        //public JsonResult GetImplementacion()
        //{
        //    Etimplementacion implementacion = GetBTL().GetImplementacion();
        //    return Json(implementacion, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetImpEntidadesFederativas()
        {
            List<EcatcpEntidadesFederativas> lsEntidades = GetBTL().GetImpEntidadesFederativas();
            return Json(lsEntidades, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetImpMunicipios(EcatcpEntidadesFederativas objetoNegocio)
        {
            List<Ecatcpmunicipios> lsMunicipios = GetBTL().GetImpMunicipios(objetoNegocio);
            return Json(lsMunicipios, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Updatetimplementacion(Etimplementacion objetoNegocio)
        {
            Resultado resultado = GetBTL().Updatetimplementacion(objetoNegocio);
            foreach (Ecataplicaciones aplicacion in objetoNegocio.Aplicaciones)
            {
                resultado = GetBTL().Updatecataplicaciones(aplicacion);
                if (resultado.ExisteError)
                {
                    break;
                }
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTemas()
        {
            List<EThemes> listaTemas = new LS().GetListThemes();
            return Json(listaTemas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModos()
        {
            List<EThemesMode> listaModes = new LS().GetListThemesOptions();
            return Json(listaModes, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Otras funcionalidades
        //public JsonResult ObtenerOrganigrama(List<Etunidadadministrativa> objetoNegocio)
        //{
        //    GenerarOrganigrama generarOrganigrama = new GenerarOrganigrama();
        //    Organigrama org = generarOrganigrama.GeneraOrganigrama(objetoNegocio);
        //    return Json(org, JsonRequestBehavior.AllowGet);
        //}
        #endregion

        #region Unidad Administrativa 
        //MM
        public ActionResult CargarImagenLogoUnidadAdministrativa(HttpPostedFileBase file)
        {
            if (file != null)
            {
                DataTable dtParametros = GetBTL().ObtenerParametros();
                //Consulta los directorios 
                DataRow[] drDirectorioFotosUnidadAdministrativa = dtParametros.Select("RIDDirectorio=202");

                if (drDirectorioFotosUnidadAdministrativa.Length > 0)
                {
                    Utilerias.CargaImagen upimg = new CargaImagen();
                    //var ruta1 = drDirectorioFotosUnidadAdministrativa[0]["DirectorioVirtualInterno"].ToString().Substring(3).Replace("/", "\\");
                    //var ruta2 = drDirectorioFotosUnidadAdministrativa[0]["DirectorioFisicoInterno"].ToString();
                    //var rutaFinal = ruta2 + ruta1;
                    //string directorioVirtual = drDirectorioFotosUnidadAdministrativa[0]["DirectorioVirtualInterno"].ToString() + upimg.guardarImagen(drDirectorioFotosUnidadAdministrativa[0]["DirectorioFisicoInterno"].ToString(), file);
                    //string directorioVirtual = drDirectorioFotosUnidadAdministrativa[0]["DirectorioVirtualInterno"].ToString() + upimg.guardarImagen(rutaFinal, file);
                    string directorioVirtual = drDirectorioFotosUnidadAdministrativa[0]["DirectorioVirtualExterno"].ToString() + upimg.guardarImagen(drDirectorioFotosUnidadAdministrativa[0]["DirectorioFisicoInterno"].ToString(), file);

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

        public JsonResult GetConfigBuzon()
        {
            List<EcatBuzonFiscal> lsBuzonF = GetBTL().GetConfigBuzon();
            return Json(lsBuzonF, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateConfigBuzon(EcatBuzonFiscal objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateConfigBuzon(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //
        #endregion

    }
}