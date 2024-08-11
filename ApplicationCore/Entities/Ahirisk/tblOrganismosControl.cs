using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblOrganismosControl
    {
        public int iIDOrganismoControl { get; set; }
        public int? iIDPais { get; set; }
        public string? tSiglaOrganismo { get; set; }
        public string? tNombreOrganismo { get; set; }
        public int? iIDUsuarioInsercion { get; set; }
        public DateTime? dtFechaInsercion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public bool? bActivo { get; set; }

        public virtual tblUsuarios tblUsuarioCreacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioModificacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInactivacionNavigation { get; set; }
    }
}
