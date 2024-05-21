using ApplicationCore.Entities.Ahirisk;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebApiAhirisk.Controllers;
using WebApiAhirisk.Models.Seguridad;
using WebApiAhirisk.Utils;
using WebApiAhisrisk.Models.Administrativo;

namespace WebApiAhisrisk.Controllers.Administrativo
{
    public class IdiomasController : BaseController
    {
        #region Dependency

        private readonly DBAhiriskV1Context _context;

        public IdiomasController(DBAhiriskV1Context context)
        {
            _context = context;
        }

        #endregion

        #region Services

        [HttpPost]
        public async Task<IActionResult> PostCrearIdioma(mIdioma idioma)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }
                var resValidarIdioma = await ValidarIdioma(idioma.tPais, idioma.tCodigo);

                if (resValidarIdioma)
                {
                    return BadRequest("Este Idioma ya existe intente con uno nuevo");
                }

                var res = await CrearIdioma(idioma, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo crear el Idioma, Comuniquese con la mesa de servicio");
                }
                return Ok("El Idioma se registro correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("IdiomasController: Error en el servicio PostCrearIdioma ", ex);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostEditarIdioma(mIdioma idioma)
        {
            try
            {
                if (!GetUserId(out int iIDUsuario))
                {
                    return Unauthorized();
                }
                var resValidarIdioma = await ValidarIdioma(idioma.tPais, idioma.tCodigo);

                if (resValidarIdioma)
                {
                    return BadRequest("Este Idioma ya existe intente con uno nuevo");
                }

                var res = await EditarIdioma(idioma, iIDUsuario);
                if (res.Contains("Error"))
                {
                    return StatusCode(500, "No se pudo Editar el Idioma, Comuniquese con la mesa de servicio");
                }
                return Ok("El Idioma se Edito correctamente");
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("IdiomasController: Error en el servicio PostEditarIdioma ", ex);
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

                //var res = await ListarUsuarios();
                return Ok();
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuariosController: Error en el servicio GetListarUsuarios ", ex);
                throw;
            }
        }

        #endregion
        #region Methods

        private async Task<string> CrearIdioma(mIdioma idiomaN, int iIDUsuario)
        {
            try
            {
                tblIdiomas idioma = new tblIdiomas();

                idioma.tCodigo = idiomaN.tCodigo;
                idioma.tCodigoPais = idiomaN.tCodigoPais;
                idioma.tNombre = idiomaN.tNombre;
                idioma.tPais = idiomaN.tPais;

                idioma.iIDUsuarioCreacion = iIDUsuario;
                idioma.dtFechaCreacion = DateTime.UtcNow;
                idioma.bActivo = true;
                

                _context.tblIdiomas.Add(idioma);
                await _context.SaveChangesAsync();

                return "Idioma registrado exitosamente";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("IdiomaController: Error en el Metodo CrearIdioma ", ex);
                return "Error: Idioma No registrado ";
            }
        }

        private async Task<bool> ValidarIdioma(string? tPais, string? tCodigo)
        {
            try
            {
                var res = await _context.tblIdiomas.AnyAsync(x => x.bActivo == true && x.tPais == tPais && x.tCodigo == tCodigo);
                return res;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("UsuarioController: Error en el metodo ValidarIdioma ", ex);
                throw;
            }
        }
        private async Task<string> EditarIdioma(mIdioma idiomaN, int iIDUsuario)
        {
            try
            {
                tblIdiomas idioma = await _context.tblIdiomas.Where(x => x.iIDIdioma == idiomaN.iIDIdioma && x.bActivo == true).FirstOrDefaultAsync();

                if (idioma != null)
                {
                    if (idiomaN.tCodigo != null && idioma.tCodigo != idiomaN.tCodigo)
                    {
                        idioma.tCodigo = idiomaN.tCodigo;
                    }
                    if (idiomaN.tCodigoPais != null && idioma.tCodigoPais != idiomaN.tCodigoPais)
                    {
                        idioma.tCodigoPais = idiomaN.tCodigoPais;
                    }
                    if (idiomaN.tNombre != null && idioma.tNombre != idiomaN.tNombre)
                    {
                        idioma.tNombre = idiomaN.tNombre;
                    }
                    if (idiomaN.tPais != null && idioma.tPais != idiomaN.tPais)
                    {
                        idioma.tPais = idiomaN.tPais;
                    }
                    if (idiomaN.bActivo != null && idioma.bActivo != idiomaN.bActivo)
                    {
                        idioma.bActivo = idiomaN.bActivo;
                        if(idiomaN.bActivo == false)
                        {
                            idioma.iIDUsuarioInactivacion = iIDUsuario;
                            idioma.dtFechaInactivacion = DateTime.UtcNow;
                        }
                    }
                    idioma.iIDUsuarioCreacion = iIDUsuario;
                    idioma.dtFechaCreacion = DateTime.UtcNow;

                    _context.Entry(idioma).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return "Idioma editado exitosamente";
                }
                return "Error: Idioma No encontrado";
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("IdiomaController: Error en el Metodo EditarIdioma ", ex);
                return "Error: Idioma No Editado ";
            }
        }

        //private async Task<List<mUsuarios>> ListarUsuarios()
        //{
        //    try
        //    {
        //        var res = await (from u in _context.tblUsuarios
        //                         join m in _context.tblMultivalores on new { iIDSubTabla = u.iIDSubTablaTipoDoc, tIDValor = u.tIDValorTipoDoc, u.bActivo } equals new { iIDSubTabla = (int?)m.iIDSubTabla, m.tIDValor, m.bActivo }
        //                         join mi in _context.tblMultivaloresIdiomas on new { iIDSubTabla = (int?)m.iIDSubTabla, m.tIDValor, m.bActivo } equals new { mi.iIDSubTabla, mi.tIDValor, mi.bActivo }
        //                         where u.bActivo == true
        //                         select new mUsuarios
        //                         {
        //                             iIDUsuario = u.iIDUsuario,
        //                             tPrimerNombre = u.tPrimerNombre,
        //                             tSegundoNombre = u.tSegundoNombre,
        //                             tPrimerApellido = u.tPrimerApellido,
        //                             tSegundoApellido = u.tSegundoApellido,
        //                             tUsuario = u.tUsuario,
        //                             tEmail = u.tEmail

        //                         }).ToListAsync();
        //        return res;

        //    }
        //    catch (Exception ex)
        //    {
        //        await GenericUtils.Log("UsuariosController: Error en el Metodo ListarUsuarios ", ex);
        //        throw;
        //    }
        //}

        #endregion

        //[HttpGet, AllowAnonymous] SERVICIO PARA RECORRER UN ARCHIVO PLANO
        //public async Task<IActionResult> GetLeerarchivo()
        //{
        //    try
        //    {
        //        string filePath = @"D:\Desktop\usbb\Programacion\Ahirisk\reporteidiomas.rpt";
        //        List<Record> records = new List<Record>();

        //        using (StreamReader sr = new StreamReader(filePath))
        //        {
        //            string line;
        //            // Skip the header lines (assume first two lines are headers)
        //            sr.ReadLine();
        //            sr.ReadLine();
        //            while ((line = sr.ReadLine()) != null)
        //            {
        //                if (string.IsNullOrWhiteSpace(line)) continue;

        //                // Split the line by one or more spaces
        //                string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //                // Create a new Record object and populate it
        //                Record record = new Record
        //                {
        //                    IDIdioma = int.Parse(parts[0]),
        //                    Codigo = parts[1],
        //                    CodigoPais = parts[2],
        //                    Nombre = parts[3],
        //                    Pais = string.Join(" ", parts, 4, parts.Length - 8), // Concatenate the parts for the country name
        //                    FechaCreacion = DateTime.ParseExact(parts[parts.Length - 4] + " " + parts[parts.Length - 3], "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
        //                    IDUsuarioCreacion = int.Parse(parts[parts.Length - 2]),
        //                    Activo = parts[parts.Length - 1] == "1"
        //                };

        //                records.Add(record);
        //            }
        //        }

        //        // Process records as needed
        //        foreach (var record in records)
        //        {
        //            Console.WriteLine($"IDIdioma: {record.IDIdioma}, Codigo: {record.Codigo}, CodigoPais: {record.CodigoPais}, " +
        //                $"Nombre: {record.Nombre}, Pais: {record.Pais}, FechaCreacion: {record.FechaCreacion}, " +
        //                $"IDUsuarioCreacion: {record.IDUsuarioCreacion}, Activo: {record.Activo}");
        //            mIdioma idioma = new mIdioma();
        //            idioma.tCodigo = record.Codigo;
        //            idioma.tCodigoPais = record.CodigoPais;
        //            idioma.tNombre = record.Nombre;
        //            idioma.tPais = record.Pais;

        //            var res = await CrearIdioma(idioma, 1);

        //        }


        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        await GenericUtils.Log("UsuariosController: Error en el servicio GetListarUsuarios ", ex);
        //        throw;
        //    }
        //}
        //public class Record
        //{
        //    public int IDIdioma { get; set; }
        //    public string Codigo { get; set; }
        //    public string CodigoPais { get; set; }
        //    public string Nombre { get; set; }
        //    public string Pais { get; set; }
        //    public DateTime FechaCreacion { get; set; }
        //    public int IDUsuarioCreacion { get; set; }
        //    public bool Activo { get; set; }
        //}
    }
}
