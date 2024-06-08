using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblMultivaloresIdiomas
    {
        public int iIDMultivaloresIdioma { get; set; }
        public int? iIDIdioma { get; set; }
        public int? iIDSubTabla { get; set; }
        public string? tIDValor { get; set; }
        public string? tDescripcionValor { get; set; }        
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
        public virtual tblMultivalores tblMultivaloresNavigation { get; set; }
    }
}
