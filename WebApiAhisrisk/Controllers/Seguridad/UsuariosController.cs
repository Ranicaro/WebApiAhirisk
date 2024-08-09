using ApplicationCore.Entities.Ahirisk;
using ApplicationCore.Interfaces.Configuracion.Email;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WebApiAhirisk.Models.Seguridad;
using WebApiAhirisk.Utils;
using WebApiAhisrisk.Models.Seguridad;

namespace WebApiAhirisk.Controllers.Seguridad
{
    public class UsuariosController : BaseController
    {
        #region Dependency
        private readonly IEmailService _emailService;
        private readonly DBAhiriskV1Context _context;

        public UsuariosController(DBAhiriskV1Context context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        #endregion

        #region Services

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> PostCrearUsuario(mCrearUsuario usuario)
        {
            try
            {
                //if (!GetUserId(out int iIDUsuario))
                //{
                //    return Unauthorized();
                //}

                //var resValidarEmail = await ValidarEmail(usuario.tEmail);

                //if (resValidarEmail)
                //{
                //    return BadRequest("Este Correo ya existe intente con uno nuevo");
                //}

                Guid tContrasenna = Guid.NewGuid();
                var tContrasenna1 = tContrasenna.ToString().Substring(0, 10);
                usuario.tPassword = tContrasenna.ToString().Substring(0, 10);
                var resCrearUsuario = await CrearUsuario(usuario, 1);
                if (resCrearUsuario == null)
                {
                    return StatusCode(500, "No se pudo crear el usuario, Comuniquese con la mesa de servicio");
                }
                mUsuarioEntidad usuarioE = new mUsuarioEntidad();
                usuarioE.iIDUsuario = resCrearUsuario.iIDUsuario;
                usuarioE.iIDEntidad = 1;
                usuarioE.iIDUsuarioCreacion = 1;
                var resCrearEntidadUsuario = await CrearUsuarioEntidad(usuarioE);
                if (!resCrearEntidadUsuario.Contains("UsuarioEntidad Creado Correctamente"))
                {
                    return BadRequest("Error al crear EntidadUsuario, Comunicarse con la mesa de servicio ");
                }

                List<mPerfil> mListPerfil = new List<mPerfil>();
                mPerfil perfil = new()
                {
                    iIDPerfil = 1
                };
                mListPerfil.Add(perfil);
                var resCrearUsuarioPerfil = await CrearUsuarioPerfil(mListPerfil, resCrearUsuario.iIDUsuario, 1);


                if (!resCrearUsuarioPerfil.Contains("PerfilUsuario Creado Correctamente"))
                {
                    return BadRequest("Error al crear UsuarioPerfil, Comunicarse con la mesa de servicio ");
                }
                var resEnviarCorreo = await EnviarCorreoUsuarioCreado(resCrearUsuario.tPrimerNombre, resCrearUsuario.tEmail, tContrasenna1.ToString(), resCrearUsuario.tUsuario);
                return Ok("El usuario se registro correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el servicio PostCrearUsuario", ex);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostEditarUsuario(mCrearUsuario usuario)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }
                var resValidarEmail = await ValidarEmail(usuario.tEmail);

                if (resValidarEmail)
                {
                    return BadRequest("Este Correo ya existe intente con uno nuevo");
                }

                var res = await EditarUsuario(usuario, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo Editar el usuario, Comuniquese con la mesa de servicio");
                }
                return Ok("El usuario se Edito correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el servicio PostEditarUsuario ", ex);
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetListarUsuarios()
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }

                var res = await ListarUsuarios();
                return Ok(res);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el servicio GetListarUsuarios ", ex);
                throw;
            }
        }

        #endregion

        #region Methods

        private async Task<tblUsuarios> CrearUsuario(mCrearUsuario usuarioN, int iIDUsuario)
        {
            try
            {
                tblUsuarios usuario = new tblUsuarios();

                usuario.tPrimerNombre = usuarioN.tPrimerNombre;
                usuario.tSegundoNombre = usuarioN.tSegundoNombre;
                usuario.tPrimerApellido = usuarioN.tPrimerApellido;
                usuario.tSegundoApellido = usuarioN.tSegundoApellido;
                usuario.tUsuario = usuarioN.tUsuario;
                usuario.tEmail = usuarioN.tEmail;
                usuario.tPassword = usuarioN.tPassword;

                usuario.iIDUsuarioCreacion = iIDUsuario;
                usuario.dtFechaCreacion = DateTime.UtcNow;
                usuario.bActivo = true;
                usuario.bHabilitado = true;

                _context.tblUsuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el Metodo CrearUsuario ", ex);
                throw;
            }
        }
        private async Task<bool> ValidarEmail(string? tEmail)
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
        private async Task<string> EditarUsuario(mCrearUsuario usuarioN, int iIDUsuario)
        {
            try
            {
                tblUsuarios usuario = await _context.tblUsuarios.Where(x => x.iIDUsuario == usuarioN.iIDUsuario && x.bActivo == true).FirstOrDefaultAsync();
                if (usuario != null)
                {
                    if (usuarioN.tPrimerNombre != null && usuario.tPrimerNombre != usuarioN.tPrimerNombre)
                    {
                        usuario.tPrimerNombre = usuarioN.tPrimerNombre;
                    }
                    if (usuarioN.tSegundoNombre != null && usuario.tSegundoNombre != usuarioN.tSegundoNombre)
                    {
                        usuario.tSegundoNombre = usuarioN.tSegundoNombre;
                    }
                    if (usuarioN.tPrimerApellido != null && usuario.tPrimerApellido != usuarioN.tPrimerApellido)
                    {
                        usuario.tPrimerApellido = usuarioN.tPrimerApellido;
                    }
                    if (usuarioN.tSegundoApellido != null && usuario.tSegundoApellido != usuarioN.tSegundoApellido)
                    {
                        usuario.tSegundoApellido = usuarioN.tSegundoApellido;
                    }
                    if (usuarioN.tPrimerNombre != null && usuario.tUsuario != usuarioN.tPrimerNombre)
                    {
                        usuario.tUsuario = usuarioN.tPrimerNombre;
                    }
                    if (usuarioN.tEmail != null && usuario.tEmail != usuarioN.tEmail)
                    {
                        usuario.tEmail = usuarioN.tEmail;
                    }
                    if (usuarioN.bActivo != null && usuario.bActivo != usuarioN.bActivo)
                    {
                        usuario.bActivo = usuarioN.bActivo;
                    }

                    usuario.iIDUsuarioModificacion = iIDUsuario;
                    usuario.dtFechaModificacion = DateTime.UtcNow;       

                    _context.Entry(usuario).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return "Usuario Editado Correctamente";
                }
                return "Error Editando el Usuario";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el Metodo EditarUsuario", ex);
                throw;
            }
        }
        private async Task<List<mUsuarios>> ListarUsuarios()
        {
            try
            {
                var res = await (from u in _context.tblUsuarios
                                 //join m in _context.tblMultivalores on new { iIDSubTabla = u.iIDSubTablaTipoDoc, tIDValor = u.tIDValorTipoDoc, u.bActivo} equals new { iIDSubTabla = (int?)m.iIDSubTabla, m.tIDValor, m.bActivo}
                                 //join mi in _context.tblMultivaloresIdiomas on new { iIDSubTabla = (int?)m.iIDSubTabla, m.tIDValor, m.bActivo} equals new {mi.iIDSubTabla, mi.tIDValor, mi.bActivo}
                                 //where u.bActivo == true
                                 select new mUsuarios
                                {
                                    iIDUsuario = u.iIDUsuario,
                                    tPrimerNombre = u.tPrimerNombre,
                                    tSegundoNombre = u.tSegundoNombre,
                                    tPrimerApellido = u.tPrimerApellido,
                                    tSegundoApellido = u.tSegundoApellido,
                                    tUsuario = u.tUsuario,
                                    tEmail = u.tEmail

                                }).ToListAsync();
                return res;

            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el Metodo ListarUsuarios ", ex);
                throw;
            }
        }
        public async Task<string> CrearUsuarioPerfil(List<mPerfil> ListPerfil, int? iIDUsuario, int iIDUsuarioCreacion)
        {
            try
            {
                if(ListPerfil != null)
                {
                    int cont = 0;
                    foreach (var uPerfil in ListPerfil)
                    {
                        cont++;
                        tblUsuariosPerfiles perfilU = new tblUsuariosPerfiles();
                        perfilU.iIDUsuario = iIDUsuario;
                        perfilU.iIDPerfil = uPerfil.iIDPerfil;
                        perfilU.iIDUsuarioCreacion = iIDUsuarioCreacion;
                        perfilU.dtFechaCreacion = DateTime.Now;
                        perfilU.bActivo = true;
                        _context.tblUsuariosPerfiles.Add(perfilU);
                        await _context.SaveChangesAsync();
                    }
                    if (cont == 0)
                    {
                        return "No se creo UsuarioPerfil";
                    }

                    return "PerfilUsuario Creado Correctamente";
                }
                return "Error La Lista de Perfil viene vacia";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuarioController: Error en el metodo de CrearUsuarioPerfil ", ex);
                throw;
            }
        }
        public async Task<string> CrearUsuarioEntidad(mUsuarioEntidad usuarioE)
        {
            try
            {
                tblEntidadUsuario entidadU = new tblEntidadUsuario();
                entidadU.iIDUsuario = usuarioE.iIDUsuario;
                entidadU.iIDEntidad = usuarioE.iIDEntidad;
                entidadU.iIDUsuarioCreacion = usuarioE.iIDUsuarioCreacion;
                entidadU.dtFechaCreacion = DateTime.Now;
                entidadU.bActivo = true;
                _context.tblEntidadUsuario.Add(entidadU);
                await _context.SaveChangesAsync();

                return "UsuarioEntidad Creado Correctamente";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuarioController: Error en el metodo de CrearUsuarioEntidad ", ex);
                return "Error: Creando UsuarioEntidad ";
            }
        }
        public async Task<bool> EnviarCorreoUsuarioCreado(string tNombre, string tCorreo, string tCodigo, string tUsuario)
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
                                    <h1>¡Hola, {tNombre}!</h1>
                                    <p>Te damos la bienvenida a Ahirisk. Tu registro ha sido exitoso. </p>
                                    <p>A continuación, te proporcionamos tus credenciales de inicio de sesión:</p>
                                    <span class='Recuerda-text'>Recuerda que puedes iniciar sesión con el correo o el usuario</span> </p>
                                    <p>Usuario: <span class='Usuario-text'>{tUsuario}</span> </p>
                                    <p>Correo: <span class='Usuario-text'>{tCorreo}</span> </p>
                                    <p>Contraseña: <span class='Usuario-text'>{tCodigo}</span> </p>

                                    <p>Puedes iniciar sesión en Ahirisk utilizando estas credenciales. Recuerda cambiar tu contraseña después de tu primer inicio de sesión.</p>
                                    <p>Si tienes problemas puedes comunicarte con la mesa de servicio</p>
                                </body>
                                </html>";

                await _emailService.SendAsync(body, "Bienvenido a Ahirisk", new List<string> { tCorreo }, MimeKit.Text.TextFormat.Html);
                return true;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("AccountController: Error en el método de EnviarCorreoUsuarioCreado", ex);
                return false;
            }
        }
        #endregion
    }
}
