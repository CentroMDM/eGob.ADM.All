using System.Collections.Generic;
using System.Data;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;

namespace BTLConfiguracionPSRV2
{
    public class BTLDias
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
        #region Motivos
        public List<EcatmotivoDiasInhabiles> GetMotivoDiasInhabil()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptDias.GetMotivoDiasInhabil());
            List<EcatmotivoDiasInhabiles> lsResultado = UtilTablas.ConvertirDataTableToList<EcatmotivoDiasInhabiles>(table);
            return lsResultado;
        }

        public Resultado SetMotivoDiasInhabil(EcatmotivoDiasInhabiles diasInhabiles)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_MOTIVODIASINHABILES);
            diasInhabiles.RIDMotivoDias = RIDDefinicion.Item1;
            DataTable table = setIngresar.InsertarRegistro(ScriptDias.SetMotivoDiasInhabil(diasInhabiles));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            resultado.Dato = diasInhabiles.RIDMotivoDias;
            return resultado;
        }

        public Resultado UpdateMotivoDiasInhabil(EcatmotivoDiasInhabiles diasInhabiles)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptDias.UpdateMotivoDiasInhabil(diasInhabiles));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion

        #region cat dias inhabiles
        public List<Ecatdescriptivoitems> GetDescriptivoItems()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptAuxiliares.GetCatalogoItems(CatalogoDescriptivo.APLICA_PARA));
            List<Ecatdescriptivoitems> lsResultado = UtilTablas.ConvertirDataTableToList<Ecatdescriptivoitems>(table);
            return lsResultado;
        }
        public List<EcatdiasInhabiles> GetCatDiasInhabiles()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptDias.GetCatDiasInhabiles());
            List<EcatdiasInhabiles> lsResultado = UtilTablas.ConvertirDataTableToList<EcatdiasInhabiles>(table);
            return lsResultado;
        }
        public Resultado SetCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            Resultado resultado = new Resultado();

            while (catDiasInhabiles.FechaDiaInhabil <= catDiasInhabiles.FechaDiaInhabilFinal)
            {
                if (!((catDiasInhabiles.FechaDiaInhabil.DayOfWeek == System.DayOfWeek.Saturday) ||
                        (catDiasInhabiles.FechaDiaInhabil.DayOfWeek == System.DayOfWeek.Sunday)))
                {
                    (int, string) RIDDefinicion = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_DIASINHABILES);
                    catDiasInhabiles.RIDDiasInhabiles = RIDDefinicion.Item1;


                    DataTable table = setIngresar.InsertarRegistro(ScriptDias.SetCatDiasInhabiles(catDiasInhabiles));
                    resultado = UtilTablas.ResultadoDesdeTabla(table);
                }
                else 
                {
                    resultado.Mensaje = "Sabados y domingos";
                    resultado.DetalleErrorSql="no fueron registrados";
                }
                catDiasInhabiles.FechaDiaInhabil = catDiasInhabiles.FechaDiaInhabil.AddDays(1);
            }

            return resultado;
        }
        public Resultado UpdateCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptDias.UpdateCatDiasInhabiles(catDiasInhabiles));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public Resultado DeleteCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            DAOUpdateorDeleteObjetosNegocio updateDefinicion = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateDefinicion.UpdateOrDeleteRegistro(ScriptDias.DeleteCatDiasInhabiles(catDiasInhabiles));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        #endregion

    }
}
