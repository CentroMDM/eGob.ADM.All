menuIzquierda.controller("crtlmenuIzquierda", ["$scope", "$timeout", "administracionServices",
    function (vm = $scope, $timeout, administracionServices) {
        var rutas = Administracion["menuIzquierda"];
        
        this.$onInit = () => {
            //MI ENTIDAD DE USUARIOS
            vm.UsuarioActual = administracionServices.GetConsultaAdministracion(rutas.GetUsuario);
            //Obtener la UA para el usuario que hizo login 
            vm.UnidadAdministrativa = administracionServices.GetConsultaAdministracionConParametro(rutas.GetUACasoConfiguracion, vm.UsuarioActual);
        }



    }])