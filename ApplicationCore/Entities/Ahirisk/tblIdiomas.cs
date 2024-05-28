using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblIdiomas
    {

        public tblIdiomas()
        {
            tblParametrosIdiomasNavigation = new HashSet<tblParametrosIdiomas>();
            tblPasswordSettingsIdiomasNavigation = new HashSet<tblPasswordSettingsIdiomas>();
        }

        public int iIDIdioma { get; set; }
        public string? tCodigo { get; set; }
        public string? tCodigoPais { get; set; }
        public string? tNombre { get; set; }
        public string? tPais { get; set; }
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
        public virtual ICollection<tblParametrosIdiomas> tblParametrosIdiomasNavigation { get; set; }
        public virtual ICollection<tblPasswordSettingsIdiomas> tblPasswordSettingsIdiomasNavigation { get; set; }
    }
}
