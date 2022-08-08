const subdirectorio = ""; //Local
//const subdirectorio = "/adm"; //Publicado

const URLAPIBase = "https://localhost:44391/api/";//API LOCAL
/*const URLAPIBase = "https://slpm.d-gob.app/adm.api/api/";//API SLPM*/


const URLAPIAcceso = URLAPIBase + "Acceso/";
const CFG = URLAPIBase + "Implementacion/"; 
const EO = URLAPIBase + "EstructuraOrganizacional/"; 

// #region //////////////// ~~~~~~~~~~~~~~~~~~~~~~ NUEVA DLL ~~~~~~~~~~~~~~~~~~~~~~ ////////////////
    // #region HOME
const GetConfig = subdirectorio + "/Home/GetConfig";
const GetConfigImp = subdirectorio + "/Home/GetConfigImp";
//const GetImp = subdirectorio + "/Home/GetImplementacion";
//const GetConfiguracionARC = subdirectorio + "/Home/GetConfiguracionARC";
const GetConfiguracionARC = subdirectorio + "/Home/GetConfiguracionARC";
    // #endregion
    // #region Configuración
        //Implementación
const GetImplementacion = CFG + "GetImplementacion";
const GetImpEntidadesFederativas = CFG + "GetImpEntidadesFederativas";
const GetImpMunicipios = CFG + "GetImpMunicipios";
const ObtenerCodigoPostalMunicipio = CFG + "ObtenerCodigoPostalMunicipio";
const ObtenerColoniasCP = CFG + "ObtenerColoniasCP";
const CargarImagenLogoImplementacion = CFG + "CargarImagenImplementacion";
const Setimplementacion = CFG + "Setimplementacion";
const Updatetimplementacion = CFG + "Updatetimplementacion";
    // #endregion
    // #region Buzon Fiscal
const CargarImagenAplicacion = subdirectorio + "/UnidadAdministrativa/CargarImagenAplicacion";
const cargaImagenBuzon = subdirectorio + "/UnidadAdministrativa/cargaImagenBuzon";
const GetConfigBuzon = subdirectorio + "/UnidadAdministrativa/GetConfigBuzon";
const UpdateConfigBuzon = subdirectorio + "/UnidadAdministrativa/UpdateConfigBuzon";
    // #endregion
    // #region Estructura Organizacional
        // #region Niveles de mando
const ConsultarNivelPuesto = EO + "ObtenerNivelPuestoInstitucional";
const ObtenerNivelXPuesto = EO + "ObtenerNivelXPuesto";
const IngresarNivelPuesto = EO + "IngresarNivelesPuesto";
const ActualizarNivelesPuesto = EO + "ActualizarNivelesPuesto";
const EliminarNivelesPuesto = EO + "EliminarNivelesPuesto";
        // #endregion
        // #region Puestos Institucionales
const ConsultaPuesto = EO + "ConsultaPuesto";
const ObtenerPuestosXUnidad = EO + "ObtenerPuestosXUnidad";
const IngresarPuesto = EO + "IngresarPuesto";
const ActualizarPuesto = EO + "ActualizarPuesto";
const EliminarPuesto = EO + "EliminarPuesto";
        // #endregion
        // #region Empleados
//const ObtenerEmpleado = subdirectorio + "/EstructuraOrganizacional/ObtenerEmpleado"; 
const ObtenerEmpleado = EO + "ObtenerEmpleado"; 
const RFCDisponibleEmpleadoNew = EO + "RFCDisponibleEmpleadoNew";
const RFCDisponibleEmpleado = EO + "RFCDisponibleEmpleado";
const ObtenerClaveEmpleadoNew = EO + "ObtenerClaveEmpleadoNew";
const ObtenerClaveEmpleado = EO + "ObtenerClaveEmpleado";
const ObtenerEmpleadosXUnidad = EO + "ObtenerEmpleadosXUnidad";
const ObtenerEmpleadosXPuesto = EO + "ObtenerEmpleadosXPuesto";
const CargarImagenEmpleado = EO + "CargarImagenEmpleado";
const IngresarEmpleado = EO + "IngresarEmpleado";
const ActualizarEmpleado = EO + "ActualizarEmpleado";
const EliminarEmpleado = EO + "EliminarEmpleado";
        // #endregion
        // #region Unidades Administrativas
const ObtenerUnidadesAdministrativas = EO + "ObtenerUnidadesAdministrativas";
const GetUnidadAdmActiva = EO + "GetUnidadAdmActiva";
const datosOrganigrama = EO + "datosOrganigrama";
const ObtenerOrganigrama = EO + "ObtenerOrganigrama";
const ObtenerEntidadFederativa = EO + "ObtenerEntidadFederativa";
const ObtenerMunicipios = EO + "ObtenerMunicipios";
const ObtenerAplicaciones = EO + "ObtenerAplicacion"; 
const CargarImagenLogoUnidadAdministrativa = EO + "CargarImagenLogoUnidadAdministrativa";
const CargarLogoDeAplicaciones = EO + "CargarLogoDeAplicaciones";
const ObtenerFiltro = EO + "ObtenerFiltro";
const BuscarFiltro = EO + "BuscarFiltros";
const InsertarUnidadAdministrativa = EO + "InsertarUnidadAdministrativa";
const ObtenerUnidadesHijas = EO + "ObtenerUnidadesHijas";
const BuzonesXUA = EO + "BuzonesXUA";
const FiltrosXBuzon = EO + "FiltrosXBuzon";
const ObtenerBuzonFiltrosInicial = EO + "ObtenerBuzonFiltrosInicial";
const EliminarUnidadAdministrativa = EO + "EliminarUnidadAdministrativa";
const ActualizarUnidadAdministrativa = EO + "ActualizarUnidadAdministrativa";
        // #endregion
        // #region Usuarios
const GetUsuarios = EO + "GetUsuarios"; 
const ObtenerUsuariosActivos = subdirectorio + "/EstructuraOrganizacional/ObtenerUsuariosActivos";
const ObtenerUsuariosActivosXU = subdirectorio + "/EstructuraOrganizacional/ObtenerUsuariosActivosXU";
const ObtenerUsuariosXUnidadA = EO + "ObtenerUsuariosXUnidadA";
const ObtenerFirmantes = subdirectorio + "/EstructuraOrganizacional/ObtenerFirmantes";
const ObtenerFirmantesXU = subdirectorio + "/EstructuraOrganizacional/ObtenerFirmantesXU"; 
const ObtenerFirmantesActivos = subdirectorio + "/EstructuraOrganizacional/ObtenerFirmantesActivos"; 
const getNewUsuarios = EO + "getNewUsuarios"; 
const UsuariosExistentes = EO + "UsuariosExistentes";
const GetTableRelacionERB = subdirectorio + "/EstructuraOrganizacional/GetTableRelacionERB";
const AplicacionesxUnidad = EO + "AplicacionesxUnidad";
const IngresarUsuario = EO + "IngresarUsuario"; 
const UpdateUser = EO + "UpdateUser";
const UpdateUserPW = EO + "UpdateUserPW";
const ReactivaUsuario = EO + "ReactivaUsuario";
const DownUsuarioyRelacionesRolBuzon = EO + "DownUsuarioyRelacionesRolBuzon";
const DeleteUsuarioyRelacionesRolBuzon = EO + "DeleteUsuarioyRelacionesRolBuzon";        
        //Usuarios-Roles
const RolesXNivelPuesto = EO + "RolesXNivelPuesto";
const insertaRolesEmpleado = EO + "insertaRolesEmpleado";
const EliminaRolTeporal = EO + "EliminaRolTeporal"; 
        //Buzones-Aplicaciones
const AplicacionXUnidad = subdirectorio + "/EstructuraOrganizacional/AplicacionXUnidad"; 
const BuzonesEmpleado = EO + "BuzonesEmpleado"; 
const BuzonesDeUsuario = subdirectorio + "/EstructuraOrganizacional/BuzonesDeUsuario"; 
const RolesXBuzon = EO + "RolesXBuzon"; 
const GetDatosTablaTemporalERB = EO + "GetDatosTablaTemporalERB";
const EliminaTablaTeporal = EO + "EliminaTablaTeporal";
const UsuariosSetDatosUsuariosTablaTemporal = EO + "UsuariosSetDatosUsuariosTablaTemporal"; 
const relacionesEliminadasTablaTemporal = EO + "relacionesEliminadasTablaTemporal";
const relacionesNuevasTablaTemporal = EO + "relacionesNuevasTablaTemporal";
const relacionesUBEliminadasTablaTemporal = EO + "relacionesUBEliminadasTablaTemporal";
const relacionesUBNuevasTablaTemporal = EO + "relacionesUBNuevasTablaTemporal";
        // #endregion
        // #region Desbloqueo de cuentas
const busquedaUserID = EO + "busquedaUserID";
const desbloquearUserID = EO + "desbloquearUserID";
        // #endregion
        // #region Grupos de Atención
const ObtenerBuzon = EO + "ObtenerBuzonesConfiguracion";
const ObtenerUsuariosYEmpleados = EO + "ObtenerUsuariosYEmpleados";
        // #endregion

    // #region Configuración de Roles
        // #region RolesPorNivelDeMando
const GetRolesXNivel = subdirectorio + "/ConfiguracionRoles/GetRolesXNivel";
const ObtenerNivelMando = subdirectorio + "/ConfiguracionRoles/ObtenerNivelMando"; 
const RolesDeNivel = subdirectorio + "/ConfiguracionRoles/RolesDeNivel"; 
const rolesAsignables = subdirectorio + "/ConfiguracionRoles/rolesAsignables"; 
const DetalleDeLosRoles = subdirectorio + "/ConfiguracionRoles/DetalleDeLosRoles"; 
const setNivelRol = subdirectorio + "/ConfiguracionRoles/setNivelRol";
const eliminaRolAsignado = subdirectorio + "/ConfiguracionRoles/eliminaRolAsignado";
        // #endregion
        // #region ModulosYCaracteristicas
const Getcataplicaciones = subdirectorio + "/ConfiguracionRoles/Getcataplicaciones"; 
const GetTodosLosRoles = subdirectorio + "/ConfiguracionRoles/GetTodosLosRoles";
const obtenerRolXAplicacion = subdirectorio + "/ConfiguracionRoles/obtenerRolXAplicacion";
const setNewRol = subdirectorio + "/ConfiguracionRoles/setNewRol"; 
const DeleteRolyRelacionesRol = subdirectorio + "/ConfiguracionRoles/DeleteRolyRelacionesRol";
const GetNewRol = subdirectorio + "/ConfiguracionRoles/GetNewRol";
const GetModulosXAplicacion = subdirectorio + "/ConfiguracionRoles/GetModulosXAplicacion";
const GetModulosCXRol = subdirectorio + "/ConfiguracionRoles/GetModulosCXRol"; 
const GetAccionXRol = subdirectorio + "/ConfiguracionRoles/GetAccionXRol";
const Roles_SetAccesosM = subdirectorio + "/ConfiguracionRoles/Roles_SetAccesosM";
const Roles_SetAccesosMC = subdirectorio + "/ConfiguracionRoles/Roles_SetAccesosMC"; 
const Roles_SetAccesosAll = subdirectorio + "/ConfiguracionRoles/Roles_SetAccesosAll"; 
const EliminarRaccesoRol = subdirectorio + "/ConfiguracionRoles/EliminarRaccesoRol";
const UpdateCatRol = subdirectorio + "/ConfiguracionRoles/UpdateCatRol";
        // #endregion
    // #endregion
    // #region Administracion de aplicaciones
        // #region Administracion
const ObtenerAplicacionesDeUnidad = subdirectorio + "/Aplicaciones/ObtenerAplicacionesDeUnidad";
const ActualizarAplicacionActivo = subdirectorio + "/Aplicaciones/ActualizarAplicacionActivo";
const ActualizarAplicacionDesactivada = subdirectorio + "/Aplicaciones/ActualizarAplicacionDesactivada";
        // #endregion
    // #endregion
    // #region Pistas de Auditoria
const GetUsuariosXUnidad = subdirectorio + "/PistasDeAuditoria/GetUsuariosXUnidad";
    // #endregion

var Administracion = {};

    //HOME
Administracion.HomeController = {
    GetConfig,
    GetConfigImp,
    GetImp: GetImplementacion, //Herencia de implementacion
    GetConfiguracionARC
}
    //Configuración
        //Implementación
Administracion.Implementacion = {
    GetImplementacion,
    GetImpEntidadesFederativas,
    GetImpMunicipios,
    ObtenerCodigoPostalMunicipio,
    ObtenerColoniasCP,
    Setimplementacion,
    Updatetimplementacion,
    CargarImagenLogoImplementacion //Fuera de la dll
}
    //Estructura Organizacional
        //Niveles de Mando
Administracion.NivelPuesto = {
    Consulta: ConsultarNivelPuesto,
    ConsultaP: ConsultaPuesto, //Herencia Puestos Institucionales
    Ingresar: IngresarNivelPuesto,
    Eliminar: EliminarNivelesPuesto,
    Actualizar: ActualizarNivelesPuesto
}
        //Puestos Institucionales
Administracion.PuestosInstitucionales = {
    Consulta: ConsultaPuesto,
    ObtenerPuestosXUnidad: ObtenerPuestosXUnidad,
    Ingresar: IngresarPuesto,
    Actualizar: ActualizarPuesto,
    Eliminar: EliminarPuesto,
    ConsultaUnidades: ObtenerUnidadesAdministrativas, //Herencia Unidades administrativas
    ConsultarNivelPuesto: ConsultarNivelPuesto, //Herencia Niveles de mando
    ObtenerEmpleado: ObtenerEmpleado//Herencia Empleados
}
        //Empleados
Administracion.Empleados = {
    GetUnidadAdmActiva: GetUnidadAdmActiva, //Herencia Unidades administrativas
    ObtenerEmpleado: ObtenerEmpleado,
    RFCDisponibleEmpleadoNew: RFCDisponibleEmpleadoNew,
    RFCDisponibleEmpleado: RFCDisponibleEmpleado,
    ConsultaPuesto: ConsultaPuesto, //Herencia Puestos Institucionales
    ObtenerNivelXPuesto: ObtenerNivelXPuesto, //Herencia Niveles de mando
    ObtenerPuestosXUnidad: ObtenerPuestosXUnidad, //Herencia Puestos Institucionales
    ObtenerClaveEmpleadoNew: ObtenerClaveEmpleadoNew,
    ObtenerClaveEmpleado: ObtenerClaveEmpleado,
    ObtenerEmpleadosXUnidad: ObtenerEmpleadosXUnidad,
    ObtenerEmpleadosXPuesto: ObtenerEmpleadosXPuesto,
    CargarImagenEmpleado: CargarImagenEmpleado,
    IngresarEmpleado: IngresarEmpleado,
    ActualizarEmpleado: ActualizarEmpleado,
    EliminarEmpleado: EliminarEmpleado
}
        //Unidades Administrativas
Administracion.Unidades = {
    Consulta: ObtenerUnidadesAdministrativas,
    datosOrganigrama: datosOrganigrama,
    ObtenerOrganigrama: ObtenerOrganigrama,
    ConsultaEntidadFederativa: ObtenerEntidadFederativa,
    ConsultaMunicipios: ObtenerMunicipios,
    ObtenerAplicaciones: ObtenerAplicaciones,
    CargarImagenLogoUnidadAdministrativa: CargarImagenLogoUnidadAdministrativa,
    ConsultaCodigoPostalMunicipio: ObtenerCodigoPostalMunicipio, //Herencia implementación
    ConsultarColoniaDesdeCP: ObtenerColoniasCP, //Herencia implementación
    CargarLogoDeAplicaciones: CargarLogoDeAplicaciones,
    ObtenerFiltro: ObtenerFiltro,
    BuscarFiltro: BuscarFiltro,
    ConsultaPuesto: ConsultaPuesto, //Herencia Puestos
    ConsultarNivelPuesto: ConsultarNivelPuesto,//Herencia Puestos
    CargarImagenEmpleado: CargarImagenEmpleado, //Herencia de empleados    
    RFCDisponibleEmpleado: RFCDisponibleEmpleado, //Herencia empleados
    ObtenerClaveEmpleado: ObtenerClaveEmpleado, //Herencia empleados
    Ingresar: InsertarUnidadAdministrativa,
    ObtenerUnidadesHijas: ObtenerUnidadesHijas,
    BuzonesXUA: BuzonesXUA,
    EmpleadosXUnidad: ObtenerEmpleadosXUnidad, //Herencia empleados
    ConsultaPuesto: ConsultaPuesto, //Herencia Puestos Institucionales
    FiltrosXBuzon: FiltrosXBuzon,
    Eliminar: EliminarUnidadAdministrativa,
    ObtenerPuestosXUnidad: ObtenerPuestosXUnidad, //Herencia Puestos Institucionales
    GetUnidadAdmActiva: GetUnidadAdmActiva,
    ObtenerNivelXPuesto: ObtenerNivelXPuesto,//Herencia niveles de mando
    Actualizar: ActualizarUnidadAdministrativa,
    ////Buzon Fiscal 
    CargarImagenLogoImplementacion,
    CargarImagenAplicacion,
    cargaImagenBuzon,
    GetConfigBuzon,
    UpdateConfigBuzon,
}
        //Usuarios
Administracion.Usuarios = {
    GetUnidadAdmActiva: GetUnidadAdmActiva, //Herencia Unidades administrativas
    ObtenerUsuariosXUnidadA: ObtenerUsuariosXUnidadA,
    GetUsuarios: GetUsuarios,
    ObtenerUsuariosActivos: ObtenerUsuariosActivos,
    ObtenerUsuariosActivosXU: ObtenerUsuariosActivosXU,    
    ObtenerFirmantes: ObtenerFirmantes,
    ObtenerFirmantesXU: ObtenerFirmantesXU,
    ObtenerFirmantesActivos: ObtenerFirmantesActivos,
    getNewUsuarios: getNewUsuarios,
    UsuariosExistentes: UsuariosExistentes,
    GetTableRelacionERB: GetTableRelacionERB,
    AplicacionesxUnidad: AplicacionesxUnidad,
    RolesXNivelPuesto: RolesXNivelPuesto,
    GetDatosTablaTemporalERB: GetDatosTablaTemporalERB,
    IngresarUsuario: IngresarUsuario,
    UpdateUser: UpdateUser,
    UpdateUserPW: UpdateUserPW,
    insertaRolesEmpleado: insertaRolesEmpleado,
    BuzonesEmpleado: BuzonesEmpleado,
    BuzonesDeUsuario: BuzonesDeUsuario,
    RolesXBuzon: RolesXBuzon,
    ReactivaUsuario: ReactivaUsuario,
    DownUsuarioyRelacionesRolBuzon: DownUsuarioyRelacionesRolBuzon,
    DeleteUsuarioyRelacionesRolBuzon: DeleteUsuarioyRelacionesRolBuzon,
    EliminaTablaTeporal: EliminaTablaTeporal,
    EliminaRolTeporal: EliminaRolTeporal,
    DatosUsuariosTablaTemporal: UsuariosSetDatosUsuariosTablaTemporal,
    relacionesEliminadasTablaTemporal: relacionesEliminadasTablaTemporal,
    relacionesNuevasTablaTemporal: relacionesNuevasTablaTemporal,
    relacionesUBEliminadasTablaTemporal: relacionesUBEliminadasTablaTemporal,
    relacionesUBNuevasTablaTemporal: relacionesUBNuevasTablaTemporal,
    ObtenerEmpleado: ObtenerEmpleado
}
        //Desbloqueo de cuentas
Administracion.Cuentas = {
    GetUnidadAdmActiva: GetUnidadAdmActiva, //Herencia Unidades administrativas
    busquedaUserID: busquedaUserID,
    desbloquearUserID: desbloquearUserID,
}
        //Grupos de atención
Administracion.GruposAtencion = {
    ObtenerBuzon: ObtenerBuzon,
    ObtenerUsuariosYEmpleados: ObtenerUsuariosYEmpleados,
    //IngresarGrupoAtencion: IngresarGrupoAtencion
}

    //Configuración de Roles
        //RolesPorNivelDeMando //ModulosYCaracteristicas
Administracion.ConfiguracionRoles = {
    //RolesPorNivelDeMando
    ObtenerNivelMando: ObtenerNivelMando,
    GetRolesXNivel: GetRolesXNivel,
    RolesDeNivel: RolesDeNivel,
    rolesAsignables: rolesAsignables,
    DetalleDeLosRoles: DetalleDeLosRoles,
    setNivelRol: setNivelRol,
    eliminaRolAsignado: eliminaRolAsignado,

    //ModulosYCaracteristicas
    Getcataplicaciones: Getcataplicaciones,
    GetTodosLosRoles: GetTodosLosRoles,
    obtenerRolXAplicacion: obtenerRolXAplicacion,
    setNewRol: setNewRol,
    DeleteRolyRelacionesRol: DeleteRolyRelacionesRol,
    GetNewRol: GetNewRol,
    GetModulosXAplicacion: GetModulosXAplicacion,
    GetModulosCXRol: GetModulosCXRol,
    GetAccionXRol: GetAccionXRol,
    Roles_SetAccesosM: Roles_SetAccesosM,
    Roles_SetAccesosMC: Roles_SetAccesosMC,
    Roles_SetAccesosAll: Roles_SetAccesosAll,
    EliminarRaccesoRol: EliminarRaccesoRol,
    UpdateCatRol: UpdateCatRol
}
    //AdministracionAplicaciones
        //Administracion
Administracion.Administracion = {
    ObtenerAplicaciones: ObtenerAplicacionesDeUnidad,
    ActualizarActivo: ActualizarAplicacionActivo,
    ActualizarDesactivado: ActualizarAplicacionDesactivada,
}
    //PistasDeAuditoria
Administracion.Auditoria = {
    GetaplicacionesPSR: Getcataplicaciones, //Herencia de ModulosYCaracteristicas
    GetUsuariosXUnidad: GetUsuariosXUnidad,
}

// #region //////////////// ~~~~~~~~~~~~~~~~~~~~~~ VIEJA DLL ~~~~~~~~~~~~~~~~~~~~~~ ////////////////

//Configuración
    //Días Inhabiles
const GetMotivoDiasInhabil = subdirectorio + "/Dias/GetMotivoDiasInhabil";
const SetMotivoDiasInhabil = subdirectorio + "/Dias/SetMotivoDiasInhabil";
const UpdateMotivoDiasInhabil = subdirectorio + "/Dias/UpdateMotivoDiasInhabil";
const GetCatDiasInhabiles = subdirectorio + "/Dias/GetCatDiasInhabiles";
const SetCatDiasInhabiles = subdirectorio + "/Dias/SetCatDiasInhabiles";
const UpdateCatDiasInhabiles = subdirectorio + "/Dias/UpdateCatDiasInhabiles";
const DeleteCatDiasInhabiles = subdirectorio + "/Dias/DeleteCatDiasInhabiles";
const GetDescriptivoItems = subdirectorio + "/Dias/GetDescriptivoItems";



//Configuración
    //Días Inhabiles
Administracion.DiasInhabiles = {
    GetMotivoDiasInhabil,
    SetMotivoDiasInhabil,
    UpdateMotivoDiasInhabil,

    GetImplementacion: GetImplementacion,
    GetImpEntidadesFederativas: GetImpEntidadesFederativas,
    GetImpMunicipios: GetImpMunicipios,

    GetCatDiasInhabiles,
    SetCatDiasInhabiles,
    UpdateCatDiasInhabiles,
    DeleteCatDiasInhabiles,
    GetDescriptivoItems
}

// #endregion

// #region //////////////// ~~~~~~~~~~~~~~~~~~~~~~ DESCONOCIDO ~~~~~~~~~~~~~~~~~~~~~~ ////////////////

/*const InsertarUnidadAdministrativa = subdirectorio + "/UnidadAdministrativa/InsertarUnidadAdministrativa";*/

const IngresarBuzon = subdirectorio + "/UnidadAdministrativa/IngresarBuzon/";
const GetTemas = subdirectorio + "/UnidadAdministrativa/GetTemas";
const GetModos = subdirectorio + "/UnidadAdministrativa/GetModos";

//const CargarImagenLogoImplementacion = subdirectorio + "/UnidadAdministrativa/CargarImagenImplementacion";
//const CargarImagenAplicacion = subdirectorio + "/UnidadAdministrativa/CargarImagenAplicacion";
//const cargaImagenBuzon = subdirectorio + "/UnidadAdministrativa/cargaImagenBuzon";
//const GetConfigBuzon = subdirectorio + "/UnidadAdministrativa/GetConfigBuzon";
//const UpdateConfigBuzon = subdirectorio + "/UnidadAdministrativa/UpdateConfigBuzon";
//Agrupadores y Clasificadores 
const ConsultarClasificadores = subdirectorio + "/Clasificadores/ConsultarClasidicadores";
const IngresarAgrupador = subdirectorio + "/Clasificadores/IngresarAgrupador";
const ConsultarAgrupadores = subdirectorio + "/Clasificadores/ConsultarAgrupadores";
const ActualizarAgrupador = subdirectorio + "/Clasificadores/ActualizarAgrupador";
const IngresarClasificador = subdirectorio + "/Clasificadores/IngresarClasificador";
const ActuaizarClasificador = subdirectorio + "/Clasificadores/ActuaizarClasificador";
const EliminarClasificador = subdirectorio + "/Clasificadores/EliminarClasificador";
const CargarImagenIcono = subdirectorio + "/Clasificadores/CargarImagenIcono";
    //Controlador Buzones
    //Buzones
    
    const ObtenerRoles = subdirectorio + "/Buzon/ObtenerRoles";
//Controlador Auxiliares
const ObtenerEstatusBuzon = subdirectorio + "/ConsultasAuxiliares/ObtenerEstatusBuzon";
const GetTipoServicio = subdirectorio + "/ConsultasAuxiliares/GetTipoServicio";
const GetTipoCaso = subdirectorio + "/ConsultasAuxiliares/GetTipoCaso";
const ClasificacionCaso = subdirectorio + "/ConsultasAuxiliares/ClasificacionCaso";
const GetTipoResultado = subdirectorio + "/ConsultasAuxiliares/GetTipoResultado";
//Controlador Usuarios
/*const IngresarGrupoAtencion = subdirectorio + "/Usuarios/IngresarGrupoAtencion";*/
//const ObtenerProcesosYEtapas = subdirectorio + "/ConfiguracionCasos/ObtenerProcesosYEtapas";
//Controlador WFDefinicion
const GetWorkFlowDefinicion = subdirectorio + "/WorkFlow/GetWorkFlowDefinicion";
const SetWorkFlowDefinicion = subdirectorio + "/WorkFlow/SetWorkFlowDefinicion";
const UpdateWorkFlowDefinicion = subdirectorio + "/WorkFlow/UpdateWorkFlowDefinicion"
const GetWorkFlowProceso = subdirectorio + "/WorkFlow/GetWorkFlowProceso";
const SetWorkFlowProceso = subdirectorio + "/WorkFlow/SetWorkFlowProceso";
const UpdateWorkFlowProceso = subdirectorio + "/WorkFlow/UpdateWorkFlowProceso";
const GetwfCatAcciones = subdirectorio + "/WorkFlow/GetwfCatAcciones";
const GetWorkFlowProcesosEtapas = subdirectorio + "/WorkFlow/GetWorkFlowProcesosEtapas";
const SetWorkFlowProcesosEtapas = subdirectorio + "/WorkFlow/SetWorkFlowProcesosEtapas";
const UpdateWorkProcesosEtapas = subdirectorio + "/WorkFlow/UpdateWorkProcesosEtapas";
//Controlador ClasificacionSujetosObjetos
const ConsultarTipoSujetosObjetos = subdirectorio + "/CumplimientoAcciones/ConsultarTipoSujetosObjetos";
const IngresarTipoSujetosObjetos = subdirectorio + "/CumplimientoAcciones/IngresarTipoSujetosObjetos";
const ConsultarClasificadoresClasificacion = subdirectorio + "/CumplimientoAcciones/ConsultarClasificadores";
const ConsultarClasificadoresClasificacionMultipleSeleccion = subdirectorio + "/CumplimientoAcciones/ConsultarClasificadoresMultipleSeleccion";
const cargaArchivoTXT = subdirectorio + "/CumplimientoAcciones/cargaArchivoTXT";
const IngresarClasificacion = subdirectorio + "/CumplimientoAcciones/IngresarClasificacion";
const ConsultarObjetosClasificados = subdirectorio + "/CumplimientoAcciones/ConsultarObjetosClasificados";
const ConsultarObjetosClasificadosMultipleSeleccion = subdirectorio + "/CumplimientoAcciones/ConsultarObjetosClasificadosMultipleSeleccion";
const EliminaClasificacion = subdirectorio + "/CumplimientoAcciones/EliminaClasificacion";

//--
const GetPreview = subdirectorio + "/ConsultasAuxiliares/GetPreview";
const caracterComillas = "&#34;";
const caracterComilla = "&#39;";
const caracterIgual = "&#61;";
const caracterCorcheteA = "&#91;";
const caracterCorcheteC = "&#93;";
const caracterLlaveA = "&#123;";
const caracterLlaveC = "&#125;";
const caracterPIE = "&#124;";
const caracterPunyCom = "&#59;";
const caracter2Puntos = "&#58;";
const caracterComillasC = "/\"/gi";
const caracterComillaC = "/'/gi";
const caracterIgualC = "/=/gi";
const caracterCorcheteAC = "/[/gi";
const caracterCorcheteCC = "/]/gi";
const caracterLlaveAC = "/{/gi";
const caracterLlaveCC = "/}/gi";
const caracterPIEC = "/|/gi";
const caracterPunyComC = "/;/gi";
const caracter2PuntosC = "/:/gi";
//Controlador Configuracion casos
const GetCatTipoServicios = subdirectorio + "/ConfiguracionCasos/GetCatTipoServicios";
const SetCatTipoServicios = subdirectorio + "/ConfiguracionCasos/SetCatTipoServicios";
const UpdateCatTipoServicios = subdirectorio + "/ConfiguracionCasos/UpdateCatTipoServicios";
const EliminarServicio = subdirectorio + "/ConfiguracionCasos/EliminarServicio";
const GetCasoConfiguracion = subdirectorio + "/ConfiguracionCasos/GetCasoConfiguracion";
const SetCasoConfiguracion = subdirectorio + "/ConfiguracionCasos/SetCasoConfiguracion";
const UpdateCasoConfiguracion = subdirectorio + "/ConfiguracionCasos/UpdateCasoConfiguracion";
const GetTcasocformatos = subdirectorio + "/ConfiguracionCasos/GetTcasocformatos";
const SetTcasocformatos = subdirectorio + "/ConfiguracionCasos/SetTcasocformatos";
const UpdateTcasocformatos = subdirectorio + "/ConfiguracionCasos/UpdateTcasocformatos";
const GetTcasoscformatoseccion = subdirectorio + "/ConfiguracionCasos/GetTcasoscformatoseccion";
const SetTcasoscformatoseccion = subdirectorio + "/ConfiguracionCasos/SetTcasoscformatoseccion";
const UpdateTcasoscformatoseccion = subdirectorio + "/ConfiguracionCasos/UpdateTcasoscformatoseccion";
const GetCatConfiguracionVariables = subdirectorio + "/ConfiguracionCasos/GetCatConfiguracionVariables";
const GetTcasoformatovariable = subdirectorio + "/ConfiguracionCasos/GetTcasoformatovariable";
const SetTcasoformatovariable = subdirectorio + "/ConfiguracionCasos/SetTcasoformatovariable";
const UpdateTcasoformatovariable = subdirectorio + "/ConfiguracionCasos/UpdateTcasoformatovariable";
const Getrccasoformatos = subdirectorio + "/ConfiguracionCasos/Getrccasoformatos";
const Setrccasoformatos = subdirectorio + "/ConfiguracionCasos/Setrccasoformatos";
const Updaterccasoformatos = subdirectorio + "/ConfiguracionCasos/Updaterccasoformatos";
const CargarImagenServicio = subdirectorio + "/ConfiguracionCasos/CargarImagenesServicios";
const CargarPlantillaCConfiguracion = subdirectorio + "/ConfiguracionCasos/CargarPlantillaCConfiguracion";

//------------------------------------------
const CargarAcuseCConfiguracion = subdirectorio + "/ConfiguracionCasos/CargarAcuseCConfiguracion"
const ConsultarClasificadoresCasos = subdirectorio + "/ConfiguracionCasos/ConsultarClasificadores";
const ConsultaGrupoClas = subdirectorio + "/ConfiguracionCasos/GetCasosAgrupadoresClasificadores";
const Gettcasosconfiguraciontiporespuestas = subdirectorio + "/ConfiguracionCasos/Gettcasosconfiguraciontiporespuestas";
const InsertarCasosAgrupadorClasificador = subdirectorio + "/ConfiguracionCasos/InsertarCasosAgrupadorClasificador";
const Settcasosconfiguraciontiporespuestas = subdirectorio + "/ConfiguracionCasos/Settcasosconfiguraciontiporespuestas";
const UpdateStatusCConfiguracion = subdirectorio + "/ConfiguracionCasos/UpdateStatusCConfiguracion";
const UpdateGrupoClasificadorCaso = subdirectorio + "/ConfiguracionCasos/UpdateGrupoClasificadorCaso";
const Updatetcasosconfiguraciontiporespuestas = subdirectorio + "/ConfiguracionCasos/Updatetcasosconfiguraciontiporespuestas";
const EliminarCasosAgrupadorClasificadorModal = subdirectorio + "/ConfiguracionCasos/EliminarCasosAgrupadorClasificadorModal";
const GetUsuario = subdirectorio + "/ConfiguracionCasos/GetUsuario";
const GetUACasoConfiguracion = subdirectorio + "/ConfiguracionCasos/GetUACasoConfiguracion";
const GetListUACasoConfiguracion = subdirectorio + "/ConfiguracionCasos/GetListUACasoConfiguracion";
const GetListCasoUnidad = subdirectorio + "/ConfiguracionCasos/GetListCasoUnidad";
const SetUnidadCCaso = subdirectorio + "/ConfiguracionCasos/SetUnidadCCaso";
const DeleteUnidadCCaso = subdirectorio + "/ConfiguracionCasos/DeleteUnidadCCaso";

const EliminarFormatos = subdirectorio + "/ConfiguracionCasos/EliminarFormatos";
const EliminarRespuestas = subdirectorio + "/ConfiguracionCasos/EliminarRespuestas";
const EliminarVariables = subdirectorio + "/ConfiguracionCasos/EliminarVariables";
const EliminarDocumentos = subdirectorio + "/ConfiguracionCasos/EliminarDocumentos";


const GetCatTipoDocumentos = subdirectorio + "/ConfiguracionCasos/GetCatTipoDocumentos";
const GetDocumentByCase = subdirectorio + "/ConfiguracionCasos/GetDocumentByCase";
const SetCatTipoDocumentos = subdirectorio + "/ConfiguracionCasos/SetCatTipoDocumentos";
const UpdateCatTipoDocumentos = subdirectorio + "/ConfiguracionCasos/UpdateCatTipoDocumentos";
const GetlstTipoArchivo = subdirectorio + "/ConfiguracionCasos/GetlstTipoArchivo";
const GetlstExtenciones = subdirectorio + "/ConfiguracionCasos/GetlstExtenciones";
const GetRarchivoExtenciones = subdirectorio + "/ConfiguracionCasos/GetRarchivoExtenciones";
const GetFirmantes = subdirectorio + "/ConfiguracionCasos/GetFirmantes";
const SetCCasoDocumento = subdirectorio + "/ConfiguracionCasos/SetCCasoDocumento";
const GetDescriptivoPrioridad = subdirectorio + "/ConfiguracionCasos/GetDescriptivoItems";






Administracion.AgrupadoresClasificadores = {
    ConsultarClasificadores,
    ConsultarAgrupadores,
    IngresarAgrupador,
    EliminarClasificador,
    ActuaizarClasificador,
    IngresarClasificador,
    ActualizarAgrupador,
    CargarImagenIcono
}

Administracion.ConfiguracionCasos = {
    GetDescriptivoPrioridad,
    GetCatTipoDocumentos,
    GetDocumentByCase,
    SetCatTipoDocumentos,
    UpdateCatTipoDocumentos,
    GetFirmantes,
    SetCCasoDocumento,

    GetCatTipoServicios,
    SetCatTipoServicios,
    UpdateCatTipoServicios,
    EliminarServicio,
    GetTipoServicio,
    GetTipoCaso,
    ClasificacionCaso,
    GetWorkFlowDefinicion,
    GetTipoResultado,
    GetCasoConfiguracion,
    SetCasoConfiguracion,
    UpdateCasoConfiguracion,
    GetTcasocformatos,
    SetTcasocformatos,
    UpdateTcasocformatos,
    GetTcasoscformatoseccion,
    SetTcasoscformatoseccion,
    UpdateTcasoscformatoseccion,
    GetCatConfiguracionVariables,
    GetTcasoformatovariable,
    SetTcasoformatovariable,
    UpdateTcasoformatovariable,
    Getrccasoformatos,
    Setrccasoformatos,
    Updaterccasoformatos,
    Gettcasosconfiguraciontiporespuestas,
    Settcasosconfiguraciontiporespuestas,
    Updatetcasosconfiguraciontiporespuestas,
    GetPreview,
    CargarImagenServicio,
    //Agrupadores y Clasificadores para Configuracion de Casos
    ConsultarClasificadoresCasos,
    InsertarCasosAgrupadorClasificador,
    EliminarCasosAgrupadorClasificadorModal,
    UpdateGrupoClasificadorCaso,
    ConsultaGrupoClas,
    UpdateStatusCConfiguracion,
    CargarPlantillaCConfiguracion,
    CargarAcuseCConfiguracion,
    //Unidades Administrativas para Configuracion de Casos
    GetUACasoConfiguracion,
    GetListUACasoConfiguracion,
    GetUsuario,
    GetListCasoUnidad,
    SetUnidadCCaso,
    DeleteUnidadCCaso,

    EliminarVariables,
    EliminarRespuestas,
    EliminarFormatos,
    EliminarDocumentos,

    GetlstTipoArchivo,
    GetlstExtenciones,
    GetRarchivoExtenciones


}

Administracion.WorkFlow = {
    SetWorkFlowDefinicion: SetWorkFlowDefinicion,
    GetWorkFlowDefinicion: GetWorkFlowDefinicion,
    UpdateWorkFlowDefinicion: UpdateWorkFlowDefinicion,
    GetWorkFlowProceso: GetWorkFlowProceso,
    SetWorkFlowProceso: SetWorkFlowProceso,
    UpdateWorkFlowProceso: UpdateWorkFlowProceso,
    GetwfCatAcciones: GetwfCatAcciones,
    GetWorkFlowProcesosEtapas: GetWorkFlowProcesosEtapas,
    SetWorkFlowProcesosEtapas: SetWorkFlowProcesosEtapas,
    UpdateWorkProcesosEtapas: UpdateWorkProcesosEtapas
}



Administracion.Buzon = {
    ObtenerBuzon: ObtenerBuzon,
    ObtenerAplicaciones: ObtenerAplicaciones,
    ObtenerEstatusBuzon: ObtenerEstatusBuzon
}

Administracion.ClasificacionSujetos = {
    ConsultarTipoSujetosObjetos,
    IngresarTipoSujetosObjetos,
    ConsultarClasificadoresClasificacion,
    ConsultarClasificadoresClasificacionMultipleSeleccion,
    ConsultarObjetosClasificadosMultipleSeleccion,
    cargaArchivoTXT,
    IngresarClasificacion,
    ConsultarObjetosClasificados,
    EliminaClasificacion
}

Administracion.CaracteresEspecioales = {
    caracterComillas,
    caracterComilla,
    caracterIgual,
    caracterCorcheteA,
    caracterCorcheteC,
    caracterLlaveA,
    caracterLlaveC,
    caracterPIE,
    caracterPunyCom,
    caracter2Puntos
}

Administracion.CaracteresEspecioalesC = {
    caracterComillasC,
    caracterComillaC,
    caracterIgualC,
    caracterCorcheteAC,
    caracterCorcheteCC,
    caracterLlaveAC,
    caracterLlaveCC,
    caracterPIEC,
    caracterPunyComC,
    caracter2PuntosC
}

//Administracion["ProcesosYEtapas"] = {
//    Consulta: ObtenerProcesosYEtapas
//}

// #endregion