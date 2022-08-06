
var AppAdministracion = angular.module("AppAdministracion", [
    "implementacion",
    "nivelMandoController",
    "unidadAdministrativaController",
    "puestoController",
    "usuarioController",
    "accesoUsuarioController",
    "buzonController",
    "buzonfiscal",
    "grupoAtencionController",
    "variablesConfiguracion",
    "wfDefinicion",
    "wfProceso",
    "wfEtapas",
    "configuracionTipoDocumentos",
    "configuracionTipoServicio",
    "diasInhabiles",
    "casoConfiguracion",
    "formatosSecciones",
    "empleados",
    "impuestos",
    "cumplimientoSujeto",
    "accionesCumplimiento",
    "clasificadores",
    "administracionServices",
    "ClasificacionSujetos",
    "HomeController",
    /*"InicioCtrl",*/
    "RolesPorNivelDeMando",
    "ModulosYCaracteristicas",
    "GDPlatform.Constants",
    "GDPlatform.Services",
    "AdministracionController",
    "PistasDeAuditoria"
]);


var implementacion = angular.module("implementacion", []);

var nivelMandoController = angular.module("nivelMandoController", []);



var administracionServices = angular.module("administracionServices", []);
var unidadAdministrativaController = angular.module("unidadAdministrativaController", []);
var puestoController = angular.module("puestoController", []);
var usuarioController = angular.module("usuarioController", []);
var accesoUsuarioController = angular.module("accesoUsuarioController", []);
var buzonController = angular.module("buzonController", []);
var buzonfiscal = angular.module("buzonfiscal", []);
var grupoAtencionController = angular.module("grupoAtencionController", []);
var variablesConfiguracion = angular.module("variablesConfiguracion", []);
var wfDefinicion = angular.module("wfDefinicion", []);
var wfProceso = angular.module("wfProceso", []);
var wfEtapas = angular.module("wfEtapas", []);
var configuracionTipoDocumentos = angular.module("configuracionTipoDocumentos", []);
var configuracionTipoServicio = angular.module("configuracionTipoServicio", []);
var diasInhabiles = angular.module("diasInhabiles", []);
var casoConfiguracion = angular.module("casoConfiguracion", []);
var formatosSecciones = angular.module("formatosSecciones", []);
var empleados = angular.module("empleados", []);
var impuestos = angular.module("impuestos", []);
var cumplimientoSujeto = angular.module("cumplimientoSujeto", []);
var accionesCumplimiento = angular.module("accionesCumplimiento", []);
var clasificadores = angular.module("clasificadores", []);
var ClasificacionSujetos = angular.module("ClasificacionSujetos", []);
var HomeController = angular.module("HomeController", []);
/*var InicioCtrl = angular.module("InicioCtrl", []);*/
var RolesPorNivelDeMando = angular.module("RolesPorNivelDeMando", []);
var ModulosYCaracteristicas = angular.module("ModulosYCaracteristicas", []);
var AdministracionController = angular.module("AdministracionController", []);
var PistasDeAuditoria = angular.module("PistasDeAuditoria", []);



var compareTo = function () {
    return {
        require: "ngModel",
        scope: {
            otherModelValue: "=compareTo"
        },
        link: function (scope, element, attributes, ngModel) {

            ngModel.$validators.compareTo = function (modelValue) {
                return modelValue == scope.otherModelValue;
            };

            scope.$watch("otherModelValue", function () {
                ngModel.$validate();
            });
        }
    };
};

AppAdministracion.directive("compareTo", compareTo);
AppAdministracion.directive('date', function (dateFilter) {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {

            var dateFormat = attrs['date'] || 'yyyy-MM-dd';

            ctrl.$formatters.unshift(function (modelValue) {
                return dateFilter(modelValue, dateFormat);
            });
        }
    };
})

AppAdministracion.directive('parseInt', [function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, elem, attrs, controller) {
            controller.$formatters.push(function (modelValue) {
                console.log('model', modelValue, typeof modelValue);
                return '' + modelValue;
            });

            controller.$parsers.push(function (viewValue) {
                console.log('view', viewValue, typeof viewValue);
                return parseInt(viewValue, 10);
            });
        }
    }
}])


AppAdministracion.directive('capitalize', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, modelCtrl) {
            var capitalize = function (inputValue) {
                if (inputValue == undefined) inputValue = '';
                var capitalized = inputValue.toUpperCase();
                if (capitalized !== inputValue) {
                    // see where the cursor is before the update so that we can set it back
                    var selection = element[0].selectionStart;
                    modelCtrl.$setViewValue(capitalized);
                    modelCtrl.$render();
                    // set back the cursor after rendering
                    element[0].selectionStart = selection;
                    element[0].selectionEnd = selection;
                }
                return capitalized;
            }
            modelCtrl.$parsers.push(capitalize);
            capitalize(scope[attrs.ngModel]); // capitalize initial value
        }
    };
})


AppAdministracion.directive('onlyLettersInput', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                var transformedInput = text.replace(/[^a-zA-Z\s]/g, '');
                //console.log(transformedInput);
                if (transformedInput !== text) {
                    ngModelCtrl.$setViewValue(transformedInput);
                    ngModelCtrl.$render();
                }
                return transformedInput;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});