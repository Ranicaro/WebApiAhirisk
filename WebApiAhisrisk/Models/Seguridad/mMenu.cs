namespace WebApiAhisrisk.Models.Seguridad
{
    public class mMenu
    {
        public int iIDMenu { get; set; }
        public string? tDescripcion { get; set; }
        public int? iIDPadre { get; set; }
        public int? iPosicionPadre { get; set; }
        public int? iPosicion { get; set; }
        public string? tUrl { get; set; }
        public string? tIcono { get; set; }
        public string? tDefinicion { get; set; }       
        public bool? bVisible { get; set; }
        public bool? bActivo { get; set; }
    }
    public class mMenuPerfiles
    {
        public int? iIDMenuPerfil { get; set; }
        public int? iIDPerfil { get; set; }
        public string? tPerfil { get; set; }
        public int? iIDMenu { get; set; }
        public string? tMenu { get; set; }
        public int? iIDUsuarioCreacion { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public int? iIDUsuarioModificacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public int? iIDUsuarioInactivacion { get; set; }
        public DateTime? dtFechaInactivacion { get; set; }
        public bool? bActivo { get; set; }
    }

    public class mMenuLista
    {
        public int? id { get; set; }
        public string? title { get; set; }
        public int? posicion { get; set; }
        public string? link { get; set; }
        public string? icon { get; set; }
        public mMenuLista? children { get; set; }

    }
}
