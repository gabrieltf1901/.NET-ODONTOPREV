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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        /// <summary>
        /// Retorna todos os pacientes.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return Ok(pacientes);
        }

        /// <summary>
        /// Retorna um paciente pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        /// <summary>
        /// Cria um novo paciente.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            await _pacienteRepository.AddAsync(paciente);
            return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
        }

        /// <summary>
        /// Atualiza um paciente existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
                return BadRequest("ID informado não coincide com o ID do objeto.");

            await _pacienteRepository.UpdateAsync(paciente);
            return NoContent();
        }

        /// <summary>
        /// Remove um paciente pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pacienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
