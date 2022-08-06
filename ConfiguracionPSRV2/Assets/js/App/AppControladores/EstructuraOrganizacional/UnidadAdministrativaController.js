unidadAdministrativaController.controller("crtlUnidadAdministrativa", ["$scope", "$timeout", "administracionServices", "$http",
    function (vm = $scope, $timeout, administracionServices, $http) {
        let respuesta = Administracion["Unidades"];

        // #region VARIABLES
            vm.tablaView = {};
            vm.orgAnigrama = {};
            vm.EntidadFederativa = {};
            vm.UnidadAdm = {};
            vm.UnidadAdm.aplicacionPlataforma = [];            
            vm.nivelesDePuestos = [];
            vm.Puestos = [];
            vm.EmpCopy = null;
            vm.NewPuesto = {};
            vm.NewPuesto.Empleados = [];
            vm.BuzonesCopy = null;
            vm.FiltroBD = [];
            vm.seActualiza = false;
        // #endregion

        // #region DATOS PRINCIPALES
            //Llamamos datos principales
            this.$onInit = () => {
                vm.tablaView = administracionServices.MetodPOST(respuesta.Consulta);
                vm.tablaView.forEach(element => { if (element.NombreEmpleado == null) { element.NombreEmpleado = "No Asignado";} console.log(element);});
                vm.orgAnigrama = administracionServices.MetodPOST(respuesta.datosOrganigrama);
                if (vm.orgAnigrama.length != 0) {
                    vm.psrOrganigrama = administracionServices.MetodPOST(respuesta.ObtenerOrganigrama, vm.orgAnigrama);
                    console.log(vm.psrOrganigrama);
                }
                vm.EntidadFederativa = administracionServices.MetodPOST(respuesta.ConsultaEntidadFederativa);
                vm.Municipios = administracionServices.MetodPOST(respuesta.ConsultaMunicipios, vm.EntidadFederativa.RIDEntidad);
                vm.aplicaciones = administracionServices.MetodPOST(respuesta.ObtenerAplicaciones);
                $http.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(sessionStorage["ngStorage-GlobalSettings"]).Acceso.Token;
            }
            //Descarta las unidades que no son padre
            vm.FiltrarPrincipal = function (item) {
                return item.RIDUnidadAdministrativa != 0;
            };
        // #endregion

        // #region ACCIONES
            //Organigrama
            vm.ViewOrg = function () {
                document.getElementById("chart-container").innerHTML = '';
                $('#chart-container').orgchart({
                    'nodeContent': 'title',
                    'visibleLevel': 2,
                    'data': vm.psrOrganigrama,
                    'pan': true,
                    'createNode': function ($node, data) {}
                });
            };        
            //Regresa al formulario principal
            vm.MostrarListado = function () {
                vm.FiltroBD = [];
                if (vm.UnidadAdm.CodigoPostal != undefined) {
                    vm.UnidadAdm.CodigoPostal = vm.UnidadAdm.CodigoPostal.CP;
                }
                vm.UnidadAdm = null;
                vm.NewPuesto = {};
                vm.NewPuesto.Empleados = [];
                vm.aplicacionesConfiguradas = false; //Muestra aplicaciones configuradas
                vm.empleadosDeUnidad = false; //Oculta los empleados agregados
                vm.tablaUnidadesDependientes = null;
                console.log(vm.tablaView);
                MostrarFormularios();
            };
            //Muestra el formulario de Nueva Unidad Administrativa
            vm.NuevoPuesto = function () {            
                vm.btnGuardar = true;
                vm.btnAddBuzon = true;
                vm.btnAddEmpleado = true;
                vm.btnAddFiltro = true;
                vm.btnActualizar = false;
                vm.btnEliminar = false;
                vm.unidadPadre = true; //Muestra unidades padres disponibles
                vm.TitularUA = false; //Muestra las opciones de titular
                vm.unidadesHijas = false;//Muestra unidades hijas
                vm.LogoConfiguracionUA = null; //oculta imagen si no hay
                if (vm.UnidadAdm.aplicacionPlataforma == null || vm.UnidadAdm.aplicacionPlataforma== undefined) {
                    vm.aplicacionesConfiguradas = false; //Muestra aplicaciones configuradas  
                }                      
                vm.empleadosDeUnidad = false; //Oculta los empleados agregados
                vm.FiltroBuzon = []; //Limpiamos la lista de filtros seleccionados
                vm.UnidadAdm = {};
                vm.UnidadAdm.aplicacionPlataforma = [];
                vm.NewPuesto = {};
                vm.NewPuesto.Empleados = [];
                vm.FiltroBD = [];
                MostrarFormularios();
            };
            //Muestra el formulario para editar
            vm.ValidarTarea = function (objetoNegocio, tarea) {
                vm.FiltroBD = [];
                vm.buzones = null;
                vm.UnidadAdm = objetoNegocio;
                //Encuentra la "Unidad administrativa de la que depende."
                if (typeof (objetoNegocio.ClaveUAPadre) == 'object') {
                    vm.UnidadAdm.ClaveUAPadre = objetoNegocio.ClaveUAPadre;
                }
                else {
                    if (vm.UnidadAdm.ClaveUAPadre != 0 || vm.UnidadAdm.ClaveUAPadre == undefined) {
                        vm.UnidadAdm.ClaveUAPadre = vm.tablaView.find(function (element) { return (element.RIDUnidadAdministrativa === objetoNegocio.ClaveUAPadre); });
                    }
                }                
                //Oculta la sección "Unidad administrativa de la que depende." cuando la unidad no tiene padres
                if (vm.UnidadAdm.ClaveUAPadre == 0 || vm.UnidadAdm.ClaveUAPadre == undefined) {
                    vm.unidadPadre = false;
                }
                else {
                    vm.unidadPadre = true;
                }
                //Activa botones de actualizar y desactiva botones de nueva unidad
                if (tarea == 'Actualizar') {
                    vm.btnActualizar = true;
                    vm.btnEliminar = true;
                    vm.btnGuardar = false;
                    vm.unidadesHijas = true;
                }
                vm.LogoConfiguracionUA = vm.UnidadAdm.DirectorioImagenesVirtual + vm.UnidadAdm.DirectorioSecundarioLogo;
                //Encuentra datos del domicilio
                vm.UnidadAdm.municipio = vm.Municipios.find(function (element) { return (element.RIDMunicipio === objetoNegocio.ClaveMunicipio); });
                vm.CPS = administracionServices.MetodPOST(respuesta.ConsultaCodigoPostalMunicipio, objetoNegocio.ClaveMunicipio);
                vm.UnidadAdm.CodigoPostal = vm.CPS.find(function (element) {return (element.CP === objetoNegocio.CodigoPostal);});
                vm.ObtenerColonias(vm.UnidadAdm.CodigoPostal.CP);
                vm.UnidadAdm.Colonia = vm.Colonias.find(function (element) { return (element.RIDCP === objetoNegocio.ClaveCP); });
                //Unidades Administrativas dependientes
                vm.tablaUnidadesDependientes = administracionServices.MetodPOST(respuesta.ObtenerUnidadesHijas, objetoNegocio.RIDUnidadAdministrativa);
                if (vm.tablaUnidadesDependientes.length < 1 || vm.tablaUnidadesDependientes == undefined || vm.tablaUnidadesDependientes == null) {
                    vm.unidadesHijas = false;
                }
                else {
                    vm.unidadesHijas = true;                    
                    vm.tablaUnidadesDependientes.forEach(element => {
                        element.NombreEmpleado = vm.tablaView.find(function (elemento) { return (elemento.ClaveEmpleado === element.ClaveEmpleado) }).NombreEmpleado
                        if (element.NombreEmpleado == null) {
                            element.NombreEmpleado = "No Asignado";
                        }
                        console.log(element.NombreEmpleado);
                    });
                }
                //Muestra buzones asociados
                vm.UnidadAdm.aplicacionPlataforma = administracionServices.MetodPOST(respuesta.BuzonesXUA, objetoNegocio.RIDUnidadAdministrativa);
                if (vm.UnidadAdm.aplicacionPlataforma.length>0) {
                    vm.aplicacionesConfiguradas = true;
                    vm.UnidadAdm.aplicacionPlataforma.forEach(element => {
                        element.Filtros = administracionServices.MetodPOST(respuesta.FiltrosXBuzon, element.RIDBuzon);
                    });
                } else {
                    vm.aplicacionesConfiguradas = false;
                }
                //Muestra empleados asociados
                vm.NewPuesto.Empleados = administracionServices.MetodPOST(respuesta.EmpleadosXUnidad, objetoNegocio.RIDUnidadAdministrativa);
                if (vm.NewPuesto.Empleados.length > 0) {
                    vm.empleadosDeUnidad = true;
                    //Señala al titular de la unidad
                    vm.NewPuesto.Empleados.forEach(element => {if (element.RIDEmpleado == vm.UnidadAdm.ClaveEmpleado) {element.Titular = true;}});
                } else {
                    vm.empleadosDeUnidad = false;
                }
                MostrarFormularios();
            };
        // #endregion

        // #region DATOS GENERALES Y DOMICILIO
            //Carga la imagen de la Unidad Administrativa
            vm.cargaImagenRe = function () {
                vm.UnidadAdm.DirectorioSecundarioLogo = "";
                var imgTem = $("#PhotoDatoGeneral").get(0);
                if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PNG' || imgTem.files[0].name.split('.').pop().toUpperCase() == 'SVG') {
                    var fd = new FormData();
                    fd.append("file", imgTem.files[0]);
                    $http.post(respuesta.CargarImagenLogoUnidadAdministrativa, fd,
                        {
                            headers: { "Content-Type": void 0 },
                            transformRequest: angular.identity
                        }
                    ).then(function Succescallback(response) {
                            console.log(response);
                            var DSecundario = response.data;
                            vm.LogoConfiguracionUA = response.data;
                            vm.UnidadAdm.DirectorioSecundarioLogo = DSecundario.substr(DSecundario.lastIndexOf("/") + 1, 41);
                        }, function errorcallback(response) {}
                    );
                }
                else { return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info'); }                
            };
            //Obtenemos el código postal a partir del municipio
            vm.ObtenerCP = function (RIDMunicipio) {
                vm.CPS = administracionServices.MetodPOST(respuesta.ConsultaCodigoPostalMunicipio, RIDMunicipio);
            }
            //Obtenemos la colonia a partir del código postal
            vm.ObtenerColonias = function (CP) {
                vm.Colonias = administracionServices.MetodPOST(respuesta.ConsultarColoniaDesdeCP, CP);
            }
        // #endregion

        // #region UNIDADES HIJAS
            //Muetra información de unidades hijas hijas
            vm.MostrarInformacionUnidad = function (unidadSeleccionada) {
                if (unidadSeleccionada == 0) {
                    Swal.fire({ icon: 'info', text: 'No se encuentran datos de esta unidad' })
                    return;
                }
                vm.UnidadJerarquica = vm.tablaView.find(function (element) { return (element.RIDUnidadAdministrativa === unidadSeleccionada) });
                //Encuentra la "Unidad administrativa de la que depende."
                var UnidadJerarquicaPadre = null;
                UnidadJerarquicaPadre = vm.tablaView.find(function (element) { return (element.RIDUnidadAdministrativa === vm.UnidadJerarquica.ClaveUAPadre); });
                vm.UnidadJerarquica.NombrePadre = UnidadJerarquicaPadre.NombreUA;
                //Encuentra la imagen de las unidades hijas
                if (vm.UnidadJerarquica.DirectorioSecundarioLogo.length > 1) {
                    vm.UnidadJerarquica.LogoUnidad = vm.UnidadJerarquica.DirectorioImagenesVirtual + vm.UnidadJerarquica.DirectorioSecundarioLogo;
                }
                //Encontramos el municipio y colonia de la unidad
                vm.UnidadJerarquicaMunicipio = vm.Municipios.find(function (element) { return (element.RIDMunicipio === vm.UnidadJerarquica.ClaveMunicipio); });
                vm.UnidadJerarquica.Municipio = vm.UnidadJerarquicaMunicipio.Municipio;
                vm.UnidadJerarquica.Colonias = administracionServices.MetodPOST(respuesta.ConsultarColoniaDesdeCP, vm.UnidadJerarquica.CodigoPostal);
                vm.UnidadJerarquicaNombreAsentamiento = vm.UnidadJerarquica.Colonias.find(function (element) { return (element.RIDCP === vm.UnidadJerarquica.ClaveCP); });
                vm.UnidadJerarquica.NombreAsentamiento = vm.UnidadJerarquicaNombreAsentamiento.NombreAsentamiento;
                //unidades dependientes de la unidad seleccionada
                vm.tablaUnidadesDependientesHijas = administracionServices.MetodPOST(respuesta.ObtenerUnidadesHijas, vm.UnidadJerarquica.RIDUnidadAdministrativa);
                if (vm.tablaUnidadesDependientesHijas.length < 1 || vm.tablaUnidadesDependientesHijas == undefined || vm.tablaUnidadesDependientesHijas == null) {
                    vm.unidadesHijasHijas = false;
                } else {
                    vm.unidadesHijasHijas = true;

                    vm.tablaUnidadesDependientesHijas.forEach(element => {
                        element.NombreEmpleado = vm.tablaView.find(function (elemento) { return (elemento.ClaveEmpleado === element.ClaveEmpleado) }).NombreEmpleado
                        if (element.NombreEmpleado == null) {
                            element.NombreEmpleado = "No Asignado";
                        }
                        console.log(element.NombreEmpleado);
                    });
                }
            }
            //Cierra modal de unidad hija
            vm.CancelarHija = function () {
                $('#UnidadHija').modal('hide');
            }
        // #endregion

        // #region CONFIGURACIÓN DE APLICACIONES
                //Btn AGREGAR APLICACIÓN
            vm.NuevoBuzon = function () {
                vm.LogoAppLogo = null;
                vm.buzones = {};
                vm.FiltroBuzon = [];
                vm.tablaFiltros = false;
            }
                //Carga de Imagen            
            vm.uploadedImage = function (element) {                
                vm.buzones.DirectorioSecundarioLogo = "";
                var imgTem = $("#selectPhotoApp").get(0);
                if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PNG' || imgTem.files[0].name.split('.').pop().toUpperCase() == 'SVG') {
                    var fd = new FormData();
                    fd.append("file", imgTem.files[0]);
                    $http.post(
                        respuesta.CargarLogoDeAplicaciones,
                        fd,
                        {
                            headers: { "Content-Type": void 0 },
                            transformRequest: angular.identity
                        }
                    ).then(function Succescallback(response) {
                            console.log(response);
                            var DSecundarioApp = response.data;
                            vm.LogoAppLogo = response.data;
                            vm.buzones.DirectorioSecundarioLogo = DSecundarioApp.substr(DSecundarioApp.lastIndexOf("/") + 1, 41);
                        }, function errorcallback(response) {}
                    );
                } else { return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');}
            };

            //#region FILTROS
                    //btn AGREGAR FILTRO
                vm.NuevoFiltro = function () {
                    vm.tablaFiltrosASeleccionar = false; //Muestra los filtros que se pueden agregar con descripción
                    vm.tablaFiltrosASeleccionar2 = false; //Muestra los filtros que se pueden agregar sin descripción
                    vm.Filtros = administracionServices.MetodPOST(respuesta.ObtenerFiltro);
                }
                    //Muestra los datos por filtro
                vm.MostrarFiltro = function (filtro) {                
                    vm.FiltrosBuzon = {};  //FiltroSBuzon != FiltroBuzon
                    if (filtro != null || filtro!= undefined) {
                        vm.FiltrosBuzon = administracionServices.MetodPOST(respuesta.BuscarFiltro, filtro);
                        if (vm.FiltrosBuzon.length > 0) {
                            for (var i = 0, len = vm.FiltrosBuzon.length; i < len; i++) {
                                vm.FiltrosBuzon[i].Nombre = filtro.Nombre;
                                for (var j = 0; j < vm.FiltroBuzon.length; j++) {
                                    if (vm.FiltroBuzon[j].Display === vm.FiltrosBuzon[i].Display) {
                                        //vm.MuestraBoton = true;
                                        vm.FiltrosBuzon[i].check = true;
                                    }
                                    else {
                                        if (!vm.FiltrosBuzon[i].hasOwnProperty("check")) {
                                            vm.FiltrosBuzon[i].check = false;
                                        }
                                    }
                                }
                                if (vm.FiltrosBuzon[i].Descripcion == null) {
                                    vm.tablaFiltrosASeleccionar2 = true; //Muestra los filtros que se puedesn agregar sin descripción
                                    vm.tablaFiltrosASeleccionar = false; //Muestra los filtros que se puedesn agregar con descripción
                                }
                                else {
                                    vm.tablaFiltrosASeleccionar = true; //Muestra los filtros que se puedesn agregar con descripción
                                    vm.tablaFiltrosASeleccionar2 = false; //Muestra los filtros que se puedesn agregar sin descripción
                                }
                            }
                        }
                        else {
                            vm.tablaFiltrosASeleccionar = false; //Muestra los filtros que se puedesn agregar con descripción
                            vm.tablaFiltrosASeleccionar2 = false; //Muestra los filtros que se puedesn agregar sin descripción
                            Swal.fire(
                                {
                                    title: "Gobierno Digital",
                                    text: "No hay opciones disponibles",
                                    icon: "info"
                                }
                            );
                        }
                        console.log(vm.FiltrosBuzon);
                    }                
                }
                    //Hace la lista de filtros escogidos
                vm.AgregarFiltroBuzon = function (filtro) {
                    vm.tablaFiltros = false;                
                    var existeFiltro = false;
                    filtro.botonMM = true;
                    var indice = -1;
                    for (var i = 0; i < vm.FiltroBuzon.length; i++) {
                        if (vm.FiltroBuzon[i].Nombre === filtro.Nombre && vm.FiltroBuzon[i].Display === filtro.Display) {
                            existeFiltro = true;
                            indice = i;
                            break;
                        }
                    }
                    if (!existeFiltro) {
                        vm.FiltroBuzon.push(filtro);
                        vm.MuestraBoton = true;
                    }
                    else {
                        vm.FiltroBuzon.splice(indice, 1);
                        vm.MuestraBoton = false;
                    }
                    if (vm.FiltroBuzon.length > 0) {
                        vm.tablaFiltros = true;
                    }
                    else {
                        vm.tablaFiltros = false;
                    }
                    vm.MostrarFiltro(vm.filter);
                }
                    //BOTON ACEPTAR/CERRAR de tipos de filtro - Asigna los datos del filtro escogido
                vm.AsignarFiltros = function () {
                    vm.buzones.Filtros = vm.FiltroBuzon; //Filtro buzon es la lista que se muestra en la tabla final de filtros
                    vm.FiltrosBuzon = null;
                    vm.Filtros = {};
                    $('#tabla-filtros').modal('hide');
                }
                    //Crea una lista auxiliar de los filtros a eliminar
                vm.EliminarFiltroBD = function (filtro) {
                    console.log(filtro);
                    if (filtro.hasOwnProperty('RID')) {
                        vm.FiltroBD.push(filtro);
                    }
                };
                    //Botón de elimina filtro
                vm.EliminaFiltro = function (filtro) {
                    //validamos el filtro a eliminar de la bd
                    vm.EliminarFiltroBD(filtro);
                    //Delete logico de la Lista
                    //Leemos el ID del item a eliminar
                    var idxitem = 0;
                    idxitem = vm.FiltroBuzon.indexOf(filtro);
                    //Eliminamos el item de la lista 
                    vm.FiltroBuzon.splice(idxitem, 1);
                    vm.MuestraBoton = false;
                };
            // #endregion

                //Botón ACEPTAR para agregar Aplicación
            vm.ImplementarNuevoBuzon = function () {
                //Valida que los campos no estén vacios
                for (const el of document.getElementById('frmConfiguracionBuzon').querySelectorAll("[required]")) {
                    if (!el.reportValidity()) {
                        Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                    }
                }
                if (vm.buzones == null || vm.buzones == undefined) {
                    Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                } else {
                    var extensionesValidas = ["png", "svg", "PNG", "SVG"];
                    if (extensionesValidas.find(element => element == vm.buzones.DirectorioSecundarioLogo.slice(((vm.buzones.DirectorioSecundarioLogo.lastIndexOf(".") - 1) + 2))) == undefined) {
                        return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
                    } else {
                        //quita el objeto de ClaveTipoBuzon para la edición de buzones en la edición de unidades
                        if (typeof (vm.buzones.ClaveTipoBuzon) == 'object') {
                            vm.buzones.ClaveTipoBuzon = vm.buzones.ClaveTipoBuzon.RIDAplicacion;
                        }
                        //indexOf() devuelve el índice en el que se puede encontrar un elemento dado en el array, ó devuelve -1 si el elemento no está presente.
                        var idxitem = false;
                        if (vm.UnidadAdm.aplicacionPlataforma.indexOf(vm.buzones) > -1) {
                            idxitem = true;
                        } else {
                            //buzca buzones que vienen de la base para no volver a insertarlos en la lista
                            vm.UnidadAdm.aplicacionPlataforma.forEach(element => { if (element.hasOwnProperty('RIDBuzon') && (element.RIDBuzon == vm.buzones.RIDBuzon)) { idxitem = true; element.Filtros = vm.FiltroBuzon; }; });
                        }
                        if (idxitem) {
                            $('#frmConfiguracionBuzon').modal('hide');
                            vm.BuzonesCopy = JSON.parse(JSON.stringify(vm.buzones));
                            console.log(vm.buzones.ClaveTipoBuzon);
                        } else {
                            if (vm.buzones == null || vm.buzones == undefined || Object.keys(vm.buzones).length < 5) {
                                Swal.fire({ icon: 'info', text: 'Llenar todos los campos obligatorios' })
                            }
                            else {
                                vm.UnidadAdm.aplicacionPlataforma.push(vm.buzones);
                                vm.BuzonesCopy = JSON.parse(JSON.stringify(vm.buzones));
                                vm.LogoAppLogo = null;
                                vm.aplicacionesConfiguradas = true; //Muestra aplicaciones configuradas
                                $('#frmConfiguracionBuzon').modal('hide');
                            }
                        }
                    }                    
                }
                            
            }
                //Btón Cancelar aplicación
            vm.CancelarBuzon = function () {
                if (vm.buzones != null || vm.buzones != undefined) {
                    if (vm.buzones.hasOwnProperty('RIDBuzon')) {
                        vm.buzones = vm.BuzonesCopy;
                        vm.BuzonesCopy = null;
                    }
                    else {
                        if (typeof (vm.buzones.ClaveTipoBuzon) == 'object') {
                            vm.buzones.ClaveTipoBuzon = vm.buzones.ClaveTipoBuzon.RIDAplicacion;
                        }
                        var indice = vm.UnidadAdm.aplicacionPlataforma.indexOf(vm.buzones);
                        if (indice > -1) {
                            vm.UnidadAdm.aplicacionPlataforma[indice] = vm.BuzonesCopy;
                            vm.FiltroBuzon = [];
                            vm.MuestraBoton = false;
                        } 
                    }   
                    $('#frmConfiguracionBuzon').modal('hide');
                }
                else {
                    vm.FiltroBuzon = [];
                    vm.FiltrosBuzon = null;
                    vm.tablaFiltros = false;
                    vm.tablaFiltrosASeleccionar = false;
                    vm.tablaFiltrosASeleccionar2 = false;
                    var idAplicacion = 0;
                    idAplicacion = vm.UnidadAdm.aplicacionPlataforma.indexOf(vm.buzones);

                    if (idAplicacion != -1) {
                        vm.UnidadAdm.aplicacionPlataforma[idAplicacion] = vm.buzonesCopy;
                        $('#frmConfiguracionBuzon').modal('hide');
                    }
                    else {
                        vm.buzones = null;
                        vm.buzonesCopy = null;
                        $('#frmConfiguracionBuzon').modal('hide');
                    }
                }                                          
            }
                //Editar Buzón
            vm.CargarBuzon = function (buz) {  
                //Edita un buzon cuando viene de la base
                if (buz.RIDBuzon != undefined || buz.RIDBuzon != null) {
                    vm.BuzonesCopy = JSON.parse(JSON.stringify(buz));
                    buz = vm.BuzonesCopy;
                    vm.buzones = buz;
                    if (typeof (buz.ClaveTipoBuzon) == 'object') {
                        vm.buzones.ClaveTipoBuzon = buz.ClaveTipoBuzon;
                    }
                    else {
                        vm.buzones.ClaveTipoBuzon = vm.aplicaciones.find(function (element) { console.log(element); return (element.RIDAplicacion === buz.ClaveTipoBuzon) });
                    }
                    vm.LogoAppLogo = buz.DirectorioImagenesVirtual + buz.DirectorioSecundarioLogo;
                    if (buz.Filtros.length > 0 && buz.hasOwnProperty('RIDBuzon')) {
                        vm.FiltroBuzon = buz.Filtros;
                    }else {
                        vm.FiltroBuzon = administracionServices.MetodPOST(respuesta.FiltrosXBuzon, vm.buzones.RIDBuzon);
                    }
                    if (vm.FiltroBuzon.length > 0) {
                        vm.tablaFiltros = true;
                    }
                    else {
                        vm.tablaFiltros = false;
                    }
                }
                //Edita un buzon que no se ha insertado en la base
                else {
                    vm.buzones = buz;
                    vm.buzones.ClaveTipoBuzon = vm.aplicaciones.find(function (element) { console.log(element); return (element.RIDAplicacion === buz.ClaveTipoBuzon) });
                    vm.buzonesCopy = angular.copy(vm.buzones);
                    if (buz.Filtros == undefined || buz.Filtros == null || buz.Filtros.length == 0 || Object.keys(buz.Filtros).length == 0) {
                        vm.tablaFiltros = false;
                    }
                    else {
                        vm.tablaFiltros = true;
                        vm.FiltroBuzon = buz.Filtros;
                    }
                }                
            }
        // #endregion

        //#region EMPLEADOS - Nueva Unidad
            //Bton Agregar empleado
            vm.nuevoEmpleado = function(){
                vm.seActualiza = false;
                console.log(vm.Emp);
                vm.Emp = {};
                vm.correoRegistrado = null;
                vm.LogoConfiguracionLogo = null;
                if (vm.btnActualizar && vm.Puestos.length == 0) {
                    vm.Puestos = administracionServices.MetodPOST(respuesta.ObtenerPuestosXUnidad, vm.UnidadAdm.RIDUnidadAdministrativa);
                }
            }
            vm.AgregarEmpleado = function () {
                console.log(vm.Emp);
                //Valida que los campos no estén vacios
                for (const el of document.querySelector('#frmAltaEmpleado').querySelectorAll('[required]')) {
                    if (!el.reportValidity()) {
                        return Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                    }
                }
                if (vm.Emp == null || vm.Emp == undefined) {
                    Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                }
                else {
                    if (vm.Emp.correoEmpleado != vm.Emp.confirmemail && vm.correoRegistrado != vm.Emp.correoEmpleado) {
                        Swal.fire({ icon: 'info', text: 'Confirmar E-mail' });
                    } else {
                        if (vm.Emp == null || vm.Emp == undefined || Object.keys(vm.Emp).length < 7) {
                            Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                        }
                        else if (vm.Emp.RFCEmpleado.length > 13 || vm.Emp.RFCEmpleado.length < 12) {
                            Swal.fire({ icon: 'info', text: 'Ingresar RFC valido' });
                        }
                        else
                        {
                            var extensionesValidas = ["png", "svg", "PNG", "SVG"];
                            if (extensionesValidas.find(element => element == vm.Emp.DirectorioSecundarioFoto.slice(((vm.Emp.DirectorioSecundarioFoto.lastIndexOf(".") - 1) + 2))) == undefined) {
                                return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
                            }
                            else {
                                //Busca si el empleado ya estaba en la lista
                                var idEmpleado = 0;
                                idEmpleado = vm.NewPuesto.Empleados.indexOf(vm.Emp);

                                if (idEmpleado == -1) {
                                    vm.Emp.RFCEmpleado = vm.Emp.RFCEmpleado.toUpperCase();
                                    //Valida que el RFC de empleado no haya sido registrado con anterioridad
                                    vm.RFCE = administracionServices.MetodPOST(respuesta.RFCDisponibleEmpleado, vm.Emp.RFCEmpleado);
                                    if (vm.RFCE === "1") {
                                        Swal.fire({ icon: 'info', text: 'Este RFC ya está en uso' });
                                    }
                                    else {
                                        //valida que el número de empleado no este en uso por otro usuario
                                        vm.ClaveAuxEmpleado = administracionServices.MetodPOST(respuesta.ObtenerClaveEmpleado, vm.Emp.NumeroEmpleado);
                                        if (vm.ClaveAuxEmpleado === "1") {
                                            Swal.fire({ icon: 'info', text: 'El número de empleado ya esta registrado' });
                                        }
                                        else {
                                            vm.Emp.NombrePuesto = vm.Emp.Puesto.NombrePuesto;
                                            vm.NewPuesto.Empleados.push(vm.Emp);
                                            vm.empleadosDeUnidad = true; //Muestra los empleados agregados
                                            $('#frmAltaEmpleado').modal('hide');
                                            vm.LogoConfiguracionLogo = null;
                                            vm.Emp = null;
                                        }
                                    }
                                }
                                else {
                                    $('#frmAltaEmpleado').modal('hide');
                                    vm.Emp = null;
                                }
                            }                                                
                        }                    
                    }
                }
            }
            //Agregar imagen de empleado
            vm.cargaImagenRe2 = function () {                
                vm.Emp.DirectorioSecundarioFoto = "";
                var imgTem = $("#selectPhotoFotoEmpleado").get(0);
                if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PNG' || imgTem.files[0].name.split('.').pop().toUpperCase() == 'SVG') {
                    var fd = new FormData();
                    fd.append("file", imgTem.files[0]);
                    $http.post(
                        respuesta.CargarImagenEmpleado,
                        fd,
                        {
                            headers: { "Content-Type": void 0 },
                            transformRequest: angular.identity
                        }
                    ).then(function Succescallback(response) {
                            console.log(response);
                            var DSecundario = response.data;
                            vm.LogoConfiguracionLogo = response.data;
                            vm.Emp.DirectorioSecundarioFoto = DSecundario.substr(DSecundario.lastIndexOf("/") + 1, 41);
                        }, function errorcallback(response) { }
                    );
                }
                else { return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info'); }
        };

                // #region Puestos
                    //Btn agregar puesto, manda a llamar los Niveles de Puesto
                    vm.agregarPuesto = function () {
                        vm.btnGuardarP = true;
                        vm.NewPuestos = {};
                        vm.nivelesDePuestos = administracionServices.MetodPOST(respuesta.ConsultarNivelPuesto);
                    }
                    //Cancela agregar un nuevo puesto
                    vm.cancelarPuesto = function () {
                        $('#frmPuestos').modal('hide');
                        vm.NewPuestos = null;
                    }
                    //Botón para agregar puesto
                    vm.agragaLsPuestos = function () {
                        console.log(Object.keys(vm.NewPuestos).length);
                        console.log(Object.keys(vm.NewPuestos).values);
                        //Valida que los campos no estén vacios
                        for (const el of document.getElementById('frmPuestos').querySelectorAll("[required]")) {
                            if (!el.reportValidity()) {
                                Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                            }
                        }
                        if (Object.keys(vm.NewPuestos).length < 4) {
                            Swal.fire({
                                icon: 'info',
                                text: 'Todos los campos son obligatorios'
                            })
                        } else {
                            vm.NewPuestos.ClaveNivelPuesto = vm.NewPuestos.ClaveNivelPuesto.RIDNivel;
                            vm.Puestos.push(vm.NewPuestos);
                            $('#frmPuestos').modal('hide');
                            vm.NewPuestos = null;
                        }
                    }
                // #endregion

            //Agregar titular
            vm.AgregarTitular = function(empleado){
                if (empleado.ClaveEmpleado == undefined) {
                    vm.Emp = empleado;
                    var idEmpleado = 0;
                    idEmpleado = vm.NewPuesto.Empleados.indexOf(vm.Emp);
                    if (idEmpleado != -1) {
                        for (var i = 0; i < vm.NewPuesto.Empleados.length; i++) {
                            vm.NewPuesto.Empleados[i].Titular = false;
                        }
                        vm.NewPuesto.Empleados[idEmpleado].Titular = true;
                    }
                }                
            };
            //Btón editar empleado
            vm.EditarEmpleado = function (empleado) {
                vm.Emp = null;
                vm.seActualiza = false;
                vm.Emp = empleado;
                //Busca los puestos existentes
                if (vm.btnActualizar && vm.Puestos.length == 0) {
                    vm.Puestos = administracionServices.MetodPOST(respuesta.ObtenerPuestosXUnidad, vm.UnidadAdm.RIDUnidadAdministrativa);
                }
                //Muestra los puestos de los empleados que vienen de la base
                if ((!empleado.hasOwnProperty('Puesto') || empleado.Puesto == null || empleado.Puesto == undefined) && empleado.hasOwnProperty('RIDEmpleado')) {
                    vm.Emp.Puesto = {};
                    vm.Emp.Puesto = vm.Puestos.find(function (element) {
                        console.log(element);
                        if (element.hasOwnProperty('RIDPuestos')) {
                            return (element.RIDPuestos == empleado.RIDPuestos);
                        }
                    });
                }
                vm.correoRegistrado = angular.copy(vm.Emp.correoEmpleado);
                vm.EmpCopy = angular.copy(vm.Emp);
            }
            //Valida cambios en el correo electronico
            vm.validarEmail = () => {
                if ((vm.NuevoEmpleado.correoEmpleado != undefined || vm.NuevoEmpleado.correoEmpleado == undefined) && vm.NuevoEmpleado.hasOwnProperty('RIDEmpleado')) {
                    vm.NuevoEmpleado.confirmemail = undefined;
                    vm.seActualiza = true;
                }
            }
            //Cancelar empleado
            vm.CancelarEmpleado = function () {
                var idEmpleado = 0;
                idEmpleado = vm.NewPuesto.Empleados.indexOf(vm.Emp);
                if (idEmpleado != -1) {
                    vm.NewPuesto.Empleados[idEmpleado] = vm.EmpCopy;
                    $('#frmAltaEmpleado').modal('hide');
                }
                else {
                    vm.Emp = null;
                    vm.EmpCopy = null;
                    $('#frmAltaEmpleado').modal('hide');
                }         
            }
        // #endregion

        // #region GUARDAR NUEVA UNIDAD
            //Botón guardar nueva unidad
            vm.GuardarObjetoNegocio = function () {
                //Valida que los campos no estén vacios
                for (const el of document.querySelector('#nuevoFormulario').querySelectorAll('[required]')) {
                    if (!el.reportValidity()) {
                        Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                    }
                }
                if (vm.UnidadAdm == null || vm.UnidadAdm == undefined || Object.keys(vm.UnidadAdm).length < 10) {
                    Swal.fire({ icon: 'info', text: 'Llenar todos los campos obligatorios' })
                }
                else {
                    var extensionesValidas = ["png", "svg", "PNG", "SVG"];
                    if (extensionesValidas.find(element => element == vm.UnidadAdm.DirectorioSecundarioLogo.slice(((vm.UnidadAdm.DirectorioSecundarioLogo.lastIndexOf(".") - 1) + 2))) == undefined) {
                        return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
                    } else {
                        vm.UnidadAdm.Empleados = vm.NewPuesto;
                        vm.UnidadAdmCopy = angular.copy(vm.UnidadAdm);
                        vm.UnidadAdm.ClaveUAPadre = vm.UnidadAdmCopy.ClaveUAPadre.RIDUnidadAdministrativa;
                        vm.UnidadAdm.ClaveCP = vm.UnidadAdmCopy.Colonia.RIDCP;
                        vm.UnidadAdm.CodigoPostal = vm.UnidadAdmCopy.Colonia.CP;
                        vm.UnidadAdm.ClaveMunicipio = vm.UnidadAdmCopy.municipio.RIDMunicipio;
                        vm.UnidadAdm.Buzones = vm.UnidadAdmCopy.aplicacionPlataforma;
                        vm.UnidadAdm.Empleados = vm.UnidadAdmCopy.Empleados.Empleados;
                        vm.UnidadAdm.Puestos = vm.Puestos;

                        Swal.fire(
                            {
                                title: "Gobierno Digital",
                                text: "¿Deseas actualizar los cambios?",
                                icon: "question",
                                showCancelButton: true,
                                cancelButtonText: 'No',
                                confirmButtonText: "Si"
                            }).then(function (seleccion) {
                                if (seleccion.value) {
                                    var result = administracionServices.MetodPOST(respuesta.Ingresar, vm.UnidadAdm);
                                    if (!result.ExisteError) {
                                        MensajeRegresoServidor(result, "success");
                                    } else {
                                        MensajeRegresoServidor(result, "error");
                                    }
                                }
                            }
                        );
                    }                    
                }
            };
        // #endregion

        // #region GUARDAR UNIDAD EDITADA
            vm.ActualizarObjetoNegocio = function () {
                //Valida que los campos no estén vacios
                for (const el of document.querySelector('#nuevoFormulario').querySelectorAll('[required]')) {
                    if (!el.reportValidity()) {
                        Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                    }
                }
                if (vm.UnidadAdm == null || vm.UnidadAdm == undefined || Object.keys(vm.UnidadAdm).length < 10) {
                    Swal.fire({ icon: 'info', text: 'Llenar todos los campos obligatorios' })
                }
                else {
                    if (vm.NewPuesto.Empleados.length >0 && vm.NewPuesto.Empleados.find(element => element.correoEmpleado == null)) {
                        return Swal.fire({ icon: 'info', text: 'Compruebe el campo de correo electrónico en los empleados de la unidad' });          
                    }
                    Swal.fire(
                        {
                            title: "Gobierno Digital",
                            text: "¿Deseas actualizar los cambios?",
                            icon: "question",
                            showCancelButton: true,
                            cancelButtonText: 'No',
                            confirmButtonText: "Si"
                        }).then(function (seleccion) {
                            if (seleccion.value) {
                                if (typeof (vm.UnidadAdm.ClaveUAPadre) == 'object') {
                                    vm.UnidadAdm.ClaveUAPadre = vm.UnidadAdm.ClaveUAPadre.RIDUnidadAdministrativa;
                                }
                                vm.UnidadAdm.CodigoPostal = vm.UnidadAdm.CodigoPostal.CP;
                                vm.UnidadAdm.Buzones = vm.UnidadAdm.aplicacionPlataforma;
                                vm.UnidadAdm.Empleados = vm.NewPuesto.Empleados;
                                vm.UnidadAdm.Puestos = vm.Puestos;
                                if ((vm.UnidadAdm.Empleados.find(element => element.Titular == true)) != undefined) {
                                    vm.UnidadAdm.ClaveEmpleado = vm.UnidadAdm.Empleados.find(element => element.Titular == true);
                                }          
                                if (vm.FiltroBD.length > 0) {
                                    //vm.UnidadAdm.aplicacionPlataforma.forEach(element => { if (element.hasOwnProperty('RIDBuzon')) { element.Filtros = vm.FiltroBD.filter(e => e.ClaveBuzon == element.RIDBuzon) } });
                                    vm.UnidadAdm.aplicacionPlataforma.forEach(element => {
                                        if (element.hasOwnProperty('RIDBuzon')) {
                                            element.Filtros = element.Filtros.filter(e => e.ClaveBuzon == 0 && e.RID == 0);
                                            element.Filtros.push(vm.FiltroBD.filter(e => e.ClaveBuzon == element.RIDBuzon));
                                            element.Filtros = [].concat.apply([], element.Filtros);
                                        }
                                    });
                                }
                                else {
                                    vm.UnidadAdm.aplicacionPlataforma.forEach(element => { if (element.hasOwnProperty('RIDBuzon')) { element.Filtros = element.Filtros.filter(e => e.ClaveBuzon == 0 && e.RID == 0) } });
                                }
                                var result = administracionServices.MetodPOST(respuesta.Actualizar, vm.UnidadAdm);
                                if (!result.ExisteError) {
                                    MensajeRegresoServidor(result, "success");
                                } else {
                                    MensajeRegresoServidor(result, "error");
                                }
                            }
                            else {
                                return;
                                //if (vm.UnidadAdm.ClaveUAPadre != 0 || vm.UnidadAdm.ClaveUAPadre == undefined) {
                                //    vm.UnidadAdm.ClaveUAPadre = vm.tablaView.find(function (element) { return (element.RIDUnidadAdministrativa === vm.UnidadAdm.ClaveUAPadre); });
                                //}
                                //vm.UnidadAdm.CodigoPostal = vm.CPS.find(function (element) { return (element.CP === vm.UnidadAdm.CodigoPostal); });
                                //vm.UnidadAdm.Colonia = vm.Colonias.find(function (element) { return (element.RIDCP === vm.UnidadAdm.ClaveCP); });
                            }
                        }
                    );
                }
            };
        // #endregion

        // #region ELIMINAR UNIDAD
            vm.EliminarObjetoNegocio = function () {
                vm.UnidadAdm.Buzones = vm.UnidadAdm.aplicacionPlataforma;
                if (typeof (vm.UnidadAdm.ClaveUAPadre) == 'object') {
                    vm.UnidadAdm.ClaveUAPadre = vm.UnidadAdm.ClaveUAPadre.RIDUnidadAdministrativa;
                }
                if (typeof (vm.UnidadAdm.CodigoPostal) == 'object') {
                    vm.UnidadAdm.CodigoPostal = vm.UnidadAdm.CodigoPostal.CP;
                }
                Swal.fire(
                    {
                        title: "Gobierno Digital",
                        html: '¿Deseas eliminar la unidad administrativa? </br> <FONT COLOR="DeepSkyBlue"> *Se eliminará toda relación existente en la base de datos, </FONT> </br> <FONT COLOR="DeepSkyBlue"> incluido puestos, empleados y usuarios </FONT>',
                        icon: "question",
                        showCancelButton: true,
                        cancelButtonText: 'No',
                        confirmButtonText: "Si"
                    }).then(function (seleccion) {
                        if (seleccion.value) {
                            vm.tablaView.forEach(element => { if (element.ClaveUAPadre == vm.UnidadAdm.RIDUnidadAdministrativa) { vm.UnidadAdm.RIDUnidadAdministrativa = false};});

                            if (vm.UnidadAdm.RIDUnidadAdministrativa == false) {
                                Swal.fire({title: "Gobierno Digital", text: "No es posible eliminar una unidad administrativa con dependencias", icon: "info"});
                            }
                            else {
                                var result = administracionServices.MetodPOST(respuesta.Eliminar, vm.UnidadAdm);
                                if (!result.ExisteError) {
                                    MensajeRegresoServidor(result, "success");
                                } else {
                                    MensajeRegresoServidor(result, "error");
                                }
                            }
                        }
                    }
                );
            };
        // #endregion
    }
])