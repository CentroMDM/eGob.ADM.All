variablesConfiguracion.controller("crtlVariables", ["$scope", "administracionServices",
    function (vm = $scope, administracionServices) {

        vm.EsPatron = true;
        vm.EsMinMax = true;
        vm.listaCampos = [];
        vm.EsLista = true;

        vm.TipoValor = function (valor) {
            vm.EsMinMax = (valor == 1 || valor == 2) ? false : true;
            vm.EsPatron = (valor == 1) ? false : true;
            vm.EsLista = (valor == 4) ? false : true;
        }

        vm.agregarCampo = function (valor) {
            var agregarValor = true;
            for (var i = 0; i < vm.listaCampos.length; i++) {
                if (valor == vm.listaCampos[i]) {
                    agregarValor = false;
                }
            }
            agregarValor ? (
                vm.listaCampos.push(valor)
            ) :
                (
                    MensajeGeneral("El valor ya se encuentra registrado", "info")
                );

            vm.variable.datoLista = "";
            MensajeEventoElemento("Objeto agregado correctamente!",1);
        }

        vm.EliminarOpcion = function (campo) {
            var index = 0;
            for (var i = 0; i < vm.listaCampos.length; i++) {
                if (vm.listaCampos[i] === campo) {
                    index = i;
                    break
                }
            }
            vm.listaCampos.splice(index, 1);
            MensajeEventoElemento("Objeto eliminado correctamente!",2);
        }

        vm.NuevoPuesto = function () {
            MostrarFormularios();
            vm.btnActualizar = false;
            vm.btnEliminar = false;
            vm.btnGuardar = true;
        };
    }])