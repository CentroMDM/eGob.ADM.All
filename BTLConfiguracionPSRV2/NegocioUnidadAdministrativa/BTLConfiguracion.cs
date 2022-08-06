using System;
using System.Collections.Generic;
using System.Data;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;

namespace BTLConfiguracionPSRV2
{
    public class BTLConfiguracion
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


        public List<Etunidadadministrativa> GetUnidadesPuestos()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerUnidadesAdministrativas());
            List<Etunidadadministrativa> lsResultado = UtilTablas.ConvertirDataTableToList<Etunidadadministrativa>(table);
            List<EtcatPuestos> lsPuestos = ObtenerPuestosInstitucionales();
            foreach (Etunidadadministrativa unidad in lsResultado)
            {
                foreach (EtcatPuestos puesto in lsPuestos)
                {
                    if (puesto.ClaveUnidadAdministrativa == unidad.RIDUnidadAdministrativa)
                    {
                        unidad.Puestos.Add(puesto);
                    }
                }
            }
            List<EcatNivelesPuestos> lsNiveles = ObtenerNivelesPuestosInstitucionales();
            foreach (EtcatPuestos puesto in lsPuestos)
            {
                foreach (EcatNivelesPuestos nivel in lsNiveles)
                {
                    if (nivel.RIDNivel == puesto.ClaveNivelPuesto)
                    {
                        puesto.NivelPuesto = nivel;
                    }
                }
            }
            return lsResultado;
        }

        public List<Etunidadadministrativa> ObtenerUnidadesAdministrativas()
        {
            DAOGetObjetosNegocio getObjetos = GetObjetosNegocio();
            DataTable table = getObjetos.ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerUnidadesAdministrativas());
            List<Etunidadadministrativa> lsResultado = UtilTablas.ConvertirDataTableToList<Etunidadadministrativa>(table);
            Etunidadadministrativa entidadPrincipal = new Etunidadadministrativa
            {
                RIDUnidadAdministrativa = 0,
                NombreUA = "UNIDAD ADMINISTRATIVA INICIAL"
            };
            lsResultado.Add(entidadPrincipal);
            List<Ebuzonesconfiguracion> lsBuzones = ObtenerBuzonesConfiguracion();

            foreach (Etunidadadministrativa unidad in lsResultado)
            {
                foreach (Ebuzonesconfiguracion buzon in lsBuzones)
                {
                    if (unidad.RIDUnidadAdministrativa == buzon.ClaveUnidadAdmva)
                    {
                        unidad.Buzones.Add(buzon);
                    }
                }
            }
            List<Etempleados> lsEmpleados = ObtenerEmpleados();
            foreach (Etunidadadministrativa unidad in lsResultado)
            {
                foreach (Etempleados empleado in lsEmpleados)
                {
                    if (empleado.RIDUnidadAdministrativa == unidad.RIDUnidadAdministrativa)
                    {
                        unidad.Empleados.Add(empleado);
                    }
                }
            }
            List<EtcatPuestos> lsPuestos = ObtenerPuestosInstitucionales();
            foreach (Etunidadadministrativa unidad in lsResultado)
            {
                foreach (EtcatPuestos puesto in lsPuestos)
                {
                    if (puesto.ClaveUnidadAdministrativa == unidad.RIDUnidadAdministrativa)
                    {
                        unidad.Puestos.Add(puesto);
                    }
                }
            }

            foreach (Etempleados empleado in lsEmpleados)
            {
                foreach (EtcatPuestos puesto in lsPuestos)
                {
                    if (empleado.ClavePuesto == puesto.RIDPuestos)
                    {
                        empleado.PuestoInstitucional = puesto;
                    }
                }
            }

            List<EcatNivelesPuestos> lsNiveles = ObtenerNivelesPuestosInstitucionales();
            foreach (EtcatPuestos puesto in lsPuestos)
            {
                foreach (EcatNivelesPuestos nivel in lsNiveles)
                {
                    if (nivel.RIDNivel == puesto.ClaveNivelPuesto)
                    {
                        puesto.NivelPuesto = nivel;
                    }
                }
            }
            return lsResultado;
        }
        public List<Etunidadadministrativa> datosOrganigrama()
        {
            //DAOGetObjetosNegocio getObjetos = GetObjetosNegocio();
            //DataTable table = getObjetos.ObtenerConsulta(ScriptUnidadAdministrativa.datosOrganigrama());
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.datosOrganigrama());
            List<Etunidadadministrativa> lsResultado = UtilTablas.ConvertirDataTableToList<Etunidadadministrativa>(table);
            //Etunidadadministrativa entidadPrincipal = new Etunidadadministrativa
            //{
            //    RIDUnidadAdministrativa = 0,
            //    NombreUA = "UNIDAD ADMINISTRATIVA INICIAL"
            //};
            //lsResultado.Add(entidadPrincipal);
            return lsResultado;
        }

        public List<Ebuzonesconfiguracion> ObtenerBuzonesConfiguracion()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerBuzonesConfiguracion());
            List<Ebuzonesconfiguracion> lsBuzones = UtilTablas.ConvertirDataTableToList<Ebuzonesconfiguracion>(table);
            BTLAuxiliares btl = new BTLAuxiliares();
            List<Ecatdescriptivoitems> lsDescriptivo = btl.ObtenerItemsCatalogoDescriptivo(CatalogoDescriptivo.BUZON);
            foreach (Ebuzonesconfiguracion buzon in lsBuzones)
            {
                foreach (Ecatdescriptivoitems catalogo in lsDescriptivo)
                {
                    if (buzon.ClaveStatus == catalogo.RIDItemCatalogo)
                    {
                        buzon.CatalogoDescriptivo = catalogo;
                    }
                }
            }
            List<Ebuzonconfiguracionfiltros> lsConfiguraciones = ObtenerBuzonFiltrosInicial();
            foreach (Ebuzonesconfiguracion buzon in lsBuzones)
            {
                foreach (Ebuzonconfiguracionfiltros filtro in lsConfiguraciones)
                {
                    if (buzon.RIDBuzon == filtro.ClaveBuzon)
                    {
                        buzon.Filtros.Add(filtro);
                    }
                }
            }
            return lsBuzones;
        }
        public List<Ebuzonconfiguracionfiltros> ObtenerBuzonFiltrosInicial()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerBuzonConfiguracionFiltros());
            List<Ebuzonconfiguracionfiltros> lsResultado = UtilTablas.ConvertirDataTableToList<Ebuzonconfiguracionfiltros>(table);
            return lsResultado;
        }

        public List<EcatBuzonFiscal> GetConfigBuzon()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetConfigBuzon());
            List<EcatBuzonFiscal> lsResultado = UtilTablas.ConvertirDataTableToList<EcatBuzonFiscal>(table);
            return lsResultado;
        }

        public Resultado UpdateConfigBuzon(EcatBuzonFiscal implementacion)
        {
            DAOUpdateorDeleteObjetosNegocio updateObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateObjetosNegocio.UpdateOrDeleteRegistro(ScriptUnidadAdministrativa.UpdateConfigBuzon(implementacion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }

        public List<EtcatPuestos> ObtenerPuestosInstitucionales()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerPuestosInstitucionales());
            List<EtcatPuestos> lsResultado = UtilTablas.ConvertirDataTableToList<EtcatPuestos>(table);
            return lsResultado;
        }
        public List<EcatNivelesPuestos> ObtenerNivelesPuestosInstitucionales()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerNivelesPuestosInstitucionales());
            List<EcatNivelesPuestos> lsResultado = UtilTablas.ConvertirDataTableToList<EcatNivelesPuestos>(table);
            return lsResultado;
        }
        public List<Ecatcp> ObtenerCodigoPostalMunicipio(int municipio)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerCodigoPostalMunicipio(municipio));
            List<Ecatcp> lsResultado = UtilTablas.ConvertirDataTableToList<Ecatcp>(table);
            return lsResultado;
        }
        public List<Ecatcp> ObtenerColoniasCP(string codigoPostal)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerColoniasCP(codigoPostal));
            List<Ecatcp> lsResultado = UtilTablas.ConvertirDataTableToList<Ecatcp>(table);
            return lsResultado;
        }
        public List<Ebuzonconfiguracionfiltros> BuscarFiltros(Ecattipofiltrosinicialesbuzon procedimientoAlmacenado)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.BuscarFiltros(procedimientoAlmacenado));
            List<Ebuzonconfiguracionfiltros> lsResultado = UtilTablas.ObtenerFiltrosBuzon(table, procedimientoAlmacenado);
            return lsResultado;
        }
        public EcatcpEntidadesFederativas ObtenerEntidadFederativa()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerEntidadFederativa());
            List<EcatcpEntidadesFederativas> ls = UtilTablas.ConvertirDataTableToList<EcatcpEntidadesFederativas>(table);
            return ls[0];
        }
        public List<Ecatcpmunicipios> ObtenerMunicipios(EcatcpEntidadesFederativas EntidadFederativa)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerMunicipios(EntidadFederativa));
            List<Ecatcpmunicipios> lsResultado = UtilTablas.ConvertirDataTableToList<Ecatcpmunicipios>(table);
            return lsResultado;
        }
        public Resultado InsertarUnidadAdministrativa(Etunidadadministrativa unidadAdministrativa)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (int, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TUNIDADADMINISTRATIVA);
            unidadAdministrativa.RIDUnidadAdministrativa = identificadores.Item1;
            unidadAdministrativa.BOIDUnidadAdministrativa = identificadores.Item2;
            DataTable table = setIngresar.InsertarRegistro(ScriptUnidadAdministrativa.InsertarUnidadAdministrativa(unidadAdministrativa));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            resultado.Dato = unidadAdministrativa.RIDUnidadAdministrativa;
            return resultado;
        }
        public Resultado ActualizarUnidadAdministrativa(Etunidadadministrativa unidad)
        {
            DAOUpdateorDeleteObjetosNegocio updateObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateObjetosNegocio.UpdateOrDeleteRegistro(ScriptUnidadAdministrativa.ActualizarUnidadAdministrativa(unidad));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado EliminarUnidadAdministrativa(Etunidadadministrativa unidad)
        {
            DAOUpdateorDeleteObjetosNegocio deleteObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = deleteObjetosNegocio.UpdateOrDeleteRegistro(ScriptUnidadAdministrativa.EliminarUnidadAdministrativa(unidad));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public List<Ecataplicaciones> ObtenerAplicaciones()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerAplicaciones());
            List<Ecataplicaciones> lsResultado = UtilTablas.ConvertirDataTableToList<Ecataplicaciones>(table);
            return lsResultado;
        }
        public DataTable ObtenerParametros()
        {
            DataTable tablaParametros = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerParametros());
            return tablaParametros;
        }
        public List<Ecattipofiltrosinicialesbuzon> ObtenerFiltro()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerFiltros());
            List<Ecattipofiltrosinicialesbuzon> lsResultado = UtilTablas.ConvertirDataTableToList<Ecattipofiltrosinicialesbuzon>(table);
            return lsResultado;
        }
        public Resultado IngresarBuzon(Ebuzonesconfiguracion buzonConfiguracion)
        {
            DAOSetObjetosNegocio daoSet = new DAOSetObjetosNegocio();
            (int, string) identificadoresBuzon = daoSet.ObtenerIdentificadoresPSR(TablasAdministracion.BUZON_CONFIGURACION);
            buzonConfiguracion.RIDBuzon = identificadoresBuzon.Item1;
            buzonConfiguracion.BOIDBuzon = identificadoresBuzon.Item2;
            daoSet.IniciarTransaccion();
            DataTable dataTable = daoSet.InsertarRegistrosMultiples(ScriptUnidadAdministrativa.IngresarBuzonConfiguracion(buzonConfiguracion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(dataTable);
            if (resultado.ExisteError)
            {
                daoSet.DeshacerTransaccion();
                daoSet.CerrarConexion();
                return resultado;
            }
            else
            {
                foreach (Ebuzonconfiguracionfiltros filtro in buzonConfiguracion.Filtros)
                {
                    (int, string) identificadorFiltro = daoSet.ObtenerIdentificadoresPSR(TablasAdministracion.BUZONCONFIGURACIONFILTROS);
                    filtro.RID = identificadorFiltro.Item1;
                    filtro.ClaveBuzon = buzonConfiguracion.RIDBuzon;
                    dataTable = daoSet.InsertarRegistrosMultiples(ScriptUnidadAdministrativa.IngresarFiltros(filtro));
                    resultado = UtilTablas.ResultadoDesdeTabla(dataTable);
                    if (resultado.ExisteError)
                    {
                        daoSet.DeshacerTransaccion();
                        daoSet.CerrarConexion();
                        return resultado;
                    }
                }
            }
            daoSet.TerminarTransaccion();
            daoSet.CerrarConexion();
            return resultado;
        }

        #region Empleados
        public List<Etempleados> ObtenerEmpleados()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.ObtenerEmpleados());
            List<Etempleados> lsResultado = UtilTablas.ConvertirDataTableToList<Etempleados>(table);
            return lsResultado;
        }
        public Resultado IngresarEmpleado(Etempleados empleado)
        {
            DAOSetObjetosNegocio setIngresar = new DAOSetObjetosNegocio();
            (Int64, string) identificadores = setIngresar.ObtenerIdentificadoresPSR(TablasAdministracion.TEMPLEADOS);
            empleado.RIDEmpleado = identificadores.Item1;
            empleado.BOIDEmpleado = identificadores.Item2;
            DataTable table = setIngresar.InsertarRegistro(ScriptUnidadAdministrativa.IngresarEmpleado(empleado));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            resultado.Dato = empleado.RIDEmpleado;
            return resultado;
        }
        public Resultado ActualizarEmpleado(Etempleados empleado)
        {
            DAOUpdateorDeleteObjetosNegocio updateObjeto = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateObjeto.UpdateOrDeleteRegistro(ScriptUnidadAdministrativa.ActualizarEmpleado(empleado));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado EliminarEmpleado(Etempleados empleado)
        {
            DAOUpdateorDeleteObjetosNegocio updateObjeto = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateObjeto.UpdateOrDeleteRegistro(ScriptUnidadAdministrativa.EliminarEmpleado(empleado));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion

        #region implementacion
        public Etimplementacion GetImplementacion()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetImplementacion());
            List<Etimplementacion> lsResultado = UtilTablas.ConvertirDataTableToList<Etimplementacion>(table);
            Etimplementacion implementacion = lsResultado[0];

            table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetCatAplicaciones());
            List<Ecataplicaciones> lsCatalogoAplicacion = UtilTablas.ConvertirDataTableToList<Ecataplicaciones>(table);
            implementacion.Aplicaciones = lsCatalogoAplicacion;

            table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetNiveldeGobierno());
            List<EcatNivelGobierno> lsCatalogoNivelGobierno = UtilTablas.ConvertirDataTableToList<EcatNivelGobierno>(table);
            implementacion.NivelesGobierno = lsCatalogoNivelGobierno;

            return implementacion;
        }
        public List<EcatcpEntidadesFederativas> GetImpEntidadesFederativas()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetImpEntidadesFederativas());
            List<EcatcpEntidadesFederativas> lsResultado = UtilTablas.ConvertirDataTableToList<EcatcpEntidadesFederativas>(table);
            return lsResultado;
        }
        public List<Ecatcpmunicipios> GetImpMunicipios(EcatcpEntidadesFederativas entidades)
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUnidadAdministrativa.GetImpMunicipios(entidades));
            List<Ecatcpmunicipios> lsResultado = UtilTablas.ConvertirDataTableToList<Ecatcpmunicipios>(table);
            return lsResultado;
        }
        public Resultado Updatetimplementacion(Etimplementacion implementacion)
        {
            DAOUpdateorDeleteObjetosNegocio updateObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateObjetosNegocio.UpdateOrDeleteRegistro(ScriptUnidadAdministrativa.Updatetimplementacion(implementacion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        public Resultado Updatecataplicaciones(Ecataplicaciones aplicaciones)
        {
            DAOUpdateorDeleteObjetosNegocio updateObjetosNegocio = new DAOUpdateorDeleteObjetosNegocio();
            DataTable table = updateObjetosNegocio.UpdateOrDeleteRegistro(ScriptUnidadAdministrativa.Updatecataplicaciones(aplicaciones));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(table);
            return resultado;
        }
        #endregion

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
                    resultado.DetalleErrorSql = "no fueron registrados";
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
