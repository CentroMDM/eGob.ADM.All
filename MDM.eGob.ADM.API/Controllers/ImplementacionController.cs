using System;
using System.Collections.Generic;
using EntitiesPSR;
using DLLImplementacion;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace MDM.eGob.ADM.API.Controllers
{
    [Authorize]
    public class ImplementacionController : ApiController
    {
        [HttpPost]
        public Etimplementacion GetImplementacion()
        {
            try
            {
                return new Implementacion().GetImplementacion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public List<EcatcpEntidadesFederativas> GetImpEntidadesFederativas()
        {
            try
            {
                return new Implementacion().GetImpEntidadesFederativas();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public List<Ecatcpmunicipios> GetImpMunicipios([FromBody] EcatcpEntidadesFederativas entidades)
        {
            try
            {
                return new Implementacion().GetImpMunicipios(entidades);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public List<Ecatcp> ObtenerCodigoPostalMunicipio([FromBody] int municipio)
        {
            try
            {
                return new Implementacion().ObtenerCodigoPostalMunicipio(municipio);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Ecatcp> ObtenerColoniasCP([FromBody] string codigoPostal)
        {
            try
            {
                return new Implementacion().ObtenerColoniasCP(codigoPostal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string CargarImagenImplementacion()
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                if (file != null && (file.ContentType == "image/png" || file.ContentType == "image/svg+xml"))
                {
                    return new Implementacion().CargarImagenImplementacion(file);
                }
                else
                {
                    return "Compruebe el formato de archivo";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado Setimplementacion([FromBody] Etimplementacion implementacion)
        {
            try
            {
                return new Implementacion().Setimplementacion(implementacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public Resultado Updatetimplementacion([FromBody] Etimplementacion implementacion)
        {
            try
            {
                return new Implementacion().Updatetimplementacion(implementacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
