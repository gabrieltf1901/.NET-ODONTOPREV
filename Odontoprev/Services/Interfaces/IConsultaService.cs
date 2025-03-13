using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;

namespace Odontoprev.Services.Interfaces;

public interface IConsultaService
{
    Task<IEnumerable<Consulta>> GetAllAsync();
    Task<Consulta> GetByIdAsync(int id);
    Task AddAsync(Consulta consulta);
    Task UpdateAsync(Consulta consulta);
    Task DeleteAsync(int id);
}