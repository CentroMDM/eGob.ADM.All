usuarioController.controller("crtlUsuario", ["$scope", "$timeout", "$window","administracionServices", "$http",
    function (vm = $scope, $timeout, $window, administracionServices, $http) {
        let respuesta = Administracion["Usuarios"];

        //Variables
        vm.AplicacionXUnidad = {};
        vm.UnidadesAdministrativas = {};        
        vm.empleadoSeleccionado = {};
        vm.Empleado = {};
        vm.aplicacionesConfiguradas = {};
        vm.RolesDisponibles = [];
        vm.RolesFinales = [];
        vm.relacionEmpleadoRolBuzon = {};
        vm.RespuestasEnDB = [];
        vm.Aplicacion = [];
        vm.BuzonSeleccionado = {};
        vm.EmpleadoUsuario = {};
        vm.Usuario = {};
        vm.Empleados = {};
        vm.Buzones = [];
        vm.EliminaTablaT = {};
        vm.empleadoRoles = {};
        vm.rolusuarioenaplicacionEliminadas = [];
        vm.rolusuarioenaplicacionNuevas = [];
        vm.usuarioBuzonEliminadas = [];
        vm.usuarioBuzonNuevas = [];
        
        //Llama los datos principales
        vm.UnidadesAdministrativas = administracionServices.MetodPOST(respuesta.GetUnidadAdmActiva);
             //Usuarios Activos
        vm.selectActivos = function () {
            for (var i = 0; i < vm.usuariosXUnidad.length; i++) {
                if (vm.usuariosXUnidad[i].ClaveStatus === 92) {
                    vm.usuariosXUnidad[i].Activo = 'Si';
                }
                else {
                    vm.usuariosXUnidad[i].Activo = 'No';
                }
            }
        };

        //Filtros
        vm.SetUnidad = function (Unidad) {
            if (Unidad != undefined) {
                vm.usuariosXUnidad = administracionServices.MetodPOST(respuesta.ObtenerUsuariosXUnidadA, Unidad);
                vm.selectActivos();
                customSwitch3.checked = false;
            }
            else {
                vm.usuariosXUnidad = {};
                customSwitch3.checked = false;
            }

        };
        vm.selectTodos = function () {
            if (customSwitch3.checked) {
                vm.usuariosXUnidad = {};
                vm.usuariosXUnidad = administracionServices.MetodPOST(respuesta.GetUsuarios);
                vm.Unidad = undefined;
                vm.selectActivos();
            }
            else {
                vm.usuariosXUnidad = {};
            }

        };
        //Fin de Filtros

        //Regresa al formulario principal
        vm.MostrarListado = function () {
            vm.EliminaTablaT = administracionServices.MetodPOST(respuesta.EliminaTablaTeporal);
            vm.Unidad = undefined;
            customSwitch3.checked = false;
            vm.usuariosXUnidad = {};
            MostrarFormularios();           
        };
        
        //Muestra Formulario de nuevo usuario - Empleados Disponibles y buzones asignables
        vm.NuevoPuesto = function () {
            InitPw('pass1'); InitPw('pass2'); InitEye('eye1'); InitEye('eye2');
            vm.EliminaTablaT = administracionServices.MetodPOST(respuesta.EliminaTablaTeporal);
            MostrarFormularios();
            document.getElementById("#OpcionUnidad").disabled = false;
            document.getElementById("#OpcionEmpleado").disabled = false;
            document.getElementById("#BtnAsignaRol").style.display = "none";
            document.getElementById("#NombreEmpleado").style.display = "none";
            document.getElementById("#PuestoEmpleado").style.display = "none";
            vm.Unidad = undefined;
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = true;
        };
        vm.SetNewUser = function (Unidad) {
            vm.RolesFinales = [];
            vm.btnCambioPw = false;
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            document.getElementById("txtUsuario").disabled = true;
            document.getElementById("#txtPassword").style.display = "block";
            document.getElementById("#txtPasswordConfirma").style.display = "block";            
            document.getElementById("#txtPassword").required = true;
            document.getElementById("#txtPasswordConfirma").required = true;
            document.getElementById("#condicionContrasena").style.display = "block";
            document.getElementById("#BtnAsignaRol").style.display = "none";
            document.getElementById("#NombreEmpleado").style.display = "none";
            document.getElementById("#PuestoEmpleado").style.display = "none";
            document.getElementById("#Aplicaciones").style.display = "block";
            document.getElementById("#Aplicaciones2").style.display = "none";
            vm.EliminaRoles = true;
            if (Unidad != undefined) {
                vm.empleadoSeleccionado = administracionServices.MetodPOST(respuesta.getNewUsuarios, Unidad.RIDUnidadAdministrativa);
                if (vm.empleadoSeleccionado.length < 1 || vm.empleadoSeleccionado.length == undefined) {
                    Swal.fire(
                        {
                            title: "Gobierno Digital",
                            text: "Esta unidad no cuenta con empleados disponibles",
                            icon: "info"
                        }
                    );
                }
                else {
                    vm.aplicacionesConfiguradas = administracionServices.MetodPOST(respuesta.AplicacionesxUnidad, Unidad.RIDUnidadAdministrativa);
                    document.getElementById("#NombreEmpleado").style.display = "block";
                    document.getElementById("#PuestoEmpleado").style.display = "block";
                }
            }
            else {

                document.getElementById("#NombreEmpleado").style.display = "none";
                document.getElementById("#PuestoEmpleado").style.display = "none";

                Swal.fire(
                    {
                        title: "Gobierno Digital",
                        text: "Esta unidad no cuenta con empleados disponibles",
                        icon: "info"
                    }
                );
                vm.empleadoSeleccionado = {};
            }
        };

        //Muestra todas las partes del formulario de editar
        vm.apareceFormulario = function () {
            InitPw('pass1'); InitPw('pass2'); InitEye('eye1'); InitEye('eye2');
            //Bloquea La edición de nombre del empleado y su unidad
            document.getElementById("#OpcionUnidad").disabled = true;
            document.getElementById("#NombreEmpleado").style.display = "block";
            document.getElementById("#OpcionEmpleado").disabled = true;
            document.getElementById("txtUsuario").disabled = true;
            document.getElementById("#PuestoEmpleado").style.display = "block";
            //Mostramos el cambio de contraseña y decimos que es requerido
            document.getElementById("#BtnAsignaRol").style.display = "block";
            document.getElementById("#txtPassword").style.display = "block";
            document.getElementById("#txtPassword").required = false;
            document.getElementById("#txtPasswordConfirma").required = false;
            document.getElementById("#txtPassword").style.display = "none";
            document.getElementById("#txtPasswordConfirma").style.display = "none";
            document.getElementById("#condicionContrasena").style.display = "none";

            //Traemos las aplicaciones disponibles por usuario
            document.getElementById("#Aplicaciones2").style.display = "block";
            document.getElementById("#Aplicaciones").style.display = "none";
            vm.EliminaRoles = true;                 
        }

        //Muestra formulario para editar un usuario
        vm.ValidarTarea = function (Usuario) {
            MostrarFormularios();
            vm.aplicacionesConfiguradas = {};
            //Activamos las partes necesarias del formulario
            vm.btnGuardar = false;
            vm.btnCambioPw = true;
            vm.btnActualizar = true;
            vm.btnHabilitar = true;
            vm.btnSuspender = false;
            vm.btnEliminar = true;
            //Traemos las aplicaciones disponibles por usuario
            vm.aplicacionesConfiguradas = administracionServices.MetodPOST(respuesta.AplicacionesxUnidad, Usuario.RIDUnidadAdministrativa);
            //llena tabla temporal con lo que ya tiene el usuario
            let accionRolesDisponibles;
            accionRolesDisponibles = administracionServices.MetodPOST(respuesta.DatosUsuariosTablaTemporal, Usuario.RIDUsuario);
            //Traemos los roles asignados por aplicacion
            vm.RolesFinales = administracionServices.MetodPOST(respuesta.BuzonesEmpleado, Usuario.ClaveEmpleado);
            //habilitamos los botones de usuario activo, según su status
            if (Usuario.ClaveStatus == 92) {
                vm.btnHabilitar = false;
                vm.btnSuspender = true;
            }
            //Traemos los datos del usuario seleccionado
            vm.Unidad = vm.UnidadesAdministrativas.find(function (element) {
                return (element.RIDUnidadAdministrativa === Usuario.RIDUnidadAdministrativa)
            });
            vm.EmpleadoUsuario = Usuario;
            if (vm.EmpleadoUsuario.Firmante) {
                document.getElementById("#Firmante").checked = true;
            }
            vm.empleadoSeleccionado = administracionServices.MetodPOST(respuesta.UsuariosExistentes, Usuario.RIDUnidadAdministrativa);
            vm.Empleado = vm.empleadoSeleccionado.find(function (element) {
                return (element.ClaveEmpleado === Usuario.ClaveEmpleado)
            });
            vm.apareceFormulario();
        };

        //validación de cambio de contraseña
        vm.validacionContrasena = function () {            
            if (vm.EmpleadoUsuario.UserPW == null || vm.EmpleadoUsuario.UserPW == undefined) {
                return true;
            }
            else {
                if (vm.EmpleadoUsuario.UserPW != vm.EmpleadoUsuario.confirmUserPW) {
                    return;
                }
                return false;
            }
        }
        
        //Valida las relaciones rusuario_buzon eliminadas y las nuevas
        vm.validaRelacionesUB = function () {
            vm.EmpleadoUsuario.RUBElimindas = administracionServices.MetodPOST(respuesta.relacionesUBEliminadasTablaTemporal, vm.EmpleadoUsuario.RIDUsuario);
            vm.EmpleadoUsuario.RUBNuevas = administracionServices.MetodPOST(respuesta.relacionesUBNuevasTablaTemporal, vm.EmpleadoUsuario.RIDUsuario);
        }

        //Valida las relaciones rolusuarioenaplicacion eliminadas y las nuevas
        vm.validaRelacionesRUA = function () {
            vm.EmpleadoUsuario.RUSElimindas = administracionServices.MetodPOST(respuesta.relacionesEliminadasTablaTemporal, vm.EmpleadoUsuario.RIDUsuario);
            vm.EmpleadoUsuario.RUSNuevas = administracionServices.MetodPOST(respuesta.relacionesNuevasTablaTemporal, vm.EmpleadoUsuario.RIDUsuario);
        }

        //Actualiza a un usuario        
        vm.ActualizaObjetoNegocio = function () {
            vm.validaRelacionesUB();
            vm.validaRelacionesRUA();            
            console.log(vm.EmpleadoUsuario);
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
                        if (vm.validacionContrasena()) {
                            var insertado = administracionServices.MetodPOST(respuesta.UpdateUser, vm.EmpleadoUsuario)
                            if (!insertado.ExisteError) {
                                $timeout(function () {
                                    MensajeRegresoServidor(insertado, "success");
                                    location.reload();
                                });
                                
                            } else {
                                MensajeRegresoServidor(insertado, "error");
                            }
                        }
                        else {
                            var insertado = administracionServices.MetodPOST(respuesta.UpdateUserPW, vm.EmpleadoUsuario)
                            if (!insertado.ExisteError) {
                                $timeout(function () {
                                    MensajeRegresoServidor(insertado, "success");
                                    location.reload();
                                });
                                
                            } else {
                                MensajeRegresoServidor(insertado, "error");
                            }
                        }
                        
                    }
                }
            );
        }

        //Función para mostrar al usuario la contraseña que acaba de escribir
        vm.ShowPw = (i) => { document.getElementById(i).type = document.getElementById(i).type == 'text' ? 'password' : 'text'; if (i == 'pass') toogleIcon('eye'); else if (i == 'pass1') toogleIcon('eye1'); else toogleIcon('eye2'); };
        function toogleIcon(i) { document.getElementById(i).classList[1] == 'fa-eye' ? (document.getElementById(i).classList.remove('fa-eye'), document.getElementById(i).classList.add('fa-eye-slash')) : (document.getElementById(i).classList.remove('fa-eye-slash'), document.getElementById(i).classList.add('fa-eye')); };
        function InitEye(i) { document.getElementById(i).classList[1] == 'fa-eye-slash' ? (document.getElementById(i).classList.remove('fa-eye-slash'), document.getElementById(i).classList.add('fa-eye')) : true; };
        function InitPw(i) { document.getElementById(i).type == 'text' ? document.getElementById(i).type = 'password' : true };

        //Cambiar contraseña
        vm.cambiarContrasena = function () {
            document.getElementById("#txtPassword").style.display = "block";
            document.getElementById("#txtPasswordConfirma").style.display = "block";
            document.getElementById("#condicionContrasena").style.display = "block";

            document.getElementById("#txtPassword").required = true;
            document.getElementById("#txtPasswordConfirma").required = true;
            vm.btnCambioPw = false;
        }

        //Busca los Roles disponibles por usuario
        vm.SetEmpleado = function (Empleado) {
            vm.EmpleadoSinRoles = {};
            vm.EmpleadoUsuario = angular.copy(Empleado);
            vm.EmpleadoUsuario.UserID = Empleado.RFCEmpleado;
            document.getElementById("#MuestraRoles").style.display = "none";
            vm.EmpleadoSinRoles = administracionServices.MetodPOST(respuesta.RolesXNivelPuesto, Empleado.ClaveNivelPuesto);
            if (vm.EmpleadoSinRoles.length == 0) {
                document.getElementById("#BtnAsignaRol").style.display = "none";
                Swal.fire(
                    {
                        title: "Gobierno Digital",
                        text: "El Nivel de Mando asignado a este empleado, no cuenta con ningún rol.",
                        icon: "info"
                    }
                );
            }
            else {
                document.getElementById("#BtnAsignaRol").style.display = "block";
            }
        };

        //Guarda los datos de la aplicación seleccionada en una lista
        vm.SetBuzonConfiguracion = function (Buzon) {            
            if (Buzon != undefined) {
                vm.Aplicacion = Buzon;  //Guarda el buzon en una variable global
                document.getElementById("#MuestraRoles").style.display = "block"; //Muestra los Roles bloqueados hasta despues de escoger el buzón 
                vm.empleadoRoles = {};
                vm.empleadoRoles.RIDNivel = vm.EmpleadoUsuario.ClaveNivelPuesto;
                vm.empleadoRoles.ClaveEmpleado = vm.EmpleadoUsuario.ClaveEmpleado;
                vm.empleadoRoles.ClaveBuzon = Buzon.RIDBuzon;
                vm.RolesDisponibles = administracionServices.MetodPOST(respuesta.GetDatosTablaTemporalERB, vm.empleadoRoles);
                if (vm.RolesDisponibles.length < 1 || vm.RolesDisponibles.length == undefined) {
                    Swal.fire(
                        {
                            title: "Gobierno Digital",
                            text: "No existen roles disponibles",
                            icon: "info"
                        }
                    );
                }
            }
        };

        //Guarda los datos de la aplicacion seleccionada en una lista X usuario
        vm.SetBuzonConfiguracionUser = function (Buzon) {
            if (vm.EmpleadoUsuario.ClaveStatus == 92) {
                console.log(Buzon);
                vm.Roles = {};
                vm.EmpleadoUsuario.ClaveBuzon = Buzon.RIDBuzon;
                vm.EmpleadoUsuario.RIDNivel = vm.EmpleadoUsuario.ClaveNivelPuesto;

                //Muestra los roles diponibles para el usuario 
                vm.RolesDisponibles = [];
                vm.RolesDisponibles = administracionServices.MetodPOST(respuesta.GetDatosTablaTemporalERB, vm.EmpleadoUsuario);
                if (vm.RolesDisponibles.length < 1 || vm.RolesDisponibles.length == undefined) {
                    Swal.fire(
                        {
                            title: "Gobierno Digital",
                            text: "No existen roles disponibles",
                            icon: "info"
                        }
                    );
                }
            }
            else {
                Swal.fire(
                    {
                        title: "Gobierno Digital",
                        text: "Es necesaria la reactivación del usuario",
                        icon: "info"
                    }
                );
            }
        };

        //Asigna Roles al usuario seleccionado        
        vm.SetUsuarioRolesBuzon = function (rol) {//Recibe la aplicacion/buzon configurado en UA
            vm.empleadoRoles.ClaveEmpleado = vm.EmpleadoUsuario.ClaveEmpleado;
            if (vm.Aplicacion.RIDBuzon != undefined) {
                vm.empleadoRoles.ClaveBuzon = vm.Aplicacion.RIDBuzon;
            }
            else {
                vm.empleadoRoles.ClaveBuzon = vm.EmpleadoUsuario.ClaveBuzon;
            }
            vm.empleadoRoles.ClaveRol = rol.RIDRol;
            vm.empleadoRoles.RIDNivel = vm.EmpleadoUsuario.ClaveNivelPuesto;
            vm.RolesDisponibles = administracionServices.MetodPOST(respuesta.insertaRolesEmpleado, vm.empleadoRoles);
            vm.RolesDisponibles = administracionServices.MetodPOST(respuesta.GetDatosTablaTemporalERB, vm.empleadoRoles);
        };
        
        //Botón cerrar
        vm.CerrarBuzon = function () {
            vm.RolesFinales = administracionServices.MetodPOST(respuesta.BuzonesEmpleado, vm.EmpleadoUsuario.ClaveEmpleado);
            vm.Buzon = undefined;
            $('#tabla-buzonesActivos').modal('hide');
            vm.RolesDisponibles = [];
        };

        //Elimina roles asiganados a empleado, no usuario
        vm.eliminarRolesAsignados = function (RolApp) {
            vm.EliminaTablaT = administracionServices.MetodPOST(respuesta.EliminaRolTeporal, RolApp.ClaveBuzon);
            vm.RolesFinales = administracionServices.MetodPOST(respuesta.BuzonesEmpleado, vm.EmpleadoUsuario.ClaveEmpleado);
        };

        //Agregar Usuario
        vm.ValidarAccion = function () {
            console.log(vm.EmpleadoUsuario);
            if (vm.EmpleadoUsuario.FundamentoFirma == "") {
                vm.EmpleadoUsuario.FundamentoFirma = " ";
            }
            if (vm.btnGuardar) {
                vm.GuardarObjetoNegocio();
            } else {
                vm.ActualizarObjetoNegocio();
            }
        };
        vm.GuardarObjetoNegocio = function () {
            //Valida que los campos no estén vacios
            for (const el of document.getElementById('nuevoFormulario').querySelectorAll("[required]")) {
                if (!el.reportValidity()) {
                    Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                }
            }
            if (vm.EmpleadoUsuario.UserPW == '' || vm.EmpleadoUsuario.UserPW == undefined) {
                Swal.fire({ icon: 'info', text: 'La contraseña no cumple las especificaciones' })
                return;
            }
            if (vm.EmpleadoUsuario.UserPW != vm.EmpleadoUsuario.confirmUserPW) {
                return;
            }
            vm.EmpleadoUsuario.Buzones = [];
            vm.EmpleadoUsuario.RolBuzonFinal = 0;
            var idxitem = -1;
            for (var i = 0; i < vm.RolesFinales.length; i++) {
                vm.EmpleadoUsuario.RolBuzonFinal += vm.RolesFinales[i].RolesAsignados;
                vm.EmpleadoUsuario.Buzones.push(vm.RolesFinales[i]);
                idxitem = vm.EmpleadoUsuario.Buzones.indexOf(vm.RolesFinales[i]);
                vm.EmpleadoUsuario.Buzones[idxitem].ClaveRol = administracionServices.MetodPOST(respuesta.RolesXBuzon, vm.RolesFinales[i].ClaveBuzon);
            }
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
                        var insertado = administracionServices.MetodPOST(respuesta.IngresarUsuario, vm.EmpleadoUsuario)
                        if (!insertado.ExisteError) {
                            MensajeRegresoServidor(insertado, "success");
                        } else {
                            MensajeRegresoServidor(insertado, "error");
                        }
                    }
                }
            );
        };
        //Fin Nuevo Usuario

        //Reactiva a un usuario dado de baja        
        vm.ReactivarObjetoNegocio = function () {
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    html: '¿Deseas reactivar al usuario?',
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.MetodPOST(respuesta.ReactivaUsuario, vm.EmpleadoUsuario.RIDUsuario);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(insertado, "success");
                        } else {
                            MensajeRegresoServidor(insertado, "error");
                        }
                        vm.accesosAgregados(lsRoles);
                    }
                }
            );
        };
        //Da de baja un usuario y sus relaciones
        vm.SupenderObjetoNegocio = function () {
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    html: '¿Deseas dar de baja al usuario? </br> <FONT COLOR="DeepSkyBlue"> *Se eliminará toda relación existente en la base de datos </FONT>',
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.MetodPOST(respuesta.DownUsuarioyRelacionesRolBuzon, vm.EmpleadoUsuario.RIDUsuario);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(insertado, "success");
                        } else {
                            MensajeRegresoServidor(insertado, "error");
                        }
                        vm.accesosAgregados(lsRoles);
                    }
                }
            );
        };

        //Eliminar usuario y sus buzones
        vm.EliminarObjetoNegocio = function () {
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    html: '¿Deseas eliminar al usuario? </br> <FONT COLOR="DeepSkyBlue"> *Se eliminará toda relación existente en la base de datos </FONT>',
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.MetodPOST(respuesta.DeleteUsuarioyRelacionesRolBuzon, vm.EmpleadoUsuario.RIDUsuario);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(insertado, "success");
                        } else {
                            MensajeRegresoServidor(insertado, "error");
                        }
                        vm.accesosAgregados(lsRoles);
                    }
                }
            );
        };
    }
])