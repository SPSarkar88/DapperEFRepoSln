namespace DapperEFRepoProject.Modules.Contacts.Request
{
    /// <summary>
    /// Represents the request to create a contact.
    /// </summary>
    public struct CreateContactRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateContactRequest"/> struct.
        /// </summary>
        public CreateContactRequest()
        {
        }
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
    }
}
