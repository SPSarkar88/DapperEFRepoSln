using System.Data;

namespace ContactManager.Infrastructure.Data.Dapper
{
    public interface IDapperContext
    {
        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <returns></returns>
        IDbConnection CreateConnection();

        /// <summary>
        /// Creates a new connection to the database asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IDbConnection> CreateConnectionAsync();
    }
}