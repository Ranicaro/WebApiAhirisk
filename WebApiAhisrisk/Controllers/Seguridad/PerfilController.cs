using ApplicationCore.Entities.Ahirisk;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApiAhirisk.Controllers;
using WebApiAhirisk.Models.Seguridad;
using WebApiAhirisk.Utils;
using WebApiAhisrisk.Models.Seguridad;

namespace WebApiAhisrisk.Controllers.Seguridad
{
    public class PerfilController : BaseController
    {
        #region Dependency

        private readonly DBAhiriskV1Context _context;

        public PerfilController(DBAhiriskV1Context context)
        {
            _context = context;
        }

        #endregion

        #region Services
        [HttpPost]
        public async Task<IActionResult> PostCrearPerfil(mPerfil perfil)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario) ||
                    !GetPerfilId(out int iIDPerfil))
                {
                    return Unauthorized();
                }
                var resValidarPerfil = await ValidarPerfil(perfil.tDescripcion);

                if (resValidarPerfil)
                {
                    return BadRequest("Este Perfil ya existe intente con uno nuevo");
                }

                var res = await CrearPerfil(perfil, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo crear el perfil, Comuniquese con la mesa de servicio");
                }
                return Ok("El Perfil se registro correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("PerfilController: Error en el servicio PostCrearPerfil ", ex);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostEditarPerfil(mPerfil perfil)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario) ||
                    !GetPerfilId(out int iIDPerfil))
                {
                    return Unauthorized();
                }
                var resValidarEmail = await ValidarPerfil(perfil.tDescripcion);

                if (resValidarEmail)
                {
                    return BadRequest("Este Perfil ya existe intente con uno nuevo");
                }
                var res = await EditarPerfil(perfil, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo Editar el perfil, Comuniquese con la mesa de servicio");
                }
                return Ok("El Perfil se registro correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("PerfilController: Error en el servicio PostEditarPerfil ", ex);
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetListarPerfiles()
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }

                var res = await ListarPerfiles();
                return Ok(res);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("PerfilController: Error en el servicio GetListarPerfiles ", ex);
                throw;
            }
        }
        #endregion

        #region Methods
        private async Task<string> CrearPerfil(mPerfil perfilN, int iIDUsuario)
        {
            try
            {
                tblPerfiles perfil = new tblPerfiles();
                perfil.tDescripcion = perfilN.tDescripcion;
                perfil.tDefinicion = perfilN.tDefinicion;

                perfil.iIDUsuarioCreacion = iIDUsuario;
                //perfil.dtFechaCreacion = DateTime.UtcNow;
                perfil.bActivo = true;

                _context.tblPerfiles.Add(perfil);
                await _context.SaveChangesAsync();

                return "Perfil Creado Correctamente";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("PerfilController: Error en el Metodo CrearPerfil ", ex);
                return "Error: Creando el Perfil";
            }
        }
        private async Task<bool> ValidarPerfil(string tDescripcion)
        {
            try
            {
                var res = await _context.tblPerfiles.AnyAsync(x => x.bActivo == true && x.tDescripcion == tDescripcion);

                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("PerfilController: Error en el Metodo ValidarPerfil ", ex);
                throw;
            }
        }
        private async Task<string> EditarPerfil(mPerfil perfilN, int iIDUsuario)
        {
            try
            {
                tblPerfiles perfil = await _context.tblPerfiles.Where(x => x.iIDPerfil == perfilN.iIDPerfil && x.bActivo == true).FirstOrDefaultAsync();

                if (perfil != null)
                {
                    if (perfilN.tDescripcion != null && perfil.tDescripcion != perfilN.tDescripcion)
                    {
                        perfil.tDescripcion = perfilN.tDescripcion;
                    }
                    if (perfilN.tDefinicion != null && perfil.tDefinicion != perfilN.tDefinicion)
                    {
                        perfil.tDefinicion = perfilN.tDefinicion;
                    }
                    if (perfilN.bActivo != null && perfil.bActivo != perfilN.bActivo)
                    {
                        perfil.bActivo = perfilN.bActivo;
                        if (perfilN.bActivo == false)
                        {
                            perfil.iIDUsuarioInactivacion = iIDUsuario;
                            perfil.dtFechaInactivacion = DateTime.UtcNow;
                        }
                    }
                    perfil.iIDUsuarioModificacion = iIDUsuario;
                    perfil.dtFechaModificacion = DateTime.UtcNow;

                    _context.Entry(perfil).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return "Perfil Creado Correctamente";
                }
                return "Error Editando el perfifil";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("PerfilController: Error en el Metodo CrearPerfil ", ex);
                return "Error: Editando el Perfil";
            }
        }
        private async Task<List<mPerfil>> ListarPerfiles()
        {
            try
            {
                var res = await _context.tblPerfiles.Where(x => x.bActivo == true).Select(x => new mPerfil
                {
                    iIDPerfil = x.iIDPerfil,
                    tDescripcion = x.tDescripcion,
                    tDefinicion = x.tDefinicion
                }).ToListAsync();
                return res;

            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el Metodo ListarPerfiles", ex);
                throw;
            }
        }
        #endregion
    }
}
