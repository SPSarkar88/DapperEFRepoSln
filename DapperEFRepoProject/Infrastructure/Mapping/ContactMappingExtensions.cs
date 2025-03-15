using DapperEFRepoProject.Models;
using DapperEFRepoProject.Modules.Contacts.Request;
using DapperEFRepoProject.Modules.Contacts.Response;

namespace DapperEFRepoProject.Infrastructure.Mapping
{
    /// <summary>
    /// Represents the extension methods for mapping contacts.
    /// </summary>
    public static class ContactMappingExtensions
    {
        /// <summary>
        /// Converts a <see cref="CreateContactRequest"/> to a <see cref="Contact"/>.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Contact ToContact(this CreateContactRequest request)
        {
            return new Contact
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
        /// <summary>
        /// Converts a <see cref="UpdateContactRequest"/> to a <see cref="Contact"/>.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Contact ToContact(this UpdateContactRequest request)
        {
            return new Contact
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                UpdatedAt = DateTime.UtcNow // Set to current UTC time: 2025-03-14 16:31:45
            };
        }
        /// <summary>
        /// Converts a <see cref="DeleteContactRequest"/> to a <see cref="Contact"/>.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Contact ToContact(this DeleteContactRequest request)
        {
            return new Contact{Id = request.Id};
        }
        /// <summary>
        /// Updates a <see cref="Contact"/> from a <see cref="UpdateContactRequest"/>.
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Contact UpdateFrom(this Contact contact, UpdateContactRequest request)
        {
            contact.FirstName = request.FirstName;
            contact.LastName = request.LastName;
            contact.Email = request.Email;
            contact.PhoneNumber = request.PhoneNumber;
            contact.Address = request.Address;
            contact.UpdatedAt = DateTime.UtcNow; // Set to current UTC time: 2025-03-14 16:31:45

            return contact;
        }
        /// <summary>
        /// Converts a <see cref="Contact"/> to a <see cref="ContactResponse"/>.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static ContactResponse ToContactResponse(this Contact contact)
        {
            return new ContactResponse
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Address = contact.Address,
                CreatedAt = contact.CreatedAt,
                UpdatedAt = contact.UpdatedAt
            };
        }
        /// <summary>
        /// Converts a collection of <see cref="Contact"/> to a <see cref="ContactListResponse"/>.
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public static ContactListResponse ToContactListResponse(this IEnumerable<Contact> contacts)
        {
            return new ContactListResponse
            {
                Contacts = contacts.Select(c => c.ToContactResponse()).ToList()
            };
        }
    }
}