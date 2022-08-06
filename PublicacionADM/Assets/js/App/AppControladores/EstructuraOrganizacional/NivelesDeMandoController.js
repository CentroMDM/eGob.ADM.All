nivelMandoController.controller("crtlNivelDeMando", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        let respuesta = Administracion['NivelPuesto'];

        this.$onInit = () => {
            vm.tablaView = administracionServices.MetodPOST(respuesta.Consulta);
            vm.tablaViewAux = angular.copy(vm.tablaView);
        }

        vm.NuevoPuesto = () => {
            document.getElementById("txtAbreviatura").disabled = false;
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = true;
        };

        vm.ValidarTarea = (objetoNegocio, tarea) => {
            document.getElementById("txtAbreviatura").disabled = true;

            if (objetoNegocio.PuestoMando == 1) {
                document.getElementById("PuestoDeMando").checked = true;
            }


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

        vm.MostrarListado = () => {
            vm.tablaView = administracionServices.MetodPOST(respuesta.Consulta);
            vm.newPuesto = {};
            MostrarFormularios();
        };

        vm.ValidarAccion = () => {
            vm.newPuesto.PuestoMando = document.getElementById("PuestoDeMando").checked;
            if (vm.btnGuardar) {
                if (!vm.validarDescripcion()) {
                    if (!vm.validacionClave()) {
                        vm.GuardarObjetoNegocio();
                    } else {
                        MensajeGeneral("La clave ya se encuentra registrada, favor de verificar", "info");
                    }
                } else {
                    MensajeGeneral("La descripción ya se encuentra registrada, favor de verificar", "info");
                }
            } else {
                if (!vm.validarDescripcion()) {
                    vm.ActualizarObjetoNegocio();
                } else {
                    vm.ActualizarObjetoNegocio();
                }
            }
        }

        vm.validacionClave = () => {
            let resultado = vm.tablaView.find(item => {
                return (item.Clave === vm.newPuesto.Clave) ? true : false;
            })
            return (resultado && resultado.Clave);
        }

        vm.validarDescripcion = () => {
            let resultado = vm.tablaViewAux.find(item => {
                return (item.Nombre === vm.newPuesto.Nombre) ? true : false
            })
            return (resultado && resultado.Nombre);
        }

        vm.GuardarObjetoNegocio = () => {
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'Cancelar',
                    confirmButtonText: "Aceptar"
                }).then(seleccion => {
                    if (seleccion.value) {
                        destroyTable();
                        var result = administracionServices.MetodPOST(respuesta.Ingresar, vm.newPuesto);
                        $timeout(() => {
                            vm.newPuesto = {};
                            vm.tablaView = administracionServices.MetodPOST(respuesta.Consulta);
                            vm.ReshapeTable();
                            vm.mdmForm.$setPristine();
                        });
                        if (!result.ExisteError) {
                            location.reload();
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.EliminarNivel = () => {
            vm.tablaPuestos = administracionServices.MetodPOST(respuesta.ConsultaP);
            for (var i = 0; i < vm.tablaPuestos.length; i++) {
                if (vm.newPuesto.RIDNivel == vm.tablaPuestos[i].ClaveNivelPuesto && vm.tablaPuestos[i].ClaveStatus == 1)
                {
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
                MensajeGeneral("El nivel de Mando se encuentra en uso por algún Puesto Institucional, no puede ser eliminado.", "info");
            }
        }

        vm.EliminarObjetoNegocio = () => {
            Swal.fire(
                {
                    target: document.getElementById('default-example-modal-lg'),
                    title: "PSR-Configuración",
                    text: "¿Deseas eliminar el registro?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(seleccion => {
                    if (seleccion.value) {
                        var result = administracionServices.MetodPOST(respuesta.Eliminar, vm.newPuesto);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.ActualizarObjetoNegocio = () => {
            Swal.fire(
                {
                    target: document.getElementById('default-example-modal-lg'),
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(seleccion => {
                    if (seleccion.value) {
                        var result = administracionServices.MetodPOST(respuesta.Actualizar, vm.newPuesto);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.FiltrarPrincipal = item => {
            return item.RIDUnidadAdministrativa != 0;
        };

        vm.ReshapeTable = () => {
            $timeout(() => {
                reloadTable();
            })
        }
    }])


