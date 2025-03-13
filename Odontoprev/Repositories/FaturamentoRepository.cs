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

public class FaturamentoRepository : IFaturamentoRepository
    {
        private readonly string _connectionString;

        public FaturamentoRepository(IOptions<OracleSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        private IDbConnection CreateConnection() =>
            new OracleConnection(_connectionString);

        public async Task<IEnumerable<Faturamento>> GetAllAsync()
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM FATURAMENTO_OP";
            return await connection.QueryAsync<Faturamento>(query);
        }

        public async Task<Faturamento> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM FATURAMENTO_OP WHERE ID = :Id";
            return await connection.QueryFirstOrDefaultAsync<Faturamento>(query, new { Id = id });
        }

        public async Task AddAsync(Faturamento faturamento)
        {
            using var connection = CreateConnection();
            string query = @"INSERT INTO FATURAMENTO_OP 
                             (ID, DATA_EMISSAO, VALOR_TOTAL, STATUS, PROCEDIMENTO_OP_ID) 
                             VALUES (:Id, :DataEmissao, :ValorTotal, :Status, :ProcedimentoOpId)";
            await connection.ExecuteAsync(query, faturamento);
        }

        public async Task UpdateAsync(Faturamento faturamento)
        {
            using var connection = CreateConnection();
            string query = @"UPDATE FATURAMENTO_OP 
                             SET DATA_EMISSAO = :DataEmissao, 
                                 VALOR_TOTAL = :ValorTotal, 
                                 STATUS = :Status, 
                                 PROCEDIMENTO_OP_ID = :ProcedimentoOpId
                             WHERE ID = :Id";
            await connection.ExecuteAsync(query, faturamento);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "DELETE FROM FATURAMENTO_OP WHERE ID = :Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }