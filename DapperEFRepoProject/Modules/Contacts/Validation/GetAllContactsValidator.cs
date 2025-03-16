using DapperEFRepoProject.Modules.Contacts.Request;
using FluentValidation;

namespace DapperEFRepoProject.Modules.Contacts.Validation
{
    /// <summary>
    /// Represents the get contact by id request validator.
    /// </summary>
    public class GetAllContactsRequestValidator : AbstractValidator<GetAllContactRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllContactsRequestValidator"/> class.
        /// </summary>
        public GetAllContactsRequestValidator()
        {
        }
    }
}
