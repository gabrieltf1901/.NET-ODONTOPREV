using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;
using Odontoprev.Repositories.Interfaces;
using Odontoprev.Services.Interfaces;

namespace Odontoprev.Services;

public class ConsultaService : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository;

    public ConsultaService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task<IEnumerable<Consulta>> GetAllAsync() =>
        await _consultaRepository.GetAllAsync();

    public async Task<Consulta> GetByIdAsync(int id) =>
        await _consultaRepository.GetByIdAsync(id);

    public async Task AddAsync(Consulta consulta) =>
        await _consultaRepository.AddAsync(consulta);

    public async Task UpdateAsync(Consulta consulta) =>
        await _consultaRepository.UpdateAsync(consulta);

    public async Task DeleteAsync(int id) =>
        await _consultaRepository.DeleteAsync(id);
}