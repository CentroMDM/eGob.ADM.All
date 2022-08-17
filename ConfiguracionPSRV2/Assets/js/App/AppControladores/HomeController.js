HomeController.controller("crtlHome", ["$scope", "$timeout", "administracionServices", "$http", "$sessionStorage",  "$rootScope",
    function (vm = $scope, $timeout, administracionServices, $http, $sessionStorage, vg = $rootScope) {
        const ctr = Administracion["HomeController"];

        //const Srv = 'https://edomex.e-gob.app/';
        //const Srv = 'https://demo-3af0.e-gob.app/';
        //const Srv = 'https://edomex.qa-psr-mx.com/';
        //const Srv = 'https://sitec.qa-psr-mx.com/';
        //const Srv = 'https://edomex.qa-psr-mx.com/';
        const Srv = 'https://edomex.serviciosweb.mx:84/';
        //const Srv = 'https://slpm.d-gob.app/';
        const Autorizacion = Srv + 'autorizacion';

        var tknTemp = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjUiLCJuYmYiOjE2NjA1NzgwNzgsImV4cCI6MTY2MDkzODA3OCwiaWF0IjoxNjYwNTc4MDc4LCJpc3MiOiJodHRwczovL2UtZ29iLmFwcC8iLCJhdWQiOiJodHRwczovL2UtZ29iLmFwcC8ifQ.rr0Ihnb4lScaiNr_2yyNf5WIDBkdgD9D5-nkUkNn1hw";
        ////var SetSession = "{\"Usuario\":{\"RIDUsuario\":2126,\"RIDEmpleado\":2124,\"Nombre\":\"Viviana\",\"APaterno\":\"Mendoza\",\"AMaterno\":\"Hernández\",\"NombreCompleto\":\"Viviana Mendoza Hernández\",\"ClaveDirectorioFoto\":0,\"DirectorioSecundarioFoto\":null,\"FullPathFoto\":\"\",\"ClavePuesto\":0,\"NombrePuesto\":\"Subdirectora de Control de Obligaciones\",\"NombreUnidadAdministrativa\":null,\"FechaInicio\":null,\"ClaveStatus\":0,\"FechsStatus\":null,\"FechaFin\":null},\"Acceso\":{\"DireccionIP\":null,\"SID\":null,\"Token\":\"" + tknTemp + "\"},\"AppSelectSettings\":{},\"AppSettings\":{\"RIDImplementacion\":200000000001,\"GUIDImplementacion\":\"AFCBF41F-F763-11EA-91B2-503EAAB753B5\",\"Nombre\":\"Gobierno del Estado de México.\",\"Lema\":null,\"NombreTema\":\"Tapestry\",\"ModoTema\":\"Default\",\"ThemeSettings\":{\"themeOptions\":\"\",\"themeURL\":\"\"},\"FullPathLogoImplementacion\":\"../ExResources/Img/LogoEntidad/c4d520a6-78f9-40ce-ac29-c487d0442b9f.svg\",\"NombreAbreviado\":\"Gob EDOMEX\",\"HorarioInicioLaboral\":null,\"HorarioFinLaboral\":null,\"ClaveEstado\":0,\"ClaveMunicipio\":0,\"CodigoPostal\":null,\"CP\":null,\"Calle\":null,\"NumExt\":null,\"NumInt\":null,\"FechaInicio\":\"/Date(1623301200000)/\",\"FechaStatus\":\"/Date(1624652556000)/\",\"ClaveStatus\":1,\"FechaFin\":\"/Date(1623301200000)/\"},\"ListApps\":[{\"RIDUnidadAdministrativa\":213,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Ecatepec\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":213,\"NombreBuzon\":\"SIAT.ECATEPEC\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":214,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Naucalpan\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":214,\"NombreBuzon\":\"SIAT.NAUCALPAN\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":215,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Nezahualcóyotl\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":215,\"NombreBuzon\":\"SIAT.NEZAHUALCÓYOTL\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":216,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Tlalnepantla\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":216,\"NombreBuzon\":\"SIAT.TLALNEPANTLA\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":217,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Toluca\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/7449c1e1-1114-4a81-b16e-25c3c60403b6.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":217,\"NombreBuzon\":\"SIAT.TOLUCA\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/7449c1e1-1114-4a81-b16e-25c3c60403b6.svg\"}]}],\"ListBuzones\":[{\"RIDUnidadAdministrativa\":213,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Ecatepec\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":213,\"NombreBuzon\":\"SIAT.ECATEPEC\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":214,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Naucalpan\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":214,\"NombreBuzon\":\"SIAT.NAUCALPAN\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":215,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Nezahualcóyotl\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":215,\"NombreBuzon\":\"SIAT.NEZAHUALCÓYOTL\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":216,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Tlalnepantla\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":216,\"NombreBuzon\":\"SIAT.TLALNEPANTLA\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":217,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Toluca\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/7449c1e1-1114-4a81-b16e-25c3c60403b6.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":217,\"NombreBuzon\":\"SIAT.TOLUCA\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://localhost:44362/\",\"URLAccesoApp\":\"https://localhost:44362/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/7449c1e1-1114-4a81-b16e-25c3c60403b6.svg\"}]}]}";
        ////var SetSession = "{\"Usuario\":{\"RIDEmpleado\":211,\"RIDUsuario\":2130,\"Nombre\":\"Usuario\",\"APaterno\":\"De\",\"AMaterno\":\"Prueba\",\"NombreCompleto\":\"Usuario De Prueba\",\"ClaveDirectorioFoto\":0,\"DirectorioSecundarioFoto\":null,\"FullPathFoto\":\"C: \\inetpub\\wwwroot\\PSRv2\\EDOMEX\\ExResources\\Img\\FotografiaUsuarios\\e156e31f - bc6b - 40cc - b832 - dd0899cea31d.png\",\"ClavePuesto\":0,\"NombrePuesto\":\"Director General de Recaudación\",\"NombreUnidadAdministrativa\":null,\"FechaInicio\":null,\"ClaveStatus\":0,\"FechsStatus\":null,\"FechaFin\":null},\"Acceso\":{\"DireccionIP\":null,\"SID\":null,\"Token\":\"" + tknTemp + "\"},\"AppSelectSettings\":{},\"AppSettings\":{\"RIDImplementacion\":200000000001,\"GUIDImplementacion\":\"AFCBF41F - F763 - 11EA - 91B2 - 503EAAB753B5\",\"Nombre\":\"Gobierno del Estado de México.\",\"Lema\":null,\"NombreTema\":\"Tapestry\",\"ModoTema\":\"Default\",\"ThemeSettings\":{\"themeOptions\":\"\",\"themeURL\":\"\\assets\\template\\css\\themes\\cust-theme-1.css\"},\"FullPathLogoImplementacion\":\"../ExResources/ Img / LogoEntidad / c4d520a6 - 78f9 - 40ce - ac29 - c487d0442b9f.svg\",\"NombreAbreviado\":\"Gob EDOMEX\", \"HorarioInicioLaboral\":null,\"HorarioFinLaboral\":null,\"ClaveEstado\":0,\"ClaveMunicipio\":0,\"CodigoPostal\":null,\"CP\":null,\"Calle\":null,\"NumExt\":null,\"NumInt\":null,\"FechaInicio\":\" / Date(1623301200000) / \",\"FechaStatus\":\" / Date(1624652556000) / \",\"ClaveStatus\":1,\"FechaFin\":\" / Date(1623301200000) / \"},\"ListApps\":[{\"RIDUnidadAdministrativa\":211,\"NombreUnidadAdministrativa\":\"Dirección General de Recaudación\",\"FullPathLogoUA\":\"../ ExResources / Img / LogoUnidadesAdministrativas / 3222ef8d - ad57 - 49da - bfd8 - c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":219,\"NombreBuzon\":\"SIGED\",\"TipoBuzon\":\"Sistema para la generación de documentos\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siged/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siged/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"},{\"RIDBuzon\":2110,\"NombreBuzon\":\"ADM\",\"TipoBuzon\":\"Sistema de administración de la plataforma\",\"URLAcceso\":\"https://localhost:44397/\",\"URLAccesoApp\":\"https://localhost:44397/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":213,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Ecatepec\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":213,\"NombreBuzon\":\"SIAT.ECATEPEC\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":214,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Naucalpan\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":214,\"NombreBuzon\":\"SIAT.NAUCALPAN\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":215,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Nezahualcóyotl\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":215,\"NombreBuzon\":\"SIAT.NEZAHUALCÓYOTL\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":216,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Tlalnepantla\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":216,\"NombreBuzon\":\"SIAT.TLALNEPANTLA\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":217,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Toluca\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/7449c1e1-1114-4a81-b16e-25c3c60403b6.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":217,\"NombreBuzon\":\"SIAT.TOLUCA\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/7449c1e1-1114-4a81-b16e-25c3c60403b6.svg\"}]}],\"ListBuzones\":[{\"RIDUnidadAdministrativa\":211,\"NombreUnidadAdministrativa\":\"Dirección General de Recaudación\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":219,\"NombreBuzon\":\"SIGED\",\"TipoBuzon\":\"Sistema para la generación de documentos\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siged/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siged/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"},{\"RIDBuzon\":2110,\"NombreBuzon\":\"ADM\",\"TipoBuzon\":\"Sistema de administración de la plataforma\",\"URLAcceso\":\"https://localhost:44397/\",\"URLAccesoApp\":\"https://localhost:44397/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":213,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Ecatepec\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":213,\"NombreBuzon\":\"SIAT.ECATEPEC\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":214,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Naucalpan\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":214,\"NombreBuzon\":\"SIAT.NAUCALPAN\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":215,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Nezahualcóyotl\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":215,\"NombreBuzon\":\"SIAT.NEZAHUALCÓYOTL\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":216,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Tlalnepantla\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":216,\"NombreBuzon\":\"SIAT.TLALNEPANTLA\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]},{\"RIDUnidadAdministrativa\":217,\"NombreUnidadAdministrativa\":\"Delegación Fiscal Toluca\",\"FullPathLogoUA\":\"../ExResources/Img/LogoUnidadesAdministrativas/7449c1e1-1114-4a81-b16e-25c3c60403b6.svg\",\"ListadoBuzones\":[{\"RIDBuzon\":217,\"NombreBuzon\":\"SIAT.TOLUCA\",\"TipoBuzon\":\"Sistema de atención de trámites\",\"URLAcceso\":\"https://edomex.qa-psr-mx.com/siat/\",\"URLAccesoApp\":\"https://edomex.qa-psr-mx.com/siat/Inicio/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/7449c1e1-1114-4a81-b16e-25c3c60403b6.svg\"}]}],\"AppBuzonSettings\":{\"RIDBuzon\":2110,\"NombreBuzon\":\"ADM\",\"TipoBuzon\":\"Sistema de administración de la plataforma\",\"URLAcceso\":\"https://localhost:44397/\",\"URLAccesoApp\":\"https://localhost:44397/\",\"FullPathLogoBuzon\":\"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}}";
        var SetSession = "{\"Usuario\": { \"RIDEmpleado\": 211, \"RIDUsuario\": 2130, \"Nombre\": \"Roberto Alejandro\", \"APaterno\": \"Guzmán\", \"AMaterno\": \"Cariño\", \"NombreCompleto\": \"Roberto Alejandro Guzmán Cariño\", \"ClaveDirectorioFoto\": 0, \"DirectorioSecundarioFoto\": null, \"FullPathFoto\": \"C:\\\\inetpub\\\\wwwroot\\\\PSRv2\\\\EDOMEX\\\\ExResources\\\\Img\\\\FotografiaUsuarios\\\\e156e31f-bc6b-40cc-b832-dd0899cea31d.png\", \"ClavePuesto\": 0, \"NombrePuesto\": \"Director General de Recaudación\", \"NombreUnidadAdministrativa\": null, \"FechaInicio\": null, \"ClaveStatus\": 0, \"FechsStatus\": null, \"FechaFin\": null     },     \"Acceso\": { \"DireccionIP\": null, \"SID\": null, \"Token\":\"" + tknTemp + "\"     },     \"AppSelectSettings\": {},     \"AppSettings\": { \"RIDImplementacion\": 200000000001, \"GUIDImplementacion\": \"AFCBF41F-F763-11EA-91B2-503EAAB753B5\", \"Nombre\": \"Gobierno del Estado de México.\", \"Lema\": null, \"NombreTema\": \"Tapestry\", \"ModoTema\": \"Default\", \"ThemeSettings\": {     \"themeOptions\": \"\",     \"themeURL\": \"\\\\assets\\\\template\\\\css\\\\themes\\\\cust-theme-1.css\" }, \"FullPathLogoImplementacion\": \"../ExResources/Img/LogoEntidad/c4d520a6-78f9-40ce-ac29-c487d0442b9f.svg\", \"NombreAbreviado\": \"Gob EDOMEX\", \"HorarioInicioLaboral\": null, \"HorarioFinLaboral\": null, \"ClaveEstado\": 0, \"ClaveMunicipio\": 0, \"CodigoPostal\": null, \"CP\": null, \"Calle\": null, \"NumExt\": null, \"NumInt\": null, \"FechaInicio\": \"/Date(1623301200000)/\", \"FechaStatus\": \"/Date(1624652556000)/\", \"ClaveStatus\": 1, \"FechaFin\": \"/Date(1623301200000)/\"     },     \"ListApps\": [ {     \"RIDUnidadAdministrativa\": 211,     \"NombreUnidadAdministrativa\": \"Dirección General de Recaudación\",     \"FullPathLogoUA\": \"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\",     \"ListadoBuzones\": [{\"RIDBuzon\": 213,\"NombreBuzon\": \"SIAT.ECATEPEC\",\"TipoBuzon\": \"Sistema de atención de trámites\",\"URLAcceso\": \"https://localhost:44397/\",\"URLAccesoApp\": \"https://localhost:44397/\",\"FullPathLogoBuzon\": \"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"}]}],\"AppBuzonSettings\": { \"RIDBuzon\": 213, \"NombreBuzon\": \"SIAT.ECATEPEC\", \"TipoBuzon\": \"Sistema de atención de trámites\", \"URLAcceso\": \"https://localhost:44397/\", \"URLAccesoApp\": \"https://localhost:44397/\", \"FullPathLogoBuzon\": \"../ExResources/Img/LogoUnidadesAdministrativas/3222ef8d-ad57-49da-bfd8-c2b48b5017ab.svg\"     } }";
        ////console.info(SetSession);
        ///*$localStorage.Conf_.Menu*/
        $sessionStorage.GlobalSettings = JSON.parse(SetSession);

        if (($sessionStorage.GlobalSettings === undefined) || ($sessionStorage.GlobalSettings === null)) {
            window.location.href = Autorizacion;
            return;
        } else {
            vm.GCLS = $sessionStorage.GlobalSettings;
            if ((vm.GCLS.Usuario == undefined) || (vm.GCLS.Usuario == '') || (vm.GCLS.Usuario == null)) {
                window.location.href = Autorizacion;
                return;
            }
            if ((vm.GCLS.AppBuzonSettings == undefined) || (vm.GCLS.AppBuzonSettings == '') || (vm.GCLS.AppBuzonSettings == null)) {
                window.location.href = Autorizacion;
                return;
            }
        }
         vm.LogOut = function () {
            delete $sessionStorage.GlobalSettings;
            $http.defaults.headers.common.Authorization = null;
            window.location.href = Autorizacion;
        }

        const configuracion = {
            APP: "",
            Sist: "",
            Nombre: "",
            User: "",
            UA: "",
            ImagenHome: "",
            LogoApp: "",
            LogoInst: "",
            Menu: "",
            ModoTema: "",
            themeOptions: "",
            NombreTema: "",
            themeURL: ""
        }; const Conf_ = Object.create(configuracion);

        vg.Angular = "::: Angular funcionando :::         ";
        vm.ConfImp = administracionServices.GetConsultaAdministracion(ctr.GetConfigImp);
        vm.Imp = administracionServices.MetodPOST(ctr.GetImp);
        vm.ConfBuz = administracionServices.GetConsultaAdministracion(ctr.GetConfig)[0];
        //vm.ImagenHome = '../Assets/img/edomex.png';      

        Conf_.APP = vg.APP = $sessionStorage.GlobalSettings.AppBuzonSettings.TipoBuzon;
        Conf_.Sist = vg.Sistema = $sessionStorage.GlobalSettings.AppBuzonSettings.TipoBuzon;
        Conf_.Nombre = vg.Nombre = $sessionStorage.GlobalSettings.AppSettings.Nombre;

        Conf_.ImagenHome = vg.ImagenHome = vm.ConfBuz.DirectorioImagenesVirtualHome + vm.ConfBuz.DirectorioSecundarioImagenHome;
        Conf_.LogoApp = vg.LogoApp = vm.ConfBuz.DirectorioImagenesVirtualApp + vm.ConfBuz.DirectorioSecundarioLogoApp;
        Conf_.LogoInst = vg.LogoInst = vm.ConfBuz.DirectorioImagenesVirtualLogo + vm.ConfBuz.DirectorioSecundarioLogo;

        Conf_.User = vg.User = $sessionStorage.GlobalSettings.Usuario.NombreCompleto;
        Conf_.UA = vg.UA = $sessionStorage.GlobalSettings.Usuario.NombrePuesto;

        Conf_.ModoTema = $sessionStorage.GlobalSettings.AppSettings.ModoTema;
        Conf_.NombreTema = $sessionStorage.GlobalSettings.AppSettings.NombreTema;

        var param = {
            ClaveUsuario: 2130, //$sessionStorage.GlobalSettings.Usuario.RIDUsuario,
            ClaveAplicacion: 213,
            ClaveBuzon: 213 //$sessionStorage.GlobalSettings.AppBuzonSettings.RIDBuzon
        };
        //#region pruebaMenu
        //Conf_.Menu = vg.MenuIzq = administracionServices.GetConfiguracionARC(ctr.GetConfiguracionARC, param);
        vg.MenuIzq =
            [
                {
                    "DireccionURL": "#",
                    "Menu": "Configuración",
                    "ListSubMenu": [
                        {
                            "DireccionURL": subdirectorio + "/Configuracion/Implementacion",
                            "SubMenu": "Implementacion",
                        },
                        {
                            "DireccionURL": subdirectorio + "/Configuracion/DiasInhabiles",
                            "SubMenu": "Dias inhábiles",
                        }
                    ]
                },
                {
                    "DireccionURL": "#",
                    "Menu": "Buzón fiscal",
                    "ListSubMenu": [
                        {
                            "DireccionURL": subdirectorio + "/BuzonFiscal/ConfiguracionBuzonFiscal",
                            "SubMenu": "Configuración",
                        }
                    ]
                },
                {
                    "DireccionURL": subdirectorio + "/Clasificadores/Clasificadores",
                    "Menu": "Clasificadores",
                    "ListSubMenu": []
                },
                {
                    "DireccionURL": "#",
                    "Menu": "Estructura organizacional",
                    "ListSubMenu": [
                        {
                            "DireccionURL": subdirectorio + "/EstructuraOrganizacional/NivelesDeMando",
                            "SubMenu": "Niveles de puesto",
                        },
                        {
                            "DireccionURL": subdirectorio + "/EstructuraOrganizacional/PuestosInstitucionales",
                            "SubMenu": "Puestos institucionales",
                        },
                        {
                            "DireccionURL": subdirectorio + "/EstructuraOrganizacional/Empleados",
                            "SubMenu": "Registro de empleados",
                        },
                        {
                            "DireccionURL": subdirectorio + "/EstructuraOrganizacional/UnidadAdministrativa",
                            "SubMenu": "Unidades administrativas",
                        },
                        {
                            "DireccionURL": subdirectorio + "/EstructuraOrganizacional/Usuarios",
                            "SubMenu": "Registro de usuarios",
                        },
                        {
                            "DireccionURL": subdirectorio + "/EstructuraOrganizacional/DesbloqueoDeCuenta",
                            "SubMenu": "Desbloqueo de cuenta",
                        },
                        {
                            "DireccionURL": subdirectorio + "/EstructuraOrganizacional/GruposAtencion",
                            "SubMenu": "Grupos de atención",
                        },
                    ]
                },
                {
                    "DireccionURL": "#",
                    "Menu": "Configuración de roles",
                    "ListSubMenu": [
                        {
                            "DireccionURL": subdirectorio + "/ConfiguracionRoles/RolesPorNivelDeMando",
                            "SubMenu": "Relación Nivel Puesto - Roles ",
                        },
                        {
                            "DireccionURL": subdirectorio + "/ConfiguracionRoles/ModulosYCaracteristicas",
                            "SubMenu": "Relación Módulos - Roles",
                        },
                    ]
                },
                {
                    "DireccionURL": "#",
                    "Menu": "Casos",
                    "ListSubMenu": [
                        {
                            "DireccionURL": subdirectorio + "/ConfiguracionCasos/TipoServicios",
                            "SubMenu": "Catálogo de servicios",
                        },
                        {
                            "DireccionURL": subdirectorio + "/ConfiguracionCasos/TipoDocumento",
                            "SubMenu": "Tipo de documentos",
                        },
                        {
                            "DireccionURL": subdirectorio + "/VariablesConfiguracion/VariablesConfiguracion",
                            "SubMenu": "Variables",
                        },
                        {
                            "DireccionURL": subdirectorio + "/ConfiguracionCasos/CasoConfiguracionFormatos",
                            "SubMenu": "Formatos y secciones",
                        },
                        {
                            "DireccionURL": subdirectorio + "/WorkFlow/Definicion",
                            "SubMenu": "Flujos de trabajo",
                        },
                        {
                            "DireccionURL": subdirectorio + "/ConfiguracionCasos/CasoConfiguracion",
                            "SubMenu": "Configuración de casos",
                        }
                    ]
                },
                {
                    "DireccionURL": "#",
                    "Menu": "Aplicaciones",
                    "ListSubMenu": [
                        {
                            "DireccionURL": subdirectorio + "/Aplicaciones/Administracion",
                            "SubMenu": "Administración",
                        }
                    ]
                },
                {
                    "DireccionURL": subdirectorio + "/PistasDeAuditoria/PistasDeAuditoria",
                    "Menu": "Pistas de auditoria",
                    "ListSubMenu": []
                }
            ];
        // #endregion

        const themeSetts = {
            themeOptions: "",
            themeURL: ""
        }; let themeDef = Object.create(themeSetts);
        themeDef.themeOptions = "mod-bg-1 mod-nav-link mod-skin-light";
        themeDef.themeURL = "";

        if (localStorage.getItem("themeSettings")===null) {
            localStorage.setItem("themeSettings", JSON.stringify(themeDef));
        }

        let themS = JSON.parse(localStorage.getItem("themeSettings"));

        var THOP = "";var THURL = "";
        switch (vm.ConfImp.ModoTema) {
            case "Oscuro":THOP = "mod-bg-1 mod-nav-link mod-skin-dark";break;
            case "Claro":THOP = "mod-bg-1 mod-nav-link mod-skin-light";break;
            default:THOP = "mod-bg-1 mod-nav-link";}
        if (vm.ConfImp.NombreTema == "Wisteria"){THURL = " ";}
        else {switch (vm.ConfImp.NombreTema){
            case 'Blue Smoke': THURL = "/adm/Assets/css/cust-theme-10.css";break;
            case 'Oslo Gray': THURL = "/adm/Assets/css/cust-theme-7.css"; break;
            case 'Tapestry': THURL = "/adm/Assets/css/cust-theme-1.css"; break;
            case 'Dodger Blue':THURL = "/adm/Assets/css/cust-theme-4.css"; break;
            case 'Emerald':  THURL = "/adm/Assets/css/cust-theme-13.css"; break;
            case 'Atlantis':  THURL = "/adm/Assets/css/cust-theme-2.css"; break;
            case 'Supernova': THURL = "/adm/Assets/css/cust-theme-14.css"; break;
            case 'Apricot': THURL = "/adm/Assets/css/cust-theme-9.css"; break;
            case 'Cranberry': THURL = "/adm/Assets/css/cust-theme-6.css"; break;
            //case 'Cranberry': THURL = "\\\\\\assets\\template\\css\\themes\\cust-theme-6.css"; break;
            default: THURL = " ";}}
        themS.themeOptions = THOP;themS.themeURL = THURL;
        localStorage.setItem("themeSettings", JSON.stringify(themS));
        Conf_.themeOptions = THOP;
        //Conf_.themeURL = THURL;
        Conf_.themeURL = $sessionStorage.GlobalSettings.AppSettings.ThemeSettings.themeURL;

        localStorage.setItem("Conf_", JSON.stringify(Conf_));

        //vg.initController = function () {
        //    setTimeout(function () { $(".preloader").fadeOut("slow"); }, 50);
        //}
        setTimeout(function () { $(".preloader").fadeOut("slow"); }, 50);
 }]
)