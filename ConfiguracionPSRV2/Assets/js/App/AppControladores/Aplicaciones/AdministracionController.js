AdministracionController.controller("crtlAdministracion", ["$scope", "administracionServices",
    function (vm = $scope, administracionServices) {
        var respuesta = Administracion["Administracion"]

        vm.buzones = administracionServices.GetConsultaAdministracion(respuesta.ObtenerAplicaciones);

        vm.MostrarListado = function () {
            vm.statusBuzon == null;
            MostrarFormularios();
        };
        vm.ValidarTarea = function (objetoNegocio, tarea) {
            if (tarea == 'Actualizar') {
                vm.btnActualizar = true;
            }
            vm.buzon = objetoNegocio;
            vm.statusBuzon == null;
            vm.SeleccionarNuevoEstatus();
            MostrarFormularios();
        };
        vm.SeleccionarNuevoEstatus = function () {
            if (vm.buzon.CStatus == "Activo" ) {
                vm.EstatusCondicion = ["Inactivo"];
            } else {
                vm.EstatusCondicion = ["Activo"];
            }
        };
        vm.Actualizar = function () {
            console.log(vm.statusBuzon);
            if (vm.statusBuzon == null || vm.statusBuzon == undefined) {
                location.reload();
            }
            else {
                //Activa las aplicaciones inactivas
                if (vm.statusBuzon == "Activo") {
                    vm.buzon.ClaveStatus = 1;
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
                                var result = administracionServices.IngresarObjetoNegocio(respuesta.ActualizarActivo, vm.buzon.RIDBuzon);
                                if (!result.ExisteError) {
                                    MensajeRegresoServidor(result, "success");
                                    location.reload();
                                } else {
                                    MensajeRegresoServidor(result, "error");
                                }
                            }
                        }
                    );
                }
                //Desactiva las aplicaciones activas
                else {                    
                    vm.buzon.ClaveStatus = 2;
                    Swal.fire(
                        {
                            title: "Gobierno Digital",
                            html: '¿Deseas actualizar los cambios? </br> <FONT COLOR="DeepSkyBlue"> *Se eliminará toda relación existente en la base de datos, </FONT> </br> <FONT COLOR="DeepSkyBlue"> incluida la relación con los usuarios </FONT>',
                            icon: "question",
                            showCancelButton: true,
                            cancelButtonText: 'No',
                            confirmButtonText: "Si"
                        }).then(function (seleccion) {
                            if (seleccion.value) {
                                var result = administracionServices.IngresarObjetoNegocio(respuesta.ActualizarDesactivado, vm.buzon.RIDBuzon);
                                if (!result.ExisteError) {
                                    MensajeRegresoServidor(result, "success");
                                    location.reload();
                                } else {
                                    MensajeRegresoServidor(result, "error");
                                }
                            }
                        }
                    );
                }
            }            
        }
    }
])