using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblUsuarios
    {
        public tblUsuarios()
        {
           tblEntidadiIDUsarioCreacionNavigation = new HashSet<tblEntidad>();
           tblEntidadiIDUsarioModificacionNavigation = new HashSet<tblEntidad>();
           tblEntidadiIDUsarioInactivacionNavigation = new HashSet<tblEntidad>();

            tblEntidadPerfilesiIDUsarioCreacionNavigation = new HashSet<tblEntidadPerfiles>();
            tblEntidadPerfilesiIDUsarioModificacionNavigation = new HashSet<tblEntidadPerfiles>();
            tblEntidadPerfilesiIDUsarioInactivacionNavigation = new HashSet<tblEntidadPerfiles>();

            tblMenuiIDUsarioCreacionNavigation = new HashSet<tblMenu>();
            tblMenuiIDUsarioModificacionNavigation = new HashSet<tblMenu> ();
            tblMenuiIDUsarioInactivacionNavigation = new HashSet<tblMenu>();

            tblMenuPerfilesiIDUsarioCreacionNavigation = new HashSet<tblMenuPerfiles>();
            tblMenuPerfilesiIDUsarioModificacionNavigation = new HashSet<tblMenuPerfiles>();
            tblMenuPerfilesiIDUsarioInactivacionNavigation = new HashSet<tblMenuPerfiles>();

            tblPerfilesiIDUsarioCreacionNavigation = new HashSet<tblPerfiles>();
            tblPerfilesiIDUsarioModificacionNavigation = new HashSet<tblPerfiles>();
            tblPerfilesiIDUsarioInactivacionNavigation = new HashSet<tblPerfiles>();

            tblMultivaloresiIDUsarioCreacionNavigation = new HashSet<tblMultivalores>();
            tblMultivaloresiIDUsarioModificacionNavigation = new HashSet<tblMultivalores>();
            tblMultivaloresiIDUsarioInactivacionNavigation = new HashSet<tblMultivalores>();

            tblMultivaloresIdiomasiIDUsarioCreacionNavigation = new HashSet<tblMultivaloresIdiomas>();
            tblMultivaloresIdiomasiIDUsarioModificacionNavigation = new HashSet<tblMultivaloresIdiomas>();
            tblMultivaloresIdiomasiIDUsarioInactivacionNavigation = new HashSet<tblMultivaloresIdiomas>();

            tblIdiomasiIDUsarioCreacionNavigation = new HashSet<tblIdiomas>();
            tblIdiomasiIDUsarioModificacionNavigation = new HashSet<tblIdiomas>();
            tblIdiomasiIDUsarioInactivacionNavigation = new HashSet<tblIdiomas>();

            tblEntidadUsuarioiIDUsarioCreacionNavigation = new HashSet<tblEntidadUsuario>();
            tblEntidadUsuarioiIDUsarioModificacionNavigation = new HashSet<tblEntidadUsuario>();
            tblEntidadUsuarioiIDUsarioInactivacionNavigation = new HashSet<tblEntidadUsuario>();
            tblEntidadUsuarioiIDUsarioUsuarioNavigation = new HashSet<tblEntidadUsuario>();

            tblUsuariosPerfilesiIDUsarioCreacionNavigation = new HashSet<tblUsuariosPerfiles>();
            tblUsuariosPerfilesiIDUsarioModificacionNavigation = new HashSet<tblUsuariosPerfiles>();
            tblUsuariosPerfilesiIDUsarioInactivacionNavigation = new HashSet<tblUsuariosPerfiles>();
            tblUsuariosPerfilesiIDUsarioUsuarioNavigation = new HashSet<tblUsuariosPerfiles>();
        }

        public int iIDUsuario { get; set; }
        public string? tPrimerNombre { get; set; }
        public string? tSegundoNombre { get; set; }
        public string? tPrimerApellido { get; set; }
        public string? tSegundoApellido { get; set; }
        public string? tUsuario { get; set; }
        public string? tEmail { get; set; }
        public string? tPassword { get; set; }
        public string? tConfirmarEmail { get; set; }
        public bool? bActivo { get; set; }
        public bool? bHabilitado { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public int? iIDSubTablaTipoDoc { get; set; }
        public string? tIDValorTipoDoc { get; set; }
        public string? tNumDoc { get; set; }



        public virtual tblMultivalores tblMultivaloresTipoDocNavigation { get; set; }

        public virtual ICollection<tblEntidad> tblEntidadiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidad> tblEntidadiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidad> tblEntidadiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblEntidadPerfiles> tblEntidadPerfilesiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidadPerfiles> tblEntidadPerfilesiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidadPerfiles> tblEntidadPerfilesiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMenu> tblMenuiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMenu> tblMenuiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMenu> tblMenuiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMenuPerfiles> tblMenuPerfilesiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMenuPerfiles> tblMenuPerfilesiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMenuPerfiles> tblMenuPerfilesiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblPerfiles> tblPerfilesiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblPerfiles> tblPerfilesiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblPerfiles> tblPerfilesiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMultivalores> tblMultivaloresiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMultivalores> tblMultivaloresiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMultivalores> tblMultivaloresiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMultivaloresIdiomas> tblMultivaloresIdiomasiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMultivaloresIdiomas> tblMultivaloresIdiomasiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMultivaloresIdiomas> tblMultivaloresIdiomasiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblIdiomas> tblIdiomasiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblIdiomas> tblIdiomasiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblIdiomas> tblIdiomasiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioiIDUsarioInactivacionNavigation { get; set; }
        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioiIDUsarioUsuarioNavigation { get; set; }

        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesiIDUsarioInactivacionNavigation { get; set; }
        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesiIDUsarioUsuarioNavigation { get; set; }

    }
}
