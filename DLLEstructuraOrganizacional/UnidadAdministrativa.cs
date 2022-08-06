using ClsAccessData;
using System.Collections.Generic;
using System.Data;
using EntitiesPSR;
using DLLUtilerias;
using System.Web;

namespace DLLEstructuraOrganizacional
{
    public class UnidadAdministrativa
    {
        DataAccess dataAccess = new DataAccess();
        public List<Etunidadadministrativa> ObtenerUnidadesAdministrativas()
        {
            DatosEO Unidades = new DatosEO();
            DataTable dtUnidades = Unidades.ObtenerUnidadesAdministrativas();
            List<Etunidadadministrativa> lsUnidades = new Utilerias().Convertir<Etunidadadministrativa>(dtUnidades);
            return lsUnidades;
        }
        public List<EUnidadesActivas> GetUnidadAdmActiva()
        {
            DatosEO Unidades = new DatosEO();
            DataTable dtUnidades = Unidades.GetUnidadAdmActiva();
            List<EUnidadesActivas> lsUnidades = new Utilerias().Convertir<EUnidadesActivas>(dtUnidades);
            return lsUnidades;
        }
        public List<Etunidadadministrativa> datosOrganigrama()
        {
            DatosEO dataOrganigrama = new DatosEO();
            DataTable dtUnidadesOrg = dataOrganigrama.datosOrganigrama();
            List<Etunidadadministrativa> lsUnidadesOrg = new Utilerias().Convertir<Etunidadadministrativa>(dtUnidadesOrg);
            return lsUnidadesOrg;
        }
        public EcatcpEntidadesFederativas ObtenerEntidadFederativa()
        {
            DatosEO Entidad = new DatosEO();
            DataTable dtEntidad = Entidad.ObtenerEntidadFederativa();
            List<EcatcpEntidadesFederativas> lsEntidad = new Utilerias().Convertir<EcatcpEntidadesFederativas>(dtEntidad);
            return lsEntidad[0];
        }
        public List<Ecatcpmunicipios> ObtenerMunicipios(int RIDEntidad)
        {
            DatosEO Municipios = new DatosEO();
            DataTable dtMunicipios = Municipios.ObtenerMunicipios(RIDEntidad);
            List<Ecatcpmunicipios> lsMunicipios = new Utilerias().Convertir<Ecatcpmunicipios>(dtMunicipios);
            return lsMunicipios;
        }
        public List<Ecataplicaciones> ObtenerAplicaciones()
        {
            DatosEO aplicacionesConfiguradas = new DatosEO();
            DataTable dtAplicacionesConfiguradas = aplicacionesConfiguradas.ObtenerAplicaciones();
            List<Ecataplicaciones> lsAplicacionesConfiguradas = new Utilerias().Convertir<Ecataplicaciones>(dtAplicacionesConfiguradas);
            return lsAplicacionesConfiguradas;
        }
        public string CargarLogoUA(HttpPostedFile file)
        {
            DatosEO guardaArchivo = new DatosEO();
            DataTable tablaParametros = guardaArchivo.CargarLogos();
            DataRow[] drDirectorioFotosUnidadAdministrativa = tablaParametros.Select("RIDDirectorio=202");
            if (drDirectorioFotosUnidadAdministrativa.Length > 0)
            {
                Utilerias upimg = new Utilerias();
                string directorioVirtual = drDirectorioFotosUnidadAdministrativa[0]["DirectorioVirtualExterno"].ToString() + upimg.guardarImagen(drDirectorioFotosUnidadAdministrativa[0]["DirectorioFisicoInterno"].ToString(), file);
                return directorioVirtual;
            }
            else
            {
                return "No se pudo obtener los parámetros del servidor.";
            }
        }
        public string CargarLogoDeAplicaciones(HttpPostedFile file)
        {
            DatosEO guardaArchivo = new DatosEO();
            DataTable tablaParametros = guardaArchivo.CargarLogos();
            DataRow[] drDirectorioFotosUnidadAdministrativa = tablaParametros.Select("RIDDirectorio=208");
            if (drDirectorioFotosUnidadAdministrativa.Length > 0)
            {
                Utilerias upimg = new Utilerias();
                string directorioVirtual = drDirectorioFotosUnidadAdministrativa[0]["DirectorioVirtualExterno"].ToString() + upimg.guardarImagen(drDirectorioFotosUnidadAdministrativa[0]["DirectorioFisicoInterno"].ToString(), file);
                return directorioVirtual;
            }
            else
            {
                return "No se pudo obtener los parámetros del servidor.";
            }
        }
        public List<Ecattipofiltrosinicialesbuzon> ObtenerFiltro()
        {
            DatosEO obtenerFiltros = new DatosEO();
            DataTable dtobtenerFiltros = obtenerFiltros.ObtenerFiltros();
            List<Ecattipofiltrosinicialesbuzon> lsobtenerFiltros = new Utilerias().Convertir<Ecattipofiltrosinicialesbuzon>(dtobtenerFiltros);
            return lsobtenerFiltros;
        }
        public List<Ebuzonconfiguracionfiltros> BuscarFiltros(Ecattipofiltrosinicialesbuzon tipoFiltro)
        {
            DatosEO obtenerFiltros = new DatosEO();
            DataTable table = obtenerFiltros.BuscarFiltros(tipoFiltro);
            List<Ebuzonconfiguracionfiltros> lsResultado = new Utilerias().ObtenerFiltrosBuzon(table, tipoFiltro);
            return lsResultado;
        }
        public Resultado InsertarUnidadAdministrativa(Etunidadadministrativa unidadADM)
        {
            DatosEO ingresarUnidad = new DatosEO();

            (int, string) idUnidad = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.TUNIDADADMINISTRATIVA);
            unidadADM.RIDUnidadAdministrativa = idUnidad.Item1;
            dataAccess.OpenConnection();
            dataAccess.BeginTransaction();
            DataTable dtUnidad = ingresarUnidad.InsertarUnidadAdministrativa(unidadADM);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
            if (resultado.ExisteError)
            {
                dataAccess.Rollback();
                dataAccess.CloseConnection();
                return resultado;
            }
            //Buzones y Filtros, Puestos y Empleados
            else
            {
                //Buzones y Filtros
                if (unidadADM.Buzones.Count != 0)
                {
                    foreach (Ebuzonesconfiguracion buzon in unidadADM.Buzones)
                    {
                        (int, string) idBuzon = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.BUZON_CONFIGURACION);
                        buzon.RIDBuzon = idBuzon.Item1;
                        buzon.ClaveUnidadAdmva = unidadADM.RIDUnidadAdministrativa;

                        dtUnidad = ingresarUnidad.InsertarBuzonAppUA(buzon);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                        if (resultado.ExisteError)
                        {
                            dataAccess.Rollback();
                            dataAccess.CloseConnection();
                            return resultado;
                        }
                        else
                        {
                            //filtros
                            if (buzon.Filtros.Count != 0)
                            {
                                foreach (Ebuzonconfiguracionfiltros filtro in buzon.Filtros)
                                {
                                    (int, string) idFiltro = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.BUZONCONFIGURACIONFILTROS);
                                    filtro.RID = idFiltro.Item1;
                                    filtro.ClaveBuzon = buzon.RIDBuzon;

                                    dtUnidad = ingresarUnidad.InsertarBuzonFiltroUA(filtro);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                    if (resultado.ExisteError)
                                    {
                                        dataAccess.Rollback();
                                        dataAccess.CloseConnection();
                                        return resultado;
                                    }
                                }
                            }
                        }
                    }
                }
                //Puestos y Empleados
                if (unidadADM.Puestos.Count != 0)
                {
                    foreach (EtcatPuestos puestos in unidadADM.Puestos)
                    {
                        (int, string) idPuesto = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_PUESTOS);
                        puestos.RIDPuestos = idPuesto.Item1;
                        puestos.ClaveUnidadAdministrativa = unidadADM.RIDUnidadAdministrativa;

                        dtUnidad = ingresarUnidad.IngresarPuesto(puestos);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                        if (resultado.ExisteError)
                        {
                            dataAccess.Rollback();
                            dataAccess.CloseConnection();
                            return resultado;
                        }
                        else
                        {
                            //empleados
                            if (unidadADM.Empleados.Count != 0)
                            {
                                foreach (Etempleados empleado in unidadADM.Empleados)
                                {
                                    if (empleado.NombrePuesto == puestos.NombrePuesto && empleado.ClavePuesto == 0)
                                    {
                                        (int, string) idEmpleado = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.TEMPLEADOS);
                                        empleado.RIDEmpleado = idEmpleado.Item1;
                                        empleado.ClavePuesto = puestos.RIDPuestos;

                                        dtUnidad = ingresarUnidad.IngresarEmpleado(empleado);
                                        resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                        if (resultado.ExisteError)
                                        {
                                            dataAccess.Rollback();
                                            dataAccess.CloseConnection();
                                            return resultado;
                                        }
                                        else
                                        {
                                            //Titular
                                            if (empleado.Titular)
                                            {
                                                unidadADM.ClaveEmpleado = empleado.RIDEmpleado;

                                                dtUnidad = ingresarUnidad.ActualizarTitular(unidadADM);
                                                resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                                if (resultado.ExisteError)
                                                {
                                                    dataAccess.Rollback();
                                                    dataAccess.CloseConnection();
                                                    return resultado;
                                                }
                                                else
                                                {
                                                    return resultado;
                                                }
                                            }
                                            else
                                            {
                                                return resultado;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //dataAccess.Rollback();
            dataAccess.CloseConnection();
            return resultado;
        }
        public List<Etunidadadministrativa> ObtenerUnidadesHijas(int RIDUA)
        {
            DatosEO UAHijas = new DatosEO();
            DataTable dtUAHijas = UAHijas.ObtenerUnidadesHijas(RIDUA);
            List<Etunidadadministrativa> lsUAHijas = new Utilerias().Convertir<Etunidadadministrativa>(dtUAHijas);
            return lsUAHijas;
        }
        public List<Ebuzonesconfiguracion> BuzonesXUA(int RIDUA)
        {
            DatosEO Buzones = new DatosEO();
            DataTable dtBuzones = Buzones.BuzonesXUA(RIDUA);
            List<Ebuzonesconfiguracion> lsBuzones = new Utilerias().Convertir<Ebuzonesconfiguracion>(dtBuzones);
            return lsBuzones;
        }
        public List<Ebuzonconfiguracionfiltros> FiltrosXBuzon(int RIDBuzon)
        {
            DatosEO filtroBuzon = new DatosEO();
            DataTable dtFiltroBuzon = filtroBuzon.FiltrosXBuzon(RIDBuzon);
            List<Ebuzonconfiguracionfiltros> lsFiltroBuzon = new Utilerias().Convertir<Ebuzonconfiguracionfiltros>(dtFiltroBuzon);
            return lsFiltroBuzon;
        }
        public List<Ebuzonconfiguracionfiltros> ObtenerBuzonFiltrosInicial()
        {
            DatosEO filtroInicial = new DatosEO();
            DataTable dtfiltroInicial = filtroInicial.ObtenerBuzonFiltrosInicial();
            List<Ebuzonconfiguracionfiltros> lsfiltroInicial = new Utilerias().Convertir<Ebuzonconfiguracionfiltros>(dtfiltroInicial);
            return lsfiltroInicial;
        }       
        public Resultado EliminarUnidadAdministrativa(Etunidadadministrativa unidadADM)
        {
            DatosEO DelUnidad = new DatosEO();
            Resultado resultado = new Resultado();
            //(Particular a general) Borra los buzones primero y luego las unidades
            if (unidadADM.Buzones.Count > 0)
            {
                foreach (Ebuzonesconfiguracion buzon in unidadADM.Buzones)
                {
                    DataTable dtUnidad = DelUnidad.DelUnidadAdministrativaBuzones(buzon);
                    resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                    if (!resultado.ExisteError)
                    {
                        dtUnidad = DelUnidad.DelUnidadAdministrativa(unidadADM);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                        return resultado;
                    }
                }
            }
            //Borra la unidad directamente
            else
            {
                DataTable dtUnidad = DelUnidad.DelUnidadAdministrativa(unidadADM);
                resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                return resultado;
            }
            return resultado;
        }
        public Resultado ActualizarUnidadAdministrativa(Etunidadadministrativa unidadADM)
        {
            DatosEO ingresarUnidad = new DatosEO();
            dataAccess.OpenConnection();
            dataAccess.BeginTransaction();
            DataTable dtUnidad = ingresarUnidad.ActualizarUnidadAdministrativa(unidadADM);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
            if (resultado.ExisteError)
            {
                dataAccess.Rollback();
                dataAccess.CloseConnection();
                return resultado;
            }
            //Buzones y Filtros, Puestos y Empleados
            else
            {
                //Buzones y Filtros
                if (unidadADM.Buzones.Count != 0)
                {
                    foreach (Ebuzonesconfiguracion buzon in unidadADM.Buzones)
                    {
                        //Inserta buzones nuevos
                        if (buzon.RIDBuzon == 0)
                        {
                            (int, string) idBuzon = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.BUZON_CONFIGURACION);
                            buzon.RIDBuzon = idBuzon.Item1;
                            buzon.ClaveUnidadAdmva = unidadADM.RIDUnidadAdministrativa;
                            dtUnidad = ingresarUnidad.InsertarBuzonAppUA(buzon);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                            if (resultado.ExisteError)
                            {
                                dataAccess.Rollback();
                                dataAccess.CloseConnection();
                                return resultado;
                            }
                            //inserta filtros
                            else
                            {
                                if (buzon.Filtros.Count != 0)
                                {
                                    foreach (Ebuzonconfiguracionfiltros filtro in buzon.Filtros)
                                    {
                                        (int, string) idFiltro = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.BUZONCONFIGURACIONFILTROS);
                                        filtro.RID = idFiltro.Item1;
                                        filtro.ClaveBuzon = buzon.RIDBuzon;
                                        dtUnidad = ingresarUnidad.InsertarBuzonFiltroUA(filtro);
                                        resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                        if (resultado.ExisteError)
                                        {
                                            dataAccess.Rollback();
                                            dataAccess.CloseConnection();
                                            return resultado;
                                        }
                                    }
                                }
                            }
                        }
                        //Actualiza los buzones existentes
                        else
                        {
                            dtUnidad = ingresarUnidad.ActualizarBuzonAppUA(buzon);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                            if (resultado.ExisteError)
                            {
                                dataAccess.Rollback();
                                dataAccess.CloseConnection();
                                return resultado;
                            }
                            else
                            {
                                //actualiza filtros
                                if (buzon.Filtros.Count != 0)
                                {
                                    foreach (Ebuzonconfiguracionfiltros filtro in buzon.Filtros)
                                    {
                                        //Inserta filtro nuevo
                                        if (filtro.RID == 0)
                                        {
                                            (int, string) idFiltro = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.BUZONCONFIGURACIONFILTROS);
                                            filtro.RID = idFiltro.Item1;
                                            filtro.ClaveBuzon = buzon.RIDBuzon;
                                            dtUnidad = ingresarUnidad.InsertarBuzonFiltroUA(filtro);
                                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                            if (resultado.ExisteError)
                                            {
                                                dataAccess.Rollback();
                                                dataAccess.CloseConnection();
                                                return resultado;
                                            }
                                        }
                                        //Trae lista auxiliar y actualiza el estatus de los filtros
                                        else
                                        {
                                            dtUnidad = ingresarUnidad.ActualizarBuzonFiltroUA(filtro);
                                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                            if (resultado.ExisteError)
                                            {
                                                dataAccess.Rollback();
                                                dataAccess.CloseConnection();
                                                return resultado;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //Puestos y Empleados
                if (unidadADM.Puestos.Count != 0)
                {
                    foreach (EtcatPuestos puestos in unidadADM.Puestos)
                    {
                        //Nuevo puesto
                        if (puestos.RIDPuestos == 0)
                        {
                            (int, string) idPuesto = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.CAT_PUESTOS);
                            puestos.RIDPuestos = idPuesto.Item1;
                            puestos.ClaveUnidadAdministrativa = unidadADM.RIDUnidadAdministrativa;
                            dtUnidad = ingresarUnidad.IngresarPuesto(puestos);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                            if (resultado.ExisteError)
                            {
                                dataAccess.Rollback();
                                dataAccess.CloseConnection();
                                return resultado;
                            }
                            else
                            {
                                //empleados
                                if (unidadADM.Empleados.Count != 0)
                                {
                                    foreach (Etempleados empleado in unidadADM.Empleados)
                                    {
                                        //Nuevo empleado
                                        if (empleado.RIDEmpleado == 0)
                                        {
                                            if (empleado.NombrePuesto == puestos.NombrePuesto && empleado.ClavePuesto == 0)
                                            {
                                                (int, string) idEmpleado = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.TEMPLEADOS);
                                                empleado.RIDEmpleado = idEmpleado.Item1;
                                                empleado.ClavePuesto = puestos.RIDPuestos;
                                                dtUnidad = ingresarUnidad.IngresarEmpleado(empleado);
                                                resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                                if (resultado.ExisteError)
                                                {
                                                    dataAccess.Rollback();
                                                    dataAccess.CloseConnection();
                                                    return resultado;
                                                }
                                                else
                                                {
                                                    //Titular
                                                    if (empleado.Titular)
                                                    {
                                                        unidadADM.ClaveEmpleado = empleado.RIDEmpleado;

                                                        dtUnidad = ingresarUnidad.ActualizarTitular(unidadADM);
                                                        resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                                        if (resultado.ExisteError)
                                                        {
                                                            dataAccess.Rollback();
                                                            dataAccess.CloseConnection();
                                                            return resultado;
                                                        }
                                                        else
                                                        {
                                                            return resultado;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        return resultado;
                                                    }
                                                }
                                            }
                                        }
                                        //Editar empleado
                                        else
                                        {
                                            if (empleado.NombrePuesto == puestos.NombrePuesto && empleado.ClavePuesto == 0)
                                            {
                                                empleado.ClavePuesto = puestos.RIDPuestos;
                                                dtUnidad = ingresarUnidad.ActualizarEmpleado(empleado);
                                                resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                                if (resultado.ExisteError)
                                                {
                                                    dataAccess.Rollback();
                                                    dataAccess.CloseConnection();
                                                    return resultado;
                                                }
                                                else
                                                {
                                                    return resultado;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //No hay nuevo puesto, editamos empleados
                        else
                        {
                            //empleados
                            if (unidadADM.Empleados.Count != 0)
                            {
                                foreach (Etempleados empleado in unidadADM.Empleados)
                                {
                                    //nuevo empleado
                                    if (empleado.RIDEmpleado == 0)
                                    {
                                        if (empleado.ClavePuesto == puestos.RIDPuestos)
                                        {
                                            (int, string) idEmpleado = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.TEMPLEADOS);
                                            empleado.RIDEmpleado = idEmpleado.Item1;
                                            dtUnidad = ingresarUnidad.IngresarEmpleado(empleado);
                                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                            if (resultado.ExisteError)
                                            {
                                                dataAccess.Rollback();
                                                dataAccess.CloseConnection();
                                                return resultado;
                                            }
                                            else
                                            {
                                                //Titular
                                                if (empleado.Titular)
                                                {
                                                    unidadADM.ClaveEmpleado = empleado.RIDEmpleado;
                                                    dtUnidad = ingresarUnidad.ActualizarTitular(unidadADM);
                                                    resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                                    if (resultado.ExisteError)
                                                    {
                                                        dataAccess.Rollback();
                                                        dataAccess.CloseConnection();
                                                        return resultado;
                                                    }
                                                    else
                                                    {
                                                        return resultado;
                                                    }
                                                }
                                                else
                                                {
                                                    return resultado;
                                                }
                                            }
                                        }
                                    }
                                    //Actualizar empleado
                                    else
                                    {
                                        if (empleado.ClavePuesto == puestos.RIDPuestos)
                                        {
                                            dtUnidad = ingresarUnidad.ActualizarEmpleado(empleado);
                                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                            if (resultado.ExisteError)
                                            {
                                                dataAccess.Rollback();
                                                dataAccess.CloseConnection();
                                                return resultado;
                                            }
                                            else
                                            {
                                                //Titular
                                                if (empleado.Titular)
                                                {
                                                    dtUnidad = ingresarUnidad.ActualizarTitular(unidadADM);
                                                    resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                                    if (resultado.ExisteError)
                                                    {
                                                        dataAccess.Rollback();
                                                        dataAccess.CloseConnection();
                                                        return resultado;
                                                    }
                                                    else
                                                    {
                                                        return resultado;
                                                    }
                                                }
                                                else
                                                {
                                                    return resultado;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //Solo empleados
                if (unidadADM.Puestos.Count == 0 && unidadADM.Empleados.Count > 0)
                {
                    foreach (Etempleados empleado in unidadADM.Empleados)
                    {
                        //Nuevo empleado
                        if (empleado.RIDEmpleado == 0)
                        {
                            (int, string) idEmpleado = ingresarUnidad.ObtenerIdentificadoresPSR(TablasAdministracion.TEMPLEADOS);
                            empleado.RIDEmpleado = idEmpleado.Item1;
                            dtUnidad = ingresarUnidad.IngresarEmpleado(empleado);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                            if (resultado.ExisteError)
                            {
                                dataAccess.Rollback();
                                dataAccess.CloseConnection();
                                return resultado;
                            }
                            else
                            {
                                //Titular
                                if (empleado.Titular)
                                {
                                    unidadADM.ClaveEmpleado = empleado.RIDEmpleado;
                                    dtUnidad = ingresarUnidad.ActualizarTitular(unidadADM);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                    if (resultado.ExisteError)
                                    {
                                        dataAccess.Rollback();
                                        dataAccess.CloseConnection();
                                        return resultado;
                                    }
                                    else
                                    {
                                        return resultado;
                                    }
                                }
                                else
                                {
                                    return resultado;
                                }
                            }
                        }
                        //Editar empleado
                        else
                        {
                            dtUnidad = ingresarUnidad.ActualizarEmpleado(empleado);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                            if (resultado.ExisteError)
                            {
                                dataAccess.Rollback();
                                dataAccess.CloseConnection();
                                return resultado;
                            }
                            else
                            {
                                //Titular
                                if (empleado.Titular)
                                {
                                    unidadADM.ClaveEmpleado = empleado.RIDEmpleado;
                                    dtUnidad = ingresarUnidad.ActualizarTitular(unidadADM);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtUnidad);
                                    if (resultado.ExisteError)
                                    {
                                        dataAccess.Rollback();
                                        dataAccess.CloseConnection();
                                        return resultado;
                                    }
                                    else
                                    {
                                        return resultado;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            dataAccess.CloseConnection();
            return resultado;
        }
    }
}
