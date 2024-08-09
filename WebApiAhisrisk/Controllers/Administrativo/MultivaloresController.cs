using ApplicationCore.Entities.Ahirisk;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApiAhirisk.Models.Administrativo;
using WebApiAhirisk.Utils;

namespace WebApiAhirisk.Controllers.Administrativo
{


    public class MultivaloresController : BaseController
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        #region Denpendency Injection
        private readonly DBAhiriskV1Context _context;
        public MultivaloresController(DBAhiriskV1Context context)
        {
            _context = context;
        }

        #endregion
        #region Services
        [HttpGet]
        public async Task<IActionResult> GetSubtabla([Required] int iIDSubTabla)
        {
            try
            {
                //if (!GetEntityId(out int iIDEntidad) || !GetLanguageId(out int iIDIdioma))
                //    return Forbid();

                var subTabla = await GetSubTabla(iIDSubTabla);
                return Ok(subTabla);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MultivaloresController: Error en el Metodo GetMultivalores", ex);
                throw;
            }
        }
        #endregion
        #region Metodos
        public async Task<MMultivaloresIdiomas> GetSubTabla(int? iIDSubTabla)
        {
            try
            {
                var res = await (from m in _context.tblMultivalores
                                 join mi in _context.tblMultivaloresIdiomas on new { iIDSubTabla = (int?)m.iIDSubTabla, m.tIDValor, bActivo = (bool?)m.bActivo } equals new { mi.iIDSubTabla, mi.tIDValor, mi.bActivo }
                                 where m.iIDSubTabla == iIDSubTabla && m.bActivo == true
                                 select new MMultivaloresIdiomas
                                 {
                                     iIDMultivaloresIdioma = mi.iIDMultivaloresIdioma,
                                     iIDIdioma = mi.iIDIdioma,
                                     iIDSubTabla = mi.iIDSubTabla,
                                     tIDValor = mi.tIDValor,
                                     tDescripcionValor = mi.tDescripcionValor,
                                     iIDUsuarioCreacion = mi.iIDUsuarioCreacion,
                                     dtFechaCreacion = mi.dtFechaCreacion,
                                     bActivo = mi.bActivo
                                 }
                                  ).FirstOrDefaultAsync();


                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MultivaloresController: Error en el Metodo GetMultivalores", ex);
                throw;
            }
        }
        public async Task<MMultivaloresIdiomas> GetMultivalores(int? iIDSubTabla, string? tIDValor)
        {
            try
            {
                var res = await (from m in _context.tblMultivalores
                                 join mi in _context.tblMultivaloresIdiomas on new { iIDSubTabla = (int?)m.iIDSubTabla, m.tIDValor, bActivo = (bool?)m.bActivo } equals new { mi.iIDSubTabla, mi.tIDValor, mi.bActivo }
                                 where m.iIDSubTabla == iIDSubTabla && m.tIDValor == tIDValor && m.bActivo == true
                                 select new MMultivaloresIdiomas
                                 {
                                     iIDMultivaloresIdioma = mi.iIDMultivaloresIdioma,
                                     iIDIdioma = mi.iIDIdioma,
                                     iIDSubTabla = mi.iIDSubTabla,
                                     tIDValor = mi.tIDValor,
                                     tDescripcionValor = mi.tDescripcionValor,
                                     iIDUsuarioCreacion = mi.iIDUsuarioCreacion,
                                     dtFechaCreacion = mi.dtFechaCreacion,
                                     bActivo = mi.bActivo
                                 }
                                  ).FirstOrDefaultAsync();


                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MultivaloresController: Error en el Metodo GetMultivalores", ex);
                throw;
            }
        }
       
        #endregion

    }


}
