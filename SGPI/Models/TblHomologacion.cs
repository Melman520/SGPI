using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblHomologacion
    {
        public int Idhomologacion { get; set; }
        public int? Idestudiante { get; set; }
        public int? Idprograma { get; set; }
        public int? IdtipoHomologacion { get; set; }
        public string? PerdiodoAcademico { get; set; }
        public int? Idasignatura { get; set; }
        public string? CodigoHomologacion { get; set; }
        public string? NomAsigHomologacion { get; set; }
        public int? CreditosHomologacion { get; set; }
        public double? Nota { get; set; }

        public virtual TblAsignatura? IdasignaturaNavigation { get; set; }
        public virtual TblEstudiante? IdestudianteNavigation { get; set; }
        public virtual TblPrograma? IdprogramaNavigation { get; set; }
        public virtual TblTipoHomologacion? IdtipoHomologacionNavigation { get; set; }
    }
}
