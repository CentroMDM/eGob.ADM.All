using System.Data;


namespace Utilerias
{
    public static class UtilGenerarTablas
    {
        public static DataTable GetTablaResultado()
        {
            DataTable dtRespuesta = new DataTable();
            dtRespuesta.Columns.Add(new DataColumn("ExisteError", typeof(bool)));
            dtRespuesta.Columns.Add(new DataColumn("DetalleDeError", typeof(string)));
            dtRespuesta.Columns.Add(new DataColumn("ComandoEjecutado", typeof(string)));
            dtRespuesta.Columns.Add(new DataColumn("Dato", typeof(object)));
            dtRespuesta.Columns.Add(new DataColumn("Dato2", typeof(object)));
            dtRespuesta.Columns.Add(new DataColumn("DetalleErrorSql", typeof(string)));
            dtRespuesta.Columns.Add(new DataColumn("Mensaje", typeof(string)));
            dtRespuesta.Columns.Add(new DataColumn("Proceso", typeof(long)));
            return dtRespuesta;
        }

    }
}
