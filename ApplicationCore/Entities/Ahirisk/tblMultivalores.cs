using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblMultivalores
    {
        public tblMultivalores() 
        {
            tblEntidadTipoDocNavigation = new HashSet<tblEntidad>();
            tblEntidadRegimenNavigation = new HashSet<tblEntidad>();
            tblUsuariosTipoDocNavigation = new HashSet<tblUsuarios>();
            tblMultivaloresIdiomasNavigation = new HashSet<tblMultivaloresIdiomas>();
        }
        public int iIDSubTabla { get; set; }
        public string? tSubTabla { get; set; }
        public string? tIDValor { get; set; }
        public int? iOrden { get; set; }
        public string? tComentario { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public bool? bActivo { get; set; }


        public virtual tblUsuarios tblUsuariosCreacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuariosModificacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuariosInactivacionNavigation { get; set; }
        public virtual ICollection<tblUsuarios> tblUsuariosTipoDocNavigation { get; set; }
        public virtual ICollection<tblEntidad> tblEntidadTipoDocNavigation { get; set; }
        public virtual ICollection<tblEntidad> tblEntidadRegimenNavigation { get; set; }
        public virtual ICollection<tblMultivaloresIdiomas> tblMultivaloresIdiomasNavigation { get; set; }

    }
}
