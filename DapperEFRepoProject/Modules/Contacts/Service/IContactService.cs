using DapperEFRepoProject.Models;

namespace DapperEFRepoProject.Modules.Contacts.Service
{
    public interface IContactService
    {
        Task<int> CountContactsAsync();
        Task<Contact> CreateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int id);
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact?> GetContactAsync(int id);
        Task<IEnumerable<Contact>> GetRecentContactsAsync(int count);
        Task<IEnumerable<Contact>> SearchContactsAsync(string searchTerm);
        Task<Contact?> UpdateContactAsync(Contact contact);
    }
}