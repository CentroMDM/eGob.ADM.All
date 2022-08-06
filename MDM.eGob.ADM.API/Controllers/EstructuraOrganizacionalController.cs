using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EntitiesPSR;
using BTLConfiguracionPSRV2;
using System.Reflection;
using DLLEstructuraOrganizacional;

namespace MDM.eGob.ADM.API.Controllers
{
    [Authorize]
    public class EstructuraOrganizacionalController : ApiController
    {
        #region Niveles de Mando
        [HttpPost]
        public List<EcatNivelesPuestos> ObtenerNivelPuestoInstitucional()
        {
            try
            {
                return new NivelesMando().ObtenerNivelesPuestosInstitucionales();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<EcatNivelesPuestos> ObtenerNivelXPuesto([FromBody] int RIDPuesto)
        {
            try
            {
                return new NivelesMando().ObtenerNivelXPuesto(RIDPuesto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado IngresarNivelesPuesto([FromBody] EcatNivelesPuestos catNivelPuestos)
        {
            try
            {
                return new NivelesMando().InsertarNivelPuesto(catNivelPuestos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado ActualizarNivelesPuesto([FromBody] EcatNivelesPuestos catNivelPuestos)
        {
            try
            {
                return new NivelesMando().ActualizarNivelPuesto(catNivelPuestos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado EliminarNivelesPuesto([FromBody] EcatNivelesPuestos catNivelPuestos)
        {
            try
            {
                return new NivelesMando().EliminarNivelPuesto(catNivelPuestos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Puestos Institucionales
        [HttpPost]
        public List<EtcatPuestos> ConsultaPuesto()
        {
            try
            {
                return new PuestosInstitucionales().ConsultaPuesto();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<EtcatPuestos> ObtenerPuestosXUnidad([FromBody] int RIDUnidad)
        {
            try
            {
                return new PuestosInstitucionales().ObtenerPuestosXUnidad(RIDUnidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado IngresarPuesto([FromBody] EtcatPuestos catNivelPuestos)
        {
            try
            {
                return new PuestosInstitucionales().IngresarPuesto(catNivelPuestos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado ActualizarPuesto([FromBody] EtcatPuestos catNivelPuestos)
        {
            try
            {
                return new PuestosInstitucionales().ActualizarPuesto(catNivelPuestos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado EliminarPuesto([FromBody] EtcatPuestos catNivelPuestos)
        {
            try
            {
                return new PuestosInstitucionales().EliminarPuesto(catNivelPuestos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Empleados
        [HttpPost]
        public List<Etempleados> ObtenerEmpleado()
        {
            try
            {
                return new Empleados().ObtenerEmpleado();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string RFCDisponibleEmpleadoNew([FromBody] string RFCEmp)
        {
            try
            {
                return new Empleados().RFCDisponibleEmpleadoNew(RFCEmp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string RFCDisponibleEmpleado([FromBody] Etempleados RFCEmp)
        {
            try
            {
                return new Empleados().RFCDisponibleEmpleado(RFCEmp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string ObtenerClaveEmpleadoNew([FromBody] string numeroNuevo)
        {
            try
            {
                return new Empleados().ObtenerClaveEmpleadoNew(numeroNuevo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string ObtenerClaveEmpleado([FromBody] Etempleados numeroNuevo)
        {
            try
            {
                return new Empleados().ObtenerClaveEmpleado(numeroNuevo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etempleados> ObtenerEmpleadosXUnidad([FromBody] int Unidad)
        {
            try
            {
                return new Empleados().ObtenerEmpleadosXUnidad(Unidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etempleados> ObtenerEmpleadosXPuesto([FromBody] int RIDPuesto)
        {
            try
            {
                return new Empleados().ObtenerEmpleadosXPuesto(RIDPuesto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string CargarImagenEmpleado()
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                //var constructorInfo = typeof(HttpPostedFile).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
                //HttpPostedFile obj = (HttpPostedFile)constructorInfo
                //          .Invoke(new object[] { file.FileName, file.ContentType, file.InputStream });
                if (file != null && (file.ContentType == "image/png" || file.ContentType == "image/svg+xml"))
                {
                    return new Empleados().CargarImagenEmpleados(file);
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
        public Resultado IngresarEmpleado([FromBody] Etempleados templeados)
        {
            try
            {
                return new Empleados().IngresarEmpleado(templeados);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado ActualizarEmpleado([FromBody] Etempleados templeados)
        {
            try
            {
                return new Empleados().ActualizarEmpleado(templeados);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado EliminarEmpleado([FromBody] Etempleados templeados)
        {
            try
            {
                return new Empleados().EliminarEmpleado(templeados);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region UnidadesAdministrativas        
        [HttpPost]
        public List<Etunidadadministrativa> ObtenerUnidadesAdministrativas()
        {
            try
            {
                return new UnidadAdministrativa().ObtenerUnidadesAdministrativas();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<EUnidadesActivas> GetUnidadAdmActiva()
        {
            try
            {
                return new UnidadAdministrativa().GetUnidadAdmActiva();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etunidadadministrativa> datosOrganigrama()
        {
            try
            {
                return new UnidadAdministrativa().datosOrganigrama();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Organigrama ObtenerOrganigrama([FromBody] List<Etunidadadministrativa> unidadesAdministrativas)
        {
            try
            {
                return new GenerarOrganigrama().ObtenerOrganigrama(unidadesAdministrativas);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public EcatcpEntidadesFederativas ObtenerEntidadFederativa()
        {
            try
            {
                return new UnidadAdministrativa().ObtenerEntidadFederativa();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Ecatcpmunicipios> ObtenerMunicipios([FromBody] int RIDEntidad)
        {
            try
            {
                return new UnidadAdministrativa().ObtenerMunicipios(RIDEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Ecataplicaciones> ObtenerAplicacion()
        {
            try
            {
                return new UnidadAdministrativa().ObtenerAplicaciones();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string CargarImagenLogoUnidadAdministrativa()
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                if (file != null && (file.ContentType == "image/png" || file.ContentType == "image/svg+xml"))
                {
                    return new UnidadAdministrativa().CargarLogoUA(file);
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
        public string CargarLogoDeAplicaciones()
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                if (file != null && (file.ContentType == "image/png" || file.ContentType == "image/svg+xml"))
                {
                    return new UnidadAdministrativa().CargarLogoDeAplicaciones(file);
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
        public List<Ecattipofiltrosinicialesbuzon> ObtenerFiltro()
        {
            try
            {
                return new UnidadAdministrativa().ObtenerFiltro();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Ebuzonconfiguracionfiltros> BuscarFiltros([FromBody] Ecattipofiltrosinicialesbuzon Ecattipofiltrosinicialesbuzon)
        {
            try
            {
                return new UnidadAdministrativa().BuscarFiltros(Ecattipofiltrosinicialesbuzon);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado InsertarUnidadAdministrativa([FromBody] Etunidadadministrativa unidadADM)
        {
            try
            {
                return new UnidadAdministrativa().InsertarUnidadAdministrativa(unidadADM);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etunidadadministrativa> ObtenerUnidadesHijas([FromBody] int RIDUA)
        {
            try
            {
                return new UnidadAdministrativa().ObtenerUnidadesHijas(RIDUA);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Ebuzonesconfiguracion> BuzonesXUA([FromBody] int RIDUA)
        {
            try
            {
                return new UnidadAdministrativa().BuzonesXUA(RIDUA);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Ebuzonconfiguracionfiltros> FiltrosXBuzon([FromBody] int RIDBuzon)
        {
            try
            {
                return new UnidadAdministrativa().FiltrosXBuzon(RIDBuzon);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Ebuzonconfiguracionfiltros> ObtenerBuzonFiltrosInicial()
        {
            try
            {
                return new UnidadAdministrativa().ObtenerBuzonFiltrosInicial();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado EliminarUnidadAdministrativa(Etunidadadministrativa unidadADM)
        {
            try
            {
                return new UnidadAdministrativa().EliminarUnidadAdministrativa(unidadADM);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado ActualizarUnidadAdministrativa([FromBody] Etunidadadministrativa unidadADM)
        {
            try
            {
                return new UnidadAdministrativa().ActualizarUnidadAdministrativa(unidadADM);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Usuarios
        [HttpPost]
        public List<Etusuarios> GetUsuarios()
        {
            try
            {
                return new Usuarios().GetUsuarios();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<EBuzonXUnidad> AplicacionesxUnidad(int RIDUnidad)
        {
            try
            {
                return new Usuarios().AplicacionesxUnidad(RIDUnidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etusuarios> ObtenerUsuariosXUnidadA([FromBody] int RIDUnidad)
        {
            try
            {
                return new Usuarios().ObtenerUsuariosXUnidadA(RIDUnidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etusuarios> getNewUsuarios([FromBody] int RIDUnidad)
        {
            try
            {
                return new Usuarios().getNewUsuarios(RIDUnidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etusuarios> UsuariosExistentes([FromBody] int RIDUnidad)
        {
            try
            {
                return new Usuarios().UsuariosExistentes(RIDUnidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado IngresarUsuario([FromBody] Etusuarios newUser)
        {
            try
            {
                return new Usuarios().IngresarUsuario(newUser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado UpdateUser([FromBody] Etusuarios updateUser)
        {
            try
            {
                return new Usuarios().UpdateUser(updateUser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado UpdateUserPW([FromBody] Etusuarios updateUserPW)
        {
            try
            {
                return new Usuarios().UpdateUserPW(updateUserPW);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etusuarios> ReactivaUsuario([FromBody] int RIDUsuario)
        {
            try
            {
                return new Usuarios().ReactivaUsuario(RIDUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etusuarios> DownUsuarioyRelacionesRolBuzon([FromBody] int RIDUsuario)
        {
            try
            {
                return new Usuarios().DownUsuarioyRelacionesRolBuzon(RIDUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<Etusuarios> DeleteUsuarioyRelacionesRolBuzon([FromBody] int RIDUsuario)
        {
            try
            {
                return new Usuarios().DeleteUsuarioyRelacionesRolBuzon(RIDUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Usuarios-Roles
        [HttpPost]
        public List<ECatRoles> RolesXNivelPuesto([FromBody] int RIDNivel)
        {
            try
            {
                return new Usuarios().RolesXNivelPuesto(RIDNivel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<ECatRoles> insertaRolesEmpleado([FromBody] ETablaRelacionERB Roles)
        {
            try
            {
                return new Usuarios().insertaRolesEmpleado(Roles);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<ECatRoles> EliminaRolTeporal([FromBody] int ClaveBuzon)
        {
            try
            {
                return new Usuarios().EliminaRolTeporal(ClaveBuzon);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Desbloqueo de cuentas
        [HttpPost]
        public List<Etusuarios> busquedaUserID([FromBody] string userID)
        {
            try
            {
                return new DesbloqueoDeCuenta().busquedaUserID(userID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Buzones-Aplicaciones
        [HttpPost]
        public List<ETablaRelacionERB> BuzonesEmpleado([FromBody] int RIDEmpleado)
        {
            try
            {
                return new Buzon_Aplicacion().BuzonesEmpleado(RIDEmpleado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<ErBuzonRoles> RolesXBuzon([FromBody] int RIDEmpleado)
        {
            try
            {
                return new Buzon_Aplicacion().RolesXBuzon(RIDEmpleado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<ECatRoles> GetDatosTablaTemporalERB([FromBody] ETablaRelacionERB RIDNivel)
        {
            try
            {
                return new Buzon_Aplicacion().GetDatosTablaTemporalERB(RIDNivel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado EliminaTablaTeporal()
        {
            try
            {
                return new Buzon_Aplicacion().EliminaTablaTeporal();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public Resultado UsuariosSetDatosUsuariosTablaTemporal([FromBody] int RIDUsuario)
        {
            try
            {
                return new Buzon_Aplicacion().UsuariosSetDatosUsuariosTablaTemporal(RIDUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<ETablaRelacionERB> relacionesEliminadasTablaTemporal([FromBody] int RIDUsuario)
        {
            try
            {
                return new Buzon_Aplicacion().relacionesEliminadasTablaTemporal(RIDUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<ETablaRelacionERB> relacionesNuevasTablaTemporal([FromBody] int RIDUsuario)
        {
            try
            {
                return new Buzon_Aplicacion().relacionesNuevasTablaTemporal(RIDUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<ETablaRelacionERB> relacionesUBEliminadasTablaTemporal([FromBody] int RIDUsuario)
        {
            try
            {
                return new Buzon_Aplicacion().relacionesUBEliminadasTablaTemporal(RIDUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<ETablaRelacionERB> relacionesUBNuevasTablaTemporal([FromBody] int RIDUsuario)
        {
            try
            {
                return new Buzon_Aplicacion().relacionesUBNuevasTablaTemporal(RIDUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Grupos de atencion
        [HttpPost]
        public List<Ebuzonesconfiguracion> ObtenerBuzonesConfiguracion()
        {
            try
            {
                return new BTLBuzon().ObtenerBuzonesConfiguracion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
