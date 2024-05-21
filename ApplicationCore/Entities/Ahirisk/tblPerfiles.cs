using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblPerfiles
    {
        public tblPerfiles() 
        {
            tblEntidadPerfilesNavigation = new HashSet<tblEntidadPerfiles>();
            tblMenuPerfilesNavigation = new HashSet<tblMenuPerfiles>();
            tblUsuariosPerfilesNavigation = new HashSet<tblUsuariosPerfiles>();
        }

        public int iIDPerfil { get; set; }
        public string? tDescripcion { get; set; }
        public string? tDefinicion { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public bool? bActivo { get; set; }


        public virtual tblUsuarios iIDUsuarioCreacionNavigation { get; set; }
        public virtual tblUsuarios iIDUsuarioModificacionNavigation { get; set; }
        public virtual tblUsuarios iIDUsuarioInactivacionNavigation { get; set; }
        public virtual ICollection<tblEntidadPerfiles> tblEntidadPerfilesNavigation { get; set; }
        public virtual ICollection<tblMenuPerfiles> tblMenuPerfilesNavigation { get; set; }
        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesNavigation { get; set; }

    }
}
