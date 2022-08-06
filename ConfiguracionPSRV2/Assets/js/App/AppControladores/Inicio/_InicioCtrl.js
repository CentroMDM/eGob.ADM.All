InicioCtrl.controller("InicioCtrl", ["$scope", "$timeout", "administracionServices", "$http", "$sessionStorage",
    function ($scope, $timeout, administracionServices, $http, $sessionStorage) {
        var vm = this;
        vm.initController = function () {
            setTimeout(function () { $(".preloader").fadeOut("slow"); }, 50);
        }
    }]
)