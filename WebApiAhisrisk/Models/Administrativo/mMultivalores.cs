using ApplicationCore.Entities.Ahirisk;

namespace WebApiAhirisk.Models.Administrativo
{
    public class MMultivaloresIdiomas
    {
        public int? iIDMultivaloresIdioma {  get; set; }  
        public int? iIDIdioma { get; set; }
        public int? iIDSubTabla { get; set; }   
        public string? tIDValor { get; set; }
        public string? tDescripcionValor { get; set; } 
        public DateTime? dtFechaCreacion { get; set;}
        public int? iIDUsuarioCreacion { get; set; }
        public bool? bActivo {  get; set; }
    }
}
