namespace DapperEFRepoProject.Modules.Contacts.Request
{
    /// <summary>
    /// Represents the request to update a contact.
    /// </summary>
    public struct DeleteContactRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteContactRequest"/> struct.
        /// </summary>
        public DeleteContactRequest()
        {
        }
        /// <summary>
        /// Gets or sets the id of the contact.
        /// </summary>
        public int Id { get; set; }
    }
}