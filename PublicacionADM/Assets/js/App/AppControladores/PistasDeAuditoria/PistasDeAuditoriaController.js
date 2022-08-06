PistasDeAuditoria.controller("crtlAuditoria", ["$scope", "$timeout", "$window", "administracionServices", "$http",
    function (vm = $scope, $timeout, $window, administracionServices, $http) {

        //Variables
        let RUTAS = Administracion["Auditoria"];
        vm.AplicacionesPSR = [];
        vm.ListUsuarios = [];

        //Aplicaciones Disponibles
        vm.AplicacionesPSR = administracionServices.GetConsultaAdministracion(RUTAS.GetaplicacionesPSR);

        //
        //vm.SetUsers = function (Aplicacion) { //
        //    if (Unidad === undefined) {
        //        vm.EmpleadosAux = {};
        //    }
        //    else {
        //        vm.EmpleadosAux = {};
        //        vm.filtroPuestos = {};
        //        vm.EmpleadosAux = administracionServices.GetConsultaAdministracionConParametro(RUTAS.ObtenerEmpleadosXUnidad, Unidad);
        //        vm.filtroPuestos = administracionServices.GetConsultaAdministracionConParametro(RUTAS.ObtenerPuestosXUnidad, Unidad);
        //        //vm.ReshapeTable('dt-resumen');
        //        customSwitch3.checked = false;
        //    }
        //}

        //vm.ListUsuarios = administracionServices.GetConsultaAdministracionConParametro(RUTAS.GetUsuariosXUnidad, vm.Applicacion.RIDAplicacion);
    }
]);