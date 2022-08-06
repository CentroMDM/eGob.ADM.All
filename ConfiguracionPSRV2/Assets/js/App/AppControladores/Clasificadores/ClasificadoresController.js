clasificadores.controller("crtlClasificadores", ["$scope", "$timeout", "$window", "administracionServices","$http",
    function (vm = $scope, $timeout, $window, administracionServices, $http) {


        var respuesta = Administracion["AgrupadoresClasificadores"]
        vm.catAgrupador = {};
        vm.modeloClasificador = {};

        this.$onInit = () => {
            vm.tablaAgrupadoresClasificadores = administracionServices.GetConsultaAdministracion(respuesta.ConsultarClasificadores);
            vm.tablaAgrupadores = administracionServices.GetConsultaAdministracion(respuesta.ConsultarAgrupadores);
            
            vm.modeloClasificador.RIDClasificador = 0;
            vm.modeloClasificador.ClaveAgrupador = 0;
            vm.modeloClasificador.nombreClasificador = "";
            vm.modeloClasificador.descripcionClasificador = "";
            vm.modeloClasificador.iconoClasificador = "";
            vm.modeloClasificador.colorClasificador = "";
            
        }

        

        vm.agregarAgrupador = () => {
            vm.catAgrupador.RIDAgrupador = 0;
            if (vm.catAgrupador.nombreAgrupador === undefined) {

                Swal.fire({
                    icon: 'error',
                    title: 'Campos obligatorios',
                    text: 'El nombre del agrupador es obligatorio'
                });
                return;
            } else {
                if (vm.catAgrupador.nombreAgrupador.replace("'", "") === "") {
                    Swal.fire({
                        icon: 'error',
                        title: 'Campos obligatorios',
                        text: 'El nombre del agrupador es obligatorio'
                    });
                    return;
                }
            }


            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas guradar el agrupador?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                       
                        var result = administracionServices.IngresarObjetoNegocio(respuesta.IngresarAgrupador, vm.catAgrupador);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.tablaAgrupadores = administracionServices.GetConsultaAdministracion(respuesta.ConsultarAgrupadores);              
                                //vm.ReloadTable();
                                //vm.CleaForm();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };


        

        vm.EliminarObjetoNegocio = () => {
            vm.modeloClasificador.ClaveAgrupador = vm.lstSelectAgrupadores.RIDAgrupador;
            vm.modeloClasificador.nombreClasificador = vm.modelnombreClasificador;
            vm.modeloClasificador.descripcionClasificador = vm.modelDescripcionClasificador;
            vm.modeloClasificador.iconoClasificador = txtIcono.value;
            vm.modeloClasificador.colorClasificador = vm.modelColorClasificador;
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas eliminar el clasificador?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {

                        var result = administracionServices.IngresarObjetoNegocio(respuesta.EliminarClasificador, vm.modeloClasificador);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.tablaAgrupadoresClasificadores = administracionServices.GetConsultaAdministracion(respuesta.ConsultarClasificadores);
                                MostrarFormularios();
                                //vm.ReloadTable();
                                //vm.CleaForm();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        }



        vm.ActualizarClasificador = () => {
            vm.modeloClasificador.ClaveAgrupador = vm.lstSelectAgrupadores.RIDAgrupador;
            vm.modeloClasificador.nombreClasificador = vm.modelnombreClasificador;
            vm.modeloClasificador.descripcionClasificador = vm.modelDescripcionClasificador;
            vm.modeloClasificador.iconoClasificador = txtIcono.value;
            vm.modeloClasificador.colorClasificador = vm.modelColorClasificador;
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas actualizar el clasificador?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {

                        var result = administracionServices.IngresarObjetoNegocio(respuesta.ActuaizarClasificador, vm.modeloClasificador);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.tablaAgrupadoresClasificadores = administracionServices.GetConsultaAdministracion(respuesta.ConsultarClasificadores);
                                MostrarFormularios();
                                //vm.ReloadTable();
                                //vm.CleaForm();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        }



        vm.agregarClasificador = () => {
            vm.modeloClasificador.ClaveAgrupador = vm.lstSelectAgrupadores.RIDAgrupador;
            vm.modeloClasificador.nombreClasificador = vm.modelnombreClasificador;
            vm.modeloClasificador.descripcionClasificador = vm.modelDescripcionClasificador;
            vm.modeloClasificador.iconoClasificador = txtIcono.value;
            vm.modeloClasificador.colorClasificador = vm.modelColorClasificador;
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas guradar el clasificador?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        
                        var result = administracionServices.IngresarObjetoNegocio(respuesta.IngresarClasificador, vm.modeloClasificador);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.tablaAgrupadoresClasificadores = administracionServices.GetConsultaAdministracion(respuesta.ConsultarClasificadores);
                                MostrarFormularios();
                                //vm.ReloadTable();
                                //vm.CleaForm();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };


        vm.NuevoAgrupador = () => {
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = true;
        };

        vm.ValidarTarea = function (objetoNegocio, tarea) {
            if (tarea == 'Eliminar') {
                vm.btnActualizar = false;
                vm.btnEliminar = true;
                vm.btnGuardar = false;

            }
            if (tarea == 'Actualizar') {
                vm.btnActualizar = true;
                vm.btnEliminar = true;
                vm.btnGuardar = false;

                
                vm.modelnombreClasificador = objetoNegocio.nombreClasificador;
                vm.modelDescripcionClasificador = objetoNegocio.descripcionClasificador;
                vm.modelIconoClasificador = objetoNegocio.iconoClasificador;
                vm.modelColorClasificador = objetoNegocio.colorClasificador;

                vm.modeloClasificador.RIDClasificador = objetoNegocio.RIDClasificador;
                vm.modeloClasificador.ClaveAgrupador = objetoNegocio.RIDAgrupador;
                vm.modeloClasificador.nombreClasificador = objetoNegocio.nombreClasificador;
                vm.modeloClasificador.descripcionClasificador = objetoNegocio.descripcionClasificador;
                vm.modeloClasificador.iconoClasificador = objetoNegocio.iconoClasificador;
                vm.modeloClasificador.colorClasificador = objetoNegocio.colorClasificador;
                $("#addIcon").addClass(objetoNegocio.iconoClasificador);
                vm.modelcolorFondo = objetoNegocio.colorClasificador;


                if (objetoNegocio.RIDAgrupador != undefined) {
                  
                    if (objetoNegocio.RIDAgrupador != 0) {
                        vm.lstSelectAgrupadores = vm.tablaAgrupadores.find(function (element) {
                            return (element.RIDAgrupador === objetoNegocio.RIDAgrupador)
                        });
                    }
                }


            }
            //vm.modeloClasificador = objetoNegocio;
            MostrarFormularios();
        };

        vm.cargaImagenRe = function () {
            var imgTem = $("#selectPhotoIcono").get(0);
            var fd = new FormData();
            fd.append("file", imgTem.files[0]);
            $http.post(
               
                respuesta.CargarImagenIcono,
                fd,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                }).then(function Succescallback(response) {
                    vm.modelIconoClasificador = response.data.rutaArchivo;
                }, function errorcallback(response) {
                    console.log(response.data);
                });
        };

        vm.ValidarAccion = function () {
            if (vm.btnGuardar) {
                vm.agregarClasificador();
            } else if (vm.btnActualizar) {
                vm.ActualizarClasificador();
            } else if (vm.btnEliminar) {
                vm.EliminarClasificador();
            }
        }

        vm.MostrarListado = function () {
            location.reload();
        };

        vm.CerrarModal = () => {
            $('#frmAgrupador').modal('hide');
        }

        vm.CerrarIconos = () => {
            $('#frmIcono').modal('hide');
        }

    }])