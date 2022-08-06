using System;

namespace EntitiesPSR
{
    //[Serializable]
    public class Etempleados : ObjetoBase
    {

        public Etempleados() {
            //PuestoInstitucional = new EtcatPuestos();
            Usuario = new Etusuarios();
        }
        public Int64 RIDEmpleado { get; set; }
        public Int64 RIDUnidadAdministrativa { get; set; }
        public string NombrePuesto { get; set; }        
        public string NombreNivel { get; set; }
        public string NumeroEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string NombreEmpCompleto { get; set; }    
        public int RIDPuestos { get; set; }
        public string RFCEmpleado { get; set; }
        public Int64 ClaveDirectorioFoto { get; set; }
        public string DirectorioSecundarioFoto { get; set; }
        public Int64 ClavePuesto { get; set; }
        public string correoEmpleado { get; set; }
        public string DirectorioImagenesVirtual { get; set; }
        //public string DirectorioImagenes { get; set; }
        public bool Titular { get; set; }
        public string BOIDEmpleado { get; set; }
        public EtcatPuestos PuestoInstitucional { get; set; }
        public Etusuarios Usuario { get; set; }
        //public Int64 ClaveUnidadAdministrativa { get; set; }
        //public string NombreUA { get; set; }
        //public string NombrePuesto { get; set; }
        //public string NombreNivel { get; set; }
        //public string NombreCompleto{
        //    get {
        //        return NombreEmpleado + " " + APaterno + " " + AMaterno;
        //    }
        //}
        public override string ToString()
        {
            return ObjetoBase.ObjetoEnCadena(this);
        }


        //public Etempleados()
        //{
        //    Usuario = new Etusuarios();
        //}
        //public Int64 RIDEmpleado { get; set; }
        //public Int64 RIDUnidadAdministrativa { get; set; }
        //public string NombrePuesto { get; set; }
        //public string NombreNivel { get; set; }
        //public string NumeroEmpleado { get; set; }
        //public string NombreEmpleado { get; set; }
        //public string APaterno { get; set; }
        //public string AMaterno { get; set; }
        //public string RFCEmpleado { get; set; }
        //public Int64 ClaveDirectorioFoto { get; set; }
        //public string DirectorioSecundarioFoto { get; set; }
        //public Int64 ClavePuesto { get; set; }
        //public string correoEmpleado { get; set; }
        //public string DirectorioImagenesVirtual { get; set; }
        //public string BOIDEmpleado { get; set; }
        //public EtcatPuestos PuestoInstitucional { get; set; }
        //public Etusuarios Usuario { get; set; }
        ////public string NombreCompleto{
        ////    get {
        ////        return NombreEmpleado + " " + APaterno + " " + AMaterno;
        ////    }
        ////}
        //public override string ToString()
        //{
        //    return ObjetoBase.ObjetoEnCadena(this);
        //}
    }
}
