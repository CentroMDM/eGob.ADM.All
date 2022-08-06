
function MostrarFormularios() {
    var x = document.getElementById("nuevoFormulario");
    var y = document.getElementById("tablaInicial");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
    if (y.style.display === "none") {
        y.style.display = "block";
    } else {
        y.style.display = "none";
    }
}

var isMobile = {
    Android: function () {
        return navigator.userAgent.match(/Android/i);
    },
    BlackBerry: function () {
        return navigator.userAgent.match(/BlackBerry/i);
    },
    iOS: function () {
        return navigator.userAgent.match(/iPhone|iPad|iPod/i);
    },
    Opera: function () {
        return navigator.userAgent.match(/Opera Mini/i);
    },
    Windows: function () {
        return navigator.userAgent.match(/IEMobile/i);
    },
    any: function () {
        return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
    }
};

function MensajeRegresoServidor(result, icon) {
    if (!result.ExisteError) { result = "La información se almacenó correctamente"; }
    else { result = "No se ha podido actualizar la información"; }

    Swal.fire({
        title: result,
        text: result.DetalleErrorSql,
        icon: icon,
        allowOutsideClick: false
    }).then(function (seleccion) {
        if (seleccion.value) {
            location.reload();
        }
    });
}

function MensajeRegresoServidorPagina(result, icon, page) {
    Swal.fire({
        title: result.Mensaje,
        text: result.DetalleErrorSql,
        icon: icon,
        allowOutsideClick: false
    }).then(function (seleccion) {
        if (seleccion.value) {
            //setTimeout(window.open("../Home/Index", "_self"), 8000);//abre la ruta en la misma pestaña con un retraso de 8 seg
            window.open(page, "_self");//abre la ruta en la misma pestaña
        }
    });
}
function MensajeGeneral(text, icon) {
    Swal.fire({
        title: "Gobierno Digital",
        text: text,
        icon: icon
    });
}

function MensajeGeneralFocus(text, icon, IDFocus) {
    Swal.fire({
        title: "Gobierno Digital",
        text: text,
        icon: icon,
        allowOutsideClick: false
    }).then((result) => {
        if (result.isConfirmed) {
            return $('html, body').animate({ scrollTop: $("#" + IDFocus).offset().top }, 150);
        }
    });
}

function MensajeEventoElemento(text, opcion) {
    if (opcion == 1)
        toastr.success(text, "Gobierno Digital");
    if (opcion == 2)
        toastr.error(text, "Gobierno Digital");
}

function FormatearFecha(fechaInicial) {
    var fecha = new Date(fechaInicial);
    var meses = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre");
    var texto = "";
    texto = fecha.getDate() + " de " + meses[fecha.getMonth()] + " del " + fecha.getFullYear();
    return texto;
}

function Trim(x) {
    return x.replace(/^\s+|\s+$/gm, '');
}

function MostrarListado() {
    location.reload();
}

function convertDateFormatDMY(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(parseInt(inputFormat.replace("/Date(", "").replace(")/", ""), 10))
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/')
}

const IniciarSpinner = () => {
    $('body').loadingModal({
        position: 'auto',
        text: '',
        color: '#fff',
        opacity: '0.7',
        backgroundColor: 'rgb(0,0,0)',
        animation: 'circle'
    });
}

const DetenerSpinner = () => {
    $('body').loadingModal('hide');
}

const IniciarTrim = () => {
    if (!String.prototype.trim) {
        (function () {
            // Make sure we trim BOM and NBSP
            console.log("Iniciando funciones prototype");
            var rtrim = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;
            String.prototype.trim = function () {
                return this.replace(rtrim, '');
            };
        })();
    }
}


const IniciarAddDays = () => {
    Date.prototype.addDays = function (days) {
        var date = new Date(this.valueOf());
        date.setDate(date.getDate() + days);
        return date;
    }
}

const fromDateToString = (fechaInicio) => {
    var date = fechaInicio.toJSON().slice(0, 10);
    var nDate = date.slice(8, 10) + '/'
        + date.slice(5, 7) + '/'
        + date.slice(0, 4);
    return nDate;
}

const stringToDate = (_date, _format, _delimiter) => {
    var formatLowerCase = _format.toLowerCase();
    var formatItems = formatLowerCase.split(_delimiter);
    var dateItems = _date.split(_delimiter);
    var monthIndex = formatItems.indexOf("mm");
    var dayIndex = formatItems.indexOf("dd");
    var yearIndex = formatItems.indexOf("yyyy");
    var month = parseInt(dateItems[monthIndex]);
    month -= 1;
    var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
    return formatedDate;
}

const compareDates = (strDateInitial, strDateFinal) => {
    //let inicial = stringToDate(strDateInitial, "dd/MM/yyyy", "/");
    //let final = stringToDate(strDateFinal, "dd/MM/yyyy", "/");
    //if (inicial < final)
    //    return false;
    //return true;
    let inicial = stringToDate(strDateInitial, "dd/MM/yyyy", "/");
    let final = stringToDate(strDateFinal, "dd/MM/yyyy", "/");
    if (inicial.getTime() === final.getTime())
        return false;
    else if (inicial.getTime() < final.getTime())
        return false;
    return true;
}

const destroyTable = () => {
    $('.tablaPSRPrincipal').DataTable().clear().destroy();
}

ReshapeTable = (name) => {
    reloadTableWithName(name);
}

const reloadTable = () => {
    $('.tablaPSRPrincipal').dataTable(
        {
            responsive: true,
            lengthChange: false,
            language: {
                search: '<div class=" d-inline-flex width-5 align-items-center justify-content-center border-bottom-right-radius-0 border-top-right-radius-0 border-right-0"><i class="fal fa-search"></i></div>',
                searchPlaceholder: "Buscar",
                /*pageLength = 10,*/
                paginate: {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Previo"
                },
                emptyTable: "Sin registros disponibles",
                zeroRecords: "No se encuentra",
                //info: "Mostrando _START_ - _END_ (Total: _TOTAL_ registros)",
                info: "Registros: _TOTAL_ ",
                infoEmpty: " ",
                infoFiltered: " (Filtrado de _MAX_ totales)"
            },
            "columnDefs": [
                { "className": "dt-center", "targets": "_all" },
                { "targets": ['no-sort', 'not-export-col'], "orderable": false },
                {
                    "targets": "sortdate",
                    "render": "$.fn.dataTable.render.moment('YYYY/MM/DD')"
                }
            ],
            "aoColumnDefs": [
                {
                    "bSortable": false,
                    "aTargets": ['no-sort', 'not-export-col'] // <-- gets last column and turns off sorting
                }
            ],
            dom:
                "<'row mb-3'<'col-sm-12 col-md-6 d-flex align-items-center justify-content-start'f><'col-sm-12 col-md-6 d-flex align-items-center justify-content-end'lB>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            buttons: [
                {
                    bom: true,
                    extend: 'excelHtml5',
                    text: 'Excel',
                    titleAttr: 'Generate Excel',
                    className: 'btn btn-info btn-sm mr-1',
                    exportOptions: {
                        columns: ':visible:not(.not-export-col)'
                    }
                },
                {
                    bom: true,
                    extend: 'csvHtml5',
                    text: 'CSV',
                    titleAttr: 'Generate CSV',
                    className: 'btn btn-info btn-sm mr-1',
                    exportOptions: {
                        columns: ':visible:not(.not-export-col)'
                    }
                }
            ]
        });
}

const destroyTableWithName = (nombre) => {
    let nombreTabla = '.' + nombre;
    $(nombreTabla).DataTable().clear().destroy();
}

const reloadTableWithName = (nombre) => {
    let nombreTabla = '.' + nombre;
    $(nombreTabla).DataTable(
        {
            responsive: true,
            lengthChange: false,
            language: {
                search: '<div class=" d-inline-flex width-5 align-items-center justify-content-center border-bottom-right-radius-0 border-top-right-radius-0 border-right-0"><i class="fal fa-search"></i></div>',
                searchPlaceholder: "Buscar",
                /*pageLength = 10,*/
                paginate: {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Previo"
                },
                emptyTable: " ",
                zeroRecords: "No se encuentra",
                info: "Mostrando  [ _START_ - _END_ ]     Registros: _TOTAL_ ",
                //info: "Registros: _TOTAL_ ",
                infoEmpty: "Sin registros disponibles",
                infoFiltered: " (Filtrado de _MAX_ totales)",
                processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Cargando...</span> '
            },
            "processing": true,
            "columnDefs": [
                { "className": "dt-center", "targets": "_all" },
                { "targets": ['no-sort', 'not-export-col'], "orderable": false, "searchable": false },
                {
                    "targets": "sortdate",
                    "render": "$.fn.dataTable.render.moment('YYYY/MM/DD')"
                },
            ],
            "aoColumnDefs": [
                {
                    "bSortable": false,
                    "aTargets": ['no-sort', 'not-export-col'] // <-- gets last column and turns off sorting
                }
            ],
            dom:
                "<'row mb-3'<'col-sm-12 col-md-6 d-flex align-items-center justify-content-start'f><'col-sm-12 col-md-6 d-flex align-items-center justify-content-end'lB>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            buttons: [
                {
                    bom: true,
                    extend: 'excelHtml5',
                    text: 'Excel',
                    titleAttr: 'Generate Excel',
                    className: 'btn btn-info btn-sm mr-1',
                    exportOptions: {
                        columns: ':visible:not(.not-export-col)'
                    }
                },
                {
                    bom: true,
                    extend: 'csvHtml5',
                    text: 'CSV',
                    titleAttr: 'Generate CSV',
                    className: 'btn btn-info btn-sm mr-1',
                    exportOptions: {
                        columns: ':visible:not(.not-export-col)'
                    }
                }
            ]
        });
}

const TipoAuditoria = Object.freeze({
    "USUARIO": 70,
    "APLICACION" : 71
})

const CatalogoMenu = Object.freeze({
    "IMPLEMENTACION": "Implementacion",
    "DIAS_HABILES": "Dias habiles",
    "NIVELES_DE_MANDO": "Niveles de mando",
    "PUESTOS_INSTITUCIONALES": "Puestos institucionales",
    "EMPLEADOS": "Empleados",
    "UNIDADES_ADMINISTRATIVAS": "Unidades administrativas",
    "USUARIOS": "Usuarios",
    "GRUPOS_DE_ATENCION": "Grupos de atencion",
    "SERVICIOS": "Servicios",
    "TIPOS_DE_DOCUMENTOS": "Tipos de documentos",
    "VARIABLES": "Variables",
    "FORMATOS": "Formatos",
    "FLUJOS_DE_TRABAJO": "Flujos de trabajo",
    "CASOS": "Casos",
    "ADMINISTRACION": "Administracion",
    "AUDITORIA": "Auditoria"
})
