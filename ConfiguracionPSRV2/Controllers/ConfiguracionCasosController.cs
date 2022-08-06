 using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BTLConfiguracionPSRV2;
using EntitiesPSR;
using EntitiesPSR.ConfiguracionPSR;
using Utilerias;
using static ClsLayoutSettings.LS;
using DAOAccesoDatos;
//using static DLLSujetos.ModelSujetos;
//using DLLSujetos;

namespace ConfiguracionPSRV2.Controllers
{
    
    public class ConfiguracionCasosController : Controller
    {
        // GET: ConfiguracionCasos
        BTLConfiguracionCasos btl = null;
        private BTLConfiguracionCasos GetBTL()
        {
            if (btl == null)
            {
                btl = new BTLConfiguracionCasos();
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

        public JsonResult GetDescriptivoItems()
        {
            List<Ecatdescriptivoitems> resultado = GetBTL().GetDescriptivoItems();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #region Caso_configuracion
        public ActionResult CasoConfiguracion()
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

        public JsonResult GetCasoConfiguracion()
        {
            List<Etcasoconfiguracion> resultado = GetBTL().GetCasoConfiguracion();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult SetCasoConfiguracion(Etcasoconfiguracion objetoNegocio)
        {
            Resultado resultado = GetBTL().SetCasoConfiguracion(objetoNegocio);

            if (!resultado.ExisteError)
            {
                if (objetoNegocio.ListaFormatos != null)
                {
                    //Guardamos los foramtos
                    foreach (Etcasocformatos casoFormato in objetoNegocio.ListaFormatos)
                    {
                        Erccasoformatos aux = new Erccasoformatos
                        {
                            ClaveFormato = casoFormato.RIDFormato,
                            ClaveCCaso = int.Parse(resultado.Dato.ToString())
                        };
                        Setrccasoformatos(aux);
                    }
                }
                if(objetoNegocio.Variables!= null)
                {
                    //Guardamos las variables /////   AQUI ES DONDE DEBEMOS PONER QUE SE ENVÍE LA VARIABLE DEFAULT
                    //-- SOLO ES UNA ; CONTENIDO DEFAULT NO PUEDE SER NULL
                    foreach (Etcasoformatovariable variable in objetoNegocio.Variables)
                    {
                        variable.Clave = int.Parse(resultado.Dato.ToString());
                        if (variable.ContenidoDefault == null)
                        {
                            variable.ContenidoDefault = "";
                            variable.Orden = 10;
                        }
                        SetTcasoformatovariable(variable);
                    }
                    //Guardamos las respuestas
                }
                if(objetoNegocio.Respuestas!= null)
                { 
                    foreach (Etcasoconfiguracion respuesta in objetoNegocio.Respuestas)
                    {
                        Etcasosconfiguraciontiporespuestas aux = new Etcasosconfiguraciontiporespuestas();
                        aux.ClaveCCaso = int.Parse(resultado.Dato.ToString());
                        aux.ClaveCCasoRespuesta = respuesta.RIDCCaso;
                        Settcasosconfiguraciontiporespuestas(aux);
                    } 
                }
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateCasoConfiguracion(Etcasoconfiguracion objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateCasoConfiguracion(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateStatusCConfiguracion(Etcasoconfiguracion objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateStatusCConfiguracion(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Plantillas   -B-
        public ActionResult CargarPlantillaCConfiguracion(HttpPostedFileBase file)
        {
            if (file != null)
            {
                DataTable dtParametros = GetBTL().ObtenerParametros();
                DataRow[] drDirectorioPlantilla = dtParametros.Select("RIDDirectorio=2013");

                if (drDirectorioPlantilla.Length > 0)
                {
                    Utilerias.CargaImagen upimg = new CargaImagen();
                    string directorioVirtual = drDirectorioPlantilla[0]["DirectorioVirtualInterno"].ToString() + upimg.guardarImagen(drDirectorioPlantilla[0]["DirectorioFisicoInterno"].ToString(), file);
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
                return new HttpStatusCodeResult(500, "Se debe enviar un Documento valido");
            }

        }

        #endregion

        #region Acuse -B-
        
        public ActionResult CargarAcuseCConfiguracion(HttpPostedFileBase file)
        {
            if (file != null)
            {
                DataTable dtParametros = GetBTL().ObtenerParametros();
                DataRow[] drDirectorioFotosImplementacion = dtParametros.Select("RIDDirectorio=2013");

                if (drDirectorioFotosImplementacion.Length > 0)
                {
                    Utilerias.CargaImagen upimg = new CargaImagen();
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
                return new HttpStatusCodeResult(500, "Se debe enviar un Documento valido");
            }

        }
        #endregion

        #region Tipo documento
        public ActionResult TipoDocumento()
        {
            return View();
        }
        public JsonResult GetlstExtenciones()
        {
            List<EcatExtenciones> resultado = GetBTL().GetlstExtenciones();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRarchivoExtenciones(Ecattipodocumentos objetoNegocio)
        {
            List<rarchivoextencion> resultado = GetBTL().GetRarchivoExtenciones(objetoNegocio.RIDDocumentoRequerido);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetTipoArchivo()
        //{
        //    List<Ecattipodocumentos> resultado = GetBTL().GetTipoArchivo();
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetCatTipoDocumentos()
        {
            List<Ecattipodocumentos> resultado = GetBTL().GetCatTipoDocumentos();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetDocumentByCase(Etcasoconfiguracion objetoNegocio)
        {
            List<EtConfiguracionDocumentos> resultado = GetBTL().GetDocumentByCase(objetoNegocio.RIDCCaso);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetCatTipoDocumentos(Ecattipodocumentos objetoNegocio)
        {
            Resultado resultado = GetBTL().SetCatTipoDocumentos(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetCCasoDocumento(EtConfiguracionDocumentos objetoNegocio)
        {
            Resultado resultado = GetBTL().SetCCasoDocumento(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateCatTipoDocumentos(Ecattipodocumentos objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateCatTipoDocumentos(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region tcasoc_formatos
        public ActionResult CasoConfiguracionFormatos()
        {
            return View();
        }

        public JsonResult GetTcasocformatos()
        {
            List<Etcasocformatos> resultado = GetBTL().GetTcasocformatos();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetTcasocformatos(Etcasocformatos objetoNegocio)
        {
            Resultado resultado = GetBTL().SetTcasocformatos(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateTcasocformatos(Etcasocformatos objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateTcasocformatos(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region tcasosc_formatoseccion
        public JsonResult GetTcasoscformatoseccion()
        {
            List<Etcasoscformatoseccion> resultado = GetBTL().GetTcasoscformatoseccion();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetTcasoscformatoseccion(Etcasoscformatoseccion objetoNegocio)
        {
            Resultado resultado = GetBTL().SetTcasoscformatoseccion(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateTcasoscformatoseccion(Etcasoscformatoseccion objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateTcasoscformatoseccion(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region cat_tiposervicios
        public ActionResult TipoServicios()
        {
            return View();
        }

        public JsonResult GetCatTipoServicios()
        {
            List<ECatTipoServicios> resultado = GetBTL().GetCatTipoServicios();
            /*foreach (Ecattiposervicios tipoServicio in resultado)
            {
                if (tipoServicio.DirectorioSecundario != "")
                {
                    tipoServicio.ImagenModelo = @"data:image/jpeg;base64," + Convert.ToBase64String(
                        System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath(tipoServicio.DirectorioImagenes), tipoServicio.DirectorioSecundario)));
                }
            }*/
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CargarImagenesServicios(HttpPostedFileBase file)
        {
            if (file != null)
            {
                DataTable dtParametros = GetBTL().ObtenerParametrosServidor();
                DataRow[] drDirectorioLogoServicios = dtParametros.Select("RIDDirectorio=2022");

                if (drDirectorioLogoServicios.Length > 0)
                {
                    Utilerias.CargaImagen upimg = new CargaImagen();
                    string directorioVirtual = drDirectorioLogoServicios[0]["DirectorioVirtualInterno"].ToString() + upimg.guardarImagen(drDirectorioLogoServicios[0]["DirectorioFisicoInterno"].ToString(), file);
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

        public JsonResult SetCatTipoServicios(ECatTipoServicios objetoNegocio)
        {
            Resultado resultado = GetBTL().SetCatTipoServicios(objetoNegocio);
            /* if (!resultado.ExisteError)
             {

                 HttpPostedFileBase objFile = (HttpPostedFileBase)new
                         HttpPostedFileBaseCustom(objetoNegocio.ImagenModelo, objetoNegocio.DirectorioSecundario);
                 string path = System.IO.Path.Combine(
                                        Server.MapPath(resultado.Dato.ToString()), objetoNegocio.DirectorioSecundario);
                 if (!Directory.Exists(Server.MapPath(resultado.Dato.ToString())))
                     Directory.CreateDirectory(Server.MapPath(resultado.Dato.ToString()));

                 objFile.SaveAs(path);
             }*/
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCatTipoServicios(ECatTipoServicios objetoNegocio)
        {
            Resultado resultado = GetBTL().UpdateCatTipoServicios(objetoNegocio);
            //if (!resultado.ExisteError)
            //{

            //    HttpPostedFileBase objFile = (HttpPostedFileBase)new
            //            HttpPostedFileBaseCustom(objetoNegocio.ImagenModelo, objetoNegocio.DirectorioSecundario);
            //    string path = System.IO.Path.Combine(
            //                           Server.MapPath(resultado.Dato.ToString()), objetoNegocio.DirectorioSecundario);
            //    if (!Directory.Exists(Server.MapPath(resultado.Dato.ToString())))
            //        Directory.CreateDirectory(Server.MapPath(resultado.Dato.ToString()));

            //    objFile.SaveAs(path);
            //}
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }        
        public JsonResult EliminarServicio(ECatTipoServicios objetoNegocio)
        {
            Resultado resultado = GetBTL().EliminarServicio(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Variables
        public JsonResult GetCatConfiguracionVariables()
        {
            var resultado = GetBTL().GetCatConfiguracionVariables();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTcasoformatovariable()
        {
            var resultado = GetBTL().GetTcasoformatovariable();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SetTcasoformatovariable(Etcasoformatovariable objetoNegocio)
        {
            var resultado = GetBTL().SetTcasoformatovariable(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateTcasoformatovariable(Etcasoformatovariable objetoNegocio)
        {
            var resultado = GetBTL().UpdateTcasoformatovariable(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
        public JsonResult EliminarVariables (Etcasoformatovariable objetoNegocio)
        {
            var resultado = GetBTL().EliminarVariables(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
        public JsonResult EliminarRespuestas(Etcasosconfiguraciontiporespuestas objetoNegocio)
        {
            var resultado = GetBTL().EliminarRespuestas(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
        public JsonResult EliminarFormatos(Etcasocformatos objetoNegocio)
        {
            var resultado = GetBTL().EliminarFormatos(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
        public JsonResult EliminarDocumentos(EtConfiguracionDocumentos objetoNegocio)
        {
            var resultado = GetBTL().EliminarDocumentos(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region relacion formato-caso
        public JsonResult Getrccasoformatos()
        {
            var resultado = GetBTL().Getrccasoformatos();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Setrccasoformatos(Erccasoformatos objetoNegocio)
        {
            var resultado = GetBTL().Setrccasoformatos(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Updaterccasoformatos(Erccasoformatos objetoNegocio)
        {
            var resultado = GetBTL().Updaterccasoformatos(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
        #endregion 

        #region respuesta casos
        public JsonResult Gettcasosconfiguraciontiporespuestas()
        {
            var resultado = GetBTL().Gettcasosconfiguraciontiporespuestas();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Settcasosconfiguraciontiporespuestas(Etcasosconfiguraciontiporespuestas objetoNegocio)
        {
            var resultado = GetBTL().Settcasosconfiguraciontiporespuestas(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Updatetcasosconfiguraciontiporespuestas(Etcasosconfiguraciontiporespuestas objetoNegocio)
        {
            var resultado = GetBTL().Updatetcasosconfiguraciontiporespuestas(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        //BRAND
        //public JsonResult GetRespuestasxCaso(Etcasoconfiguracion objetoNegocio)
        //{
        //    List<EtCasosClasificadores> resultado = GetBTL().GetRespuestasxCaso(objetoNegocio.RIDCCaso);
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
        #endregion

        //Brand

        #region Casos Agrupadores Clasificadores
        public JsonResult ConsultarClasificadores(EtcatAgrupadores objetoNegocio)
        {
            List<EtcatAgrupadoresClasificadores> resultado = GetBTL().ConsultarClasificadoresGrupo(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertarCasosAgrupadorClasificador(EtCasosClasificadores objetoNegocio)
        {
            List<EtCasosClasificadores> resultado = GetBTL().InsertarCasosAgrupadorClasificador(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarCasosAgrupadorClasificadorModal(EtCasosClasificadores objetoNegocio)
        {
            Resultado resultado = GetBTL().EliminarCasosAgrupadorClasificadorModal(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateGrupoClasificadorCaso(EtCasosClasificadores objetoNegocio)
        {
            List<EtCasosClasificadores> resultado = GetBTL().UpdateGrupoClasificadorCaso(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCasosAgrupadoresClasificadores(Etcasoconfiguracion objetoNegocio)
        //Llenar tabla de agrupadores clasificadores para caso seleccionado 
        {
            List<EtCasosClasificadores> resultado = GetBTL().GetCasosAgrupadoresClasificadores(objetoNegocio.RIDCCaso);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion

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
        public JsonResult GetListUACasoConfiguracion(Etunidadadministrativa objetoNegocio)
        {
            List<Etunidadadministrativa> resultado = GetBTL().GetListUACasoConfiguracion(objetoNegocio.ClaveUAPadre);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetListCasoUnidad(Etcasoconfiguracion objetoNegocio)
        {
            List<ErCCasosUnidadesAdministrativas> resultado = GetBTL().GetListCasoUnidad(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SetUnidadCCaso(ErCCasosUnidadesAdministrativas objetoNegocio)
        {
            Resultado resultado = GetBTL().SetUnidadCCaso(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteUnidadCCaso(ErCCasosUnidadesAdministrativas objetoNegocio)
        {
            Resultado resultado = GetBTL().DeleteUnidadCCaso(objetoNegocio);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Firmantes

        public JsonResult GetFirmantes(Etunidadadministrativa objetoNegocio)
        {
            List<EtFirmantes> resultado = GetBTL().GetFirmantes(objetoNegocio.RIDUnidadAdministrativa);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}
