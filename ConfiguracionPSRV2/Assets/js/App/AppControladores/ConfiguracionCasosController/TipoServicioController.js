configuracionTipoServicio.controller("configTipoServicio", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {

        var rutas = Administracion["ConfiguracionCasos"];
        vm.btnActualizar = false;
        vm.btnGuardar = false;
        vm.tipoServicio = {};
        vm.tipoClasificador = {};

        vm.Init = () => {
            IniciarSpinner();
            vm.tablaTipoServicio = administracionServices.GetConsultaAdministracion(rutas.GetCatTipoServicios);
            vm.tablaTipoClasificador = administracionServices.GetConsultaAdministracion(rutas.GetTipoServicio);
            DetenerSpinner();
        }
        vm.Init();


        vm.setModeloInicial = function () {
            vm.tipoClasificador = vm.tablaTipoClasificador.find(function (item) {
                return item.RIDItemCatalogo === vm.tipoServicio.ClaveClasificadorServicio
            });
            vm.tipoClasificador;
        }

        vm.NuevoPuesto = function () {
            vm.tipoServicio = {};
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = true;
        };

        vm.ValidarAccion = function () {
            vm.tipoServicio.ClaveClasificadorServicio = vm.tipoClasificador.RIDItemCatalogo;
            if (vm.btnGuardar) {
                vm.GuardarObjetoNegocio();
            } else {
                vm.ActualizarObjetoNegocio();
            }
        }

        vm.ValidarTarea = function (objetoNegocio, tarea) {
            if (tarea == 'Actualizar') {
                vm.btnGuardar = false;
                vm.btnEliminar = true;
                vm.btnActualizar = true;
                //console.log(objetoNegocio);
                vm.tipoServicio = objetoNegocio;
                vm.setModeloInicial();
                //vm.setTipoClasificador(vm.tipoClasificador);
            }
            MostrarFormularios();
        };

        vm.GuardarObjetoNegocio = function () {
            vm.tipoServicio.NombreServicio = vm.tipoServicio.NombreServicio.toUpperCase();
            vm.tipoServicio.Abreviatura = vm.tipoServicio.Abreviatura.toUpperCase();
            vm.tipoServicio.Descripcion = vm.tipoServicio.Descripcion.toUpperCase();
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas guardar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetCatTipoServicios, vm.tipoServicio);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.tipoServicio = {};
                                vm.mdmForm.$setPristine();
                                vm.MostrarListado();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                }
            );
        };


        vm.ActualizarObjetoNegocio = function () {
            vm.tipoServicio.NombreServicio = vm.tipoServicio.NombreServicio.toUpperCase();
            vm.tipoServicio.Abreviatura = vm.tipoServicio.Abreviatura.toUpperCase();
            vm.tipoServicio.Descripcion = vm.tipoServicio.Descripcion.toUpperCase();
            Swal.fire(
                {
                    target: document.getElementById('default-example-modal-lg'),
                    title: "Gobierno Digital",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.ActualizarObjetoNegocio(rutas.UpdateCatTipoServicios, vm.tipoServicio);
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

        vm.EliminarObjetoNegocio = function () {
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    html: '¿Deseas eliminar el servicio?',
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        if (seleccion.value) {
                            var result = administracionServices.EliminarObjetoNegocio(rutas.EliminarServicio, vm.tipoServicio);
                            //console.log(result);
                            if (!result.ExisteError) {
                                location.reload();
                                MensajeRegresoServidor(result, "success");
                            } else {
                                MensajeRegresoServidor(result, "error");
                            }
                        }
                    }
                }
                );
        };

        vm.setTipoClasificador = function (tipoClasificador)
        {
            tipoClasificador;
            vm.tipoClasificador = tipoClasificador;
        }

        vm.CargarImagen = function (e) {
            var reader = new FileReader();
            reader.onload = function (e) {
                vm.tipoServicio.ImagenModelo = e.target.result;
                vm.$apply();
            };
            reader.readAsDataURL(e.target.files[0]);
            vm.tipoServicio.DirectorioSecundario = e.target.files[0].name;
            console.log(vm.tipoServicio.ImagenModelo);
        }

        vm.MostrarListado = function () {
            vm.tablaTipoServicio = administracionServices.GetConsultaAdministracion(rutas.GetCatTipoServicios);
            MostrarFormularios();
        };


    }])