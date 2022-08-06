cumplimientoSujeto.controller("crtlCumplimientoSujeto", ["$scope", "$timeout", "$window", "administracionServices",
    function (vm = $scope, $timeout, $window, administracionServices) {



        vm.NuevoPuesto = () => {
            MostrarFormularios();
        };

    }])