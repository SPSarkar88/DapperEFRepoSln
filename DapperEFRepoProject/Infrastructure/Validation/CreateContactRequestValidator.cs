using FluentValidation;
using DapperEFRepoProject.Modules.Contacts.Request;

namespace DapperEFRepoProject.Infrastructure.Validation
{
    public class CreateContactRequestValidator : AbstractValidator<CreateContactRequest>
    {
        public CreateContactRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).MaximumLength(100);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
        }
    }
}