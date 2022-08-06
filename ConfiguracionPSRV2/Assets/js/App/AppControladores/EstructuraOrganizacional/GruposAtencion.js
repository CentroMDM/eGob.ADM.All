grupoAtencionController.controller("crtlGrupoAtencion", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        var respuesta = Administracion["GruposAtencion"];
        vm.btnGuardar = true;
        vm.btnActualizar = false;
        vm.btnEliminar = false;

        vm.buzon = {};
        vm.grupoAtencion = {}
        vm.Buzones = administracionServices.MetodPOST(respuesta.ObtenerBuzon);
        vm.Empleados = administracionServices.GetConsultaAdministracion(respuesta.ObtenerUsuariosYEmpleados);
        vm.EmpleadosBuzon = [];
        vm.EmpleadosSeleccionados = [];
        vm.FiltrosSeleccionados = [];

        vm.EsUsuario = function (empleado) {
            if (empleado.Usuario.RIDUsuario == 0)
                return false;
            return true;
        }

        vm.SetBuzonGrupoAtencion = function (buzon) {
            vm.buzon = buzon;
            vm.EmpleadosBuzon = [];
            for (var i = 0; i < vm.Empleados.length; i++) {
                for (var j = 0; j < vm.Empleados[i].Usuario.Buzones.length; j++) {
                    if (vm.Empleados[i].Usuario.Buzones[j].RIDBuzon == vm.buzon.RIDBuzon) {
                        vm.EmpleadosBuzon.push(vm.Empleados[i]);
                    }
                }
            }
        }

        vm.IngresarFiltro = function (filtro) {
            //elimino objeto de la lista principal
            var removeIndex = vm.buzon.Filtros.map(function (item) {
                return item.RID;
            }).indexOf(filtro.RID);
            vm.buzon.Filtros.splice(removeIndex, 1);
            vm.FiltrosSeleccionados.push(filtro);
        }

        vm.IngresarEmpleado = function (empleado) {
            var removeIndex = vm.EmpleadosBuzon.map(function (item) {
                return item.RIDEmpleado;
            }).indexOf(empleado.RIDEmpleado);
            vm.EmpleadosBuzon.splice(removeIndex, 1);
            vm.EmpleadosSeleccionados.push(empleado);
        }

        vm.ValidarAccion = function () {
            if (vm.btnGuardar) {
                vm.GuardarObjetoNegocio();
            } else {
                vm.ActualizarObjetoNegocio();
            }
        }

        vm.AjusteFiltros = function () {
            for (var i = 0; i < vm.FiltrosSeleccionados.length; i++) {
                vm.FiltrosSeleccionados[i].ClaveTipoGrupo = vm.FiltrosSeleccionados[i].ClaveTipoFiltro;
            }
        }

        vm.GuardarObjetoNegocio = function () {
            //Generamos el grupo de atencion
            vm.AjusteFiltros();
            vm.buzon.FiltroGrupoAtencion = vm.FiltrosSeleccionados;
            vm.grupoAtencion.Buzon = vm.buzon;
            vm.grupoAtencion.Usuarios = vm.EmpleadosSeleccionados;
            //Guardamos los datos
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
                        var result = administracionServices.IngresarObjetoNegocio(respuesta.IngresarGrupoAtencion, vm.grupoAtencion);
                        $timeout(function () {
                            vm.buzon = {};
                            vm.grupoAtencion = {}
                            vm.EmpleadosBuzon = [];
                            vm.EmpleadosSeleccionados = [];
                            vm.FiltrosSeleccionados = [];
                            vm.mdmForm.$setPristine();
                        });
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

    }])