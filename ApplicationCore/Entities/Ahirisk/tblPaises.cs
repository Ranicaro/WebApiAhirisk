using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblPaises
    {
        public int iIDPais { get; set; }
        public string? tCodigoSimple { get; set; }
        public string? tCodigoCompuesto { get; set; }
        public string? tCodigoNumero { get; set; }
        public string? tIndTelefonico { get; set; }
        public string? tNombrePais { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public bool? bActivo { get; set; }

        public virtual tblUsuarios tblUsuarioCreacionNavigation { get; set; }

    }
}
