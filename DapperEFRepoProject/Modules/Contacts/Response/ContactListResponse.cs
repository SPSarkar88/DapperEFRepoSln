namespace DapperEFRepoProject.Modules.Contacts.Response
{
    public struct ContactListResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactListResponse"/> struct.
        /// </summary>
        public ContactListResponse() { }
        /// <summary>
        /// Gets or sets the list of contact.
        /// </summary>
        public List<ContactResponse> Contacts { get; set; } = new List<ContactResponse>();
        /// <summary>
        /// Gets or sets the total number of contacts.
        /// </summary>
        public int TotalContacts { get; set; }
    }
}