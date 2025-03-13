using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;
using Odontoprev.Repositories.Interfaces;
using Odontoprev.Services.Interfaces;

namespace Odontoprev.Services;

public class ProfissionalService : IProfissionalService
{
    private readonly IProfissionalRepository _profissionalRepository;

    public ProfissionalService(IProfissionalRepository profissionalRepository)
    {
        _profissionalRepository = profissionalRepository;
    }

    public async Task<IEnumerable<Profissional>> GetAllAsync() =>
        await _profissionalRepository.GetAllAsync();

    public async Task<Profissional> GetByIdAsync(int id) =>
        await _profissionalRepository.GetByIdAsync(id);

    public async Task AddAsync(Profissional profissional) =>
        await _profissionalRepository.AddAsync(profissional);

    public async Task UpdateAsync(Profissional profissional) =>
        await _profissionalRepository.UpdateAsync(profissional);

    public async Task DeleteAsync(int id) =>
        await _profissionalRepository.DeleteAsync(id);
}