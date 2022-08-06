using System.Collections.Generic;
using System.Data;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;

namespace BTLConfiguracionPSRV2
{
    public class BTLAuxiliares
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

        public List<Ecatdescriptivoitems> ObtenerItemsCatalogoDescriptivo(CatalogoDescriptivo catalogoDescriptivo) {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptAuxiliares.GetCatalogoItems(catalogoDescriptivo));
            List<Ecatdescriptivoitems> lsResultado = UtilTablas.ConvertirDataTableToList<Ecatdescriptivoitems>(table);
            return lsResultado;
        }

        public (Etcasocformatos, List<Etcasoscformatoseccion>, List<EAuxPreviewFormatos>) GetPreview(int RIDFormato) {
            DAOGetObjetosNegocio dao = new DAOGetObjetosNegocio();
            ProcedimientoAlmacenado sp = ScriptAuxiliares.GetVistaPrevia(RIDFormato);
            DataSet dataSet = dao.ObtenerConsultaDataSet(sp);
            Etcasocformatos formatos = UtilTablas.ConvertirDataTableToList<Etcasocformatos>(dataSet.Tables[0])[0];
            List<Etcasoscformatoseccion> secciones = UtilTablas.ConvertirDataTableToList<Etcasoscformatoseccion>(dataSet.Tables[1]);
            List<EAuxPreviewFormatos> variables = UtilTablas.ConvertirDataTableToList<EAuxPreviewFormatos>(dataSet.Tables[2]);
            return (formatos, secciones, variables);
        }

    }
}
