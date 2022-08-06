using System.Collections.Generic;
using System.Data;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;

namespace BTLConfiguracionPSRV2
{
    public class BTLWorkFlow
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
        #region Definicion
        public List<Eworkflowdefinicion> GetWorkFlowDefinicion()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptWorkFlow.GetWorkFlowDefinicion());
            List<Eworkflowdefinicion> lsResultado = UtilTablas.ConvertirDataTableToList<Eworkflowdefinicion>(table);
            return lsResultado;
        }

        public Resultado SetWorkFlowDefinicion(Eworkflowdefinicion definicion)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.WORKFLOWDEFINICION);
            definicion.RIDWorkFlow = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptWorkFlow.SetWorkFlowDefinicion(definicion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            resultado.Dato = definicion.RIDWorkFlow;
            return resultado;
        }

        public Resultado UpdateWorkFlowDefinicion(Eworkflowdefinicion definicion)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptWorkFlow.UpdateWorkFlowDefinicion(definicion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion

        #region Procesos


        public List<Ewfprocesos> GetWorkFlowProceso()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptWorkFlow.GetWorkFlowProcesos());
            List<Ewfprocesos> lsResultado = UtilTablas.ConvertirDataTableToList<Ewfprocesos>(table);
            Ewfprocesos procesoInicial = new Ewfprocesos
            {
                RIDProceso = 0,
                NombreProcesoExterno = "Proceso Inicial"
            };
            lsResultado.Insert(0, procesoInicial);
            //Obtenemos las definiciones
            List<Eworkflowdefinicion> lsDefiniciones = GetWorkFlowDefinicion();
            foreach (Ewfprocesos proceso in lsResultado)
            {
                foreach (Eworkflowdefinicion definicion in lsDefiniciones)
                {
                    if (proceso.ClaveWorkFlow == definicion.RIDWorkFlow)
                    {
                        proceso.WorkFlowDefinicion = definicion;
                        break;
                    }
                }
            }
            //Obtenemos los procesos padre
            List<Ewfprocesos> lsAux = GenericCopier<List<Ewfprocesos>>.DeepCopy(lsResultado);
            foreach (Ewfprocesos proceso in lsResultado)
            {
                foreach (Ewfprocesos aux in lsAux)
                {
                    if (proceso.ClaveProcesoPadre == aux.RIDProceso)
                    {
                        proceso.ProcesoPrincipal = aux;
                        break;
                    }
                }
            }
            return lsResultado;
        }

        public Resultado SetWorkFlowProceso(Ewfprocesos definicion)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.WORKFLOWPROCESOS);
            definicion.RIDProceso = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptWorkFlow.SetWorkFlowProceso(definicion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            resultado.Dato = definicion.RIDProceso;
            return resultado;
        }

        public Resultado UpdateWorkFlowProceso(Ewfprocesos definicion)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptWorkFlow.UpdateWorkFlowProceso(definicion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion

        #region CatalogoAcciones
        public List<Ecatacciones> GetwfCatAcciones()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptWorkFlow.GetwfCatAcciones());
            List<Ecatacciones> lsResultado = UtilTablas.ConvertirDataTableToList<Ecatacciones>(table);
            return lsResultado;
        }

        #endregion

        #region ProcesoEtapas

        public List<Ewfprocesosetapas> GetWorkFlowProcesosEtapas()
        {
            List<Ewfprocesos> procesos = GetWorkFlowProceso();
            List<Ecatacciones> acciones = GetwfCatAcciones();
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptWorkFlow.GetWorkFlowProcesosEtapas());
            List<Ewfprocesosetapas> lsResultado = UtilTablas.ConvertirDataTableToList<Ewfprocesosetapas>(table);
            foreach (Ewfprocesosetapas procesoEtapa in lsResultado)
            {
                foreach (Ecatacciones accion in acciones)
                {
                    if (procesoEtapa.ClaveAccion == accion.RIDAccion)
                    {
                        procesoEtapa.Accion = accion;
                    }
                }
            }
            foreach (Ewfprocesosetapas procesoEtapa in lsResultado)
            {
                foreach (Ewfprocesos proceso in procesos)
                {
                    if (procesoEtapa.ClaveProceso == proceso.RIDProceso)
                    {
                        procesoEtapa.Proceso = proceso;
                    }
                }
            }
            return lsResultado;
        }


        public Resultado SetWorkFlowProcesosEtapas(Ewfprocesosetapas procesoEtapas)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.WORKFLOWPROCESOSETAPAS);
            procesoEtapas.RIDEtapa = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptWorkFlow.SetWorkFlowProcesosEtapas(procesoEtapas));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado UpdateWorkProcesosEtapas(Ewfprocesosetapas procesoEtapas)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptWorkFlow.UpdateWorkProcesosEtapas(procesoEtapas));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        #endregion

    }
}
