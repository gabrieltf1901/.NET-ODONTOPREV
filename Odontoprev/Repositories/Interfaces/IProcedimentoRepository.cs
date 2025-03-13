using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;

namespace Odontoprev.Repositories.Interfaces;

public interface IProcedimentoRepository
{
    Task<IEnumerable<Procedimento>> GetAllAsync();
    Task<Procedimento> GetByIdAsync(int id);
    Task AddAsync(Procedimento procedimento);
    Task UpdateAsync(Procedimento procedimento);
    Task DeleteAsync(int id);
}