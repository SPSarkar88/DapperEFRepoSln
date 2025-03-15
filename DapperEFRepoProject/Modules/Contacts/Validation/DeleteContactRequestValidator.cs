using FluentValidation;
using DapperEFRepoProject.Modules.Contacts.Request;

namespace DapperEFRepoProject.Modules.Contacts.Validation
{
    public class DeleteContactRequestValidator : AbstractValidator<DeleteContactRequest>
    {
        public DeleteContactRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}