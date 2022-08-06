buzonfiscal.controller("crtlBuzonFiscal", ["$scope", "$timeout", "administracionServices","$http",
    function (vm = $scope, $timeout, administracionServices, $http) {
        
        

        $(document).ready(function () {
            $('#summernote').summernote({
                height: 300,
                minHeight: null,
                maxHeight: null,
                focus: true
            }
            );
        });
        $(document).ready(function () {
            $('#summernote2').summernote({
                height: 300,
                minHeight: null,
                maxHeight: null,
                focus: true
            }
            );
        });
        var rutas = Administracion["Unidades"];

        this.$onInit = () => {
            vm.Implementacion = administracionServices.GetConsultaAdministracion(rutas.GetConfigBuzon)[0];
            vm.MostrarSummernote();
            vm.LogoConfiguracionLogoApp = vm.Implementacion.DirectorioImagenesVirtualApp + vm.Implementacion.DirectorioSecundarioLogoApp;
            vm.LogoConfiguracionLogo = vm.Implementacion.DirectorioImagenesVirtualLogo + vm.Implementacion.DirectorioSecundarioLogo;
            vm.ImagenHomeConfiguracionImagenHome = vm.Implementacion.DirectorioImagenesVirtualHome + vm.Implementacion.DirectorioSecundarioImagenHome;
        }

        vm.MostrarSummernote = () => {
            $('#summernote').summernote('code', vm.Implementacion.FLN);
            $('#summernote2').summernote('code', vm.Implementacion.FLBF);
        }

        vm.cargaImagenLogoApp = function (e) {
            var imgTem = $("#selectPhotoFotoLogoApp").get(0);
            var fd = new FormData();
            fd.append("file", imgTem.files[0]);
            $http.post(
                rutas.CargarImagenAplicacion,
                fd,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                }).then(function Succescallback(response) {
                    console.log(response);
                    var DSecundarioApp = response.data.rutaArchivo;
                    vm.LogoConfiguracionLogoApp = response.data.rutaArchivo;
                    vm.Implementacion.DirectorioSecundarioLogoApp = DSecundarioApp.replace("../ExResources/Img/LogoApplicaciones/", "");
                }, function errorcallback(response) {
                    console.log(response.data);
                });
        };

        vm.cargaImagenLogo = function (e) {
            var imgTem = $("#selectPhotoFotoLogo").get(0);
            var fd = new FormData();
            fd.append("file", imgTem.files[0]);
            $http.post(
                rutas.cargaImagenBuzon,
                fd,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                }).then(function Succescallback(response) {console.log(response);
                    var DSecundario = response.data.rutaArchivo;
                    vm.LogoConfiguracionLogo = response.data.rutaArchivo;
                    vm.Implementacion.DirectorioSecundarioLogo = DSecundario.replace("../ExResources/Img/LogosBuzones/", "");//Esta carpeta no es
                    //vm.LogoConfiguracionLogo = vm.Implementacion.DirectorioImagenesVirtual + vm.Implementacion.DirectorioSecundarioLogo;

                }, function errorcallback(response) {
                    console.log(response.data);
                });
        };

        vm.cargaImagenHome = function (e) {
            var imgTem = $("#selectPhotoFotoHome").get(0);
            var fd = new FormData();
            fd.append("file", imgTem.files[0]);
            $http.post(
                rutas.cargaImagenBuzon,
                fd,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                }).then(function Succescallback(response) {
                    var DSecundarioHome = response.data.rutaArchivo;
                    vm.ImagenHomeConfiguracionImagenHome = response.data.rutaArchivo;
                    vm.Implementacion.DirectorioSecundarioImagenHome = DSecundarioHome.replace("../ExResources/Img/LogosBuzones/", "");
                    //vm.ImagenHomeConfiguracionImagenHome = vm.Implementacion.DirectorioImagenesVirtual + vm.Implementacion.DirectorioSecundarioImagenHome;
                }, function errorcallback(response) {
                    console.log(response.data);
                });
        };

        vm.ValidarAccion = function () {
            vm.Implementacion.FLN = $('#summernote').summernote('code');
            vm.Implementacion.FLBF = $('#summernote2').summernote('code');
            vm.ActualizarObjetoNegocio();

        }

        vm.Modo = function (seleccion) {
            vm.Implementacion.ModoTema = seleccion;
        }

        vm.Tema = function (seleccion) {
            vm.Implementacion.NombreTema = seleccion;
        }
        //Envía a base de datos
        vm.ActualizarObjetoNegocio = function () {
            Swal.fire(
                {
                    title: "PSR-Configuración",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        var result = administracionServices.ActualizarObjetoNegocio(rutas.UpdateConfigBuzon, vm.Implementacion);
                        if (!result.ExisteError) {
                            MensajeRegresoServidor(result, "success");
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };
    }])