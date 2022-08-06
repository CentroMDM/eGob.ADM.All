buzonController.controller("crtlBuzon", ["$scope", "administracionServices",
    function (vm = $scope, administracionServices) {

        var respuesta = Administracion["Buzon"]
        vm.aplicaciones = administracionServices.GetConsultaAdministracion(respuesta.ObtenerAplicaciones);
        vm.buzones = administracionServices.GetConsultaAdministracion(respuesta.ObtenerBuzon);
        vm.EstatusBuzon = administracionServices.GetConsultaAdministracion(respuesta.ObtenerEstatusBuzon);
        vm.EstatusCondicion = []
        vm.statusBuzon = {};

        vm.ValidarTarea = function (objetoNegocio, tarea) {
            if (tarea == 'Actualizar') {
                vm.btnGuardar = false;
            }
            vm.buzon = objetoNegocio;
            MostrarFormularios();
            vm.SeleccionarNuevoEstatus();
        };

        vm.SeleccionarNuevoEstatus = function () {
            vm.EstatusCondicion = [];
            for (var i = 0; i < vm.EstatusBuzon.length; i++) {
                if (vm.buzon.CatalogoDescriptivo.NombreItem === 'Activo') {
                    if (vm.EstatusBuzon[i].NombreItem === 'Suspendido' || vm.EstatusBuzon[i].NombreItem === 'Cancelado') {
                        vm.EstatusCondicion.push(vm.EstatusBuzon[i]);
                    }
                }
                if (vm.buzon.CatalogoDescriptivo.NombreItem === 'Habilitado') {
                    if (vm.EstatusBuzon[i].NombreItem === 'Cancelado' || vm.EstatusBuzon[i].NombreItem === 'Activo') {
                        vm.EstatusCondicion.push(vm.EstatusBuzon[i]);
                    }
                }

                if (vm.buzon.CatalogoDescriptivo.NombreItem === 'Cancelado' || vm.buzon.CatalogoDescriptivo.NombreItem === 'Suspendido') {
                    if (vm.EstatusBuzon[i].NombreItem === 'Activo') {
                        vm.EstatusCondicion.push(vm.EstatusBuzon[i]);
                    }
                }
            }
        };

        vm.ActualizarEstatusBuzon = function (NuevoEstatus) {
            vm.statusBuzon = NuevoEstatus;
        }
        vm.Actualizar = function () {
            if ("ClaveCatalogo" in vm.statusBuzon) {
                $("#tabla-cambioEstatus").modal("show");
            }
        }
        vm.GuardarNuevoEstatus = function () {
            $("#tabla-cambioEstatus").modal("hide");
        }

    }])