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
    public class FaturamentoController : ControllerBase
    {
        private readonly IFaturamentoRepository _faturamentoRepository;

        public FaturamentoController(IFaturamentoRepository faturamentoRepository)
        {
            _faturamentoRepository = faturamentoRepository;
        }

        /// <summary>
        /// Retorna todos os registros de faturamento.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var faturamentos = await _faturamentoRepository.GetAllAsync();
            return Ok(faturamentos);
        }

        /// <summary>
        /// Retorna um registro de faturamento pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var faturamento = await _faturamentoRepository.GetByIdAsync(id);
            if (faturamento == null)
                return NotFound();

            return Ok(faturamento);
        }

        /// <summary>
        /// Cria um novo registro de faturamento.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Faturamento faturamento)
        {
            await _faturamentoRepository.AddAsync(faturamento);
            return CreatedAtAction(nameof(GetById), new { id = faturamento.Id }, faturamento);
        }

        /// <summary>
        /// Atualiza um registro de faturamento existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Faturamento faturamento)
        {
            if (id != faturamento.Id)
                return BadRequest("ID informado não coincide com o ID do objeto.");

            await _faturamentoRepository.UpdateAsync(faturamento);
            return NoContent();
        }

        /// <summary>
        /// Remove um registro de faturamento pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _faturamentoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
