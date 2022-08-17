implementacion.controller("crtlImplementacion", ["$scope", "$timeout", "administracionServices", "$http",
    function (vm = $scope, $timeout, administracionServices, $http) {
        var rutas = Administracion["Implementacion"];

        vm.EntidadFederativa = {};
        vm.TipoNivelGobierno = {};
        vm.LSTEntidadesFederativas = {};
        vm.LSTMunicipios = {};
        vm.Municipio = {};
        vm.CodigoPostal = {};
        vm.Colonia = {};
        vm.EntidadFederativaCircunscripcion ={};
        vm.MunicipiosCircunscripcion = {};
       

        
        $http.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(sessionStorage["ngStorage-GlobalSettings"]).Acceso.Token;
        vm.Implementacion = administracionServices.MetodPOST(rutas.GetImplementacion);
        if (vm.Implementacion.GUIDImplementacion != null && vm.Implementacion.RIDImplementacion != 0) {
            document.getElementById("#Licencia").disabled = true;
            document.getElementById("#condicionLicencia").style.display = "none";
            document.getElementById("datepicker-2").disabled = true;
            document.getElementById("datepicker-3").disabled = true;
            vm.LogoImplementacionLogo = vm.Implementacion.DirectorioImagenesVirtual + vm.Implementacion.LogoDirectorioSecundario;
            vm.LogoImplementacionFavicon = vm.Implementacion.DirectorioImagenesVirtual + vm.Implementacion.FaviconDirectorioSecundario;
            vm.LogoImplementacionImagenHome = vm.Implementacion.DirectorioImagenesVirtual + vm.Implementacion.ImagenHomeDirectorioSecundario;
            //var HInicio = new Date(parseInt(vm.Implementacion.HorarioInicioLaboral.replace("/Date(", "").replace(")/", "")));
            var HInicio = new Date(vm.Implementacion.HorarioInicioLaboral.replace("/Date(", "").replace(")/", ""));
            vm.Implementacion.HorarioInicioLaboral = HInicio;
            //var HFin = new Date(parseInt(vm.Implementacion.HorarioFinLaboral.replace("/Date(", "").replace(")/", "")));
            var HFin = new Date(vm.Implementacion.HorarioFinLaboral.replace("/Date(", "").replace(")/", ""));
            vm.Implementacion.HorarioFinLaboral = HFin;

            //var FInicio = new Date(parseInt(vm.Implementacion.FechaInicio.replace("/Date(", "").replace(")/", "")),);
            var FInicio = new Date(vm.Implementacion.FechaInicio.replace("/Date(", "").replace(")/", ""));
            var day = FInicio.getDate();
            var month = FInicio.getMonth() + 1;
            var year = FInicio.getFullYear();
            vm.Implementacion.FechaInicio = day + "/" + month + "/" + year;

            //var FFin = new Date(parseInt(vm.Implementacion.FechaFin.replace("/Date(", "").replace(")/", "")),);
            var FFin = new Date(vm.Implementacion.FechaFin.replace("/Date(", "").replace(")/", ""));
            var Fday = FFin.getDate();
            var Fmonth = FFin.getMonth() + 1;
            var Fyear = FFin.getFullYear();
            vm.Implementacion.FechaFin = Fday + "/" + Fmonth + "/" + Fyear;

        }

        vm.EntidadesFederativas = administracionServices.MetodPOST(rutas.GetImpEntidadesFederativas);
        //vm.EntidadFederativaCircunscripcion = EntidadesFederativas;

        //Actualizamos los combos

        vm.init = function () {

            if (vm.Implementacion != null && vm.Implementacion.claveNivelGobierno != 0) {
                vm.TipoNivelGobierno = vm.Implementacion.NivelesGobierno.find(function (element) {
                    return (element.ClaveTipoGobierno === vm.Implementacion.claveNivelGobierno)
                });
                if (vm.TipoNivelGobierno != undefined) {

                    vm.AsignarNivelGobierno(vm.TipoNivelGobierno);

                    if (vm.Implementacion.claveEntidadNivelGobierno != 0) {
                        vm.LSTEntidadesFederativas = vm.EntidadesFederativas.find(function (element) {
                            return (element.RIDEntidad === vm.Implementacion.claveEntidadNivelGobierno)
                        });
                    }

                    if (vm.LSTEntidadesFederativas != undefined) {
                        vm.MunicipiosCircunscripcion = administracionServices.MetodPOST(rutas.GetImpMunicipios, vm.LSTEntidadesFederativas);

                        if (vm.Implementacion.claveMunicipioNivelGobierno != 0) {
                            vm.LSTMunicipios = vm.MunicipiosCircunscripcion.find(function (element) {
                                return (element.RIDMunicipio === vm.Implementacion.claveMunicipioNivelGobierno)
                            });
                        }
                    }
                }

            } 
            vm.cargaLogo = function () {
                vm.LogoImplementacionLogo = null;
                vm.Implementacion.LogoDirectorioSecundario = null;
                var imgTem = $("#selectPhotoLogo").get(0);
                if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PNG' || imgTem.files[0].name.split('.').pop().toUpperCase() == 'SVG') {
                    var fd = new FormData();
                    fd.append("file", imgTem.files[0]);
                    $http.post(
                        rutas.CargarImagenLogoImplementacion,
                        fd, {
                        headers: { "Content-Type": void 0 },
                        transformRequest: angular.identity
                    }
                    ).then(function Succescallback(response) {
                        console.log(response);
                        var DSecundario = response.data;
                        vm.LogoImplementacionLogo = response.data;
                        vm.Implementacion.LogoDirectorioSecundario = DSecundario.substr(DSecundario.lastIndexOf("/") + 1, 41);
                    }, function errorcallback(response) { }
                    );
                } else { return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info'); } 
            };
            vm.cargaFavicon = function () {
                vm.Implementacion.FaviconDirectorioSecundario = "";
                var imgTem = $("#selectPhotoFavicon").get(0);
                if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PNG' || imgTem.files[0].name.split('.').pop().toUpperCase() == 'SVG') {
                    var fd = new FormData();
                    fd.append("file", imgTem.files[0]);
                    $http.post(
                        rutas.CargarImagenLogoImplementacion,
                        fd, {
                        headers: { "Content-Type": void 0 },
                        transformRequest: angular.identity
                    }
                    ).then(function Succescallback(response) {
                        console.log(response);
                        var DSecundario = response.data;
                        vm.LogoImplementacionFavicon = response.data;
                        vm.Implementacion.FaviconDirectorioSecundario = DSecundario.substr(DSecundario.lastIndexOf("/") + 1, 41);
                    }, function errorcallback(response) { }
                    );
                } else { return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info'); }
            };
            vm.cargaImagenHome = function () {
                vm.Implementacion.ImagenHomeDirectorioSecundario = "";
                var imgTem = $("#selectPhotoHome").get(0);
                if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PNG' || imgTem.files[0].name.split('.').pop().toUpperCase() == 'SVG') {
                    var fd = new FormData();
                    fd.append("file", imgTem.files[0]);
                    $http.post(
                        rutas.CargarImagenLogoImplementacion,
                        fd, {
                        headers: { "Content-Type": void 0 },
                        transformRequest: angular.identity
                    }
                    ).then(function Succescallback(response) {
                        console.log(response);
                        var DSecundario = response.data;
                        vm.LogoImplementacionImagenHome = response.data;
                        vm.Implementacion.ImagenHomeDirectorioSecundario = DSecundario.substr(DSecundario.lastIndexOf("/") + 1, 41);
                    }, function errorcallback(response) { }
                    );
                } else { return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info'); }
            };

            if (vm.Implementacion != null && vm.Implementacion.Estado != 0) {
                vm.EntidadFederativa = vm.EntidadesFederativas.find(function (element) {
                    return (element.RIDEntidad === vm.Implementacion.Estado)
                });
            } else {
                return;
            }
            if (vm.Implementacion != null && vm.Implementacion.ClaveMunicipio != 0) {
                vm.Municipios = administracionServices.MetodPOST(rutas.GetImpMunicipios, vm.EntidadFederativa);
                vm.Municipio = vm.Municipios.find(function (element) {
                    return (element.RIDMunicipio === vm.Implementacion.ClaveMunicipio)
                });
            } else {
                return;
            }
            if (vm.Implementacion != null && vm.Implementacion.CodigoPostal != 0) {
                vm.CodigosPostales = administracionServices.MetodPOST(rutas.ObtenerCodigoPostalMunicipio, vm.Municipio.RIDMunicipio);
                vm.CodigoPostal = vm.CodigosPostales.find(function (element) {
                    return (element.CP === vm.Implementacion.CodigoPostal)
                });
            } else {
                return;
            }
            if (vm.Implementacion != null && vm.Implementacion.ClaveCP != 0) {
                vm.Colonias = administracionServices.MetodPOST(rutas.ObtenerColoniasCP, vm.CodigoPostal.CP);
                vm.Colonia = vm.Colonias.find(function (element) {
                    return (element.RIDCP === vm.Implementacion.ClaveCP)
                });
            } else {
                return;
            }

        }
        this.$onInit = () => {
            vm.NivelGobiernoEstatal = false;
            vm.NivelGobiernoMunicipal = false;
            vm.init();
        }

        vm.FormatoFecha = function (fecha) {
            var date = new Date(fecha);
            var day = date.getDate();       // yields date
            var month = date.getMonth() + 1;    // yields month (add one as '.getMonth()' is zero indexed)
            var year = date.getFullYear();  // yields year
            var hour = date.getHours();     // yields hours 
            var minute = date.getMinutes(); // yields minutes
            var second = date.getSeconds(); // yields seconds

            // After this construct a string with the above results as below
            var time = day + "/" + month + "/" + year + " " + hour + ':' + minute + ':' + second; 
            return time;
            //return DateTime.ParseExact(time, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

        vm.ActualizarObjetoNegocio = function () {
            for (const el of document.querySelector('#mdmForm').querySelectorAll('[required]')) {
                if (!el.reportValidity()) {
                    return Swal.fire({ icon: 'info', text: 'Todos los campos son obligatorios' });
                }
            }
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas actualizar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {

                        vm.Implementacion.HorarioInicioLaboral = vm.FormatoFecha(vm.Implementacion.HorarioInicioLaboral);
                        vm.Implementacion.HorarioFinLaboral = vm.FormatoFecha(vm.Implementacion.HorarioFinLaboral);
                        vm.Implementacion.FechaInicio = vm.FormatoFecha(vm.Implementacion.FechaInicio);
                        vm.Implementacion.FechaFin = vm.FormatoFecha(vm.Implementacion.FechaFin);

                        if (vm.Implementacion.RIDImplementacion == 0) {
                            vm.Implementacion.ClaveDirectorioLogoImplementacion = 201;
                            vm.Implementacion.RIDImplementacion = 200000000001;
                            var result = administracionServices.MetodPOST(rutas.Setimplementacion, vm.Implementacion);
                            if (!result.ExisteError) {
                                Swal.fire({
                                    title: "La información se almacenó correctamente",
                                    icon: "success",
                                    allowOutsideClick: false
                                }).then(function (seleccion) {
                                    if (seleccion.value) {
                                        window.open("../Home/Index", "_self");//abre la ruta en la misma pestaña

                                    }
                                });
                            } else {
                                MensajeRegresoServidor(result, "error");
                            }
                        } else {
                            var result = administracionServices.MetodPOST(rutas.Updatetimplementacion, vm.Implementacion);
                            if (!result.ExisteError) {
                                Swal.fire({
                                    title: "La información se almacenó correctamente",
                                    icon: "success",
                                    allowOutsideClick: false
                                }).then(function (seleccion) {
                                    if (seleccion.value) {
                                        window.open("../Home/Index", "_self");//abre la ruta en la misma pestaña

                                    }
                                });
                            } else {
                                MensajeRegresoServidor(result, "error");
                            }
                        }                        
                    }
                }
            );
        };


        vm.ValidarAccion = function () {
            vm.Implementacion.Estado = vm.EntidadFederativa.RIDEntidad;
            vm.Implementacion.ClaveMunicipio = vm.Municipio.RIDMunicipio;
            vm.Implementacion.CodigoPostal = vm.CodigoPostal.CP;
            vm.Implementacion.ClaveCP = vm.Colonia.RIDCP;
            
            vm.ActualizarObjetoNegocio();
        }

        vm.AsignarEntidad = function (EntidaFederativa) {
            vm.EntidadFederativa = EntidaFederativa;
            vm.Municipios = administracionServices.MetodPOST(rutas.GetImpMunicipios, vm.EntidadFederativa);
            vm.CodigosPostales = {};
            vm.Colonia = {};
        }

        vm.AsignarMunicipio = function (Municipio) {
            vm.Municipio = Municipio;
            vm.CodigosPostales = administracionServices.MetodPOST(rutas.ObtenerCodigoPostalMunicipio, vm.Municipio.RIDMunicipio);
            vm.Colonia = {};
        }

        vm.AsignarCodigoPostal = function (CodigoPostal) {
            vm.CodigoPostal = CodigoPostal;
            vm.Colonias = administracionServices.MetodPOST(rutas.ObtenerColoniasCP, vm.CodigoPostal.CP);
        }

        vm.AsignarColonia = function (Colonia) {
            vm.Colonia = Colonia;
        }

        vm.Modo = function (seleccion) {
            vm.Implementacion.ModoTema = seleccion;
        }

        vm.Tema = function (seleccion) {
            vm.Implementacion.NombreTema = seleccion;
        }


        vm.AsignarNivelGobierno = function (seleccion) {

            vm.NivelGobiernoSeleccionado = seleccion;
            vm.Implementacion.claveNivelGobierno = vm.NivelGobiernoSeleccionado.ClaveTipoGobierno;
            if (vm.NivelGobiernoSeleccionado.TipoGobierno === 'Federal') {
                vm.NivelGobiernoEstatal = false;
                vm.NivelGobiernoMunicipal = false;
                vm.Implementacion.claveEntidadNivelGobierno = 0;
                vm.Implementacion.claveMunicipioNivelGobierno = 0;
                vm.LSTEntidadesFederativas = {};
                vm.LSTMunicipios = {};
            }
            if (vm.NivelGobiernoSeleccionado.TipoGobierno === 'Estatal') {
                vm.NivelGobiernoEstatal = true;
                vm.NivelGobiernoMunicipal = false;
                vm.Implementacion.claveMunicipioNivelGobierno = 0;
            }
            if (vm.NivelGobiernoSeleccionado.TipoGobierno === 'Municipal') {
                vm.NivelGobiernoEstatal = true;
                vm.NivelGobiernoMunicipal = true;
                vm.LSTMunicipios = {};
            }

        }

        vm.seleccionEntidadFederativa = function (EntidaFederativa) {
            vm.EntidadFederativaCircunscripcion = EntidaFederativa;
            vm.Implementacion.claveEntidadNivelGobierno = vm.EntidadFederativaCircunscripcion.RIDEntidad;
            vm.MunicipiosCircunscripcion = administracionServices.MetodPOST(rutas.GetImpMunicipios, vm.EntidadFederativaCircunscripcion);
        }

        vm.AsignarMunicipioCircunscripcion = function (seleccion) {
            vm.Implementacion.claveMunicipioNivelGobierno = seleccion.RIDMunicipio;
        }
        

    }])