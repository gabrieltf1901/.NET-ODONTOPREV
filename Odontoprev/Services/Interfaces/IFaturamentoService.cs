using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;

namespace Odontoprev.Services.Interfaces;

public interface IFaturamentoService
{
    Task<IEnumerable<Faturamento>> GetAllAsync();
    Task<Faturamento> GetByIdAsync(int id);
    Task AddAsync(Faturamento faturamento);
    Task UpdateAsync(Faturamento faturamento);
    Task DeleteAsync(int id);
}