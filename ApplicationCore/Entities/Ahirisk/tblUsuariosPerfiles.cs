using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblUsuariosPerfiles
    {
        public int iIDUsuarioPerfil { get; set; }
        public int? iIDUsuario { get; set; }
        public int? iIDPerfil { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public bool? bActivo { get; set; }

        public virtual tblPerfiles tblPerfilesPerfilNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioCreacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioModificacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInactivacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioUsuarioNavigation { get; set; }
    }
}
