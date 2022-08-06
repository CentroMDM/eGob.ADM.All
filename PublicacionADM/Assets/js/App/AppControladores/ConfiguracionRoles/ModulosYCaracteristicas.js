ModulosYCaracteristicas.controller("ModulosYCaracteristicas", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        var rutas = Administracion["ConfiguracionRoles"];

        //Variables
        vm.todasLasApps = {};
        vm.todosLosRoles = {};
        vm.datosDeRol = {};
        vm.catModulos = {};
        vm.getCaracteristicas = {};
        vm.setAcciones = {};

        //Datos principales
            //Traemos todos los roles y su aplicación
        vm.todasLasApps = administracionServices.GetConsultaAdministracion(rutas.Getcataplicaciones);
        
        //Muestra Formulario de Nuevo Rol
        vm.NuevoPuesto = function () {
            vm.datosDeRol = {};
            vm.appsRoles = [];
            document.getElementById("#nombreRol").disabled = false;
            //document.getElementById("#lvlRol").disabled = false;
            document.getElementById("#NombreAplicacion").disabled = false;
            document.getElementById("#descripcionRol").disabled = false;
            vm.btnCrear = true;
            vm.btnActualizar = false;
            MostrarFormularios();
            document.getElementById("#accesosDeRol").style.display = "none";            
            document.getElementById("#accesosDeRol2").style.display = "none";
        };

        //Muestra Formulario de Editar Rol
        vm.editarRaccesoROl = function (lsRoles) {
            vm.datosDeRol.ClaveAplicacion = lsRoles.ClaveAplicacion;
            vm.datosDeRol.RIDRol = lsRoles.RIDRol;
            vm.datosDeRol.nombreRol = lsRoles.nombreRol;
            vm.datosDeRol.descripcionRol = lsRoles.descripcionRol;
            vm.appsRoles = vm.todasLasApps.find(function (element) {
                return (element.RIDAplicacion === lsRoles.ClaveAplicacion)
            });
            vm.btnAgregar = true;
            vm.btnCrear = false;
            vm.btnActualizar = true;
            document.getElementById("#nombreRol").disabled = false;
            //document.getElementById("#lvlRol").disabled = false;
            document.getElementById("#NombreAplicacion").disabled = false;                            
            document.getElementById("#descripcionRol").disabled = false;
            vm.accesosRol(vm.datosDeRol);                                    
            vm.accesosAgregados(vm.datosDeRol);
            document.getElementById("#accesosDeRol").style.display = "block";
            document.getElementById("#accesoCaract").style.display = "none";
            document.getElementById("#accesoAccion").style.display = "none";
            MostrarFormularios();
        }

        //Regresa al formulario principal
        vm.MostrarListado = function () {
            MostrarFormularios();
            vm.App = [];
            vm.todosLosRoles = {};
            customSwitch1.checked = false;
        };

        //Filtros
        vm.SetApp = function (App) {
            if (App === undefined) {
                vm.todosLosRoles = {};
            }
            else {                
                vm.todosLosRoles = administracionServices.GetConsultaAdministracionConParametro(rutas.obtenerRolXAplicacion, App);
                customSwitch1.checked = false;
            }
        }
        vm.selectTodosRoles = function () {
            if (customSwitch1.checked) {
                vm.App = undefined;
                vm.todosLosRoles = {};
                vm.todosLosRoles = administracionServices.GetConsultaAdministracion(rutas.GetTodosLosRoles);
            }
            else {
                vm.todosLosRoles = {};
            }
        }
        //Fin de Filtros

        //Validaciones para crear un rol
        vm.validacionRoles = function () {
            vm.datosDeRol.ClaveAplicacion = vm.appsRoles.RIDAplicacion;
            vm.catRoles = administracionServices.GetConsultaAdministracion(rutas.GetTodosLosRoles);
            var encuentraRol = vm.catRoles.find(element => element.nombreRol == vm.datosDeRol.nombreRol && element.ClaveAplicacion == vm.datosDeRol.ClaveAplicacion);
            console.log(encuentraRol);
            if (encuentraRol == undefined) {
                document.getElementById("#nombreRol").disabled = true;
                //document.getElementById("#lvlRol").disabled = true;
                document.getElementById("#NombreAplicacion").disabled = true;
                document.getElementById("#descripcionRol").disabled = true;
                vm.btnAgregar = true;
                vm.btnCrear = false;
                vm.btnActualizar = false;
                document.getElementById("#accesosDeRol").style.display = "block";
                document.getElementById("#accesoCaract").style.display = "none";
                document.getElementById("#accesoAccion").style.display = "none";
                return true;
            }
            else {
                document.getElementById("#accesosDeRol").style.display = "none";
                document.getElementById("#accesosDeRol2").style.display = "none";
                document.getElementById("#nombreRol").disabled = false;
                //document.getElementById("#lvlRol").disabled = false;
                document.getElementById("#NombreAplicacion").disabled = false;
                document.getElementById("#descripcionRol").disabled = false;
                vm.btnAgregar = false;
                //vm.btnCrear = true;
                //vm.btnActualizar = false;
                return false;
            }
        }

        //Crear Rol
        vm.setNewRol = function () {
            //Valida que los campos no estén vacios
            for (const el of document.getElementById('#creacionDeRol').querySelectorAll("[required]")) {
                if (!el.reportValidity()) {
                    Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                }
                else {
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
                                if (vm.validacionRoles()) {
                                    vm.btnCrear = false;
                                    var result = administracionServices.GetConsultaAdministracionConParametro(rutas.setNewRol, vm.datosDeRol);
                                    if (!result.ExisteError) {
                                        $timeout(() => {
                                            let getRIDRol = administracionServices.GetConsultaAdministracionConParametro(rutas.GetNewRol, vm.datosDeRol);
                                            vm.datosDeRol.RIDRol = getRIDRol[0].RIDRol;
                                            vm.accesosRol(vm.datosDeRol);
                                            if (getRIDRol[0].RIDRol != 0) {
                                                vm.datosDeRol.RIDRol = getRIDRol[0].RIDRol;
                                                Swal.fire('', 'El rol se creó correctamente', 'success');
                                                vm.accesosRol(vm.datosDeRol);
                                            }
                                            else {
                                                Swal.fire('', 'No se ha podido actualizar los cambios', 'error'); return;
                                            }
                                        });
                                    } else {
                                        Swal.fire('', 'No se ha podido actualizar los cambios', 'error'); return;
                                    }
                                }
                                else {
                                    Swal.fire('', 'El Nombre de rol ya existe', 'error'); return;
                                }
                            }
                        }
                        );
                }
            }            
        }

        //Accesos del Rol
            //Traemos los modulos disponibles para el rol recién creado
        vm.accesosRol = function (datosDeRol) {
            vm.catModulos = {};
            vm.setAcciones = {};
            vm.Modulo = {};
            vm.Caract = {};
            vm.Accion = {};
            vm.catModulos = administracionServices.GetConsultaAdministracionConParametro(rutas.GetModulosXAplicacion, datosDeRol);
        }
            //Traemos los datos de las caracteristicas asociadas al modulo seleccionado 
        vm.getCat_Caracteristicas = function (Modulo) {
            vm.getCaracteristicas = {};
            Modulo.RIDRol = vm.datosDeRol.RIDRol;
            vm.getCaracteristicas = administracionServices.GetConsultaAdministracionConParametro(rutas.GetModulosCXRol, Modulo);
            if (vm.getCaracteristicas.length == 0) {
                document.getElementById("#accesoCaract").style.display = "none";
                document.getElementById("#accesoAccion").style.display = "none";
            }
            else {
                document.getElementById("#accesoCaract").style.display = "block";
            }            
        }        
            //Traemos los datos de las acciones asociadas a la caracteristica seleccionada
        vm.getMenuAcciones = function (Caract) {
            vm.getAcciones = {};
            Caract.RIDRol = vm.datosDeRol.RIDRol;
            vm.getAcciones = administracionServices.GetConsultaAdministracionConParametro(rutas.GetAccionXRol, Caract);
            if (vm.getAcciones.length == 0) {
                document.getElementById("#accesoAccion").style.display = "none";
            }
            else {
                document.getElementById("#accesoAccion").style.display = "block";
            }
        }
            //Validación de accesos
        vm.validaAccesos = function () {
            vm.setAcciones.RIDRol = vm.datosDeRol.RIDRol;
            vm.setAcciones.RIDModulo = vm.Modulo.RIDModulo;
            vm.setAcciones.RIDCaracteristica = vm.Caract.RIDCaracteristica;
            vm.setAcciones.RIDAccion = vm.Accion.RIDAccion;
        }

        //Insertar accesos
        vm.setNewAcceso = function () {
            vm.validaAccesos();
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
                        //si es nulo o undefined entonces ponle 0 y pregunta si = 0 
                        if ((vm.setAcciones.RIDModulo ??= 0) == 0) {
                            return;
                        }
                        if ((vm.setAcciones.RIDCaracteristica ??= 0) == 0 && (vm.setAcciones.RIDAccion ??= 0) == 0) {
                            //insertar modulo solito
                            var result = administracionServices.GetConsultaAdministracionConParametro(rutas.Roles_SetAccesosM, vm.setAcciones);
                        }
                        else if ((vm.setAcciones.RIDAccion ??= 0) == 0){
                            //inserta módulo y carcateristica
                            var result = administracionServices.GetConsultaAdministracionConParametro(rutas.Roles_SetAccesosMC, vm.setAcciones);
                        }
                        else {
                            var result = administracionServices.GetConsultaAdministracionConParametro(rutas.Roles_SetAccesosAll, vm.setAcciones);
                        }
                        if (!result.ExisteError) {
                            $timeout(() => {
                                document.getElementById("#accesosDeRol2").style.display = "block";
                                document.getElementById("#accesoCaract").style.display = "none";
                                document.getElementById("#accesoAccion").style.display = "none";
                                Swal.fire('', 'El acceso se agregó correctamente', 'success');
                                vm.accesosRol(vm.datosDeRol);
                                vm.accesosAgregados(vm.datosDeRol);
                            });
                        } else {
                              Swal.fire('', 'No se ha podido actualizar los cambios', 'error'); return;
                        }
                    }
                }
            );         
        }

        //Accesos agregados
        vm.accesosAgregados = function (datosDeRol) {
            vm.RAccesosRol = {};
            vm.RAccesosRol = administracionServices.GetConsultaAdministracionConParametro(rutas.DetalleDeLosRoles, datosDeRol.RIDRol);
            if (vm.RAccesosRol.length == 0 || vm.RAccesosRol.length == undefined) {
                document.getElementById("#accesosDeRol2").style.display = "none";
            }
            else {
                document.getElementById("#accesosDeRol2").style.display = "block";
                return;
            }
        }

        //Editar Rol y sus accesos
        vm.UpdateNewRol = function () {
            //Valida que los campos no estén vacios
            for (const el of document.getElementById('#creacionDeRol').querySelectorAll("[required]")) {
                if (!el.reportValidity()) {
                    Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                }
                else {
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
                                if (vm.validacionRoles()) {
                                    vm.btnActualizar = false;
                                    var result = administracionServices.GetConsultaAdministracionConParametro(rutas.UpdateCatRol, vm.datosDeRol);
                                    if (!result.ExisteError) {
                                        $timeout(() => {
                                            Swal.fire('', 'El rol se actualizó correctamente', 'success');
                                            vm.accesosRol(vm.datosDeRol);
                                        });
                                    } else {
                                        Swal.fire('', 'No se ha podido actualizar los cambios', 'error'); return;
                                    }
                                }
                                else {
                                    Swal.fire('', 'El Nombre de rol ya existe', 'error'); return;
                                }
                            }
                        }
                    );
                }
            }
        }

        //Eliminar Rol y sus modulos
        vm.eliminarRolYModulo = function (lsRoles) {
            console.log(lsRoles);
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    /*text: '¿Deseas eliminar el registro? También se eliminarán los accesos relacionados',*/
                    html: '¿Deseas eliminar el registro? </br> <FONT COLOR="DeepSkyBlue"> *Se eliminará toda relación existente en la base de datos </FONT>',
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.GetConsultaAdministracionConParametro(rutas.EliminarRaccesoRol, lsRoles);
                        if (!result.ExisteError) {
                            $timeout(() => {
                                Swal.fire('', 'El acceso se eliminó correctamente', 'success');
                                vm.accesosAgregados(lsRoles);
                            });
                        } else {
                            Swal.fire('', 'No se ha podido actualizar los cambios', 'error'); return;
                        }
                        vm.accesosAgregados(lsRoles);
                    }
                }
            );
        }
    }
]);