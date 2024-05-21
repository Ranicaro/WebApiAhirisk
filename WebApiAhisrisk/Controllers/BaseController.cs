using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAhirisk.Controllers
{
    [Authorize]
    [ApiController]
    [ProducesResponseType(500)]
    [Route("[controller]/[action]")]
    //[ApiExplorerSettings(GroupName = "prozesslaw")]
    [Produces("application/json"), Consumes("application/json")]
    [ProducesResponseType(typeof(string), 400)]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public bool GetUserId(out int userId)
        {
            var userIdClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "iIDUsuario")?.Value;
            bool valid = int.TryParse(userIdClaim, out userId);

            return valid;
        }

        [NonAction]
        public bool GetEntityId(out int entityId)
        {
            var entityIdClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "iIDEntidad")?.Value;
            bool valid = int.TryParse(entityIdClaim, out entityId);

            return valid;
        }

        [NonAction]
        public bool GetLanguageId(out int languageId)
        {
            var languageIdClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "iIDIdioma")?.Value;
            bool valid = int.TryParse(languageIdClaim, out languageId);

            return valid;
        }

        [NonAction]
        public bool GetMonedaLocalId(out int monedaLocalId)
        {
            var monedaLocalIdClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "iIDEntidadMonedaLocal")?.Value;
            bool valid = int.TryParse(monedaLocalIdClaim, out monedaLocalId);

            return valid;
        }
        [NonAction]
        public bool GetPerfilId(out int perfilId)
        {
            var perfilIdClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "iIDPerfil")?.Value;
            bool valid = int.TryParse(perfilIdClaim, out perfilId);

            return valid;
        }
        [NonAction]
        public bool GetClaim(out int id, string name)
        {
            var claimId = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == name)?.Value;
            return int.TryParse(claimId, out id);
        }
    }
}
