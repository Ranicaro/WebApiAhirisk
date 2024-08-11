using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAhirisk.Models.Administrativo;
using WebApiAhirisk.Utils;

namespace WebApiAhirisk.Controllers.Administrativo
{
    public class MatrizDeRiesgoController : BaseController
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        #region Dependecy Injection

        private readonly DBAhiriskV1Context _context;
        public MatrizDeRiesgoController(DBAhiriskV1Context context)
        {
            _context = context;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<IActionResult> GetTipoProductoRiesgo()
        {
            try
            {
                var tipoP = await tipoProceso();
                return Ok(tipoP);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Servicio GetTipoProductoRiesgo", ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetProcesosPorTipoProcesoRiesgo([FromBody] TipoProcesoRequest request)
        {
            try
            {
                var procesosPorTipo = await procesosPorTipoProceso(request.iIDTipoProceso);
                return Ok(procesosPorTipo);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Metodo GetProcesosPorTipoProceso", ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMetodologiaRiesgo()
        {
            try
            {
                var metodologias = await metodologia();
                return Ok(metodologias);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Servicio GetMetodologia", ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetFactorRiesgoPorMetodologiaRiesgo([FromBody] FactorRiesgoRequest request)
        {
            try
            {
                var factorRiesgo= await factorRiesgoPorMetodologia(request.iIDMetodologiaRiesgo);
                return Ok(factorRiesgo);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Metodo GetFactorRiesgoPorMetodologia", ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganismosControl()
        {
            try
            {
                var organismos = await organismosControl();
                return Ok(organismos);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Servicio GetOrganismosControl", ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetProductosPorOrganismoControlRiesgo(int? iIDOrganismoControl)
        {
            try
            {
                var productos = await productoRiesgo(1);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Servicio GetProductosRiesgo", ex);
                throw;
            }
        }

        #endregion

        #region Metodos

        public async Task<List<mProcesoRiesgo>> tipoProceso()
        {
            try
            {
                var res = await (from ttp in _context.tblTipoProcesos.AsNoTracking()
                                 join ttppi in _context.tblTipoProcesosPaisIdioma on ttp.iIDTipoProceso equals ttppi.iIDTipoProceso into ttppiGroup
                                 from ttppi in ttppiGroup.DefaultIfEmpty()
                                 select new mProcesoRiesgo
                                 {
                                     iIDTipoProceso = ttp.iIDTipoProceso,
                                     iIDTipoProcesosPaisIdioma = ttppi.iIDTipoProcesosPaisIdioma,
                                     tDescripcionProceso = ttppi.tDescripcionProceso
                                 }).AsNoTracking().ToListAsync();

                return res;

            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Metodo metodologia", ex);
                throw;
            }
        }

        public async Task<List<mProcesoRiesgo>> procesosPorTipoProceso(int? iIDTipoProceso)
        {
            try
            {
                var res = await (from ttp in _context.tblTipoProcesos.AsNoTracking()
                                 join ttppi in _context.tblTipoProcesosPaisIdioma on ttp.iIDTipoProceso equals ttppi.iIDTipoProceso into ttppiGroup
                                 from ttppi in ttppiGroup.DefaultIfEmpty()
                                 join tp in _context.tblProcesos on ttppi.iIDTipoProceso equals tp.iIDTipoProceso into tpGroup
                                 from tp in tpGroup.DefaultIfEmpty()
                                 join tppi in _context.tblProcesosPaisIdioma on tp.iIDProceso equals tppi.iIDProceso into tppiGroup
                                 from tppi in tppiGroup.DefaultIfEmpty()
                                 where (!iIDTipoProceso.HasValue || ttp.iIDTipoProceso == iIDTipoProceso.Value)
                                 select new mProcesoRiesgo
                                 {
                                     iIDProceso = ttp.iIDTipoProceso,
                                     tDescripcionProceso = ttppi.tDescripcionProceso
                                 }).AsNoTracking().ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Metodo ProcesosPorTipoProceso", ex);
                throw;
            }
        }

        public async Task<List<mMetodologiaRiesgo>> metodologia()
        {
            try
            {
                var res = await (from tmr in _context.tblMetodologiaRiesgo.AsNoTracking()
                                 join tmrpi in _context.tblMetodologiaRiesgoPaisIdioma on tmr.iIDMetodologiaRiesgo equals tmrpi.iIDMetodologiaRiesgo into tmrpiGroup
                                 from tmrpi in tmrpiGroup.DefaultIfEmpty()
                                 select new mMetodologiaRiesgo
                                 {
                                     iIDMetodologiaRiesgo = tmrpi.iIDMetodologiaRiesgo,
                                     iIDMetodologiaRiesgoPaisIdioma = tmrpi.iIDMetodologiaRiesgoPaisIdioma,
                                     tSigla = tmrpi.tSigla,
                                     tDescripcion = tmrpi.tDescripcion
                                 }).AsNoTracking().ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Metodo metodologia", ex);
                throw;
            }
        }

        public async Task<List<mFactorRiesgo>> factorRiesgoPorMetodologia(int? iIDMetodologiaRiesgo)
        {
            try
            {
                var res = await (from tmr in _context.tblMetodologiaRiesgo.AsNoTracking()
                                 join tmrpi in _context.tblMetodologiaRiesgoPaisIdioma on tmr.iIDMetodologiaRiesgo equals tmrpi.iIDMetodologiaRiesgo into tmrpiGroup
                                 from tmrpi in tmrpiGroup.DefaultIfEmpty()
                                 join tfr in _context.tblFactoresRiesgo on tmrpi.iIDMetodologiaRiesgo equals tfr.iIDMetodologiaRiesgo into tfrGroup
                                 from tfr in tfrGroup.DefaultIfEmpty()
                                 join tfrpi in _context.tblFactoresRiesgoPaisIdioma on tfr.iIDFactorRiesgo equals tfrpi.iIDFactorRiesgo into tfrpiGroup
                                 from tfrpi in tfrpiGroup.DefaultIfEmpty()
                                 where (!iIDMetodologiaRiesgo.HasValue || tmr.iIDMetodologiaRiesgo == iIDMetodologiaRiesgo.Value)
                                 where tmr.iIDMetodologiaRiesgo == 4
                                 select new mFactorRiesgo
                                 {
                                     iIDMetodologiaRiesgo = tmr.iIDMetodologiaRiesgo,
                                     iIDFactorRiesgo = tfr.iIDFactorRiesgo,
                                     iIDFactorRiesgoPaisIdioma = tfrpi.iIDFactorRiesgoPaisIdioma,
                                     tDescripcionFactor = tfrpi.tDescripcionFactor
                                 }).AsNoTracking().ToListAsync();

                return res;

            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Metodo factorRiesgoPorMetodologia", ex);
                throw;
            }
        }

        public async Task<List<mProductoRiesgo>> productoRiesgo(int? iIDOrganismoControl)
        {
            try
            {
                var res = await (from too in _context.tblOrganismosControl.AsNoTracking()
                                 join tprodu in _context.tblProductos on too.iIDOrganismoControl equals tprodu.iIDOrganismoControl into tproduGroup
                                 from tprodu in tproduGroup.DefaultIfEmpty()
                                 where (!iIDOrganismoControl.HasValue || too.iIDOrganismoControl == iIDOrganismoControl.Value)
                                 select new mProductoRiesgo
                                 {
                                     iIDOrganismoControl = too.iIDOrganismoControl,
                                     iIDProducto = tprodu.iIDProducto,
                                     tCodigoProducto = tprodu.tCodigoProducto,
                                     tNombreProducto = tprodu.tNombreProducto
                                 }).AsNoTracking().ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Metodo productoRiesgo", ex);
                throw;
            }
        }

        public async Task<List<mOrganismoControl>> organismosControl()
        {
            try
            {
                var res = await (from teoc in _context.tblEntidadOrganismosControl.AsNoTracking()
                                 join toc in _context.tblOrganismosControl on teoc.iIDOrganismoControl equals toc.iIDOrganismoControl into tocGroup
                                 from toc in tocGroup.DefaultIfEmpty()
                                 select new mOrganismoControl
                                 {
                                     iIDEntidadOrganismoControl = teoc.iIDEntidadOrganismoControl,
                                     iIDOrganismoControl = teoc.iIDOrganismoControl,
                                     iIDPais = toc.iIDPais,
                                     tSiglaOrganismo = toc.tSiglaOrganismo,
                                     tNombreOrganismo = toc.tNombreOrganismo
                                 }).AsNoTracking().ToListAsync();

                return res;


            }
            catch (Exception ex)
            {
                await GenericUtils.Log("MatrizDeRiesgoController: Error en el Metodo organismosControl", ex);
                throw;
            }
        }

        #endregion
    }
}
