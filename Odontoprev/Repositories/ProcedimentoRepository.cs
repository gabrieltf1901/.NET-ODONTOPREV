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

public class ProcedimentoRepository : IProcedimentoRepository
    {
        private readonly string _connectionString;

        public ProcedimentoRepository(IOptions<OracleSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        private IDbConnection CreateConnection() =>
            new OracleConnection(_connectionString);

        public async Task<IEnumerable<Procedimento>> GetAllAsync()
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM PROCEDIMENTO_OP";
            return await connection.QueryAsync<Procedimento>(query);
        }

        public async Task<Procedimento> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "SELECT * FROM PROCEDIMENTO_OP WHERE ID = :Id";
            return await connection.QueryFirstOrDefaultAsync<Procedimento>(query, new { Id = id });
        }

        public async Task AddAsync(Procedimento procedimento)
        {
            using var connection = CreateConnection();
            string query = @"INSERT INTO PROCEDIMENTO_OP 
                             (ID, DESCRICAO, PRECO_UNITARIO, CATEGORIA, CONSULTA_OP_ID) 
                             VALUES (:Id, :Descricao, :PrecoUnitario, :Categoria, :ConsultaOpId)";
            await connection.ExecuteAsync(query, procedimento);
        }

        public async Task UpdateAsync(Procedimento procedimento)
        {
            using var connection = CreateConnection();
            string query = @"UPDATE PROCEDIMENTO_OP 
                             SET DESCRICAO = :Descricao, 
                                 PRECO_UNITARIO = :PrecoUnitario, 
                                 CATEGORIA = :Categoria, 
                                 CONSULTA_OP_ID = :ConsultaOpId
                             WHERE ID = :Id";
            await connection.ExecuteAsync(query, procedimento);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            string query = "DELETE FROM PROCEDIMENTO_OP WHERE ID = :Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }