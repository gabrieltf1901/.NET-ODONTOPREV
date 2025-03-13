using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;
using Odontoprev.Repositories.Interfaces;
using Odontoprev.Services.Interfaces;

namespace Odontoprev.Services;

public class FaturamentoService : IFaturamentoService
{
    private readonly IFaturamentoRepository _faturamentoRepository;

    public FaturamentoService(IFaturamentoRepository faturamentoRepository)
    {
        _faturamentoRepository = faturamentoRepository;
    }

    public async Task<IEnumerable<Faturamento>> GetAllAsync() =>
        await _faturamentoRepository.GetAllAsync();

    public async Task<Faturamento> GetByIdAsync(int id) =>
        await _faturamentoRepository.GetByIdAsync(id);

    public async Task AddAsync(Faturamento faturamento) =>
        await _faturamentoRepository.AddAsync(faturamento);

    public async Task UpdateAsync(Faturamento faturamento) =>
        await _faturamentoRepository.UpdateAsync(faturamento);

    public async Task DeleteAsync(int id) =>
        await _faturamentoRepository.DeleteAsync(id);
}