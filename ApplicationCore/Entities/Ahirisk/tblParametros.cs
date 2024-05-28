using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblParametros
    {

        public tblParametros()
        {
            tblEntidadParametrosNavigation = new HashSet<tblEntidadParametros>();
            tblParametrosIdiomasNavigation = new HashSet<tblParametrosIdiomas>();
        }

        public int iIDParametro { get; set; }
        public DateTime? dtFechaInsercion { get; set; }
        public int? iIDUsuarioInsercion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public bool bActivo { get; set; }

        public virtual tblUsuarios tblUsuarioInsercionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioModificacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInactivacionNavigation { get; set; }
        public virtual ICollection<tblEntidadParametros> tblEntidadParametrosNavigation { get; set; }
        public virtual ICollection<tblParametrosIdiomas> tblParametrosIdiomasNavigation { get; set; }
    }
}
