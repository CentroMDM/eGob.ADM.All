using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;
using System.Drawing;

namespace BTLConfiguracionPSRV2
{
    public class BTLConfiguracionCasos
    {
        private DAOGetObjetosNegocio daoGetObjetosNegocio = null;
        private DAOGetObjetosNegocio GetObjetosNegocio()
        {
            if (daoGetObjetosNegocio == null)
            {
                daoGetObjetosNegocio = new DAOGetObjetosNegocio();
            }
            return daoGetObjetosNegocio;
        }

        public List<Ecatdescriptivoitems> GetDescriptivoItems()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptAuxiliares.GetCatalogoItems(CatalogoDescriptivo.CONFIGURACION_CASO));
            List<Ecatdescriptivoitems> lsResultado = UtilTablas.ConvertirDataTableToList<Ecatdescriptivoitems>(table);
            return lsResultado;
        }

        #region cat_tipodocumentos
        public List<EcatExtenciones> GetlstExtenciones()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetlstExtenciones());
            List<EcatExtenciones> lsUsuarios = UtilTablas.ConvertirDataTableToList<EcatExtenciones>(table);
            return lsUsuarios;
        }
        public List<rarchivoextencion> GetRarchivoExtenciones(int RidDocumento)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetRarchivoExtenciones(RidDocumento));
            List<rarchivoextencion> lsUsuarios = UtilTablas.ConvertirDataTableToList<rarchivoextencion>(table);
            return lsUsuarios;
        }
        //public List<Ecattipodocumentos> GetTipoArchivo()
        //{
        //    DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetTipoArchivo());
        //    List<Ecattipodocumentos> lsUsuarios = UtilTablas.ConvertirDataTableToList<Ecattipodocumentos>(table);
        //    return lsUsuarios;
        //}
        public List<Ecattipodocumentos> GetCatTipoDocumentos()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetCatTipoDocumentos());
            List<Ecattipodocumentos> lsUsuarios = UtilTablas.ConvertirDataTableToList<Ecattipodocumentos>(table);
            return lsUsuarios;
        }
        public Resultado SetCCasoDocumento(EtConfiguracionDocumentos CasoDocumento)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.SetCCasoDocumento(CasoDocumento));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public List<EtConfiguracionDocumentos> GetDocumentByCase(int pRIDCCaso)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetDocumentByCase(pRIDCCaso));
            List<EtConfiguracionDocumentos> lsUsuarios = UtilTablas.ConvertirDataTableToList<EtConfiguracionDocumentos>(table);
            return lsUsuarios;
        }

        public Resultado SetCatTipoDocumentos(Ecattipodocumentos tipoDocumento) {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_TIPODOCUMENTOS);
            tipoDocumento.RIDDocumentoRequerido = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.SetCatTipoDocumentos(tipoDocumento));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado UpdateCatTipoDocumentos(Ecattipodocumentos tipoDocumento)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.UpdateCatTipoDocumentos(tipoDocumento));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion
        #region cat_tiposervicio
        public List<ECatTipoServicios> GetCatTipoServicios()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetCatTipoServicios());
            List<ECatTipoServicios> lsUsuarios = UtilTablas.ConvertirDataTableToList<ECatTipoServicios>(table);
            return lsUsuarios;
        }

        public DataTable ObtenerParametrosServidor()
        {
            DataTable tablaParametros = GetObjetosNegocio().ObtenerConsulta(sp: ScriptConfiguracionCasos.ObtenerParametrosServidor());
            return tablaParametros;
        }

        public Resultado SetCatTipoServicios(ECatTipoServicios tipoServicios)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_TIPOSERVICIOS);
            tipoServicios.RID = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.SetCatTipoServicios(tipoServicios));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }



        public Resultado UpdateCatTipoServicios(ECatTipoServicios tipoServicios)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.UpdateCatTipoServicios(tipoServicios));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }        
        public Resultado EliminarServicio(ECatTipoServicios tipoServicios)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.EliminarServicio(tipoServicios));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion
        #region caso_configuracion
        public List<Etcasoconfiguracion> GetCasoConfiguracion()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetCasoConfiguracion());
            List<Etcasoconfiguracion> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etcasoconfiguracion>(table);
            return lsUsuarios;
        }
        public Resultado SetCasoConfiguracion(Etcasoconfiguracion casoConfiguracion)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.T_CASO_CONFIGURACION);
            casoConfiguracion.RIDCCaso = RIDDefinicion.Item1;

            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.SetCasoConfiguracion(casoConfiguracion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            resultado.Dato = casoConfiguracion.RIDCCaso;
            return resultado;
        }

        public Resultado UpdateCasoConfiguracion(Etcasoconfiguracion casoConfiguracion)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.UpdateCasoConfiguracion(casoConfiguracion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        
        public Resultado UpdateStatusCConfiguracion(Etcasoconfiguracion casoConfiguracion)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.UpdateStatusCConfiguracion(casoConfiguracion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        #endregion

        #region Plantillas
        public DataTable ObtenerParametros()
        {
            DataTable tablaParametros = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.ObtenerParametros());
            return tablaParametros;
        }


        #endregion
        #region tcasoc_formatos
        public List<Etcasocformatos> GetTcasocformatos()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetTcasocformatos());
            List<Etcasocformatos> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etcasocformatos>(table);
            return lsUsuarios;
        }


        public Resultado SetTcasocformatos(Etcasocformatos casoFormato)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TCASOC_FORMATOS);
            casoFormato.RIDFormato = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.SetTcasocformatos(casoFormato));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            resultado.Dato = casoFormato.RIDFormato;
            return resultado;
        }

        public Resultado UpdateTcasocformatos(Etcasocformatos casoFormato)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.UpdateTcasocformatos(casoFormato));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion
        #region tcasosc_formatoseccion
        public List<Etcasoscformatoseccion> GetTcasoscformatoseccion()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetTcasoscformatoseccion());
            List<Etcasoscformatoseccion> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etcasoscformatoseccion>(table);
            return lsUsuarios;
        }


        public Resultado SetTcasoscformatoseccion(Etcasoscformatoseccion casoFormatoSeccion)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TCASOSC_FORMATOSECCION);
            casoFormatoSeccion.RIDSeccion = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.SetTcasoscformatoseccion(casoFormatoSeccion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            resultado.Dato = casoFormatoSeccion.RIDSeccion;
            return resultado;
        }

        public Resultado UpdateTcasoscformatoseccion(Etcasoscformatoseccion casoFormatoSeccion)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.UpdateTcasoscformatoseccion(casoFormatoSeccion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion
        #region Variables
        public List<Ecatconfiguracionvariables> GetCatConfiguracionVariables() {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetCatConfiguracionVariables());
            List<Ecatconfiguracionvariables> lsVariables = UtilTablas.ConvertirDataTableToList<Ecatconfiguracionvariables>(table);
            return lsVariables;
        }

        public List<Etcasoformatovariable> GetTcasoformatovariable() {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetTcasoformatovariable());
            List<Etcasoformatovariable> lsVariables = UtilTablas.ConvertirDataTableToList<Etcasoformatovariable>(table);
            return lsVariables;
        }

        public Resultado SetTcasoformatovariable(Etcasoformatovariable tcasoformatovariable) {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TCASO_FORMATOVARIABLE);
            tcasoformatovariable.RID = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.SetTcasoformatovariable(tcasoformatovariable));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado UpdateTcasoformatovariable(Etcasoformatovariable tcasoformatovariable)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.UpdateTcasoformatovariable(tcasoformatovariable));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion
        #region relacion caso-formato
        public List<Erccasoformatos> Getrccasoformatos()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.Getrccasoformatos());
            List<Erccasoformatos> lsVariables = UtilTablas.ConvertirDataTableToList<Erccasoformatos>(table);
            return lsVariables;
        }

        public Resultado Setrccasoformatos(Erccasoformatos rccasoformatos)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.RCCASO_FORMATOS);
            rccasoformatos.RID = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.Setrccasoformatos(rccasoformatos));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado Updaterccasoformatos(Erccasoformatos rccasoformatos)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.Updaterccasoformatos(rccasoformatos));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado EliminarVariables(Etcasoformatovariable objetoNegocio)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.EliminarVariables(objetoNegocio));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado EliminarRespuestas(Etcasosconfiguraciontiporespuestas objetoNegocio)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.EliminarRespuestas(objetoNegocio));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado EliminarFormatos(Etcasocformatos objetoNegocio)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.EliminarFormatos(objetoNegocio));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado EliminarDocumentos(EtConfiguracionDocumentos objetoNegocio)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.EliminarDocumentos(objetoNegocio));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion
        #region respuesta casos
        public List<Etcasosconfiguraciontiporespuestas> Gettcasosconfiguraciontiporespuestas()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.Gettcasosconfiguraciontiporespuestas());
            List<Etcasosconfiguraciontiporespuestas> lsVariables = UtilTablas.ConvertirDataTableToList<Etcasosconfiguraciontiporespuestas>(table);
            return lsVariables;
        }

        public Resultado Settcasosconfiguraciontiporespuestas(Etcasosconfiguraciontiporespuestas casosConfiguracionRespuesta)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TCASOS_CONFIGURACIONTIPORESPUESTAS);
            casosConfiguracionRespuesta.RID = RIDDefinicion.Item1;

            DataTable table = setIngresar.InsertarRegistro(ScriptConfiguracionCasos.Settcasosconfiguraciontiporespuestas(casosConfiguracionRespuesta));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado Updatetcasosconfiguraciontiporespuestas(Etcasosconfiguraciontiporespuestas casosConfiguracionRespuesta)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.Updatetcasosconfiguraciontiporespuestas(casosConfiguracionRespuesta));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }


        #endregion
        #region Casos_agrupadores_Controladores
        public List<EtcatAgrupadores> ConsultaAgrupadores()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptAgrupadores.consultaAgrupadores());
            List<EtcatAgrupadores> lsResultado = UtilTablas.ConvertirDataTableToList<EtcatAgrupadores>(table);
            return lsResultado;
        }
        
        public List<EtcatAgrupadoresClasificadores> ConsultarClasificadoresGrupo(EtcatAgrupadores grupo)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.ConsultarClasificadoresGrupo(grupo));
            List<EtcatAgrupadoresClasificadores> lsResultado = UtilTablas.ConvertirDataTableToList<EtcatAgrupadoresClasificadores>(table);
            return lsResultado;
        }
        #endregion

        #region casos_grupo_clasificacion
        public List<EtCasosClasificadores> GetCasosAgrupadoresClasificadores(int RIDCaso)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetCasosAgrupadoresClasificadores(RIDCaso));
            List<EtCasosClasificadores> lsGrupoClas = UtilTablas.ConvertirDataTableToList<EtCasosClasificadores>(table);
            return lsGrupoClas;
        }

        public List<EtCasosClasificadores> InsertarCasosAgrupadorClasificador(EtCasosClasificadores casoagrupador)
        {
            //Pide ID al control de folios
            //DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            //(int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TCASOS_GRUPOCLASIFICACION);
            //casoagrupador.RIDGrupoClasificador = RIDDefinicion.Item1;


            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.InsertarCasosAgrupadorClasificador(casoagrupador));
            List<EtCasosClasificadores> lsResultado = UtilTablas.ConvertirDataTableToList<EtCasosClasificadores>(table);
            return lsResultado;
        }
        public Resultado EliminarCasosAgrupadorClasificadorModal(EtCasosClasificadores casoagrupador)
        {
            DAOUpdateorDeleteObjetosNegocio DeteleCasoAgrupador = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = DeteleCasoAgrupador.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.EliminarCasosAgrupadorClasificadorModal(casoagrupador));
            Resultado lsResultado = UtilTablas.ResultadoDesdeTabla(table);
            return lsResultado;
        }

        public List<EtCasosClasificadores> UpdateGrupoClasificadorCaso(EtCasosClasificadores casoagrupador)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.UpdateGrupoClasificadorCaso(casoagrupador));
            List<EtCasosClasificadores> lsResultado = UtilTablas.ConvertirDataTableToList<EtCasosClasificadores>(table);
            return lsResultado;
        }

        #endregion

        #region Unidades Administrativas CCasos
        public List<Etusuarios> GetUsuario()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetUsuario());
            List<Etusuarios> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etusuarios>(table);
            return lsUsuarios;
        }
        public List<Etunidadadministrativa> GetUACasoConfiguracion(int RIDUsuario)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetUACasoConfiguracion(RIDUsuario));
            List<Etunidadadministrativa> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etunidadadministrativa>(table);
            return lsUsuarios;
        }
        public List<Etunidadadministrativa> GetListUACasoConfiguracion(int RIDUAPADRE)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetListUACasoConfiguracion(RIDUAPADRE));
            List<Etunidadadministrativa> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etunidadadministrativa>(table);
            return lsUsuarios;
        }
        
            public List<ErCCasosUnidadesAdministrativas> GetListCasoUnidad(Etcasoconfiguracion casoconfiguracion)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetListCasoUnidad(casoconfiguracion));
            List<ErCCasosUnidadesAdministrativas> lsUsuarios = UtilTablas.ConvertirDataTableToList<ErCCasosUnidadesAdministrativas>(table);
            return lsUsuarios;
        }
        public Resultado SetUnidadCCaso(ErCCasosUnidadesAdministrativas CCasoUA)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.SetUnidadCCaso(CCasoUA));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado DeleteUnidadCCaso(ErCCasosUnidadesAdministrativas CCasoUA)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptConfiguracionCasos.DeleteUnidadCCaso(CCasoUA));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        #endregion

        #region Firmantes
        public List<EtFirmantes> GetFirmantes(int RIDUA)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptConfiguracionCasos.GetFirmantes(RIDUA));
            List<EtFirmantes> lsVariables = UtilTablas.ConvertirDataTableToList<EtFirmantes>(table);
            return lsVariables;
        }
        #endregion

    }
}

