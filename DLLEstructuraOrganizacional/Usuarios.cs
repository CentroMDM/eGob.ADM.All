using System;
using System.Collections.Generic;
using System.Data;
using EntitiesPSR;
using DLLUtilerias;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ClsLoguin;

namespace DLLEstructuraOrganizacional
{
    public class Usuarios
    {
        #region Usuarios
        public List<Etusuarios> GetUsuarios()
        {
            DatosEO obtenerUsuarios = new DatosEO();
            DataTable dtUsuarios = obtenerUsuarios.GetUsuarios();
            List<Etusuarios> lsUsuarios = new Utilerias().Convertir<Etusuarios>(dtUsuarios);
            return lsUsuarios;
        }
        //public List<Etusuarios> ObtenerUsuariosActivos()
        //{
        //    DatosEO obtenerUsuarios = new DatosEO();
        //    DataTable dtUsuarios = obtenerUsuarios.ObtenerUsuariosActivos();
        //    List<Etusuarios> lsUsuarios = UtilTablas.ConvertirDataTableToList<Etusuarios>(dtUsuarios);
        //    return lsUsuarios;
        //}
        public List<EBuzonXUnidad> AplicacionesxUnidad(int RIDUnidad)
        {
            DatosEO obtenerAppXU = new DatosEO();
            DataTable dtAppXU = obtenerAppXU.AplicacionesxUnidad(RIDUnidad);
            List<EBuzonXUnidad> lsAppXU = new Utilerias().Convertir<EBuzonXUnidad>(dtAppXU);
            return lsAppXU;
        }
        //public List<Etusuarios> ObtenerUsuariosActivosXU(int RIDUnidad)
        //{
        //    DatosEO obtenerUsuariosXU = new DatosEO();
        //    DataTable dtUsuariosXU = obtenerUsuariosXU.ObtenerUsuariosActivosXU(RIDUnidad);
        //    List<Etusuarios> lsUsuariosXU = UtilTablas.ConvertirDataTableToList<Etusuarios>(dtUsuariosXU);
        //    return lsUsuariosXU;
        //}
        public List<Etusuarios> ObtenerUsuariosXUnidadA(int RIDUnidad)
        {
            DatosEO obtenerUsuariosXU = new DatosEO();
            DataTable dtUsuariosXU = obtenerUsuariosXU.ObtenerUsuariosXUnidadA(RIDUnidad);
            List<Etusuarios> lsUsuariosXU = new Utilerias().Convertir<Etusuarios>(dtUsuariosXU);
            return lsUsuariosXU;
        }
        //public List<Etusuarios> ObtenerFirmantes()
        //{
        //    DatosEO obtenerFirmantes = new DatosEO();
        //    DataTable dtFirmantes = obtenerFirmantes.ObtenerFirmantes();
        //    List<Etusuarios> lsfirmantes = UtilTablas.ConvertirDataTableToList<Etusuarios>(dtFirmantes);
        //    return lsfirmantes;
        //}
        //public List<Etusuarios> ObtenerFirmantesXU(int RIDUnidad)
        //{
        //    DatosEO obtenerFirmantesXU = new DatosEO();
        //    DataTable dtFirmantesXU = obtenerFirmantesXU.ObtenerFirmantesXU(RIDUnidad);
        //    List<Etusuarios> lsfirmantesXU = UtilTablas.ConvertirDataTableToList<Etusuarios>(dtFirmantesXU);
        //    return lsfirmantesXU;
        //}
        //public List<Etusuarios> ObtenerFirmantesActivos()
        //{
        //    DatosEO obtenerFirmantesA = new DatosEO();
        //    DataTable dtFirmantesA = obtenerFirmantesA.ObtenerFirmantesActivos();
        //    List<Etusuarios> lsfirmantesA = UtilTablas.ConvertirDataTableToList<Etusuarios>(dtFirmantesA);
        //    return lsfirmantesA;
        //}
        public List<Etusuarios> getNewUsuarios(int RIDUnidad)
        {
            DatosEO newUsuariosXU = new DatosEO();
            DataTable dtnewUsuariosXU = newUsuariosXU.getNewUsuarios(RIDUnidad);
            List<Etusuarios> lsnewUsuariosXU = new Utilerias().Convertir<Etusuarios>(dtnewUsuariosXU);
            return lsnewUsuariosXU;
        }
        public List<Etusuarios> UsuariosExistentes(int RIDUnidad)
        {
            DatosEO UsuariosXU = new DatosEO();
            DataTable dtUsuariosXU = UsuariosXU.UsuariosExistentes(RIDUnidad);
            List<Etusuarios> lsUsuariosXU = new Utilerias().Convertir<Etusuarios>(dtUsuariosXU);
            return lsUsuariosXU;
        }
        //public List<ETablaRelacionERB> GetTableRelacionERB()
        //{
        //    DatosEO relacionERB = new DatosEO();
        //    DataTable dtRelacionERB = relacionERB.GetTableRelacionERB();
        //    List<ETablaRelacionERB> lsRelacionERB = UtilTablas.ConvertirDataTableToList<ETablaRelacionERB>(dtRelacionERB);
        //    return lsRelacionERB;
        //}
        //////public static string ObtenerCodigoSHA(string cadena)
        //////{
        //////    return Convert.ToBase64String(new SHA512CryptoServiceProvider().ComputeHash(new UnicodeEncoding().GetBytes(cadena)));
        //////}
        public Resultado IngresarUsuario(Etusuarios newUser)
        {
            DatosEO ingresarUsuario = new DatosEO();
            (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.TUSUARIOS);
            newUser.UserID = HelperLogin.EncodePassword(newUser.UserID);
            newUser.UserPW = HelperLogin.EncodePassword(newUser.UserID + newUser.UserPW);
            newUser.RIDUsuario = identificadores.Item1;
            newUser.BOIDUsuario = identificadores.Item2;
            DataTable dtEmpleado = ingresarUsuario.IngresarUsuario(newUser);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtEmpleado);
            if (resultado.ExisteError)
            {
                return resultado;
            }
            else
            {
                foreach (Erusuariobuzon buzon in newUser.Buzones)//Inserta en rusuario_buzon
                {
                    identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RUSUARIO_BUZON);
                    Erusuariobuzon usuarioBuzon = new Erusuariobuzon
                    {
                        RID = identificadores.Item1,
                        ClaveUsuario = newUser.RIDUsuario,
                        ClaveBuzon = buzon.ClaveBuzon
                    };
                    dtEmpleado = ingresarUsuario.rUsuarioBuzon(usuarioBuzon);
                    resultado = new Utilerias().ResultadoDesdeTabla(dtEmpleado);
                    if (resultado.ExisteError)
                    {
                        return resultado;
                    }
                    else
                    {
                        foreach (ErBuzonRoles rol in buzon.ClaveRol) //Inserta en rrolusuarioaplicacion
                        {
                            identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                            ErBuzonRoles usuarioRol = new ErBuzonRoles
                            {
                                RIDRUS = identificadores.Item1,
                                ClaveUsuario = newUser.RIDUsuario,
                                ClaveBuzon = buzon.ClaveBuzon,
                                ClaveRol = rol.ClaveRol
                            };
                            dtEmpleado = ingresarUsuario.rUsuarioRol(usuarioRol);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtEmpleado);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }

                    }
                }
                dtEmpleado = ingresarUsuario.EliminaTablaTeporal();
                resultado = new Utilerias().ResultadoDesdeTabla(dtEmpleado);
                if (resultado.ExisteError)
                {
                    return resultado;
                }
            }
            return resultado;
        }
        public Resultado UpdateUser(Etusuarios updateUser)
        {
            //DatosEO ingresarUsuario = new DatosEO();
            //DataTable dtupdateUser = ingresarUsuario.UpdateUser(updateUser);
            //Resultado resultado = UtilTablas.ResultadoDesdeTabla(dtupdateUser);
            //return resultado;

            DatosEO ingresarUsuario = new DatosEO();
            DataTable dtupdateUser = ingresarUsuario.UpdateUser(updateUser);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
            if (resultado.ExisteError)
            {
                return resultado;
            }
            else
            {
                if (updateUser.RUBElimindas.Count == 0 && updateUser.RUBNuevas.Count == 0)
                {
                    if (updateUser.RUSElimindas.Count == 0 && updateUser.RUSNuevas.Count == 0)
                    {
                        return resultado;
                    }
                    else if (updateUser.RUSElimindas.Count != 0 && updateUser.RUSNuevas.Count == 0)
                    {

                        foreach (ErBuzonRoles rusElimindo in updateUser.RUSElimindas) //Inserta en rrolusuarioaplicacion
                        {
                            dtupdateUser = ingresarUsuario.DelRUSElimindas(rusElimindo);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }
                    }
                    else if (updateUser.RUSElimindas.Count == 0 && updateUser.RUSNuevas.Count != 0)
                    {
                        foreach (ErBuzonRoles rusNuevo in updateUser.RUSNuevas) //Inserta en rrolusuarioaplicacion
                        {
                            (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                            ErBuzonRoles usuarioRol = new ErBuzonRoles
                            {
                                RIDRUS = identificadores.Item1,
                                ClaveUsuario = updateUser.RIDUsuario,
                                ClaveBuzon = rusNuevo.ClaveBuzon,
                                ClaveRol = rusNuevo.ClaveRol
                            };
                            dtupdateUser = ingresarUsuario.rUsuarioRol(usuarioRol);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }
                    }
                    else if (updateUser.RUSElimindas.Count != 0 && updateUser.RUSNuevas.Count != 0)
                    {
                        foreach (ErBuzonRoles rusElimindo in updateUser.RUSElimindas) //Inserta en rrolusuarioaplicacion
                        {
                            dtupdateUser = ingresarUsuario.DelRUSElimindas(rusElimindo);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }
                        foreach (ErBuzonRoles rusNuevo in updateUser.RUSNuevas) //Inserta en rrolusuarioaplicacion
                        {
                            (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                            ErBuzonRoles usuarioRol = new ErBuzonRoles
                            {
                                RIDRUS = identificadores.Item1,
                                ClaveUsuario = updateUser.RIDUsuario,
                                ClaveBuzon = rusNuevo.ClaveBuzon,
                                ClaveRol = rusNuevo.ClaveRol
                            };
                            dtupdateUser = ingresarUsuario.rUsuarioRol(usuarioRol);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }
                    }
                }
                else if (updateUser.RUBElimindas.Count != 0 && updateUser.RUBNuevas.Count == 0)
                {
                    foreach (Erusuariobuzon rubElimindo in updateUser.RUBElimindas)//Inserta en rusuario_buzon
                    {

                        dtupdateUser = ingresarUsuario.DelRUBElimindas(rubElimindo);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                        if (resultado.ExisteError)
                        {
                            return resultado;
                        }
                        else
                        {
                            if (updateUser.RUSElimindas.Count == 0 && updateUser.RUSNuevas.Count == 0)
                            {
                                if (updateUser.RUSNuevas.Count == 0)
                                {
                                    return resultado;
                                }
                            }
                            else if (updateUser.RUSElimindas.Count != 0 && updateUser.RUSNuevas.Count == 0)
                            {

                                foreach (ErBuzonRoles rusElimindo in updateUser.RUSElimindas) //Inserta en rrolusuarioaplicacion
                                {
                                    dtupdateUser = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                    if (resultado.ExisteError)
                                    {
                                        return resultado;
                                    }
                                }
                            }
                            else if (updateUser.RUSElimindas.Count == 0 && updateUser.RUSNuevas.Count != 0)
                            {
                                foreach (ErBuzonRoles rusNuevo in updateUser.RUSNuevas) //Inserta en rrolusuarioaplicacion
                                {
                                    (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                    ErBuzonRoles usuarioRol = new ErBuzonRoles
                                    {
                                        RIDRUS = identificadores.Item1,
                                        ClaveUsuario = updateUser.RIDUsuario,
                                        ClaveBuzon = rusNuevo.ClaveBuzon,
                                        ClaveRol = rusNuevo.ClaveRol
                                    };
                                    dtupdateUser = ingresarUsuario.rUsuarioRol(usuarioRol);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                    if (resultado.ExisteError)
                                    {
                                        return resultado;
                                    }
                                }
                            }
                            else if (updateUser.RUSElimindas.Count != 0 && updateUser.RUSNuevas.Count != 0)
                            {
                                foreach (ErBuzonRoles rusElimindo in updateUser.RUSElimindas) //Inserta en rrolusuarioaplicacion
                                {
                                    dtupdateUser = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                    if (resultado.ExisteError)
                                    {
                                        return resultado;
                                    }
                                }
                                foreach (ErBuzonRoles rusNuevo in updateUser.RUSNuevas) //Inserta en rrolusuarioaplicacion
                                {
                                    //Console.Write($"{buzon} ");
                                    (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                    ErBuzonRoles usuarioRol = new ErBuzonRoles
                                    {
                                        RIDRUS = identificadores.Item1,
                                        ClaveUsuario = updateUser.RIDUsuario,
                                        ClaveBuzon = rusNuevo.ClaveBuzon,
                                        ClaveRol = rusNuevo.ClaveRol
                                    };
                                    dtupdateUser = ingresarUsuario.rUsuarioRol(usuarioRol);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                    if (resultado.ExisteError)
                                    {
                                        return resultado;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (updateUser.RUBElimindas.Count == 0 && updateUser.RUBNuevas.Count != 0)
                {
                    foreach (Erusuariobuzon rubNuevo in updateUser.RUBNuevas)//Inserta en rusuario_buzon
                    {
                        (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RUSUARIO_BUZON);
                        Erusuariobuzon insertaRUB = new Erusuariobuzon
                        {
                            RID = identificadores.Item1,
                            ClaveUsuario = updateUser.RIDUsuario,
                            ClaveBuzon = rubNuevo.ClaveBuzon
                        };
                        dtupdateUser = ingresarUsuario.rUsuarioBuzon(insertaRUB);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                    }
                    if (resultado.ExisteError)
                    {
                        return resultado;
                    }
                    else
                    {
                        if (updateUser.RUSElimindas.Count == 0 && updateUser.RUSNuevas.Count == 0)
                        {
                            if (updateUser.RUSNuevas.Count == 0)
                            {
                                return resultado;
                            }
                        }
                        else if (updateUser.RUSElimindas.Count != 0 && updateUser.RUSNuevas.Count == 0)
                        {

                            foreach (ErBuzonRoles rusElimindo in updateUser.RUSElimindas) //Inserta en rrolusuarioaplicacion
                            {
                                dtupdateUser = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                        else if (updateUser.RUSElimindas.Count == 0 && updateUser.RUSNuevas.Count != 0)
                        {
                            foreach (ErBuzonRoles rusNuevo in updateUser.RUSNuevas) //Inserta en rrolusuarioaplicacion
                            {
                                (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                ErBuzonRoles usuarioRol = new ErBuzonRoles
                                {
                                    RIDRUS = identificadores.Item1,
                                    ClaveUsuario = updateUser.RIDUsuario,
                                    ClaveBuzon = rusNuevo.ClaveBuzon,
                                    ClaveRol = rusNuevo.ClaveRol
                                };
                                dtupdateUser = ingresarUsuario.rUsuarioRol(usuarioRol);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                        else if (updateUser.RUSElimindas.Count != 0 && updateUser.RUSNuevas.Count != 0)
                        {
                            foreach (ErBuzonRoles rusElimindo in updateUser.RUSElimindas) //Inserta en rrolusuarioaplicacion
                            {
                                dtupdateUser = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                            foreach (ErBuzonRoles rusNuevo in updateUser.RUSNuevas) //Inserta en rrolusuarioaplicacion
                            {
                                //Console.Write($"{buzon} ");
                                (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                ErBuzonRoles usuarioRol = new ErBuzonRoles
                                {
                                    RIDRUS = identificadores.Item1,
                                    ClaveUsuario = updateUser.RIDUsuario,
                                    ClaveBuzon = rusNuevo.ClaveBuzon,
                                    ClaveRol = rusNuevo.ClaveRol
                                };
                                dtupdateUser = ingresarUsuario.rUsuarioRol(rusNuevo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                    }
                }
                else if (updateUser.RUBElimindas.Count != 0 && updateUser.RUBNuevas.Count != 0)
                {
                    foreach (Erusuariobuzon rubElimindo in updateUser.RUBElimindas)//Inserta en rusuario_buzon
                    {

                        dtupdateUser = ingresarUsuario.DelRUBElimindas(rubElimindo);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                    }
                    foreach (Erusuariobuzon rubNuevo in updateUser.RUBNuevas)//Inserta en rusuario_buzon
                    {
                        (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RUSUARIO_BUZON);
                        Erusuariobuzon insertaRUB = new Erusuariobuzon
                        {
                            RID = identificadores.Item1,
                            ClaveUsuario = updateUser.RIDUsuario,
                            ClaveBuzon = rubNuevo.ClaveBuzon
                        };
                        dtupdateUser = ingresarUsuario.rUsuarioBuzon(insertaRUB);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                    }
                    if (resultado.ExisteError)
                    {
                        return resultado;
                    }
                    else
                    {
                        if (updateUser.RUSElimindas.Count == 0 && updateUser.RUSNuevas.Count == 0)
                        {
                            if (updateUser.RUSNuevas.Count == 0)
                            {
                                return resultado;
                            }
                        }
                        else if (updateUser.RUSElimindas.Count != 0 && updateUser.RUSNuevas.Count == 0)
                        {

                            foreach (ErBuzonRoles rusElimindo in updateUser.RUSElimindas) //Inserta en rrolusuarioaplicacion
                            {
                                dtupdateUser = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                        else if (updateUser.RUSElimindas.Count == 0 && updateUser.RUSNuevas.Count != 0)
                        {
                            foreach (ErBuzonRoles rusNuevo in updateUser.RUSNuevas) //Inserta en rrolusuarioaplicacion
                            {
                                (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                ErBuzonRoles usuarioRol = new ErBuzonRoles
                                {
                                    RIDRUS = identificadores.Item1,
                                    ClaveUsuario = updateUser.RIDUsuario,
                                    ClaveBuzon = rusNuevo.ClaveBuzon,
                                    ClaveRol = rusNuevo.ClaveRol
                                };
                                dtupdateUser = ingresarUsuario.rUsuarioRol(usuarioRol);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                        else if (updateUser.RUSElimindas.Count != 0 && updateUser.RUSNuevas.Count != 0)
                        {
                            foreach (ErBuzonRoles rusElimindo in updateUser.RUSElimindas) //Inserta en rrolusuarioaplicacion
                            {
                                dtupdateUser = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                            foreach (ErBuzonRoles rusNuevo in updateUser.RUSNuevas) //Inserta en rrolusuarioaplicacion
                            {
                                (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                ErBuzonRoles usuarioRol = new ErBuzonRoles
                                {
                                    RIDRUS = identificadores.Item1,
                                    ClaveUsuario = updateUser.RIDUsuario,
                                    ClaveBuzon = rusNuevo.ClaveBuzon,
                                    ClaveRol = rusNuevo.ClaveRol
                                };
                                dtupdateUser = ingresarUsuario.rUsuarioRol(usuarioRol);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUser);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                    }
                }
            }
            //dtEmpleado = ingresarUsuario.EliminaTablaTeporal();
            //resultado = UtilTablas.ResultadoDesdeTabla(dtEmpleado);
            //if (resultado.ExisteError)
            //{
            return resultado;
        }
        public Resultado UpdateUserPW(Etusuarios updateUserPW)
        {
            DatosEO ingresarUsuario = new DatosEO();
            updateUserPW.UserID = HelperLogin.EncodePassword(updateUserPW.UserID);
            updateUserPW.UserPW = HelperLogin.EncodePassword(updateUserPW.UserID + updateUserPW.UserPW);
            DataTable dtupdateUserPW = ingresarUsuario.UpdateUserPW(updateUserPW);
            Resultado resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
            if (resultado.ExisteError)
            {
                return resultado;
            }
            else
            {
                if (updateUserPW.RUBElimindas.Count == 0 && updateUserPW.RUBNuevas.Count == 0)
                {
                    if (updateUserPW.RUSElimindas.Count == 0 && updateUserPW.RUSNuevas.Count == 0)
                    {
                        return resultado;
                    }
                    else if (updateUserPW.RUSElimindas.Count != 0 && updateUserPW.RUSNuevas.Count == 0)
                    {

                        foreach (ErBuzonRoles rusElimindo in updateUserPW.RUSElimindas) //Inserta en rrolusuarioaplicacion
                        {
                            dtupdateUserPW = ingresarUsuario.DelRUSElimindas(rusElimindo);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }
                    }
                    else if (updateUserPW.RUSElimindas.Count == 0 && updateUserPW.RUSNuevas.Count != 0)
                    {
                        foreach (ErBuzonRoles rusNuevo in updateUserPW.RUSNuevas) //Inserta en rrolusuarioaplicacion
                        {
                            (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                            ErBuzonRoles usuarioRol = new ErBuzonRoles
                            {
                                RIDRUS = identificadores.Item1,
                                ClaveUsuario = updateUserPW.RIDUsuario,
                                ClaveBuzon = rusNuevo.ClaveBuzon,
                                ClaveRol = rusNuevo.ClaveRol
                            };
                            dtupdateUserPW = ingresarUsuario.rUsuarioRol(usuarioRol);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }
                    }
                    else if (updateUserPW.RUSElimindas.Count != 0 && updateUserPW.RUSNuevas.Count != 0)
                    {
                        foreach (ErBuzonRoles rusElimindo in updateUserPW.RUSElimindas) //Inserta en rrolusuarioaplicacion
                        {
                            dtupdateUserPW = ingresarUsuario.DelRUSElimindas(rusElimindo);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }
                        foreach (ErBuzonRoles rusNuevo in updateUserPW.RUSNuevas) //Inserta en rrolusuarioaplicacion
                        {
                            (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                            ErBuzonRoles usuarioRol = new ErBuzonRoles
                            {
                                RIDRUS = identificadores.Item1,
                                ClaveUsuario = updateUserPW.RIDUsuario,
                                ClaveBuzon = rusNuevo.ClaveBuzon,
                                ClaveRol = rusNuevo.ClaveRol
                            };
                            dtupdateUserPW = ingresarUsuario.rUsuarioRol(usuarioRol);
                            resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                            if (resultado.ExisteError)
                            {
                                return resultado;
                            }
                        }
                    }
                }
                else if (updateUserPW.RUBElimindas.Count != 0 && updateUserPW.RUBNuevas.Count == 0)
                {
                    foreach (Erusuariobuzon rubElimindo in updateUserPW.RUBElimindas)//Inserta en rusuario_buzon
                    {
                        dtupdateUserPW = ingresarUsuario.DelRUBElimindas(rubElimindo);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                        if (resultado.ExisteError)
                        {
                            return resultado;
                        }
                        else
                        {
                            if (updateUserPW.RUSElimindas.Count == 0 && updateUserPW.RUSNuevas.Count == 0)
                            {
                                if (updateUserPW.RUSNuevas.Count == 0)
                                {
                                    return resultado;
                                }
                            }
                            else if (updateUserPW.RUSElimindas.Count != 0 && updateUserPW.RUSNuevas.Count == 0)
                            {

                                foreach (ErBuzonRoles rusElimindo in updateUserPW.RUSElimindas) //Inserta en rrolusuarioaplicacion
                                {
                                    dtupdateUserPW = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                    if (resultado.ExisteError)
                                    {
                                        return resultado;
                                    }
                                }
                            }
                            else if (updateUserPW.RUSElimindas.Count == 0 && updateUserPW.RUSNuevas.Count != 0)
                            {
                                foreach (ErBuzonRoles rusNuevo in updateUserPW.RUSNuevas) //Inserta en rrolusuarioaplicacion
                                {
                                    (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                    ErBuzonRoles usuarioRol = new ErBuzonRoles
                                    {
                                        RIDRUS = identificadores.Item1,
                                        ClaveUsuario = updateUserPW.RIDUsuario,
                                        ClaveBuzon = rusNuevo.ClaveBuzon,
                                        ClaveRol = rusNuevo.ClaveRol
                                    };
                                    dtupdateUserPW = ingresarUsuario.rUsuarioRol(usuarioRol);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                    if (resultado.ExisteError)
                                    {
                                        return resultado;
                                    }
                                }
                            }
                            else if (updateUserPW.RUSElimindas.Count != 0 && updateUserPW.RUSNuevas.Count != 0)
                            {
                                foreach (ErBuzonRoles rusElimindo in updateUserPW.RUSElimindas) //Inserta en rrolusuarioaplicacion
                                {
                                    dtupdateUserPW = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                    if (resultado.ExisteError)
                                    {
                                        return resultado;
                                    }
                                }
                                foreach (ErBuzonRoles rusNuevo in updateUserPW.RUSNuevas) //Inserta en rrolusuarioaplicacion
                                {
                                    (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                    ErBuzonRoles usuarioRol = new ErBuzonRoles
                                    {
                                        RIDRUS = identificadores.Item1,
                                        ClaveUsuario = updateUserPW.RIDUsuario,
                                        ClaveBuzon = rusNuevo.ClaveBuzon,
                                        ClaveRol = rusNuevo.ClaveRol
                                    };
                                    dtupdateUserPW = ingresarUsuario.rUsuarioRol(usuarioRol);
                                    resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                    if (resultado.ExisteError)
                                    {
                                        return resultado;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (updateUserPW.RUBElimindas.Count == 0 && updateUserPW.RUBNuevas.Count != 0)
                {
                    foreach (Erusuariobuzon rubNuevo in updateUserPW.RUBNuevas)//Inserta en rusuario_buzon
                    {
                        (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RUSUARIO_BUZON);
                        Erusuariobuzon insertaRUB = new Erusuariobuzon
                        {
                            RID = identificadores.Item1,
                            ClaveUsuario = updateUserPW.RIDUsuario,
                            ClaveBuzon = rubNuevo.ClaveBuzon
                        };
                        dtupdateUserPW = ingresarUsuario.rUsuarioBuzon(insertaRUB);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                    }
                    if (resultado.ExisteError)
                    {
                        return resultado;
                    }
                    else
                    {
                        if (updateUserPW.RUSElimindas.Count == 0 && updateUserPW.RUSNuevas.Count == 0)
                        {
                            if (updateUserPW.RUSNuevas.Count == 0)
                            {
                                return resultado;
                            }
                        }
                        else if (updateUserPW.RUSElimindas.Count != 0 && updateUserPW.RUSNuevas.Count == 0)
                        {

                            foreach (ErBuzonRoles rusElimindo in updateUserPW.RUSElimindas) //Inserta en rrolusuarioaplicacion
                            {
                                dtupdateUserPW = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                        else if (updateUserPW.RUSElimindas.Count == 0 && updateUserPW.RUSNuevas.Count != 0)
                        {
                            foreach (ErBuzonRoles rusNuevo in updateUserPW.RUSNuevas) //Inserta en rrolusuarioaplicacion
                            {
                                (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                ErBuzonRoles usuarioRol = new ErBuzonRoles
                                {
                                    RIDRUS = identificadores.Item1,
                                    ClaveUsuario = updateUserPW.RIDUsuario,
                                    ClaveBuzon = rusNuevo.ClaveBuzon,
                                    ClaveRol = rusNuevo.ClaveRol
                                };
                                dtupdateUserPW = ingresarUsuario.rUsuarioRol(usuarioRol);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                        else if (updateUserPW.RUSElimindas.Count != 0 && updateUserPW.RUSNuevas.Count != 0)
                        {
                            foreach (ErBuzonRoles rusElimindo in updateUserPW.RUSElimindas) //Inserta en rrolusuarioaplicacion
                            {
                                dtupdateUserPW = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                            foreach (ErBuzonRoles rusNuevo in updateUserPW.RUSNuevas) //Inserta en rrolusuarioaplicacion
                            {
                                (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                ErBuzonRoles usuarioRol = new ErBuzonRoles
                                {
                                    RIDRUS = identificadores.Item1,
                                    ClaveUsuario = updateUserPW.RIDUsuario,
                                    ClaveBuzon = rusNuevo.ClaveBuzon,
                                    ClaveRol = rusNuevo.ClaveRol
                                };
                                dtupdateUserPW = ingresarUsuario.rUsuarioRol(rusNuevo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                    }
                }
                else if (updateUserPW.RUBElimindas.Count != 0 && updateUserPW.RUBNuevas.Count != 0)
                {
                    foreach (Erusuariobuzon rubElimindo in updateUserPW.RUBElimindas)//Inserta en rusuario_buzon
                    {

                        dtupdateUserPW = ingresarUsuario.DelRUBElimindas(rubElimindo);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                    }
                    foreach (Erusuariobuzon rubNuevo in updateUserPW.RUBNuevas)//Inserta en rusuario_buzon
                    {
                        (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RUSUARIO_BUZON);
                        Erusuariobuzon insertaRUB = new Erusuariobuzon
                        {
                            RID = identificadores.Item1,
                            ClaveUsuario = updateUserPW.RIDUsuario,
                            ClaveBuzon = rubNuevo.ClaveBuzon
                        };
                        dtupdateUserPW = ingresarUsuario.rUsuarioBuzon(insertaRUB);
                        resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                    }
                    if (resultado.ExisteError)
                    {
                        return resultado;
                    }
                    else
                    {
                        if (updateUserPW.RUSElimindas.Count == 0 && updateUserPW.RUSNuevas.Count == 0)
                        {
                            if (updateUserPW.RUSNuevas.Count == 0)
                            {
                                return resultado;
                            }
                        }
                        else if (updateUserPW.RUSElimindas.Count != 0 && updateUserPW.RUSNuevas.Count == 0)
                        {

                            foreach (ErBuzonRoles rusElimindo in updateUserPW.RUSElimindas) //Inserta en rrolusuarioaplicacion
                            {
                                dtupdateUserPW = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                        else if (updateUserPW.RUSElimindas.Count == 0 && updateUserPW.RUSNuevas.Count != 0)
                        {
                            foreach (ErBuzonRoles rusNuevo in updateUserPW.RUSNuevas) //Inserta en rrolusuarioaplicacion
                            {
                                (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                ErBuzonRoles usuarioRol = new ErBuzonRoles
                                {
                                    RIDRUS = identificadores.Item1,
                                    ClaveUsuario = updateUserPW.RIDUsuario,
                                    ClaveBuzon = rusNuevo.ClaveBuzon,
                                    ClaveRol = rusNuevo.ClaveRol
                                };
                                dtupdateUserPW = ingresarUsuario.rUsuarioRol(usuarioRol);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                        else if (updateUserPW.RUSElimindas.Count != 0 && updateUserPW.RUSNuevas.Count != 0)
                        {
                            foreach (ErBuzonRoles rusElimindo in updateUserPW.RUSElimindas) //Inserta en rrolusuarioaplicacion
                            {
                                dtupdateUserPW = ingresarUsuario.DelRUSElimindas(rusElimindo);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                            foreach (ErBuzonRoles rusNuevo in updateUserPW.RUSNuevas) //Inserta en rrolusuarioaplicacion
                            {
                                (int, string) identificadores = ingresarUsuario.ObtenerIdentificadoresPSR(TablasAdministracion.RROLUSUARIOENAPLICACION);
                                ErBuzonRoles usuarioRol = new ErBuzonRoles
                                {
                                    RIDRUS = identificadores.Item1,
                                    ClaveUsuario = updateUserPW.RIDUsuario,
                                    ClaveBuzon = rusNuevo.ClaveBuzon,
                                    ClaveRol = rusNuevo.ClaveRol
                                };
                                dtupdateUserPW = ingresarUsuario.rUsuarioRol(usuarioRol);
                                resultado = new Utilerias().ResultadoDesdeTabla(dtupdateUserPW);
                                if (resultado.ExisteError)
                                {
                                    return resultado;
                                }
                            }
                        }
                    }
                }
            }
            return resultado;
        }
        public List<Etusuarios> ReactivaUsuario(int RIDUsuario)
        {
            DatosEO upUser = new DatosEO();
            DataTable dtupUser = upUser.ReactivaUsuario(RIDUsuario);
            List<Etusuarios> lsupUser = new Utilerias().Convertir<Etusuarios>(dtupUser);
            return lsupUser;
        }
        public List<Etusuarios> DownUsuarioyRelacionesRolBuzon(int RIDUsuario)
        {
            DatosEO delUser = new DatosEO();
            DataTable dtdelUser = delUser.DownUsuarioyRelacionesRolBuzon(RIDUsuario);
            List<Etusuarios> lsdelUser = new Utilerias().Convertir<Etusuarios>(dtdelUser);
            return lsdelUser;
        }
        public List<Etusuarios> DeleteUsuarioyRelacionesRolBuzon(int RIDUsuario)
        {
            DatosEO delUser = new DatosEO();
            DataTable dtdelUser = delUser.DeleteUsuarioyRelacionesRolBuzon(RIDUsuario);
            List<Etusuarios> lsdelUser = new Utilerias().Convertir<Etusuarios>(dtdelUser);
            return lsdelUser;
        }
        #endregion

        #region Usuarios-Roles
        public List<ECatRoles> RolesXNivelPuesto(int RIDNivel)
        {
            DatosEO rolesXNivelP = new DatosEO();
            DataTable dtrolesXNivelP = rolesXNivelP.RolesXNivelPuesto(RIDNivel);
            List<ECatRoles> lsrolesXNivelP = new Utilerias().Convertir<ECatRoles>(dtrolesXNivelP);
            return lsrolesXNivelP;
        }
        public List<ECatRoles> insertaRolesEmpleado(ETablaRelacionERB Roles)
        {
            DatosEO setRoles = new DatosEO();
            DataTable dtrolesXNivelP = setRoles.insertaRolesEmpleado(Roles);
            List<ECatRoles> lsrolesXNivelP = new Utilerias().Convertir<ECatRoles>(dtrolesXNivelP);
            return lsrolesXNivelP;
        }
        public List<ECatRoles> EliminaRolTeporal(int ClaveBuzon)
        {
            DatosEO delRolTemp = new DatosEO();
            DataTable dtdelRolTemp = delRolTemp.EliminaRolTeporal(ClaveBuzon);
            List<ECatRoles> lsdelRolTemp = new Utilerias().Convertir<ECatRoles>(dtdelRolTemp);
            return lsdelRolTemp;
        }
        #endregion
    }
}
