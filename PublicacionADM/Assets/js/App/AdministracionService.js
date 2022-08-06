administracionServices.factory("administracionServices", ["$http", "$window",
    function ($http, $window) {
        return {
            GetConsultaAdministracion: function (urlConsulta) {
                var result = null;
                $.ajax({
                    type: "GET",
                    url: urlConsulta,
                    contentType: "application/json;charset=utf-8",
                    async: false,
                    dataType: "json",
                    beforeSend: function () {
                        IniciarSpinner();
                    },
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    },
                    complete: function () {
                        DetenerSpinner();
                    },
                });
                return result;
            },
            GetConsultaAdministracionConParametro: function (urlConsulta, objecto) {
                var result = null;
                $.ajax({
                    type: "POST",
                    url: urlConsulta,
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify({
                        objetoNegocio: objecto
                    }),
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });
                return result;
            },
            EliminarObjetoNegocio: function (urlConsulta, objecto) {
                var result = null;
                $.ajax({
                    type: "POST",
                    url: urlConsulta,
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify({
                        objetoNegocio: objecto
                    }),
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });
                return result;
            },
            ActualizarObjetoNegocio: function (urlConsulta, objecto) {
                var result = null;
                $.ajax({
                    type: "POST",
                    url: urlConsulta,
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify({
                        objetoNegocio: objecto
                    }),
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });
                return result;
            },
            IngresarObjetoNegocio: function (urlIngresar, objecto) {
                var result = null;
                $.ajax({
                    type: "POST",
                    url: urlIngresar,
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify({
                        objetoNegocio: objecto
                    }),
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });
                return result;
            },

            ObtenerOrganigrama: function (urlIngresar, objecto) {
                var result = null;
                $.ajax({
                    type: "POST",
                    url: urlIngresar,
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify({
                        objetoNegocio: objecto
                    }),
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });
                return result;
            },

            GetConfiguracionARC: function (urlIngresar, data) {
                var result = null;
                $.ajax({
                    type: "POST",
                    url: urlIngresar,
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(data),
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        console.log(errordata.responseText);
                    }
                });
                return result;
            },

            MetodPOST: function (urlIngresar, objecto) {
                var tkn = JSON.parse(sessionStorage["ngStorage-GlobalSettings"]).Acceso.Token;
                var result = null;
                $.ajax({
                    method: 'POST',
                    url: urlIngresar,
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(objecto),
                    async: false,
                    dataType: 'json',
                    headers: { Authorization: "Bearer " + tkn },
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });
                return result;
            },          
        }
    }
])

