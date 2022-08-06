using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOAccesoDatos;
using EntitiesPSR;
using Utilerias;

namespace BTLConfiguracionPSRV2
{
    public class BTLUsuario
    {
        private DAOGetObjetosNegocio daoGetObjetosNegocio = null;
        private DAOGetObjetosNegocio GetObjetosNegocio()
        {
            if (daoGetObjetosNegocio == null)
            {
                daoGetObjetosNegocio = new DAOGetObjetosNegocio();
            }
            return daoGetObjetosNegocio;
        }
        public List<Etempleados> ObtenerUsuariosYEmpleados()
        {
            BTLUnidadAdministrativa btl = new BTLUnidadAdministrativa();
            List<Etempleados> lsEmpleados = btl.ObtenerEmpleados();
            List<EtcatPuestos> lsPuestos = btl.ObtenerPuestosInstitucionales();
            foreach (Etempleados empleado in lsEmpleados)
            {
                foreach (EtcatPuestos puesto in lsPuestos)
                {
                    if (empleado.ClavePuesto == puesto.RIDPuestos)
                    {
                        empleado.PuestoInstitucional = puesto;
                    }
                }
            }
            //Usuarios asociados
            List<Etusuarios> lsUsuarios = ObtenerUsuarios();
            //Buscamos los buzones
            List<Ebuzonesconfiguracion> lsBuzonRol = new BTLBuzon().ObtenerBuzonYRol();
            //Buscamos las relaciones
            List<Errolusuarioenaplicacion> lsUsuarioAplicacion = ObtenerUsuarioEnAplicacion();
            //foreach (Etempleados empleado in lsEmpleados)
            //{
            //    foreach (Etusuarios usuario in lsUsuarios)
            //    {
            //        if (usuario.ClaveEmpleado == empleado.RIDEmpleado)
            //        {
            //            usuario.Buzones = ObtenerBuzonRolDesdeUsuario(lsBuzonRol, lsUsuarioAplicacion, usuario);
            //            empleado.Usuario = usuario;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}
            return lsEmpleados;
        }
        private List<Ebuzonesconfiguracion> ObtenerBuzonRolDesdeUsuario(List<Ebuzonesconfiguracion> lsBuzonRol, List<Errolusuarioenaplicacion> lsUsuarioAplicacion, Etusuarios usuario)
        {
            //Obtener lista de buzones
            List<long> auxBuzon = new List<long>();
            List<Ebuzonesconfiguracion> nuevoBuzon = new List<Ebuzonesconfiguracion>();
            foreach (Errolusuarioenaplicacion usuarioAplicacion in lsUsuarioAplicacion)
            {
                foreach (Ebuzonesconfiguracion buzon in lsBuzonRol)
                {
                    if (!auxBuzon.Contains(usuarioAplicacion.ClaveBuzon) && usuarioAplicacion.ClaveBuzon == buzon.RIDBuzon && usuarioAplicacion.ClaveUsuario == usuario.RIDUsuario)
                    {
                        nuevoBuzon.Add(GenericCopier<Ebuzonesconfiguracion>.DeepCopy(buzon));
                        auxBuzon.Add(usuarioAplicacion.ClaveBuzon);
                    }
                }
            }
            foreach (Ebuzonesconfiguracion buzon in nuevoBuzon)
            {
                buzon.Roles = new List<Ecattodosroles>();
                foreach (Errolusuarioenaplicacion usuarioAplicacion in lsUsuarioAplicacion)
                {
                    if (usuarioAplicacion.ClaveBuzon == buzon.RIDBuzon && usuarioAplicacion.ClaveUsuario == usuario.RIDUsuario)
                    {
                        //Agregamos el rol que se encuentra en Claverol
                        foreach (Ebuzonesconfiguracion auxBuz in lsBuzonRol)
                        {
                            foreach (Ecattodosroles rol in auxBuz.Roles)
                            {
                                if (usuarioAplicacion.ClaveRol == rol.RIDRol && buzon.RIDBuzon == auxBuz.RIDBuzon)
                                {
                                    buzon.Roles.Add(rol);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return nuevoBuzon;
        }






























        public List<Etgruposatencion> ObtenerGruposAtencion() {
            List<Etgruposatencion> gruposAtencion = new List<Etgruposatencion>();
            return gruposAtencion;
        }

        public Resultado IngresarGrupoAtencion(Etgruposatencion grupoAtencion) {
            DAOSetObjetosNegocio daoSet = new DAOSetObjetosNegocio();
            (int, string) identificadores = daoSet.ObtenerIdentificadoresPSR(TablasAdministracion.TGRUPOATENCION);
            grupoAtencion.RIDGrupo = identificadores.Item1;
            grupoAtencion.BOIDGrupo = identificadores.Item2;
            daoSet.IniciarTransaccion();
            DataTable dataTable = daoSet.InsertarRegistrosMultiples(ScriptUsuario.IngresarGrupoAtencion(grupoAtencion));
            Resultado resultado = UtilTablas.ResultadoDesdeTabla(dataTable);
            if (resultado.ExisteError) {
                daoSet.DeshacerTransaccion();
                daoSet.CerrarConexion();
                return resultado;
            }
            else {
                foreach (Etempleados empleado in grupoAtencion.Usuarios) {
                    identificadores = daoSet.ObtenerIdentificadoresPSR(TablasAdministracion.RGRUPOUSUARIO);
                    Ergrupousuario grupousuario = new Ergrupousuario
                    {
                        RID = identificadores.Item1,
                        ClaveGrupoAtencion = grupoAtencion.RIDGrupo,
                        ClaveUsuario = empleado.Usuario.RIDUsuario
                    };
                    dataTable = daoSet.InsertarRegistrosMultiples(ScriptUsuario.IngresarGrupoUsuario(grupousuario));
                    resultado = UtilTablas.ResultadoDesdeTabla(dataTable);
                    if (resultado.ExisteError)
                    {
                        daoSet.DeshacerTransaccion();
                        daoSet.CerrarConexion();
                        return resultado;
                    }
                }
                foreach (Ebuzonconfiguraciongruposatencion conGrupoAtencion in grupoAtencion.Buzon.FiltroGrupoAtencion) {
                    identificadores = daoSet.ObtenerIdentificadoresPSR(TablasAdministracion.BUZON_CONFIGURACIONGRUPOSATENCION);
                    conGrupoAtencion.RID = identificadores.Item1;
                    conGrupoAtencion.ClaveGrupoAtencion = grupoAtencion.RIDGrupo;
                    dataTable = daoSet.InsertarRegistrosMultiples(ScriptUsuario.IngresarBuzonConfiguracionGruposAtencion(conGrupoAtencion));
                    resultado = UtilTablas.ResultadoDesdeTabla(dataTable);
                    if (resultado.ExisteError) {
                        daoSet.DeshacerTransaccion();
                        daoSet.CerrarConexion();
                        return resultado;
                    }
                }
            }
            daoSet.TerminarTransaccion();
            daoSet.CerrarConexion();
            return resultado;
        }

        //public Resultado IngresarUsuario(Etempleados empleado)
        //{
        //    DAOSetObjetosNegocio daoSet = new DAOSetObjetosNegocio();
        //    (int, string) identificadores = daoSet.ObtenerIdentificadoresPSR(TablasAdministracion.TUSUARIOS);
        //    empleado.Usuario.RIDUsuario = identificadores.Item1;
        //    empleado.Usuario.BOIDUsuario = identificadores.Item2;
        //    daoSet.IniciarTransaccion();
        //    DataTable dataTable = daoSet.InsertarRegistrosMultiples(ScriptUsuario.IngresarUsuario(empleado));
        //    Resultado resultado = UtilTablas.ResultadoDesdeTabla(dataTable);
        //    if (resultado.ExisteError)
        //    {
        //        daoSet.DeshacerTransaccion();
        //        daoSet.CerrarConexion();
        //        return resultado;
        //    }
        //    else
        //    {
        //        //Guardamos al usuario y al numero de buzones que contenga
        //        //foreach (Ebuzonesconfiguracion buzon in empleado.Usuario.Buzones)
        //        foreach (Ebuzonesconfiguracion buzon in empleado.Usuario.NombrePuesto)
        //            {
        //            identificadores = daoSet.ObtenerIdentificadoresPSR(TablasAdministracion.RUSUARIO_BUZON);
        //            Erusuariobuzon usuarioBuzon = new Erusuariobuzon
        //            {
        //                RID = identificadores.Item1,
        //                ClaveUsuario = empleado.Usuario.RIDUsuario,
        //                ClaveBuzon = buzon.RIDBuzon
        //            };
        //            dataTable = daoSet.InsertarRegistrosMultiples(ScriptUsuario.IngresarUsuarioBuzon(usuarioBuzon));
        //            resultado = UtilTablas.ResultadoDesdeTabla(dataTable);
        //            if (resultado.ExisteError)
        //            {
        //                daoSet.DeshacerTransaccion();
        //                daoSet.CerrarConexion();
        //                return resultado;
        //            }
        //        }
        //        //Guardamos la relacion usuario, buzon, rol
        //        foreach (Ebuzonesconfiguracion buzon in empleado.Usuario.Buzones)
        //        {
        //            foreach (Ecatroles rol in buzon.Roles)
        //            {
        //                identificadores = daoSet.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
        //                Errolusuarioenaplicacion rolUsuarioAplicacion = new Errolusuarioenaplicacion
        //                {
        //                    RIDRUS = identificadores.Item1,
        //                    ClaveApplicacion = buzon.ClaveTipoBuzon,
        //                    ClaveUsuario = empleado.Usuario.RIDUsuario,
        //                    ClaveBuzon = buzon.RIDBuzon,
        //                    ClaveRol = rol.RIDRol
        //                };
        //                dataTable = daoSet.InsertarRegistrosMultiples(ScriptUsuario.IngresarRolUsuarioAplicacion(rolUsuarioAplicacion));
        //                resultado = UtilTablas.ResultadoDesdeTabla(dataTable);
        //                if (resultado.ExisteError)
        //                {
        //                    daoSet.DeshacerTransaccion();
        //                    daoSet.CerrarConexion();
        //                    return resultado;
        //                }
        //            }
        //        }

        //    }
        //    daoSet.TerminarTransaccion();
        //    daoSet.CerrarConexion();
        //    return resultado;
        //}

        

        
        public List<Etusuarios> ObtenerUsuarios()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUsuario.ObtenerUsuariosBuzon());
            List<Etusuarios> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etusuarios>(table);
            return lsUsuarios;
        }

        public List<Errolusuarioenaplicacion> ObtenerUsuarioEnAplicacion()
        {
            DataTable table = GetObjetosNegocio().ObtenerConsulta(ScriptUsuario.ObtenerUsuarioEnAplicacion());
            List<Errolusuarioenaplicacion> lsUsuariosEnAplicacion = UtilTablas.ConvertirDataTableToList<Errolusuarioenaplicacion>(table);
            return lsUsuariosEnAplicacion;
        }

    }
}
