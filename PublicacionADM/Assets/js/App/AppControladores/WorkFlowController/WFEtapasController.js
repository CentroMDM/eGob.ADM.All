wfEtapas.controller("crtlWFEtapas", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        var rutas = Administracion["WorkFlow"];
        vm.btnActualizar = false;
        vm.btnGuardar = false;
        vm.proceso = {};
        vm.accion = {};
        vm.WFProcesoEtapa = {};
        vm.tablaProcesos = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowProceso);
        vm.tablaAcciones = administracionServices.GetConsultaAdministracion(rutas.GetwfCatAcciones);
        vm.tablaProcesosEtapas = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowProcesosEtapas);

        vm.ValidarAccion = function () {
            vm.WFProcesoEtapa.Proceso = vm.proceso;
            vm.WFProcesoEtapa.Accion = vm.accion;
            if (vm.btnGuardar) {
                vm.GuardarObjetoNegocio();
            } else {
                vm.ActualizarObjetoNegocio();
            }
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
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetWorkFlowProcesosEtapas, vm.WFProcesoEtapa);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.proceso = {};
                                vm.accion = {};
                                vm.WFProcesoEtapa = {};
                                vm.mdmForm.$setPristine();
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
                vm.WFProcesoEtapa = objetoNegocio;
                vm.setModeloInicial();
            }
            MostrarFormularios();
        };

        vm.setModeloInicial = function () {
            vm.proceso = vm.tablaProcesos.find(function (item) {
                return item.RIDProceso == vm.WFProcesoEtapa.Proceso.RIDProceso
            });
            vm.accion = vm.tablaAcciones.find(function (item) {
                return item.RIDAccion == vm.WFProcesoEtapa.Accion.RIDAccion;
            });
        }

        vm.NuevoPuesto = function () {
            MostrarFormularios();
            vm.proceso = {};
            vm.accion = {};
            vm.WFProcesoEtapa = {};
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = true;
        };

        vm.MostrarListado = function () {
            vm.tablaProcesosEtapas = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowProcesosEtapas);
            MostrarFormularios();
        };

        vm.FiltroProceso = function (item) {
            return (item.RIDProceso != 0) ? true:false
        }

        vm.setProceso = function (proceso) {
            vm.proceso = proceso;
        }

        vm.setAccion = function (accion) {
            vm.accion = accion;
        }

    }])