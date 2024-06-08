namespace WebApiAhirisk.Models
{
    public class mLogin
    {
        public string tEmail { get; set; } 
        public string tPassword { get; set; }
    }
    public class mToken
    {
        public string iIDUsuario { get; set; }
        public string tEmail { get; set;}
        public string tNombre { get; set; }
        public string tUsuario { get; set; }

    }
    public class LoginResponse
    {
        public int iIDUsuario { get; set; }
        public string Token { get; set; }

    }
    public class Token
    {
        public int? iIDEntidad { get; set; }
        public int? iIDPerfil { get; set; }
        public int? timeExpire { get; set; }
    }
    public class MPasswordSetting
    {
        public int? iIDPasswordSettingIdioma { get; set; }
        public string? tDescripcion { get; set; }
        public int? iValorMinimo { get; set; }
        public string? tDescripcionConcatenada { get; set; }
    }
}
