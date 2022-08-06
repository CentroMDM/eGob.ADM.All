using EntitiesPSR;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOAccesoDatos
{
    public class ScriptClasificacionSujetos
    {
        #region Niveles de mando
        public static ProcedimientoAlmacenado ObtenerTipoSujetosObjetos()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Cumplimiento_GetTipoSujetosObjetos");
            return sp;
        }

        public static ProcedimientoAlmacenado ObtenerObjetosClasificados(EtcatAgrupadoresClasificadores objetoNegocio)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Cumplimiento_GETObjetosClasificados");
            sp.NuevoParametro("pClaveClasificador", MySqlDbType.Int32, objetoNegocio.RIDClasificador);
            return sp;
        }

        public static ProcedimientoAlmacenado EliminaClasificacion(EConsultaObjetosClasificados objetoNegocio)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Cumplimiento_DELObjetosClasificados");
            sp.NuevoParametro("pClaveTipoObjeto", MySqlDbType.Int32, objetoNegocio.RIDItemCatalogo);
            sp.NuevoParametro("pClaveClasificador", MySqlDbType.Int32, objetoNegocio.RIDClasificador);
            sp.NuevoParametro("pClaveObjeto", MySqlDbType.VarChar, objetoNegocio.Identificador);
            return sp;
        }

        

        public static ProcedimientoAlmacenado InsertarTipoSujetoObjeto(EcatTipoSujetosObjetos tipoSujetoObjeto)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Cumplimiento_SetTipoSujetosObjetos");
            sp.NuevoParametro("pRIDItemCatalogo", MySqlDbType.Int32, tipoSujetoObjeto.RIDItemCatalogo);
            sp.NuevoParametro("pnombreItem", MySqlDbType.VarChar, tipoSujetoObjeto.nombreItem);
            return sp;
        }

        public static ProcedimientoAlmacenado ConsultarClasificadoresGrupo(EtcatAgrupadores grupo)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Configuracion_GetClasificadores");
            sp.NuevoParametro("pClaveAgrupador", MySqlDbType.Int32, grupo.RIDAgrupador);
            return sp;
        }

        public static ProcedimientoAlmacenado InsertarClasificacionSujetoObjeto(EClasificacionSujetoObjeto clasiifcadorSujeto)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Cumplimiento_SetClasificadores");
            sp.NuevoParametro("pclaveTipoObjeto", MySqlDbType.Int32, clasiifcadorSujeto.ClaveSujetoObjeto);
            sp.NuevoParametro("pClaveClasificador", MySqlDbType.Int32, clasiifcadorSujeto.ClaveClasificador);
            sp.NuevoParametro("pClaveObjeto", MySqlDbType.VarChar, clasiifcadorSujeto.ClaveObjeto);
            return sp;
        }



        /*
        public static ProcedimientoAlmacenado InsertarAgrupador(EtcatAgrupadores agrupadores)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetAgrupador");
            sp.NuevoParametro("pRIDAgrupador", MySqlDbType.Int32, agrupadores.RIDAgrupador);
            sp.NuevoParametro("pnombreAgrupador", MySqlDbType.VarChar, agrupadores.nombreAgrupador);
            return sp;
        }

        public static ProcedimientoAlmacenado ActuaizarClasificador(EtcatClasificadores clasificadores)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_UpdateClasificador");
            sp.NuevoParametro("pRIDClasificador", MySqlDbType.Int32, clasificadores.RIDClasificador);
            sp.NuevoParametro("pClaveAgrupador", MySqlDbType.Int32, clasificadores.ClaveAgrupador);
            sp.NuevoParametro("pnombreClasificador", MySqlDbType.VarChar, clasificadores.nombreClasificador);
            sp.NuevoParametro("pdescripcionClasificador", MySqlDbType.VarChar, clasificadores.descripcionClasificador);
            sp.NuevoParametro("piconoClasificador", MySqlDbType.VarChar, clasificadores.iconoClasificador);
            sp.NuevoParametro("pcolorClasificador", MySqlDbType.VarChar, clasificadores.colorClasificador);
            return sp;
        }

        public static ProcedimientoAlmacenado EliminarClasificador(EtcatClasificadores clasificadores)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_DelClasificador");
            sp.NuevoParametro("pRIDClasificador", MySqlDbType.Int32, clasificadores.RIDClasificador);
            return sp;
        }


        public static ProcedimientoAlmacenado InsertarClasificador(EtcatClasificadores clasificadores)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Configuracion_SetClasificador");
            sp.NuevoParametro("pRIDClasificador", MySqlDbType.Int32, clasificadores.RIDClasificador);
            sp.NuevoParametro("pClaveAgrupador", MySqlDbType.Int32, clasificadores.ClaveAgrupador);
            sp.NuevoParametro("pnombreClasificador", MySqlDbType.VarChar, clasificadores.nombreClasificador);
            sp.NuevoParametro("pdescripcionClasificador", MySqlDbType.VarChar, clasificadores.descripcionClasificador);
            sp.NuevoParametro("piconoClasificador", MySqlDbType.VarChar, clasificadores.iconoClasificador);
            sp.NuevoParametro("pcolorClasificador", MySqlDbType.VarChar, clasificadores.colorClasificador);
            return sp;
        }


        public static ProcedimientoAlmacenado EliminarNivelPuesto(EcatNivelesPuestos nivelPuesto)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_DelNivelPuesto");
            sp.NuevoParametro("_RIDNivel", MySqlDbType.Int64, nivelPuesto.RIDNivel);
            return sp;
        }

        public static ProcedimientoAlmacenado ActualizarNivelPuesto(EcatNivelesPuestos nivelPuesto)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_UpdateNivelPuesto");
            sp.NuevoParametro("_RIDNivel", MySqlDbType.Int64, nivelPuesto.RIDNivel);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, nivelPuesto.Nombre);
            sp.NuevoParametro("_Clave", MySqlDbType.VarChar, nivelPuesto.Clave);
            return sp;
        }
        #endregion

        #region Catalogo institucional de puestos

        public static ProcedimientoAlmacenado ObtenerPuestosInstitucionales()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_GetPuestosInstitucionales");
            return sp;
        }
        public static ProcedimientoAlmacenado IngresarPuestoInstitucional(EtcatPuestos puestoInstitucional)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_SetPuesto");
            sp.NuevoParametro("_RIDPuestos", MySqlDbType.Int32, puestoInstitucional.RIDPuestos);
            //sp.NuevoParametro("_BOIDPuesto", MySqlDbType.VarChar, puestoInstitucional.BOIDPuesto);
            sp.NuevoParametro("_ClaveNivelPuesto", MySqlDbType.Int32, puestoInstitucional.ClaveNivelPuesto);
            sp.NuevoParametro("_ClaveUnidadAdministrativa", MySqlDbType.Int32, puestoInstitucional.ClaveUnidadAdministrativa);
            sp.NuevoParametro("_nombrePuesto", MySqlDbType.VarChar, puestoInstitucional.NombrePuesto);
            sp.NuevoParametro("_abreviatura", MySqlDbType.VarChar, puestoInstitucional.Abreviatura);
            sp.NuevoParametro("_descripcionPuesto", MySqlDbType.VarChar, puestoInstitucional.DescricionPuesto);
            return sp;
        }
        public static ProcedimientoAlmacenado EliminarPuestoInstitucional(EtcatPuestos puestoInstitucional)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_DelPuestoInstitucional");
            sp.NuevoParametro("_RIDPuesto", MySqlDbType.Int64, puestoInstitucional.RIDPuestos);
            return sp;
        }
        public static ProcedimientoAlmacenado ActualizarPuestoInstitucional(EtcatPuestos puestoInstitucional)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_UpdatePuestoInstitucional");
            sp.NuevoParametro("_RIDPuestos", MySqlDbType.Int64, puestoInstitucional.RIDPuestos);
            sp.NuevoParametro("_ClaveNivelPuesto", MySqlDbType.Int64, puestoInstitucional.ClaveNivelPuesto);
            sp.NuevoParametro("_claveUnidadAdministrativa", MySqlDbType.Int64, puestoInstitucional.ClaveUnidadAdministrativa);
            sp.NuevoParametro("_nombrePuesto", MySqlDbType.VarChar, puestoInstitucional.NombrePuesto);
            sp.NuevoParametro("_abreviatura", MySqlDbType.VarChar, puestoInstitucional.Abreviatura);
            sp.NuevoParametro("_descripcionPuesto", MySqlDbType.VarChar, puestoInstitucional.DescricionPuesto);
            return sp;
        }
        */
        #endregion
    }
}
