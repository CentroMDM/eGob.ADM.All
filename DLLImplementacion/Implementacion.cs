using System;
using System.Collections.Generic;
using System.Data;
using EntitiesPSR;
using DLLUtilerias;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DLLImplementacion
{
    public class Implementacion
    {
        public Etimplementacion GetImplementacion()
        {
            DatosImplementacion obtenerParametros = new DatosImplementacion();
            DataTable dtImplementacion = obtenerParametros.GetImplementacion();
            List<Etimplementacion> lsResultado = new Utilerias().Convertir<Etimplementacion>(dtImplementacion);
            Etimplementacion implementacion = null;
            if (lsResultado.Count != 0)
            {
                implementacion = lsResultado[0];
            }
            else
            {
                implementacion = new Etimplementacion();
            }
            dtImplementacion = obtenerParametros.GetNiveldeGobierno();
            List<EcatNivelGobierno> lsCatalogoNivelGobierno = new Utilerias().Convertir<EcatNivelGobierno>(dtImplementacion);            
            implementacion.NivelesGobierno = lsCatalogoNivelGobierno;

            dtImplementacion = obtenerParametros.GetCatAplicaciones();
            List<Ecataplicaciones> lsCatalogoAplicacion = new Utilerias().Convertir<Ecataplicaciones>(dtImplementacion);
            implementacion.Aplicaciones = lsCatalogoAplicacion;
            return implementacion;
        }
        public List<EcatcpEntidadesFederativas> GetImpEntidadesFederativas()
        {
            DatosImplementacion obtenerParametros = new DatosImplementacion();
            DataTable dtEntidadFederativa = obtenerParametros.GetImpEntidadesFederativas();
            List<EcatcpEntidadesFederativas> lsEntidadFederativa = new Utilerias().Convertir<EcatcpEntidadesFederativas>(dtEntidadFederativa);
            return lsEntidadFederativa;
        }
        public List<Ecatcpmunicipios> GetImpMunicipios(EcatcpEntidadesFederativas entidades)
        {
            DatosImplementacion obtenerParametros = new DatosImplementacion();
            DataTable dtMunicipios = obtenerParametros.GetImpMunicipios(entidades);
            List<Ecatcpmunicipios> lsMunicipio = new Utilerias().Convertir<Ecatcpmunicipios>(dtMunicipios);
            return lsMunicipio;
        }
        public List<Ecatcp> ObtenerCodigoPostalMunicipio(int municipio)
        {
            DatosImplementacion obtenerParametros = new DatosImplementacion();
            DataTable dtCodigoPostal = obtenerParametros.ObtenerCodigoPostalMunicipio(municipio);
            List<Ecatcp> lsCodigoPostal = new Utilerias().Convertir<Ecatcp>(dtCodigoPostal);
            return lsCodigoPostal;
        }
        public List<Ecatcp> ObtenerColoniasCP(string codigoPostal)
        {
            DatosImplementacion obtenerParametros = new DatosImplementacion();
            DataTable dtColonias = obtenerParametros.ObtenerColoniasCP(codigoPostal);
            List<Ecatcp> lsColonias = new Utilerias().Convertir<Ecatcp>(dtColonias);
            return lsColonias;
        }
        public string CargarImagenImplementacion(HttpPostedFile file)
        {
            DatosImplementacion guardaArchivo = new DatosImplementacion();
            DataTable tablaParametros = guardaArchivo.CargarImagenImplementacion();
            DataRow[] drDirectorioFotosEmpleado = tablaParametros.Select("RIDDirectorio=201");
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
        public Resultado Setimplementacion(Etimplementacion implementacion)
        {
            DatosImplementacion obtenerParametros = new DatosImplementacion();
            DataTable dtImplementacion = obtenerParametros.Setimplementacion(implementacion);
            Resultado lsImplementacion = new Utilerias().ResultadoDesdeTabla(dtImplementacion);
            return lsImplementacion;
        }
        public Resultado Updatetimplementacion(Etimplementacion implementacion)
        {
            DatosImplementacion obtenerParametros = new DatosImplementacion();
            DataTable dtImplementacion = obtenerParametros.Updatetimplementacion(implementacion);
            Resultado lsImplementacion = new Utilerias().ResultadoDesdeTabla(dtImplementacion);
            return lsImplementacion;
        }
    }
}
