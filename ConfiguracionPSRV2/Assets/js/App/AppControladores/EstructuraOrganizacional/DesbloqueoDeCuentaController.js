accesoUsuarioController.controller("crtlAccesoUsuario", ["$scope", "$timeout", "$window", "administracionServices", "$http",
    function (vm = $scope, $timeout, $window, administracionServices, $http) {
        let respuesta = Administracion["Cuentas"];

        //Variables
        vm.UnidadesAdministrativas = {};

        //Datos iniciales
        //vm.MuestraBoton = false;
        //vm.customSwitch1 = false;
        //vm.customSwitch2 = false;
        //vm.customSwitch3 = false;
        //vm.customSwitch4 = false;
        vm.UnidadesAdministrativas = administracionServices.MetodPOST(respuesta.GetUnidadAdmActiva);

        //customSwitch1.checked = false;
        //document.getElementById("#select1").style.display = "none";
        //document.getElementById("#select2").style.display = "none";
        //document.getElementById("#select3").style.display = "none";
        //document.getElementById("#select4").style.display = "none";    

        //Filtros
        //vm.selectUserID = function (variable) {
        //        vm.customSwitch2 = false;
        //        vm.customSwitch3 = false;
        //        vm.customSwitch4 = false;
        //    if (vm.customSwitch1) {
        //        vm.customSwitch1 = false;
        //        document.getElementById("#select1").style.display = "none";
        //    } else {
        //        vm.customSwitch1 = true;
        //        document.getElementById("#select1").style.display = "block";
        //        document.getElementById("#select2").style.display = "none";
        //        document.getElementById("#select3").style.display = "none";
        //        document.getElementById("#select4").style.display = "none";  
        //    }
        //};
        //vm.selectEmpleado = function () {
        //    vm.customSwitch1 = false;
        //    vm.customSwitch3 = false;
        //    vm.customSwitch4 = false;
        //    if (vm.customSwitch2) {
        //        vm.customSwitch2 = false;
        //        document.getElementById("#select2").style.display = "none";
        //    } else {
        //        vm.customSwitch2 = true;
        //        document.getElementById("#select2").style.display = "block";
        //        document.getElementById("#select1").style.display = "none";
        //        document.getElementById("#select3").style.display = "none";
        //        document.getElementById("#select4").style.display = "none";  
        //    }
        //};
        //vm.selectUnidad = function () {
        //    vm.customSwitch1 = false;
        //    vm.customSwitch2 = false;
        //    vm.customSwitch4 = false;
        //    if (vm.customSwitch3) {
        //        vm.customSwitch3 = false;
        //        document.getElementById("#select3").style.display = "none";
        //        document.getElementById("#select4").style.display = "none";  //
        //    } else {
        //        vm.customSwitch3 = true;
        //        document.getElementById("#select1").style.display = "none";
        //        document.getElementById("#select2").style.display = "none"; 
        //        document.getElementById("#select3").style.display = "block"; 
        //        document.getElementById("#select4").style.display = "block"; //
        //    }
        //};
        //vm.selectAll = function () {
        //    vm.customSwitch1 = false;
        //    vm.customSwitch2 = false;
        //    vm.customSwitch3 = false;
        //    if (vm.customSwitch4) {
        //        vm.customSwitch4 = false;
        //    } else {
        //        vm.customSwitch4 = true;
        //        document.getElementById("#select1").style.display = "none";
        //        document.getElementById("#select2").style.display = "none";
        //        document.getElementById("#select3").style.display = "none";
        //        document.getElementById("#select4").style.display = "none";
        //    }
        //};

        //Buscar usuario por ID
        vm.buscarUserID = function (usuario) {
            if (vm.UserID == undefined || vm.UserID.length != 8) {
                 return Swal.fire({title: "Gobierno Digital", text: "Ingrese un ID valido", icon: "info"});
            }
            vm.UserID = usuario.toUpperCase();
            vm.listaDeUsuariosOriginal = administracionServices.MetodPOST(respuesta.busquedaUserID, vm.UserID);


            vm.listaDeUsuarios = vm.listaDeUsuariosOriginal.filter(function (item, index, array) {
                return array.indexOf(item) === index;
            })
            console.log(vm.listaDeUsuarios);
        };




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
    }
])