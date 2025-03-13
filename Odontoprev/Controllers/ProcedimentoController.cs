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
    public class ProcedimentoController : ControllerBase
    {
        private readonly IProcedimentoRepository _procedimentoRepository;

        public ProcedimentoController(IProcedimentoRepository procedimentoRepository)
        {
            _procedimentoRepository = procedimentoRepository;
        }

        /// <summary>
        /// Retorna todos os procedimentos.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var procedimentos = await _procedimentoRepository.GetAllAsync();
            return Ok(procedimentos);
        }

        /// <summary>
        /// Retorna um procedimento pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var procedimento = await _procedimentoRepository.GetByIdAsync(id);
            if (procedimento == null)
                return NotFound();

            return Ok(procedimento);
        }

        /// <summary>
        /// Cria um novo procedimento.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Procedimento procedimento)
        {
            await _procedimentoRepository.AddAsync(procedimento);
            return CreatedAtAction(nameof(GetById), new { id = procedimento.Id }, procedimento);
        }

        /// <summary>
        /// Atualiza um procedimento existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Procedimento procedimento)
        {
            if (id != procedimento.Id)
                return BadRequest("ID informado não coincide com o ID do objeto.");

            await _procedimentoRepository.UpdateAsync(procedimento);
            return NoContent();
        }

        /// <summary>
        /// Remove um procedimento pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _procedimentoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

