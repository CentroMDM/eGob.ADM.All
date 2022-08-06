using System.Collections.Generic;
using System.Data;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;

namespace BTLConfiguracionPSRV2
{
    public class BTLPuestos
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

        #region niveles de mando
        public List<EcatNivelesPuestos> ObtenerNivelesPuestosInstitucionales()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptPuestos.ObtenerNivelPuesto());
            List<EcatNivelesPuestos> lsResultado = UtilTablas.ConvertirDataTableToList<EcatNivelesPuestos>(table);
            return lsResultado;
        }

        public Resultado InsertarNivelPuesto(EcatNivelesPuestos catPuestos)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            //(int, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_NIVELESPUESTOS);
            int param1;
            string param2;
            (param1, param2) = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_NIVELESPUESTOS);
            catPuestos.RIDNivel = param1;
            catPuestos.BOIDNivel = param2;
            DataTable table = setIngresar.InsertarRegistro(ScriptPuestos.InsertarNivelPuesto(catPuestos));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado EliminarNivelPuestoInstitucional(EcatNivelesPuestos puesto)
        {
            DAOUpdateorDeleteObjetosNegocio updateorDeleteObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateorDeleteObjetosNegocio.UpdateOrDeleteRegistro(ScriptPuestos.EliminarNivelPuesto(puesto));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado ActualizarNivelPuesto(EcatNivelesPuestos puesto)
        {
            DAOUpdateorDeleteObjetosNegocio updateorDeleteObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateorDeleteObjetosNegocio.UpdateOrDeleteRegistro(ScriptPuestos.ActualizarNivelPuesto(puesto));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion

        #region Puestos institucionales
        public List<EtcatPuestos> ObtenerPuestosInstitucionales()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptPuestos.ObtenerPuestosInstitucionales());
            List<EtcatPuestos> lsResultado = UtilTablas.ConvertirDataTableToList<EtcatPuestos>(table);
            return lsResultado;
        }
        public Resultado IngresarPuestoInstitucional(EtcatPuestos puestoInstitucional)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_PUESTOS);
            puestoInstitucional.RIDPuestos = identificadores.Item1;
            puestoInstitucional.BOIDPuesto = identificadores.Item2;
            DataTable table = setIngresar.InsertarRegistro(ScriptPuestos.IngresarPuestoInstitucional(puestoInstitucional));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado EliminarPuestoInstitucional(EtcatPuestos puestoInstitucional)
        {
            DAOUpdateorDeleteObjetosNegocio updateorDeleteObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateorDeleteObjetosNegocio.UpdateOrDeleteRegistro(ScriptPuestos.EliminarPuestoInstitucional(puestoInstitucional));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado ActualizarPuestoInstitucional(EtcatPuestos puestoInstitucional)
        {
            DAOUpdateorDeleteObjetosNegocio updateorDeleteObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateorDeleteObjetosNegocio.UpdateOrDeleteRegistro(ScriptPuestos.ActualizarPuestoInstitucional(puestoInstitucional));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion 

    }
}
