using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;
using Odontoprev.Repositories.Interfaces;
using Odontoprev.Services.Interfaces;

namespace Odontoprev.Services;

public class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<IEnumerable<Paciente>> GetAllAsync() =>
        await _pacienteRepository.GetAllAsync();

    public async Task<Paciente> GetByIdAsync(int id) =>
        await _pacienteRepository.GetByIdAsync(id);

    public async Task AddAsync(Paciente paciente) =>
        await _pacienteRepository.AddAsync(paciente);

    public async Task UpdateAsync(Paciente paciente) =>
        await _pacienteRepository.UpdateAsync(paciente);

    public async Task DeleteAsync(int id) =>
        await _pacienteRepository.DeleteAsync(id);
}