namespace DapperEFRepoProject.Modules.Contacts.Request
{
    /// <summary>
    /// Represents the get contact by id request.
    /// </summary>
    public struct GetContactByIdRequest
    {
        /// <summary>
        /// Creates a new instance of the <see cref="GetContactByIdRequest"/> class.
        /// </summary>
        public GetContactByIdRequest()
        {
            
        }
        /// <summary>
        /// The unique identifier of the contact.
        /// </summary>
        public int Id{ get; set; }
    }
}
