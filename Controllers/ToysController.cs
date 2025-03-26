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

        // Get all
        /// <summary>
        /// Obter todos os brinquedos
        /// </summary>
        /// <returns>Todos os Brinquedos</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toys>>> GetAll()
        {
            try
            {
                return await _context.Toys.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        // Get by Id
        /// <summary>   
        /// Obter um Paciente
        /// </summary>
        /// <param name="id">Identificador do Brinquedo</param>
        /// <returns>Dados do Brinquedo</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Toys>> GetById(int id)
        {
            try
            {
                var toy = await _context.Toys.FindAsync(id);
                return toy == null ? NotFound() : toy;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // Create
        /// <summary>
        /// Cadastrar um Brinquedo
        /// </summary>
        /// <remarks>
        /// objeto Json
        /// </remarks>
        /// <returns>Brinquedo recém criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPost]
        public async Task<ActionResult<Toys>> Create(Toys toy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Toys.Add(toy);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = toy.Id_toy }, toy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualizar um Brinquedo
        /// </summary>
        /// <param name="id">Identificador do Brinquedo</param>
        /// <returns>Não retorna informações</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Toys toy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existingToy = await _context.Toys.FindAsync(id);
                if (existingToy == null) return NotFound();

                // Atualiza campos manualmente
                existingToy.Name_toy = toy.Name_toy;
                existingToy.Type_toy = toy.Type_toy;
                existingToy.Classification_toy = toy.Classification_toy;
                existingToy.Brand_toy = toy.Brand_toy;
                existingToy.Price_toy = toy.Price_toy;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // Delete
        /// <summary>
        /// Deletar um Brinquedo
        /// </summary>
        /// <param name="id">Identificador de Brinquedos</param>
        /// <returns>Não retorna informações</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var toy = await _context.Toys.FindAsync(id);
                if (toy == null) return NotFound();

                _context.Toys.Remove(toy);
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
