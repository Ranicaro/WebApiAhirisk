using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblEntidad
    {
        public tblEntidad()
        {
            tblEntidadPerfilesNavigation = new HashSet<tblEntidadPerfiles>();
            tblEntidadUsuarioNavigation = new HashSet<tblEntidadUsuario>();
        }
        public int iIDEntidad { get; set; }
        public int iIDSubTablaTipoDoc { get; set; }
        public string tIDValorTipoDoc { get; set; }
        public string tNumeroIdentificacion { get; set; }
        public string? tDigitoVerificacion { get; set; }
        public string tPrimerNombre { get; set; }
        public string? tSegundoNombre { get; set; }
        public string tPrimerApellido { get; set; }
        public string? tSegundoApellido { get; set; }
        public string? tRazonSocial { get; set; }
        public string? tNombreEntidad { get; set; }
        public int? iIDSubTablaRegimen { get; set; }
        public string? tIDValorRegimen { get; set; }       
        public string? tLogo { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public bool? bActivo { get; set; }


        public virtual tblUsuarios tblUsuarioCreacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioModificacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInactivacionNavigation { get; set; }
        public virtual tblMultivalores tblMultivaloresTipoDocNavigation { get; set; }
        public virtual tblMultivalores tblMultivaloresRegimenNavigation { get; set; }
        public virtual ICollection<tblEntidadPerfiles> tblEntidadPerfilesNavigation { get; set; }
        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioNavigation { get; set; }


    }
}
