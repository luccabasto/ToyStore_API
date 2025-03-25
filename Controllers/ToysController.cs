using ToyStore_API.Data;
using ToyStore_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToyStore_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToysController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toys>>> GetAll()
        {
            try
            {
                return await _context.TB_Toys.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Toys>> GetById(int id)
        {
            try
            {
                var toy = await _context.TB_Toys.FindAsync(id);
                return toy == null ? NotFound() : toy;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Toys>> Create(Toys toy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.TB_Toys.Add(toy);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = toy.Id_toy }, toy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Toys toy)
        {
            if (id != toy.Id_toy) return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existingToy = await _context.TB_Toys.FindAsync(id);
                if (existingToy == null) return NotFound();

                _context.Entry(toy).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var toy = await _context.TB_Toys.FindAsync(id);
                if (toy == null) return NotFound();

                _context.TB_Toys.Remove(toy);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}
