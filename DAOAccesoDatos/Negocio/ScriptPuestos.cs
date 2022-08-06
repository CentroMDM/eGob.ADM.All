using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesPSR;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public static class ScriptPuestos
    {
        #region Niveles de mando
        public static ProcedimientoAlmacenado ObtenerNivelPuesto()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("Sp_Administracion_GetNivelesPuestos");
            return sp;
        }

        public static ProcedimientoAlmacenado InsertarNivelPuesto(EcatNivelesPuestos nivelPuesto)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_Administracion_SetNivelPuesto");
            sp.NuevoParametro("_RIDNivel", MySqlDbType.Int32, nivelPuesto.RIDNivel);
            sp.NuevoParametro("_Clave", MySqlDbType.VarChar, nivelPuesto.Clave);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, nivelPuesto.Nombre);
            sp.NuevoParametro("_PuestoMando", MySqlDbType.Byte, nivelPuesto.PuestoMando);
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
            sp.NuevoParametro("_PuestoMando", MySqlDbType.Byte, nivelPuesto.PuestoMando);
            return sp;
        }
        #endregion

        #region Catalogo institucional de puestos

        public static ProcedimientoAlmacenado ObtenerPuestosInstitucionales() {
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
            sp.NuevoParametro("_descripcionPuesto", MySqlDbType.VarChar, puestoInstitucional.DescripcionPuesto);
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
            sp.NuevoParametro("_descripcionPuesto", MySqlDbType.VarChar, puestoInstitucional.DescripcionPuesto);
            return sp;
        }

        #endregion

    }
}
