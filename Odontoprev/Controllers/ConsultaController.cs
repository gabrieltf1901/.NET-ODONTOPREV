using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Odontoprev.Models.Entities;
using Odontoprev.Repositories.Interfaces;
using Odontoprev.Data;
using Odontoprev.Models.Entities;

namespace Odontoprev.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        /// <summary>
        /// Retorna todas as consultas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consultas = await _consultaRepository.GetAllAsync();
            return Ok(consultas);
        }

        /// <summary>
        /// Retorna uma consulta pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consulta = await _consultaRepository.GetByIdAsync(id);
            if (consulta == null)
                return NotFound();

            return Ok(consulta);
        }

        /// <summary>
        /// Cria uma nova consulta.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Consulta consulta)
        {
            await _consultaRepository.AddAsync(consulta);
            return CreatedAtAction(nameof(GetById), new { id = consulta.Id }, consulta);
        }

        /// <summary>
        /// Atualiza uma consulta existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Consulta consulta)
        {
            if (id != consulta.Id)
                return BadRequest("ID informado não coincide com o ID do objeto.");

            await _consultaRepository.UpdateAsync(consulta);
            return NoContent();
        }

        /// <summary>
        /// Remove uma consulta pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _consultaRepository.DeleteAsync(id);
            return NoContent();
        }
    }

