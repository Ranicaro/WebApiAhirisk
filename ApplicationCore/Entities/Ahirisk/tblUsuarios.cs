﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Ahirisk
{
    public class tblUsuarios
    {
        public tblUsuarios()
        {
           tblEntidadiIDUsarioCreacionNavigation = new HashSet<tblEntidad>();
           tblEntidadiIDUsarioModificacionNavigation = new HashSet<tblEntidad>();
           tblEntidadiIDUsarioInactivacionNavigation = new HashSet<tblEntidad>();

            tblEntidadPerfilesiIDUsarioCreacionNavigation = new HashSet<tblEntidadPerfiles>();
            tblEntidadPerfilesiIDUsarioModificacionNavigation = new HashSet<tblEntidadPerfiles>();
            tblEntidadPerfilesiIDUsarioInactivacionNavigation = new HashSet<tblEntidadPerfiles>();

            tblMenuiIDUsarioCreacionNavigation = new HashSet<tblMenu>();
            tblMenuiIDUsarioModificacionNavigation = new HashSet<tblMenu> ();
            tblMenuiIDUsarioInactivacionNavigation = new HashSet<tblMenu>();

            tblMenuPerfilesiIDUsarioCreacionNavigation = new HashSet<tblMenuPerfiles>();
            tblMenuPerfilesiIDUsarioModificacionNavigation = new HashSet<tblMenuPerfiles>();
            tblMenuPerfilesiIDUsarioInactivacionNavigation = new HashSet<tblMenuPerfiles>();

            tblPerfilesiIDUsarioCreacionNavigation = new HashSet<tblPerfiles>();
            tblPerfilesiIDUsarioModificacionNavigation = new HashSet<tblPerfiles>();
            tblPerfilesiIDUsarioInactivacionNavigation = new HashSet<tblPerfiles>();

            tblMultivaloresiIDUsarioCreacionNavigation = new HashSet<tblMultivalores>();
            tblMultivaloresiIDUsarioModificacionNavigation = new HashSet<tblMultivalores>();
            tblMultivaloresiIDUsarioInactivacionNavigation = new HashSet<tblMultivalores>();

            tblMultivaloresIdiomasiIDUsarioCreacionNavigation = new HashSet<tblMultivaloresIdiomas>();
            tblMultivaloresIdiomasiIDUsarioModificacionNavigation = new HashSet<tblMultivaloresIdiomas>();
            tblMultivaloresIdiomasiIDUsarioInactivacionNavigation = new HashSet<tblMultivaloresIdiomas>();

            tblIdiomasiIDUsarioCreacionNavigation = new HashSet<tblIdiomas>();
            tblIdiomasiIDUsarioModificacionNavigation = new HashSet<tblIdiomas>();
            tblIdiomasiIDUsarioInactivacionNavigation = new HashSet<tblIdiomas>();

            tblEntidadUsuarioiIDUsarioCreacionNavigation = new HashSet<tblEntidadUsuario>();
            tblEntidadUsuarioiIDUsarioModificacionNavigation = new HashSet<tblEntidadUsuario>();
            tblEntidadUsuarioiIDUsarioInactivacionNavigation = new HashSet<tblEntidadUsuario>();
            tblEntidadUsuarioiIDUsarioUsuarioNavigation = new HashSet<tblEntidadUsuario>();

            tblUsuariosPerfilesiIDUsarioCreacionNavigation = new HashSet<tblUsuariosPerfiles>();
            tblUsuariosPerfilesiIDUsarioModificacionNavigation = new HashSet<tblUsuariosPerfiles>();
            tblUsuariosPerfilesiIDUsarioInactivacionNavigation = new HashSet<tblUsuariosPerfiles>();
            tblUsuariosPerfilesiIDUsarioUsuarioNavigation = new HashSet<tblUsuariosPerfiles>();

            tblEntidadParametrosUsuarioCreacionNavigation = new HashSet<tblEntidadParametros>();
            tblEntidadParametrosUsuarioModificacionNavigation = new HashSet<tblEntidadParametros>();
            tblEntidadParametrosUsuarioInactivacionNavigation = new HashSet<tblEntidadParametros>();

            tblParametrosUsuarioCreacionNavigation = new HashSet<tblParametros>();
            tblParametrosUsuarioModificacionNavigation = new HashSet<tblParametros>();
            tblParametrosUsuarioInactivacionNavigation = new HashSet<tblParametros>();

            tblParametrosIdiomasUsuarioCreacionNavigation = new HashSet<tblParametrosIdiomas>();
            tblParametrosIdiomasUsuarioModificacionNavigation = new HashSet<tblParametrosIdiomas>();
            tblParametrosIdiomasUsuarioInactivacionNavigation = new HashSet<tblParametrosIdiomas>();

            tblEntidadPasswordSettingsUsuarioCreacionNavigation = new HashSet<tblEntidadPasswordSettings>();
            tblEntidadPasswordSettingsUsuarioModificacionNavigation = new HashSet<tblEntidadPasswordSettings>();
            tblEntidadPasswordSettingsUsuarioInactivacionNavigation = new HashSet<tblEntidadPasswordSettings>();

            tblPasswordSettingsUsuarioCreacionNavigation = new HashSet<tblPasswordSettings>();
            tblPasswordSettingsUsuarioModificacionNavigation = new HashSet<tblPasswordSettings>();
            tblPasswordSettingsUsuarioInactivacionNavigation = new HashSet<tblPasswordSettings>();

            tblPasswordSettingsIdiomasUsuarioCreacionNavigation = new HashSet<tblPasswordSettingsIdiomas>();
            tblPasswordSettingsIdiomasUsuarioModificacionNavigation = new HashSet<tblPasswordSettingsIdiomas>();
            tblPasswordSettingsIdiomasUsuarioInactivacionNavigation = new HashSet<tblPasswordSettingsIdiomas>();

            tblEmailNotificacionesUsuarioCreacionNavigation = new HashSet<tblEmailNotificaciones>();
            tblEmailNotificacionesUsuarioModificacionNavigation = new HashSet<tblEmailNotificaciones>();
            tblEmailNotificacionesUsuarioInactivacionNavigation = new HashSet<tblEmailNotificaciones>();

            tblProcesosUsuarioCreacionNavigation = new HashSet<tblProcesos>();
            tblProcesosUsuarioModificacionNavigation = new HashSet<tblProcesos>();
            tblProcesosUsuarioInactivacionNavigation = new HashSet<tblProcesos>();

            tblProcesosPaisIdiomaUsuarioCreacionNavigation = new HashSet<tblProcesosPaisIdioma>();
            tblProcesosPaisIdiomaUsuarioModificacionNavigation = new HashSet<tblProcesosPaisIdioma>();
            tblProcesosPaisIdiomaUsuarioInactivacionNavigation = new HashSet<tblProcesosPaisIdioma>();

            tblTipoProcesosUsuarioCreacionNavigation = new HashSet<tblTipoProcesos>();

            tblTipoProcesosPaisIdiomaUsuarioCreacionNavigation = new HashSet<tblTipoProcesosPaisIdioma>();
            tblTipoProcesosPaisIdiomaUsuarioModificacionNavigation = new HashSet<tblTipoProcesosPaisIdioma>();
            tblTipoProcesosPaisIdiomaUsuarioInactivacionNavigation = new HashSet<tblTipoProcesosPaisIdioma>();

            tblProductosUsuarioCreacionNavigation = new HashSet<tblProductos>();
            tblProductosUsuarioModificacionNavigation = new HashSet<tblProductos>();
            tblProductosUsuarioInactivacionNavigation = new HashSet<tblProductos>();

            tblPaisesUsuarioCreacionNavigation = new HashSet<tblPaises>();
            tblPaisesUsuarioModificacionNavigation = new HashSet<tblPaises>();
            tblPaisesUsuarioInactivacionNavigation = new HashSet<tblPaises>();

            tblOrganismosControlUsuarioCreacionNavigation = new HashSet<tblOrganismosControl>();
            tblOrganismosControlUsuarioModificacionNavigation = new HashSet<tblOrganismosControl>();
            tblOrganismosControlUsuarioInactivacionNavigation = new HashSet<tblOrganismosControl>();

            tblMetodologiaRiesgoUsuarioCreacionNavigation = new HashSet<tblMetodologiaRiesgo>();

            tblMetodologiaRiesgoPaisIdiomaUsuarioCreacionNavigation = new HashSet<tblMetodologiaRiesgoPaisIdioma>();
            tblMetodologiaRiesgoPaisIdiomaUsuarioModificacionNavigation = new HashSet<tblMetodologiaRiesgoPaisIdioma>();
            tblMetodologiaRiesgoPaisIdiomaUsuarioInactivacionNavigation = new HashSet<tblMetodologiaRiesgoPaisIdioma>();

            tblFactoresRiesgoUsuarioCreacionNavigation = new HashSet<tblFactoresRiesgo>();
            tblFactoresRiesgoUsuarioModificacionNavigation = new HashSet<tblFactoresRiesgo>();
            tblFactoresRiesgoUsuarioInactivacionNavigation = new HashSet<tblFactoresRiesgo>();

            tblFactoresRiesgoPaisIdiomaUsuarioCreacionNavigation = new HashSet<tblFactoresRiesgoPaisIdioma>();
            tblFactoresRiesgoPaisIdiomaUsuarioModificacionNavigation = new HashSet<tblFactoresRiesgoPaisIdioma>();
            tblFactoresRiesgoPaisIdiomaUsuarioInactivacionNavigation = new HashSet<tblFactoresRiesgoPaisIdioma>();

            tblEntidadOrganismosControlUsuarioCreacionNavigation = new HashSet<tblEntidadOrganismosControl>();
            tblEntidadOrganismosControlUsuarioModificacionNavigation = new HashSet<tblEntidadOrganismosControl>();
            tblEntidadOrganismosControlUsuarioInactivacionNavigation = new HashSet<tblEntidadOrganismosControl>();
        }

        public int iIDUsuario { get; set; }
        public string? tPrimerNombre { get; set; }
        public string? tSegundoNombre { get; set; }
        public string? tPrimerApellido { get; set; }
        public string? tSegundoApellido { get; set; }
        public string? tUsuario { get; set; }
        public string? tEmail { get; set; }
        public string? tPassword { get; set; }
        public string? tConfirmarEmail { get; set; }
        public bool? bActivo { get; set; }
        public bool? bHabilitado { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public int? iIDSubTablaTipoDoc { get; set; }
        public string? tIDValorTipoDoc { get; set; }
        public string? tNumDoc { get; set; }



        public virtual tblMultivalores tblMultivaloresTipoDocNavigation { get; set; }

        public virtual ICollection<tblEntidad> tblEntidadiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidad> tblEntidadiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidad> tblEntidadiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblEntidadPerfiles> tblEntidadPerfilesiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidadPerfiles> tblEntidadPerfilesiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidadPerfiles> tblEntidadPerfilesiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMenu> tblMenuiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMenu> tblMenuiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMenu> tblMenuiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMenuPerfiles> tblMenuPerfilesiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMenuPerfiles> tblMenuPerfilesiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMenuPerfiles> tblMenuPerfilesiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblPerfiles> tblPerfilesiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblPerfiles> tblPerfilesiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblPerfiles> tblPerfilesiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMultivalores> tblMultivaloresiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMultivalores> tblMultivaloresiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMultivalores> tblMultivaloresiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMultivaloresIdiomas> tblMultivaloresIdiomasiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMultivaloresIdiomas> tblMultivaloresIdiomasiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMultivaloresIdiomas> tblMultivaloresIdiomasiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblIdiomas> tblIdiomasiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblIdiomas> tblIdiomasiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblIdiomas> tblIdiomasiIDUsarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioiIDUsarioInactivacionNavigation { get; set; }
        public virtual ICollection<tblEntidadUsuario> tblEntidadUsuarioiIDUsarioUsuarioNavigation { get; set; }

        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesiIDUsarioCreacionNavigation { get; set; }
        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesiIDUsarioModificacionNavigation { get; set; }
        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesiIDUsarioInactivacionNavigation { get; set; }
        public virtual ICollection<tblUsuariosPerfiles> tblUsuariosPerfilesiIDUsarioUsuarioNavigation { get; set; }

        public virtual ICollection<tblEntidadParametros> tblEntidadParametrosUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidadParametros> tblEntidadParametrosUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidadParametros> tblEntidadParametrosUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblParametros> tblParametrosUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblParametros> tblParametrosUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblParametros> tblParametrosUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblParametrosIdiomas> tblParametrosIdiomasUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblParametrosIdiomas> tblParametrosIdiomasUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblParametrosIdiomas> tblParametrosIdiomasUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblEntidadPasswordSettings> tblEntidadPasswordSettingsUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidadPasswordSettings> tblEntidadPasswordSettingsUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidadPasswordSettings> tblEntidadPasswordSettingsUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblPasswordSettings> tblPasswordSettingsUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblPasswordSettings> tblPasswordSettingsUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblPasswordSettings> tblPasswordSettingsUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblPasswordSettingsIdiomas> tblPasswordSettingsIdiomasUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblPasswordSettingsIdiomas> tblPasswordSettingsIdiomasUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblPasswordSettingsIdiomas> tblPasswordSettingsIdiomasUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblEmailNotificaciones> tblEmailNotificacionesUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEmailNotificaciones> tblEmailNotificacionesUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEmailNotificaciones> tblEmailNotificacionesUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblProcesos> tblProcesosUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblProcesos> tblProcesosUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblProcesos> tblProcesosUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblProcesosPaisIdioma> tblProcesosPaisIdiomaUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblProcesosPaisIdioma> tblProcesosPaisIdiomaUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblProcesosPaisIdioma> tblProcesosPaisIdiomaUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblTipoProcesos> tblTipoProcesosUsuarioCreacionNavigation { get; set; }

        public virtual ICollection<tblTipoProcesosPaisIdioma> tblTipoProcesosPaisIdiomaUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblTipoProcesosPaisIdioma> tblTipoProcesosPaisIdiomaUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblTipoProcesosPaisIdioma> tblTipoProcesosPaisIdiomaUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblProductos> tblProductosUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblProductos> tblProductosUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblProductos> tblProductosUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblPaises> tblPaisesUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblPaises> tblPaisesUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblPaises> tblPaisesUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblOrganismosControl> tblOrganismosControlUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblOrganismosControl> tblOrganismosControlUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblOrganismosControl> tblOrganismosControlUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblMetodologiaRiesgo> tblMetodologiaRiesgoUsuarioCreacionNavigation { get; set; }

        public virtual ICollection<tblMetodologiaRiesgoPaisIdioma> tblMetodologiaRiesgoPaisIdiomaUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblMetodologiaRiesgoPaisIdioma> tblMetodologiaRiesgoPaisIdiomaUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblMetodologiaRiesgoPaisIdioma> tblMetodologiaRiesgoPaisIdiomaUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblFactoresRiesgo> tblFactoresRiesgoUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblFactoresRiesgo> tblFactoresRiesgoUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblFactoresRiesgo> tblFactoresRiesgoUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblFactoresRiesgoPaisIdioma> tblFactoresRiesgoPaisIdiomaUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblFactoresRiesgoPaisIdioma> tblFactoresRiesgoPaisIdiomaUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblFactoresRiesgoPaisIdioma> tblFactoresRiesgoPaisIdiomaUsuarioInactivacionNavigation { get; set; }

        public virtual ICollection<tblEntidadOrganismosControl> tblEntidadOrganismosControlUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tblEntidadOrganismosControl> tblEntidadOrganismosControlUsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tblEntidadOrganismosControl> tblEntidadOrganismosControlUsuarioInactivacionNavigation { get; set; }
    }
}
