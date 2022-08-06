using DAOAccesoDatos;
using EntitiesPSR;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utilerias;

namespace BTLConfiguracionPSRV2.NegocioUnidadAdministrativa
{
    public class BTLClasificacionSujetos
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

        #region Clasificación sujetos
        public List<EcatTipoSujetosObjetos> ObtenerConsultaTipoSujetosObjetos()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptClasificacionSujetos.ObtenerTipoSujetosObjetos());
            List<EcatTipoSujetosObjetos> lsResultado = UtilTablas.ConvertirDataTableToList<EcatTipoSujetosObjetos>(table);
            return lsResultado;
        }

        public List<EConsultaObjetosClasificados> ObtenerObjetosClasificados(EtcatAgrupadoresClasificadores objetoNegocioFiltro)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptClasificacionSujetos.ObtenerObjetosClasificados(objetoNegocioFiltro));
            List<EConsultaObjetosClasificados> lsResultado = UtilTablas.ConvertirDataTableToList<EConsultaObjetosClasificados>(table);
            return lsResultado;
        }

        public Resultado EliminarClasificacion(EConsultaObjetosClasificados objetoNegocio)
        {
            DAOUpdateorDeleteObjetosNegocio EliminarRegistro = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = EliminarRegistro.UpdateOrDeleteRegistro(ScriptClasificacionSujetos.EliminaClasificacion(objetoNegocio));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }



        public Resultado IngresarTipoSujetosObjeto(EcatTipoSujetosObjetos catTipoSujetoObjeto)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            //(int, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_NIVELESPUESTOS);
            int param1;
            string param2;
            (param1, param2) = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TCAT_TIPOSUJETOOBJETO);
            catTipoSujetoObjeto.RIDItemCatalogo = param1;
            //catAgrupador = param2;
            DataTable table = setIngresar.InsertarRegistro(ScriptClasificacionSujetos.InsertarTipoSujetoObjeto(catTipoSujetoObjeto));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado ClasificaSujetouObjeto(HttpPostedFileBase file, string ClveSujetoObjeto,string ClaveClasificacion)
        {
            if (file != null)
            {
                StreamReader srReadFile = new StreamReader(file.InputStream);
                if (!srReadFile.EndOfStream)
                {
                    DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
                    //(int, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_NIVELESPUESTOS);
                    while (!srReadFile.EndOfStream)
                    {
                        //int param1;
                        //string param2;
                        //(param1, param2) = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TCLASIFICACIONSUJETOS);
                        EClasificacionSujetoObjeto ClasificadorSujeto = new EClasificacionSujetoObjeto();

                        string strRegistro = srReadFile.ReadLine();

                        ClasificadorSujeto.ClaveSujetoObjeto = int.Parse(ClveSujetoObjeto);
                        ClasificadorSujeto.ClaveClasificador = int.Parse(ClaveClasificacion);
                        ClasificadorSujeto.ClaveObjeto = strRegistro;

                        DataTable table = setIngresar.InsertarRegistro(ScriptClasificacionSujetos.InsertarClasificacionSujetoObjeto(ClasificadorSujeto));
                    }
                    Resultado resultado = new Resultado();
                    resultado.ClaveStatus = 1;
                    resultado.DetalleDeError = "";
                    return resultado;
                }

            }

            Resultado resultadoF = new Resultado();
            resultadoF.ClaveStatus = 0;
            resultadoF.DetalleDeError = "No se recibió el archivo para la clasificación masiva.";

            return resultadoF;

        }


        public Resultado ClasificaSujetouObjeto(EClasificacionSujetoObjeto objetoNegocio)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            DataTable table = setIngresar.InsertarRegistro(ScriptClasificacionSujetos.InsertarClasificacionSujetoObjeto(objetoNegocio));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }





        public List<EtcatAgrupadoresClasificadores> ConsultarClasificadoresGrupo(EtcatAgrupadores grupo)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptClasificacionSujetos.ConsultarClasificadoresGrupo(grupo));
            List<EtcatAgrupadoresClasificadores> lsResultado = UtilTablas.ConvertirDataTableToList<EtcatAgrupadoresClasificadores>(table);
            return lsResultado;
        }

        public List<EtcatAgrupadores> consultaAgrupadores()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptAgrupadores.consultaAgrupadores());
            List<EtcatAgrupadores> lsResultado = UtilTablas.ConvertirDataTableToList<EtcatAgrupadores>(table);
            return lsResultado;
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
