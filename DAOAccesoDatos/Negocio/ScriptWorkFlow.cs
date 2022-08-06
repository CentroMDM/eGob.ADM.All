using EntitiesPSR;
using MySql.Data.MySqlClient;

namespace DAOAccesoDatos
{
    public static class ScriptWorkFlow
    {
        #region Definicion
        public static ProcedimientoAlmacenado GetWorkFlowDefinicion()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Getworkflowdefinicion");
            return sp;
        }

        public static ProcedimientoAlmacenado SetWorkFlowDefinicion(Eworkflowdefinicion workFlowDefinicion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Setworkflowdefinicion");
            sp.NuevoParametro("_RIDWorkFlow", MySqlDbType.Int32, workFlowDefinicion.RIDWorkFlow);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, workFlowDefinicion.Nombre);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, workFlowDefinicion.Descripcion);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateWorkFlowDefinicion(Eworkflowdefinicion workFlowDefinicion)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Updateworkflowdefinicion");
            sp.NuevoParametro("_RIDWorkFlow", MySqlDbType.Int32, workFlowDefinicion.RIDWorkFlow);
            sp.NuevoParametro("_Nombre", MySqlDbType.VarChar, workFlowDefinicion.Nombre);
            sp.NuevoParametro("_Descripcion", MySqlDbType.VarChar, workFlowDefinicion.Descripcion);
            return sp;
        }
        #endregion

        #region procesos

        public static ProcedimientoAlmacenado GetWorkFlowProcesos()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Getwfprocesos");
            return sp;
        }

        public static ProcedimientoAlmacenado SetWorkFlowProceso(Ewfprocesos procesos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Setwfprocesos");
            sp.NuevoParametro("_ClaveWorkFlow", MySqlDbType.Int32, procesos.WorkFlowDefinicion.RIDWorkFlow);
            sp.NuevoParametro("_ClaveProcesoPadre", MySqlDbType.Int32, procesos.ProcesoPrincipal.RIDProceso);
            sp.NuevoParametro("_RIDProceso", MySqlDbType.Int32, procesos.RIDProceso);
            sp.NuevoParametro("_NombreProcesoInterno", MySqlDbType.VarChar, procesos.NombreProcesoInterno);
            sp.NuevoParametro("_DescripcionProcesoIntarno", MySqlDbType.VarChar, procesos.DescripcionProcesoIntarno);
            sp.NuevoParametro("_NombreProcesoExterno", MySqlDbType.VarChar, procesos.NombreProcesoExterno);
            sp.NuevoParametro("_DescripcionProcesoExterna", MySqlDbType.VarChar, procesos.DescripcionProcesoExterna);
            sp.NuevoParametro("_OrdenEjecucion", MySqlDbType.Int32, procesos.OrdenEjecucion);
            sp.NuevoParametro("_EjecucionObligatoria", MySqlDbType.Byte, procesos.EjecucionObligatoria);
            sp.NuevoParametro("_ProcesoRepetitivo", MySqlDbType.Byte, procesos.ProcesoRepetitivo);
            sp.NuevoParametro("_LimiteIteraciones", MySqlDbType.Int32, procesos.LimiteIteraciones);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateWorkFlowProceso(Ewfprocesos procesos)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Updatewfprocesos");
            sp.NuevoParametro("_ClaveWorkFlow", MySqlDbType.Int32, procesos.WorkFlowDefinicion.RIDWorkFlow);
            sp.NuevoParametro("_ClaveProcesoPadre", MySqlDbType.Int32, procesos.ProcesoPrincipal.RIDProceso);
            sp.NuevoParametro("_RIDProceso", MySqlDbType.Int32, procesos.RIDProceso);
            sp.NuevoParametro("_NombreProcesoInterno", MySqlDbType.VarChar, procesos.NombreProcesoInterno);
            sp.NuevoParametro("_DescripcionProcesoIntarno", MySqlDbType.VarChar, procesos.DescripcionProcesoIntarno);
            sp.NuevoParametro("_NombreProcesoExterno", MySqlDbType.VarChar, procesos.NombreProcesoExterno);
            sp.NuevoParametro("_DescripcionProcesoExterna", MySqlDbType.VarChar, procesos.DescripcionProcesoExterna);
            sp.NuevoParametro("_OrdenEjecucion", MySqlDbType.Int32, procesos.OrdenEjecucion);
            sp.NuevoParametro("_EjecucionObligatoria", MySqlDbType.Byte, procesos.EjecucionObligatoria);
            sp.NuevoParametro("_ProcesoRepetitivo", MySqlDbType.Byte, procesos.ProcesoRepetitivo);
            sp.NuevoParametro("_LimiteIteraciones", MySqlDbType.Int32, procesos.LimiteIteraciones);
            return sp;
        }

        #endregion

        #region Etapas
        public static ProcedimientoAlmacenado GetWorkFlowProcesosEtapas()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Getwfprocesosetapas");
            return sp;
        }

        public static ProcedimientoAlmacenado SetWorkFlowProcesosEtapas(Ewfprocesosetapas procesosEtapas)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Setwfprocesosetapas");
            sp.NuevoParametro("_ClaveProceso", MySqlDbType.Int32, procesosEtapas.Proceso.RIDProceso);
            sp.NuevoParametro("_RIDEtapa", MySqlDbType.Int32, procesosEtapas.RIDEtapa);
            sp.NuevoParametro("_NombreEtapaInterno", MySqlDbType.VarChar, procesosEtapas.NombreEtapaInterno);
            sp.NuevoParametro("_DescripcionEtapaIntarno", MySqlDbType.VarChar, procesosEtapas.DescripcionEtapaIntarno);
            sp.NuevoParametro("_NombreEtapaExterno", MySqlDbType.VarChar, procesosEtapas.NombreEtapaExterno);
            sp.NuevoParametro("_DescripcionEtapaExterna", MySqlDbType.VarChar, procesosEtapas.DescripcionEtapaExterna);
            sp.NuevoParametro("_ClaveAccion", MySqlDbType.Int32, procesosEtapas.Accion.RIDAccion);
            sp.NuevoParametro("_OrdenEjecucion", MySqlDbType.Int32, procesosEtapas.OrdenEjecucion);
            sp.NuevoParametro("_EjecucionObligatoria", MySqlDbType.Byte, procesosEtapas.EjecucionObligatoria);
            return sp;
        }

        public static ProcedimientoAlmacenado UpdateWorkProcesosEtapas(Ewfprocesosetapas procesosEtapas)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Updatewfprocesosetapas");
            sp.NuevoParametro("_ClaveProceso", MySqlDbType.Int32, procesosEtapas.Proceso.RIDProceso);
            sp.NuevoParametro("_RIDEtapa", MySqlDbType.Int32, procesosEtapas.RIDEtapa);
            sp.NuevoParametro("_NombreEtapaInterno", MySqlDbType.VarChar, procesosEtapas.NombreEtapaInterno);
            sp.NuevoParametro("_DescripcionEtapaIntarno", MySqlDbType.VarChar, procesosEtapas.DescripcionEtapaIntarno);
            sp.NuevoParametro("_NombreEtapaExterno", MySqlDbType.VarChar, procesosEtapas.NombreEtapaExterno);
            sp.NuevoParametro("_DescripcionEtapaExterna", MySqlDbType.VarChar, procesosEtapas.DescripcionEtapaExterna);
            sp.NuevoParametro("_ClaveAccion", MySqlDbType.Int32, procesosEtapas.Accion.RIDAccion);
            sp.NuevoParametro("_OrdenEjecucion", MySqlDbType.Int32, procesosEtapas.OrdenEjecucion);
            sp.NuevoParametro("_EjecucionObligatoria", MySqlDbType.Byte, procesosEtapas.EjecucionObligatoria);
            return sp;
        }
        #endregion

        #region Acciones
        public static ProcedimientoAlmacenado GetwfCatAcciones() {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado("SP_workflow_Getwfcatacciones");
            return sp;
        }
        #endregion
    }
}
