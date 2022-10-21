using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblTipoHomologacion
    {
        public TblTipoHomologacion()
        {
            TblHomologacions = new HashSet<TblHomologacion>();
        }

        public int IdtipoHomologacion { get; set; }
        public string? TipoHomologacion { get; set; }

        public virtual ICollection<TblHomologacion> TblHomologacions { get; set; }
    }
}
