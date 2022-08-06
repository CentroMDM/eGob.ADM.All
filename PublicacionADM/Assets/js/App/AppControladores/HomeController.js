HomeController.controller("crtlHome", ["$scope", "$timeout", "administracionServices", "$http", "$sessionStorage",  "$rootScope",
    function (vm = $scope, $timeout, administracionServices, $http, $sessionStorage, vg = $rootScope) {
        const ctr = Administracion["HomeController"];

        const Srv = 'https://slpm.d-gob.app/';
        const Autorizacion = Srv + 'autorizacion';

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
            ClaveUsuario: $sessionStorage.GlobalSettings.Usuario.RIDUsuario,
            ClaveAplicacion: 211,
            ClaveBuzon: sessionStorage.GlobalSettings.AppBuzonSettings.RIDBuzon
        };
        //#region pruebaMenu
        Conf_.Menu = vg.MenuIzq = administracionServices.GetConfiguracionARC(ctr.GetConfiguracionARC, param);
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