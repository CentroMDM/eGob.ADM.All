ClasificacionSujetos.controller("crtlClasificacionSujetos", ["$scope", "$timeout", "$window", "administracionServices", "$http",
    function (vm = $scope, $timeout, $window, administracionServices, $http) {


        var respuesta = Administracion["ClasificacionSujetos"];
        var ConsultaAgrupadores = Administracion["AgrupadoresClasificadores"];
        vm.catTipoSujetoObjeto = {};
        vm.catAgrupadores = {};
        vm.entClasificacion = {};
        vm.modeloClasificador = {};
        vm.filtroClasificadores = {};

        vm.TablaClasificadores = [];
        
      

        this.$onInit = () => {
            vm.cargaManual = false;
            vm.cargaMasiva = false;
            vm.TablaAgrupadores = administracionServices.GetConsultaAdministracion(ConsultaAgrupadores.ConsultarAgrupadores);
            vm.TablaSujetosObjetos = administracionServices.GetConsultaAdministracion(respuesta.ConsultarTipoSujetosObjetos);

            if (localStorage.getItem("AgrupadoresSeleccionados") != 'undefined')
            vm.TablaAgrupadoresSeleccionados = JSON.parse(localStorage.getItem("AgrupadoresSeleccionados"));
            if (localStorage.getItem("ClasificadoresSeleccionados") != 'undefined')
            vm.TablaClasificadoresSeleccionados = JSON.parse(localStorage.getItem("ClasificadoresSeleccionados"));

            if (vm.TablaAgrupadoresSeleccionados.length>0) {
                for (let a = 0; a < vm.TablaAgrupadoresSeleccionados.length; a++) {
                    //$("#lstAgrupadorFiltro").val(vm.TablaAgrupadoresSeleccionados[a].RIDAgrupador);
                    document.getElementById("lstAgrupadorFiltro").value = vm.TablaAgrupadoresSeleccionados[a].RIDAgrupador;
                    //vm.lstSeleccionAgrupadorFiltro = vm.TablaAgrupadores.find(function (element) {
                    //    return (element.RIDAgrupador === vm.TablaAgrupadoresSeleccionados[a].RIDAgrupador)
                    //});
                }
            }

            if (vm.TablaClasificadoresSeleccionados != null) {
                lstSeleccionClasificadorFiltro = vm.TablaClasificadoresSeleccionados;
            }

            vm.tablaClasificacionObjetos = administracionServices.GetConsultaAdministracionConParametro(respuesta.ConsultarObjetosClasificados, JSON.parse(localStorage.getItem("ClasificadoresSeleccionados")));

            
        }

        vm.asignaAgrupador = (itemAgrupador) => {
            vm.catAgrupadores = itemAgrupador;
            if (itemAgrupador.RIDAgrupador > 0)
                vm.TablaClasificadores= administracionServices.GetConsultaAdministracionConParametro(respuesta.ConsultarClasificadoresClasificacion, vm.catAgrupadores);
                vm.modelcolorFondo = "#ffffff";



            }

        vm.asignaAgrupadorFiltro = (itemAgrupador) => {
            localStorage.setItem("AgrupadoresSeleccionados", JSON.stringify(itemAgrupador));
                vm.TablaClasificadoresFiltro = administracionServices.GetConsultaAdministracionConParametro(respuesta.ConsultarClasificadoresClasificacionMultipleSeleccion, itemAgrupador);
                vm.modelcolorFondo = "#ffffff";
            }

            vm.consultaObjetosClasificados = (itemClasificador) => {

                localStorage.setItem("ClasificadoresSeleccionados", JSON.stringify(itemClasificador));
                //vm.tablaClasificacionObjetos = administracionServices.GetConsultaAdministracionConParametro(respuesta.ConsultarObjetosClasificados, itemClasificador);
                vm.modelcolorFondo = "#ffffff";
            }



        vm.asignarClasificador = (itemClasificador) => {
            vm.modeloClasificador = itemClasificador;
            $("#addIconMan").removeClass();
            $("#addIconMan").addClass(itemClasificador.iconoClasificador);

            $("#addIconMas").removeClass();
            $("#addIconMas").addClass(itemClasificador.iconoClasificador);

            vm.modelcolorFondo = itemClasificador.colorClasificador;
            }


            vm.asignarMetodoClasificador = (itmeMetodoClasificador) => {
                vm.cargaManual = false;
                vm.cargaMasiva = false;
                vm.btnGuardar = false;
                if (itmeMetodoClasificador === '1') {
                    vm.cargaManual = true;
                    vm.cargaMasiva = false;
                    vm.btnGuardar = true;
                } else if (itmeMetodoClasificador === '2') {
                    vm.cargaManual = false;
                    vm.cargaMasiva = true;
                    vm.btnGuardar = false;
                }
            }


        vm.agregarTipoSujetoObjeto = (nombreItem) => {
            vm.catTipoSujetoObjeto.RIDItemCatalogo = 0;
          

            if (nombreItem === undefined) {

                Swal.fire({
                    icon: 'error',
                    title: 'Campos obligatorios',
                    text: 'El campo tipo es obligatorio'
                });
                return;
            } 
        
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas guradar el tipo de sujeto y objeto?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {

                        var result = administracionServices.IngresarObjetoNegocio(respuesta.IngresarTipoSujetosObjetos, vm.catTipoSujetoObjeto);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                vm.TablaSujetosObjetos = administracionServices.GetConsultaAdministracion(respuesta.ConsultarTipoSujetosObjetos);
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        }




        vm.EliminarObjetoNegocio = () => {
            vm.modeloClasificador.ClaveAgrupador = vm.lstSelectAgrupadores.RIDAgrupador;
            vm.modeloClasificador.nombreClasificador = vm.modelnombreClasificador;
            vm.modeloClasificador.descripcionClasificador = vm.modelDescripcionClasificador;
            vm.modeloClasificador.iconoClasificador = txtIcono.value;
            vm.modeloClasificador.colorClasificador = vm.modelColorClasificador;
            Swal.fire(
                {
                    title: "PSR-Configuración",
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
                    title: "PSR-Configuración",
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
                })
        }



        vm.agregarClasificador = () => {

            vm.entClasificacion.ClaveSujetoObjeto = vm.lstSelectSujetosObjetos.RIDItemCatalogo;
            vm.entClasificacion.ClaveClasificador = vm.lstSeleccionClasificador.RIDClasificador;
            vm.entClasificacion.ClaveObjeto = vm.modeloClaveSujetoObjeto;

            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas guradar el clasificador?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {

                        var result = administracionServices.IngresarObjetoNegocio(respuesta.IngresarClasificacion, vm.entClasificacion);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success")
                            $timeout(function () {

                                vm.NuevoAgrupador();
                               
                                //vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error")
                        }
                    }
                })
        }


        vm.NuevoAgrupador = () => {
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = false;
        }

        vm.ValidarTipoSujetoObjeto = function (catTipoSujetoObjeto, tarea) {
            if (tarea == 'Eliminar') {
               

            }
            if (tarea == 'Actualizar') {

            }
            MostrarFormularios();
        }

        vm.ValidarTarea = function (objetoNegocio, tarea) {


            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas eliminar la clasificación del objeto?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {

                        var result = administracionServices.IngresarObjetoNegocio(respuesta.EliminaClasificacion, objetoNegocio);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                            $timeout(function () {
                                //vm.tablaClasificacionObjetos = administracionServices.GetConsultaAdministracion(respuesta.ConsultarObjetosClasificados); 
                                MostrarListado();
                                //MostrarFormularios();
                                //vm.ReloadTable();
                                //vm.CleaForm();
                                vm.mdmForm.$setPristine();
                            })
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                })
        }

        vm.cargaArchivoTXT = function (catTipoSujetoObjeto, lstSeleccionClasificador) {
            var imgTem = $("#ArchivoInsumo").get(0);
           
            var fd = new FormData();
            fd.append("file", imgTem.files[0]);
            fd.append("ClaveSubjetoObjeto", catTipoSujetoObjeto.RIDItemCatalogo);
            fd.append("ClaveClasificacion", lstSeleccionClasificador.RIDClasificador);
            $http.post(
                respuesta.cargaArchivoTXT,
                fd,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                }).then(function Succescallback(response) {
                    console.log(response.data);
                    
                   
                }, function errorcallback(response) {
                    console.log(response.data);
                })
        }



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
                })
        }

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
        }

        vm.CerrarModal = () => {
            $('#frmTipoSujetoObjeto').modal('hide');
        }

        vm.CerrarIconos = () => {
            $('#frmIcono').modal('hide');
        }

    }])