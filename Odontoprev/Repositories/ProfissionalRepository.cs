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

public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly string _connectionString;

        public ProfissionalRepository(IOptions<OracleSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        private IDbConnection CreateConnection() =>
            new OracleConnection(_connectionString);

        public async Task<IEnumerable<Profissional>> GetAllAsync()
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM PROFISSIONAL_OP";
            return await connection.QueryAsync<Profissional>(query);
        }

        public async Task<Profissional> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM PROFISSIONAL_OP WHERE ID = :Id";
            return await connection.QueryFirstOrDefaultAsync<Profissional>(query, new { Id = id });
        }

        public async Task AddAsync(Profissional profissional)
        {
            using var connection = CreateConnection();
            string query = @"INSERT INTO PROFISSIONAL_OP 
                             (ID, CRM, NOME_COMPLETO, ESPECIALIDADE_ODONTOLOGICA, CONTATO, HORARIO_DE_CONSULTA, AVALIACAO_QUALIDADE_SERVICO, PACIENTE_OP_ID) 
                             VALUES (:Id, :Crm, :NomeCompleto, :EspecialidadeOdontologica, :Contato, :HorarioDeConsulta, :AvaliacaoQualidadeServico, :PacienteOpId)";
            await connection.ExecuteAsync(query, profissional);
        }

        public async Task UpdateAsync(Profissional profissional)
        {
            using var connection = CreateConnection();
            string query = @"UPDATE PROFISSIONAL_OP 
                             SET CRM = :Crm, 
                                 NOME_COMPLETO = :NomeCompleto, 
                                 ESPECIALIDADE_ODONTOLOGICA = :EspecialidadeOdontologica, 
                                 CONTATO = :Contato, 
                                 HORARIO_DE_CONSULTA = :HorarioDeConsulta, 
                                 AVALIACAO_QUALIDADE_SERVICO = :AvaliacaoQualidadeServico, 
                                 PACIENTE_OP_ID = :PacienteOpId
                             WHERE ID = :Id";
            await connection.ExecuteAsync(query, profissional);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "DELETE FROM PROFISSIONAL_OP WHERE ID = :Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }