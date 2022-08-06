formatosSecciones.controller("crtlFormatosSecciones", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        const RUTAS = Administracion["ConfiguracionCasos"];

        vm.casoFormato = {};
        vm.casoSecciones = {};
        //vm.casoConfiguracion = {};
        vm.variables = {};
        vm.variable = {};
        vm.btnGuardar = false;
        vm.btnActualizar = false;
        vm.btnGuardarSecciones = false;
        vm.btnActualizarSecciones = false;
        vm.btnGuardarVariable = false;
        vm.btnActualizarVariable = false;
        vm.variableSeccion = {};

        vm.btnAddSecciones = true;
        vm.btnAddVariables = false;

        this.$onInit = () => {
            vm.TablaFormato = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasocformatos);
            //vm.CasoConfiguracion = administracionServices.GetConsultaAdministracion(RUTAS.GetCasoConfiguracion);
        }

        vm.FiltrarSecciones = () => {
            vm.TablaSecciones = vm.TablaSeccionesCompleta.filter(item => {
                return item.ClaveFormato === vm.casoFormato.RIDFormato
            })
        }

        //vm.FiltrarCasoConfiguracion = () => {
        //    vm.casoConfiguracion = vm.CasoConfiguracion.find(item => {
        //        return item.RIDCCaso === vm.casoFormato.ClaveCCaso;
        //    })
        //}

        //vm.setCasoConfiguracion = casoConfiguracion => vm.casoConfiguracion = casoConfiguracion;

        vm.NuevoPuesto = () => {
            vm.btnGuardar = true;
            vm.btnActualizar = false;
            vm.btnAddSecciones = true;
            MostrarFormularios();
        };

        vm.ValidarTareaFormato = (objetoNegocio, opcion) => {
            vm.casoFormato = objetoNegocio;
            vm.TablaSeccionesCompleta = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasoscformatoseccion);
            vm.FiltrarSecciones();
            //vm.FiltrarCasoConfiguracion();
            if (opcion == 'Actualizar') {
                vm.btnGuardar = false;
                vm.btnActualizar = true;
                vm.btnAddSecciones = false;
            }
            MostrarFormularios();
        }

        vm.CargarImagen = e => {
            var reader = new FileReader();
            reader.onload = e => {
                vm.casoFormato.ImagenModelo = e.target.result;
                vm.$apply();
            };
            reader.readAsDataURL(e.target.files[0]);
            var extensionesValidas = ["png", "svg", "PNG", "SVG"];
            if (extensionesValidas.find(element => element == e.target.files[0].name.slice(((e.target.files[0].name.lastIndexOf(".") - 1) + 2))) == undefined) {
                return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
            }
            else {
                vm.casoFormato.DirectorioSecundario = e.target.files[0].name;    
            }
        }

        vm.MostrarListado = () => {
            vm.TablaFormato = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasocformatos);
            MostrarFormularios();
        }

        vm.ValidarAccion = () => {
            //vm.casoFormato.ClaveCCaso = vm.casoConfiguracion.RIDCCaso;
            if (vm.btnGuardar) {
                vm.GuardarObjetoFormato();
            } else {
                vm.ActualizarObjetoFormato();
            }
        }

        vm.GuardarObjetoFormato = () => {
            var extensionesValidas = ["png", "svg", "PNG", "SVG"];
            if (extensionesValidas.find(element => element == vm.casoFormato.DirectorioSecundario.slice(((vm.casoFormato.DirectorioSecundario.lastIndexOf(".") - 1) + 2))) == undefined) {
                return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
            } else {
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
                            var result = administracionServices.IngresarObjetoNegocio(RUTAS.SetTcasocformatos, vm.casoFormato);
                            if (!result.ExisteError) {
                                MensajeRegresoServidor(result, "success");
                                $timeout(function () {
                                    vm.btnAddSecciones = false;
                                    vm.btnGuardar = false;
                                    vm.btnActualizar = true;
                                    vm.casoFormato.RIDFormato = result.Dato;
                                    vm.mdmForm.$setPristine();
                                })
                            } else {
                                MensajeRegresoServidor(result, "error");
                            }
                        }
                    }
                );
            }            
        };

        vm.ActualizarObjetoFormato = () => {
            var extensionesValidas = ["png", "svg", "PNG", "SVG"];
            if (extensionesValidas.find(element => element == vm.casoFormato.DirectorioSecundario.slice(((vm.casoFormato.DirectorioSecundario.lastIndexOf(".") - 1) + 2))) == undefined) {
                return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
            } else {
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
                            var result = administracionServices.ActualizarObjetoNegocio(RUTAS.UpdateTcasocformatos, vm.casoFormato);
                            if (!result.ExisteError) {
                                MensajeRegresoServidor(result, "success");
                                $timeout(function () {
                                    //vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
                                    vm.MostrarListado();
                                    vm.mdmForm.$setPristine();
                                })
                            } else {
                                MensajeRegresoServidor(result, "error");
                            }
                        }
                    }
                );
            }            
        };

        vm.NuevoProceso = () => {
            vm.casoSecciones = {};
            vm.btnGuardarSecciones = true;
            vm.btnActualizarSecciones = false;
            vm.btnAddVariables = true;
            vm.TCasoFormatoVariables = {};
        }

        vm.CancelarProceso = () => {
            vm.NuevoProceso();
            $('#frmSecciones').modal('hide');
        }

        vm.ValidarAccionSecciones = () => {
            if (vm.btnGuardarSecciones) {
                vm.casoSecciones.ClaveFormato = vm.casoFormato.RIDFormato
                vm.GuardarObjetoSeccion();
            } else {
                vm.ActualizarObjetoSeccion();
            }
        }

        vm.GetSeccionVariables = () => {
            vm.TCasoFormatoVariables = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasoformatovariable);
            vm.TCasoFormatoVariables = vm.TCasoFormatoVariables.filter(item => (item.ClaveTipoFormulario === 46 && item.Clave === vm.casoSecciones.RIDSeccion));
        }

        vm.ValidarTareaSecciones = (objetoNegocio, opcion) => {
            vm.casoSecciones = objetoNegocio;
            vm.btnAddVariables = false;
            //Filtros
            vm.GetSeccionVariables();
            if (opcion == 'Actualizar') {
                vm.btnGuardarSecciones = false;
                vm.btnActualizarSecciones = true;
            }
        }

        vm.GuardarObjetoSeccion = () => {
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
                        var result = administracionServices.IngresarObjetoNegocio(RUTAS.SetTcasoscformatoseccion, vm.casoSecciones);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.casoSecciones.RIDSeccion = result.Dato;
                                vm.TablaSeccionesCompleta = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasoscformatoseccion);
                                vm.FiltrarSecciones();
                                vm.btnAddVariables = false;
                                vm.btnGuardarSecciones = false;
                                vm.btnActualizarSecciones = true;
                                //vm.CancelarProceso();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };


        vm.ActualizarObjetoSeccion = () => {
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
                        var result = administracionServices.ActualizarObjetoNegocio(RUTAS.UpdateTcasoscformatoseccion, vm.casoSecciones);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                //vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
                                vm.CancelarProceso();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        //Variables
        vm.NuevoProcesoVariable = () => {
            vm.variables = administracionServices.GetConsultaAdministracion(RUTAS.GetCatConfiguracionVariables);
            vm.btnGuardarVariable = true;
            vm.btnActualizarVariable = false;
        };

        vm.setVariables = objetoNegocio => (vm.variable = objetoNegocio);

        vm.NuevaVariables = () => {
            vm.variable = {};
        }

        vm.CancelarVariables = () => {
            vm.NuevaVariables();
            $('#frmVariables').modal('hide');
        }

        vm.ValidarTareaVariable = (objetoNegocio, opcion) => {
            vm.variableSeccion = objetoNegocio;
            if (!(vm.variables && vm.variables.length > 0)) {
                vm.variables = administracionServices.GetConsultaAdministracion(RUTAS.GetCatConfiguracionVariables);
            }
            vm.variable = vm.variables.find(item => (item.RIDVariable === vm.variableSeccion.ClaveVariable));
            if (opcion == 'Actualizar') {
                vm.btnGuardarVariable = false;
                vm.btnActualizarVariable = true;
            }
        }

        vm.ValidarAccionVariable = () => {

            vm.variableSeccion.ClaveTipoFormulario = 46;
            vm.variableSeccion.Clave = vm.casoSecciones.RIDSeccion;
            vm.variableSeccion.ClaveVariable = vm.variable.RIDVariable;
            if (vm.btnGuardarVariable) {
                vm.GuardarObjetoVariable();
            } else {
                vm.ActualizarObjetoVariable();
            }
        }

        vm.GuardarObjetoVariable = () => {
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
                        var result = administracionServices.IngresarObjetoNegocio(RUTAS.SetTcasoformatovariable, vm.variableSeccion);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.variableSeccion = {};
                                vm.variable = {};
                                vm.GetSeccionVariables();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.ActualizarObjetoVariable = () => {
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
                        var result = administracionServices.ActualizarObjetoNegocio(RUTAS.UpdateTcasoformatovariable, vm.variableSeccion);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                $('#frmVariables').modal('hide');
                                vm.variableSeccion = {};
                                vm.GetSeccionVariables();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.Preview = (tablaFormato) => {
            vm.htmlPreview = administracionServices.GetConsultaAdministracionConParametro(RUTAS.GetPreview, tablaFormato.RIDFormato);
            $('.previewModal').html(vm.htmlPreview);
            $('#modalPreview').modal({ show: true })
        }


    }]);

