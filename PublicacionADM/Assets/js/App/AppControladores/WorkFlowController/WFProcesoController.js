wfProceso.controller("crtlWFProceso", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        var rutas = Administracion["WorkFlow"];
        vm.btnActualizar = false;
        vm.btnGuardar = false;
        vm.WFProceso = {};
        vm.Definicion = {};
        vm.procesoPadre = {};

        vm.tablaProcesos = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowProceso);
        vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);

        vm.NuevoPuesto = function () {
            vm.WFProceso = {};
            vm.Definicion = {};
            vm.procesoPadre = {};
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = true;
        };

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
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetWorkFlowProceso, vm.WFProceso);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                //vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
                                vm.WFProceso = {};
                                vm.Definicion = {};
                                vm.procesoPadre = {};
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.ValidarAccion = function () {
            vm.WFProceso.WorkFlowDefinicion = vm.Definicion;
            vm.WFProceso.ProcesoPrincipal = vm.procesoPadre;
            console.log(vm.WFProceso);
            if (vm.btnGuardar) {
                vm.GuardarObjetoNegocio();
            } else {
                vm.ActualizarObjetoNegocio();
            }
        }

        vm.setDefinicion = function (definicion) {
            vm.Definicion = definicion;
        }

        vm.setProcesoPadre = function (procesoPadre) {
            vm.procesoPadre = procesoPadre;
        }

        vm.filterProcesoInicial = function (item) {
            return (item.RIDProceso != 0) ? true : false;
        }

        vm.ValidarTarea = function (objetoNegocio, tarea) {
            if (tarea == 'Actualizar') {
                vm.btnGuardar = false;
                vm.btnActualizar = true;
                //console.log(objetoNegocio);
                vm.WFProceso = objetoNegocio;
                vm.setModeloInicial();
            }
            MostrarFormularios();
        };

        vm.setModeloInicial = function () {
            vm.Definicion = vm.tablaDefinicion.find(function (item) {
                return item.RIDWorkFlow == vm.WFProceso.WorkFlowDefinicion.RIDWorkFlow
            });

            vm.procesoPadre = vm.tablaProcesos.find(function (item) {
                return item.RIDProceso == vm.WFProceso.ProcesoPrincipal.RIDProceso;
            });
        }

        vm.MostrarListado = function () {
            vm.tablaProcesos = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowProceso);
            MostrarFormularios();
        };

    }])

