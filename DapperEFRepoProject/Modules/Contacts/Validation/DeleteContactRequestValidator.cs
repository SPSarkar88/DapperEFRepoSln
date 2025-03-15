using FluentValidation;
using DapperEFRepoProject.Modules.Contacts.Request;

namespace DapperEFRepoProject.Modules.Contacts.Validation
{
    /// <summary>
    /// Represents the validator for the <see cref="DeleteContactRequest"/> struct.
    /// </summary>
    public class DeleteContactRequestValidator : AbstractValidator<DeleteContactRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteContactRequestValidator"/> class.
        /// </summary>
        public DeleteContactRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}