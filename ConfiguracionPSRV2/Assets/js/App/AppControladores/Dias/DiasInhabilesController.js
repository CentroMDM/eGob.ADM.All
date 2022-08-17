diasInhabiles.controller("crtlDiasInhabiles", ["$scope", "$timeout", "$window", "administracionServices", "$http",

    function (vm = $scope, $timeout, $window, administracionServices, $http,) {

        const rutas = Administracion["DiasInhabiles"];
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
            vm.lstAplicafor = administracionServices.MetodPOST(rutas.GetDescriptivoItems);

            vm.tablaDiasInhabiles = administracionServices.MetodPOST(rutas.GetCatDiasInhabiles);
            vm.implementacion = administracionServices.MetodPOST(rutas.GetImplementacion);
            vm.IniciarCatalogos();
            for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                var FInicio = vm.tablaDiasInhabiles[i].FechaDiaInhabil.slice(0, 10);
                var dateParts = FInicio.split("-");
                vm.tablaDiasInhabiles[i].FechaDiaInhabil = dateParts[2] + "/" + dateParts[1] + "/" + dateParts[0];
            }     
        }
        vm.changeFecha = () => {
            if (vm.btnGuardar == false && vm.btnActualizar == true) {
                vm.CatDiasInhabiles.FechaDiaInhabilFinal = vm.CatDiasInhabiles.FechaDiaInhabil;
            }
        }
        vm.ValidarTarea = (objetoNegocio, tarea) => {
            if (tarea == 'Actualizar') {
                vm.btnGuardar = false;
                vm.btnActualizar = true;
                vm.btnEliminar = true;
                vm.CatDiasInhabiles = objetoNegocio;
                vm.CatDiasInhabiles.FechaDiaInhabilCopy = JSON.parse(JSON.stringify(vm.CatDiasInhabiles.FechaDiaInhabil));
                vm.CatDiasInhabiles.FechaDiaInhabilFinal = vm.CatDiasInhabiles.FechaDiaInhabil;
                //vm.CatDiasInhabiles.FechaDiaInhabil = fromDateToString(new Date(parseInt(vm.CatDiasInhabiles.FechaDiaInhabil.replace("/Date(", "").replace(")/", ""), 10)));
                //vm.CatDiasInhabiles.FechaDiaInhabil = fromDateToString(new Date(parseInt(vm.CatDiasInhabiles.FechaDiaInhabil.replace("/Date(", "").replace(")/", ""), 10)));

                //vm.CatDiasInhabiles.FechaDiaInhabilFinal = angular.copy(vm.CatDiasInhabiles.FechaDiaInhabil);

                vm.EntidadFederativa = vm.EntidadesFederativas.find(item => {
                    return item.RIDEntidad === vm.CatDiasInhabiles.ClaveEntidadFederativa;
                });
                vm.setEntidadFederativa(vm.EntidadFederativa);
                
                //vm.Municipio = vm.Municipios.find(item => {
                //    return item.RIDMunicipio === vm.CatDiasInhabiles.ClaveMunicipio;
                //});
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
            vm.WFDefinicion = {};
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
            vm.EntidadesFederativas = administracionServices.MetodPOST(rutas.GetImpEntidadesFederativas);
            vm.EntidadFederativa = vm.EntidadesFederativas.find(item => {
                return item.RIDEntidad === vm.implementacion.Estado;
            });
            vm.setEntidadFederativa(vm.EntidadFederativa);
        }
        vm.setEntidadFederativa = (EntidadFederativa) => {
            vm.EntidadFederativa = EntidadFederativa;
            vm.Municipios = administracionServices.MetodPOST(rutas.GetImpMunicipios, vm.EntidadFederativa);
        }
        vm.setMunicipio = (Municipio) => {
            vm.Municipio = Municipio;
        }
        vm.setMotivoDiasInhabiles = (MotivoDiasInhabiles) => {
            vm.MotivoDiasInhabiles = MotivoDiasInhabiles;
        }
        vm.FormatoFecha = function (fecha) {
            //var date = new Date(fecha);
            var dateParts = fecha.split("/");
            var date = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]); 
            var day = date.getDate();       // yields date
            var month = date.getMonth() + 1;    // yields month (add one as '.getMonth()' is zero indexed)
            var year = date.getFullYear();  // yields year
            var hour = date.getHours();     // yields hours 
            var minute = date.getMinutes(); // yields minutes
            var second = date.getSeconds(); // yields seconds

            // After this construct a string with the above results as below
            var time = month + "/" + day + "/" + year + " " + hour + ':' + minute + ':' + second;
            return time;
            //return DateTime.ParseExact(time, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
        vm.ValidarAccion = () => {
            vm.CatDiasInhabiles.ClaveMotivoDiasInhabiles = vm.MotivoDiasInhabiles.RIDMotivoDias;
            vm.CatDiasInhabiles.ClaveEntidadFederativa = vm.EntidadFederativa.RIDEntidad;
            //vm.CatDiasInhabiles.ClaveMunicipio = vm.Municipio.RIDMunicipio;
            if (vm.CatDiasInhabiles.FechaDiaInhabilCopy!=undefined) {
                vm.CatDiasInhabiles.FechaDiaInhabil = vm.CatDiasInhabiles.FechaDiaInhabilCopy;                
            }
            if (compareDates(vm.CatDiasInhabiles.FechaDiaInhabil, vm.CatDiasInhabiles.FechaDiaInhabilFinal)) {
                return MensajeGeneral("La fecha final no puede ser menor a la fecha inicial", "info");
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
                        var result = administracionServices.MetodPOST(rutas.DeleteCatDiasInhabiles, vm.CatDiasInhabiles);
                        $('.tablaPSRPrincipal').DataTable().clear().destroy();
                        if (!result.ExisteError) {
                            vm.tablaDiasInhabiles = administracionServices.MetodPOST(rutas.GetCatDiasInhabiles);
                            for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                                var FInicio = new Date(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", ""),);
                                vm.tablaDiasInhabiles[i].FechaDiaInhabil = FInicio.getDate() + "/" + (FInicio.getMonth() + 1) + "/" + FInicio.getFullYear();
                            }
                            MensajeRegresoServidor(result, "success");
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
                    vm.validate = new Date(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", ""), 10);
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
                        vm.CatDiasInhabiles.FechaDiaInhabil = vm.FormatoFecha(vm.CatDiasInhabiles.FechaDiaInhabil);
                        vm.CatDiasInhabiles.FechaDiaInhabilFinal = vm.FormatoFecha(vm.CatDiasInhabiles.FechaDiaInhabilFinal);
                        var result = administracionServices.MetodPOST(rutas.SetCatDiasInhabiles, vm.CatDiasInhabiles);
                        $('.tablaPSRPrincipal').DataTable().clear().destroy();
                        if (!result.ExisteError) {
                            vm.WFDefinicion = {};
                            vm.CatDiasInhabiles = {};
                            vm.MotivoDiasInhabiles = {};
                            vm.Municipio = {};
                            vm.Aplica = {};
                            vm.tablaDiasInhabiles = administracionServices.MetodPOST(rutas.GetCatDiasInhabiles);
                            for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                                var FInicio = new Date(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", ""),);
                                vm.tablaDiasInhabiles[i].FechaDiaInhabil = FInicio.getDate() + "/" + (FInicio.getMonth() + 1) + "/" + FInicio.getFullYear();
                            }
                            MensajeRegresoServidor(result, "success");
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
                        //vm.CatDiasInhabiles.FechaDiaInhabilFinal = vm.CatDiasInhabiles.FechaDiaInhabil;
                        vm.CatDiasInhabiles.FechaDiaInhabil = vm.FormatoFecha(vm.CatDiasInhabiles.FechaDiaInhabil);
                        vm.CatDiasInhabiles.FechaDiaInhabilFinal = vm.FormatoFecha(vm.CatDiasInhabiles.FechaDiaInhabilFinal);
                        var result = administracionServices.MetodPOST(rutas.UpdateCatDiasInhabiles, vm.CatDiasInhabiles);
                        if (!result.ExisteError) {
                            vm.CatDiasInhabiles = {};
                            vm.tablaDiasInhabiles = administracionServices.MetodPOST(rutas.GetCatDiasInhabiles);
                            for (var i = 0; i < vm.tablaDiasInhabiles.length; i++) {
                                var FInicio = new Date(vm.tablaDiasInhabiles[i].FechaDiaInhabil.replace("/Date(", "").replace(")/", ""),);
                                vm.tablaDiasInhabiles[i].FechaDiaInhabil = FInicio.getDate() + "/" + (FInicio.getMonth() + 1) + "/" + FInicio.getFullYear();
                            }
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                }
            );
        };
        vm.GetMotivoDiasInhabiles = () => {
            vm.tablaMotivosDiasInhabiles = administracionServices.MetodPOST(rutas.GetMotivoDiasInhabil);
        }
        vm.ValidarMotivoDiaInhabil = (objetoMotivo) => {
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
                        var result = administracionServices.MetodPOST(rutas.SetMotivoDiasInhabil, vm.MotivoDiaInhabil);
                        if (!result.ExisteError) {
                            vm.GetMotivoDiasInhabiles();
                            vm.MotivoDiaInhabil.Motivo = '';
                            Swal.fire('', 'La información se almacenó correctamente', 'success'); 
                            //MensajeRegresoServidor(result, "success");
                        } else {
                            Swal.fire('', 'No se ha podido actualizar la información', 'error');
                            //MensajeRegresoServidor(result, "error");
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
                        var result = administracionServices.MetodPOST(rutas.UpdateMotivoDiasInhabil, eliminaMotivo);
                        if (!result.ExisteError) {
                            vm.GetMotivoDiasInhabiles();
                            //MensajeRegresoServidor(result, "success");
                            Swal.fire('', 'La información se almacenó correctamente', 'success'); 
                        } else {
                            //MensajeRegresoServidor(result, "error");
                            Swal.fire('', 'No se ha podido actualizar la información', 'error');
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
    }])