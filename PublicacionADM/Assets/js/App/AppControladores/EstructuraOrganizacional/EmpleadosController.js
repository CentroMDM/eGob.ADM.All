empleados.controller("crtlEmpleado", ["$scope", "$timeout", "$window", "administracionServices", "$http",
    function (vm = $scope, $timeout, $window, administracionServices, $http) {

        //Variables
        let RUTAS = Administracion["Empleados"];
        vm.EmpleadosAux = {};
        vm.NuevoEmpleado = {};
        vm.filtroPuestos = {};
        vm.btnGuardar = false;
        vm.btnActualizar = false;
        vm.btnEliminar = false;
        vm.seActualiza = false;

        //Llama los datos principales
        vm.IniciarAplicacion = () => {
            vm.UnidadesAdministrativas = administracionServices.MetodPOST(RUTAS.GetUnidadAdmActiva);
        }
        this.$onInit = () => {
            vm.IniciarAplicacion();
        }

        //Filtros
        vm.SetUnidad = function (Unidad) {
            if (Unidad === undefined) {
                vm.EmpleadosAux = {};
            }
            else {
                vm.EmpleadosAux = {};
                vm.filtroPuestos = {};
                vm.EmpleadosAux = administracionServices.MetodPOST(RUTAS.ObtenerEmpleadosXUnidad, Unidad);
                vm.filtroPuestos = administracionServices.MetodPOST(RUTAS.ObtenerPuestosXUnidad, Unidad);
                customSwitch3.checked = false;
            }
        }
        vm.SetPuesto = function (Puesto) {
            if (Puesto != undefined) {
                vm.EmpleadosAux = {};
                vm.EmpleadosAux = administracionServices.MetodPOST(RUTAS.ObtenerEmpleadosXPuesto, Puesto);
                customSwitch3.checked = false;
            }
        }
        vm.selectEmpleados = function () {
            if (customSwitch3.checked) {
                vm.Unidad = undefined;
                vm.filtroPuestos = {};
                vm.EmpleadosAux = {};
                vm.EmpleadosAux = administracionServices.MetodPOST(RUTAS.ObtenerEmpleado);
            }
            else {
                vm.EmpleadosAux = {};
            }
        }

        //Muestra formulario de nuevo empleado
        vm.NuevoPuesto = () => {
            vm.NuevoEmpleado = {};
            vm.EmpleadosAux = {};
            vm.filtroPuestos = {};
            vm.unidadAdministrativa = {};
            customSwitch3.checked = false;
            vm.btnGuardar = true;
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.LogoConfiguracionLogo = null;
            vm.seActualiza = false;
            MostrarFormularios();
        };

        //Regresar al Formulario principal
        vm.MostrarListado = () => {
            vm.EmpleadosAux = {};
            vm.filtroPuestos = {};
            customSwitch3.checked = false;
            vm.Unidad = undefined;
            MostrarFormularios();
        }

        //Muestra formulario para editar Empleado
        vm.EditarEmpleado = (empleado) => {
            vm.btnGuardar = false;
            vm.btnActualizar = true;
            vm.btnEliminar = true;
            vm.seActualiza = false;
            vm.NuevoEmpleado = empleado;
            vm.unidadAdministrativa = vm.UnidadesAdministrativas.find(function (element) {
                return (element.RIDUnidadAdministrativa === empleado.RIDUnidadAdministrativa)
            });
            vm.filtroPuestos = administracionServices.MetodPOST(RUTAS.ConsultaPuesto);
            vm.puestos = vm.filtroPuestos.find(function (element) {
                return (element.RIDPuestos === empleado.ClavePuesto)
            });
            vm.LogoConfiguracionLogo = empleado.DirectorioImagenesVirtual + empleado.DirectorioSecundarioFoto;
            MostrarFormularios();
            $timeout(function () {
                $('.status').select2();
            })
            vm.NuevoEmpleado.confirmemail = vm.NuevoEmpleado.correoEmpleado;
        }

        //Cargar Imagen Empleado ------ cambiar a DLL
        vm.cargaImagenRe = async function () {
            vm.LogoConfiguracionLogo = null;
            vm.NuevoEmpleado.DirectorioSecundarioFoto = null;
            var imgTem = $("#selectPhotoFoto").get(0);
            if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PNG' || imgTem.files[0].name.split('.').pop().toUpperCase() == 'SVG') { 
                var fd = new FormData();
                fd.append("file", imgTem.files[0]);
                $http.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(sessionStorage["ngStorage-GlobalSettings"]).Acceso.Token;
                $http.post(
                    RUTAS.CargarImagenEmpleado,
                    fd, {
                    headers: { "Content-Type": void 0 },
                    transformRequest: angular.identity
                }
                ).then(function Succescallback(response) {
                    console.log(response);
                    var DSecundario = response.data;
                    vm.LogoConfiguracionLogo = response.data;
                    vm.NuevoEmpleado.DirectorioSecundarioFoto = DSecundario.substr(DSecundario.lastIndexOf("/") + 1, 41);
                }, function errorcallback(response) { }
                );
            } else { return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info'); }
        };

        //Validaciones Nuevo Empleado
        vm.setUnidadAdministrativa = (unidad) => {
            vm.NuevoEmpleado.NombreNivel = "";
            vm.unidad = unidad;
            vm.filtroPuestos = {};
            vm.filtroPuestos = administracionServices.MetodPOST(RUTAS.ObtenerPuestosXUnidad, unidad.RIDUnidadAdministrativa);
            vm.NuevoEmpleado.unidad = unidad.RIDUnidadAdministrativa;
        }
        vm.selectNivelMando = (Puesto) => {
            vm.nivelXPuesto = administracionServices.MetodPOST(RUTAS.ObtenerNivelXPuesto, Puesto.RIDPuestos);
            vm.Nivel = vm.nivelXPuesto[0];
            vm.NuevoEmpleado.ClavePuesto = Puesto.RIDPuestos;
            vm.NuevoEmpleado.Nivel = vm.Nivel.RIDNivel
            vm.NuevoEmpleado.NombreNivel = vm.Nivel.Nombre;

        }
        vm.ValidarAccion = () => {
            if (vm.btnGuardar) {
                //Convertimos el RFC a Mayúsculas
                vm.NuevoEmpleado.RFCEmpleado = vm.NuevoEmpleado.RFCEmpleado.toUpperCase();
                //Valida que el RFC cumpla con las caracteristicas de un RFC
                if (vm.NuevoEmpleado.RFCEmpleado.length > 13 || vm.NuevoEmpleado.RFCEmpleado.length < 12) {
                    Swal.fire(
                        {
                            title: "Gobierno Digital",
                            text: "Ingrese un RFC valido",
                            icon: "info"
                        }
                    );
                }
                else {
                    //Valida que el RFC de empleado no haya sido registrado con anterioridad
                    vm.RFCE = administracionServices.MetodPOST(RUTAS.RFCDisponibleEmpleadoNew, vm.NuevoEmpleado.RFCEmpleado);
                    if (vm.RFCE === "1") {
                        Swal.fire(
                            {
                                title: "Gobierno Digital",
                                text: "Este RFC ya está en uso",
                                icon: "info"
                            }
                        );
                    }
                    else {
                        //valida que el número de empleado no este en uso por otro usuario
                        vm.ClaveAuxEmpleado = administracionServices.MetodPOST(RUTAS.ObtenerClaveEmpleadoNew, vm.NuevoEmpleado.NumeroEmpleado);
                        if (vm.ClaveAuxEmpleado === "1") {
                            Swal.fire(
                                {
                                    title: "Gobierno Digital",
                                    text: "El número de empleado ya esta registrado",
                                    icon: "info"
                                }
                            );
                        }
                        else {
                            //Valida correo electronico
                            if (vm.NuevoEmpleado.correoEmpleado != vm.NuevoEmpleado.confirmemail || vm.NuevoEmpleado.correoEmpleado == undefined || vm.NuevoEmpleado.confirmemail == undefined) {
                                Swal.fire(
                                    {
                                        title: "Gobierno Digital",
                                        text: "El email ingresado no cumple con las especificaciones, favor de verificar.",
                                        icon: "info"
                                    }
                                );
                            } else {
                                if (vm.NuevoEmpleado.DirectorioSecundarioFoto == undefined) {
                                    return MensajeGeneral("Todos los campos son obligatorios", 'info');
                                } else {
                                    //Valida el formato de archivo
                                    var extensionesValidas = ["png", "svg", "PNG", "SVG"];
                                    if (extensionesValidas.find(element => element == vm.NuevoEmpleado.DirectorioSecundarioFoto.slice(((vm.NuevoEmpleado.DirectorioSecundarioFoto.lastIndexOf(".") - 1) + 2))) == undefined) {
                                        return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
                                    }
                                    else {
                                        vm.AgregarEmpleado();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else {
                //Convertimos el RFC a Mayúsculas
                vm.NuevoEmpleado.RFCEmpleado = vm.NuevoEmpleado.RFCEmpleado.toUpperCase();
                //Valida que el RFC cumpla con las caracteristicas de un RFC
                if (vm.NuevoEmpleado.RFCEmpleado.length > 13 || vm.NuevoEmpleado.RFCEmpleado.length < 12) {
                    Swal.fire(
                        {
                            title: "Gobierno Digital",
                            text: "Ingrese un RFC valido",
                            icon: "info"
                        }
                    );
                }
                else {
                    //Valida que el RFC de empleado no haya sido registrado con anterioridad
                    vm.RFCE = administracionServices.MetodPOST(RUTAS.RFCDisponibleEmpleado, vm.NuevoEmpleado);
                    if (vm.RFCE === "1") {
                        Swal.fire(
                            {
                                title: "Gobierno Digital",
                                text: "Este RFC ya está en uso",
                                icon: "info"
                            }
                        );
                    }
                    else {
                        //valida que el número de empleado no este en uso por otro usuario
                        vm.ClaveAuxEmpleado = administracionServices.MetodPOST(RUTAS.ObtenerClaveEmpleado, vm.NuevoEmpleado);
                        if (vm.ClaveAuxEmpleado === "1") {
                            Swal.fire(
                                {
                                    title: "Gobierno Digital",
                                    text: "El número de empleado ya esta registrado",
                                    icon: "info"
                                }
                            );
                        }
                        else {
                            //confirma correo electronico
                            if (vm.NuevoEmpleado.correoEmpleado != vm.NuevoEmpleado.confirmemail || vm.NuevoEmpleado.correoEmpleado == undefined || vm.NuevoEmpleado.confirmemail == undefined) {
                                Swal.fire(
                                    {
                                        title: "Gobierno Digital",
                                        text: "El email ingresado ha cambiado, favor de confirmar.",
                                        icon: "info"
                                    }
                                );
                            } else {
                                if (vm.NuevoEmpleado.DirectorioSecundarioFoto == undefined) {
                                    return MensajeGeneral("Todos los campos son obligatorios", 'info');
                                } else {
                                    //Confirma formato de imagen
                                    var extensionesValidas = ["png", "svg", "PNG", "SVG"];
                                    if (extensionesValidas.find(element => element == vm.NuevoEmpleado.DirectorioSecundarioFoto.slice(((vm.NuevoEmpleado.DirectorioSecundarioFoto.lastIndexOf(".") - 1) + 2))) == undefined) {
                                        return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
                                    }
                                    else {
                                        vm.ActualizarEmpleado();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        vm.validarEmail = () => {
            if ((vm.NuevoEmpleado.correoEmpleado != undefined || vm.NuevoEmpleado.correoEmpleado == undefined) && vm.NuevoEmpleado.hasOwnProperty('RIDEmpleado')) {
                vm.NuevoEmpleado.confirmemail = undefined;
                vm.seActualiza = true;
            }
        }

        //Guarda nuevo empleado
        vm.AgregarEmpleado = () => {
            for (const el of document.querySelector('#formEmpleado').querySelectorAll('[required]')) {
                if (!el.reportValidity()) {
                    return Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                }
                else {
                    Swal.fire(
                        {
                            title: "Gobierno Digital",
                            text: "¿Deseas actualizar los cambios?",
                            icon: "question",
                            showCancelButton: true,
                            cancelButtonText: 'No',
                            confirmButtonText: "Si"
                        }).then(seleccion => {
                            if (seleccion.value) {
                                var result = administracionServices.MetodPOST(RUTAS.IngresarEmpleado, vm.NuevoEmpleado);
                                if (!result.ExisteError) {
                                    vm.NuevoEmpleado = {};
                                    MensajeRegresoServidor(result, "success");
                                } else {
                                    MensajeRegresoServidor(result, "error");
                                }
                            }
                        }
                    );
                }
            }
        }

        //Editar y Guardar Empleado
        vm.ActualizarEmpleado = () => {
            for (const el of document.getElementById('formEmpleado').querySelectorAll("[required]")) {
                if (!el.reportValidity()) {
                    Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                }
                else {
                    //Convertimos el RFC a Mayúsculas
                    vm.NuevoEmpleado.RFCEmpleado = vm.NuevoEmpleado.RFCEmpleado.toUpperCase();
                    //Valida que el RFC cumpla con las caracteristicas de un RFC
                    if (vm.NuevoEmpleado.RFCEmpleado.length > 13 || vm.NuevoEmpleado.RFCEmpleado.length < 12) {
                        Swal.fire(
                            {
                                title: "Gobierno Digital",
                                text: "Ingrese un RFC valido",
                                icon: "info"
                            }
                        );
                    }
                    else {
                        var extensionesValidas = ["png", "svg", "PNG", "SVG"];
                        if (extensionesValidas.find(element => element == vm.NuevoEmpleado.DirectorioSecundarioFoto.slice(((vm.NuevoEmpleado.DirectorioSecundarioFoto.lastIndexOf(".") - 1) + 2))) == undefined) {
                            return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
                        }
                        else {
                            Swal.fire(
                                {
                                    title: "Gobierno Digital",
                                    text: "¿Deseas actualizar los cambios?",
                                    icon: "question",
                                    showCancelButton: true,
                                    cancelButtonText: 'No',
                                    confirmButtonText: "Si"
                                }).then(seleccion => {
                                    if (seleccion.value) {
                                        var result = administracionServices.MetodPOST(RUTAS.ActualizarEmpleado, vm.NuevoEmpleado);
                                        if (!result.ExisteError) {
                                            MensajeRegresoServidor(result, "success");
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
        }

        //Elimina Empleado
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
                        var result = administracionServices.MetodPOST(RUTAS.EliminarEmpleado, vm.NuevoEmpleado);
                        if (!result.ExisteError) {
                            location.reload();
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };
    }
]);