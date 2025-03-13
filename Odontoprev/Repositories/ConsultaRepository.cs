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

public class ConsultaRepository : IConsultaRepository
    {
        private readonly string _connectionString;

        public ConsultaRepository(IOptions<OracleSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        private IDbConnection CreateConnection() =>
            new OracleConnection(_connectionString);

        public async Task<IEnumerable<Consulta>> GetAllAsync()
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM CONSULTA_OP";
            return await connection.QueryAsync<Consulta>(query);
        }

        public async Task<Consulta> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM CONSULTA_OP WHERE ID = :Id";
            return await connection.QueryFirstOrDefaultAsync<Consulta>(query, new { Id = id });
        }

        public async Task AddAsync(Consulta consulta)
        {
            using var connection = CreateConnection();
            string query = @"INSERT INTO CONSULTA_OP 
                             (ID, DATA_HORA_CONSULTA, TIPO_PROCEDIMENTO, VALOR_CONSULTA, STATUS, PROFISSIONAL_OP_ID) 
                             VALUES (:Id, :DataHoraConsulta, :TipoProcedimento, :ValorConsulta, :Status, :ProfissionalOpId)";
            await connection.ExecuteAsync(query, consulta);
        }

        public async Task UpdateAsync(Consulta consulta)
        {
            using var connection = CreateConnection();
            string query = @"UPDATE CONSULTA_OP 
                             SET DATA_HORA_CONSULTA = :DataHoraConsulta, 
                                 TIPO_PROCEDIMENTO = :TipoProcedimento, 
                                 VALOR_CONSULTA = :ValorConsulta, 
                                 STATUS = :Status, 
                                 PROFISSIONAL_OP_ID = :ProfissionalOpId
                             WHERE ID = :Id";
            await connection.ExecuteAsync(query, consulta);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "DELETE FROM CONSULTA_OP WHERE ID = :Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
