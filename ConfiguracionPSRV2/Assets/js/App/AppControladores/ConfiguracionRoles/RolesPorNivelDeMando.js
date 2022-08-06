RolesPorNivelDeMando.controller("RolesPorNivelDeMando", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        var rutas = Administracion["ConfiguracionRoles"];

        //Variables
        vm.RolesXNivel = {};
        vm.NivelPuesto = {};
        vm.rolesDeNivel = {};
        vm.RolesAsignables = {};
        vm.detalleDelRol = {};
        vm.nivelYRol = {};

        //Datos Principales
        vm.RolesXNivel = administracionServices.GetConsultaAdministracion(rutas.GetRolesXNivel);
        vm.NivelPuesto = administracionServices.GetConsultaAdministracion(rutas.ObtenerNivelMando);
        document.getElementById("#tbRolesAgregados2").style.display = "none";
        document.getElementById("#tbRolesAgregados1").style.display = "none";
        document.getElementById("#ocultaTabla").style.display = "none";

        //Muestra Formulario de nueva relación Nivel-Rol
        vm.NuevoPuesto = function () {
            vm.Nivel = [];
            document.getElementById("#NivelPuesto").disabled = false;
            document.getElementById("#tbRolesAgregados2").style.display = "none";
            document.getElementById("#tbRolesAgregados1").style.display = "none";
            document.getElementById("#ocultaTabla").style.display = "none";
            MostrarFormularios();
        };

        //Regresa al formulario principal
        vm.MostrarListado = function () {
            MostrarFormularios();
        };

        //Muestra Roles asignados al nivel de puesto y trae los roles diponibles
        vm.setNivelPuesto = function (RIDNivel) {
            vm.nivelYRol.RIDNivel = RIDNivel;
            vm.rolesDeNivel = administracionServices.GetConsultaAdministracionConParametro(rutas.RolesDeNivel, RIDNivel);
            vm.RolesAsignables = administracionServices.GetConsultaAdministracionConParametro(rutas.rolesAsignables, RIDNivel);
            if (vm.rolesDeNivel.length == 0) {
                vm.objetoAux = { nombreRol: "No existen roles asignados", descripcionRol: "" };
                document.getElementById("#tbRolesAgregados1").style.display = "none";
                document.getElementById("#tbRolesAgregados2").style.display = "block";
                vm.rolesDeNivel.push(vm.objetoAux);
            }
            else {
                document.getElementById("#tbRolesAgregados2").style.display = "none";
                document.getElementById("#tbRolesAgregados1").style.display = "block";
            }
        }

        //Muestra los detalles del rol seleccionado en ese momento
        vm.detallesDeRol = function (RIDRol) {
            if (RIDRol == undefined) {
                document.getElementById("#ocultaTabla").style.display = "none";
            }
            else {
                vm.detalleDelRol = administracionServices.GetConsultaAdministracionConParametro(rutas.DetalleDeLosRoles, RIDRol);
                document.getElementById("#ocultaTabla").style.display = "block";
                if (vm.detalleDelRol.length == 0) {
                    vm.objetoAux = { NombreModulo: "No existen modulos asignados a este rol", NombreCaracteristicas: "", NombreAccion: "" };
                    vm.detalleDelRol.push(vm.objetoAux);
                }
            }
        }

        //Inicia Asignación de roles
        vm.AgregarRol = function (RIDRol) {
            if (RIDRol == undefined) {
                Swal.fire({
                    icon: 'info',
                    text: 'Debe seleccionar un rol antes'
                })
            }
            else {
                vm.nivelYRol.RIDRol = RIDRol;
                //vm.SetNivelROl
                Swal.fire(
                    {
                        title: "Gobierno Digital",
                        text: "¿Deseas asociar el rol a este nivel?",
                        icon: "question",
                        showCancelButton: true,
                        cancelButtonText: 'No',
                        confirmButtonText: "Si"
                    }).then(function (seleccion) {
                        if (seleccion.value) {
                            var result = administracionServices.GetConsultaAdministracionConParametro(rutas.setNivelRol, vm.nivelYRol);
                            if (!result.ExisteError) {
                                $timeout(() => {
                                    //MensajeRegresoServidor(result, "success");
                                    Swal.fire('', 'El rol se agregó correctamente', 'success'); 
                                    //vm.rolesDeNivel = administracionServices.GetConsultaAdministracionConParametro(rutas.RolesDeNivel, vm.nivelYRol.RIDNivel);
                                    vm.setNivelPuesto(vm.nivelYRol.RIDNivel);
                                    //location.reload();
                                    /*return;*/
                                });
                            } else {
                                /*MensajeRegresoServidor(result, "error");*/
                                Swal.fire('', 'No se ha podido asociar el rol', 'error'); return;

                            }
                        }
                    }
                );
            }
        }

        //elimina un rol asignado
        vm.actualizarRelacionNivelRol = function (RIDRol) {
            document.getElementById("#ocultaTabla").style.display = "none";
            vm.nivelYRol.RIDRol = RIDRol;
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas eliminar el rol de este nivel?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.GetConsultaAdministracionConParametro(rutas.eliminaRolAsignado, vm.nivelYRol);
                        if (!result.ExisteError) {
                            $timeout(() => {
                                //MensajeRegresoServidor(result, "success");
                                Swal.fire('', 'El rol se eliminó correctamente', 'success');
                                //vm.rolesDeNivel = administracionServices.GetConsultaAdministracionConParametro(rutas.RolesDeNivel, vm.nivelYRol.RIDNivel);
                                vm.setNivelPuesto(vm.nivelYRol.RIDNivel);
                                //location.reload();
                                /*return;*/
                            });
                        } else {
                            /*MensajeRegresoServidor(result, "error");*/
                            Swal.fire('', 'No se ha podido eliminar el rol', 'error'); return;

                        }
                    }
                }
            );
        }

        //Edita una relación rol Nivel
        vm.ValidarTarea = function (RIDNivel) {
            vm.NuevoPuesto();
            document.getElementById("#NivelPuesto").disabled = true;
            vm.Nivel = vm.NivelPuesto.find(element => element.RIDNivel == RIDNivel);
            console.log(vm.Nivel);
            vm.setNivelPuesto(RIDNivel);
        }
    }
]);