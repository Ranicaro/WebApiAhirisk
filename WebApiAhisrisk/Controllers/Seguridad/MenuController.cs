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
    public class MenuController : BaseController
    {
        #region Dependency

        private readonly DBAhiriskV1Context _context;

        public MenuController(DBAhiriskV1Context context)
        {
            _context = context;
        }

        #endregion

        #region Services

        [HttpPost]
        public async Task<IActionResult> PostCrearMenu(mMenu menu)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }
                var resValidarEmail = await ValidarRuta(menu.tUrl);
                if (resValidarEmail)
                {
                    return BadRequest("Esta Url ya existe intente con uno nuevo");
                }

                var res = await CrearMenu(menu, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo Crear la ruta, Comuniquese con la mesa de servicio");
                }
                return Ok("La ruta se registro correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el servicio PostCrearUsuario", ex);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostEditarMenu(mMenu menu)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }
                var resValidarEmail = await ValidarRuta(menu.tUrl);
                if (resValidarEmail)
                {
                    return BadRequest("Esta Url ya existe intente con uno nuevo");
                }

                var res = await EditarMenu(menu, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo Editar la ruta, Comuniquese con la mesa de servicio");
                }
                return Ok("La ruta se edito correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el servicio PostCrearUsuario", ex);
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetListarMenu()
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }

                var res = await ListarMenu();
                return Ok(res);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el servicio GetListarMenus ", ex);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostCrearMenuPerfiles(mMenuPerfiles menuPerfil)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }
                var resValidarMenuPerfil = await ValidarMenuPerfil(menuPerfil.iIDPerfil, menuPerfil.iIDMenu);
                if (resValidarMenuPerfil)
                {
                    return BadRequest("Este Menu ya esta asginado a este perfil, intente con uno nuevo");
                }

                var res = await CrearMenuPerfil(menuPerfil, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo asingar ese menu a ese perfil, Comuniquese con la mesa de servicio");
                }
                return Ok("La ruta se registro correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el servicio PostCrearMenuPerfiles ", ex);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostEditarMenuPerfil(mMenuPerfiles menuPerfil)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }
                var resValidarMenuPerfil = await ValidarMenuPerfil(menuPerfil.iIDPerfil, menuPerfil.iIDMenu);
                if (resValidarMenuPerfil)
                {
                    return BadRequest("Este Menu ya esta asginado a este perfil, intente con uno nuevo");
                }

                var res = await EditarMenuPerfil(menuPerfil, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo Editar el MenuPerfil, Comuniquese con la mesa de servicio");
                }
                return Ok("El MenuPerfil se edito correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el servicio PostEditarMenuPerfil ", ex);
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetListarMenuPerfil()
        {
            try
            {
                if (!GetUserId(out int iIDUsuario) ||
                    !GetPerfilId(out int iIDPerfil))
                {
                    return Unauthorized();
                }

                var res = await ListarMenuPerfil(iIDPerfil);
                return Ok(res);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el servicio GetListarMenuPerfil ", ex);
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            try
            {
                //if (!GetUserId(out int iIDUsuario) || 
                //    !GetPerfilId(out int iIDPerfil)) 
                //{
                //    return Unauthorized();
                //}

                var menus = (await GetMenusList(1))
                .Where(x => !x.iIDPadre.HasValue)
                .Select(Parse);

                return Ok(menus);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el servicio GetMenus ", ex);
                throw;
            }
        }
        #endregion

        #region Methods   
        private async Task<string> CrearMenu(mMenu menuN, int iIDUsuario)
        {
            try
            {
                tblMenu menu = new tblMenu();

                menu.tDescripcion = menuN.tDescripcion;
                menu.iIDPadre = menuN.iIDPadre;
                menu.iPosicionPadre = menuN.iPosicionPadre;
                menu.iPosicion = menuN.iPosicion;
                menu.tUrl = menuN.tUrl;
                menu.tIcono = menuN.tIcono;
                menu.tDefinicion = menuN.tDefinicion;
                menu.iIDUsuarioCreacion = iIDUsuario;
                menu.dtFechaCreacion = DateTime.UtcNow;
                menu.bActivo = true;
                menu.bVisible = true;

                _context.tblMenu.Add(menu);
                await _context.SaveChangesAsync();

                return "Ruta registrada exitosamente";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el Metodo CrearMenu ", ex);
                return "Error: Ruta no creada";
            }
        }

        private async Task<bool> ValidarRuta(string? tUrl)
        {
            try
            {
                var res = await _context.tblMenu.AnyAsync(x => x.bActivo == true && x.tUrl == tUrl);
                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el metodo ValidarRuta ", ex);
                throw;
            }
        }
        private async Task<string> EditarMenu(mMenu menuN, int iIDUsuario)
        {
            try
            {
                tblMenu menu = await _context.tblMenu.Where(x => x.bActivo == true && x.iIDMenu == menuN.iIDMenu).FirstOrDefaultAsync();

                if(menu != null)
                {
                    if (menuN.tDescripcion != null && menu.tDescripcion != menuN.tDescripcion)
                    {
                        menu.tDescripcion = menuN.tDescripcion;
                    }
                    if (menuN.iIDPadre != null && menu.iIDPadre != menuN.iIDPadre)
                    {
                        menu.iIDPadre = menuN.iIDPadre;
                    }
                    if (menuN.iPosicionPadre != null &&  menu.iPosicionPadre != menuN.iPosicionPadre)
                    {
                        menu.iPosicionPadre = menuN.iPosicionPadre;
                    }
                    if (menuN.iPosicion != null && menu.iPosicion != menuN.iPosicion)
                    {
                        menu.iPosicion = menuN.iPosicion;
                    }
                    if (menuN.tUrl != null && menu.tUrl != menuN.tUrl)
                    {
                        menu.tUrl = menuN.tUrl;
                    }
                    if (menuN.tIcono != null && menu.tIcono != menuN.tIcono)
                    {
                        menu.tIcono = menuN.tIcono;
                    }
                    if (menuN.tDefinicion != null && menu.tDefinicion != menuN.tDefinicion)
                    {
                        menu.tDefinicion = menuN.tDefinicion;
                    }
                    if (menuN.bActivo != null && menu.bActivo != menuN.bActivo)
                    {
                        menu.bActivo = menuN.bActivo;
                        if(menuN.bActivo == false)
                        {
                            menu.iIDUsuarioInactivacion = iIDUsuario;
                            menu.dtFechaInactivacion = DateTime.UtcNow;
                        }                      
                    }
                    if (menu.bVisible != null && menu.bVisible != menu.bVisible)
                    {
                        menu.bVisible = menu.bVisible;
                    }
                    menu.iIDUsuarioModificacion = iIDUsuario;
                    menu.dtFechaModificacion = DateTime.UtcNow;



                    _context.Entry(menu).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return "Ruta Editado exitosamente";
                }
                return "Error: Ruta no Encontrada";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el Metodo CrearMenu ", ex);
                return "Error: Ruta no Editada";
            }
        }
        private async Task<List<mMenu>> ListarMenu()
        {
            try
            {
                var res = await _context.tblMenu.Where(x => x.bActivo == true)
                    .Select(x => new mMenu
                    {
                        iIDMenu = x.iIDMenu,
                        tDescripcion = x.tDescripcion,
                        iIDPadre = x.iIDPadre,
                        iPosicionPadre = x.iPosicionPadre,
                        iPosicion = x.iPosicion,
                        tUrl = x.tUrl,
                        tIcono = x.tIcono,
                        tDefinicion = x.tDefinicion,
                        bVisible = x.bVisible
                    })
                    .ToListAsync();
                return res;

            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el Metodo ListarUsuarios ", ex);
                throw;
            }
        }
        private async Task<string> CrearMenuPerfil(mMenuPerfiles menuPerfilN, int iIDUsuario)
        {
            try
            {
                tblMenuPerfiles menuPerfil = new tblMenuPerfiles();

                menuPerfil.iIDMenu = menuPerfilN.iIDMenu;
                menuPerfil.iIDPerfil = menuPerfilN.iIDPerfil;

                menuPerfil.iIDUsuarioCreacion = iIDUsuario;
                menuPerfil.dtFechaCreacion = DateTime.UtcNow;
                menuPerfil.bActivo = true;

                _context.tblMenuPerfiles.Add(menuPerfil);
                await _context.SaveChangesAsync();

                return "Menu asignado a perfil exitosamente";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el Metodo CrearMenuPerfil ", ex);
                return "Error: Menu no asignada a perfil";
            }
        }
        private async Task<bool> ValidarMenuPerfil(int? iIDPerfil, int? iIDMenu)
        {
            try
            {
                var res = await _context.tblMenuPerfiles.AnyAsync(x => x.bActivo == true && x.iIDPerfil == iIDPerfil && x.iIDMenu == iIDMenu);
                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el metodo ValidarMenuPerfil ", ex);
                throw;
            }
        }
        private async Task<string> EditarMenuPerfil(mMenuPerfiles menuPerfilN, int iIDUsuario)
        {
            try
            {
                tblMenuPerfiles menuPerfil = await _context.tblMenuPerfiles.Where(x => x.bActivo == true && x.iIDMenuPerfil == menuPerfilN.iIDMenuPerfil).FirstOrDefaultAsync();

                if(menuPerfil != null)
                {
                    if (menuPerfilN.iIDMenu != null && menuPerfil.iIDMenu != menuPerfilN.iIDMenu)
                    {
                        menuPerfil.iIDMenu = menuPerfilN.iIDMenu;
                    }
                    if (menuPerfilN.iIDPerfil != null && menuPerfil.iIDPerfil != menuPerfilN.iIDPerfil)
                    {
                        menuPerfil.iIDPerfil = menuPerfilN.iIDPerfil;
                    }              
                    if (menuPerfilN.bActivo != null && menuPerfil.bActivo != menuPerfilN.bActivo)
                    {
                        menuPerfil.bActivo = menuPerfilN.bActivo;
                        if (menuPerfilN.bActivo == false)
                        {
                            menuPerfil.iIDUsuarioInactivacion = iIDUsuario;
                            menuPerfil.dtFechaInactivacion = DateTime.UtcNow;
                        }
                    }
                    menuPerfil.iIDUsuarioModificacion = iIDUsuario;
                    menuPerfil.dtFechaModificacion = DateTime.UtcNow;


                    _context.Entry(menuPerfil).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return "MenuPerfil editado correctmanete";
                }
                return "Error: MenuPerfil No encontrado";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el Metodo EditarMenuPerfil ", ex);
                return "Error: Editando MenuPerfil";
            }
        }
        private async Task<List<mMenuPerfiles>> ListarMenuPerfil(int iIDPerfil)
        {
            try
            {
                var res = await (from mp in _context.tblMenuPerfiles
                                 join m in _context.tblMenu on new { mp.iIDMenu, mp.bActivo } equals new { iIDMenu = (int?)m.iIDMenu, m.bActivo }

                                 join p in _context.tblPerfiles on new { mp.iIDPerfil, mp.bActivo } equals new { iIDPerfil = (int?)p.iIDPerfil, p.bActivo }
                                 where mp.bActivo == true && mp.iIDPerfil == iIDPerfil
                                 orderby m.iPosicion ascending
                                 select new mMenuPerfiles
                                 {
                                     iIDMenuPerfil = mp.iIDMenuPerfil,
                                     iIDPerfil = mp.iIDPerfil,
                                     tPerfil = p.tDescripcion,
                                     iIDMenu = mp.iIDMenu,
                                     tMenu = m.tDescripcion
                                 }
                                 ).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MenuController: Error en el Metodo ListarMenuPerfil ", ex);
                throw;
            }
        }
        private async Task<List<tblMenu>> GetMenusList(int iIDPerfil)
        {
            try
            {

                var res = await (from mp in _context.tblMenuPerfiles
                                 join m in _context.tblMenu on new { mp.iIDMenu, mp.bActivo } equals new { iIDMenu = (int?)m.iIDMenu, m.bActivo }

                                 join p in _context.tblPerfiles on new { mp.iIDPerfil, mp.bActivo } equals new { iIDPerfil = (int?)p.iIDPerfil, p.bActivo }
                                 where mp.bActivo == true && mp.iIDPerfil == iIDPerfil
                                 orderby m.iIDMenu ascending
                                 select (m)
                                ).ToListAsync();
                return res;

            }
            catch (Exception ex)
            {

                await GenericUtils.Log("UsuariosController: Error en el Metodo GetMenuList ", ex);
                throw;
            }
        }

        private static mMenuLista Parse(tblMenu menu) => new()
        {
            id = menu.iIDMenu,
            title = menu.tDescripcion,
            icon = menu.tIcono,
            posicion = menu.iPosicion,
            link = ParseLink(menu.tUrl),
            //children = menu.InverseiIDPadreNavigation.Select(Parse).ToList()
            children = menu.InverseiIDPadreNavigation.Any()
               ? menu.InverseiIDPadreNavigation.Select(Parse).ToList()
               : null
        };

        private static string ParseLink(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

                int pos = url.IndexOf('?');
                if (pos >= 0)
                    url = url.Substring(0, pos);
            
            return url;
        }


        #endregion

    }
}
