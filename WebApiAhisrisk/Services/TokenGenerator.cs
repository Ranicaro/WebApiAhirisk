using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace WebApiAhirisk.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        #region Dependency

        private readonly DBAhiriskV1Context _context;
        private readonly IConfiguration _configuration;

        public TokenGenerator(DBAhiriskV1Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        #endregion


        #region Metodos

        public JwtSecurityToken CreateJwtSecurityToken(IEnumerable<Claim> claims)
        {
            return UpdateJwtSecurityToken(claims);
        }

        //public async Task<JwtSecurityToken> CreateJwtSecurityToken(ISpSsoResult ssoResult)
        //{
        //    var user = await _context.TblUsuarios.FirstOrDefaultAsync(u => u.TEmail == ssoResult.UserID.ToString() && u.BActivo);
        //    if (user == null)
        //        return null;
        //    var userId = user?.Id.ToString();

        //    var claims = new List<Claim>
        //    {
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Sub, userId),
        //        new Claim("iIDUsuario", userId),
        //        new Claim(JwtRegisteredClaimNames.UniqueName, user.TUsuario),
        //        new Claim(JwtRegisteredClaimNames.Email, user.TEmail),
        //        new Claim(
        //            "name",
        //            user.TPrimerNombre +
        //            (user.TSegundoNombre == null ? string.Empty : ' ' + user.TSegundoNombre) +
        //            ' ' + user.TPrimerApellido +
        //            (user.TSegundoApellido == null ? string.Empty : ' ' + user.TSegundoApellido)
        //        ),
        //        new Claim("iIDTipoAutenticacion", "2"),
        //        new Claim("iIDIdioma", user.IIdidioma.ToString())
        //    };

        //    return UpdateJwtSecurityToken(claims);
        //}

        public string CreateJwtSecurityToken(Dictionary<string, string> dicionary)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, dicionary.FirstOrDefault(c => c.Key == "id").Value),
                new Claim("iIDUsuario", dicionary.FirstOrDefault(c => c.Key == "id").Value),
            };

            string value;
            if ((value = dicionary.FirstOrDefault(c => c.Key == "email").Value) != null)
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "user").Value) != null)
                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "name").Value) != null)
                claims.Add(new Claim("name", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "idioma").Value) != null)
                claims.Add(new Claim("iIDIdioma", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "autenticacion").Value) != null)
                claims.Add(new Claim("iIDTipoAutenticacion", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "iIDPerfil").Value) != null)
                claims.Add(new Claim("iIDPerfil", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "iIDEntidad").Value) != null)
                claims.Add(new Claim("iIDEntidad", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "timeExpire").Value) != null)
                claims.Add(new Claim("timeExpire", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "idMenu").Value) != null)
                claims.Add(new Claim("idMenu", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "bMenu").Value) != null)
                claims.Add(new Claim("bMenu", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "idRequerimientoExterno").Value) != null)
                claims.Add(new Claim("idRequerimientoExterno", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "idAsignado").Value) != null)
                claims.Add(new Claim("idAsignado", value));

            var jwtToken = UpdateJwtSecurityToken(claims);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }

        public JwtSecurityToken UpdateJwtSecurityToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            double timeExpire = 0;

            var timeExpireClaim = claims.FirstOrDefault(c => c.Type == "timeExpire");

            if (timeExpireClaim != null)
            {
                if (double.TryParse(timeExpireClaim.Value, out timeExpire))
                {
                    timeExpire = Convert.ToDouble(timeExpireClaim.Value);
                }
            }
            else
            {
                // Manejo de error: El claim "timeExpire" no se encontró en la colección de claims.
                //throw new ArgumentException("El claim 'timeExpire' no se encontró en la colección de claims.");
                timeExpire = 0;
            }

            if (timeExpire == 0 || timeExpire == null)
            {
                timeExpire = 60;
            }

            return new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(timeExpire),
                signingCredentials: credentials);
        }

        public string CreateJwtSecurityToken(Dictionary<string, string> dicionary, int hours)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, dicionary.FirstOrDefault(c => c.Key == "id").Value),
                new Claim("iIDUsuario", dicionary.FirstOrDefault(c => c.Key == "id").Value),
            };

            string value;
            if ((value = dicionary.FirstOrDefault(c => c.Key == "email").Value) != null)
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "user").Value) != null)
                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "name").Value) != null)
                claims.Add(new Claim("name", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "idioma").Value) != null)
                claims.Add(new Claim("iIDIdioma", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "autenticacion").Value) != null)
                claims.Add(new Claim("iIDTipoAutenticacion", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "iIDPerfil").Value) != null)
                claims.Add(new Claim("iIDPerfil", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "iIDEntidad").Value) != null)
                claims.Add(new Claim("iIDEntidad", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "idMenu").Value) != null)
                claims.Add(new Claim("idMenu", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "bMenu").Value) != null)
                claims.Add(new Claim("bMenu", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "idRequerimientoExterno").Value) != null)
                claims.Add(new Claim("idRequerimientoExterno", value));
            if ((value = dicionary.FirstOrDefault(c => c.Key == "idAsignado").Value) != null)
                claims.Add(new Claim("idAsignado", value));

            var jwtToken = UpdateJwtSecurityToken(claims, hours);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }

        public JwtSecurityToken UpdateJwtSecurityToken(IEnumerable<Claim> claims, int hours)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: credentials);
        }

        #endregion


    }
}
