using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using Odontoprev.Data;
using Odontoprev.Models.Entities;
using Odontoprev.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Odontoprev.Repositories;

public class PacienteRepository : IPacienteRepository
    {
        private readonly string _connectionString;

        public PacienteRepository(IOptions<OracleSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        private IDbConnection CreateConnection() =>
            new OracleConnection(_connectionString);

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM PACIENTE_OP";
            return await connection.QueryAsync<Paciente>(query);
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM PACIENTE_OP WHERE ID = :Id";
            return await connection.QueryFirstOrDefaultAsync<Paciente>(query, new { Id = id });
        }

        public async Task AddAsync(Paciente paciente)
        {
            using var connection = CreateConnection();
            string query = @"INSERT INTO PACIENTE_OP 
                             (ID, NOME_COMPLETO, DATA_NASCIMENTO, CONTATO, PLANO_DE_SAUDE, HISTORICO_MEDICO) 
                             VALUES (:Id, :NomeCompleto, :DataNascimento, :Contato, :PlanoDeSaude, :HistoricoMedico)";
            await connection.ExecuteAsync(query, paciente);
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            using var connection = CreateConnection();
            string query = @"UPDATE PACIENTE_OP 
                             SET NOME_COMPLETO = :NomeCompleto, 
                                 DATA_NASCIMENTO = :DataNascimento, 
                                 CONTATO = :Contato, 
                                 PLANO_DE_SAUDE = :PlanoDeSaude, 
                                 HISTORICO_MEDICO = :HistoricoMedico
                             WHERE ID = :Id";
            await connection.ExecuteAsync(query, paciente);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "DELETE FROM PACIENTE_OP WHERE ID = :Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }