using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Odontoprev.Models.Entities;
using Odontoprev.Repositories.Interfaces;
using Odontoprev.Data;
using Odontoprev.Models.Entities;

namespace Odontoprev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _profissionalRepository;

        public ProfissionalController(IProfissionalRepository profissionalRepository)
        {
            _profissionalRepository = profissionalRepository;
        }

        /// <summary>
        /// Retorna todos os profissionais.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profissionais = await _profissionalRepository.GetAllAsync();
            return Ok(profissionais);
        }

        /// <summary>
        /// Retorna um profissional pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profissional = await _profissionalRepository.GetByIdAsync(id);
            if (profissional == null)
                return NotFound();

            return Ok(profissional);
        }

        /// <summary>
        /// Cria um novo profissional.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Profissional profissional)
        {
            await _profissionalRepository.AddAsync(profissional);
            return CreatedAtAction(nameof(GetById), new { id = profissional.Id }, profissional);
        }

        /// <summary>
        /// Atualiza um profissional existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Profissional profissional)
        {
            if (id != profissional.Id)
                return BadRequest("ID informado não coincide com o ID do objeto.");

            await _profissionalRepository.UpdateAsync(profissional);
            return NoContent();
        }

        /// <summary>
        /// Remove um profissional pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _profissionalRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
