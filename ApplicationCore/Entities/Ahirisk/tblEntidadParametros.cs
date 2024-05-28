using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblEntidadParametros
    {
        public int iIDEntidadParametro { get; set; }
        public int? iIDEntidad { get; set; }
        public int? iIDParametro { get; set; }
        public int? iTipoParametro { get; set; }
        public string? tCodigo { get; set; }
        public string? tDescripcion { get; set; }
        public decimal? dValor { get; set; }
        public DateTime? dtValor { get; set; }
        public bool? bValor { get; set; }
        public string? tValor { get; set; }
        public int? iValor { get; set; }
        public DateTime? dtFechaInsercion { get; set; }
        public int? iIDUsuarioInsercion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public bool bActivo { get; set; }

        public virtual tblEntidad tblEntidadNavigation { get; set; }
        public virtual tblParametros tblParametrosNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInsercionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioModificacionNavigation { get; set; }
        public virtual tblUsuarios tblUsuarioInactivacionNavigation { get; set; }
    }
}
