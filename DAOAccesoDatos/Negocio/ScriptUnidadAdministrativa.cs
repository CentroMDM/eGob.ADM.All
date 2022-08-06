using EntitiesPSR;
using MySql.Data.MySqlClient;
using System;

namespace DAOAccesoDatos
{
    public static class ScriptUnidadAdministrativa
    {

        public static ProcedimientoAlmacenado ObtenerParametros()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_GPObtenerParametrosServidor");
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerUnidadesAdministrativas()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_GetUnidadAdministrativa");
            return sp;
        }
        public static ProcedimientoAlmacenado datosOrganigrama()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SSP_Administracion_GetOrganigrama");
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerBuzonesConfiguracion()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetBuzonConfiguracion");
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerBuzonConfiguracionFiltros()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetBuzonConfiguracionFiltros");
            return sp;
        }

        public static ProcedimientoAlmacenado GetConfigBuzon()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SSP_Administracion_GetConfigBuzon");
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateConfigBuzon(EcatBuzonFiscal implementacion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SSP_Administracion_UpdateConfigBuzon");
            sp.NuevoParametro("_RIDConfig", MySqlDbType.Int64, implementacion.RIDConfiguracion);
            sp.NuevoParametro("_URLBuzonFiscal", MySqlDbType.VarChar, implementacion.URLBuzonFiscal);
            sp.NuevoParametro("_DirectorioSecundarioLogoApp", MySqlDbType.VarChar, implementacion.DirectorioSecundarioLogoApp);
            sp.NuevoParametro("_DirectorioSecundarioLogo", MySqlDbType.VarChar, implementacion.DirectorioSecundarioLogo);
            sp.NuevoParametro("_DirectorioSecundarioImagenHome", MySqlDbType.VarChar, implementacion.DirectorioSecundarioImagenHome);
            sp.NuevoParametro("_NombreTema", MySqlDbType.VarChar, implementacion.NombreTema);
            sp.NuevoParametro("_ModoTema", MySqlDbType.VarChar, implementacion.ModoTema);
            sp.NuevoParametro("_FLN", MySqlDbType.Text, implementacion.FLN);
            sp.NuevoParametro("_FLBF", MySqlDbType.Text, implementacion.FLBF);
            return sp;
        }

        public static ProcedimientoAlmacenado ObtenerEmpleados()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetEmpleados");
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerPuestosInstitucionales()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_GetPuestosInstitucionales");
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerNivelesPuestosInstitucionales()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_GetNivelesPuestos");
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerCodigoPostalMunicipio(int municipio)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_GetCodigoPostalMunicipio");
            sp.NuevoParametro("_ClaveMunicipio", MySqlDbType.Int32, municipio);
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerColoniasCP(string codigoPostal)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_GetColoniaCP");
            sp.NuevoParametro("_CP", MySqlDbType.VarChar, codigoPostal);
            return sp;
        }
        public static ProcedimientoAlmacenado BuscarFiltros(Ecattipofiltrosinicialesbuzon filtroInicial)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado(filtroInicial.SP_GetCatalogo);
            return sp;
        }
        public static ProcedimientoAlmacenado GetCatTipoServicios()
        {
            throw new NotImplementedException();
        }
        /*public static ProcedimientoAlmacenado GetCatTipoServicios()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_GPObtenerParametrosServidor");
            return sp;
        }*/
        public static ProcedimientoAlmacenado ObtenerEntidadFederativa()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_GetEntidadFederativa");
            sp.NuevoParametro("_RIDEntidad", MySqlDbType.Int32, (int)EntidadDeImplementacion.ENTIDAD_IMPLEMENTACION);
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerMunicipios(EcatcpEntidadesFederativas EntidadFederativa)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_GetMunicipios");
            sp.NuevoParametro("_RIDEntidad", MySqlDbType.Int32, EntidadFederativa.RIDEntidad);
            return sp;
        }
        public static ProcedimientoAlmacenado InsertarUnidadAdministrativa(Etunidadadministrativa unidadAdministrativa)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_SetUnidadAdministrativa");
            sp.NuevoParametro("_ClaveImplementacion", MySqlDbType.Int32, unidadAdministrativa.ClaveImplementacion);
            sp.NuevoParametro("_ClaveUAPadre", MySqlDbType.Int32, unidadAdministrativa.ClaveUAPadre);
            sp.NuevoParametro("_RIDUnidadAdministrativa", MySqlDbType.Int32, unidadAdministrativa.RIDUnidadAdministrativa);
            //sp.NuevoParametro("_BOIDUnidadAdministrativa", MySqlDbType.VarChar, unidadAdministrativa.BOIDUnidadAdministrativa);
            sp.NuevoParametro("_NombreUA", MySqlDbType.VarChar, unidadAdministrativa.NombreUA);
            sp.NuevoParametro("_AbreviaturaUA", MySqlDbType.VarChar, unidadAdministrativa.AbreviaturaUA);
            sp.NuevoParametro("_ClaveDirectorioLogo", MySqlDbType.Int32, unidadAdministrativa.ClaveDirectorioLogo);
            sp.NuevoParametro("_DirectorioSecundarioLogo", MySqlDbType.VarChar, unidadAdministrativa.DirectorioSecundarioLogo);
            sp.NuevoParametro("_Estado", MySqlDbType.VarChar, unidadAdministrativa.Estado);
            sp.NuevoParametro("_ClaveMunicipio", MySqlDbType.Int16, unidadAdministrativa.ClaveMunicipio);
            sp.NuevoParametro("_CodigoPostal", MySqlDbType.VarChar, unidadAdministrativa.CodigoPostal);
            sp.NuevoParametro("_ClaveCP", MySqlDbType.Int16, unidadAdministrativa.ClaveCP);
            sp.NuevoParametro("_Calle", MySqlDbType.VarChar, unidadAdministrativa.Calle);
            sp.NuevoParametro("_NumeroExterior", MySqlDbType.VarChar, unidadAdministrativa.NumExt);
            sp.NuevoParametro("_NumeroInterior", MySqlDbType.VarChar, unidadAdministrativa.NumInt);
            sp.NuevoParametro("_ClaveEmpleado", MySqlDbType.Int32, unidadAdministrativa.ClaveEmpleado);
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerAplicaciones()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetAplicacionBuzon");
            return sp;
        }
        public static ProcedimientoAlmacenado ObtenerFiltros()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetFiltroBuzon");
            return sp;
        }
        public static ProcedimientoAlmacenado IngresarBuzonConfiguracion(Ebuzonesconfiguracion buzonConfiguracion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetBuzonConfiguracion");
            sp.NuevoParametro("_RIDBuzon", MySqlDbType.Int32, buzonConfiguracion.RIDBuzon);
            //sp.NuevoParametro("_BOIDBuzon", MySqlDbType.VarChar, buzonConfiguracion.BOIDBuzon);
            sp.NuevoParametro("_ClaveUnidadAdmva", MySqlDbType.Int32, buzonConfiguracion.ClaveUnidadAdmva);
            sp.NuevoParametro("_ClaveTipoBuzon", MySqlDbType.Int32, buzonConfiguracion.ClaveTipoBuzon);
            sp.NuevoParametro("_NombreBuzon", MySqlDbType.VarChar, buzonConfiguracion.NombreBuzon);
            sp.NuevoParametro("_AliasBuzon", MySqlDbType.VarChar, buzonConfiguracion.AliasBuzon);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, buzonConfiguracion.Descripcion);
            sp.NuevoParametro("_DirectorioSecundarioLogo", MySqlDbType.VarChar, buzonConfiguracion.DirectorioSecundarioLogo);
            //sp.NuevoParametro("_IconoFontAsome", MySqlDbType.VarChar, buzonConfiguracion.IconoFontAsome);
            return sp;
        }
        public static ProcedimientoAlmacenado IngresarFiltros(Ebuzonconfiguracionfiltros buzonConfiguracionFiltro)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetBuzonConfiguracionFiltros");
            sp.NuevoParametro("_RID", MySqlDbType.Int32, buzonConfiguracionFiltro.RID);
            sp.NuevoParametro("_ClaveBuzon", MySqlDbType.Int32, buzonConfiguracionFiltro.ClaveBuzon);
            sp.NuevoParametro("_ClaveTipoFiltro", MySqlDbType.Int16, buzonConfiguracionFiltro.ClaveTipoFiltro);
            sp.NuevoParametro("_ClaveCatalogo", MySqlDbType.Int32, buzonConfiguracionFiltro.ClaveCatalogo);
            //sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, buzonConfiguracionFiltro.Nombre);
            //sp.NuevoParametro("_Display", MySqlDbType.VarChar, buzonConfiguracionFiltro.Display);
            //sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, buzonConfiguracionFiltro.Descripcion);
            return sp;
        }
        public static ProcedimientoAlmacenado ActualizarUnidadAdministrativa(Etunidadadministrativa unidadAdministrativa)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_UpdateUnidadAdministrativa");
            sp.NuevoParametro("_ClaveImplementacion", MySqlDbType.Int64, unidadAdministrativa.ClaveImplementacion);
            sp.NuevoParametro("_ClaveUAPadre", MySqlDbType.Int64, unidadAdministrativa.ClaveUAPadre);
            sp.NuevoParametro("_RIDUnidadAdministrativa", MySqlDbType.VarChar, unidadAdministrativa.RIDUnidadAdministrativa);
            sp.NuevoParametro("_NombreUA", MySqlDbType.VarChar, unidadAdministrativa.NombreUA);
            sp.NuevoParametro("_AbreviaturaUA", MySqlDbType.VarChar, unidadAdministrativa.AbreviaturaUA);
            sp.NuevoParametro("_ClaveDirectorioLogo", MySqlDbType.Int64, unidadAdministrativa.ClaveDirectorioLogo);
            sp.NuevoParametro("_DirectorioSecundarioLogo", MySqlDbType.VarChar, unidadAdministrativa.DirectorioSecundarioLogo);
            sp.NuevoParametro("_Estado", MySqlDbType.VarChar, unidadAdministrativa.Estado);
            sp.NuevoParametro("_ClaveMunicipio", MySqlDbType.Int16, unidadAdministrativa.ClaveMunicipio);
            sp.NuevoParametro("_CodigoPostal", MySqlDbType.VarChar, unidadAdministrativa.CodigoPostal);
            sp.NuevoParametro("_ClaveCP", MySqlDbType.Int16, unidadAdministrativa.ClaveCP);
            sp.NuevoParametro("_Calle", MySqlDbType.VarChar, unidadAdministrativa.Calle);
            sp.NuevoParametro("_NumeroExterior", MySqlDbType.VarChar, unidadAdministrativa.NumExt);
            sp.NuevoParametro("_NumeroInterior", MySqlDbType.VarChar, unidadAdministrativa.NumInt);
            sp.NuevoParametro("_ClaveEmpleado", MySqlDbType.Int64, unidadAdministrativa.ClaveEmpleado);
            return sp;
        }
        public static ProcedimientoAlmacenado IngresarEmpleado(Etempleados empleados)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetEmpleado");
            sp.NuevoParametro("_RIDEmpleado", MySqlDbType.Int32, empleados.RIDEmpleado);
            sp.NuevoParametro("_RFCEmpleado", MySqlDbType.VarChar, empleados.RFCEmpleado);
            //sp.NuevoParametro("_BOIDEmpleado", MySqlDbType.VarChar, empleados.BOIDEmpleado);
            sp.NuevoParametro("_NombreEmpleado", MySqlDbType.VarChar, empleados.NombreEmpleado);
            sp.NuevoParametro("_APaterno", MySqlDbType.VarChar, empleados.APaterno);
            sp.NuevoParametro("_AMaterno", MySqlDbType.VarChar, empleados.AMaterno);
            sp.NuevoParametro("_NumeroEmpleado", MySqlDbType.VarChar, empleados.NumeroEmpleado);
            sp.NuevoParametro("_DirectorioSecundarioFoto", MySqlDbType.VarChar, empleados.DirectorioSecundarioFoto);
            sp.NuevoParametro("_ClavePuesto", MySqlDbType.Int32, empleados.PuestoInstitucional.RIDPuestos);
            return sp;
        }
        public static ProcedimientoAlmacenado ActualizarEmpleado(Etempleados empleados)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_UpdateEmpleado");
            sp.NuevoParametro("_RIDEmpleado", MySqlDbType.Int64, empleados.RIDEmpleado);
            sp.NuevoParametro("_RFCEmpleado", MySqlDbType.VarChar, empleados.RFCEmpleado);
            sp.NuevoParametro("_NombreEmpleado", MySqlDbType.VarChar, empleados.NombreEmpleado);
            sp.NuevoParametro("_APaterno", MySqlDbType.VarChar, empleados.APaterno);
            sp.NuevoParametro("_AMaterno", MySqlDbType.VarChar, empleados.AMaterno);
            sp.NuevoParametro("_NumeroEmpleado", MySqlDbType.VarChar, empleados.NumeroEmpleado);
            sp.NuevoParametro("_DirectorioSecundarioFoto", MySqlDbType.VarChar, empleados.DirectorioSecundarioFoto);
            sp.NuevoParametro("_ClavePuesto", MySqlDbType.Int64, empleados.ClavePuesto);
            return sp;
        }
        public static ProcedimientoAlmacenado EliminarUnidadAdministrativa(Etunidadadministrativa unidad)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_DelUnidadAdministrativa");
            sp.NuevoParametro("_RIDUnidadAdministrativa", MySqlDbType.Int64, unidad.RIDUnidadAdministrativa);
            return sp;
        }
        public static ProcedimientoAlmacenado EliminarEmpleado(Etempleados empleado)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_DelEmpleado");
            sp.NuevoParametro("_RIDEmpleado", MySqlDbType.Int64, empleado.RIDEmpleado);
            return sp;
        }

        #region implementacion
        public static ProcedimientoAlmacenado GetImplementacion()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_Gettimplementacion");
            return sp;
        }
        public static ProcedimientoAlmacenado GetConfigImp()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("BSP_Implementacion_GetConfiguracion");
            //sp.NuevoParametro("GUIDImplementacion_", MySqlDbType.VarChar, "ED34520F-DA5C-4EAE-9A27-6655DA4DFCB0");
            //sp.NuevoParametro("GUIDImplementacion_", MySqlDbType.VarChar, "0C1B4E03-05C8-485F-A167-DE9DDC1F46EF");
            //sp.NuevoParametro("GUIDImplementacion_", MySqlDbType.VarChar, "AFCBF41F-F763-11EA-91B2-503EAAB753B5");
            return sp;
        }
        public static ProcedimientoAlmacenado GetConfiguracionARC(Erusuariobuzon usuario)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("JSP_GetConfiguracionARC");
            sp.NuevoParametro("ClaveUsuario_", MySqlDbType.Int32, usuario.ClaveUsuario);
            sp.NuevoParametro("ClaveAplicacion_", MySqlDbType.Int32, usuario.ClaveAplicacion);
            sp.NuevoParametro("ClaveBuzon_", MySqlDbType.Int32, usuario.ClaveBuzon);
            return sp;
        }
        public static ProcedimientoAlmacenado GetNiveldeGobierno()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_GetNivelesGobierno");
            return sp;
        }
        public static ProcedimientoAlmacenado GetCatAplicaciones()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_Getcataplicaciones");
            return sp;
        }
        public static ProcedimientoAlmacenado GetImpEntidadesFederativas()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_GetImpEntidadesFederativas");
            return sp;
        }
        public static ProcedimientoAlmacenado GetImpMunicipios(EcatcpEntidadesFederativas entidades)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_GetImpMunicipios");
            sp.NuevoParametro("_ClaveEntidad", MySqlDbType.Int32, entidades.RIDEntidad);
            return sp;
        }
        public static ProcedimientoAlmacenado Updatetimplementacion(Etimplementacion implementacion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_Updatetimplementacion");
            sp.NuevoParametro("_RIDImplementacion", MySqlDbType.Int64, implementacion.RIDImplementacion);
            sp.NuevoParametro("_GUIDImplementacion", MySqlDbType.VarChar, implementacion.GUIDImplementacion);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, implementacion.Nombre);
            sp.NuevoParametro("_NombreTema", MySqlDbType.VarChar, implementacion.NombreTema);
            sp.NuevoParametro("_ModoTema", MySqlDbType.VarChar, implementacion.ModoTema);
            sp.NuevoParametro("_Lema", MySqlDbType.VarChar, implementacion.Lema);
            //sp.NuevoParametro("_Privacidad", MySqlDbType.VarChar, implementacion.Privacidad);
            sp.NuevoParametro("_FaviconDirectorioSecundario", MySqlDbType.VarChar, implementacion.FaviconDirectorioSecundario);
            sp.NuevoParametro("_LogoDirectorioSecundario", MySqlDbType.VarChar, implementacion.LogoDirectorioSecundario);
            sp.NuevoParametro("_ImagenHomeDirectorioSecundario", MySqlDbType.VarChar, implementacion.ImagenHomeDirectorioSecundario);
            sp.NuevoParametro("_Estado", MySqlDbType.Int32, implementacion.Estado);
            sp.NuevoParametro("_ClaveMunicipio", MySqlDbType.Int32, implementacion.ClaveMunicipio);
            sp.NuevoParametro("_ClaveNivelGobierno", MySqlDbType.Int32, implementacion.claveNivelGobierno);
            sp.NuevoParametro("_ClaveEntidadNivelGobierno", MySqlDbType.Int32, implementacion.claveEntidadNivelGobierno);
            sp.NuevoParametro("_ClaveMunicipioNivelGobierno", MySqlDbType.Int32, implementacion.claveMunicipioNivelGobierno);
            sp.NuevoParametro("_CodigoPostal", MySqlDbType.VarChar, implementacion.CodigoPostal);
            sp.NuevoParametro("_ClaveCP", MySqlDbType.Int32, implementacion.ClaveCP);
            sp.NuevoParametro("_Calle", MySqlDbType.VarChar, implementacion.Calle);
            sp.NuevoParametro("_NumExt", MySqlDbType.VarChar, implementacion.NumExt);
            sp.NuevoParametro("_NumInt", MySqlDbType.VarChar, implementacion.NumInt);
            sp.NuevoParametro("_NombreAbreviado", MySqlDbType.VarChar, implementacion.NombreAbreviado);
            sp.NuevoParametro("_HorarioInicioLaboral", MySqlDbType.VarChar, implementacion.HorarioInicioLaboral.ToString("yyyy-MM-dd HH:mm:ss"));
            sp.NuevoParametro("_HorarioFinLaboral", MySqlDbType.VarChar, implementacion.HorarioFinLaboral.ToString("yyyy-MM-dd HH:mm:ss"));
            sp.NuevoParametro("_FechaInicio", MySqlDbType.VarChar, implementacion.FechaInicio.ToString("yyyy-MM-dd HH:mm:ss"));
            sp.NuevoParametro("_FechaFin", MySqlDbType.VarChar, implementacion.FechaFin.ToString("yyyy-MM-dd HH:mm:ss"));
            return sp;
        }
        public static ProcedimientoAlmacenado Updatecataplicaciones(Ecataplicaciones aplicaciones)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_Updatecataplicaciones");
            sp.NuevoParametro("_RIDAplicacion", MySqlDbType.Int32, aplicaciones.RIDAplicacion);
            sp.NuevoParametro("_NombreAplicacion", MySqlDbType.VarChar, aplicaciones.NombreAplicacion);
            sp.NuevoParametro("_URLAcceso", MySqlDbType.VarChar, aplicaciones.URLAcceso);
            return sp;
        }
        #endregion

    }
}