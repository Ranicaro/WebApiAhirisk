using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApiAhirisk.Models;
using WebApiAhirisk.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebApiAhirisk.Models.Seguridad;
using Microsoft.Extensions.Configuration;
using WebApiAhirisk.Services;
using ApplicationCore.Interfaces;
using System.Security.Principal;
using ApplicationCore.Interfaces.Configuracion.Email;
using WebApiAhisrisk.Services;
using ApplicationCore.Entities.Ahirisk;

namespace WebApiAhirisk.Controllers
{
    public class AccountController : BaseController
    {
        #region Dependency

        private readonly DBAhiriskV1Context _context;
        public readonly string secretKey;
        public IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IEmailService _emailService;

        public AccountController(DBAhiriskV1Context context, ITokenGenerator tokenGenerator, IEmailService emailService)
        {
            _context = context;            
            _tokenGenerator = tokenGenerator;
            _emailService = emailService;
        }

        #endregion

        #region Servicios
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> PostLogin([Required] mLogin login)
        {
            try
            {
                var user = await _context.tblUsuarios
                    .Where(x => x.tEmail == login.tEmail && x.tPassword == login.tPassword
                    && x.bHabilitado == true && x.bActivo == true)
                    .FirstOrDefaultAsync();

                if(user == null)
                {
                    return BadRequest("Email o Contraseña incorrecta");
                }

                mToken mtoken = new()
                {
                    iIDUsuario = user.iIDUsuario.ToString(),
                    tEmail = user.tEmail,
                    tNombre = user.tPrimerNombre +" "+user.tPrimerApellido,
                    tUsuario = user.tUsuario
                };
                //var token = GenerateToken(mtoken);
                //var response = new { token };
                string token = null;
                //if (IdRequerimiento == null && IdAsignado == null)
                //{
                token = _tokenGenerator.CreateJwtSecurityToken(
                new Dictionary<string, string>
                {
                    { "id", user.iIDUsuario.ToString() },
                    { "email", user.tEmail },
                    {
                        "name",
                        user.tPrimerNombre +
                        (user.tSegundoNombre == null ? string.Empty : ' ' + user.tSegundoNombre) +
                        ' ' + user.tPrimerApellido +
                        (user.tSegundoApellido == null ? string.Empty : ' ' + user.tSegundoApellido)
                    },
                    { "idioma", "43" },
                    { "autenticacion", "1" }
                });
                return Ok(new LoginResponse
                {
                    Token = token.ToString(),
                    iIDUsuario = user.iIDUsuario
                });
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el servicio PostLogin ", ex);
                throw;
            }
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> DownloadPoliticasDeDatos()
        {
            try
            {
                var fileName = "ProtecciondeDatos.docx";
                var filePath = Path.Combine("C:\\Users\\Juan Maldonado\\OneDrive\\Escritorio\\AHIRISK\\soportesDescargables", fileName);

                   if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(fileStream, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el servicio de Descargar Documento de Politicas de Privacidad ", ex);
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostUpdateToken(Token token)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }

                //if (!await ValidarEntidad(iIDUsuario, token.iIDEntidad ?? 0))
                //    return BadRequest();
                //if (!await ValidarPerfil(iIDUsuario, token.iIDPerfil ?? 0))
                //    return BadRequest();

                //var user = _usuarioController.getInformacionUsuario(iIDUsuario);
                //if (token.iIDEntidad != 0)
                //{
                //    var monedaDefault = await _context.tblEntidadParametros.Where(x => x.iIDEntidad == token.iIDEntidad && x.iIDParametro == 8 && x.bActivo == true).Select(x => x.iValor).FirstOrDefaultAsync();
                //    UpsertClaim(User, "iIDEntidadMonedaLocal", monedaDefault);
                //}
                UpsertClaim(User, "iIDEntidad", token.iIDEntidad);
                UpsertClaim(User, "iIDPerfil", token.iIDPerfil);
                UpsertClaim(User, "timeExpire", token.timeExpire ?? 0);
                //UpsertClaim(User, "passwordExpire", user.Result.dtFechaCambioPassword);

                return Ok(new JwtSecurityTokenHandler().WriteToken(_tokenGenerator.UpdateJwtSecurityToken(User.Claims)));
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el Servicio PostUpdateToken", ex);
                throw;
            }           
        }
       
        [HttpGet, AllowAnonymous]
        public async Task<IEnumerable<MPasswordSetting>> PasswordSettings(int? iIDEntidad)
        {
            try
            {
                var parametrosPassword = await (from eps in _context.tblEntidadPasswordSettings
                                                join ps in _context.tblPasswordSettings on eps.iIDPasswordSetting equals ps.iIDPasswordSetting
                                                join psi in _context.tblPasswordSettingsIdiomas on ps.iIDPasswordSetting equals psi.iIDPasswordSetting
                                                where eps.iIDEntidad == 1 && eps.bActivo == true
                                                select new MPasswordSetting
                                                {
                                                    iIDPasswordSettingIdioma = psi.iIDPasswordSettingIdioma,
                                                    tDescripcion = psi.tSettingDescripcion,
                                                    iValorMinimo = eps.iValorMinimo
                                                }
                                 ).ToListAsync();
                var listaCondiciones = new List<MPasswordSetting>();

                foreach (MPasswordSetting ps in parametrosPassword)
                {
                    listaCondiciones.Add(ps);

                    if (ps.iIDPasswordSettingIdioma == 1)
                    {
                        ps.tDescripcionConcatenada = "Contener " + ps.iValorMinimo + " Letra(s) Mayúscula(s).";
                    }
                    else if (ps.iIDPasswordSettingIdioma == 2)
                    {
                        ps.tDescripcionConcatenada = "Contener " + ps.iValorMinimo + " Letra(s) Minúscula(s).";
                    }
                    else if (ps.iIDPasswordSettingIdioma == 3)
                    {
                        ps.tDescripcionConcatenada = "Contener " + ps.iValorMinimo + " Número(s).";
                    }
                    else if (ps.iIDPasswordSettingIdioma == 4)
                    {
                        ps.tDescripcionConcatenada = "Contener " + ps.iValorMinimo + " Caractér(es) Especial(es).";
                    }
                    else if (ps.iIDPasswordSettingIdioma == 5)
                    {
                        ps.tDescripcionConcatenada = "La contraseña no debe estar incluida en el usuario.";
                    }
                    else if (ps.iIDPasswordSettingIdioma == 6)
                    {
                        ps.tDescripcionConcatenada = "La contraseña no debe de haber sido utilizada últimamente.";
                    }
                    else if (ps.iIDPasswordSettingIdioma == 7)
                    {
                        ps.tDescripcionConcatenada = "La contraseña debe tener un tamaño mínimo de: " + ps.iValorMinimo + "caracteres.";
                    }
                }
                if (parametrosPassword.Count > 0)
                {
                    return listaCondiciones;
                }
                else
                {
                    return new List<MPasswordSetting>();
                }
            }
            catch (Exception ex)
            {
                GenericUtils.Log("AccountController: Error en el método de PasswordSetting ", ex);
                throw;
            }
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> PostEnviarCorreoRecuperarContrasena(MRecuperarContrasena mRecuperarContrasena)
        {
            try
            {
                var resValidarEmail = await ValidarEmailRecuperacionContrasena(mRecuperarContrasena.tEmail);

                if (resValidarEmail)
                {
                    Guid tContrasenna = Guid.NewGuid();
                    var tCodigoContrasenna = tContrasenna.ToString().Substring(0, 10);
                    var resEnviarCorreo = await EnviarCorreoRecuperacionContrasena(mRecuperarContrasena.tEmail, tCodigoContrasenna.ToString());
                    if(resEnviarCorreo == true)
                    {
                        var resCambiarContrasenaPorCodigo = await CambiarContrasenaPorCodigo(mRecuperarContrasena.tEmail, tCodigoContrasenna.ToString());
                    }
                }
                else
                {
                    return BadRequest("Este correo no se encuentra registrado, por favor intente nuevamente.");
                }

                return Ok("Se envió el código de recuperación de contraseña a tu correo electrónico.");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el Servicio PostEnviarCorreoRecuperarContraseña", ex);
                throw;
            }
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> PostCambiarContrasena(MRecuperarContrasena mRecuperarContrasena)
        {
            try
            {

                var resVerificacionCodigoContrasena = await VerificacionCodigoCambioContrasena(mRecuperarContrasena);

                if(resVerificacionCodigoContrasena == true)
                {
                    var resContrasenaActualizada = await ActualizarContrasena(mRecuperarContrasena);
                }

                return Ok("Se actualizó la contraseña de manera correcta.");

            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el Servicio PostActualizarContrasena", ex);
                throw;
            }
        }
        
        #endregion

        #region Metodos
        public static void UpsertClaim(IPrincipal currentPrincipal, string key, object value)
        {
            try
            {
                if (currentPrincipal.Identity is not ClaimsIdentity identity)
                    return;

                // check for existing claim and remove it
                var existingClaim = identity.FindFirst(key);
                if (existingClaim != null)
                    identity.RemoveClaim(existingClaim);

                // add new claim
                identity.AddClaim(new Claim(key, value.ToString()));
            }
            catch (Exception ex)
            {
                GenericUtils.Log("AccountController: Error en el Metodo UpsertClaim ", ex);
                throw;
            }
        }
        //public Task<bool> ValidarEntidad(int iIDUsuario, int iIDEntidad)
        //{
        //    //return _context.tblEntidadUsuario
        //    //    .Include(x => x.iIDEntidadNavigation)
        //    //    .Where(x => x.bActivo == true && x.iIDEntidadNavigation != null && x.iIDEntidadNavigation.bActivo)
        //    //    .AnyAsync(x => x.iIDUsuario == iIDUsuario && x.iIDEntidad == iIDEntidad);
        //}

        //public Task<bool> ValidarPerfil(int iIDUsuario, int iIDPerfil)
        //{
        //    //return _context.tblUsuariosPerfiles
        //    //    .Include(x => x.iIDPerfilNavigation)
        //    //    .Where(x => x.bActivo == true && x.iIDPerfilNavigation.bActivo)
        //    //    .AnyAsync(x => x.iIDUsuario == iIDUsuario && x.iIDPerfil == iIDPerfil);
        //}
        private async Task<bool> ValidarEmailRecuperacionContrasena(string? tEmail)
        {
            try
            {
                var res = await _context.tblUsuarios.AnyAsync(x => x.bActivo == true && x.tEmail == tEmail);
                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuarioController: Error en el metodo ValidarEmail ", ex);
                throw;
            }
        }
        public async Task<bool> EnviarCorreoRecuperacionContrasena(string tCorreo, string tCodigo)
        {
            try
            {
                string body = $@"
                               <html>
                                <head>
                                    <style>
                                        h1 {{
                                            color: rgb(20,79,84);
                                        }}
                                        p {{
                                            font-size: 18px;
                                            font-family: Latto, sans-serif;
                                            color: black
                                        }}
                                        .Recuerda-text {{
                                            font-size: 25px;
                                            font-family: Latto, sans-serif;                                          
                                            color: #289CA6;
                                            text-align: left;
                                        }}
                                        .Usuario-text {{
                                            font-size: 18px;
                                            font-family: Latto, sans-serif;                                           
                                            color: #289CA6;
                                            text-align: left;
                                        }}
                                    </style>
                                </head>
                                <body>
                                    <h1>¡Hola!</h1>
                                    <p>Este es tu codigo de recuperación de contraseña </p>
                                    <p>A continuación, te proporcionamos tus credenciales de inicio de sesión:</p>
                                    <p>Contraseña: <span class='Usuario-text'>{tCodigo}</span> </p>

                                    <p>Puedes cambiar tu contraseña en Ahirisk en el modulo de recuperación de contraseña.</p>
                                    <p>Si tienes problemas puedes comunicarte con la mesa de servicio</p>
                                </body>
                                </html>";

                await _emailService.SendAsync(body, "Codigo de recuperación de contraseña Ahirisk", new List<string> { tCorreo }, MimeKit.Text.TextFormat.Html);
                return true;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el método de EnviarCorreoRecuperarContrasenna", ex);
                return false;
            }
        }
        public async Task<bool> CambiarContrasenaPorCodigo(string tCorreo, string tCodigo)
        {
            try
            {

               tblUsuarios usuario = await _context.tblUsuarios.Where(x => x.tEmail == tCorreo && x.bActivo == true).FirstOrDefaultAsync();
               if(usuario != null)
                {
                    if (tCorreo != null && usuario.tEmail == tCorreo)
                    {
                        usuario.tPassword = tCodigo;
                    }

                    usuario.dtFechaModificacion = DateTime.UtcNow;

                    _context.Entry(usuario).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el método de CambiarContrasenaPorCodigo", ex);
                return false;
            }
        }
        public async Task<bool> VerificacionCodigoCambioContrasena(MRecuperarContrasena mRecuperarContrasena)
        {
            try
            {
                tblUsuarios usuario = await _context.tblUsuarios.Where(x => x.tEmail == mRecuperarContrasena.tEmail && x.bActivo == true).FirstOrDefaultAsync();
                if(usuario != null)
                {
                    if (mRecuperarContrasena.tEmail != null && usuario.tPassword == mRecuperarContrasena.tCodigoCambioPassword)
                    {
                        return true;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el método de VerificacionCodigoCambioContrasena", ex);
                return false;
            }
        }
        public async Task<bool> ActualizarContrasena(MRecuperarContrasena mRecuperarContrasena)
        {
            try
            {
                tblUsuarios usuario = await _context.tblUsuarios.Where(x => x.tEmail == mRecuperarContrasena.tEmail && x.bActivo == true).FirstOrDefaultAsync();
                if (usuario != null)
                {
                    if (mRecuperarContrasena.tEmail != null && usuario.tEmail == mRecuperarContrasena.tEmail)
                    {
                        usuario.tPassword = mRecuperarContrasena.tPassword;
                    }

                    usuario.dtFechaModificacion = DateTime.UtcNow;

                    _context.Entry(usuario).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el método de ActualizarContrasena", ex);
                return false;
            }
        }
        #endregion


    }
}
