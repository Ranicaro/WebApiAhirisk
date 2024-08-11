using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblMetodologiaRiesgo
    {
        public int iIDMetodologiaRiesgo { get; set; }
        public int? iIDUsuarioInsercion { get; set; }
        public DateTime? dtFechaInsercion { get; set; }
        public bool? bActivo { get; set; }

        public virtual tblUsuarios tblUsuarioCreacionNavigation { get; set; }
    }
}
