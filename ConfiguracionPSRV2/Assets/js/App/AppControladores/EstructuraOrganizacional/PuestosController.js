puestoController.controller("crtlPuesto", ["$scope", "$timeout", "$window", "administracionServices",
    function (vm = $scope, $timeout, $window, administracionServices) {

        var respuesta = Administracion["PuestosInstitucionales"]

        this.$onInit = () => {
            vm.tablaView = administracionServices.MetodPOST(respuesta.Consulta);
            vm.unidades = administracionServices.MetodPOST(respuesta.ConsultaUnidades);
            vm.NivelPuesto = administracionServices.MetodPOST(respuesta.ConsultarNivelPuesto );
        }

        vm.NuevoPuesto = function () {
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = true;
        };

        vm.ValidarTarea = function (objetoNegocio, tarea) {
            if (tarea == 'Eliminar') {
                vm.btnActualizar = false;
                vm.btnEliminar = true;
                vm.btnGuardar = false;
            }
            if (tarea == 'Actualizar') {
                vm.btnActualizar = true;
                vm.btnEliminar = true;
                vm.btnGuardar = false;
            }
            vm.newPuesto = objetoNegocio;
            MostrarFormularios();
        };

        vm.MostrarListado = function () {
            location.reload();
        };

        vm.ValidarAccion = function () {
            vm.newPuesto.Buzones = vm.buzones;
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
                        var result = administracionServices.MetodPOST(respuesta.Ingresar, vm.newPuesto);
                        $timeout(function () {
                            vm.newPuesto = {};
                            vm.buzones = [];
                            vm.mdmForm.$setPristine();
                        });
                        if (!result.ExisteError) {
                            location.reload();
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                }
            );
        };

        vm.EliminarPuesto = () => {
            vm.tablaPuestos = administracionServices.MetodPOST(respuesta.ObtenerEmpleado);
            for (var i = 0; i < vm.tablaPuestos.length; i++) {
                if (vm.newPuesto.RIDPuestos == vm.tablaPuestos[i].ClavePuesto && vm.tablaPuestos[i].ClaveStatus == 140) {
                    vm.newPuesto.SePuedeEliminar = false;
                    break;
                }
                else {
                    vm.newPuesto.SePuedeEliminar = true;
                }
            }
            if (vm.newPuesto.SePuedeEliminar) {
                vm.EliminarObjetoNegocio();
            } else {
                MensajeGeneral("El Puesto Institucional se encuentra en uso por algún Empleado, no puede ser eliminado", "info");
            }
        }

        vm.EliminarObjetoNegocio = function () {
            Swal.fire(
                {
                    target: document.getElementById('default-example-modal-lg'),
                    title: "PSR-Configuración",
                    text: "¿Deseas eliminar el registro?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.MetodPOST(respuesta.Eliminar, vm.newPuesto);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            location.reload();
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.ActualizarObjetoNegocio = function () {
            Swal.fire(
                {
                    target: document.getElementById('default-example-modal-lg'),
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.MetodPOST(respuesta.Actualizar, vm.newPuesto);
                        if (!result.ExisteError) {
                            location.reload();
                            MensajeRegresoServidor(result, "success");
                            MostrarFormularios();
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.FiltrarPrincipal = function (item) {
            return item.RIDUnidadAdministrativa != 0;
        };

    }])
