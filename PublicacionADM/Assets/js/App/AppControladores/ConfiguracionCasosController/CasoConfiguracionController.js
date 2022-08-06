casoConfiguracion.controller("crtlCasoConfiguracion", ["$scope", "$timeout", "administracionServices", "$http",
    function (vm = $scope, $timeout, administracionServices, $http) {


        $(document).ready(function () {
            $('#summernote').summernote({
                height: 300,
                minHeight: null,
                maxHeight: null,
                focus: true
            });
            //$("summernote").width($(window).width() * 0.4)
        });

        //console.log(Administracion);

        const RUTAS = Administracion["ConfiguracionCasos"];
        const caracteresespeciales = Administracion["caracteresespecioales"];
        const caracteresespecialesc = Administracion["caracteresespecioalesc"];
        var respuesta = Administracion["ClasificacionSujetos"];
        var ConsultaAgrupadores = Administracion["AgrupadoresClasificadores"];

        vm.btnGuardar = false;
        vm.btnActualizar = false;
        vm.btnGuardarVariable = false;
        vm.btnActualizarVariable = false;

        vm.casoConfiguracion = {};
        vm.variableSeccion = {};
        vm.catTipoSujetoObjeto = {};
        vm.catAgrupadores = {};
        vm.modeloClasificador = {};
        vm.filtroClasificadores = {};
        vm.listaFormatos = [];
        vm.TCasoFormatoVariables = [];
        vm.respuestasCasos = [];
        vm.TablaClasificadores = [];
        vm.LstUnidadesAdm = [];
        vm.formatos = [];
        //Brand clasificadores agrupadores
        vm.btnInsertar = false;
        vm.btnNuevo = true;
        vm.AgrupadoresClasificadores = [];
        vm.listaux = [];
        vm.CasoUnidad = [];
        vm.entCasoClasificacion = {};
        vm.entDeleteCAC = {};
        vm.entModalGrupClass = {};
        vm.bactualizar = false;
        vm.Publicado = false;
        vm.Requiere = false;
        vm.btnDisabled = true;
        //vm.CasoStatus = "Publicado";
        vm.LstUnidadesAdm = {};
        vm.btnEdicion = false;
        vm.CasoStatus = "Publicar";
        vm.FormatosEliminados = [];
        vm.VariablesEliminadas = [];
        vm.RespuestasEliminadas = [];
        vm.UnidadesEliminadas = [];
        vm.FirmantesEliminados = [];
        vm.FirmantesEnDB = [];
        vm.FormatosEnDB = [];
        vm.VariablesEnDB = [];
        vm.RespuestasEnDB = [];
        vm.AnexosEnDB = [];
        vm.AnexosEliminados = [];
        //Configuracion de Documentos
        vm.configuracionDocumento = {};
        vm.listConfDocumentos = [];

        vm.vwFirmantes = [];
        vm.Firmante = {};
        vm.tblAnexos = [];
        vm.SlctPrioridad = {};





        this.$onInit = () => {
            //consulta TODAS las Configuraciones de CASO existentes
            vm.configuracionCasos = administracionServices.GetConsultaAdministracion(RUTAS.GetCasoConfiguracion);
            //AGRUPADORES Y CLASIFICADORES (AG y CL) solo llena los listbox de agrupador y clasificador
            vm.TablaAgrupadores = administracionServices.GetConsultaAdministracion(ConsultaAgrupadores.ConsultarAgrupadores);
            //MI ENTIDAD DE USUARIOS
            //vm.UsuarioActual = administracionServices.GetConsultaAdministracion(RUTAS.GetUsuario);
            //Obtener la UA para el usuario que hizo login 
            //vm.UnidadAdministrativa = administracionServices.GetConsultaAdministracionConParametro(RUTAS.GetUACasoConfiguracion, vm.UsuarioActual);
            vm.UnidadAdministrativa = {};
            vm.UnidadAdministrativa.RIDUnidadAdministrativa = 211;
            vm.UnidadAdministrativa.ClaveUAPadre = 0;
            //Vista de tabla agrupadores vacia
            vm.grupoClas = [];
            vm.CasoUnidad = [];
            vm.respuestasCasos = [];
        }//FIN OnInit();

        //Accion Nuevo o Regresar
        vm.RegresarInicial = () => {
            $("#selectPlantilla")[0].value = null;
            $("#selectAcuse")[0].value = null;
            vm.configuracionCasos = administracionServices.GetConsultaAdministracion(RUTAS.GetCasoConfiguracion);
            console.log(vm.casoConfiguracion);
            MostrarFormularios();
        }




        //Editar Caso Existente
        vm.FiltraCasoFormato = () => {

            //FORMATOS vive en vm.listaFormatos
            vm.relacionCasoFormato = administracionServices.GetConsultaAdministracion(RUTAS.Getrccasoformatos);
            //contiene el filtro de rccaso_formatos
            vm.relacionFiltro = vm.relacionCasoFormato.filter(item => (
                item.ClaveCCaso === vm.casoConfiguracion.RIDCCaso
            ));
            for (let i = 0; i < vm.formatos.length; i++) {
                for (let j = 0; j < vm.relacionFiltro.length; j++) {
                    if (vm.formatos[i].RIDFormato === vm.relacionFiltro[j].ClaveFormato) {
                        vm.nvoFormatoConRid = {};
                        vm.formatos[i].RID = vm.relacionFiltro[j].RID;
                        vm.listaFormatos.push(vm.formatos[i]);//Formatos para el caso actual
                        break;
                    }
                }
            }
            vm.FormatosEnDB = angular.copy(vm.listaFormatos);
            //Respuestas VIVE EN vm.respuestasCasos
            vm.respuestasCasos = [];//Las respuestas para el caso seleccionado actual 
            //Todas las respuestas de la tabla
            vm.respuestas = administracionServices.GetConsultaAdministracion(RUTAS.Gettcasosconfiguraciontiporespuestas);
            vm.resAux = vm.respuestas.filter(item => (item.ClaveCCaso === vm.casoConfiguracion.RIDCCaso));
            //vm.RIDAux = vm.respuestas.filter(value => value.ClaveCCaso === vm.casoConfiguracion.RIDCCaso);
            for (let i = 0; i < vm.resAux.length; i++) {
                for (let j = 0; j < vm.configuracionCasos.length; j++) {
                    if (vm.resAux[i].ClaveCCasoRespuesta === vm.configuracionCasos[j].RIDCCaso) {
                        //if (vm.configuracionCasos[j].RIDCCaso != vm.casoConfiguracion.RIDCCaso) {
                        vm.configuracionCasos[j].RID = vm.resAux[i].RID;
                        vm.respuestasCasos.push(vm.configuracionCasos[j]);
                        break;
                        //}
                    }
                }
            }
            vm.RespuestasEnDB = angular.copy(vm.respuestasCasos);

            //Variables vive en vm.TCasoFormatoVariables y sumernote
            vm.variables = administracionServices.GetConsultaAdministracion(RUTAS.GetCatConfiguracionVariables);
            vm.Confvar = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasoformatovariable);
            vm.resAux = vm.Confvar.filter(item => item.Clave === vm.casoConfiguracion.RIDCCaso);
            for (let i = 0; i < vm.resAux.length; i++) {
                for (let j = 0; j < vm.variables.length; j++) {
                    if (vm.resAux[i].ClaveVariable === vm.variables[j].RIDVariable) {
                        if (vm.resAux[i].Orden === 0) {
                            //tinyMCE.activeEditor.setContent(vm.resAux[i].ContenidoDefault);
                            $('#summernote').summernote('code', vm.resAux[i].ContenidoDefault);

                        } else {
                            vm.resAux[i].Title = vm.variables[j].Title;
                            vm.resAux[i].NombreInterno = vm.variables[j].NombreInterno;
                            vm.TCasoFormatoVariables.push(vm.resAux[i]);
                        }
                        break;
                    }
                }
            }
            vm.VariablesEnDB = angular.copy(vm.TCasoFormatoVariables);

        }//Filtra Casos Formatos y Variables 
        vm.ValidarTarea = (objetoNegocio, accion) => {
            //setTimeout("document.body.style.cursor = 'default'", 7000);
            $("#selectPlantilla")[0].value = null;
            $("#selectAcuse")[0].value = null;
            //console.log($("#selectPlantilla")[0].value);
            //console.log($("#selectAcuse")[0].value);
            vm.casoConfiguracion = objetoNegocio;
            vm.formatos = [];
            vm.listaFormatos = [];
            vm.catTipoServicios = {};
            vm.tipoCasos = {};
            vm.definicionesWorkFlow = {};
            vm.tipoResultados = {};
            vm.CasoUnidad = [];
            vm.FormatosEliminados = [];

            //llena listbobx de opciones
            vm.casoConfiguracion = objetoNegocio;
            vm.formatos = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasocformatos);
            vm.catTipoServicios = administracionServices.GetConsultaAdministracion(RUTAS.GetCatTipoServicios);
            vm.tipoCasos = administracionServices.GetConsultaAdministracion(RUTAS.GetTipoCaso);
            vm.ClasificacionCaso = administracionServices.GetConsultaAdministracion(RUTAS.ClasificacionCaso);
            vm.definicionesWorkFlow = administracionServices.GetConsultaAdministracion(RUTAS.GetWorkFlowDefinicion);

            vm.tipoResultados = administracionServices.GetConsultaAdministracion(RUTAS.GetTipoResultado);
            //vm.tipoDocumentos = administracionServices.GetConsultaAdministracion(RUTAS.GetCatTipoDocumentos);
            vm.FiltraCasoFormato();

            document.body.style.cursor = "default";
            if (accion === 'Actualizar') {
                vm.bactualizar = true;
                vm.grupoClas = {};
                vm.tblAnexos = [];
                vm.grupoClas = administracionServices.GetConsultaAdministracionConParametro(RUTAS.ConsultaGrupoClas, vm.casoConfiguracion);
                //Documentos desde la base
                vm.tblAnexos = administracionServices.GetConsultaAdministracionConParametro(RUTAS.GetDocumentByCase, vm.casoConfiguracion);
                vm.AnexosEnDB = angular.copy(vm.tblAnexos);
                vm.getPrioridad();
                vm.SlctPrioridad = vm.lstPrioridad.find(item => {
                    return vm.casoConfiguracion.Prioridad === item.RIDItemCatalogo;
                });
                console.log(vm.SlctPrioridad);

                $('#summernote').summernote('code', vm.casoConfiguracion.PlantillaCuerpoDocumento);

                vm.tipoServicio = vm.catTipoServicios.find(item => {
                    return vm.casoConfiguracion.ClaveTipoServicio === item.RID;
                });
                vm.tipoCaso = vm.tipoCasos.find(item => {
                    return vm.casoConfiguracion.ClaveTipoCaso === item.RIDItemCatalogo;
                });
                vm.Clasificacion = vm.ClasificacionCaso.find(item => {
                    return vm.casoConfiguracion.ClasificacionCaso === item.RIDItemCatalogo;
                });
                vm.definicionWorkFlow = vm.definicionesWorkFlow.find(item => {
                    return vm.casoConfiguracion.ClaveWorkFlow === item.RIDWorkFlow;
                });
                //vm.tipoDocumento = vm.tipoDocumentos.find(item => {
                //    return vm.casoConfiguracion.ClaveTipoDocumento === item.RIDTipoDocumento
                //});
                vm.tipoResultado = vm.tipoResultados.find(item => {
                    return vm.casoConfiguracion.ClaveTipoResultado === item.RIDItemCatalogo;
                });

                //Cargar valores de los permisos
                customSwitch2.checked = vm.casoConfiguracion.PermitirRespuesta;
                vm.Requiere = customSwitch3.checked = vm.casoConfiguracion.RequiereAcuse ? true : false;
                customSwitch4.checked = vm.casoConfiguracion.RequiereFiel;
                customSwitch5.checked = vm.casoConfiguracion.RequiereAutorizacion;
                IniciaAutoridad.checked = vm.casoConfiguracion.IniciaAutoridad;

                //vm.casoConfiguracion.DirectorioSecundario = vm.casoConfiguracion.DirectorioImagenes;
                //vm.casoConfiguracion.Respuestas;

                //cargar valores de unidades
                vm.CasoUnidad = angular.copy(vm.casoConfiguracion.LstUnidadesAdministrativas = administracionServices.GetConsultaAdministracionConParametro(RUTAS.GetListCasoUnidad, vm.casoConfiguracion));
                vm.btnGuardar = false;
                vm.btnActualizar = true;
                vm.btnInsertar = true;
                vm.btnNuevo = false;
            }
            vm.VariablesEliminadas = [];
            vm.RespuestasEliminadas = [];
            vm.UnidadesEliminadas = [];
            vm.FirmantesEliminados = [];
            console.log(vm.casoConfiguracion);
            MostrarFormularios();
        }
        //Crear Nuevo Caso
        vm.NuevoPuesto = () => {
            vm.btnGuardar = true;
            vm.btnActualizar = false;
            //Datos generales
            vm.casoConfiguracion = {};
            $("#selectPlantilla")[0].value = null;
            $("#selectAcuse")[0].value = null;
            $('#summernote').summernote('code', '');
            //Configuracion
            vm.tipoServicio = {};
            vm.tipoCaso = {};
            vm.definicionWorkFlow = {};
            vm.tipoResultado = {};
            vm.tipoDocumento = {};
            vm.listaFormatos = [];
            vm.TCasoFormatoVariables = [];
            customSwitch2.checked = false;
            customSwitch3.checked = false;
            customSwitch4.checked = false;
            customSwitch5.checked = false;
            IniciaAutoridad.checked = false;
            vm.casoConfiguracion.DirectorioSecundarioAcuse = "Plantilla.pdf";
            vm.casoConfiguracion.DirectorioSecundario = "Plantilla.pdf";

            vm.CasoUnidad = [];
            //Respuestas
            vm.respuestasCasos = [];

            vm.formatos = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasocformatos);
            vm.catTipoServicios = administracionServices.GetConsultaAdministracion(RUTAS.GetCatTipoServicios);
            vm.tipoCasos = administracionServices.GetConsultaAdministracion(RUTAS.GetTipoCaso);
            vm.definicionesWorkFlow = administracionServices.GetConsultaAdministracion(RUTAS.GetWorkFlowDefinicion);
            vm.tipoResultados = administracionServices.GetConsultaAdministracion(RUTAS.GetTipoResultado);
            vm.variables = administracionServices.GetConsultaAdministracion(RUTAS.GetCatConfiguracionVariables);
            vm.ClasificacionCaso = administracionServices.GetConsultaAdministracion(RUTAS.ClasificacionCaso);
            //Dias
            //Permisos
            vm.Requiere = false;
            vm.tblAnexos = [];
            //Agrupadores
            vm.btnInsertar = false;
            vm.btnNuevo = true;
            vm.grupoClas = [];
            //Mostrar Formulario
            MostrarFormularios();
        };

        vm.getformatos = function () {
            if (vm.formatos === undefined) { vm.formatos = administracionServices.GetConsultaAdministracion(RUTAS.GetTcasocformatos); }
        }
        vm.getcatTipoServicios = function () {
            if (vm.catTipoServicios === undefined) { vm.catTipoServicios = administracionServices.GetConsultaAdministracion(RUTAS.GetCatTipoServicios); }
        }
        vm.gettipoCasos = function () {
            if (vm.tipoCasos === undefined) { vm.tipoCasos = administracionServices.GetConsultaAdministracion(RUTAS.GetTipoCaso); }
        }
        vm.getdefinicionesWorkFlow = function () {
            if (vm.definicionesWorkFlow === undefined) { vm.definicionesWorkFlow = administracionServices.GetConsultaAdministracion(RUTAS.GetWorkFlowDefinicion); }
        }
        vm.gettipoResultados = function () {
            if (vm.tipoResultados === undefined) { vm.tipoResultados = administracionServices.GetConsultaAdministracion(RUTAS.GetTipoResultado); }
        }
        //vm.getvariables = function () {
        //    if (vm.variables === undefined) { vm.variables = administracionServices.GetConsultaAdministracion(RUTAS.GetCatConfiguracionVariables); }
        //}



        //Datos generales
        //Se carga la plantilla
        vm.CargarPlantilla = function (e) {
            let imgTem = $("#selectPlantilla").get(0);
            if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PDF') {
                let fd = new FormData();
                fd.append("file", imgTem.files[0]);
                $http.post(RUTAS.CargarPlantillaCConfiguracion, fd, { withCredentials: true, headers: { 'Content-Type': undefined }, transformRequest: angular.identity })
                    .then(function Succescallback(response) {
                        console.log(response);
                        var rutArchivo = response.data.rutaArchivo;
                        vm.casoConfiguracion.DirectorioSecundario = rutArchivo.replace("../ExResources/Plantillas/Casos/", "");
                    }, function errorcallback(response) {
                        console.log(response.data);
                    });
            }
            else
                return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
        };
        //Se carga el acuse
        vm.CargarAcuse = function (e) {
            let imgTem = $("#selectAcuse").get(0);
            if (imgTem.files[0].name.split('.').pop().toUpperCase() == 'PDF') {
                let fd = new FormData();
                fd.append("file", imgTem.files[0]);
                console.log(imgTem.files[0]);
                $http.post(RUTAS.CargarAcuseCConfiguracion, fd, { withCredentials: true, headers: { 'Content-Type': undefined }, transformRequest: angular.identity })
                    .then(function Succescallback(response) {
                        console.log(response);
                        vm.casoConfiguracion.DirectorioSecundarioAcuse = response.data.rutaArchivo.replace("../ExResources/Plantillas/Casos/", "");
                    }, function errorcallback(response) {
                        console.log(response.data);
                    });
            }
            else
                return MensajeGeneral("Compruebe que el formato de archivo sea el correcto e inténtelo de nuevo", 'info');
        };
        //Configuración
        vm.setConfiguracionCasos = objetoNegocio => {
            vm.configuracionCaso = objetoNegocio;

        }
        vm.setTipoServicio = (tipoServicio) => vm.tipoServicio = tipoServicio;
        vm.setTipoCaso = (tipoCaso) => vm.tipoCaso = tipoCaso;
        vm.setClasificacionCaso = (clasificacion) => vm.ClasificacionCasoSelec = clasificacion;
        vm.setDefinicion = (definicionWorkFlow) => vm.definicionWorkFlow = definicionWorkFlow;
        //vm.setTipoDocumento = (tipoDocumento) => vm.tipoDocumento = tipoDocumento;


        //Formatos
        vm.setTipoResultados = (tipoResultado) => vm.tipoResultado = tipoResultado;
        //vm.setTipoFormato = (tipoFormato) => vm.tipoFormato = tipoFormato;
        vm.setTipoFormato = function (tipoFormato) {
            vm.tipoFormato = tipoFormato;
            if (tipoFormato != undefined) {
                vm.btnDisabled = false;
                document.getElementById("btnADDFORMATO").focus();
            }
            else {
                vm.btnDisabled = true;
            }

        }
        vm.AddFormato = (tipoFormato) => {

            for (var i = 0; vm.listaFormatos.length > i; i++) {
                if (vm.listaFormatos[i].RIDFormato === tipoFormato.RIDFormato) {
                    vm.tipoFormato = null;
                    vm.btnDisabled = true;
                    MensajeGeneral("El formato ya se encuentra seleccionado", "info");
                    return;
                }
            }
            if (tipoFormato != undefined) {
                vm.listaFormatos.push(tipoFormato);
                //eliminar de Listapara seleccionar
                //var idxitem = 0;
                //idxitem = vm.formatos.indexOf(tipoFormato);
                //vm.formatos.splice(idxitem, 1);
                vm.tipoFormato = null;
                vm.btnDisabled = true;
            }

        }

        //Respuestas
        vm.addRespuestaCaso = (item) => {
            item;
            //SI NO ESTA DEFINIDO     SI NO ESTA NULO             SI NO ESTA VACIO
            if (item != undefined) {
                if (item != null) {
                    if (vm.configuracionCaso.hasOwnProperty("RIDCCaso")) {
                        if (vm.configuracionCaso != undefined && vm.respuestasCasos != undefined) {
                            for (var i = 0; i < vm.respuestasCasos.length; i++) {
                                if (vm.configuracionCaso.Nombre === vm.respuestasCasos[i].Nombre) {
                                    MensajeGeneral("Seleccion invalida, favor de ingresar otro caso para la respuesta", "info");
                                    vm.configuracionCaso = {};
                                    return;
                                }
                            }
                        }

                        if (vm.respuestasCasos === undefined) {
                            vm.respuestasCasos = angular.copy(vm.configuracionCaso);
                        }
                        else {
                            vm.respuestasCasos.push(vm.configuracionCaso);
                        }
                        vm.configuracionCaso = {};
                    }
                }
            }
        }

        //Variables
        vm.ObtenerVariablePrimaria = () => {
            vm.variableSeccion.ClaveTipoFormulario = 45;
            //vm.variableSeccion.Clave = vm.casoSecciones.RIDSeccion;
            vm.variableSeccion.ClaveVariable = 202;
            //vm.variableSeccion.ContenidoDefault = tinymce.get("tinymce").getContent();
            vm.variableSeccion.ContenidoDefault = $('#summernote').summernote('code');
            vm.TCasoFormatoVariables.push(vm.variableSeccion);
        }
        vm.NuevoProcesoVariable = () => {
            //console.log(vm.variables);
            vm.btnGuardarVariable = true;
            vm.btnActualizarVariable = false;
            vm.variableSeccion.ContenidoDefault = '';
            //tinymce.get("tinymce").getContent();
        }
        vm.CancelarVariables = () => {
            vm.NuevaVariables();
            $('#frmVariables').modal('hide');
        }
        vm.NuevaVariables = () => {
            vm.variable = {};
            vm.variableSeccion = {};
        }
        vm.setVariables = objetoNegocio => (vm.variable = objetoNegocio);
        vm.ValidarAccionVariable = () => {
            if (vm.btnGuardarVariable) {
                vm.variableSeccion.ClaveTipoFormulario = 45;
                //vm.variableSeccion.Clave = vm.casoSecciones.RIDSeccion;
                vm.variableSeccion.ClaveVariable = vm.variable.RIDVariable;
                vm.variableSeccion.Title = vm.variable.Title;
                vm.variableSeccion.NombreInterno = vm.variable.NombreInterno;

                for (var i = 0; i < vm.TCasoFormatoVariables.length; i++) {
                    if (vm.TCasoFormatoVariables[i].NombreInterno === vm.variableSeccion.NombreInterno) {
                        return MensajeGeneral("Ya se ha ingresado esta variable.");
                    }
                }

                vm.TCasoFormatoVariables.push(vm.variableSeccion);
                vm.CancelarVariables();
            }
        }

        //Permisos
        //Añadir Acuse
        vm.AddAcuse = function () {
            if (customSwitch3.checked) {
                vm.casoConfiguracion.DirectorioSecundarioAcuse = "Plantilla.pdf";
                vm.Requiere = true;
                $('#reqselec').prop('required', true);
            }
            else {
                if (vm.casoConfiguracion.DirectorioSecundarioAcuse != "Plantilla.pdf") {
                    Swal.fire({
                        title: "Gobierno Digital",
                        text: "Se eliminará la plantilla seleccionada",
                        icon: 'info',
                        showCancelButton: true,
                        confirmButtonText: 'Aceptar',
                        focusCancel: true,
                        allowOutsideClick: false

                    }).then((result) => {
                        if (result.isConfirmed) {
                            Swal.fire(
                                'Actualizado',
                                '',
                                'success'
                            ).then((result) => {
                                if (result.isConfirmed) {
                                    vm.Requiere = false;
                                    $('#reqselec').removeAttr('required');
                                    vm.ReshapeTable('customSwitch3');
                                    //ReshapeTable('customSwitch3');
                                }
                            })
                        } else if (result.dismiss === Swal.DismissReason.cancel) {
                            vm.Requiere = true;
                            customSwitch3.checked = true;
                            swalWithBootstrapButtons.fire(
                                'Cancelado'
                            ).then((result) => {
                                if (result.isConfirmed) {
                                    vm.ReshapeTable('customSwitch3');
                                    //ReshapeTable('customSwitch3');
                                    vm.ReshapeTable('selectAcuse');
                                    //ReshapeTable('selectAcuse');
                                }
                            })
                        }
                    })
                }
                vm.Requiere = false;
                $('#reqselec').removeAttr('required');
                vm.ReshapeTable('customSwitch3');
                //ReshapeTable('customSwitch3');
            }
        }
        //Agrupadores Clasificadores
        vm.AgrupadoresClasificadores = function () {
            //AGRUPADORES Y CLASIFICADORES (AG y CL) solo llena los listbox de agrupador y clasificador
            vm.TablaAgrupadores = administracionServices.GetConsultaAdministracion(ConsultaAgrupadores.ConsultarAgrupadores);

            if (localStorage.getItem("AgrupadoresSeleccionados") != 'undefined')
                vm.TablaAgrupadoresSeleccionados = JSON.parse(localStorage.getItem("AgrupadoresSeleccionados"));
            if (localStorage.getItem("ClasificadoresSeleccionados") != 'undefined')
                vm.TablaClasificadoresSeleccionados = JSON.parse(localStorage.getItem("ClasificadoresSeleccionados"));
            if (vm.TablaAgrupadoresSeleccionados.length > 0) {
                for (let a = 0; a < vm.TablaAgrupadoresSeleccionados.length; a++) {
                    document.getElementById("lstAgrupadorFiltro").value = vm.TablaAgrupadoresSeleccionados[a].RIDAgrupador;
                }
            }
            if (vm.TablaClasificadoresSeleccionados != null) {
                lstSeleccionClasificadorFiltro = vm.TablaClasificadoresSeleccionados;
                //lstSeleccionAgrupadorFiltro = vm.TablaAgrupadoresSeleccionados;
            }
            vm.tablaClasificacionObjetos = administracionServices.GetConsultaAdministracionConParametro(respuesta.ConsultarObjetosClasificados, JSON.parse(localStorage.getItem("ClasificadoresSeleccionados")));
        }

        vm.CancelarAgrupadorCaso = () => {
            $('#frmAgrupadores').modal('hide');
        }
        vm.AceptarAgrupadorCaso = () => {
            $('#frmAgrupadores').modal('hide');
        }
        vm.asignaAgrupadorFiltro = (itemAgrupador) => {
            localStorage.setItem("AgrupadoresSeleccionados", JSON.stringify(itemAgrupador));
            vm.TablaClasificadoresFiltro = administracionServices.GetConsultaAdministracionConParametro(RUTAS.ConsultarClasificadoresCasos, itemAgrupador);
        }
        vm.InsertarCasosAgrupadorClasificador = function (RIDCcaso) {
            //Seccion de Inserta en DB al darle boton Guardar
            for (var i = 0; i < vm.grupoClas.length; i++) {

                vm.entCasoClasificacion.ClaveClasificador = vm.grupoClas[i].ClaveClasificador;
                vm.entCasoClasificacion.ClaveGrupo = vm.grupoClas[i].ClaveGrupo;
                vm.entCasoClasificacion.ClaveCaso = RIDCcaso;

                var result = administracionServices.IngresarObjetoNegocio(RUTAS.InsertarCasosAgrupadorClasificador, vm.entCasoClasificacion);

                if (result.ExisteError) {
                    vm.errorGuardadoGrupoClas = 1;
                }
                else {
                    vm.errorGuardadoGrupoClas = 0;

                }
            }
        }
        vm.InsertarListaAgrupadorClasificadorNuevo = function () {
            //Leemos el ID del Agrupador y el Clasificador
            vm.listaux = {};
            vm.listaux.ClaveClasificador = vm.lstSeleccionClasificadorFiltro.RIDClasificador;
            vm.listaux.ClaveGrupo = vm.lstSeleccionClasificadorFiltro.RIDAgrupador;
            //Leemos la descripcion de los campos
            vm.listaux.NombreClasificador = vm.lstSeleccionClasificadorFiltro.nombreClasificador;
            vm.listaux.NombreGrupo = vm.lstSeleccionClasificadorFiltro.nombreAgrupador;

            // VALIDAMOS SI EXISTE EL ELEMENTO
            if (vm.grupoClas.length >= 0) {
                Existe = false;
                for (var i = 0; i < vm.grupoClas.length; i++) {
                    if (vm.grupoClas[i].ClaveGrupo === vm.listaux.ClaveGrupo && vm.grupoClas[i].ClaveClasificador === vm.listaux.ClaveClasificador) {
                        Existe = true; break;
                    }
                }
                if (Existe) {
                    Swal.fire({
                        icon: 'info',
                        title: 'Éste elemento ya fue registrado con anterioridad.'
                    })
                }
                else {
                    //Insertamos en la lista  
                    vm.grupoClas.push(vm.listaux);
                    //Limpiamos la lista auxiliar
                    vm.listaux = {};
                    vm.lstSeleccionClasificadorFiltro = {};
                    vm.lstSeleccionAgrupadorFiltro = {};
                    //Oculta el modal y regresa a Formulario
                    vm.AceptarAgrupadorCaso();
                }
            }
        }
        vm.DropListaAgrupadorClasificadorNuevo = function (tGrupoClas) {
            //Delete logico de la Lista
            //Leemos el ID del item a eliminar
            var idxitem = 0;
            idxitem = vm.grupoClas.indexOf(tGrupoClas);
            //Eliminamos el item de la lista 
            vm.grupoClas.splice(idxitem, 1);
        }
        vm.InsertarCasosAgrupadorClasificadorModal = function (casoConfiguracion) {
            //Inserta directamente en la base cuando se edita un caso para agregar agrupadores y clasificadores

            //Leemos el ID del Agrupador y el Clasificador
            vm.entCasoClasificacion.ClaveClasificador = vm.lstSeleccionClasificadorFiltro.RIDClasificador;
            vm.entCasoClasificacion.ClaveGrupo = vm.lstSeleccionClasificadorFiltro.RIDAgrupador;
            //se llena entidad con la clave del caso que estamos editando
            vm.entCasoClasificacion.ClaveCaso = casoConfiguracion.RIDCCaso;

            // VALIDAMOS SI EXISTE EL ELEMENTO

            if (vm.grupoClas.length >= 0) {
                Existe = false;
                for (var i = 0; i < vm.grupoClas.length; i++) {
                    if (vm.grupoClas[i].ClaveGrupo === vm.entCasoClasificacion.ClaveGrupo && vm.grupoClas[i].ClaveClasificador === vm.entCasoClasificacion.ClaveClasificador) {
                        Existe = true; break;
                    }
                }
                if (Existe) {
                    Swal.fire({
                        icon: 'info',
                        title: 'Éste elemento ya fue registrado con anterioridad.'
                    })
                }
                else {
                    //Insertar en la tabla tconfiguracion_casosagrupadorClasificador
                    var result = administracionServices.IngresarObjetoNegocio(RUTAS.InsertarCasosAgrupadorClasificador, vm.entCasoClasificacion);
                    //ACTUALIZAR VARIABLE CON LA QUE SE LLENA LA  VISTA DE TABLA DESDE LA BASE
                    vm.grupoClas = administracionServices.GetConsultaAdministracionConParametro(RUTAS.ConsultaGrupoClas, casoConfiguracion);
                    vm.lstSeleccionClasificadorFiltro = {};
                    vm.lstSeleccionAgrupadorFiltro = {};
                    //Oculta el modal y regresa a Formulario
                    vm.AceptarAgrupadorCaso();
                }
            }
        }

        //Unidades Administrativas
        vm.CancelarCasoUnidad = () => {
            $('#frmCasoUnidad').modal('hide');
        }
        vm.ModalCasoUnidad = function () {
            //Obtener las UA Hermanas e Hijas de la UA Actual
            vm.LstUnidadesAdm = administracionServices.GetConsultaAdministracionConParametro(RUTAS.GetListUACasoConfiguracion, vm.UnidadAdministrativa);
            vm.LstUnidadesAdm;
        }

        vm.AceptarCasoUnidad = function (UAseleccion) {
            var flag = false;
            UAseleccion;
            flag = 'NombreUA' in UAseleccion;
            if (flag) {
                flag = false;
                //Validar si el elemento ya existe
                for (var i = 0; i < vm.CasoUnidad.length; i++) {
                    if (vm.CasoUnidad[i].RIDUnidadAdministrativa === UAseleccion.RIDUnidadAdministrativa) { flag = true; }
                }
                if (!flag) {
                    //Insertamos en la lista  
                    vm.CasoUnidad.push(UAseleccion);
                    //Oculta el modal y regresa a Formulario    
                    $('#frmCasoUnidad').modal('hide');
                }
                else {
                    Swal.fire({
                        icon: 'info',
                        title: 'Ya se han concedido permisos a ésta Unidad.'
                    })
                }
            }
            else {
                Swal.fire({
                    icon: 'info',
                    title: 'Selecciona un elemento de la lista'
                })
            }
        }
        vm.InsertarRequeridos = function (Actualiza) {
            //aqui revisar los documentos requeridos
            console.log(vm.tblAnexos);
            if (Actualiza)//si es actualizacion
            {
                //obtener elementos para mandar a base de datos
                var send = true;
                for (var i = 0; i < vm.tblAnexos.length; i++)//recorrer TblVISTA
                {
                    send = true;//asumimos que se va a enviar 
                    for (var j = 0; j < vm.AnexosEnDB.length; j++)//recorrer elementos en BD
                    {//comparamos y si algun ID es igual en la base NO ENVIAMOS
                        if (vm.tblAnexos[i].RIDRequisito === vm.AnexosEnDB[j].RIDRequisito) {
                            send = false;
                            break;
                        }
                    }
                    if (send) {
                        //si no esta en Base... se envía
                        vm.tblAnexos[i].ClaveCCaso = vm.casoConfiguracion.RIDCCaso;
                        //Enviar a Base
                        var result = administracionServices.IngresarObjetoNegocio(RUTAS.SetCCasoDocumento, vm.tblAnexos[i]);
                    }
                }
            }
            else {//guardar simplemente
                //llenar lista de Configuracion de Caso
                vm.casoConfiguracion.LstDocumentosRequeridos = vm.tblAnexos;
                //Se envia cada elemento de la lista a la base de datos
                for (var i = 0; i < vm.casoConfiguracion.LstDocumentosRequeridos.length; i++) {
                    vm.casoConfiguracion.LstDocumentosRequeridos[i].ClaveCCaso = vm.casoConfiguracion.RIDCCaso;
                    console.log(vm.casoConfiguracion.LstDocumentosRequeridos[i]);
                    //Enviar a Base
                    var result = administracionServices.IngresarObjetoNegocio(RUTAS.SetCCasoDocumento, vm.casoConfiguracion.LstDocumentosRequeridos[i]);
                }
            }
        }
        vm.GuardarUnidadAdmCCaso = function (Actualiza) {
            //Entidad con Casos y Unidades Administrativas
            vm.entCasoUnidad = {};
            if (Actualiza)//si es actualizacion
            {
                //obtener elementos para mandar a base de datos
                var send = true;
                for (var i = 0; i < vm.CasoUnidad.length; i++)//recorrer TblVISTA
                {
                    send = true;//asumimos que se va a enviar 
                    for (var j = 0; j < vm.casoConfiguracion.LstUnidadesAdministrativas.length; j++)//recorrer elementos en BD
                    {//comparamos y si algun ID es igual en la base NO ENVIAMOS
                        if (vm.CasoUnidad[i].RIDUnidadAdministrativa === vm.casoConfiguracion.LstUnidadesAdministrativas[j].RIDUnidadAdministrativa) {
                            send = false;
                            break;
                        }
                    }
                    if (send) {
                        //si no esta en Base... se envía
                        vm.entCasoUnidad.RIDCCaso = vm.casoConfiguracion.RIDCCaso;
                        vm.entCasoUnidad.RIDUnidadAdministrativa = vm.CasoUnidad[i].RIDUnidadAdministrativa;
                        vm.entCasoUnidad;
                        //Enviar a Base
                        var result = administracionServices.IngresarObjetoNegocio(RUTAS.SetUnidadCCaso, vm.entCasoUnidad);
                    }
                }
            }
            else {//guardar simplemente
                //llenar lista de Configuracion de Caso
                vm.casoConfiguracion.LstUnidadesAdministrativas = vm.CasoUnidad;
                //Se envia cada elemento de la lista a la base de datos
                for (var i = 0; i < vm.casoConfiguracion.LstUnidadesAdministrativas.length; i++) {
                    vm.entCasoUnidad.RIDCCaso = vm.casoConfiguracion.RIDCCaso;
                    vm.entCasoUnidad.RIDUnidadAdministrativa = vm.casoConfiguracion.LstUnidadesAdministrativas[i].RIDUnidadAdministrativa;
                    vm.entCasoUnidad;
                    //Enviar a Base
                    var result = administracionServices.IngresarObjetoNegocio(RUTAS.SetUnidadCCaso, vm.entCasoUnidad);
                }
            }
        }

        //IniciaContribuyente
        vm.GetFirmantes = function () {

            if (vm.lstFirmantes === undefined) {
                vm.lstFirmantes = administracionServices.GetConsultaAdministracionConParametro(RUTAS.GetFirmantes, vm.UnidadAdministrativa);
            }
            //console.log(lstFirmantes);
        }
        vm.SetFirmantes = (Seleccion) => vm.FirmanteSeleccionado = Seleccion;
        vm.addFirmante = function (Seleccion) {
            if (vm.lstFirmantes.indexOf(Seleccion) >= 0) {
                if (vm.vwFirmantes.indexOf(Seleccion) < 0) { vm.vwFirmantes.push(Seleccion); }
                else { vm.FirmanteSeleccionado = {}; return MensajeGeneral("Ya ha sido agregado", "info"); }
                vm.FirmanteSeleccionado = {};
            }
        }
        vm.dropFirmante = function (Seleccion) {
            if (vm.FirmantesEliminados.indexOf(Seleccion) < 0) { vm.FirmantesEliminados.push(Seleccion); }
            vm.vwFirmantes.splice(vm.vwFirmantes.indexOf(Seleccion), 1);
            console.log(FirmantesEliminados);
        }

        //Documentos Requeridos
        function sortByKey(array, key) { return array.sort(function (a, b) { return ((a[key] < b[key]) ? -1 : ((a[key] > b[key]) ? 1 : 0)); }); }
        vm.GetTipoArchivo = function () {
            if (vm.lstTipoArchivo === undefined) {
                vm.lstTipoArchivo = administracionServices.GetConsultaAdministracion(RUTAS.GetCatTipoDocumentos);
            }//vm.lstTipoArchivo;
        }
        vm.AddTipoDocumento = function (Doc) {
            Doc.Requerido = vm.configuracionDocumento.Requerido;
            Doc.Orden = vm.configuracionDocumento.Orden;
            if (vm.tblAnexos.indexOf(Doc) < 0) {
                if (!(Doc.Orden === null || Doc.Orden === undefined || Doc.Orden === '') && (Doc.Orden >= 1 && Doc.Orden <= 50)) {
                    for (var i = 0; i < vm.tblAnexos.length; i++) {
                        if (vm.tblAnexos[i].Orden == Doc.Orden) { return MensajeGeneral("Asignado, elige un número de orden distinto.", "info"); }
                    }//push a la lista y ordenar
                    vm.tblAnexos.push(Doc); vm.tblAnexos = sortByKey(vm.tblAnexos, 'Orden');
                }
                else { return MensajeGeneral("Verifica el valor del orden 1 a 50, solo números enteros", "info"); }
            } else { return MensajeGeneral("Ya ha sido agregado", "info"); }
            vm.CancelarDocumentos();
        }
        vm.dropRequisito = function (itm) {
            if (vm.AnexosEliminados.indexOf(itm) < 0) { vm.AnexosEliminados.push(itm); }
            vm.tblAnexos.splice(vm.tblAnexos.indexOf(itm), 1);
        }
        vm.ModalDocumentos = function () {
            vm.configuracionDocumento = {};
            vm.configuracionDocumento.Requerido = false;
            vm.tipoDocumento = {};
        }
        vm.changeTipoArchivo = function (tFile) {
            vm.tipoDocumento.TipoArchivo = tFile;
            //vm.tipoDocumento.TipoArchivo;
            //vm.tipoDocumento.TipoArchivo.RID;
            //vm.tipoDocumento.TipoArchivo.NombreTipoArchivo;
            //vm.tipoDocumento.TipoArchivo.NombreCorto;
            //vm.tipoDocumento.TipoArchivo.Extencion;
            //vm.tipoDocumento.TipoArchivo.TypeMime;

            if (vm.tipoDocumento.TipoArchivo != undefined) {
                vm.bMostrarExt = true;
            }
            else { vm.bMostrarExt = false; }
        }
        vm.CancelarDocumentos = () => {
            $('#frmConfDocumentos').modal('hide');
        }


        vm.setPrioridad = (Prioridad) => vm.SlctPrioridad = Prioridad;
        vm.getPrioridad = function () {
            if (vm.lstPrioridad === undefined) {
                vm.lstPrioridad = administracionServices.GetConsultaAdministracion(RUTAS.GetDescriptivoPrioridad);
            }
        }
        vm.Autoridad = function () {
            if (!vm.casoConfiguracion.IniciaAutoridad) {
                //vm.casoConfiguracion.IniciaAutoridad = true;
                //Swal.fire(
                //    {
                //        title: "Gobierno Digital",
                //        text: "Se limpiará la lista de firmantes, ¿Estás de Acuerdo?",
                //        icon: "question",
                //        showCancelButton: true,
                //        cancelButtonText: 'No',
                //        confirmButtonText: "Si"
                //    }).then(function (seleccion) {
                //        if (seleccion.value) {
                //            vm.casoConfiguracion.IniciaAutoridad = false;
                            vm.vwFirmantes = [];
                            //IniciaAutoridad.checked = false;
                            
                //        }
                //    }
                //);
            }
        }

        //GUARDAR
        vm.ValidarAccion = () => {
            //si esta chekeado y  no subio 
            if (vm.Requiere && (vm.casoConfiguracion.DirectorioSecundarioAcuse === "" || vm.casoConfiguracion.DirectorioSecundarioAcuse === undefined)) {
                return MensajeGeneralFocus("Necesitas adjuntar una plantilla de Acuse", 'info', 'Atencion');
            }
            //si esta chekeado y  no hay firmante
            if (vm.casoConfiguracion.IniciaAutoridad && (vm.vwFirmantes.length === 0 || vm.vwFirmantes === undefined)) {
                return MensajeGeneral("Se necesita al menos un firmante", 'info');
            }













            //Guardar o Actualizar......SIEMPRE HACE ESTO ANTES DE... guardar o actualizar
            vm.casoConfiguracion.Prioridad = vm.SlctPrioridad.RIDItemCatalogo;
            vm.casoConfiguracion.ClaveTipoServicio = vm.tipoServicio.RID;
            vm.casoConfiguracion.ClaveTipoCaso = vm.tipoCaso.RIDItemCatalogo;
            vm.casoConfiguracion.ClaveWorkFlow = vm.definicionWorkFlow.RIDWorkFlow;
            if (vm.ClasificacionCasoSelec != null || vm.ClasificacionCasoSelec != undefined) {
                vm.casoConfiguracion.ClasificacionCaso = vm.ClasificacionCasoSelec.RIDItemCatalogo;
            }
            //vm.casoConfiguracion.ClaveTipoDocumento = vm.tipoDocumento.RIDTipoDocumento;
            if (vm.tipoResultado === undefined) {
                vm.casoConfiguracion.ClaveTipoResultado = 0;
            }
            else {
                vm.casoConfiguracion.ClaveTipoResultado = vm.tipoResultado.RIDItemCatalogo;
            }
            vm.casoConfiguracion.ListaFormatos = vm.listaFormatos;
            vm.Respuestas = vm.respuestasCasos;
            var strContenidoPlantilla = $('#summernote').summernote('code');

            //for (let i = 0; i < CaracteresEspecialesC.length; i++){
            //    strContenidoPlantilla = strContenidoPlantilla.replace(CaracteresEspecialesC[i], CaracteresEspeciales[i]);
            //}
            //strContenidoPlantilla = strContenidoPlantilla.replace(";", CaracteresEspeciales.caracterPunyCom);
            //strContenidoPlantilla = strContenidoPlantilla.replace(":", CaracteresEspeciales.caracter2Puntos)
            //strContenidoPlantilla = strContenidoPlantilla.replace(/"/gi, CaracteresEspeciales.caracterComillas);
            //strContenidoPlantilla = strContenidoPlantilla.replace(/'/gi, CaracteresEspeciales.caracterComilla);
            //strContenidoPlantilla = strContenidoPlantilla.replace(/=/gi, CaracteresEspeciales.caracterIgual);
            //strContenidoPlantilla = strContenidoPlantilla.replace(/\[/gi, CaracteresEspeciales.caracterCorcheteA);
            //strContenidoPlantilla = strContenidoPlantilla.replace(/\]/gi, CaracteresEspeciales.caracterCorcheteC);
            //strContenidoPlantilla = strContenidoPlantilla.replace(/{/gi, CaracteresEspeciales.caracterLlaveA);
            //strContenidoPlantilla = strContenidoPlantilla.replace(/}/gi, CaracteresEspeciales.caracterLlaveC);
            //strContenidoPlantilla = strContenidoPlantilla.replace(/\|/gi, CaracteresEspeciales.caracterPIE);





            //VALIDAR QUE NO SE ENVIEN NULOS NI SE GUARDEN NULOS EN ESTE CAMPO O LE TRUENA A JESUS Y NO SE ENVIA LA RESPUESTA
            vm.casoConfiguracion.PlantillaCuerpoDocumento = strContenidoPlantilla;
            if (vm.casoConfiguracion.PlantillaCuerpoDocumento === null) {
                vm.casoConfiguracion.PlantillaCuerpoDocumento = "";
            }









            vm.ObtenerVariablePrimaria();
            vm.casoConfiguracion.Variables = vm.TCasoFormatoVariables;

            //Leer valores del checkbox 
            vm.casoConfiguracion.PermitirRespuesta = customSwitch2.checked ? 1 : 0;
            vm.casoConfiguracion.RequiereAcuse = customSwitch3.checked ? 1 : 0;
            vm.casoConfiguracion.RequiereFiel = customSwitch4.checked ? 1 : 0;
            vm.casoConfiguracion.RequiereAutorizacion = customSwitch5.checked ? 1 : 0;
            vm.casoConfiguracion.Respuestas = vm.respuestasCasos;
            
            if (vm.btnGuardar) {
                vm.GuardarObjetoCasoConfiguracion();//aqui entra cuando le das guardar en un nuevo caso
            } else {
                vm.ActualizarCasoConfiguracion();//Editar caso existente
            }
        }
        vm.GuardarObjetoCasoConfiguracion = () => {
            vm.casoConfiguracion.Nombre = vm.casoConfiguracion.Nombre.toUpperCase();
            vm.casoConfiguracion.NombreInterno = vm.casoConfiguracion.NombreInterno.toUpperCase();
            vm.casoConfiguracion.NombreExterno = vm.casoConfiguracion.NombreExterno.toUpperCase();
            vm.casoConfiguracion.Descripcion = vm.casoConfiguracion.Descripcion.toUpperCase();
            vm.casoConfiguracion.DescripcionInterna = vm.casoConfiguracion.DescripcionInterna.toUpperCase();
            vm.casoConfiguracion.DescripcionExterna =  vm.casoConfiguracion.DescripcionExterna.toUpperCase();
            vm.casoConfiguracion.AbreviaturaInterna = vm.casoConfiguracion.AbreviaturaInterna.toUpperCase();
            vm.casoConfiguracion.AbreviaturaExterna = vm.casoConfiguracion.AbreviaturaExterna.toUpperCase();
            vm.casoConfiguracion.Variables.ClaveTipoFormulario = 45;
            vm.casoConfiguracion.Variables.Orden = 10;
            vm.casoConfiguracion.Variables.ClaveVariable = 202;
            vm.casoConfiguracion.Variables.Required = 0;
            vm.casoConfiguracion.Variables.ContenidoDefault = '';//////////////////revisar esta sección
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas Guardar la configuracion del caso?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        vm.casoConfiguracion.ClaveUnidadAdministrativa = vm.UnidadAdministrativa.RIDUnidadAdministrativa;
                        var result = administracionServices.IngresarObjetoNegocio(RUTAS.SetCasoConfiguracion, vm.casoConfiguracion);

                        if (!result.ExisteError) {
                            vm.casoConfiguracion.RIDCCaso = result.Dato;
                            vm.InsertarRequeridos();
                            vm.GuardarUnidadAdmCCaso(false);
                            vm.InsertarCasosAgrupadorClasificador(result.Dato);

                                            //MM
                                            if (vm.errorGuardadoGrupoClass === 1) {
                                                //Mensaje de guardado
                                            }

                            MensajeRegresoServidor(result, "success");
                            //$('#mdmForm');
                            $timeout(function () {
                                vm.casoConfiguracion = {};
                                vm.tipoServicio = {};
                                vm.tipoCaso = {};
                                vm.definicionWorkFlow = {};
                                vm.tipoDocumento = {};
                                vm.tipoResultado = {};
                                vm.listaFormatos = [];
                                //tinyMCE.activeEditor.setContent("");
                                $('#summernote').summernote('code', '');
                                vm.respuestasCasos = [];
                                vm.TCasoFormatoVariables = [];
                                vm.grupoClas = [];
                                vm.CasoUnidad = [];
                                vm.mdmForm.$setPristine();
                                vm.configuracionCasos = administracionServices.GetConsultaAdministracion(RUTAS.GetCasoConfiguracion);
                                //vm.destroyTable();
                                vm.ReshapeTable('dt-resumen');
                                //ReshapeTable('dt-resumen');
                                MostrarFormularios();
                            })
                            //MensajeRegresoServidorPagina(result, "success","../ConfiguracionCasos/CasoConfiguracion")
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                }
            );
        };




        //ACTUALIZAR
        //Cuando actualiza
        vm.GuardarRelaciones = function () {

            vm.GuardarFormatos();
            vm.GuardaRespuestas();
            vm.GuardarVariable();
        }

        //cuando actualiza
        vm.GuardarFormatos = function () {
            vm.FormatosEnDB;
            vm.listaFormatos;
            var Enviar = true;

            for (var i = 0; i < vm.listaFormatos.length; i++) {
                for (var j = 0; j < vm.FormatosEnDB.length; j++) {
                    Enviar = true;
                    if (vm.listaFormatos[i].RID === vm.FormatosEnDB[j].RID) {
                        Enviar = false;
                        break;
                        //como ya lo encontró que no haga nada :)
                    }
                }
                if (Enviar) {
                    //si no lo encontró
                    vm.EntidadAux = {};
                    vm.EntidadAux.RID = 0;
                    vm.EntidadAux.ClaveFormato = vm.listaFormatos[i].RIDFormato;
                    vm.EntidadAux.ClaveCCaso = vm.casoConfiguracion.RIDCCaso;
                    //enviar a base de datos 
                    var result = administracionServices.IngresarObjetoNegocio(RUTAS.Setrccasoformatos, vm.EntidadAux);
                }
            }

        }
        //cuando actualiza
        vm.GuardaRespuestas = function () {
            vm.RespuestasEnDB;
            vm.respuestasCasos;
            var Enviar = true;

            for (var i = 0; i < vm.respuestasCasos.length; i++) {
                Enviar = true;
                for (var j = 0; j < vm.RespuestasEnDB.length; j++) {
                    if (vm.respuestasCasos[i].RID === vm.RespuestasEnDB[j].RID) {
                        Enviar = false;
                        break;
                        //como ya lo encontró que no haga nada :)
                    }

                }
                if (Enviar) {
                    vm.EntidadAux = {};
                    vm.EntidadAux.RID = 0;
                    vm.EntidadAux.ClaveCCasoRespuesta = vm.respuestasCasos[i].RIDCCaso;
                    vm.EntidadAux.ClaveCCaso = vm.casoConfiguracion.RIDCCaso;
                    //enviar a base de datos 
                    var result = administracionServices.IngresarObjetoNegocio(RUTAS.Settcasosconfiguraciontiporespuestas, vm.EntidadAux);
                }
            }
        }
        //cuando actualiza
        vm.GuardarVariable = function () {
            vm.VariablesEnDB;
            vm.TCasoFormatoVariables;
            vm.variable;
            vm.variables;
            vm.variableSeccion;
            
            var Enviar = true;

            for (var i = 0; i < vm.TCasoFormatoVariables.length; i++) {
                Enviar = true;
                for (var j = 0; j < vm.VariablesEnDB.length; j++) {
                    // clave variable 206 y 202
                    if (vm.TCasoFormatoVariables[i].RID === vm.VariablesEnDB[j].RID) {
                        Enviar = false;
                        break;//como ya lo encontró que no haga nada :)
                    }
                }
                if (Enviar) {
                    vm.EntidadAux = {};
                    vm.EntidadAux = angular.copy(vm.TCasoFormatoVariables[i]);
                    vm.EntidadAux.RID = vm.VariablesEnDB[0].RID;
                    vm.EntidadAux.Orden = 10;
                    vm.EntidadAux.Clave = vm.casoConfiguracion.RIDCCaso;
                    vm.EntidadAux.ContenidoDefault = " ";
                    //enviar a base de datos 
                    var result = administracionServices.IngresarObjetoNegocio(RUTAS.UpdateTcasoformatovariable, vm.EntidadAux);
                }
            }
        }
        //ACTUALIZACION ELIMINADOS

        vm.EliminarCasosAgrupadorClasificadorModal = function (ClaveGrupoClas, casoConfiguracion) {
            //Delete logico de la tabla tcasos_grupoclasificacion
            //Leemos el RID de la tabla para saber que registro eliminar
            vm.entDeleteCAC.RID = ClaveGrupoClas.RID;
            //Llamamos el SP_ para eliminar
            var result = administracionServices.EliminarObjetoNegocio(RUTAS.EliminarCasosAgrupadorClasificadorModal, vm.entDeleteCAC);
            result;
            //ACTUALIZAR VARIABLE CON LA QUE SE LLENA LA  VISTA DE TABLA
            vm.grupoClas = administracionServices.GetConsultaAdministracionConParametro(RUTAS.ConsultaGrupoClas, casoConfiguracion);
        }
        vm.DropCasoUnidad = function (item, Editar) {//Delete logico de la Lista
            //quitar PERMISOS A UNIDADES ADMN
            if (Editar) {
                //Cambio de status en base de datos con el SP DeleteUnidadCCaso
                var result = administracionServices.EliminarObjetoNegocio(RUTAS.DeleteUnidadCCaso, item);
            }
            vm.CasoUnidad.splice(vm.CasoUnidad.indexOf(item), 1);
        }

        vm.EliminarFormato = function (listformato) {
            if (vm.FormatosEliminados.indexOf(listformato) < 0) { vm.FormatosEliminados.push(listformato); }
            vm.listaFormatos.splice(vm.listaFormatos.indexOf(listformato), 1);
            vm.FormatosEliminados;
        }
        vm.EliminarRespuesta = function (resp) {
            if (vm.RespuestasEliminadas.indexOf(resp) < 0) { vm.RespuestasEliminadas.push(resp); }
            vm.respuestasCasos.splice(vm.respuestasCasos.indexOf(resp), 1);
            vm.RespuestasEliminadas;
        }
        vm.EliminarVariableVw = function (varitem) {
            if (vm.VariablesEliminadas.indexOf(varitem)) { vm.VariablesEliminadas.push(varitem); }
            vm.TCasoFormatoVariables.splice(vm.TCasoFormatoVariables.indexOf(varitem), 1);
            vm.VariablesEliminadas
        }

        vm.ActualizarEliminados = function () {

            var result = [1, '', '', 'No se eliminaron formatos,variables, Respuestas ni Requisitos'];

            for (var i = 0; i < vm.FormatosEliminados.length; i++) {//recorrer lista de eliminados
                var eliminar = true;
                for (var j = 0; j < vm.listaFormatos.length; j++) {//recorrer lista actualizada
                    if (vm.FormatosEliminados[i] === vm.listaFormatos[j]) {
                        //hay un eliminado que realmente no se eliminó
                        eliminar = false;
                        break;//NADA
                    }

                }
                if (eliminar)//proceso eliminar
                {
                    result = administracionServices.EliminarObjetoNegocio(RUTAS.EliminarFormatos, vm.FormatosEliminados[i]);
                }
            }

            for (var i = 0; i < vm.VariablesEliminadas.length; i++) {
                var eliminar = true;
                for (var j = 0; j < vm.listaFormatos.length; j++) {//recorrer lista actualizada
                    if (vm.VariablesEliminadas[i] === vm.listaFormatos[j]) {
                        //hay un eliminado que realmente no se eliminó
                        eliminar = false;
                        break;//NADA
                    }
                    
                }
                if (eliminar)//proceso eliminar
                {
                    result = administracionServices.EliminarObjetoNegocio(RUTAS.EliminarVariables, vm.VariablesEliminadas[i]);
                }
            }

            for (var i = 0; i < vm.RespuestasEliminadas.length; i++) {
                var eliminar = true;
                for (var j = 0; j < vm.respuestasCasos.length; j++) {//recorrer lista actualizada
                    if (vm.RespuestasEliminadas[i] === vm.respuestasCasos[j]) {
                        //hay un eliminado que realmente no se eliminó
                        eliminar = false;
                        break;//NADA
                    }
                }
                if (eliminar)//proceso eliminar
                {
                    result = administracionServices.EliminarObjetoNegocio(RUTAS.EliminarRespuestas, vm.RespuestasEliminadas[i]);
                }
            }
            //documentos
            for (var i = 0; i < vm.AnexosEliminados.length; i++) {
                var eliminar = true;
                for (var j = 0; j < vm.tblAnexos.length; j++) {//recorrer lista actualizada
                    if (vm.AnexosEliminados[i] === vm.tblAnexos[j]) {
                        //hay un eliminado que realmente no se eliminó
                        eliminar = false;
                        break;//NADA
                    }
                }
                if (eliminar)//proceso eliminar
                {
                    result = administracionServices.EliminarObjetoNegocio(RUTAS.EliminarDocumentos, vm.AnexosEliminados[i]);
                }
            }

            return result;
        }
        vm.ActualizarCasoConfiguracion = () => {
            //Boton de Guardado al Editar un caso 
            vm.casoConfiguracion.Nombre = vm.casoConfiguracion.Nombre.toUpperCase();
            vm.casoConfiguracion.NombreInterno = vm.casoConfiguracion.NombreInterno.toUpperCase();
            vm.casoConfiguracion.NombreExterno = vm.casoConfiguracion.NombreExterno.toUpperCase();
            vm.casoConfiguracion.Descripcion = vm.casoConfiguracion.Descripcion.toUpperCase();
            vm.casoConfiguracion.DescripcionInterna = vm.casoConfiguracion.DescripcionInterna.toUpperCase();
            vm.casoConfiguracion.DescripcionExterna = vm.casoConfiguracion.DescripcionExterna.toUpperCase();
            vm.casoConfiguracion.AbreviaturaInterna = vm.casoConfiguracion.AbreviaturaInterna.toUpperCase();
            vm.casoConfiguracion.AbreviaturaExterna = vm.casoConfiguracion.AbreviaturaExterna.toUpperCase();
            vm.casoConfiguracion.Variables.ClaveTipoFormulario = 45;
            vm.casoConfiguracion.Variables.Orden = 10;
            vm.casoConfiguracion.Variables.ClaveVariable = 202;
            vm.casoConfiguracion.Variables.Required = 0;
            vm.casoConfiguracion.Variables.ContenidoDefault = ''; /////////////////// solo si esta vacio dejar como espacio, hay que revisar
            Swal.fire(
                {
                    title: "Gobierno Digital",
                    text: "¿Deseas guardar los cambios?",
                    icon: "question",
                    showCancelButton: true,
                    cancelButtonText: 'No',
                    confirmButtonText: "Si"
                }).then(function (seleccion) {
                    if (seleccion.value) {
                        //vm.casoConfiguracion.ClaveUnidadAdministrativa = vm.UnidadAdministrativa.RIDUnidadAdministrativa; 
                        var result = administracionServices.ActualizarObjetoNegocio(RUTAS.UpdateCasoConfiguracion, vm.casoConfiguracion);
                        if (!result.ExisteError) {
                            vm.GuardarUnidadAdmCCaso(true);
                            vm.InsertarRequeridos(true);
                            vm.GuardarRelaciones();
                            vm.ActualizarEliminados();

                            MensajeRegresoServidor(result,"success");
                            //$timeout(function () {
                                vm.casoConfiguracion = {};
                                vm.tipoServicio = {};
                                vm.tipoCaso = {};
                                vm.definicionWorkFlow = {};
                                vm.tipoDocumento = {};
                                vm.tipoResultado = {};
                                vm.permiterespuesta = 0;
                                vm.requiereacuse = 0;
                                vm.requierefiel = 0;
                                vm.requiereautorizacion = 0;
                                vm.TCasoFormatoVariables = [];
                                vm.grupoClas = [];
                                vm.CasoUnidad = [];
                                vm.mdmForm.$setPristine();
                                vm.configuracionCasos = administracionServices.GetConsultaAdministracion(RUTAS.GetCasoConfiguracion);
                                //vm.destroyTable();
                                vm.ReshapeTable('dt-resumen');
                                //ReshapeTable('dt-resumen');
                                MostrarFormularios();
                            //})
                        } else {
                            MensajeRegresoServidor(result, "error");
                        }
                    }
                });
        };






        //PUBLICAR
        vm.ReshapeTable = (name) => {
            $timeout(() => { reloadTableWithName(name); });
        }
        vm.Message = function () {

        }
        vm.Publicar = function (pCCasoStatus) {
            var Status = pCCasoStatus.ClaveStatusCCaso;
            var msg = '';

            if (Status === 111) { msg = '¿Estás seguro de que quieres Publicar?'; }
            else if (Status === 110) { msg = '¿Estás seguro de que quieres cambiar el Estatus "Publicado" a "No Publicado?"'; }

            Swal.fire({
                icon: 'question',
                title: "Gobierno Digital",
                text: msg,
                showConfirmButton: true,
                showCancelButton: true,
                confirmButtonText: `Aceptar`,
                cancelButtonText: `Cancelar`,
                focusCancel: true, 
                allowOutsideClick:false 

            }).then((result) =>
            {
                if (result.isConfirmed) {
                    //Valida accion
                    if (Status === 110)//Cambiar a SIN PUBLICAR
                    {
                        pCCasoStatus.ClaveStatusCCaso = 111;
                        //UpdateStatus
                        administracionServices.IngresarObjetoNegocio(RUTAS.UpdateStatusCConfiguracion, pCCasoStatus);
                    }
                    else if (Status === 111) //PUBLICAR
                    {
                        pCCasoStatus.ClaveStatusCCaso = 110;
                        //UpdateStatus
                        administracionServices.IngresarObjetoNegocio(RUTAS.UpdateStatusCConfiguracion, pCCasoStatus);
                    }
                    
                    Swal.fire({
                        icon: 'success',
                        title: 'Gobierno Digital',
                        text: 'Actualizado.',
                        allowOutsideClick: false
                    }).then((result) => {
                        if (result.isConfirmed) {
                            //ACTUALIZAR VARIABLE CON LA QUE SE LLENA LA  VISTA DE TABLA
                            vm.configuracionCasos = administracionServices.GetConsultaAdministracion(RUTAS.GetCasoConfiguracion);
                            //vm.destroyTable();
                            vm.ReshapeTable('dt-resumen');
                            //ReshapeTable('dt-resumen');
                        }
                    })
                }
                else if (result.isDenied)
                {
                    Swal.fire('Gobierno Digital', 'No se realizó ningún cambio.', 'info')
                }
            })   
        }
    }]
)

