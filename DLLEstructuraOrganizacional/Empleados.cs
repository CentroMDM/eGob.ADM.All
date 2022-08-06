using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesPSR;
using DLLUtilerias;

namespace DLLEstructuraOrganizacional
{
    public class Empleados
    {
        public List<Etempleados> ObtenerEmpleado()
        {
            DatosEO Empleado = new DatosEO();
            DataTable dtEmpleados = Empleado.ObtenerEmpleado();
            List<Etempleados> lsEmpleados = new Utilerias().Convertir<Etempleados>(dtEmpleados);
            return lsEmpleados;
        }
        public string RFCDisponibleEmpleadoNew(string RFCEmp)
        {
            DatosEO RFCE = new DatosEO();
            DataTable dtRFCE = RFCE.RFCDisponibleEmpleadoNew(RFCEmp);
            string lsRFCE = "0";
            if (dtRFCE.Rows.Count > 0)
            {
                lsRFCE = dtRFCE.Rows[0][0].ToString();
            }
            return lsRFCE;
        }
        public string RFCDisponibleEmpleado(Etempleados RFCEmp)
        {
            DatosEO RFCE = new DatosEO();
            DataTable dtRFCE = RFCE.RFCDisponibleEmpleado(RFCEmp);
            string lsRFCE = "0";
            if (dtRFCE.Rows.Count > 0)
            {
                lsRFCE = dtRFCE.Rows[0][0].ToString();
            }
            return lsRFCE;
        }
        public string ObtenerClaveEmpleadoNew(string numeroNuevo)
        {
            DatosEO obtenerClaveEmpleado = new DatosEO();
            DataTable dtClaves = obtenerClaveEmpleado.ObtenerClaveEmpleadoNew(numeroNuevo);
            string lsClaves = "0";
            if (dtClaves.Rows.Count > 0)
            {
                lsClaves = dtClaves.Rows[0][0].ToString();
            }
            return lsClaves;
        }
        public string ObtenerClaveEmpleado(Etempleados numeroNuevo)
        {
            DatosEO obtenerClaveEmpleado = new DatosEO();
            DataTable dtClaves = obtenerClaveEmpleado.ObtenerClaveEmpleado(numeroNuevo);
            string lsClaves = "0";
            if (dtClaves.Rows.Count > 0)
            {
                lsClaves = dtClaves.Rows[0][0].ToString();
            }
            return lsClaves;
        }
        public List<Etempleados> ObtenerEmpleadosXUnidad(int RIDUnidad)
        {
            DatosEO obtenerEmpleadoXU = new DatosEO();
            DataTable dtEmpleados = obtenerEmpleadoXU.ObtenerEmpleadosXUnidad(RIDUnidad);
            //List<Etempleados> lsEmpleadoXU = UtilTablas.ConvertirDataTableToList<Etempleados>(dtEmpleados);
            List<Etempleados> lsEmpleadoXU = new Utilerias().Convertir<Etempleados>(dtEmpleados);
            return lsEmpleadoXU;
        }
        public List<Etempleados> ObtenerEmpleadosXPuesto(int RIDPuesto)
        {
            DatosEO obtenerEmpleadoXP = new DatosEO();
            DataTable dtEmpleados = obtenerEmpleadoXP.ObtenerEmpleadosXPuesto(RIDPuesto);
            List<Etempleados> lsEmpleadoXP = new Utilerias().Convertir<Etempleados>(dtEmpleados);
            return lsEmpleadoXP;
        }
        public string CargarImagenEmpleados(HttpPostedFile file)
        {
            DatosEO guardaArchivo = new DatosEO();
            DataTable tablaParametros = guardaArchivo.CargarImagenEmpleado();
            DataRow[] drDirectorioFotosEmpleado = tablaParametros.Select("RIDDirectorio=203");
            if (drDirectorioFotosEmpleado.Length > 0)
            {
                Utilerias upimg = new Utilerias();
                string directorioVirtual = drDirectorioFotosEmpleado[0]["DirectorioVirtualExterno"].ToString() + upimg.guardarImagen(drDirectorioFotosEmpleado[0]["DirectorioFisicoInterno"].ToString(), file);
                return directorioVirtual;
            }
            else
            {
                return "No se pudo obtener los parámetros del servidor.";
            }
        }
        public Resultado IngresarEmpleado(Etempleados templeados)
        {
            DatosEO ingresarEmpleado = new DatosEO();
            int param1;
            string param2;
            (param1, param2) = ingresarEmpleado.ObtenerIdentificadoresPSR(TablasAdministracion.TEMPLEADOS);
            templeados.RIDEmpleado = param1;
            templeados.BOIDEmpleado = param2;
            DataTable dtEmpleado = ingresarEmpleado.IngresarEmpleado(templeados);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtEmpleado);
            return resultado;
        }
        public Resultado ActualizarEmpleado(Etempleados empleado)
        {
            DatosEO updateEmpleado = new DatosEO();
            DataTable dtEmpleado = updateEmpleado.ActualizarEmpleado(empleado);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtEmpleado);
            return resultado;
        }
        public Resultado EliminarEmpleado(Etempleados empleado)
        {
            DatosEO delEmpleado = new DatosEO();
            DataTable dtEmpleado = delEmpleado.EliminarEmpleado(empleado);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtEmpleado);
            return resultado;
        }
    }
}
