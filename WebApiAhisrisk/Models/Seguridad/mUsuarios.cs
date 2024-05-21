using System.Collections;
using WebApiAhisrisk.Models.Seguridad;

namespace WebApiAhirisk.Models.Seguridad
{
    public class mUsuarios
    {
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
        public DateTime? dtFechaModificacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
    }

    public class mCrearUsuario
    {
        public int? iIDUsuario { get; set; }
        public string? tPrimerNombre { get; set; }
        public string? tSegundoNombre { get; set; }
        public string? tPrimerApellido { get; set; }
        public string? tSegundoApellido { get; set; }
        public string? tUsuario { get; set; }
        public string? tEmail { get; set; }
        public string? tPassword { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public bool? bActivo { get; set; }
        public List<mPerfil>? ListaPerfil { get; set; }
    }
    public class mUsuarioEntidad
    {
        public int? iIDUsuario { get; set; }
        public int? iIDEntidad { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
    }
}
