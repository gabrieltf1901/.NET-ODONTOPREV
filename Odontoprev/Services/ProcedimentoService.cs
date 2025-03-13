using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;
using Odontoprev.Repositories.Interfaces;
using Odontoprev.Services.Interfaces;

namespace Odontoprev.Services;

public class ProcedimentoService : IProcedimentoService
{
    private readonly IProcedimentoRepository _procedimentoRepository;

    public ProcedimentoService(IProcedimentoRepository procedimentoRepository)
    {
        _procedimentoRepository = procedimentoRepository;
    }

    public async Task<IEnumerable<Procedimento>> GetAllAsync() =>
        await _procedimentoRepository.GetAllAsync();

    public async Task<Procedimento> GetByIdAsync(int id) =>
        await _procedimentoRepository.GetByIdAsync(id);

    public async Task AddAsync(Procedimento procedimento) =>
        await _procedimentoRepository.AddAsync(procedimento);

    public async Task UpdateAsync(Procedimento procedimento) =>
        await _procedimentoRepository.UpdateAsync(procedimento);

    public async Task DeleteAsync(int id) =>
        await _procedimentoRepository.DeleteAsync(id);
}