using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblParametrosIdiomas
    {
        public int iIDParametrosIdiomas { get; set; }
        public int? iIDIdioma { get; set; }
        public int? iIDParametro { get; set; }
        public string? tParametroNombre { get; set; }
        public DateTime? dtFechaInsercion { get; set; }
        public int? iIDUsuarioInsercion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public bool bActivo { get; set; }

        public virtual tblIdiomas tblIdiomasNavigation { get; set; }
        public virtual tblParametros tblParametrosNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInsercionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioModificacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInactivacionNavigation { get; set; }
    }
}
