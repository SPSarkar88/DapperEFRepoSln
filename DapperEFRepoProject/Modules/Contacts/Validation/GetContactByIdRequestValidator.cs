using DapperEFRepoProject.Modules.Contacts.Request;
using FluentValidation;

namespace DapperEFRepoProject.Modules.Contacts.Validation
{
    /// <summary>
    /// Represents the get contact by id request validator.
    /// </summary>
    public class GetContactByIdRequestValidator : AbstractValidator<GetContactByIdRequest>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="GetContactByIdRequestValidator"/> class.
        /// </summary>
        public GetContactByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
