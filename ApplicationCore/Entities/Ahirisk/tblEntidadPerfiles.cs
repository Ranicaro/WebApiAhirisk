using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblEntidadPerfiles
    {

        public int iIDEntidadPerfil { get; set; }
        public int? iIDEntidad { get; set; }
        public bool? bHeredaPerfil { get; set; }
        public int iIDPerfil { get; set; }
        public string? tDescripcion { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public bool? bActivo { get; set; }

        public virtual tblUsuarios tblUsuarioCreacionNavigation {get;set;}
        public virtual tblUsuarios tblUsuarioModificacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInactivacionNavigation { get; set; }
        public virtual tblPerfiles tblPerfilesNavigation { get; set; }
        public virtual tblEntidad tblEntidadNavigation { get; set; }

    }
}
