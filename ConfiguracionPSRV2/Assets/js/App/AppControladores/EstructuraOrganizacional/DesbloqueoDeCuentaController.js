accesoUsuarioController.controller("crtlAccesoUsuario", ["$scope", "$timeout", "$window", "administracionServices", "$http",
    function (vm = $scope, $timeout, $window, administracionServices, $http) {
        let respuesta = Administracion["Cuentas"];

        //Variables y configuración inicial
        vm.user = {};
        document.getElementById("#datosUsuario").style.display = "none";
        document.getElementById("#inputUserID").disabled = false;
        document.getElementById("#inputUserPW").disabled = false;

        //Buscar usuario por ID
        vm.buscarUser = function () {
            if (vm.user.UserID == undefined || vm.user.UserID.length > 13 || vm.user.UserID.length < 12)
                return Swal.fire({title: "Gobierno Digital", text: "Ingrese un ID válido", icon: "info"});
            if (vm.user.UserPW == undefined || vm.user.UserPW.length != 8) 
                return Swal.fire({ title: "Gobierno Digital", text: "Ingrese un código válido", icon: "info" });
            vm.user.UserID = vm.user.UserID.toUpperCase();
            vm.user.UserPW = vm.user.UserPW.toUpperCase();
            vm.datosUsuarioBloqueado = administracionServices.MetodPOST(respuesta.busquedaUserID, vm.user);
            if (vm.datosUsuarioBloqueado.length>0) {
                document.getElementById("#datosUsuario").style.display = "block";
                document.getElementById("#inputUserID").disabled = true;
                document.getElementById("#inputUserPW").disabled = true;
            } else {
                return Swal.fire({ title: "Gobierno Digital", text: "Usuario no encontrado", icon: "info" });
            }
        };
        vm.desbloquearCuenta = function () {
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Desbloquear cuenta?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(seleccion => {
                    if (seleccion.value) {
                        var result = administracionServices.MetodPOST(respuesta.desbloquearUserID, vm.user);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                }
            );
        };
        vm.cancelarDesbloqueo = function () {
            vm.user = {};
            document.getElementById("#datosUsuario").style.display = "none";
            document.getElementById("#inputUserID").disabled = false;
            document.getElementById("#inputUserPW").disabled = false;
        };   
    }
])