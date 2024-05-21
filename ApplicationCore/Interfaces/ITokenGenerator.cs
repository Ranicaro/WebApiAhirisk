using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ITokenGenerator
    {
        JwtSecurityToken CreateJwtSecurityToken(IEnumerable<Claim> claims);
        //Task<JwtSecurityToken> CreateJwtSecurityToken(ISpSsoResult ssoResult);
        //string CreateJwtSecurityToken(Areas.UberLaw.Models.User user);
        //JwtSecurityToken CreateJwtSecurityToken(Entities.Solicitudes.Usuario user);
        JwtSecurityToken UpdateJwtSecurityToken(IEnumerable<Claim> claims);
        string CreateJwtSecurityToken(Dictionary<string, string> dictionary);
        string CreateJwtSecurityToken(Dictionary<string, string> dictionary, int numero);
    }
}
