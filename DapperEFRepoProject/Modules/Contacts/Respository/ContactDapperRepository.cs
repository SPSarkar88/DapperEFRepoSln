using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using DapperEFRepoProject.Models;

namespace DapperEFRepoProject.Modules.Contacts.Respository
{
    /// <summary>
    /// Represents a repository for managing contacts in the database.
    /// </summary>
    public class ContactDapperRepository : IContactDapperRepository
    {
        /// <summary>
        /// The connection string used to connect to the database.
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        /// Creates a new instance of the <see cref="ContactDapperRepository"/> class.
        /// </summary>
        /// <param name="connectionString"></param>
        public ContactDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <returns></returns>
        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        /// <summary>
        /// Searches for contacts in the database based on a search term.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Contact>> SearchContactsAsync(string searchTerm)
        {
            using var connection = CreateConnection();
            connection.Open();

            var query = @"
                SELECT * FROM Contacts 
                WHERE FirstName LIKE @Search 
                OR LastName LIKE @Search 
                OR Email LIKE @Search
                OR PhoneNumber LIKE @Search";

            return await connection.QueryAsync<Contact>(
                query,
                new { Search = $"%{searchTerm}%" }
            );
        }
        /// <summary>
        /// Gets the most recent contacts from the database.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Contact>> GetRecentContactsAsync(int count)
        {
            using var connection = CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Contact>(
                "SELECT TOP (@Count) * FROM Contacts ORDER BY CreatedAt DESC",
                new { Count = count }
            );
        }
        /// <summary>
        /// Gets a contact by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            using var connection = CreateConnection();
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<Contact>(
                "SELECT * FROM Contacts WHERE Id = @Id",
                new { Id = id }
            );
        }
        /// <summary>
        /// Counts the number of contacts in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountContactsAsync()
        {
            using var connection = CreateConnection();
            connection.Open();

            return await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM Contacts"
            );
        }
    }
}