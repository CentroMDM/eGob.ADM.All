wfDefinicion.controller("crtlWFDefinicion", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        var rutas = Administracion["WorkFlow"];

        vm.btnActualizar = false;
        vm.btnGuardar = false;
        vm.WFDefinicion = {};
        //Procesos
        vm.btnActualizarProceso = false;
        vm.btnGuardarProceso = false;
        vm.WFProceso = {};
        vm.procesoPadre = {};
        vm.btnAddProceso = true;
        //Etapas
        vm.btnGuardarEtapa = false;
        vm.btnActualizarEtapa = false;
        vm.btnAddEtapa = true;
        vm.accion = {};
        vm.WFProcesoEtapa = {};


        
        vm.Init = () => {
            IniciarSpinner();
            vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
            vm.tablaAcciones = administracionServices.GetConsultaAdministracion(rutas.GetwfCatAcciones);
            //vm.tablaProcesosEtapasAux = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowProcesosEtapas);
            DetenerSpinner();
            
        }

        vm.Init();
        


        vm.NuevoPuesto = function () {
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnGuardar = true;
            vm.btnAddProceso = true;
            vm.btnAddEtapa = true;
            vm.WFDefinicion = {};
            vm.tablaProcesos = [];
        };


        vm.NuevoProceso = function () {
            vm.WFProceso = {};
            vm.procesoPadre = {};
            vm.btnAddEtapa = true;
            vm.btnActualizarProceso = false;
            vm.btnGuardarProceso = true;
            vm.tablaProcesosEtapas = [];
        }

        vm.GuardarObjetoNegocio = function () {
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetWorkFlowDefinicion, vm.WFDefinicion);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                //vm.WFDefinicion = {}; Dejamos la Definicion para poder guardar los procesos y etapas
                                vm.WFDefinicion.RIDWorkFlow = result.Dato;
                                vm.AllowAddProceso();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };


        vm.ActualizarObjetoNegocio = function () {
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.ActualizarObjetoNegocio(rutas.UpdateWorkFlowDefinicion, vm.WFDefinicion);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.MostrarListado();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };


        vm.ValidarTarea = function (objetoNegocio, tarea) {
            if (tarea == 'Actualizar') {
                vm.btnGuardar = false;
                vm.btnActualizar = true;
                vm.WFDefinicion = objetoNegocio;
                vm.AllowAddProceso();
            }
            MostrarFormularios();
        };

        vm.AllowAddProceso = function () {
            vm.tablaProcesosAux = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowProceso);
            vm.tablaProcesos = vm.tablaProcesosAux.filter(function (item) {
                return item.ClaveWorkFlow === vm.WFDefinicion.RIDWorkFlow || item.ClaveWorkFlow === 0;
            });
            if (vm.procesoPadre) {
                vm.procesoPadre = vm.tablaProcesos.find(function (item) {
                    return item.RIDProceso === vm.procesoPadre.RIDProceso;
                })
            }
            vm.btnAddProceso = false;
        }

        vm.ValidarDefinicion = function () {
            var result = vm.tablaDefinicion.find(function (element) {
                return (element.Nombre === vm.WFDefinicion.Nombre && element.Descripcion === vm.WFDefinicion.Descripcion)
            })
            if (result == undefined)
                return true;
            return false;
        }

        vm.ValidarAccion = function () {

            if (vm.btnGuardar) {
                if (!(vm.WFDefinicion.RIDWorkFlow && vm.WFDefinicion.RIDWorkFlow !== 0)) {
                    if (vm.ValidarDefinicion()) {
                        vm.GuardarObjetoNegocio();
                    } else {
                        MensajeGeneral("La definicion, ya se encuentra registrada", "info");
                    }
                } else {
                    MensajeGeneral("La definicion, ya se encuentra registrada", "info");
                }
            } else {
                vm.ActualizarObjetoNegocio();
            }
        }


        vm.MostrarListado = function () {
            vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
            MostrarFormularios();
        };

        vm.CancelarProceso = function () {
            vm.NuevoProceso();
            $('#frmProcesos').modal('hide');
        }

        //Procesos
        vm.setProcesoPadre = function (procesoPadre) {
            vm.procesoPadre = procesoPadre;
        }

        vm.ValidarAccionProceso = function () {
            vm.WFProceso.WorkFlowDefinicion = vm.WFDefinicion;
            vm.WFProceso.ProcesoPrincipal = vm.procesoPadre;
            if (vm.btnGuardarProceso) {
                if (vm.WFProceso.RIDProceso && vm.WFProceso.RIDProceso !== 0) {
                    MensajeGeneral("El Proceso ya se encuentra registrado", "info")
                } else {
                    vm.GuardarProceso();
                }
            } else {
                vm.ActualizarProceso();
            }
        }

        vm.ValidarTareaProceso = function (objetoNegocio, tarea) {
            if (tarea == 'Actualizar') {
                vm.btnGuardarProceso = false;
                vm.btnActualizarProceso = true;
                vm.btnAddEtapa = false;
                //console.log(objetoNegocio);
                vm.WFProceso = objetoNegocio;
                vm.procesoPadre = vm.tablaProcesos.find(function (item) {
                    return item.RIDProceso === vm.WFProceso.ProcesoPrincipal.RIDProceso;
                });
                vm.setTablaProcesoEtapas();
            }
        }

        vm.ValidarTareaEtapa = (objetoNegocio, tarea) => {
            if (tarea === 'Actualizar') {
                vm.btnGuardarEtapa = false;
                vm.btnActualizarEtapa = true;
                vm.WFProcesoEtapa = objetoNegocio;
                vm.accion = vm.tablaAcciones.find(function (item) {
                    return item.RIDAccion === vm.WFProcesoEtapa.ClaveAccion
                })
            }
        }

        vm.GuardarProceso = function () {
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetWorkFlowProceso, vm.WFProceso);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                //vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
                                vm.WFProceso.RIDProceso = result.Dato;
                                vm.btnAddEtapa = false;
                                vm.AllowAddProceso();
                                vm.mdmProceso.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.ActualizarProceso = function () {
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.ActualizarObjetoNegocio(rutas.UpdateWorkFlowProceso, vm.WFProceso);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                //vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
                                vm.btnAddEtapa = false;
                                vm.AllowAddProceso();
                                vm.mdmProceso.$setPristine();
                                $('#frmProcesos').modal('hide');

                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };


        vm.filterProcesoInicial = function (item) {
            return (item.RIDProceso != 0) ? true : false;
        }

        //etapas
        vm.NuevaEtapa = function () {
            vm.btnGuardarEtapa = true;
            vm.btnActualizarEtapa = false;
            vm.accion = {};
            vm.WFProcesoEtapa = {};
        }

        vm.CancelarEtapa = function () {
            $('#frmEtapas').modal('hide');
        }

        vm.ValidarAccionEtapa = function () {
            vm.WFProcesoEtapa.Proceso = vm.WFProceso;
            vm.WFProcesoEtapa.Accion = vm.accion;
            if (vm.btnGuardarEtapa) {
                vm.GuardarObjetoEtapa();
            } else {
                vm.GuardarObjetoEtapa();
            }
        }

        vm.setAccion = function (accion) {
            vm.accion = accion;
        }

        vm.setTablaProcesoEtapas = function () {
            vm.tablaProcesosEtapasAux = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowProcesosEtapas);
            vm.tablaProcesosEtapas = vm.tablaProcesosEtapasAux.filter(function (item) {
                return item.ClaveProceso === vm.WFProceso.RIDProceso;
            })
        }

        vm.GuardarObjetoEtapa = function () {
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetWorkFlowProcesosEtapas, vm.WFProcesoEtapa);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.setTablaProcesoEtapas();
                                vm.CancelarEtapa();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.GuardarObjetoEtapa = function () {
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.ActualizarObjetoNegocio(rutas.UpdateWorkProcesosEtapas, vm.WFProcesoEtapa);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.setTablaProcesoEtapas();
                                vm.CancelarEtapa();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

    }])
