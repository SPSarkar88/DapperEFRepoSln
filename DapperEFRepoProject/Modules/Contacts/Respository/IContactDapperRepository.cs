using DapperEFRepoProject.Models;

namespace DapperEFRepoProject.Modules.Contacts.Respository
{
    public interface IContactDapperRepository
    {
        Task<int> CountContactsAsync();
        Task<Contact?> GetContactByIdAsync(int id);
        Task<IEnumerable<Contact>> GetRecentContactsAsync(int count);
        Task<IEnumerable<Contact>> SearchContactsAsync(string searchTerm);
    }
}