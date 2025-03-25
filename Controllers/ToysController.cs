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
            return await _context.TB_Toys.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Toys>> GetById(int id)
        {
            var toy = await _context.TB_Toys.FindAsync(id);
            return toy == null ? NotFound() : toy;
        }

        [HttpPost]
        public async Task<ActionResult<Toys>> Create(Toys toy)
        {
            if (toy.Classification_toy > 12)
                return BadRequest("Só é permitido brinquedos para crianças até 12 anos.");

            _context.TB_Toy.Add(toy);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = toy.Id_toy }, toy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Toys toy)
        {
            if (id != toy.Id_toy) return BadRequest();

            if (toy.Classification_toy > 12)
                return BadRequest("Classificação acima de 12 anos não é permitida.");

            _context.Entry(toy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toy = await _context.TB_Toys.FindAsync(id);
            if (toy == null) return NotFound();


            _context.TB_Toys.Remove(toy);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
