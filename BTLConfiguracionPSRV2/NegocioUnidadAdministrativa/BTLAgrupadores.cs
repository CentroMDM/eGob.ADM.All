using DAOAccesoDatos;
using EntitiesPSR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilerias;

namespace BTLConfiguracionPSRV2.NegocioUnidadAdministrativa
{
    public class BTLAgrupadores
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
        public List<EtcatAgrupadoresClasificadores> ObtenerConsultaAgrupadoresClasificadores()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptAgrupadores.ObtenerAgrupadoresClasificadores());
            List<EtcatAgrupadoresClasificadores> lsResultado = UtilTablas.ConvertirDataTableToList<EtcatAgrupadoresClasificadores>(table);
            return lsResultado;
        }

        public List<EtcatAgrupadores> consultaAgrupadores()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptAgrupadores.consultaAgrupadores());
            List<EtcatAgrupadores> lsResultado = UtilTablas.ConvertirDataTableToList<EtcatAgrupadores>(table);
            return lsResultado;
        }

        public Resultado IngresarAgrupador(EtcatAgrupadores catAgrupador)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            //(int, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_NIVELESPUESTOS);
            int param1;
            string param2;
            (param1, param2) = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_AGRUPADORES);
            catAgrupador.RIDAgrupador = param1;
            //catAgrupador = param2;
            DataTable table = setIngresar.InsertarRegistro(ScriptAgrupadores.InsertarAgrupador(catAgrupador));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }


        public Resultado IngresarClasificador(EtcatClasificadores catClasificador)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            //(int, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_NIVELESPUESTOS);
            int param1;
            string param2;
            (param1, param2) = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_CLASIFICADORES);
            catClasificador.RIDClasificador = param1;
            //catAgrupador = param2;
            DataTable table = setIngresar.InsertarRegistro(ScriptAgrupadores.InsertarClasificador(catClasificador));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado ActuaizarClasificador(EtcatClasificadores catClasificador)
        {
            DAOUpdateorDeleteObjetosNegocio updateRegistro = new DAOUpdateorDeleteObjetosNegocio();

            DataTable table = updateRegistro.UpdateOrDeleteRegistro(ScriptAgrupadores.ActuaizarClasificador(catClasificador));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }


        public Resultado EliminarClasificador(EtcatClasificadores catClasificador)
        {
            DAOUpdateorDeleteObjetosNegocio delRegistro = new DAOUpdateorDeleteObjetosNegocio();
            
            DataTable table = delRegistro.UpdateOrDeleteRegistro(ScriptAgrupadores.EliminarClasificador(catClasificador));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public DataTable ObtenerParametros()
        {
            DataTable tablaParametros = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerParametros());
            return tablaParametros;
        }

       
        #endregion 

    }
}
