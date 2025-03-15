namespace DapperEFRepoProject.Modules.Contacts.Response
{
    /// <summary>
    /// Represents the response for a contact.
    /// </summary>
    public struct ContactResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactResponse"/> struct.
        /// </summary>
        public ContactResponse() { }
        /// <summary>
        /// Gets or sets the identifier of the contact.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the email of the contact.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the address of the contact.
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Gets or sets the date and time the contact was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the date and time the contact was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}