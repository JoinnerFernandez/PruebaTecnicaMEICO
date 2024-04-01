using BackPrueba_WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackPrueba_WebAPI.Models;



namespace BackPrueba_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public PruebaController(ApplicationDbContext context)
        {

            _context = context;
        }
        [HttpGet("getContactos/{IdUsuario}")]
        public async Task <ActionResult> getContactos(string IdUsuario)
        {
            try
            {
                var result = await _context.USUARIO
                    .Where(u => u.IdUsuario == IdUsuario)
                    .Include(u => u.lstContactos)
                        .ThenInclude(c => c.lstTelefonos)
                    .Include(u => u.lstContactos)
                        .ThenInclude(c => c.lstCorreos)
                    .FirstOrDefaultAsync(); 

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("No Existe");
                }

            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message + ex.InnerException?.Message);
            }           
        }

        [HttpPost("postUsuario")]
        public async Task<ActionResult> postUsuario(Usuario obj)
        {
            try
            {
                await _context.USUARIO.AddAsync(obj);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException?.Message);
            }
        }

        [HttpPost("postContacto")]
        public async Task<ActionResult> postContacto(Contacto obj)
        {
            try
            {
                var objContacto = await _context.CONTACTO.FindAsync(obj.IdContacto);
                if (objContacto == null)
                {
                    await _context.CONTACTO.AddAsync(obj);
                }
                else
                {
                    _context.Entry(objContacto).CurrentValues.SetValues(obj);

                    var lstTelefonos = await _context.TELEFONO.Where(x => x.IdContacto == objContacto.IdContacto).ToListAsync();
                    _context.TELEFONO.RemoveRange(lstTelefonos);
                    _context.TELEFONO.AddRangeAsync(obj.lstTelefonos);

                    var lstCorreos = await _context.CORREO.Where(x => x.IdContacto == objContacto.IdContacto).ToListAsync();
                    _context.CORREO.RemoveRange(lstCorreos);
                    _context.CORREO.AddRangeAsync(obj.lstCorreos);
                }
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException?.Message);
            }
        }

        [HttpDelete("deleteContacto/{IdContacto}")]
        public async Task<ActionResult> deleteContacto(int IdContacto)
        {
            try
            {
                var obj = await _context.CONTACTO.Where(x => x.IdContacto == IdContacto).Include(y => y.lstTelefonos).Include(y => y.lstCorreos).FirstOrDefaultAsync();
                if (obj != null)
                {
                    _context.CONTACTO.Remove(obj);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException?.Message);
            }
            
        }
    }
}
