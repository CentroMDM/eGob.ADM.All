using System;
using System.Collections.Generic;
using EntitiesPSR;
using DLLImplementacion;
using System.Web.Http;
using System.Web;
using BTLConfiguracionPSRV2;

namespace MDM.eGob.ADM.API.Controllers
{
    [Authorize]
    public class ConfiguracionController : ApiController
    {
        #region Implementacion
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
        #endregion

        #region Días Inhábiles
        [HttpPost]
        public List<Ecatdescriptivoitems> GetDescriptivoItems()
        {
            try
            {
                return new BTLDias().GetDescriptivoItems();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<EcatdiasInhabiles> GetCatDiasInhabiles()
        {
            try
            {
                return new BTLDias().GetCatDiasInhabiles();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public Resultado DeleteCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            try
            {
                return new BTLDias().DeleteCatDiasInhabiles(catDiasInhabiles);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public Resultado SetCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            try
            {
                return new BTLDias().SetCatDiasInhabiles(catDiasInhabiles);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public Resultado UpdateCatDiasInhabiles(EcatdiasInhabiles catDiasInhabiles)
        {
            try
            {
                return new BTLDias().UpdateCatDiasInhabiles(catDiasInhabiles);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Motivos
        [HttpPost]
        public List<EcatmotivoDiasInhabiles> GetMotivoDiasInhabil()
        {
            try
            {
                return new BTLDias().GetMotivoDiasInhabil();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public Resultado SetMotivoDiasInhabil(EcatmotivoDiasInhabiles diasInhabiles)
        {
            try
            {
                return new BTLDias().SetMotivoDiasInhabil(diasInhabiles);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [HttpPost]
        public Resultado UpdateMotivoDiasInhabil(EcatmotivoDiasInhabiles diasInhabiles)
        {
            try
            {
                return new BTLDias().UpdateMotivoDiasInhabil(diasInhabiles);
            }
            catch (Exception e)
            {
                throw e;
            }
        }        
        #endregion
    }
}
