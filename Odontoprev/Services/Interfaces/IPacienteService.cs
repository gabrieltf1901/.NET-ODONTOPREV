using System.Collections.Generic;
using System.Threading.Tasks;
using Odontoprev.Models.Entities;

namespace Odontoprev.Services.Interfaces;

public interface IPacienteService
{
    Task<IEnumerable<Paciente>> GetAllAsync();
    Task<Paciente> GetByIdAsync(int id);
    Task AddAsync(Paciente paciente);
    Task UpdateAsync(Paciente paciente);
    Task DeleteAsync(int id);
}