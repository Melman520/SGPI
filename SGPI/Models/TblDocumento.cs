using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblDocumento
    {
        public TblDocumento()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int Iddoc { get; set; }
        public string? TipoDocumento { get; set; }

        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
