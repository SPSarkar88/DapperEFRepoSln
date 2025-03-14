namespace DapperEFRepoProject.Models
{
    /// <summary>
    /// Represents a contact in the address book.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// The unique identifier for the contact.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the contact.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The last name of the contact.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The email address of the contact.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The phone number of the contact.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// The address of the contact.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// The date and time the contact was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The date and time the contact was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}