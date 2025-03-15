using DapperEFRepoProject.Infrastructure.Data.EFCore;
using DapperEFRepoProject.Models;
using DapperEFRepoProject.Modules.Contacts.Respository;
using Microsoft.EntityFrameworkCore;

namespace DapperEFRepoProject.Modules.Contacts.Service
{
    /// <summary>
    /// Represents a service for managing contacts in the database.
    /// </summary>
    public class ContactService : IContactService
    {
        /// <summary>
        /// The database context used to interact with the database.
        /// </summary>
        private readonly ApplicationDbContext _dbContext;
        /// <summary>
        /// The Dapper repository used to interact with the database.
        /// </summary>
        private readonly ContactDapperRepository _dapperRepo;

        /// <summary>
        /// Creates a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dapperRepo"></param>
        public ContactService(ApplicationDbContext dbContext, ContactDapperRepository dapperRepo)
        {
            _dbContext = dbContext;
            _dapperRepo = dapperRepo;
        }
        /// <summary>
        /// Creates a new contact in the database.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }
        /// <summary>
        /// Gets a contact from the database by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Contact?> GetContactAsync(int id)
        {
            return await _dbContext.Contacts.FindAsync(id);
        }
        /// <summary>
        /// Gets all contacts from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }
        /// <summary>
        /// Updates an existing contact in the database.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task<Contact?> UpdateContactAsync(Contact contact)
        {
            var existingContact = await _dbContext.Contacts.FindAsync(contact.Id);
            if (existingContact == null)
                return null;

            _dbContext.Entry(existingContact).CurrentValues.SetValues(contact);
            existingContact.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return existingContact;
        }
        /// <summary>
        /// Deletes a contact from the database by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact == null)
                return false;

            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Searches for contacts in the database based on a search term.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Contact>> SearchContactsAsync(string searchTerm)
        {
            return await _dapperRepo.SearchContactsAsync(searchTerm);
        }
        /// <summary>
        /// Gets the most recent contacts from the database.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Contact>> GetRecentContactsAsync(int count)
        {
            return await _dapperRepo.GetRecentContactsAsync(count);
        }
        /// <summary>
        /// Counts the number of contacts in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountContactsAsync()
        {
            return await _dapperRepo.CountContactsAsync();
        }
    }
}