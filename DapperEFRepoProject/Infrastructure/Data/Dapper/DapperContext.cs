using System.Data;
using Microsoft.Data.SqlClient;

namespace ContactManager.Infrastructure.Data.Dapper
{
    /// <summary>
    /// Represents the Dapper context.
    /// </summary>
    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DapperContext"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        /// <summary>
        /// Creates a new connection to the database asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}