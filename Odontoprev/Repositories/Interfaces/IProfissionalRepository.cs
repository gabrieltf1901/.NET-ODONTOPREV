using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;

namespace Odontoprev.Repositories.Interfaces;

public interface IProfissionalRepository
{
    Task<IEnumerable<Profissional>> GetAllAsync();
    Task<Profissional> GetByIdAsync(int id);
    Task AddAsync(Profissional profissional);
    Task UpdateAsync(Profissional profissional);
    Task DeleteAsync(int id);
}