using EntitiesPSR;
using MySql.Data.MySqlClient;
using System;

namespace DAOAccesoDatos
{
    public static class ScriptConfiguracionCasos
    {
        #region cat_tipoDocumentos
        public static ProcedimientoAlmacenado GetlstExtenciones()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_GetlstExtenciones");
            return sp;
        }
        public static ProcedimientoAlmacenado GetRarchivoExtenciones(int RID)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_Getrarchivoextencion");
            sp.NuevoParametro("_ClaveTipoDocumento", MySqlDbType.Int32, RID);

            return sp;
        }
        //public static ProcedimientoAlmacenado GetTipoArchivo()
        //{
        //    ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("");
        //    return sp;
        //}
        public static ProcedimientoAlmacenado GetCatTipoDocumentos() {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_GetCatDocumentos");
            return sp; 
        }
        public static ProcedimientoAlmacenado GetDocumentByCase(int pRIDCCaso) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_GetDocumentosByCCaso");
            sp.NuevoParametro("pClaveCCaso", MySqlDbType.Int32, pRIDCCaso);
            return sp; 
        }

        public static ProcedimientoAlmacenado ObtenerParametrosServidor()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_GPObtenerParametrosServidor");
            return sp;
        }

        public static ProcedimientoAlmacenado SetCatTipoDocumentos(Ecattipodocumentos tipoDocumento) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_SetCatTipoDocumentos");

            sp.NuevoParametro("_RIDTipoDocumento", MySqlDbType.Int32, tipoDocumento.RIDDocumentoRequerido);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, tipoDocumento.NombreDocumento);
            sp.NuevoParametro("_NombreCorto", MySqlDbType.VarChar, tipoDocumento.NombreCortoDocumento);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, tipoDocumento.Descripcion);
            //sp.NuevoParametro("_TipoArchivo", MySqlDbType.Int32, tipoDocumento.TipoArchivo.RID);
            sp.NuevoParametro("_Tamano", MySqlDbType.Decimal, tipoDocumento.TamanioMaximoMB);
            return sp;
        }
        public static ProcedimientoAlmacenado SetCCasoDocumento(EtConfiguracionDocumentos tipoDocumento) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_SetCCasoDocumentos");

            
            sp.NuevoParametro("pClaveCCaso", MySqlDbType.Int32, tipoDocumento.ClaveCCaso);
            sp.NuevoParametro("pClaveTipoDocumento", MySqlDbType.Int32, tipoDocumento.RIDDocumentoRequerido);
            sp.NuevoParametro("pOrden", MySqlDbType.Int32, tipoDocumento.Orden);
            sp.NuevoParametro("pMostrar", MySqlDbType.Byte, tipoDocumento.Mostrar);
            sp.NuevoParametro("pRequerido", MySqlDbType.Byte, tipoDocumento.Requerido);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateCatTipoDocumentos(Ecattipodocumentos tipoDocumento) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_UpdateCatTipoDocumentos");

            sp.NuevoParametro("_RIDTipoDocumento", MySqlDbType.Int32, tipoDocumento.RIDDocumentoRequerido);
            //sp.NuevoParametro("_RIDRelacion", MySqlDbType.Int32, tipoDocumento.RIDRelacion);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, tipoDocumento.NombreDocumento);
            sp.NuevoParametro("_NombreCorto", MySqlDbType.VarChar, tipoDocumento.NombreCortoDocumento);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, tipoDocumento.Descripcion);
            //sp.NuevoParametro("_TipoArchivo", MySqlDbType.Int32, tipoDocumento.TipoArchivo.RID);
            sp.NuevoParametro("_Tamano", MySqlDbType.Decimal, tipoDocumento.TamanioMaximoMB);
            return sp;
        }



        
        #endregion

        #region cat_tiposervicios
        public static ProcedimientoAlmacenado GetCatTipoServicios()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetCatTipoServicios");
            return sp;
        }

        public static ProcedimientoAlmacenado SetCatTipoServicios(ECatTipoServicios tipoServicio)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetCatTipoServicios");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, tipoServicio.RID);
            sp.NuevoParametro("_ClaveClasificadorServicio", MySqlDbType.Int32, tipoServicio.ClaveClasificadorServicio);
            sp.NuevoParametro("_NombreServicio", MySqlDbType.VarChar, tipoServicio.NombreServicio);
            sp.NuevoParametro("_Abreviatura", MySqlDbType.VarChar, tipoServicio.Abreviatura);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, tipoServicio.Descripcion);
            sp.NuevoParametro("_DirectorioSecundario", MySqlDbType.VarChar, tipoServicio.DirectorioSecundario);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateCatTipoServicios(ECatTipoServicios tipoServicio)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_UpdateCatTipoServicios");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, tipoServicio.RID);
            sp.NuevoParametro("_ClaveClasificadorServicio", MySqlDbType.Int32, tipoServicio.ClaveClasificadorServicio);
            sp.NuevoParametro("_NombreServicio", MySqlDbType.VarChar, tipoServicio.NombreServicio);
            sp.NuevoParametro("_Abreviatura", MySqlDbType.VarChar, tipoServicio.Abreviatura);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, tipoServicio.Descripcion);
            sp.NuevoParametro("_DirectorioSecundario", MySqlDbType.VarChar, tipoServicio.DirectorioSecundario);
            return sp;
        }        
        public static ProcedimientoAlmacenado EliminarServicio(ECatTipoServicios tipoServicio)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SSP_Configuracion_DelTipoServicio");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, tipoServicio.RID);
            return sp;
        }
        #endregion

        #region caso_configuracion
        public static ProcedimientoAlmacenado GetCasoConfiguracion()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetCasoConfiguracion");

            return sp;
        }
        public static ProcedimientoAlmacenado SetCasoConfiguracion(Etcasoconfiguracion casoconfiguracion) 
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetCasoConfiguracion");
            sp.NuevoParametro("_RIDCCaso", MySqlDbType.Int32, casoconfiguracion.RIDCCaso);
            //sp.NuevoParametro("_BOIDCCaso", MySqlDbType.VarChar, casoconfiguracion.BOIDCCaso);
            sp.NuevoParametro("pClaveUnidadAdministrativa", MySqlDbType.Int32, casoconfiguracion.ClaveUnidadAdministrativa);
            sp.NuevoParametro("_ClaveTipoServicio", MySqlDbType.Int32, casoconfiguracion.ClaveTipoServicio);
            sp.NuevoParametro("_ClaveTipoCaso", MySqlDbType.Int32, casoconfiguracion.ClaveTipoCaso);
            sp.NuevoParametro("_ClaveClasificacionCaso", MySqlDbType.Int32, casoconfiguracion.ClasificacionCaso);
            sp.NuevoParametro("pClaveStatusCaso", MySqlDbType.Int32,111);
            sp.NuevoParametro("_ClaveWorkFlow", MySqlDbType.Int32, casoconfiguracion.ClaveWorkFlow);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, casoconfiguracion.Nombre);
            sp.NuevoParametro("_NombreI", MySqlDbType.VarChar, casoconfiguracion.NombreInterno);
            sp.NuevoParametro("_NombreE", MySqlDbType.VarChar, casoconfiguracion.NombreExterno);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, casoconfiguracion.Descripcion);
            sp.NuevoParametro("_DescripcionI", MySqlDbType.VarChar, casoconfiguracion.DescripcionInterna);
            sp.NuevoParametro("_DescripcionE", MySqlDbType.VarChar, casoconfiguracion.DescripcionExterna);
            sp.NuevoParametro("_AbrI", MySqlDbType.VarChar, casoconfiguracion.AbreviaturaInterna);
            sp.NuevoParametro("_AbrE", MySqlDbType.VarChar, casoconfiguracion.AbreviaturaExterna);
            //sp.NuevoParametro("_ClaveTipoDocumento", MySqlDbType.Int32, casoconfiguracion.ClaveTipoDocumento);
            sp.NuevoParametro("_PlantillaCuerpoDocumento", MySqlDbType.Text, casoconfiguracion.PlantillaCuerpoDocumento);
            sp.NuevoParametro("_DiasHabilesTerminoAtencion", MySqlDbType.Int32, casoconfiguracion.DiasHabilesTerminoAtencion);
            sp.NuevoParametro("_DiasHabilesRespuesta", MySqlDbType.Int32, casoconfiguracion.DiasHabilesRespuesta);
            sp.NuevoParametro("_PermitirRespuesta", MySqlDbType.Byte,casoconfiguracion.PermitirRespuesta);
            sp.NuevoParametro("_RequiereAcuse", MySqlDbType.Byte, casoconfiguracion.RequiereAcuse);
            sp.NuevoParametro("pClavePathPlantillaAcuse", MySqlDbType.Int32, casoconfiguracion.ClavePathPlantillaAcuse);
            sp.NuevoParametro("pDirectorioSecundarioAcuse", MySqlDbType.VarChar, casoconfiguracion.DirectorioSecundarioAcuse);
            sp.NuevoParametro("_RequiereFiel", MySqlDbType.Byte, casoconfiguracion.RequiereFiel);
            sp.NuevoParametro("_RequiereAutorizacion", MySqlDbType.Byte, casoconfiguracion.RequiereAutorizacion);
            sp.NuevoParametro("_ClaveTipoResultado", MySqlDbType.Int32, casoconfiguracion.ClaveTipoResultado);
            sp.NuevoParametro("_DirectorioSecundario", MySqlDbType.VarChar, casoconfiguracion.DirectorioSecundario);
            sp.NuevoParametro("pIniciaAutoridad", MySqlDbType.Byte, casoconfiguracion.IniciaAutoridad);
            sp.NuevoParametro("pPrioridad", MySqlDbType.Int32, casoconfiguracion.Prioridad);
            //sp.NuevoParametro("_plantillaGP", MySqlDbType.Text, casoconfiguracion.PlantillaGP);
            //sp.NuevoParametro("_procesoMasivo", MySqlDbType.Byte, casoconfiguracion.ProcesoMasivo);
            return sp;
        }
        public static ProcedimientoAlmacenado UpdateCasoConfiguracion(Etcasoconfiguracion casoconfiguracion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_UpdateCasoConfiguracion");
            sp.NuevoParametro("_RIDCCaso", MySqlDbType.Int32, casoconfiguracion.RIDCCaso);
            //sp.NuevoParametro("_BOIDCCaso", MySqlDbType.VarChar, casoconfiguracion.BOIDCCaso);
            sp.NuevoParametro("pClaveUnidadAdministrativa", MySqlDbType.Int32, casoconfiguracion.ClaveUnidadAdministrativa);
            sp.NuevoParametro("_ClaveTipoServicio", MySqlDbType.Int32, casoconfiguracion.ClaveTipoServicio);
            sp.NuevoParametro("_ClaveTipoCaso", MySqlDbType.Int32, casoconfiguracion.ClaveTipoCaso);
            sp.NuevoParametro("_ClaveClasificacionCaso", MySqlDbType.Int32, casoconfiguracion.ClasificacionCaso);
            sp.NuevoParametro("pClaveStatusCaso", MySqlDbType.Int32, 111);
            sp.NuevoParametro("_ClaveWorkFlow", MySqlDbType.Int32, casoconfiguracion.ClaveWorkFlow);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, casoconfiguracion.Nombre);
            sp.NuevoParametro("_NombreI", MySqlDbType.VarChar, casoconfiguracion.NombreInterno);
            sp.NuevoParametro("_NombreE", MySqlDbType.VarChar, casoconfiguracion.NombreExterno);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, casoconfiguracion.Descripcion);
            sp.NuevoParametro("_DescripcionI", MySqlDbType.VarChar, casoconfiguracion.DescripcionInterna);
            sp.NuevoParametro("_DescripcionE", MySqlDbType.VarChar, casoconfiguracion.DescripcionExterna);
            sp.NuevoParametro("_AbrI", MySqlDbType.VarChar, casoconfiguracion.AbreviaturaInterna);
            sp.NuevoParametro("_AbrE", MySqlDbType.VarChar, casoconfiguracion.AbreviaturaExterna);
            //sp.NuevoParametro("_ClaveTipoDocumento", MySqlDbType.Int32, casoconfiguracion.ClaveTipoDocumento);
            sp.NuevoParametro("_PlantillaCuerpoDocumento", MySqlDbType.Text, casoconfiguracion.PlantillaCuerpoDocumento);
            sp.NuevoParametro("_DiasHabilesTerminoAtencion", MySqlDbType.Int32, casoconfiguracion.DiasHabilesTerminoAtencion);
            sp.NuevoParametro("_DiasHabilesRespuesta", MySqlDbType.Int32, casoconfiguracion.DiasHabilesRespuesta);
            sp.NuevoParametro("_PermitirRespuesta", MySqlDbType.Byte, casoconfiguracion.PermitirRespuesta);
            sp.NuevoParametro("_RequiereAcuse", MySqlDbType.Byte, casoconfiguracion.RequiereAcuse);
            sp.NuevoParametro("pClavePathPlantillaAcuse", MySqlDbType.Int32, casoconfiguracion.ClavePathPlantillaAcuse);
            sp.NuevoParametro("pDirectorioSecundarioAcuse", MySqlDbType.VarChar, casoconfiguracion.DirectorioSecundarioAcuse);
            sp.NuevoParametro("_RequiereFiel", MySqlDbType.Byte, casoconfiguracion.RequiereFiel);
            sp.NuevoParametro("_RequiereAutorizacion", MySqlDbType.Byte, casoconfiguracion.RequiereAutorizacion);
            sp.NuevoParametro("_ClaveTipoResultado", MySqlDbType.Int32, casoconfiguracion.ClaveTipoResultado);
            sp.NuevoParametro("_DirectorioSecundario", MySqlDbType.VarChar, casoconfiguracion.DirectorioSecundario);
            sp.NuevoParametro("pIniciaAutoridad", MySqlDbType.Byte, casoconfiguracion.IniciaAutoridad);
            sp.NuevoParametro("pPrioridad", MySqlDbType.Int32, casoconfiguracion.Prioridad);
            //sp.NuevoParametro("_plantillaGP", MySqlDbType.Text, casoconfiguracion.PlantillaGP);
            //sp.NuevoParametro("_procesoMasivo", MySqlDbType.Byte, casoconfiguracion.ProcesoMasivo);

            return sp;
        }
        
        public static ProcedimientoAlmacenado UpdateStatusCConfiguracion(Etcasoconfiguracion casoconfiguracion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_UpdateStatusCCaso");
            sp.NuevoParametro("pStatus", MySqlDbType.Int32, casoconfiguracion.ClaveStatusCCaso);
            sp.NuevoParametro("pClvCCaso", MySqlDbType.Int32, casoconfiguracion.RIDCCaso);
            return sp;
        }

        #endregion

        #region Plantillas
        public static ProcedimientoAlmacenado ObtenerParametros()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_GPObtenerParametrosServidor");
            return sp;
        }
        #endregion

        #region tcasoc_formatos
        public static ProcedimientoAlmacenado GetTcasocformatos()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetTcasocformatos");
            return sp;
        }

        public static ProcedimientoAlmacenado SetTcasocformatos(Etcasocformatos casoFormato)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetTcasocformatos");
            //sp.NuevoParametro("_ClaveCCaso", MySqlDbType.Int32, casoFormato.ClaveCCaso);
            sp.NuevoParametro("_RIDFormato", MySqlDbType.Int32, casoFormato.RIDFormato);
            sp.NuevoParametro("_Orden", MySqlDbType.Int32, casoFormato.Orden);
            sp.NuevoParametro("_NombreInterno", MySqlDbType.VarChar, casoFormato.NombreInterno);
            sp.NuevoParametro("_NombreExterno", MySqlDbType.VarChar, casoFormato.NombreExterno);
            sp.NuevoParametro("_DescipcionInterna", MySqlDbType.VarChar, casoFormato.DescipcionInterna);
            sp.NuevoParametro("_DescripcionExterna", MySqlDbType.VarChar, casoFormato.DescripcionExterna);
            sp.NuevoParametro("_DirectorioSecundario", MySqlDbType.VarChar, casoFormato.DirectorioSecundario);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateTcasocformatos(Etcasocformatos casoFormato)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_UpdateTcasocformatos");
            //sp.NuevoParametro("_ClaveCCaso", MySqlDbType.Int32, casoFormato.ClaveCCaso);
            sp.NuevoParametro("_RIDFormato", MySqlDbType.Int32, casoFormato.RIDFormato);
            sp.NuevoParametro("_Orden", MySqlDbType.Int32, casoFormato.Orden);
            sp.NuevoParametro("_NombreInterno", MySqlDbType.VarChar, casoFormato.NombreInterno);
            sp.NuevoParametro("_NombreExterno", MySqlDbType.VarChar, casoFormato.NombreExterno);
            sp.NuevoParametro("_DescipcionInterna", MySqlDbType.VarChar, casoFormato.DescipcionInterna);
            sp.NuevoParametro("_DescripcionExterna", MySqlDbType.VarChar, casoFormato.DescripcionExterna);
            sp.NuevoParametro("_DirectorioSecundario", MySqlDbType.VarChar, casoFormato.DirectorioSecundario);
            return sp;
        }
        #endregion

        #region tcasosc_formatoseccion
        public static ProcedimientoAlmacenado GetTcasoscformatoseccion()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetTcasoscformatoseccion");
            return sp;
        }

        public static ProcedimientoAlmacenado SetTcasoscformatoseccion(Etcasoscformatoseccion casoFormatoSeccion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetTcasoscformatoseccion");
            sp.NuevoParametro("_ClaveFormato", MySqlDbType.Int32, casoFormatoSeccion.ClaveFormato);
            sp.NuevoParametro("_RIDSeccion", MySqlDbType.Int32, casoFormatoSeccion.RIDSeccion);
            sp.NuevoParametro("_Orden", MySqlDbType.Int32, casoFormatoSeccion.Orden);
            sp.NuevoParametro("_NombreInterno", MySqlDbType.VarChar, casoFormatoSeccion.NombreInterno);
            sp.NuevoParametro("_NombreExterno", MySqlDbType.VarChar, casoFormatoSeccion.NombreExterno);
            sp.NuevoParametro("_DescripcionInterna", MySqlDbType.VarChar, casoFormatoSeccion.DescripcionInterna);
            sp.NuevoParametro("_DescripcionExterna", MySqlDbType.VarChar, casoFormatoSeccion.DescripcionExterna);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateTcasoscformatoseccion(Etcasoscformatoseccion casoFormatoSeccion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_UpdateTcasoscformatoseccion");
            sp.NuevoParametro("_ClaveFormato", MySqlDbType.Int32, casoFormatoSeccion.ClaveFormato);
            sp.NuevoParametro("_RIDSeccion", MySqlDbType.Int32, casoFormatoSeccion.RIDSeccion);
            sp.NuevoParametro("_Orden", MySqlDbType.Int32, casoFormatoSeccion.Orden);
            sp.NuevoParametro("_NombreInterno", MySqlDbType.VarChar, casoFormatoSeccion.NombreInterno);
            sp.NuevoParametro("_NombreExterno", MySqlDbType.VarChar, casoFormatoSeccion.NombreExterno);
            sp.NuevoParametro("_DescripcionInterna", MySqlDbType.VarChar, casoFormatoSeccion.DescripcionInterna);
            sp.NuevoParametro("_DescripcionExterna", MySqlDbType.VarChar, casoFormatoSeccion.DescripcionExterna);
            return sp;
        }
        #endregion

        #region variables
        public static ProcedimientoAlmacenado GetCatConfiguracionVariables() {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetCatConfiguracionVariables");
            return sp;
        }

        public static ProcedimientoAlmacenado GetTcasoformatovariable() {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetTcasoformatovariable");
            return sp;
        }

        public static ProcedimientoAlmacenado SetTcasoformatovariable(Etcasoformatovariable tcasoformatovariable) {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetTcasoformatovariable");
            sp.NuevoParametro("_ClaveTipoFormulario", MySqlDbType.Int32, tcasoformatovariable.ClaveTipoFormulario);
            sp.NuevoParametro("_Clave", MySqlDbType.Int32, tcasoformatovariable.Clave);
            sp.NuevoParametro("_RID", MySqlDbType.Int32, tcasoformatovariable.RID);
            sp.NuevoParametro("_Orden", MySqlDbType.Int32, tcasoformatovariable.Orden);
            sp.NuevoParametro("_ClaveVariable", MySqlDbType.Int32, tcasoformatovariable.ClaveVariable);
            sp.NuevoParametro("_Required", MySqlDbType.Byte, tcasoformatovariable.Required);
            sp.NuevoParametro("_ContenidoDefault", MySqlDbType.VarChar, tcasoformatovariable.ContenidoDefault);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateTcasoformatovariable(Etcasoformatovariable tcasoformatovariable)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_UpdateTcasoformatovariable");
            sp.NuevoParametro("_ClaveTipoFormulario", MySqlDbType.Int32, tcasoformatovariable.ClaveTipoFormulario);
            sp.NuevoParametro("_Clave", MySqlDbType.Int32, tcasoformatovariable.Clave);
            sp.NuevoParametro("_RID", MySqlDbType.Int32, tcasoformatovariable.RID);
            sp.NuevoParametro("_Orden", MySqlDbType.Int32, tcasoformatovariable.Orden);
            sp.NuevoParametro("_ClaveVariable", MySqlDbType.Int32, tcasoformatovariable.ClaveVariable);
            sp.NuevoParametro("_Required", MySqlDbType.Byte, tcasoformatovariable.Required);
            sp.NuevoParametro("_ContenidoDefault", MySqlDbType.VarChar, tcasoformatovariable.ContenidoDefault);
            return sp;
        }


        public static ProcedimientoAlmacenado EliminarVariables(Etcasoformatovariable tcasoformatovariable)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_EliminarVariables");
            sp.NuevoParametro("pRID", MySqlDbType.Int32, tcasoformatovariable.RID);
            return sp;
        }
        public static ProcedimientoAlmacenado EliminarRespuestas(Etcasosconfiguraciontiporespuestas respuestas)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_EliminarRespuestas");
            sp.NuevoParametro("pRID", MySqlDbType.Int32, respuestas.RID);
            return sp;
        }
        public static ProcedimientoAlmacenado EliminarFormatos(Etcasocformatos formatos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_EliminarFormato");
            sp.NuevoParametro("pRID", MySqlDbType.Int32, formatos.RID);
            return sp;
        }
        public static ProcedimientoAlmacenado EliminarDocumentos(EtConfiguracionDocumentos anexo)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_EliminarDocumento");
            sp.NuevoParametro("pRID", MySqlDbType.Int32, anexo.RIDRequisito);
            return sp;
        }

        #endregion

        #region relacion caso - formato
        public static ProcedimientoAlmacenado Getrccasoformatos()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_Getrccasoformatos");
            return sp;
        }

        public static ProcedimientoAlmacenado Setrccasoformatos(Erccasoformatos rccasoformatos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_Setrccasoformatos");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, rccasoformatos.RID);
            sp.NuevoParametro("_ClaveCCaso", MySqlDbType.Int32, rccasoformatos.ClaveCCaso);
            sp.NuevoParametro("_ClaveFormato", MySqlDbType.Int32, rccasoformatos.ClaveFormato);
            return sp;
        }

        public static ProcedimientoAlmacenado Updaterccasoformatos(Erccasoformatos rccasoformatos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_Updaterccasoformatos");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, rccasoformatos.RID);
            sp.NuevoParametro("_ClaveCCaso", MySqlDbType.Int32, rccasoformatos.ClaveCCaso);
            sp.NuevoParametro("_ClaveFormato", MySqlDbType.Int32, rccasoformatos.ClaveFormato);
            return sp;
        }
        #endregion

        #region respuesta casos
        public static ProcedimientoAlmacenado Gettcasosconfiguraciontiporespuestas()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_configuracion_Gettcasosconfiguraciontiporespuestas");
            return sp;
        }

        public static ProcedimientoAlmacenado Settcasosconfiguraciontiporespuestas(Etcasosconfiguraciontiporespuestas rccasoformatos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_configuracion_Settcasosconfiguraciontiporespuestas");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, rccasoformatos.RID);
            sp.NuevoParametro("_ClaveCCaso", MySqlDbType.Int32, rccasoformatos.ClaveCCaso);
            sp.NuevoParametro("_ClaveCCasoRespuesta", MySqlDbType.Int32, rccasoformatos.ClaveCCasoRespuesta);
            return sp;
        }

        public static ProcedimientoAlmacenado Updatetcasosconfiguraciontiporespuestas(Etcasosconfiguraciontiporespuestas rccasoformatos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_configuracion_Updatetcasosconfiguraciontiporespuestas");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, rccasoformatos.RID);
            sp.NuevoParametro("_ClaveCCaso", MySqlDbType.Int32, rccasoformatos.ClaveCCaso);
            sp.NuevoParametro("_ClaveCCasoRespuesta", MySqlDbType.Int32, rccasoformatos.ClaveCCasoRespuesta);
            return sp;
        }



        #endregion

        #region Casos Agrupadores clasificadores
        public static ProcedimientoAlmacenado ConsultarClasificadoresGrupo(EtcatAgrupadores grupo)
        {
            //Para llenar los listbox
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Configuracion_GetClasificadores");
            sp.NuevoParametro("pClaveAgrupador", MySqlDbType.Int32, grupo.RIDAgrupador);
            return sp;
        }
        public static ProcedimientoAlmacenado InsertarCasosAgrupadorClasificador(EtCasosClasificadores casoAgrupador)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_SetCasosAgrupadoresClasificadores");
            //sp.NuevoParametro("pRID", MySqlDbType.Int32, casoAgrupador.RIDGrupoClasificador);
            sp.NuevoParametro("pClaveGrupo", MySqlDbType.Int32, casoAgrupador.ClaveGrupo);
            sp.NuevoParametro("pClaveclasificador", MySqlDbType.Int32, casoAgrupador.ClaveClasificador);
            sp.NuevoParametro("pClaveCaso", MySqlDbType.Int32, casoAgrupador.ClaveCaso);
            return sp;
        }
        public static ProcedimientoAlmacenado EliminarCasosAgrupadorClasificadorModal(EtCasosClasificadores casoAgrupador)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_DeleteAgrupadoresClasificadores");
            sp.NuevoParametro("pRID", MySqlDbType.Int32, casoAgrupador.RID);
            return sp;
        }


        public static ProcedimientoAlmacenado GetCasosAgrupadoresClasificadores(int RIDCaso)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_GetCasosAgrupadoresClasificadores");
            sp.NuevoParametro("pClaveCaso", MySqlDbType.Int32, RIDCaso);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateGrupoClasificadorCaso(EtCasosClasificadores casoAgrupador)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Configuracion_UpdateCasoGrupoclasificacion");
            sp.NuevoParametro("pRIDGrupoClasificador", MySqlDbType.Int32, casoAgrupador.RID);
            sp.NuevoParametro("pClaveCaso", MySqlDbType.Int32, casoAgrupador.ClaveCaso);
            return sp;
        }
        #endregion

        #region Unidad Administrativa CCasos
        public static ProcedimientoAlmacenado GetUsuario()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_GetUsuario");
            sp.NuevoParametro("pRIDUsuario", MySqlDbType.Int32, (int)EntidadUsuarioCConfiguracion.USUARIO_ACTUAL);
            return sp;
        }
        public static ProcedimientoAlmacenado GetUACasoConfiguracion(int RIDUsuario)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_GetUACasoConfiguracion");
            sp.NuevoParametro("pRIDUsuario", MySqlDbType.Int32, RIDUsuario);
            return sp;
        }
        public static ProcedimientoAlmacenado GetListUACasoConfiguracion(int RIDUAPADRE)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_GetUnidadesAdministrativas");
            sp.NuevoParametro("pRIDUAPadre", MySqlDbType.Int32, RIDUAPADRE);
            return sp;
        }
        
        public static ProcedimientoAlmacenado GetListCasoUnidad(Etcasoconfiguracion casoconfiguracion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_GetCCasoUnidadesAdministrativas");
            sp.NuevoParametro("pClaveCCaso", MySqlDbType.Int32, casoconfiguracion.RIDCCaso);
            return sp;
        }
        public static ProcedimientoAlmacenado SetUnidadCCaso(ErCCasosUnidadesAdministrativas CCasoUA)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_SetUnidadesAdministrativas");
            sp.NuevoParametro("pClaveCCaso", MySqlDbType.Int32, CCasoUA.RIDCCaso);
            sp.NuevoParametro("pClaveUA", MySqlDbType.Int32, CCasoUA.RIDUnidadAdministrativa);
            return sp;
        }
        public static ProcedimientoAlmacenado DeleteUnidadCCaso(ErCCasosUnidadesAdministrativas CCasoUA)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_DeleteUnidadesAdministrativas");
            sp.NuevoParametro("pRID", MySqlDbType.Int32, CCasoUA.RID);
            return sp;
        }

        #endregion

        public static ProcedimientoAlmacenado GetFirmantes(int RIDUA)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Configuracion_Firmantes");
            sp.NuevoParametro("pRIDUA", MySqlDbType.Int32, RIDUA);
            return sp;
        }

    }
}




