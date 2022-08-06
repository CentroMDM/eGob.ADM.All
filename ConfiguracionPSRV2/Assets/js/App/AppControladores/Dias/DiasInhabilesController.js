diasInhabiles.controller("crtlDiasInhabiles", ["$scope", "$timeout", "$window", "administracionServices", "$http",
//diasInhabiles.controller("crtlDiasInhabiles", ["$scope", "$timeout", "$window", "administracionServices", "$http", "$rootScope",

    function (vm = $scope, $timeout, $window, administracionServices, $http,) {
    //function (vm = $scope, $timeout, $window, administracionServices, $http, vg = $rootScope) {

        const rutas = Administracion["DiasInhabiles"];
        

        //console.log("Conf_ - Dias");
        //console.log(
        //    JSON.parse(localStorage.getItem("Conf_"))
        //);
        //vg.MenuIzq = JSON.parse(localStorage.getItem("Conf_.Menu"));




        vm.MotivoDiaInhabil = {};
        vm.EntidadFederativa = {};
        vm.MotivoDiasInhabiles = {};
        vm.CatDiasInhabiles = {};
        vm.Municipio = {};
        vm.btnGuardar = false;
        vm.btnActualizar = false;
        vm.btnEliminar = false;
        vm.mostrarFechaFinal = true;


        this.$onInit = () => {
            vm.lstAplicafor = administracionServices.GetConsultaAdministracion(rutas.GetDescriptivoItems);

            vm.tablaDiasInhabiles = administracionServices.GetConsultaAdministracion(rutas.GetCatDiasInhabiles);
            vm.implementacion = administracionServices.GetConsultaAdministracion(rutas.GetImplementacion);
            vm.IniciarCatalogos();
            for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                var FInicio = new Date(parseInt(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", "")),);
                vm.tablaDiasInhabiles[i].FechaDiaInhabil = FInicio.getDate() + "/" + (FInicio.getMonth() + 1) + "/" + FInicio.getFullYear();
                //var day = FInicio.getDate();var month = FInicio.getMonth() + 1;var year = FInicio.getFullYear();
                //vm.tablaDiasInhabiles[i].FechaDiaInhabil = day + "/" + month + "/" + year;
            }     
        }

        vm.ValidarTarea = (objetoNegocio, tarea) => {
            if (tarea == 'Actualizar') {
                vm.btnGuardar = false;
                vm.btnActualizar = true;
                vm.btnEliminar = true;
                vm.CatDiasInhabiles = objetoNegocio;
                //vm.CatDiasInhabiles.FechaDiaInhabil = fromDateToString(new Date(parseInt(vm.CatDiasInhabiles.FechaDiaInhabil.replace("/Date(", "").replace(")/", ""), 10)));
                //vm.CatDiasInhabiles.FechaDiaInhabil = fromDateToString(new Date(parseInt(vm.CatDiasInhabiles.FechaDiaInhabil.replace("/Date(", "").replace(")/", ""), 10)));
                vm.CatDiasInhabiles.FechaDiaInhabilFinal = angular.copy(vm.CatDiasInhabiles.FechaDiaInhabil);

                //Llenamos la seleccion
                vm.EntidadFederativa = vm.EntidadesFederativas.find(item => {
                    return item.RIDEntidad === vm.CatDiasInhabiles.ClaveEntidadFederativa;
                });
                vm.setEntidadFederativa(vm.EntidadFederativa);
                
                vm.Municipio = vm.Municipios.find(item => {
                    return item.RIDMunicipio === vm.CatDiasInhabiles.ClaveMunicipio;
                });
                //B
                vm.MotivoDiasInhabiles = vm.tablaMotivosDiasInhabiles.find(item => {
                    return item.RIDMotivoDias === vm.CatDiasInhabiles.ClaveMotivoDiasInhabiles;
                });
                vm.Aplica = vm.lstAplicafor.find(item => {
                    return item.RIDItemCatalogo === vm.CatDiasInhabiles.ClaveAplicaPara;
                });  
            }
            vm.mostrarFechaFinal = false;
            MostrarFormularios();
        }
        vm.CleaForm = () => {
            vm.CatDiasInhabiles = {};
            vm.MotivoDiasInhabiles = {};
            vm.Municipio = {};
            vm.WFDefinicion = {}; //Dejamos la Definicion para poder guardar los procesos y etapas
            vm.CatDiasInhabiles = {};
            vm.MotivoDiasInhabiles = {};
            vm.Aplica = {};
        }
        vm.MostrarListado = () => {
            $("#formMunicipio").empty();
            MostrarFormularios();
        }
        vm.NuevoPuesto = () => {
            vm.MotivoDiasInhabiles = {};
            vm.MotivoDiaInhabil.Motivo = '';
            vm.Aplica = {};
            vm.btnGuardar = true;
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.CleaForm();
            vm.mostrarFechaFinal = true;
            vm.setEntidadFederativa(vm.EntidadFederativa);
            MostrarFormularios();
        };
        vm.CerrarModal = () => {
            $('#frmMotivos').modal('hide');
        }
        vm.CerrarModalCambios = () => {
            $('#frmMotivosCambios').modal('hide');
        }

        vm.IniciarCatalogos = () => {
            vm.GetMotivoDiasInhabiles();
            vm.EntidadesFederativas = administracionServices.GetConsultaAdministracion(rutas.GetImpEntidadesFederativas);
            vm.EntidadFederativa = vm.EntidadesFederativas.find(item => {
                return item.RIDEntidad === vm.implementacion.Estado;
            });
            vm.setEntidadFederativa(vm.EntidadFederativa);
        }
        vm.setEntidadFederativa = (EntidadFederativa) => {
            vm.EntidadFederativa = EntidadFederativa;
            vm.Municipios = administracionServices.GetConsultaAdministracionConParametro(rutas.GetImpMunicipios, vm.EntidadFederativa);
        }
        vm.setMunicipio = (Municipio) => {
            vm.Municipio = Municipio;
        }
        vm.setMotivoDiasInhabiles = (MotivoDiasInhabiles) => {
            vm.MotivoDiasInhabiles = MotivoDiasInhabiles;
        }

        vm.ValidarAccion = () => {
            vm.CatDiasInhabiles.ClaveMotivoDiasInhabiles = vm.MotivoDiasInhabiles.RIDMotivoDias;
            vm.CatDiasInhabiles.ClaveEntidadFederativa = vm.EntidadFederativa.RIDEntidad;
            vm.CatDiasInhabiles.ClaveMunicipio = vm.Municipio.RIDMunicipio;
            if (compareDates(vm.CatDiasInhabiles.FechaDiaInhabil, vm.CatDiasInhabiles.FechaDiaInhabilFinal)) {
                MensajeGeneral("La fecha final no puede ser menor a la fecha inicial", "info");
                return;
            }
            if (vm.btnGuardar) {
                vm.listaNoValidos = vm.Validaciones();
                if (vm.listaNoValidos.length > 0) {
                    MensajeGeneral("La(s) siguiente(s) fechas no son validas: " + vm.listaNoValidos.join(), "info");
                } else {
                    vm.GuardarObjetoDiaInhabil();
                }

            } else {
                vm.ActualizarObjetoDiaInhabil();
            }
        }
        vm.eliminarFecha = () => {
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas eliminar?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.EliminarObjetoNegocio(rutas.DeleteCatDiasInhabiles, vm.CatDiasInhabiles);
                        $('.tablaPSRPrincipal').DataTable().clear().destroy();
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.tablaDiasInhabiles = administracionServices.GetConsultaAdministracion(rutas.GetCatDiasInhabiles);
                                for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                                    var FInicio = new Date(parseInt(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", "")),);
                                    vm.tablaDiasInhabiles[i].FechaDiaInhabil = FInicio.getDate() + "/" + (FInicio.getMonth() + 1) + "/" + FInicio.getFullYear();
                                }
                                vm.ReshapeTable('dt-resumen');
                                MostrarFormularios();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        }
        vm.Validaciones = () => {
            vm.fecInicial = stringToDate(vm.CatDiasInhabiles.FechaDiaInhabil, 'dd/mm/yyyy', '/');
            vm.fecFinal = stringToDate(vm.CatDiasInhabiles.FechaDiaInhabilFinal, 'dd/mm/yyyy', '/');
            vm.fechasInvalidas = [];
            while (vm.fecInicial <= vm.fecFinal) {
                for (let i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                    vm.validate = new Date(parseInt(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", ""), 10));
                    //vm.validate = new Date(parseInt(vm.tablaDiasInhabiles[i].FechaInicioDiaInhabil.replace("/Date(", "").replace(")/", ""), 10));
                    if (vm.fecInicial.getTime() === vm.validate.getTime()) {
                        vm.fechasInvalidas.push(fromDateToString(vm.fecInicial));
                        break;
                    }
                }
                vm.fecInicial = vm.fecInicial.addDays(1);
            }
            return vm.fechasInvalidas;
        }
        vm.GuardarObjetoDiaInhabil = () => {
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
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetCatDiasInhabiles, vm.CatDiasInhabiles);
                        $('.tablaPSRPrincipal').DataTable().clear().destroy();
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.WFDefinicion = {}; //Dejamos la Definicion para poder guardar los procesos y etapas
                                vm.CatDiasInhabiles = {};
                                vm.MotivoDiasInhabiles = {};
                                //vm.EntidadFederativa = {};
                                vm.Municipio = {};
                                vm.Aplica = {};

                                //vm.CleaForm();
                                //vm.ReloadTable();
                                //vm.mdmForm.$setPristine();
                                vm.tablaDiasInhabiles = administracionServices.GetConsultaAdministracion(rutas.GetCatDiasInhabiles);
                                for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                                    var FInicio = new Date(parseInt(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", "")),);
                                    vm.tablaDiasInhabiles[i].FechaDiaInhabil = FInicio.getDate() + "/" + (FInicio.getMonth() + 1) + "/" + FInicio.getFullYear();
                                }
                                vm.ReshapeTable('dt-resumen');
                                MostrarFormularios();
                            })
                        }
                        else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                }
            );
        };
        vm.ActualizarObjetoDiaInhabil = function () {
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
                        vm.CatDiasInhabiles.FechaDiaInhabilFinal = vm.CatDiasInhabiles.FechaDiaInhabil;
                        var result = administracionServices.ActualizarObjetoNegocio(rutas.UpdateCatDiasInhabiles, vm.CatDiasInhabiles);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                //vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
                                vm.CatDiasInhabiles = {};
                                vm.tablaDiasInhabiles = administracionServices.GetConsultaAdministracion(rutas.GetCatDiasInhabiles);
                                for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                                    var FInicio = new Date(parseInt(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", "")),);
                                    vm.tablaDiasInhabiles[i].FechaDiaInhabil = FInicio.getDate() + "/" + (FInicio.getMonth() + 1) + "/" + FInicio.getFullYear();
                                }
                                vm.ReshapeTable('dt-resumen');
                                
                            })
                            MostrarFormularios();
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        //Motivos
        vm.GetMotivoDiasInhabiles = () => {
            vm.tablaMotivosDiasInhabiles = administracionServices.GetConsultaAdministracion(rutas.GetMotivoDiasInhabil);
        }
        vm.ValidarMotivoDiaInhabil = (objetoMotivo) => {
            //vm.MotivoDiaInhabil = objetoMotivo;
            var eliminaMotivo = objetoMotivo;

            for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                if (vm.tablaDiasInhabiles[i].ClaveMotivoDiasInhabiles === eliminaMotivo.RIDMotivoDias && vm.tablaDiasInhabiles[i].ClaveStatus === 1) {

                    return MensajeGeneral("No se puede eliminar ");
                }
            }
            vm.ActualizarObjetoNegocio(eliminaMotivo);
        }
        vm.ValidarMotivo = () => {
            if (vm.MotivoDiaInhabil.Motivo) {
                if (vm.MotivoDiaInhabil.Motivo.trim() === '') {
                    MensajeGeneral("El campo no puede contener elementos vacios", "info")
                    vm.MotivoDiaInhabil.Motivo = '';
                    return false
                } else {
                    //validamos que no existe un motivo similar
                    let aux = vm.tablaMotivosDiasInhabiles.find(function (item) {
                        return item.Motivo === vm.MotivoDiaInhabil.Motivo;
                    })
                    if (aux) {
                        MensajeGeneral("El motivo ya se encuentra registrado", "info")
                        MotivoDiaInhabil.Motivo = '';
                        return false;
                    } else {
                        return true;
                    }
                }
            } else {
                MensajeGeneral("El campo contiene caracteres no validos o no contiene la estructura adecuada ", "info")
                return false;
            }
        }

        vm.GuardarNuevoMotivo = () => {
            if (vm.ValidarMotivo()) {
                vm.MotivoDiaInhabil.ClaveStatus = 1;
                vm.GuardarObjetoMotivo();
            }
        }
        vm.ActualizarMotivo = () => {
            if (vm.ValidarMotivo()) {
                vm.ActualizarObjetoNegocio();
            }
        }
        vm.GuardarObjetoMotivo = () => {
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas guardar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(seleccion =>  {
                    if (seleccion.value) {
                        var result = administracionServices.IngresarObjetoNegocio(rutas.SetMotivoDiasInhabil, vm.MotivoDiaInhabil);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(() => {
                                //vm.WFDefinicion = {}; Dejamos la Definicion para poder guardar los procesos y etapas
                                vm.GetMotivoDiasInhabiles();
                                vm.MotivoDiaInhabil.Motivo = '';
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };
        vm.ActualizarObjetoNegocio = (eliminaMotivo) => {
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas Actualizar?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(seleccion => {
                    if (seleccion.value) {
                        var result = administracionServices.ActualizarObjetoNegocio(rutas.UpdateMotivoDiasInhabil, eliminaMotivo);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");

                            $timeout(() => {
                                //vm.tablaDefinicion = administracionServices.GetConsultaAdministracion(rutas.GetWorkFlowDefinicion);
                                vm.GetMotivoDiasInhabiles();
                                vm.ReshapeTable('TbMotivos');
                                //vm.MotivoDiaInhabil = {};
                                //$('#frmMotivosCambios').modal('hide');

                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                }
             );
        };

        vm.ReshapeTable = (name) => {
            $timeout(() => { reloadTableWithName(name); });
        }



        //Aplica Para
        vm.setAplica = function (Aplica) {
            vm.CatDiasInhabiles.ClaveAplicaPara = Aplica.RIDItemCatalogo;
        }

        //vm.ReloadTable = () => {
        //    $timeout(() => {
        //        $('.tablaPSRPrincipal').DataTable(
        //            {
        //                responsive: true,
        //                lengthChange: false,
        //                language: {
        //                    search: '<div class=" d-inline-flex width-5 align-items-center justify-content-center border-bottom-right-radius-0 border-top-right-radius-0 border-right-0"><i class="fal fa-search"></i></div>',
        //                    searchPlaceholder: "Buscar",
        //                    zeroRecords: " ",
        //                    paginate: {
        //                        "first": "Primero",
        //                        "last": "Ultimo",
        //                        "next": "Siguiente",
        //                        "previous": "Previo"
        //                    },
        //                    info: "Mostrando _START_ de _END_ de _TOTAL_ registros",
        //                    infoEmpty: "Sin registros"
        //                },
        //                "columnDefs": [
        //                    { "className": "dt-center", "targets": "_all" }
        //                ],
        //                dom:
        //                    "<'row mb-3'<'col-sm-12 col-md-6 d-flex align-items-center justify-content-start'f><'col-sm-12 col-md-6 d-flex align-items-center justify-content-end'lB>>" +
        //                    "<'row'<'col-sm-12'tr>>" +
        //                    "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
        //                buttons: [
        //                    {
        //                        extend: 'excelHtml5',
        //                        text: 'Excel',
        //                        titleAttr: 'Generate Excel',
        //                        className: 'btn btn-info btn-sm mr-1'
        //                    },
        //                    {
        //                        extend: 'csvHtml5',
        //                        text: 'CSV',
        //                        titleAttr: 'Generate CSV',
        //                        className: 'btn btn-info btn-sm mr-1'
        //                    }
        //                ]
        //            });
        //    }, 0);
        //}

    }])