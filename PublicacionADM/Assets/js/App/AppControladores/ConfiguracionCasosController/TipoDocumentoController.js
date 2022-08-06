configuracionTipoDocumentos.controller("configTipoDocto", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {

        var rutas = Administracion["ConfiguracionCasos"];
        vm.btnActualizar = false;
        vm.btnGuardar = false;
        vm.tipoDocumento = {};
        vm.tipoArchivo = {};

        vm.tablaTipoDocumento = administracionServices.GetConsultaAdministracion(rutas.GetCatTipoDocumentos);
        //vm.tipoDocumento.TipoArchivo = vm.lstTipoArchivo.find(item => {
        //    return vm.tipoDocumento.ClaveExtencion === item.RID;
        //});

        vm.GetExtenciones = function () {
            if (vm.lstTipoArchivo === undefined) {
                vm.lstTipoArchivo = administracionServices.GetConsultaAdministracion(rutas.GetlstExtenciones);
            }
        }       
        

        vm.changeTipoArchivo = function (tFile) {
            vm.TipoArchivo = tFile;
            if (vm.TipoArchivo != undefined) {
                vm.bMostrarExt = true;
            }
            else {
                vm.bMostrarExt = false;
            }
        }

        vm.NuevoPuesto = function () {
            vm.tipoDocumento = {};
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnGuardar = true;
            vm.bMostrarExt = false;
        };
        //Editar Archivo
        vm.ValidarTarea = function (objetoNegocio, tarea) {
            if (tarea == 'Actualizar') {
                vm.btnGuardar = false;
                vm.btnActualizar = true;
                vm.tipoDocumento = objetoNegocio;
                vm.TblRarchivoExtenciones = administracionServices.GetConsultaAdministracionConParametro(rutas.GetRarchivoExtenciones, vm.tipoDocumento);
            }
            MostrarFormularios();
        };
        //Guardar o Actualizar
        vm.ValidarAccion = function () {
            if (vm.btnGuardar) {
                vm.GuardarObjetoNegocio();
            } else {
                vm.ActualizarObjetoNegocio();
            }
        }
        vm.GuardarObjetoNegocio = function () {
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
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetCatTipoDocumentos, vm.tipoDocumento);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.tipoDocumento = {};
                                vm.mdmForm.$setPristine();
                                vm.tablaTipoDocumento = administracionServices.GetConsultaAdministracion(rutas.GetCatTipoDocumentos);
                                vm.ReshapeTable('dt-resumen');
                                MostrarFormularios();
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
                    target: document.getElementById('default-example-modal-lg'),
                    title: "Gobierno Digital",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.ActualizarObjetoNegocio(rutas.UpdateCatTipoDocumentos, vm.tipoDocumento);
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

        vm.NuevoTipoArchivo = function (nuevotipoarchivo) {
            if (NombreTipoArchivo in nuevotipoarchivo) {
                if (Extencion in nuevotipoarchivo) {
                    if (TypeMime in nuevotipoarchivo) {
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetCatTipoArchivo, nuevotipoarchivo);
                    } else {
                        return MensajeGeneral("El Tipo MIME no puede estar vacío", 'info');
                    }
                } else {
                    return MensajeGeneral("La extención no puede estar vacía", 'info');
                }
            } else {
                return MensajeGeneral("El nombre no puede estar vacío",'info');
            }
           
        }
        






        vm.CerrarModal = () => {
            $(frmTipoArchivo).modal('hide');
        }
        vm.MostrarListado = function () {
            vm.tablaTipoDocumento = {};
            vm.tablaTipoDocumento = administracionServices.GetConsultaAdministracion(rutas.GetCatTipoDocumentos);
            //vm.tablaTipoDocumento = administracionServices.GetConsultaAdministracion(rutas.GetlstTipoArchivo);
            MostrarFormularios();
        };
        //vm.ReshapeTable = (name) => {
        //    $timeout(() => { reloadTableWithName(name); });
        //}

    }])