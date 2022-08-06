empleados.controller("crtlEmpleado", ["$scope", "$timeout", "$window", "administracionServices", "$http",
    function (vm = $scope, $timeout, $window, administracionServices, $http) {

        let RUTAS = Administracion["Unidades"];
        vm.Empleado = {};

        vm.btnGuardar = false;
        vm.btnActualizar = false;
        vm.btnEliminar = false;
        vm.seActualiza = false;

        vm.IniciarAplicacion = () => {
            vm.UnidadesAdministrativas = administracionServices.GetConsultaAdministracion(RUTAS.GetUnidadesPuestos);
            vm.Empleados = administracionServices.GetConsultaAdministracion(RUTAS.ObtenerEmpleado);
            vm.PuestosAux = [];
            for (var i = 0, len = vm.UnidadesAdministrativas.length; i < len; i++) {
                vm.PuestosAux = vm.PuestosAux.concat(vm.UnidadesAdministrativas[i].Puestos);
            }
            //for (var i = 0; i < vm.Empleados.length; i++) {
            //    for (var j = 0; j < vm.PuestosAux.length; j++) {
            //        //console.log(vm.Empleados[i]);
            //        if (vm.Empleados[i].ClavePuesto === vm.PuestosAux[j].RIDPuestos) {
            //            vm.Empleados[i].PuestoInstitucional = vm.PuestosAux[j];
            //        }
            //    }
            //}
        }

        this.$onInit = () => {
            vm.IniciarAplicacion();
        }

        vm.MostrarListado = () => {
            vm.IniciarAplicacion();
            MostrarFormularios();
        }

        vm.BuscarUnidadDesdeEmpleado = (empleado) => {
            for (var i = 0, len = vm.UnidadesAdministrativas.length; i < len; i++) {
                for (var j = 0, lens = vm.UnidadesAdministrativas[i].Puestos.length; j < lens; j++) {
                    if (empleado.ClavePuesto === vm.UnidadesAdministrativas[i].Puestos[j].RIDPuestos) {
                        vm.unidad = vm.UnidadesAdministrativas[i];
                        vm.puesto = vm.UnidadesAdministrativas[i].Puestos[j];
                    }
                }    
            }
        }

        vm.setUnidadAdministrativa = (unidad) => {
            vm.unidad = unidad;
            vm.setPuesto = puesto => vm.puesto = puesto;
        }

        vm.EditarEmpleado = (empleado) => {
            vm.Empleado = empleado;
            vm.LogoConfiguracionLogo = vm.Empleado.DirectorioImagenesVirtual + vm.Empleado.DirectorioSecundarioFoto;
            vm.btnGuardar = false;
            vm.btnActualizar = true;
            vm.btnEliminar = true;
            vm.BuscarUnidadDesdeEmpleado(empleado);
            $timeout(function () {
                $('.status').select2();
            })
            vm.seActualiza = true;
            MostrarFormularios();
        }


        vm.NuevoPuesto = () => {
            vm.btnGuardar = true;
            vm.btnActualizar = false;
            vm.Empleado = {};
            vm.unidad = {};
            vm.puesto = {};
            vm.seActualiza = false;
            MostrarFormularios();
        };

        vm.cargaImagenRe = function () {
            var imgTem = $("#selectPhotoFoto").get(0);
            var fd = new FormData();
            fd.append("file", imgTem.files[0]);
            $http.post(
                //Función carga imagen
                RUTAS.CargarImagenEmpleado,
                fd,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined},
                    transformRequest: angular.identity
                }).then(function Succescallback(response) {
                    console.log(response);
                    //Muestra Imagen
                    var DSecundario = response.data.rutaArchivo;
                    vm.LogoConfiguracionLogo = response.data.rutaArchivo;
                    vm.Empleado.DirectorioSecundarioFoto = DSecundario.replace("../ExResources/FotografiaUsuarios/", "");
                    //vm.Empleado.DirectorioSecundarioFoto = response.data.rutaArchivo;
                    //console.log(vm.Empleado.DirectorioSecundarioFoto);
                }, function errorcallback(response) {
                });
        };


        vm.ValidarAccion = () => {
            if (vm.Empleado.RFCEmpleado.length != 13 && vm.Empleado.RFCEmpleado.length != 12) {
                Swal.fire('Ingrese un RFC valido')
            }
            else {
                console.log(vm.Empleado);
                if (vm.btnGuardar) {
                    vm.AgregarEmpleado();
                } else {
                    vm.ActualizarEmpleado();
                }
            }
        }

        vm.EliminarPuesto = () => {
            vm.EliminarObjetoNegocio();
        }

        vm.EliminarObjetoNegocio = () => {
            Swal.fire(
                {
                    target: document.getElementById('default-example-modal-lg'),
                    title: "PSR-Configuración",
                    text: "¿Deseas eliminar al empleado?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(seleccion => {
                    if (seleccion.value) {
                        var result = administracionServices.EliminarObjetoNegocio(RUTAS.EliminarEmpleado, vm.Empleado);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            location.reload();
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };

        vm.ActualizarEmpleado = () => {
            vm.Empleado.PuestoInstitucional = vm.puesto;
            vm.LogoConfiguracionLogo; /*= vm.newPuesto.DirectorioImagenesVirtual + vm.newPuesto.DirectorioSecundarioLogo;*/
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(seleccion => {
                    if (seleccion.value) {
                        var result = administracionServices.IngresarObjetoNegocio(RUTAS.ActualizarEmpleado, vm.Empleado);
                        if (!result.ExisteError) {
                            $timeout(() => {
                                MensajeRegresoServidor(result, "success");
                                location.reload();
                            });
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        }



        vm.AgregarEmpleado = () => {
            let seEncuentra = vm.Empleados.find(item => (item.NumeroEmpleado === vm.Empleado.NumeroEmpleado));

            //for (var i = 0, len = vm.Empleados.length; i < len; i++) {
            //    if (vm.Empleados[i].NumeroEmpleado === vm.Empleado.NumeroEmpleado) {
            //        existe = true;
            //        break;
            //    }
            //}
            if (seEncuentra && seEncuentra.NumeroEmpleado !== '') {
                MensajeGeneral("El numero de empleado ya existe", "info");
                return;
            }
            vm.Empleado.PuestoInstitucional = vm.puesto;
            //Ingresar Empleado a BD

            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(seleccion => {
                    if (seleccion.value) {
                        var result = administracionServices.IngresarObjetoNegocio(RUTAS.IngresarEmpleado, vm.Empleado);
                        if (!result.ExisteError) {
                            $timeout(() => {
                                MensajeRegresoServidor(result, "success");
                                vm.Empleado.RIDEmpleado = result.Dato;
                                vm.Empleado.NombreCompleto = vm.Empleado.Nombre + " " + vm.Empleado.APaterno + " " + vm.Empleado.AMaterno;
                                location.reload();
                                //vm.Empleados.push(vm.Empleado);
                                vm.Empleado = {};
                                vm.unidad = {};
                                vm.puesto = {};

                            });
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });

            //Fin ingresar
        }


    }]);